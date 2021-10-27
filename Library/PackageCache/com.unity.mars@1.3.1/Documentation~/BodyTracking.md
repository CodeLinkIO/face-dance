# Body Tracking
Body tracking in Unity MARS enables you to track humans in augmented reality. Use it to try on virtual clothing, attach accessories or match body poses.

This section describes how to track bodies in your application.
It contains the following guides:

* How to place an avatar on top of a tracked body
* How to attach objects to landmarks defined in humanoid avatars
* How to create and match body poses in Unity MARS
* Simple example: Painting a tracked body proxy with a color when a pose is matched

After reading this guide, you should have the necessary knowledge to incorporate body tracking in your Unity MARS app.

__Note:__ Body tracking only works on iOS devices. This is because ARKit is the only platform that supports this feature right now.
It is important to know that the ARFoundation, ARKit, and ARkit face tracking packages need to be at least on version 4.0.2 for this feature to work.

## Body Tracking in Unity MARS
Body tracking in Unity MARS works seamlessly with Unity's avatar animation system.

To track a body, use a **Body Proxy**. This Proxy consists of two components: a **body trait** and an **action**. The action can be either a:

* **Match Body Pose Action**, which lets you make any humanoid avatar follow a tracked body
* **Body Expression Action**, which lets you match body poses
You can use both types of body actions with the same Body Proxy to animate a virtual avatar and also match poses.

### Creating a Body Proxy
To add a Body Proxy to your currently open Scene, click the __Body__ button on the MARS Panel.

![Body Proxy](images/BodyTracking/body-proxy-mars-panel.png)

### Preparing the Body Proxy
After you create your Body Proxy, Unity automatically creates a child GameObject on the Proxy called **Default Body Rig**.
Unity MARS uses the default body rig to create landmarks on bodies (more on that later).

For now, delete this GameObject and attach your own humanoid avatar as a child of the created BodyProxy. Then, drag and drop the animator from your humanoid to the Match Body Pose Action's **Animator** property.

![Match Body Pose Action](images/BodyTracking/body-action.png)

And that's it! Now, you should be able to build your app and see it working on your device.
You can also test it in the Simulation view. Open an environment that contains a synthetic body, then press the **Play** button in the Simulation view. Your humanoid avatar should follow the synthetic body (gray avatar).

![Match Body Pose Action](images/BodyTracking/body-on-sim-view.gif)

## Body landmarks
Landmarks are spatial data such as points, edges, or polygons, that let you anchor or align virtual content in your tracked world.
Body landmarks let you attach content such as accessories, hats, clothing, etc. to humanoid avatars.

To use landmarks, create a **Body** preset from the MARS Panel. Unity will add a child GameObject on the body called **Default Body Rig**.
This body rig lets you attach your 3D content to tracked bodies.

![Body Landmarks](images/BodyTracking/body-landmarks.png)

To add content to your Body Proxy, drag and drop your Assets to the Body Proxy in the Scene view. Unity MARS will automatically place your content where it needs to go.

![Body Landmarks](images/BodyTracking/attaching-body-landmarks.gif)  

To see the landmarks in action, open the Simulation view and select an environment that contains a synthetic body.  Press the **Play** button and you should see your landmarks attached to your synthetic body.

![Body Landmarks](images/BodyTracking/body-landmarks-sim-view.gif)

__Note:__ If, for any reason, you lose the default body rig, select the Body Proxy and click the **Transparent Default** button under the Body Action. Unity MARS will generate a new body rig that you can use.

If you have a humanoid avatar and want to attach your own landmarks to it, you must manually parent your authored content to your avatar rig hierarchy.
This enables you to use your own avatar without introducing overhead in your workflow. To add your own humanoid avatar you can either parent a humanoid body to the proxy or click on the **Custom Avatar** button, select your avatar and Unity will take care of the rest.

## Matching body poses
Body poses expand the potential of Unity MARS when tracking humanoid avatars.
With this feature, you can continuously check on what a tracked human is doing and trigger events when the tracked human matches custom poses you defined.

Unity MARS needs two things to match a body pose: a tracked human and a body pose.
To track humans and match them against poses, you must create a Body Proxy and attach a **Body Expression* action to your Proxy.

