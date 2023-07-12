Main .NET framework solution.

## vrcrouter
The router.

## vrcrouter-config
The winforms configuration app. Pretty much a front-end to the route json files with some QOL stuff
to test functionality.

## vrcrouter-common
Common shared code between router and configuration

## Building

Build from Visual Studio.

Both the router and the config will require the following files in the same folder for proper
functionality:
  * manifest.vrmanifest
  * openvr_api.dll
  * vrcrouter_native.dll

These files are not automatically copied on build. Please do so manually.
