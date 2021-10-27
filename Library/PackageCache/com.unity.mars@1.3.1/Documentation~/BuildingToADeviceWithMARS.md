# Building to devices with Unity MARS
This guide will show you how to install Unity MARS to a new Unity Project, use MARS to create a simple AR application that places a sphere on a surface, and build your application to an iOS or Android mobile device.
Before getting started, make sure you have read the [requirements](index.md#requirements) to ensure your project meets the minimum requirements. Bear in mind that this guide is subject to change as different Unity versions come out, so make sure that you are viewing the documentation for the version of Unity MARS you have installed.

## Installing MARS to a new project
To install Unity MARS you will first need to register at [unity.com/products/unity-mars](http://unity.com/products/unity-mars) to gain access to the MARS Installer Asset Package, called **MARS_Installer.unitypackage**. The installer can be found in a download link in the welcome email you received after you signup. The installer can also be found at [id.unity.com](http://id.unity.com) at My Account &gt; My Seats or Organizations &gt; "Your Organization". Initially, this installer is the only way to install MARS into a new or existing Unity project.

To get you started; Create a new project and import the MARS Installer [`.unitypackage`](https://docs.unity3d.com/Manual/AssetPackagesImport.html) through the **Assets** menu.

To import the local `MARS_Install.unitypackage` in Unity:

1. Open the project in the Editor where you want to import the Asset package.
2. Choose *Assets &gt; Import Package &gt; Custom Package*. A file browser appears, prompting you to "Import package ...".
3. In the file browser, navigate to the  `MARS_Install.unitypackage` file and click Open.
4. The Import Unity Package window displays all the items in the package already selected, ready to install.
5. **Do Not** deselect any items before clicking **Import**. Unity will add the required assets and import the required packages from [Unity's Package Manager](https://docs.unity3d.com/Manual/Packages.html), so that you can access them from your [Project window](https://docs.unity3d.com/Manual/ProjectView.html)
6. After pressing **Import** it can take several minutes to add and process all the MARS assets and scripts.

**Note:** You will need access to a stable internet connection to download the required MARS assets from Unity's Package Manager.

![Package load](images/BuildingMARSToDevices/importing-mars-package.gif)

Since we are aiming to build to Android / iOS we will need an additional package: `com.unity.mars-ar-foundation-providers`.

To install packages in Unity, you do so through the [package manager](https://docs.unity3d.com/Manual/upm-ui.html) by going to `Window &gt; Package Manager` and [searching for the necessary packages](https://docs.unity3d.com/Manual/upm-ui-find.html)

The `com.unity.mars-ar-foundation-providers` package will work with most versions of AR Foundation, starting with `com.unity.xr.arfoundation@2.1.8`, but does not directly depend on it. Also, depending on the platform you chose to build for, you might need [ARCore (for Android builds)](https://docs.unity3d.com/Packages/com.unity.xr.arcore@latest/index.html) and / or [ARKit (for iOS builds)](https://docs.unity3d.com/Packages/com.unity.xr.arkit@latest/index.html).

Finally, the version of the AR Foundation package you're using has to match with the version of ARKit and/or ARCore you are targeting, unless noted otherwise. Version mismatches will likely result in compiler errors.

For recommendations around package versions and project configuration, you can always check the [MARS AR Foundation Providers package documentation](https://docs.unity3d.com/Packages/com.unity.mars-ar-foundation-providers@latest).

So! Three things to check:
 1. Check that *MARS AR Foundation Providers* is installed in the package manager (if it's not installed, install it).
 2. Select and install ARCore (for Android builds) and/or ARKit (for iOS builds), depending on the platform(s) you plan to target your build for.
 3. **Make sure that [ARCore](https://docs.unity3d.com/Packages/com.unity.xr.arcore@latest/index.html) / [ARKit](https://docs.unity3d.com/Packages/com.unity.xr.arkit@latest/index.html) versions match with [ARFoundation](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@latest/index.html).**

![Set build target](images/BuildingMARSToDevices/installing-extra-packages.gif)


## Preparing Unity for making builds for Android - iOS
Now that we have MARS installed and all the necessary packages set we are ready to organize Unity for making our builds in the [Build Settings Window](https://docs.unity3d.com/Manual/BuildSettings.html).

By default Unity is set to build to standalone platforms, so next we need to set the device platform we plan to build MARS to; for example, iOS or Android.
To do so, go to `File &gt; Build Settings`, select the platform you plan to build for (iOS / Android), press the `Switch Platform` button, and wait while Unity re-imports the project for the new build target.

![Set build target](images/BuildingMARSToDevices/set-build-target.gif)

### iOS-specific project setup for building with Unity MARS
If you are building for iOS, you will have to do some extra steps by opening the _Project settings_ by either going to `Edit &gt; Project Settings &gt; Player` or `File &gt; Build Settings &gt; Project Settings`. Select the `Other settings` tab and:
1. Set the name of your company and app. This is to avoid name conflicts when creating a bundle identifier in XCode.
2. Set a message when asking for permissions to use the camera.
3. Set the minimum version required for the version of ARFoundation you are planning to use. This is highly dependent on the version of Unity you are using, and the platform(s) you are targeting and the functionality you want to support; for more information check the [ARFoundation docs](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@latest/index.html) on what is available and required depending on your needs.
4. Set architecture to ARM64.
5. In the `XR Plug-in management` section in the `Project Settings` window, set the checkbox under `ARKit` to enable the plugin provider.

![Set build target](images/BuildingMARSToDevices/setting-unity-for-ios-build.gif)

Building Unity projects for iOS devices involves two steps:
1. Unity builds an [XCode project](https://docs.unity3d.com/Manual/StructureOfXcodeProject.html)
2. XCode builds said project to your device.

This guide will take you up until generating an XCode project; you can find more info about iOS build settings **[here](https://docs.unity3d.com/Manual/BuildSettingsiOS.html)**

### Android-specific project setup for building with Unity MARS
To [build and run Android apps](https://docs.unity3d.com/Manual/android-BuildProcess.html) you must install the Unity Android Build Support platform module, the Android Software Development Kit (SDK) and the Native Development Kit (NDK).

It is recommended to use the [Unity Hub](https://docs.unity3d.com/Manual/GettingStartedUnityHub.html) to install Android Build Support and the required dependencies (Android SDK & NDK tools, and OpenJDK). For more detailed information on how to install the SDK and NDK you can follow this link **[here](https://docs.unity3d.com/Manual/android-sdksetup.html)**.

To setup your Unity MARS app to build on Android, follow these steps:

1. In the Unity build settings, set your platform to `Android` by going to `File &gt; Build Settings...`, select `Android`, and click the `Switch Platform` button.
2. Enable _ARCore_ in the `XR-Plugin management` section in the _Project Settings_ window by either going to `Edit &gt; Project Settings &gt; XR-Plugin management` or `File &gt; Build Settings &gt; Project Settings &gt; XR-Plugin Management` to activate the plugin provider.
3. Disable 'Auto Graphics API' to make sure the **Vulkan** Graphics API is not enabled. Go to `Edit &gt; Project Settings` in the `Player` section on the left, in the `Other Settings` foldout under the `Rendering` header. Disable **Auto Graphics API**.
4. If 'Vulkan' appears in the list of **Graphics APIs** under 'Auto Graphics API', select 'Vulkan' from the list and then click the '-' button in the lower right corner of the list.

**Note**

Android's **ARCore** does not currently support the **Vulkan** rendering APIs and will not work if 'Vulkan' is your application's graphics API.

![Set build target](images/BuildingMARSToDevices/setting-unity-for-android-build.gif)

If you end up getting errors and can't enable the `ARCore` plugin provider, then most likely you have different ARFoundation and ARCore versions. **Make sure that your ARCore package version matches the installed ARFoundation package version in Package Manager.**

# Creating a scene for testing on a device build
By now you should be ready to start working on your MARS application. Let's create something simple we can use to visualize on our build:

1. Create a new [Unity Scene](https://docs.unity3d.com/Manual/CreatingScenes.html) by clicking on `File &gt; New Scene`
2. Save the scene (`File &gt; Save as...`) and call it "Sample Scene".
3. Create a Horizontal Plane [proxy](MARSConcepts.md#proxy) by _right clicking_ on the `Hierarchy view &gt; MARS &gt; Presets &gt; Horizontal Plane`
4. _Right click_ again on the created Horizontal Plane GameObject in the Hierarchy, and select `3D Object &gt; Sphere` and adjust its scale (a good scale would be around 10 cubic centimeters (0.1, 0.1, 0.1)). Make sure the sphere is a child of the `Horizontal Plane` GameObject.
5. Create a **Plane Visualizer** by also _right clicking_ in the Hierarchy view and selecting `MARS &gt; Data Visualizers &gt; Plane Visualizer`.

You should now have a _Horizontal Plane_ GameObject with a child GameObject _Sphere_, a _Planes Visualizer_ GameObject, and a `MARS Session` GameObject, which should have automatically been created for you. With this scene, you will be able to see scanned surfaces, and when an horizontal plane is detected, a sphere will appear.

![Create simple app](images/BuildingMARSToDevices/creating-simple-mars-app.gif)

And that's it!  We are ready to build the project now.

# Building your project to your selected platform
Finally, depending on the platform you are targeting, you will be generating an [XCode project (for iOS builds)](https://docs.unity3d.com/Manual/iphone-GettingStarted.html) or an [`apk` file (for Android builds)](https://docs.unity3d.com/Manual/android-BuildProcess.html).  Depending on the build target, you will have to compile the final build through XCode, or move the generated .apk file to your Android phone.

On Unity's side we just need to:
1. Open the [Build Settings window](https://docs.unity3d.com/Manual/BuildSettings.html) by going to `File &gt; Build Settings...`
2. Add the created scene by clicking on the `Add Open Scenes` in the scenes build, or dragging the scene into the list from the Project view.
3. Click build.
4. Follow any extra steps necessary for building to your device of choice; either build with [XCode (for iOS builds)](https://docs.unity3d.com/Manual/iphone-GettingStarted.html) or move the generated [`apk` file (for Android builds)](https://docs.unity3d.com/Manual/android-BuildProcess.html) to your device.

![Build](images/BuildingMARSToDevices/build-to-device.gif)

Upon starting the app, after the Unity splash screen, you should see a video stream of your camera.

Start moving your device to scan surfaces.  While doing this, you should scanned surfaces displayed with a hexagonal pattern; this is the default effect of the Plane Visualizer we added. When a horizontal plane is detected, the sphere you created as a child of the Horizontal Plane Proxy will appear as shown in the image.

![Build](images/BuildingMARSToDevices/final-build.png)

# Troubleshooting
If you are getting a black screen after building your project, check that you have installed these packages:
* `com.unity.mars-ar-foundation-providers`
* `com.unity.xr.arfoundation`

And one or both of the following:
* `com.unity.xr.arkit`
* `com.unity.xr.arcore`

If you are still seeing a black screen, please refer to the [FAQ](FAQ.md) for some common causes. If you followed this step by step guide you should not have any problems.

If you are seeing several compile errors, make sure your `ARFoundation`, `ARCore` and / or `ARKit` packages **have the same major and minor versions** and that you are using a version of Unity that supports that version of AR Foundation. Note that some issues can be caused by using ARFoundation in older Unity 2019.4 versions.

If you have errors when generating a build, check that the version you have specified for `ARCore` / `ARKit` is supported by the SDK version.  Otherwise, you will not be able to build to your devices.