![Body Expression](images/BodyTracking/body-expression-action1.png)

This creates a **Body Expression** action you can use to track poses and trigger events when Unity MARS detects a match for a pose you specified.

![Body Expression Inspector](images/BodyTracking/body-expression-action2.png)

In the Body Expression action's **Inspector** window, you can configure the following values:

|**Property**|**Description**|
|---|---|
|**Create Pose**|When you click this button, Unity MARS opens a separate window where you can modify muscle values on your avatar to create poses.|
|**Angle Tolerance For Poses**|Refers to the angle between a body member and the desired pose. This value should typically be between 30 and 60 degrees.<br/><br/>A value of 0 means that members of your tracked avatar and your pose must be completely parallel to match. This might work in the Simulation view but, considering the inaccuracies that tracking poses introduces, there's a high chance it will fail tracking on device builds.|
|**Scale To Match Height**|If you enable this option, the internal body rig that your app tracks will be scaled to match the tracked human.|
|**Trigger Events**|This is an array of body poses and a list of triggering events. It enables you to invoke events once a pose is matched, and contains the following options:<br/><br/>- **Body Pose**: Data that has to match against the currently tracked human.<br/>- **Triggering Event**: List of methods to call when the body pose is matched.|

### The Body Pose tool
To match human poses, you must create data to compare against the tracked avatar.
 To do that, use the **Body Pose** tool.

 The Body Pose tool is a small utility that displays when you select a GameObject that contains an animator that is human, or any of the animator's children.
__Note:__ If the selected avatar body has a disabled skinned mesh renderer, the Body Pose tool will not display.
 The Body Pose tool enables you to extract poses anywhere in Unity - for example,
in Timeline, in the Avatar Editor tool, in the Scene view, or in current synthetic bodies.

The tool enables you to do the following:

* Load a pose to the current selected humanoid avatar
* Reset the pose to the default muscle values
* Make the avatar stay in T pose
* Save the current pose.

Note that the tool is only available in your currently selected view (Simulation view or Scene view).

![Body Pose Tool](images/BodyTracking/body-pose-tool.png)

#### Creating poses
To create a pose, click the **Create Pose** button in the Body Expression Action Inspector. This opens the Avatar Editor Scene, where you can modify muscle values to build a pose you want to match.
After you are happy with the pose you created, click the **Save** button and select where to save the pose.

![Create Body Pose](images/BodyTracking/body-pose-save.gif)

Another way to create a pose is to use the Body Pose tool to extract and modify data from anywhere in Unity, as mentioned earlier in this section.
Select a humanoid avatar you want to extract the pose from, then click the **Save** button in the Body Pose tool window.

#### Loading poses
If you want to create a pose that is similar to a saved pose you already have, you can load the pose onto a new avatar, modify it, and then save it as a new pose.
To load a pose, select the avatar you want to load the pose to. The Body Pose tool should appear in your current Scene view.
Drag and drop the pose into the **Body Pose** field and click **Load**. That's it!

![Body Pose Tool Load](images/BodyTracking/body-pose-tool-load.gif)

#### Body pose data
Unity saves body poses as **Body Pose Data** types, which contain all data required to compare poses against currently tracked avatars.
To see what a pose looks like, select any Body Pose Data Asset and visualize its avatar in the Inspector.

![Body Pose Data](images/BodyTracking/body-pose-data-inspector.png)

##### Modifying poses
After you save a pose, you can further modify it by changing certain muscles on it. Select the pose and move sliders left and right to visualize how the pose changes.
 Once you are happy with the changes, click the **Apply** button to save them.

![Body Pose Data Tweak](images/BodyTracking/body-pose-data-tweak.gif)

##### Selective body members
Sometimes, you might want to track poses that don't necessarily require tracking of all the body members. For example, when tracking a seated pose, you don't need to know how the hands are positioned nor how the head is angled.

In this case, you can select which body members you want to track in the Body Pose Data inspector.

![Body Pose Data Members](images/BodyTracking/body-pose-selective-members.png)

### Final thoughts
As you've seen, body tracking in Unity MARS lets you attach virtual items to tracked bodies and also superimpose full humanoid avatars on top of tracked bodies.

You can use the Body Pose tool across Unity to load, save, and modify poses when you need to match tracked avatars against custom created poses.

