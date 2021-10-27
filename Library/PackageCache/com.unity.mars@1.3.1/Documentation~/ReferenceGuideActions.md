# Actions reference guide
Actions are operations that happen when all conditions in your proxy are met.

## Face landmarks action (`FaceLandmarksAction`)
![Action](images/ReferenceGuide/Actions/face-landmarks-action.png)

Adds face landmarks as children gameobjects to the proxy for later anchoring content.
More info can be found on the [face landmarks section](Landmarks.md#landmarks-on-faces).

|**Target Relation**|**Description**|
|---|---|
|**Create all face landmarks**|Creates children landmarks for every part of the face that can be tracked, such as the eyes, nose, earts, etc. Content that is a child of the landmark will be attached to that part of the face.|
|**Add landmark**|Selectively adds face landmarks to the proxy|

## Plane landmarks action (`PlaneLandmarksAction`)

![Action](images/ReferenceGuide/Actions/plane-landmarks-action.png)

Adds plane landmarks as children gameobjects to the proxy for anchoring content. More info can be found in the [Plane landmarks section](Landmarks.md#landmarks-on-planes).

|**Target Relation**|**Description**|
|---|---|
|**Show Debug Visuals**|If enabled, the landmark will draw debugging gizmos in the scene when the gameobject is selected.|
|**Debug Color**|The color to use when drawing debug gizmos for this landmark.|
|**Add Landmark...**|Adds a landmark as a children gameobject to the proxy. _Options_: **Centroid**: Landmark is the calculated center of the plane's vertices, **Bounding Rect**: Landmark is the smallest rectangle that encapsulates the plane. This is a polygon landmark like the PlaneLandmarkAction itself, and it can create child landmarks from the bounding rectangle vertices. **Provided Center**: Landmark position is the center point that is associated with the plane by the data provider. **Closest (point, edge, pose)**: Landmark is the closest point, edge or pose to another transform. The Pose type will orient forward towards the target, but always aligned to the surface of the plane.|

## Build surface action (`BuildSurfaceAction`)

![Action](images/ReferenceGuide/Actions/build-surface-action.png)

Creates a surface over the tracked planes. This component requires a `MeshFilter` or a `MeshCollider` component to work. 

If you want to make a collider for every detected plane, you can use a Proxy Replicator and on the child Proxy Object add the plane condition, the Build Surface action (you need to remove Set Pose first) and add a Mesh Collider. This will instantiate a proxy with a collider for each detected surface.

|**Target Relation**|**Description**|
|---|---|
|**Local Plane Offset**|Offsets the created plane in local space. Offset in Y axis to clarify depth ordering|
|**Reset On Loss**|When enabled, the object's pose and scale will be reset if the data for the proxy is lost.|

## Body expression action (`BodyExpressionAction`)
![Action](images/ReferenceGuide/Actions/body-expression-action.png)

Matches a human body pose against saved `BodyPoseData` poses. With this you can track if a person is seated, or raising hands or  body pose you can do; for more information refer to the [matching body poses](BodyTracking.md#matching-body-poses) section. 

|**Target Relation**|**Description**|
|---|---|
|**Create Body Pose**|When pressed, opens quickly the avatar editor inspector for creating body poses. For more info, refer to the [Matching body poses](BodyTracking.md#matching-body-poses) section.|
|**Angle Tolerance**|Refers to the maximum permitted bone angles between the current tracked human and the pose being compared against. 0 means the pose has to match exactly. A good matching value would be ~30 to 60 degrees.|
|**Scale To Match Height**|Scales the body to match the actual height of the person.|
|**Trigger Events**|Array of pairs of Body Poses (`BodyPoseData`) and events you can trigger when the pose gets matched.|

## Face action (`FaceAction`)
![Action](images/ReferenceGuide/Actions/face-action.png)

Positions and animates a tracked AR Facemesh.

|**Target Relation**|**Description**|
|---|---|
|**Face Anchor Override**|Set a transform here if you want to animate the face via the action but have it locked elsewhere, like you were putting a face on an AR statue or something.|
|**Face Mesh**|This acts as an occluder for the face; This gets set/replaced by the animated face mesh from the active facetracking system (if available).|

## Face expression action (`FaceExpressionAction`)
![Action](images/ReferenceGuide/Actions/face-expression-action.png)

Lets you create events when certain face movements happen.

|**Target Relation**|**Description**|
|---|---|
|**Add Event**|Creates a new list of events that get triggered when a specific face movement happens.|

|**Available Face Events**||
|---|---|
|Left Eye Open|Left Eye Close|
|Right Eye Open|Right Eye Close|
|Left Eyebrow Raise|Left Eyebrow Lower|
|Right Eyebrow Raise|Right Eyebrow Lower|
|Both Eyebrows Raise|Both Eyebrows Lower|
|Left Lip Corner Raise|Left Lip Corner Lower|
|Right Lip Corner Raise|Right Lip Corner Lower|
|Smile Engaged|Smile Disengaged|
|Mout Close|Mouth Open|

## Match body pose action (`MatchBodyPoseAction`)
![Action](images/ReferenceGuide/Actions/match-body-pose-action.png)

This component lets you make a mecanim humanoid avatar match movements a tracked person can do. It lets you attach assets to body landmarks (i.e a hat, a watch, a necktie) so they can be augmented and placed when tracking a person.

To understand better how the body tracking works; refer to the [Body tracking section](BodyTracking.md) in the MARS docs.

|**Target Relation**|**Description**|
|---|---|
|**Body Rig**|**Transparent Default**: Creates a default body rig as a child of this proxy, this body rig is useful when creating landarks in bodies, **Custom Avatar**: Lets you select a humanoid avatar to match to the tracked body.|
|**Animator**|Reference to the Humanoid's Animator that you want to match body poses to the tracked person.|
|**Edit Bindings**|Lets you edit the current assigned avatar pose that is references in the animator field.|
|**Scale To Match Height**|Scales the humanoid avatar to match the actual height of the person.|
|**Reset On Tracking Loss**|When enabled, the object pose and scale will be reset if the data for it is lost.|

## Match action (`MatchAction`)
![Action](images/ReferenceGuide/Actions/match-action.png)

This component lets you trigger your onw methods when this proxy's conditon is met.

|**Target Relation**|**Description**|
|---|---|
|**On Match Acquire**|Event called when the conditions on the proxy are matched.|
|**On Match Update**|Event called each frame while the conditions on the proxy are matched.|
|**On Match Loss**|Event called when one or more conditions on the proxy are not met and the proxy match is loss.|
|**On Match Timeout**|Event called when no query match has been found in time.|

## Set aligned pose action (`SetAlignedPoseAction`)
![Action](images/ReferenceGuide/Actions/set-aligned-pose-action.png)

Syncs the gameobject's position with the real world object and aligns the long side to the X-Axis.

|**Target Relation**|**Description**|
|---|---|
|**Follow Match Updates**|When enabled, movement of the matched data, such as surface resizing will be followed.|
|**Reset On Loss**|When enabled, the object's pose and scale will be reset if the data for it is lost.|

## Set pose action (`SetPoseAction`)
![Action](images/ReferenceGuide/Actions/set-pose-action.png)

Set the position of this game object to the position of the found real-world object.

|**Target Relation**|**Description**|
|---|---|
|**Follow Match Updates**|When enabled, movement of the matched data, such as surface resizing will be followed..|
|**AlignWith World Up**|The axis that will be aligned to the world up direction. If set to None (default), the data's pose rotation will be used directly. If set to Y, the local Y axis will always be aligned with the world Up direction. If set to Z, the local Z axis will always be aligned with the world Up direction.|
|**Reset On Loss**|When enabled, the object's pose and scale will be reset if the data for it is lost..|

## Show Objects on tracking action (`ShowChildrenOnTrackingAction`)
![Action](images/ReferenceGuide/Actions/show-children-on-tracking-action.png)

Activates children if the parent Real World Object is tracked; disables children otherwise.

## Show Objects in bounds action (`ShowChildrenInBoundsAction`)
![Action](images/ReferenceGuide/Actions/show-children-on-bounds-action.png)

Disables any children outside of the real-world object's bounds.

## Stretch to extents action (`StretchToExtentsAction`)
![Action](images/ReferenceGuide/Actions/stretch-to-extents-action.png)

Scales children to fit the bounds of their parent real world object.

|**Target Relation**|**Description**|
|---|---|
|**Planar Stretch**|How content should be scaled to match the extents of an AR object.|
|**Vertical Stretch**|How content should be scaled vertically to match the extents of an AR object.|
|**Base Scale**|The default size of the proxy that will be used to scale down the effect from the bounds.|
|**Reset On Loss**|When enabled, the object's pose and scale will be reset if the data for it is lost.|
