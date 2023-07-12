# VRCRouter
Lightweight and configurable OSC router for VRChat.

## Usage Tutorial
https://www.youtube.com/watch?v=8abMvrzguo4

## Issues/Merges
I don't check GitHub so poke me on other socials in case you've opened a ticket:
  https://shader.gay

## Building release
Run the compile-release-all-netf.sh script (I use cygwin)
msbuild and clang must be accessible on the PATH.

Final binaries should be in staging/ship/

For a proper release, the final package should contain the following files/folders:
  * manifest.vrmanifest
  * openvr_api.dll
  * USAGE.txt
  * route presets
