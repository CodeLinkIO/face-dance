# Face tracking

Face tracking is an important part of AR with many practical use cases, including face effects, filters, and "try-ons" which allow the user to simulate makeup, eyeglasses, or different hairstyles.

Unity MARS applications have face-tracking ability when you deploy your app to an Android or iOS device. In the Unity Editor, Unity MARS applications can use face tracking in **Recorded** mode or **Live** mode simulations. The Unity MARS package content includes default [Session Recordings](SessionRecordings.md) that are videos with pre-recorded face tracking data. You can play these videos in **Recorded** mode to test against recorded face data. Unity MARS also supports face tracking against a pure video in simulation. The video feed can come from either a camera in **Live** mode or custom video in **Recorded** mode. To use this kind of face tracking you need to download and install [ULSee](https://assetstore.unity.com/packages/tools/integration/single-face-tracker-plugin-lite-version-30-face-tracking-points-90212), which is a third-party plug-in. You can still create facemasks in the Editor without ULSee.

**Note:** You only need ULSee if you want to use live video from your computer's camera to test face content in the Editor. When you deploy your project to a device, AR Foundation will be used by default (given the device supports AR Foundation).

AR Foundation face tracking might support some features that Unity MARS doesn't include. You can use both Unity MARS and AR Foundation APIs in the same scene to achieve your project needs.

## Using a facemask template

From Unity's main menu, go to **Window &gt; MARS &gt; Choose Template**, and select the **Facemask** option. This opens a template Scene with all the elements you need to incorporate face tracking in your app, which you then need to save separately (menu: **File &gt; Save As**).

![Creating a Facemask template](images/FaceTracking/facemask-template-menu.png)

To test out face tracking capabilities while designing your AR app, make sure that the Simulation view is open, and set its mode to either **Live** (to get a stream from the first webcam Unity MARS detects), or **Recorded** (if you have a pre-recorded video to work with). Face tracking works with both these options.

![Device view in Unity MARS](images/FaceTracking/facetracking-device-view.png)

### Loading custom recorded videos

To load your own video clip for testing inside Unity MARS, you must create a [Session Recording](SessionRecordings.md#video-recordings) asset that references the video clip. In the **Project window**, right-click the video clip then select **Create &gt; MARS &gt; Session Recording from Video Clip**.

After you've done this, you must refresh Recorded mode environments. From Unity's main menu, go to **Window &gt; MARS &gt; Developer &gt; Refresh Session Recordings**.

You should now see your video in the **Environment** drop-down list of the Device view.

![Selecting a custom video from the Environment drop-down list](images/FaceTracking/recorded-video-on-device-view.png)

## Placing digital content on a face

The Facemask template places a head model in the middle of your Scene.

![Face model in the Scene](images/FaceTracking/face.png)

To create facemasks, decorate this model as if it were a mannequin. When you drag a Prefab from your Project onto the face, different key ‘landmarks’ (such as the eyebrow or nose) light up as the cursor hovers that area. Release the mouse button to anchor the GameObject to that particular feature. Unity MARS places the GameObject as a child GameObject of the face landmark in the **Transform** hierarchy.

To reposition a Prefab or move it to a different landmark, select the GameObject, hold down the Shift key, and then drag the GameObject to its new position.

To control how dragged GameObjects should snap and align to the face, use the **Placement Options** section of the main Unity toolbar. The options available are **Snap to Pivot** and **Orient to Surface**. If you enable **Orient to Surface**, you can also select which direction Unity considers to be "forward".

![Placement Options buttons](images/FaceTracking/placement-options.png)

**Note:** If you are not using Unity 2019.3 or 2019.4, these options don't exist in the main toolbar; instead, they are in the MARS Panel's **Placement Options** section.

![Placement Options Panel](images/FaceTracking/placement-options-panel.png)

## Testing face tracking on Unity MARS

Test your facemask in the Device view. You can set the **Mode** to Live or Recorded, as described above.

![Testing face tracking in the Device view](images/FaceTracking/testing-facetracking.png)

The first time you select Live mode, you will be prompted to allow permission to use the camera. Click **Allow** to allow access and turn on the camera. If you click **Deny**, you will see a console warning instructing you on how to allow access every time Unity MARS tries to use the camera.

On Mac OS X version 10.14 (Mojave) and above, the operating system already handles camera access permission, and you can allow or deny access under **System Preferences &gt; Security &amp; Privacy &gt; Camera**. The setting for Unity Hub controls whether or not all versions of the Unity Editor have access to the camera. If you installed the Editor outside of the Hub, you might see individual Editor versions appear in this view.

On Windows and earlier version of Mac OS X, Unity MARS will ask for permission using a custom prompt, and track the setting under **Preferences &gt; MARS**. Toggle the **Camera permission** setting in this view to allow or deny access after the initial prompt.

## Face tracking considerations
To preview your face tracking app in Play mode, you must enable the **Simulate in Play Mode** option in Project Settings. From Unity's main menu, go to **Edit &gt; Project Settings &gt; MARS &gt; Simulation &gt; Scene Module &gt; Simulate in Play Mode**.

![Disabling the Simulate in Play Mode option](images/FaceTracking/disable-play-mode.png)
