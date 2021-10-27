# Simulation Environment Components Reference guide
This section refers to components that are not part of Unity MARS proxies yet they are used in the MARS simulation environments. 
Commonly these components set how the simulation environment is organized.

For reading about components that simulate realworld data in the simulated environments please refer to the [Synthetic Data](ReferenceGuideSyntheticData.md) section.   

## Ignore for environment persistence (`IgnoreForEnvironmentPersistence`)
![Sim environment ignore for persistence](images/ReferenceGuide/SimulationEnvironmentComponents/ignore-for-environment-persistence.png)

This is used when you have simulation environment objects that move / change and you want to ignore said objects to not trigger an environment pop up save dialog.
This script is used on synthetic bodies. 

|**Target Relation**|**Description**|
|---|---|
|**Ignore Children Also**|If checked, ignores any change that this object or any of its children do.|

## Simulated Object (`SimulatedObject`)
![Sim env simulated object](images/ReferenceGuide/SimulationEnvironmentComponents/simulated-object.png)

Identifies this object as a simulated replacement for real world data.
This component is used in place of [Synthesized Object](ReferenceGuideSyntheticData.md#synthesized-object-synthesizedobject) to feed data from synthetic components through the MARS data provider layer, enabling you to test your content with data as it would come through on a device. 

## MARS Environment Settings(`MARSEnvironmentSettings`)
![Sim environment settings](images/ReferenceGuide/SimulationEnvironmentComponents/mars-environment-settings.png)

This component holds several scene environment settings like the initial position of the camera, how the environment is colored, position where the camera starts the simulation among others. 

|**Target Relation**|**Description**|
|---|---|
|***Environment Info***|*Holds environment scene settings*|
|**Default Camera World Pose**|Refers to the initial world pose of the camera when this environment scene is loaded|
|**Default Camera Pivot**|Default world pivot of the scene camera for this environment scene|
|**Default Camera Size**|Default orbit radius of the camera when viewing this environment scene|
|**Save Environment View** button|When pressed, saves the default camera settings for this environment scene to match your current scene or simulation view camera|
|**Simulation Starting Pose**|Refers to the world pose of the device (device view mode) when starting a simulation|
|**Environment Bounds**|Sets the bounds that encapsulate the whole simulation environment|
|**Save Simulation Starting Pose** button|When pressed saves the simulated device starting pose for this environment to match your current scene or sim view camera|
|***Render Settings***|*Set of settings that define how the simulation environment is rendered*|
|**Ambient Mode**|Refers to the ambient mode type applied to the simulation environment; for example directional ambient with separate sky, equator and ground colors, or flat ambient with a single color.|
|**Ambiend Sky Color**|When the Ambient Mode is set to Trilight; Trilight ambient lighing mode uses this color to affect upwards-facing object parts.|
|**Ambient Ground Color**|When the Ambient Mode is set to Trilight; Trilight ambient lighing mode uses this color to affect downwards-facing object parts.|
|**Ambient Intensity**|How much the light from the Ambient Source affects the Scene.|
|**Ambient Light**|Refers to the Flat ambient lighting color.|
|**Substractive Shadow Color**|Refers to the color used for the sun shadows in the Subtractive lightmode.|
|**Reflection Intensity**|Sets how much the skybox / custom cubemap reflection affects the Scene.|
|**Reflection Bounces**|Defines in how many passes reflections are calculated. In a given pass, the Scene is rendered into a cubemap with the reflections calculated in the previous pass applied to reflective objects.If set to 1, the Scene will be rendered once, which means that a reflection will not be able to reflect another reflection and reflective objects will show up black, when seen in other reflective surfaces. If set to 2, the Scene will be rendered twice and reflective objects will show reflections from the first pass, when seen in other reflective surfaces.|
|**Default Reflection Mode**|Refers to the default reflection mode to use in the environment; this can use a custom texture or generate a specular reflection texture from the skybox|
|**Default Reflection Resolution**|Refers to the cubemap resolution for the default reflection.|
|**Halo Strength**|Refers to the size of the Light halos. For any light, the size of the halo is this value multiplied by Light.range.|
|**Flare Strength**|Sets the intensity of all flares in the environment.|
|**Flare Fade Speed**|Refers to the fade speed of all flares in the environment.|
|**Skybox**|Sets a skybox material to use on the simulation environment|
|**Custom Reflection**|Specifies a cubemap for use as a default specular reflection.|
|**Use Scene Sun**|When checked uses the light in the environment as the sun|
|**Ambient Probe**|Skybox ambient lighting mode uses this Spherical Harmonics (SH) probe to calculate ambient. You can also assign a completely custom SH probe this way. The GI system will bake the ambient probe, but it actually won't be used on geometry that uses light probes or lightmaps, as the environment lighting is already in the light probes and the lightmaps. It is used as the last fallback if light probes or lightmaps are not present or enabled for an object.|

## Plane Extraction Settings(`PlaneExtractionSettings`)
![Sim env plane extraction settings](images/ReferenceGuide/SimulationEnvironmentComponents/plane-extraction-settings.png)

Settings used by MARS to generate synthetic AR plane data from the whole simulated environment. These planes are baked into the environment and used to provide data for instant simulation.
On temporal simulation these planes will not be used.

|**Target Relation**|**Description**|
|---|---|
|***Voxel Generation Params***|*The Voxel generation params are settings used by MARS to generate and voxelize a point cloud of the simulated environment, this is used when preparing the environment for plane extraction.*|
|**Raycast Seed**|Seed with which to initialize the random number generator used to create rays|
|**Raycast Count**|Refers to the number of raycasts used to generate a point cloud|
|**Max Hit Distance**|Sets the maximum hit distance for each raycast|
|**Normal Tolreance Angle**|If the angle between a point's normal and a voxel grid direction is within this range, the point is added to the grid|
|**Voxel Size**|Refers to the side length of each voxel|
|**Outer Points Threshold**|This is a threshold, The points that are within this distance from the bounds outer side facing the same way as the point's normal will be ignored|
|***Plane Finding Params***|*The Plane finding params defines settings that are used by MARS to generate environment surface data based on points and voxels generated using Voxel Generation Params*|
|**Min Points Per Square Meter**|Defines the voxel point density threshold that is independent of voxel size|
|**Min Side Length**|Planes with x or y extent less than this value will be ignored|
|**In Layer Merge Distance**|Planes within the same layer that are at most this distance from each other will be merged|
|**Cross Layer Merge Distance**|Planes in adjacent layers with an elevation difference of at most this much will be merged|
|**Check Empty Area**|When enabled, planes will only be created if they do not contain too much empty area|
|**Allowed Empty Area Curve**|Curve that maps the area of a plane to the ratio of area that is allowed to be empty|

## Simulated Playable(`SimulatedPlayable`)
![Sim env simulated playable](images/ReferenceGuide/SimulationEnvironmentComponents/simulated-playable.png)

This components automatically attaches a `Playable Director` component if there are none; the Playable Director attached 
to this game object will pause and resume play based on whether temporal simulation is active or not.

## X Ray Collider(`XRayCollider`)
![Sim env xray collider](images/ReferenceGuide/SimulationEnvironmentComponents/xray-collider.png)

This component is part of the XRay system for synthetic environments.
This component marks a collider as being one that can be disabled through the x-ray system so when something is getting xrayed out the collider gets disabled.

## X Ray Region(`XRayRegion`)
![Sim env xray region](images/ReferenceGuide/SimulationEnvironmentComponents/xray-region.png)

This component is part of the XRay system; This component defines a region of space that can be cut into dynamically to view the contents through an XRay view

|**Target Relation**|**Description**|
|---|---|
|**Floor Height**|Defines the height of the floor in local coordinates.|
|**Ceiling Height**|Defines the ceiling height in local coordinates.|
|**Clip Offset**|Sets how much the camera clipping plane moves forward from the center of this region.|
|**View Bounds**|Refers to the active size of the clipping region.|
