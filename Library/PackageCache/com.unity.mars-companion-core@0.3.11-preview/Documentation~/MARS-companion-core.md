# Unity MARS Companion Core

The Unity MARS Companion Core package is used to sync resources for the Unity MARS companion apps. This documentation gives a brief overview on how to use the package, and covers its technical requirements and known limitations.

## Preview package

This package is available as a preview, so it is not ready for production use. The features and documentation in this package might change before it is verified for release.

# Installing Unity MARS Companion Core

The Unity MARS Companion Core package will be installed along with new Unity MARS installations. To install the Unity MARS Companion Core package like you would any other unlisted package:
- Open the Package Manager Window.
- Click the **+** drop-down.
- Choose **Add package from git URL...**
- Type `com.unity.mars-companion-core` and press Enter.

To learn more about packages, go to the [Package Manager documentation](https://docs.unity3d.com/Packages/com.unity.package-manager-ui@latest/index.html).

<a name="UsingUnityMARSCompanionCore"></a>
# Using Unity MARS Companion Core

Most of the controls for the Unity MARS Companion Core package are located in the **Companion Resource Manager** window. To open this window, from Unity's main menu, go to **Window &gt; MARS &gt; Companion Resource Manager**.

In order to sync resources to and from the Companion App, you must connect your project to a [Cloud Services project](https://docs.unity3d.com/Manual/SettingUpProjectServices.html). To link your project, enable any service (for example, Cloud Build) from the services window (menu: **Window &gt; General &gt; Services**), or link to an existing project.

If your project is not linked to Unity's Cloud Services, you will see the following:

![The Companion Resource Window (Unlinked)](images/companion-resource-window-unlinked.png)

Once your project is linked, and you have published some resources, you will see the following:

![The Companion Resource Window](images/companion-resource-window.png)

- Click the **Refresh** button (top-right circle arrows button) to update the resource list. You need to do this every time you upload a resource from the app. Unity MARS does not update resources automatically.
- To import a resource into your project, click its corresponding button in the **Sync Action** column. This opens a file dialog where you can specify a path within the `Assets` folder where you want to save the new resources. Some resource types import multiple files for a single resource. Unity displays a dialog for each file.
- Hover the mouse cursor over a resource's metadata in the **Asset**, **Size**, or **Last Updated** column to see a tooltip with its unique identifier.
- The **Asset** column contains an object field to indicate which Unity project asset is associated with the cloud resource. This displays `None` for resources which have not been imported into the project or did not originate in this project. The `Assets/MARS/Settings/CompanionResourceSync` asset keeps track of which cloud resource is associated with which Unity project asset, and **this asset should be tracked in version control** so that all users of the project have the same asset files associated with their corresponding cloud resources.
- Click the **X** button next to any resource to remove it from the list. This deletes the resource on cloud storage and removes the resource from the list for all users of this resource folder. If there is a local asset associated with this resource, this asset is **not** deleted, but its association with a unique identifier is removed from the `CompanionResourceSync` asset.
- The **Sync Asset Bundles** button exports and syncs asset bundles to the **Platforms** you selected via the **cloud buttons**. This process can take a long time depending on your project size, because it requires Unity to switch to each of the target build platforms if necessary. For example, if your project is currently set to the iOS platform, and you want to export Android bundles, Unity must switch to the Android build target to do so, which is equivalent to clicking the **Switch Platform** button in the **Build Settings** window of the Unity Editor.
- Click the **cloud buttons** under the **platform icons** to cycle through the various actions which can happen when you press the **Sync Asset Bundles** button. Depending on the current state of the resource's Asset Bundles, asset bundles can be added, removed, or updated. If an Asset Bundle needs to be updated but you do not have the module installed for that platform, you will see a warning icon until that asset bundle is either deleted or published by a user with the module installed. The cloud button can indicate one of the following states:
  - ![Not Uploaded](images/cloud-icon-not-uploaded.png) `Not Uploaded`: The resource will not have an asset bundle after it is synced. Either it never had one, or the user has indicated that it should be deleted.
  - ![Uploaded](images/cloud-icon-uploaded.png) `Uploaded`: The resource will have an asset bundle after it is synced. Either it already has one, or the user has indicated that it should be published.
  - ![Update](images/cloud-icon-update.png) `Update`: The resource has changed since this platform bundle was originally published, and this bundle will be uploaded as part of the sync. If the resource is in this state you can click the **cloud button** once to switch to the `Uploaded` state, which will keep the old version. Clicking the **cloud button** a second time will switch to the `Not Uploaded` state, which will indicate that it should be deleted. Clicking the **cloud button** a third time will return it to the `Update` state.
  - ![Warn](images/cloud-icon-warn.png) `Warn`: The resource has changed since this platform's bundle was originally published, but the platform required to publish it is not installed. If the resource is in this state you can click the **cloud button** to indicate that it should be deleted, or click it again to cycle back to the `Warn` state and keep the old version.

<a name="PublishingScenesAndPrefabs"></a>
# Publishing Scenes and Prefabs

The Unity MARS Companion Core package also adds a menu item to the context (right-click) menu for assets. Right-click the asset in the **Project** view, then select **MARS Companion &gt; Publish** from the context menu.

![The Companion Resource Publish Menu](images/publish-resource.png)

You can publish the following asset types:
- Scenes
- Prefabs

The first time you publish a scene that has asset references, Unity displays a save dialog that lets you select where to save an additional ScriptableObject which contains references to these assets and their guids. If this file already exists, Unity will reuses the existing ScriptableObject. Unity also logs instructions to the console which remind you to publish an AssetBundle for these assets. To do this, use the **cloud buttons** and **Sync Asset Bundles** button in the **Companion Resource Manager**.

The Unity MARS Companion app currently supports iOS and Android. If you need to edit a scene or use a Prefab on these platforms, you must ensure that the **cloud button** for each platform you want is in the `Uploaded` (![Uploaded](images/cloud-icon-uploaded.png)) state in the **Companion Resource Manager**. If you need additional AssetBundles, update the **cloud buttons** you need and press **Sync Asset Bundles**. This applies to published Prefabs, as well as Scene AssetPacks. If you see any **cloud buttons** in the `Update` or `Warn` state, you might encounter issues when trying to use those scenes or Prefabs in the Companion App.

**Note**: The **MARS Companion &gt; Publish** context menu option will only publish the JSON content of a scene, or the metadata for a Prefab. When publishing an asset for the first time, you must also publish AssetBundles for the platforms you wish to use it on.

**Note:** Currently, Unity does **not** check if a resource has changed since the last time you published it. Regardless of whether or not it is strictly necessary, Unity will always suggest that you publish an Asset Bundle whenever its upload timestamp is earlier than its resource's upload timestamp.

**Note:** AssetBundles are not forwards-compatible. The current version of the Unity MARS Companion App available on App Stores was built with Unity 2019.4.14f1. Asset Bundles built with newer versions of Unity might not load correctly.

# Viewing data recordings
To view data recordings which have been imported, follow these steps:

1. Change the Unity MARS Simulation View **mode** to Recorded.
2. Select the recording using the **environment** dropdown.

The **Device View** will have its scene camera follow the recorded camera path, and the recording data providers will simulate AR data for planes and point cloud, if provided. To learn more about Unity MARS session recordings, see [this page](https://docs.unity3d.com/Packages/com.unity.mars@1.0/manual/SessionRecordings.html) in the Unity MARS documentation.

# Technical details
## Requirements

This version of Unity MARS Companion Core is compatible with the following versions of the Unity Editor:

* 2019.3.0f6 or later

## Known limitations

Unity MARS Companion Core version 0.3 includes the following known limitations:

* The version of Burst required by this package will spam errors in Unity 2019.3 on MacOS X Big Sur. Affected users should upgrade to Unity 2019.4 or avoid updating to Big Sur.
* When linking a mobile project to a Cloud project, the Cloud project name will take precedence
* Video recordings might appear rotated when played back in Play mode
* Prefabs built with Unity versions newer than 2019.4.14f1 cannot be used in the current version of the app

## Document revision history

|Date|Reason|
|---|---|
|Jan 08, 2021|Update for 0.3 release|
|Dec 13, 2020|Update known limitations|
|Aug 06, 2020|Update docs with new companion app UI|
|Apr 08, 2020|Update for 0.1 release|
|Oct 20, 2019|Document created|
