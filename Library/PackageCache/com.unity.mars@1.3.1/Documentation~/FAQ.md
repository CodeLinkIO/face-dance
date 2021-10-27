# Frequently Asked Questions (FAQ)

## Can I use photogrammetry scans?

Yes. When [creating a new Simulation Environment](SimulationEnvironments.md), you can import photogrammetry scans or other point cloud data, and then proceed with the Environment Settings, Plane Extraction, and XRay setup.

## How do I move in Device View?

First, press the **Play** button in the **View** toolbar. Then, hold the right mouse button to look around,  and move using WASD controls. Use Q and E to lower and raise your height.  This view is intentionally restricted to human-like movement; if you want free camera controls in the simulation scene, switch to the **As Scene** view type from the **View** toolbar.  See the [UI Overview](UIOverview.md#simulation-view) for more information on Simulation and Device Views.

## How can I use my camera feed for face tracking workflows while in the Editor?

This is currently possible, but you must first acquire a separate third-party license. Please contact us directly at mars@unity3d.com.

## How do I use face detection and world/plane tracking at the same time?

Unity MARS supports designing these experiences, but there are no devices that currently support the required feature set. It would be possible with a face tracking provider that works on top of the ARKit or ARCore video stream, rather than exclusive to it.

## How can I do the face animation motion-capture with a mobile phone that I saw at Unite Berlin?

You might be thinking of the [Facial AR Remote](https://blogs.unity3d.com/2018/08/13/facial-ar-remote-animating-with-ar/) project. You can download it from its own GitHub [repository](https://github.com/Unity-Technologies/facial-ar-remote). Our team is working on building an AR face feature set into Unity MARS, but for now these are two separate projects.

## I built my Scene to a device and all I see is a black screen. What went wrong?

This could happen for a number of reasons. First, double-check the following:
  * Ensure you have the [**ARCore XR Plugin**](https://docs.unity3d.com/Packages/com.unity.xr.arcore@latest/index.html) for Android or [**ARKit XR Plugin**](https://docs.unity3d.com/Packages/com.unity.xr.arkit@latest/index.html) for iOS installed via Package Manager.
  * Ensure you have [**Unity MARS AR Foundation Providers**](https://docs.unity3d.com/Packages/com.unity.mars-ar-foundation-providers@latest/index.html) package installed via the Package Manager. If you upgraded Unity MARS or directly add the Unity MARS Package from the package manager [**Unity MARS AR Foundation Providers**](https://docs.unity3d.com/Packages/com.unity.mars-ar-foundation-providers@latest/index.html) may not be installed or at the correct version.
  * The `FunctionalityInjectionModule` in `Assets/ModuleLoader/Settings/Resources` has a `Default Island` set, and this defines `Default Providers` including `ARFoundationPlaneProvider`, etc. from the `AR Foundation Providers` package.
  * Refer to [**AR Background Setup in Unity MARS**](Graphics.md#ar-background-setup-in-unity-mars) for Unity MARS setup.
  * If you are using URP (Universal Render Pipeline; formerly Lightweight Render Pipeline (LWRP)), ensure that the AR Background Renderer Feature is added to your SRP configuration (generally onto the ForwardRenderer asset for URP projects). The AR Background Render Feature requires AR Foundation 3.0.1 or greater. For more information, refer to [this additional documentation to configure an AR Foundation project with a URP](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@3.0/manual/ar-camera-background-with-scriptable-render-pipeline.html).
  * Note that **Custom Scriptable Render Pipelines** and **High Definition Render Pipeline (HDRP)** do not support the AR Background setup provided by **AR Foundation** and will require you to create a custom implementation.
  * Check the device log using `adb logcat` or running the app through XCode. Unity logs errors on-screen if you create a development build, but you might miss some warnings.

## I set up face tracking correctly but it doesn't work on my iOS device. Which devices are supported?

ARKit face tracking support is exclusive to newer devices that support face ID. A listing of supported devices is here: https://support.apple.com/en-us/HT209183.

## I am using SRP/URP/HDRP and see a black screen in the Editor Play Mode. What went wrong?

Enable the `UseFallbackCompositeRendering` checkbox in the `CompositeRenderModuleOptions` scriptable object under **Assets/MARS/UserSettings/** to combine the AR environment with your Scene instead of trying to composite it separately. Alternatively, go to **Project Settings &gt; MARS &gt; Editor Visuals**, navigate to the **Composite Render** section, and enable the **Use Fallback Composite Rendering** option.

## I am using URP and the Room X-Ray is not working, appears flipped or backward. What went wrong?

Enable `FlipXRayDirection` in the `XRayOptions`. Alternatively, go to **Project Settings &gt; MARS &gt; Editor Visuals**, navigate to the **X-Ray Module** section, and enable the **Flip X Ray Direction** option.

## I am getting a crash on macOS Catalina when building for device X, what can I do?

The Post Processing package can cause crashes on macOS Catalina on some devices.
To fix this issue, follow these steps:
1. Go to the **Player Settings** window (menu: **Edit &gt; Project Settings &gt; Player Settings**) and select your build platform.
2. Expand the **Other** section.
3. In the **Scripting Define Symbols** field, remove `UNITY_POST_PROCESSING_STACK_V2`.
4. Remove the Post Processing package.

## Why am I getting rendering artifacts in the simulated environment?

World scale can cause rendering artifacts in the simulated environment as the scale moves further away from 1.
This can cause shadows to appear cut off in the simulation environment.

## I get strange behaviors when working with Faces. What's wrong?

Face workflows and content placement do not behave the same on all platforms.
This includes geometry being flipped or not correctly matching the size of the matched face.

## Unity MARS is slow, what can I do?

Some debug simulation playback options, such as raycast visualization, greatly affect performance. To improve performance, disable these options in **Project Settings** under**MARS &gt; Debug Settings &gt; Simulated Data Discovery**).

## I selected X condition and cannot see the condition handle right away.

Condition tool handles are only visible in the active view and might require a click in the view before becoming interactable.

## I am getting lots of compiler errors, what happened?
This could happen when you have different versions of `AR Foundation` matching ARCore, ARKit, Hololens, or Magic Leap versions. Make sure that all versions you are using in your project match.
For more information, see AR Foundation Providers package documentation to see how to handle package versions.

## Where can I find Unity MARS examples?
This package comes with sample content that you can optionally install from the **Package Manager** window (menu: **Window &gt; Package Manager**, then search for Unity MARS).
To import the samples, click the **Import into project** button.

![FAQ Unity MARS samples](images/FAQ/MARS-samples.png)

## Which features of Unity MARS are disabled if I don't have an active license? Will builds work without a license? What happens if I don't have Internet access?
In short: without an active license, most of the MARS workflows and the simulation are disabled, but built apps will be unaffected. Built apps work with or without an active license. All app builds are considered entitled, so you can make small updates to your app even after your license has expired and all runtime systems will continue working. Unity MARS licensing will never stop your built app from working.
Once a user is entitled, their local entitlement will persist for two weeks (14 days), even if offline.

In the Editor, scenes that don't use MARS should not be affected. Scenes that use MARS will have the following features disabled when the user is not entitled:

 - MARS windows, such as the Simulation View, Device View, and the MARS panel will not be functional.
 - Simulation environments will not load in Simulation or Play mode.
 - The core Proxy database matching system will not be functional.
