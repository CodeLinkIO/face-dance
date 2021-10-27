# Graphics

This page provides more information on Unity MARS rendering support and features in the Editor.

## Composite Render

The Composite Render is the special render setup for Unity MARS that allows the Simulation view to render the Simulated Environment separately from and occluded by the Simulated Content in the editor views. This is achieved by the Simulation Scene being broken into two preview scenes with a camera rendering each scene. This supports the built-in render modes fully with partial support through fallback options for Scriptable Render Pipelines (SRP).

### Composite Render Options

Options for the Composite Renderer can be found in the **Project Settings Window** accessed under **MARS &gt; Editor Visuals &gt; Composite Render**. This contains options to enable fallback rendering mode **Use Fallback Composite Rendering**. When enabled the composite rendering is simplified to use a single simulation scene and camera. This provides wider support to different rendering APIs and Scriptable Render Pipelines (SRP). The **Use Camera Stack In Fallback** keeps the single simulation scene setup but uses the composite camera as a child of the target camera with a lower sort depth to be rendered before the target camera on the camera stack. This mode is not supported in the Scene or Simulation View and will still use the base fallback setup.

### Supported Rendering Modes

| Feature | Supported |
| ----------- | ----------- |
| Forward | Yes|
| Legacy Deferred | Yes |
| Deferred | Yes - MARS depth shaders not supported|
| Post Processing | Yes |
| VR | In research |
| VR Single Pass | In research |
| URP | Yes - Fallback Composite (no camera stack) |
| HDRP | In research |
| Custom Render Pipe | In research |
| AR Camera Background | Runtime only|
| AR Background Render Feature | Runtime only|


### Post Processing

![Post Processing](images/Graphics/PostProcessing.png)

Unity MARS supports Post Processing version 2.2.2 and greater. Unity MARS uses this to enhance the rendering of the Simulation views with color correction, ambient occlusion, and chromatic aberration applied only to the simulated environment. These effects provide some extra separation of the Scene content on the simulated environment, to better represent what you see on the target device. The post processing profiles included with the MARS content are for legacy rendering only and do not support URP.

### AR Background Setup in Unity MARS

[**AR Foundation**](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@latest/index.html) provides a simple way to add your device's camera feed to the background of your Unity MARS app using [**ARCameraBackground**](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@latest/index.html?subfolder=/api/UnityEngine.XR.ARFoundation.ARCameraBackground.html) and the [**ARBackgroundRenderFeature**](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@latest/index.html?subfolder=/api/UnityEngine.XR.ARFoundation.ARBackgroundRendererFeature.html) in URP. If you are using the [**Unity MARS AR Foundation Providers**](https://docs.unity3d.com/Packages/com.unity.mars-ar-foundation-providers@latest/index.html) package, the AR Camera Background will automatically be added to your scene at runtime by the **AR Foundation Camera Provider**. If you are not using the Unity MARS AR Foundation Providers or you need to use custom settings on the ARCameraBackground, refer to the [section on AR Camera Background](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@latest/index.html?subfolder=/manual/index.html%23ar-camera-background) in the [AR Foundation scene setup guide](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@latest/index.html?subfolder=/manual/index.html%23scene-setup).

#### Configuring ARCameraBackground with the Universal Render Pipeline
If you are using **URP (Universal Render Pipeline)**, you will need to upgrade the **AR Foundation** package and associated packages to version 3.0.1 or greater using Package Manager. To add the **AR Background Render Feature** to your render pipeline refer to [this additional documentation to configure an AR Foundation project with a URP.](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@latest/index.html?subfolder=/manual/ar-camera-background-with-scriptable-render-pipeline.html)

### Universal Render Pipeline

Unity MARS supports Universal Render Pipeline (UniversalRP) 7.x or greater. Shaders within MARS are built to support URP without the need to upgrade the material. However, if you started your project before switching to URP, you might still need to upgrade materials, especially those on primitive objects. To do this, from Unity's main menu, go to **Edit &gt; Render Pipeline &gt; Universal Render Pipeline &gt; Upgrade Project Materials to UniversalRP Materials**.

Some features of the composite render are not supported in **Universal RP** at this time. These are: simulated occlusion, simulated environment GI lighting, and simulated environment post FX. To use the **AR Background Render Feature** from AR Foundation with the **UniversalRP** refer to [**AR Background Setup in Unity MARS**.](Graphics.md#ar-background-setup-in-unity-mars)

For more information about compatibility between the associated packages and **AR Foundation** refer to [AR Foundation Providers package documentation](https://docs.unity3d.com/Packages/com.unity.mars-ar-foundation-providers@1.0/manual/index.html).
