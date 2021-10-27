This is the code for the native plugin component for MARS as an AR Subsystem.  The native plugin provides the camera pose to AR Subsystems as there is no C# API for this.  It is based on the [XR StarterKit](https://github.cds.internal.unity3d.com/unity/xr.sdk.starter-kit).

`TrackingProvider.cpp` exports `MARSXRSubsystem_SetCameraPose` which is called from `CameraSubsystem.cs` when the camera pose is updated; this pose is then passed to AR Subsystems when requested.

## Building

```
bee.exe
```

or on Mac:

```
mono bee.exe
```
Then create a universal binary
```
lipo -create build/mac_arm64/MARSXRSubsystem.dylib build/mac_x64/MARSXRSubsystem.dylib -output build/MARSXRSubsystem.dylib
```
Manually sign the dylib with codesign.
