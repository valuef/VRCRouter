# VRCRouter
Lightweight and configurable OSC router for VRChat PCVR.

## Features
* Configuration interface.
* Low CPU & RAM footprint.
* Start with SteamVR.
* OSC Message routing from VRChat to specified address:port.
* Application autostarting and autoclosing.

## Download
[Download from the Releases page](https://github.com/valuef/VRCRouter/releases/)

## Usage Tutorial
https://www.youtube.com/watch?v=8abMvrzguo4

## Issues/Merges
I don't check GitHub so poke me on [other socials](https://shader.gay) in case you've opened a ticket.

## Building release
Run the compile-release-all-netf.sh script on cygwin.
Msbuild path is hard-coded into the script.
Clang must be accessible on the PATH.

Final binaries will be placed in staging/ship/

For a proper release, the final package should contain the following files/folders:
  * manifest.vrmanifest
  * openvr_api.dll
  * USAGE.txt
  * route presets