**Note:** If you want to visualize a tracked pose, you must use a Match Body Pose Action along with the Body Expression Action. This is because you might want to match your pose without rendering any avatar on top of your tracked humanoid.

## Synthetic bodies
Traditional mixed reality content authoring requires a lot of time to build and deploy to devices, test, and iterate. Unity MARS lets you simulate bodies and match your authored content in the Simulation view without the need to build and deploy your app. To do this, you can create a **Synthetic Body** from the MARS Panel, which will simulate a real human that you can test your content against.

![Body Pose Data Tweak](images/BodyTracking/synthetic-bodies.gif)

You can set several parameters of the synthetic body as follows:
* Select the body's animation from the **Playable** field
* Play, pause, or stop the animation
* Open the current animation in the Timeline
* Save the current pose for later matching with a Body Expression action

![Body Pose Data Tweak](images/BodyTracking/synthetic-body-inspector.png)

## Body tracking example
If you followed everything on this page, you should now be familiar with body tracking, body landmarks, and avatar pose matching in Unity MARS.
This section shows a simple body pose tracking example. It includes the following:

* Extracting a pose from an animation
* Testing pose tracking in the Simulation view
* Running the app on a device

When you finish this section, you will have a simple MARS app that displays an avatar that follows your movements. When your body pose matches a pose you defined, the virtual humanoid color will change to blue.

### Extracting a pose from an animation
The first step to working with body pose matching is to have pose data to compare against. The easiest way to do this is to extract a pose from the synthetic body: pause the synthetic body's animation, then save the pose.

![Body Pose Extraction](images/BodyTracking/body-extract-pose.gif)

If you want more precision in selecting a pose, open the Timeline from the synthesized body's Inspector window and use the slider to select a specific frame.
When finished, click the **Save** button and enter a name for your pose.

![Body Pose Extraction](images/BodyTracking/body-pose-tweak.gif)

### Testing the extracted pose in the Simulation View
You are now ready to set up your avatar for pose matching. To do so, follow these steps:

1. From the MARS panel, create a Body Proxy with a Match Body Pose Action and a Body Expression action.
2. Remove the Default Body Rig GameObject.
3. Attach a humanoid avatar as a child of your Body Proxy.
4. Set the animator on the Match Body Pose Action to the avatar you just attached.

    ![Body Pose Prepare](images/BodyTracking/body-prepare-for-match.gif)

4. Attach this script to your main Camera:

    ```
    public class TestPose : MonoBehaviour
    {
        public GameObject objToColor;

        public void Colorblue()
        {
            objToColor.GetComponent<Renderer>().sharedMaterial.color = Color.blue;
            Debug.Log("Matched pose!");
        }
    }
    ```

5. In the main Camera's Inspector window, on the `TestPose` component, set the `objToColor` variable to a skinned mesh renderer in your avatar body or any renderer that you want to color blue when the pose is matched.

6. In the Body Expression action's Inspector, create a trigger event and attach the saved body pose you created in the previous step. Then, drag and drop the camera GameObject to the trigger event and select the `ColorBlue()` method under the `TestPose` class.

    ![Body Pose Prepare](images/BodyTracking/body-prepare-for-match2.gif)

If you want to test this in both Play and Simulation mode, make sure the event is set to run on **Editor And Runtime**.

### Building and testing tracked poses
Now that you have a body proxy prepared to match against a body pose that you created from an animation, you can test your app and run it on your device.

When you press the **Play** button in the Simulation view, you will see the virtual avatar follow the synthetic body. When the synthetic body's pose matches the pose you selected, the virtual avatar's color will change to blue.

![Body Pose Test SimView](images/BodyTracking/body-pose-test.gif)

Finally, build the project to your device and test it out. When your app detects a match between the tracked human's pose and the pose you created, the avatar color will change to blue.

![Body Pose Test Device](images/BodyTracking/body-pose-device-build.gif)

__Note:__ If you can't get your pose to match, adjust the tolerance angle in the Body Expression action's Inspector. If a match occurs abruptly, lower the value. If the match doesn't occur, increase it. A good tolerance angle is around 30 to 35 degrees. If you enter a bigger value, pose matching will match easier. A smaller value requires you to match the pose with more accuracy.
