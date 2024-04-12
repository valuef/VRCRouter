#include <stdio.h>
#include <windows.h>
#include <TlHelp32.h>

#define COMBINE1(X,Y) X##Y
#define CMB(X,Y) COMBINE1(X,Y)

template<typename T>
struct DeferExitScope {
  T lambda;

  DeferExitScope(T l) : lambda(l) {}

  ~DeferExitScope() { lambda(); }
  DeferExitScope(const DeferExitScope &);

  operator bool() const { return true; }

private:
  DeferExitScope& operator = (const DeferExitScope &);
};
 
class DeferExitScopeHelp {
public:
  template<typename T>
  DeferExitScope<T> operator+(T t){ return t;}
};
 
#define defer const auto & CMB(defer__, __COUNTER__) = DeferExitScopeHelp() + [&]()

extern "C" __declspec(dllexport)
bool
__cdecl
terminate_app(DWORD process_id) {
  auto handle = OpenProcess(PROCESS_TERMINATE, FALSE, process_id);

  do {
    HANDLE snapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
    if(snapshot == INVALID_HANDLE_VALUE) {
      printf("\tFailed to get process snapshot. Error code is: %ld\n", GetLastError());
      return false;
    }
    defer { CloseHandle(snapshot); };

    PROCESSENTRY32 process_entry = {};
    process_entry.dwSize = sizeof(process_entry);

    if(!Process32First(snapshot, &process_entry)) {
      printf("\tCall to Process32First failed. Error code is: %ld\n", GetLastError());
      return false;
    }

    do {
      if(process_entry.th32ParentProcessID == process_id) {
        auto child_handle = OpenProcess(PROCESS_TERMINATE, FALSE, process_entry.th32ProcessID);
        if(child_handle == NULL) {
          printf("\tFailed to OpenProcess to terminate process '%s'. Error code is: %ld\n", process_entry.szExeFile, GetLastError());
        }
        else {
          printf("\tClosing child process %s (pid %lu handle %p)\n", process_entry.szExeFile, process_entry.th32ProcessID, child_handle);
          TerminateProcess(child_handle, 0);
          CloseHandle(child_handle); 
        }
      }
    } while(Process32Next(snapshot, &process_entry));

  } while(false);

  TerminateProcess(handle, 0);
  CloseHandle(handle);

  return true;
}

struct Autostart_App_Result {
  DWORD id;
  DWORD error;
  bool success;
};

extern "C" __declspec(dllexport)
void
__cdecl
launch_autostart_app(
  wchar_t *path,
  wchar_t *args,
  wchar_t *working_dir,
  Autostart_App_Result *ret
) {
  STARTUPINFOW si = {};
  si.cb = sizeof(si);
  PROCESS_INFORMATION pi = {};

  auto result = CreateProcessW(
    path, args,
    0, 
    0, 
    false, 
    CREATE_NEW_CONSOLE, 
    0, 
    working_dir,
    &si, 
    &pi
  );

  *ret = {};

  if(result) {
    ret->success = true;
    ret->id = pi.dwProcessId;

    CloseHandle(pi.hProcess);
    CloseHandle(pi.hThread);

    return;
  }

  ret->error = GetLastError();
  ret->success = false;
}


extern "C" __declspec(dllexport)
bool
__cdecl
wait_for_vrchat_to_start() {
  while(true) {
    HANDLE snapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
    if(snapshot == INVALID_HANDLE_VALUE) {
      //logt_error("vrchat", "Failed to get a list of all running processes. Not going to wait for VRChat...\n");
      return false;
    }

    defer { CloseHandle(snapshot); };

    PROCESSENTRY32 process_entry = {};
    process_entry.dwSize = sizeof(process_entry);
    if(!Process32First(snapshot, &process_entry)) {
      //logt_error("vrchat", "Failed to retrieve information about the first process. Not going to wait for VRChat...\n");
      return false;
      break;
    }

    do {
      auto *name = process_entry.szExeFile;
      auto *vrc_name = "VRChat.exe";

      if(strcmp(name, vrc_name) == 0) {
        return true;
      }

    } while(Process32Next(snapshot, &process_entry));

    Sleep(1000);
  }
}


extern "C" __declspec(dllexport)
bool
__cdecl
terminate_app_by_name(
  wchar_t *search_for_name
) {
  HANDLE snapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
  if(snapshot == INVALID_HANDLE_VALUE) {
    //logt_error("vrchat", "Failed to get a list of all running processes. Not going to wait for VRChat...\n");
    return false;
  }

  defer { CloseHandle(snapshot); };

  PROCESSENTRY32W process_entry = {};
  process_entry.dwSize = sizeof(process_entry);
  if(!Process32FirstW(snapshot, &process_entry)) {
    //logt_error("vrchat", "Failed to retrieve information about the first process. Not going to wait for VRChat...\n");
    return false;
  }

  do {
    auto *got_name = process_entry.szExeFile;

    if(wcscmp(got_name, search_for_name) == 0) {
      return terminate_app(process_entry.th32ProcessID);
    }

  } while(Process32NextW(snapshot, &process_entry));

  return false;
}

