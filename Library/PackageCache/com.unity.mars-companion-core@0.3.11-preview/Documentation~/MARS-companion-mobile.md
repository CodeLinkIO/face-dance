# About Unity MARS Companion Mobile

The Unity MARS Companion Apps allow users to capture real-world data directly on their device and bring it into the Unity MARS authoring environment to quickly create and iterate on AR experiences.

# Using Unity MARS Companion Mobile

You can obtain the Unity MARS Companion App for Smartphones by invite from TestFlight or Google Play.

(Coming Soon) Official builds of the Unity MARS Companion App will be available on the iOS App Store and Google Play

There are four main workflows in the Unity MARS Mobile Companion app, which you can use to:
- [Edit Proxies](#proxy-scan-workflow)
- [Capture Environments](#environment-capture-workflow)
- [Capture Image Markers](#marker-capture-workflow)
- [Record Data](#record-data-workflow)

## Linking your Unity account to the Companion App

The first time you run the app, you will be prompted to sign in. In order to access cloud storage and sync assets with the Editor, you must sign in with a Unity account that is entitled to a Unity MARS subscription. To sign in, follow these steps:

1. Tap **Login**
1. You will be redirected to a browser where you can follow the normal Unity sign in process using your e-mail and password or your preferred authentication provider
1. If login is successful, you will be returned to the app and proceed to **Project List**

If you cannot connect to the internet, or if you just want to try the Unity MARS Companion App without signing in, you can tap **Skip** to use the app in offline mode. You will not be able to link your project or access cloud storage for any existing linked projects, but you will be able to create and manage resources in local storage.

Your sign-in will be valid for 30 days, and during this time the app will automatically bypass the **Sign In** view. After 30 days, simply tap **Login** and repeat the browser sign in process.

## Linking your project to the Companion App

From the **Project List** view, you can either create a new project, or, if you are signed in, import a project from the Editor.

To create a new project and start capturing data, tap **New Project**.

If you have a project open in the Editor, or a **Project ID**, tap **Import Project**, which opens the QR code reader.

In the Unity Editor, click the **QR Code** button in the **Companion Resource Manager** to display the **Project ID QR Code**, then scan this code. When the scan is successful, the **Project ID** will display in the Unity Companion App, and the project title will replace the instructions.

Tap **Link Project** to complete the linking process. This will bring you to the **Resource List** view.

## Project list view

To return to the **Project List** view, tap **Projects** in the upper-left corner of the **Resource List** view. From there, you can:
- Link another project
- Create a new project
- Choose an existing project

![Unity MARS Mobile Companion Project List View](images/project-list.png)

### Project list multi-select

To enter multi-select mode, tap **Select** in the **Project List** view:

Toggle the selection state on projects in the list by tapping anywhere along the row. Tap **Done** to exit multi-select mode.

Tap **Delete** to delete multiple projects. Deleting a linked project in the Companion App does not delete the Cloud Services project.

### Project list context menu

You can also bring up a context menu for an individual project by pressing the three gray dots next to it.

Tap **Remove** to remove this project from the list. Tap anywhere in the shaded area above the context menu to dismiss it.

## Profile view

Tap the circular blue button with your initials on it to go to the **Profile view**. If you skipped login, this circle displays the letter **U** instead.

![Unity MARS Mobile Companion Profile View](images/profile.png)

The Profile view displays information about the user who is currently logged in to the app, as well as the total data usage across all of their Unity MARS Companion projects. To log out and go back to the **Sign In** view, tap **Log Out**. If you skipped login, the button will read **Log In**. Tap the **Privacy Policy** button to view the Unity MARS privacy policy in your device's browser. The version number of the app is displayed at the very bottom of the screen. Tap back to return to the **Resource List** view.

### Data usage

Each Unity MARS subscription contributes 10GB of Unity MARS cloud storage to the Unity Cloud organization it is associated with. This storage cap does not apply to any other Unity services. Projects associated to a given organization share storage, and thus as more and more files are stored, the total free storage available to all projects will decrease. This is why some projects can use 10GB of storage or more, and others might display a storage limit that is smaller than 10GB.

For example, in the screenshot above, the first project is the only one in its organization, which has two associated MARS subscriptions. The second project belongs to a second organization with one associated Unity MARS subscription. The remaining four projects all belong to a third organization with one Unity MARS subscription. They have collectively used 0.4GB of storage, which means that this organization has 9.6GB available. The two projects which have used less than 5MB (rounded down to 0.00) of storage both show 9.6GB as the total amount of usable storage, while the apps which have used some storage show the total amount as 9.6GB plus the amount they have already used.

## Resource list view

The **Resource List** view shows a list of all resources in a given **Resource Folder** for the project which was selected in the **Project List** view. You can expand or collapse the groups or resources by tapping the header, for example `Scenes (3)`.

![Unity MARS Mobile Companion Proxy Scan Flow](images/resource-list.png)

### Opening scenes

Tapping on a scene resource opens the **Proxy Scan** flow with that scene loaded. If the scene was published from the Editor and requires an Asset Bundle, the app displays an on-screen message indicating that the bundle is being downloaded. When the download finishes, the app proceeds to the **Proxy Scan** flow. If the Asset Bundle has not been published for the current platform or failed to download, you will see a message appear briefly in the **Proxy Scan** flow that says `Scene AssetBundle is missing for this platform`.

If a scene has been modified in the cloud since the last time you saved or opened it on your device, the scene will be in the `Conflicted` state. When you try to open it, a context menu displays. You can either choose to download the cloud version or upload your local version to the cloud to resolve the conflict. After the conflict is resolved, tap the scene to open it.

If you wish to edit a conflicted scene offline, you must unlink the project. You can re-link the project at any time.

### Resource status icons

Some resources have an icon to display their synchronization status. A Unity MARS Companion App resource can be in one of the following states:
- ![Local Only](images/sync-icon-local-only.png) `Local Only`: The resource only exists locally on the device and can be uploaded to the cloud.
- ![Synced](images/sync-icon-synced.png) `Synced`: The resource exists in the cloud and on the device, and both versions have the same timestamp.
- ![Cloud Only](images/sync-icon-cloud-only.png) `Cloud Only`: The resource only exists on the cloud and can be downloaded to the device.
- ![Conflicted](images/sync-icon-conflicted.png) `Conflicted`: The resource exists in the cloud and on the device, but each version has a different timestamp.

Resources can also appear grayed out and with no status icon. Because these resources exist in the cloud but cannot be downloaded to the device, they are not considered `Cloud Only`. The only action you can take on these resources is to delete them from their context menu.

Because you can only download and edit `Scene` resources after they are uploaded, these are the only resources that can show the `Cloud Only` or `Conflicted` status.

### Resource list multi-select

As with the **Project List**, you can tap **Select** in the **Resource List** view to enter multi-select mode. Toggle the selection state on resources in the resource list and tap **Delete** to delete multiple resources. Tap **Done** to exit multi-select mode.

### Resource list context menu

You can bring up a context menu for an individual resource by pressing the three gray dots next to it.

Depending on the type of resource, and whether or not it can be uploaded or downloaded, you might see one or more of the following options:

- **Rename** opens the system keyboard and allows you to rename a scene.
- **Duplicate** duplicates a scene.
- **Delete** deletes the resource.
- **Upload** uploads a resource which only exists locally or is in conflict.
- **Download** downloads a resource which only exists on the cloud or is in conflict.

Tap anywhere in the shaded area above the context menu to dismiss it.

### Resource list view settings

Tap the three gray dots next to the project title to open the **Project Settings** menu.

Enter a resource folder into the text field to open the resource list for that folder. The list updates automatically when you dismiss the keyboard.

If the project is not linked to a Unity Cloud Services project, this menu contains a text field that allows you to rename the project.

## AR capture mode

### Home view

Tap **AR Capture Mode** in the **Resource List** view to enter the **Home** view, where you can switch between the app's four main modes:

- [Proxy Scan](#proxy-scan-workflow)
- [Environment](#environment-capture-workflow)
- [Marker](#marker-capture-workflow)
- [Record Data](#record-data-workflow)

![Unity MARS Mobile Companion Home view](images/home-proxy.png)

Swipe left or right on the cards to select the mode you want to use, then tap the **Start** button. To return to the **Resource List** view, tap the **&lt;** button.

## Proxy Scan workflow

Tap the **Start** button to enter the **Proxy Scan** workflow:

![Unity MARS Mobile Companion Proxy Scan Flow](images/proxy-1.png)

This creates a new scene with a light source and a MARSSession GameObject, and enables point cloud and surface detection. Press the **Pause** button to start editing Proxies:

![Unity MARS Mobile Companion Proxy Scan Flow](images/proxy-2.png)

Tap any surface to create a Proxy using the data for that surface. The **Toggle Visuals** button (top, second from the left) toggles the plane visuals to allow you to preview your content without plane visuals. Disabling plane visuals also disables the ability to create and select Proxies.

Tap the **Objects** button (bottom-right) to open the **Asset List** view. You can drag an asset up and out of the list and into the AR view. If you release the drag gesture while your finger is over a scanned surface, a Proxy will be created if one was not already matched, or the child object of the matched Proxy will be replaced with this asset. If there is no surface under your finger, the object will disappear and no scene changes will be made.

To scan or update more surfaces, press **Resume Scan**. To remove all surfaces and restart the scan, press the **Restart** button on the left. You can also tap surfaces with matched proxies (highlighted in blue) to edit that Proxy.

### Proxy Inspector

When you tap a surface, the app highlights it in orange and displays the **Proxy Inspector**:

![Unity MARS Mobile Companion Proxy Scan Flow](images/proxy-3.png)

Changes made here update the Proxy in real time and might cause it to match other surfaces.

Tap **Discard** to discard any changes made since you opened this view. Tap **Reset** to reset the Proxy to its original state (either when it was created, or when the scene was loaded).

#### Plane size condition

Tap **Size** to open the **Plane Size Condition** Inspector:

![Unity MARS Mobile Companion Proxy Scan Flow](images/proxy-4.png)

This activates the **Plane Size Handle** in the **Camera** view, which you can use to adjust the **Plane Size Condition** constraints spatially.

The **Disable** button disables the **Plane Size Condition**. When this Condition is disabled, tap the **Enable** button to enable it. Tap **Cancel** to revert any changes you made since you opened this view. Tap **Done** to confirm your changes.

#### Alignment condition

Tap **Alignment** in the **Proxy Inspector** view to open the **Alignment Condition Inspector**:

![Unity MARS Mobile Companion Proxy Scan Flow](images/proxy-5.png)

The **Disable** button disables the **Alignment Condition**. When this Condition is disabled, tap the **Enable** button to enable it. Tap **Cancel** to revert any changes you made since you opened this view. Tap **Done** to confirm your changes.

#### Semantic tag condition

Tap **Traits** in the **Proxy Inspector** view to open the **Semantic Tag Condition Inspector**:

![Unity MARS Mobile Companion Proxy Scan Flow](images/proxy-6.png)

So far, `floor` is the only semantic tag available in the companion app. In the future, you will be able to make custom builds with more advanced data providers that take advantage of other semantic tags.

The **Disable** button disables the **Semantic Tag Condition**. When this Condition is disabled, tap the **Enable** button to enable it. Tap **Cancel** to revert any changes you made since you opened this view. Tap **Done** to confirm your changes.

#### Proxy metadata

![Unity MARS Mobile Companion Proxy Scan Flow](images/proxy-7.png)

Tap the name of the Proxy at the top of the **Proxy Inspector** to open the **Proxy Attributes Inspector**, where you can rename the Proxy and choose a different color for it. The color applies to the Proxy icon in the Inspector, as well as the Proxy visuals in the Editor when the Proxy is imported. Proxies with similar names will be differentiated by their color.

### Asset list view

Tap **Objects** in the **Proxy Inspector** view to open the **Asset List**. This list contains simple primitives you can use for preview purposes. Tap **Prefabs** to see a list that contains any Prefabs which have been published from the Editor. If this is a new project, the list only contains the set of default Prefabs. Tap **Primitives** to return to the list of primitives.

![Unity MARS Mobile Companion Proxy Scan Flow](images/proxy-8.png)

From either the **Prefabs** or the **Primitives** list, drag an icon up and out of the list and onto the surface. This makes the object a child of the Proxy. You can also tap an icon to instantiate the object you tapped as a child of the Proxy you are editing. The Companion App currently supports only one child item with an identity transform. More object manipulation tools will be added before release.

Tapping or dragging a different object in the list destroys the previous child and instantiates a new one. Proxies imported from the Editor have their first child destroyed and replaced with the selected object if the Proxy had any transform children.

Tap **Dismiss** when you finished editing assets.

### Proxy List

After you dismiss the **Proxy Inspector**, the **Proxy Scan Flow** header buttons reappear. Tap the **Proxy List** button in the upper right to open the **Proxy List** view.

![Unity MARS Mobile Companion Proxy Scan Flow](images/proxy-list.png)

### Save and exit

When you are done editing, tap the **X** button in the top-left to exit the **Proxy Scan Flow**. The app will prompt you to save your changes.

Tap the **&lt;** in the top left corner to dismiss the save view and continue editing.

Tap **Discard** to discard changes and revert the scene to the state it was in before you entered the **Proxy Scan Flow**. The app will ask you to confirm the action. Tap **Discard** to confirm and discard the current scene changes, which will return you to the **Resource List** view, or tap **Cancel** to dismiss the confirmation prompt.

Tap **Save** to save the scene. This saves the scene to the cloud, adds it to the resource list, and caches a local version to the device's local storage. You can rename the scene using the text field above the two buttons.

Saving might take a while for complex scenes, or if your connection times out. If the project is not linked, saving is generally much quicker. Otherwise, even if the device is in airplane mode, the app will still attempt a connection, which might take a few seconds.

## Environment Capture workflow

Enter the **Environment Capture** workflow from the Home view.

![Unity MARS Mobile Companion Home view](images/home-environment.png)

The purpose of this flow is to capture the room as a synthetic environment for use in the Editor. Start by scanning all of the surfaces you wish to capture, including the floor. At any time during the flow, you can press the **Restart** button on the left to remove all surfaces, clear the floor plan, and restart scanning.

![Unity MARS Mobile Companion Environment Flow](images/environment-1.png)

When you are done scanning all surfaces you wish to capture, press **Start**. This button becomes active as soon as Unity MARS has recognized the floor.

![Unity MARS Mobile Companion Environment Flow](images/environment-2.png)

When you press **Start**, the surface visuals disappear and a **Cursor Post** appear. The **Cursor Post** is anchored to the floor so that the bottom of the post lines up with the center of the screen. Tapping **Place Corner** starts a **Floor Plan** which allows you to capture the walls of the room if you weren't able to scan them as surfaces. It is highly recommended that you scan thoroughly and include a floor plan to help you recognize the environment in the Editor.

To complete the flow and save the environment, with or without a floor plan, tap the **Finish** button on the right at any time.

![Unity MARS Mobile Companion Environment Flow](images/environment-3.png)

After placing the first corner, you will see a wall outline between the first corner and the cursor. Keep tapping **Place Corner** to add more walls. The **Place Corner** button will be disabled if the cursor is too close to an existing corner.

![Unity MARS Mobile Companion Environment Flow](images/environment-4.png)

While you are placing corners, you can swipe up and down anywhere on the screen to adjust the height of the walls.

![Unity MARS Mobile Companion Environment Flow](images/environment-5.png)

It is often easiest to adjust wall height after you have placed a few corners.

![Unity MARS Mobile Companion Environment Flow](images/environment-6.png)

If you have at least two walls and line up the cursor with the first corner, the walls will turn green and the **Place Corner** button will be replaced by the **Finish** button.

When you tap **Finish**, the app will prompt you to save the environment.

Tap **Discard** to discard the environment scan. The app will ask you to confirm the action. Tap **Discard** to confirm and discard the current environment scan, which will return to the **Home View**. Tap **Cancel** to dismiss the confirmation prompt.

Tap **Save** to save the environment. This saves the environment to the cloud, adds it to the resource list, and caches a local version to the device's local storage. You can rename the environment using the text field above the two buttons.

## Marker Capture workflow

Enter the **Marker Capture** workflow from the Home view.

![Unity MARS Mobile Companion Home view](images/home-marker.png)

The purpose of this flow is to capture an image for use as an **Image Tracking Marker** and identify **Hotspots** on the image.

![Unity MARS Mobile Companion Marker Flow](images/marker-1.png)

Tap **Take Photo** to capture the current camera image.

![Unity MARS Mobile Companion Marker Flow](images/marker-2.png)

Tap anywhere on the image to add a **Hotspot**.

![Unity MARS Mobile Companion Marker Flow](images/marker-3.png)

Tap **Done** to return to the previous menu, or **Delete** to delete the hotspot.

![Unity MARS Mobile Companion Marker Flow](images/marker-4.png)

Tap **Rename** to rename the hotspot.

![Unity MARS Mobile Companion Marker Flow](images/marker-5.png)

In the previous view, you can tap the name of the maker to rename it.

Tap **Cancel** to discard the marker and hotspots. The app will ask you to confirm the action. Tap **Discard** to confirm and discard the current marker and hotspots, which will return to the **Capture View**. Tap **Cancel** to dismiss the confirmation prompt.

Tap **Save** to save the marker to the cloud, add it to the resource list and save a local copy. This also brings you back to the **Capture View** so you can capture another image.

## Record Data workflow

Enter the **Record Data** workflow from the Home view:

![Unity MARS Mobile Companion Home view](images/home-record-data.png)

The purpose of this flow is to create a data recording for playback in the **Simulation** view. You can either begin recording immediately, or scan some surfaces first so that they exist at the beginning of the recording. Surface scanning begins immediately when you enter the **Record Data Flow**:

![Unity MARS Mobile Companion Record Data](images/record-data-1.png)

Tap **Start Record** to start recording video, camera pose, and surface events:

![Unity MARS Mobile Companion Record Data](images/record-data-2.png)

The timer at the top of the screen will indicate the current length of the recording. Tap **Stop Record** to stop recording and finalize the video:

![Unity MARS Mobile Companion Record Data](images/record-data-3.png)

This view allows you to make some choices before saving the recording. You can also use the text field to name the recording.

Note the file sizes next to the corresponding data tracks. The sum of these sizes will be the amount of data uploaded to the cloud and/or saved to your device.

Tap **Discard** to discard the recording. The app will ask you to confirm the action. Tap **Discard** to confirm and discard the current recording. Tap **Cancel** to dismiss the confirmation prompt.

Tap **Save** to save the recording. If you are in a linked project, saving uploads the recording to the cloud and also saves it locally to the device. If you are in an unlinked project, the recording is saved locally. After you link the project, you can upload it later from the **Resource List** view.

The **Video** track is disabled by default because videos tend to be much larger than the rest of the recording. If you wish to include video with the recording, tap the checkbox before you tap **Save**. To exclude one of the other data tracks, tap its corresponding checkbox.

You can cancel this upload, as well as any web request, if it takes longer than 3 seconds. To do that, tap the **X** button that appears in the upper-right corner of the screen. You will see a progress indicator indicating the percent completion of the video upload.

# Technical details

The Unity MARS Companion Apps were built with Unity 2019.4.14f1.

## Requirements

This version of Unity MARS Companion Mobile is compatible with the following versions of the Unity Editor:

* 2019.3.0f6 and later (recommended)

The Unity MARS Companion App for iOS requires ARKit and iOS 11.0 or later.

The Unity MARS Companion App for Android requires AR Core and Android 7.0 or later.

## Known limitations

Unity MARS Companion Mobile version 0.3 includes the following known limitations:

* Parts of the app are missing error feedback. Web requests might appear to have succeeded even if they fail or time out.
* There is no limitation on the length of data recordings. Extremely long recordings might crash the app before they can be saved.
* When linking a mobile project to a Cloud project, the Cloud project name will take precedence.
* Video recordings might appear rotated when played back in Play mode.
* Prefabs built with Unity versions later than 2019.4.14f1 (chronologically) cannot be used in the current version of the app.

## Document revision history

|Date|Reason|
|---|---|
|Jan 08, 2021|0.3 release|
|Apr 09, 2020|0.1.0 release|
|Oct 20, 2019|Document created.|
