# Synthetic data reference guide
This section refers to components that generate data used by Unity MARS proxies.
When placed under a proxy itself, synthetic components add data directly to the MARS database when the proxy finds a match.
When used with the [Simulated Object](ReferenceGuideSimulationEnvironmentComponents.md#simulated-object-simulatedobject) component in a simulation environment, synthetic components go through the MARS data provider layer, enabling you to test your content with data as it would come through on a device. 

For setting the simulation environment setup you can refer to the [Simulation Environments](ReferenceGuideSimulationEnvironmentComponents.md) section.

## Synthesized body (`SynthesizedBody`)
![Synthesized body](images/ReferenceGuide/SyntheticData/synthesized-body.png)

Lets you play / stop the set animation in the synthetic body for being able to save a body pose from it.

|**Target Relation**|**Description**|
|---|---|
|**Animation Playback**|Plays, Pauses or Stops the current synthetic body animation.|
|**Open Timeline**|Opens the timeline inspector to be able to tweak the current animated synthetic pose for saving it.|
|**Extract Body Pose**|By pressing the `Save Pose` button the current synthetic body pose will be saved.|

## Synthesized Marker Id (`SynthesizedMarkerId`)
![Synthesized marker id](images/ReferenceGuide/SyntheticData/synthesized-marker-id.png)

Simulates an image marker in the simulation view for later matching it with a proxy with a marker condition.
Use the `MARS Panel -> Synthetic Image Marker` preset to quickly create a synthesized marker in the simulation view.
Normally this component is used in conjunction with a Synthesized Marker component.

|**Target Relation**|**Description**|
|---|---|
|**Marker Library**|Contains all the image markers available in the current set marker library.|
|**Texture**|Texture selected for this synthetic marker.|
|**Label**|Optional label to use to refer the image marker.|
|**Size**|Physical size (in meters) the synthetic image marker has.|
|**Marker ID**|Internal marker GUID in the marker library (read only).|

## Synthesized Marker (`SynthesizedMarker`)
![Synthesized marker](images/ReferenceGuide/SyntheticData/synthesized-marker.png)

Creates data for an MRMarker.
When added to a synthesized object, adds a trackable MRMarker to the database.
When added to a simulated object, it's data will be provided to the database by the simulated marker provider.
Normally this component is used in conjunction with a Synthesized Marker ID component.

## Synthesized object (`SynthesizedObject`)
![Synthesized object](images/ReferenceGuide/SyntheticData/synthesized-object.png)

Component that automatically inserts and updates data in MARS database.
Intrinsically linked to the proxy it is parented to.

|**Target Relation**|**Description**|
|---|---|
|**Override Data ID**|Every piece of data in MARS is assigned an ID (Like every discovered plane gets an ID, and all the traits associated with it have the same ID). Normally, IDs are randomly generated, but MARS has a few values that are static. **Unset** means use the normal random logic **ImmediateEnvironment** is used for non-spatial data; things like 'weather', global lighting, etc and **LocalUser** It's for linking data to the user..|

## Synthesized pose (`SynthesizedPose`)
![Synthesized pose](images/ReferenceGuide/SyntheticData/synthesized-pose.png)

Creates the data for a pose trait. When added to a synthesized object, adds a pose in the form of the GameObject's world position
to its representation in the MARS database.

## Synthesized Manual pose (`SynthesizedManualPose`)
![Synthesized manual pose](images/ReferenceGuide/SyntheticData/synthesized-manual-pose.png)

Create the data for a pose trait. When added to a synthesized object, adds a pose that is manually specified via script
to its representation in the database.

## Synthesized plane (`SynthesizedPlane`)
![Synthesized plane](images/ReferenceGuide/SyntheticData/synthesized-plane.png)

Creates data for an MRPlane.
When added to a synthesized object, adds a trackable MRPlane to the database.
When added to a simulated object, it's plane will be provided to the database by the simulated plane provider.

|**Target Relation**|**Description**|
|---|---|
|**Use MR Plane Mesh**|When checked, the plane used for the SynthesizedTrackable will have a runtime generated ID rather than any serialized value.|

## Synthesized Semantic Tag (`SynthesizedSemanticTag`)
![Synthesized semantic tag](images/ReferenceGuide/SyntheticData/synthesized-semantic-tag.png)

Creates data for a semantic tag trait.
When added to a synthesized object, adds a semantic tag to its representation in the database

|**Target Relation**|**Description**|
|---|---|
|**Semantic Tag**|Semantic tag to use on this object. Automatically changes the tag in the database when set.|

## Synthesized Alignment (`SynthesizedAlignment`)
![Synthesized alignment](images/ReferenceGuide/SyntheticData/synthesized-alignment.png)

Creates the data for a plane alignment trait. When added to a synthesized object, adds an alignment based on the game object's rotation.

## Synthesized Bounds 2D (`SynthesizedBounds2D`)
![Synthesized bounds 2D](images/ReferenceGuide/SyntheticData/synthesized-bounds-2d.png)

Creates the data for a 2D bounds trait. When added to a synthesized object, adds extents based on the object's scale to its representation in the database.

## Synthesized Light Estimation(`SynthesizedLightEstimation`)
![Synthesized light estimation](images/ReferenceGuide/SyntheticData/synthesized-light.png)

In simulation the Synthesized Light Estimation component uses the light color to feed the IProvidesLightEstimation provider.
On the consuming side the MARS Light Estimation Visualizer is an IUsesLightEstimation that if added to a light in the scene will use it do drive the light values from MARS, so you can light AR content.

|**Target Relation**|**Description**|
|---|---|
|**Directional**|When checked the transform direction of the light will be taken into account for lighting|
