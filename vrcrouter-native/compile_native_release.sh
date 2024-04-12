#!/bin/bash

clang native.cpp --shared -o vrcrouter_native.dll -O3 -Wno-undefined-internal --target=x86_64-pc-windows-msvc
# cp vrcrouter_native.dll "../VRCRouter/bin/Debug/net6.0/vrcrouter_native.dll"
# cp vrcrouter_native.dll "../VRCRouter/bin/Release/net6.0/vrcrouter_native.dll"
# cp vrcrouter_native.dll "../vrcrouter-netf/vrcrouter-config/bin/Debug/" 
