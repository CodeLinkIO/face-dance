# Forces reference guide
Proxy forces allow you to express a web of flexible spring-like forces that pull your proxy into its final position.
For more information about proxy forces you can jump to the [forces section](Forces.md).

Below are the key concepts, types, and main properties that the Proxy forces system uses.

## Forces (`ProxyForces`)

![ProxyForces](images/Forces/proxy-forces-component.png)

Collects and applies the forces below onto this object. One per GameObject. If you enabled the **Require Forces*** option, set forces to act as starting conditions to filter out invalid starting states.

## Alignment (`ProxyAlignmentForce`)

![ProxyAlignmentForces](images/Forces/proxy-alignmnet-force.png)

Applies a force that aligns this object relative to another object. This supports multiple target relations. Depending on the purpose of your application, they work as follows:

|**Target Relation**|**Description**|
|---|---|
|**Move To And Align With**|Moves and rotates to align with the target object.|
|**Move To And Face**|Moves to the target object and faces it (faces towards the Z axis).|
|**Center In Front Of And Face**|Moves in front of the object and faces it (faces towards the Z axis), regardless of distance.|
|**Scene Initial Relative Pose**|Saves the initial alignment (in the scene) from the target to this object, and applies a force to regain that alignment.|
|**Scene Initial Relative Angle**|Saves the initial angle (in the scene) from the target to this object, and applies a force to regain that angle.|

**Scale forces** control the amount of force applied towards the goal pose. Set this value to 0 to make the force have no effect and 1 to apply the full force.

## Region - Occupancy (`ProxyRegionForceOccupancy`)

Describes how the object occupies space and applies a force to keep it from colliding with other occupied spaces. By default, Unity MARS assigns a unit cube to the region transform and creates this cube as a child of the Proxy. This transform defines the region's shape and pose.

![ProxyRegionForceOccupancy](images/Forces/proxy-region-force-occupancy.png)

**Note**: Because Proxy forces don't depend on Unity's physics system, if you want to change the region transform of any Proxy force, you only have to change the scale of the transform assigned in the **Region Transform** object field.

Padding regions are used to model empty/negative space around the object. They can overlap with other paddings but will collide with occupied regions. If you enable the **Is Padding** option, the Proxy will avoid occupied regions, but will allow overlap with other padded areas.

## Region - Towards (`ProxyRegionForceTowards`)

![ProxyRegionForceTowards](images/Forces/proxy-region-force-towards.png)

Describes a region that is attracted towards other objects (an attach-shape or snap-point). A "towards" region is often used to describe parts of objects that should be in contact with a surface such as a wall, the floor, or both.

You can configure this force using the following parameters:

|**Parameter**|**Description**|
|---|---|
|**Towards Layers**|Filters the attraction to only the selected layers.|
|**Towards Alignment**|Filters the attraction to the set alignment (vertical, horizontal up, etc.)|
|**Towards Edge Only**|Attraction can be only towards the edge of the object. This is useful when defining corner alignments, for example.|
|**Region Transform**|Describes the shape of the attachment or attraction region relative to the proxy.|

## Region - Plane2D (`ProxyRegionForcePlane2D`)

![ProxyRegionForcePlane2D](images/Forces/proxy-region-force-plane-2D.png)

Describes a flat 2D region at the object origin that is attracted towards other planes and provides a way to automatically pull the size and alignment of this region from other **Conditions** on the Proxy.

You can configure this force using the following parameters:

|**Parameter**|**Description**|
|---|---|
|**Keep Match Plane**|When enabled within a plane proxy, only is attracted to the matched plane.|
|**Use Plane Size Condition**|When enabled, gets the region size from a **plane size condition** available at start.|
|**Use Alignment Condition**|When enabled, gets the region's alignment from an **alignment condition** available at start.|
|**Plane Size**|Size of the 2D plane in X and Y/Z axes (can automatically pull from an associated plane size condition).|
|**Plane Alignment**|Defines which planes to align with, like only horizontal up (can automatically pull from an associated alignment condition).|
