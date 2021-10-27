# Visualizers reference guide
Visualizers lets you preview data that is being scanned as you detect your environment; you can use these components to visually see said data.

## Plane visualizer (`MARSPlaneVisualizer`)
![Visualizer](images/ReferenceGuide/Visualizers/mars-plane-visualizer.png)

Creates planes as you scan your environment to preview the scanned data MARS has gathered.

|**Target Relation**|**Description**|
|---|---|
|**Plane Prefab**|Prefab to instantiate when creating planes.|
|**Use Plane Geometry**|If checked, the planes will match the geometry of the scanned environment; Unchecked will generate square planes.|
|**Make Edge**|If checked, displays an outline of the generated plane.|
|**Edge Width**|Defines the edge thickness of the scanned polygon.|
|**Edge Repeat Distance**|Refers to the repeat distance for the edge texture UVs.|

## Point cloud visualizer (`MARSPointCloudVisualizer`)
![Visualizer](images/ReferenceGuide/Visualizers/mars-point-cloud-visualizer.png)

Visualizes scanned data through a point cloud and displays each point confidence through colors within a gradient.

|**Target Relation**|**Description**|
|---|---|
|**Low Confidence Color**|Defines the color for the low confidence points in the gradient.|
|**High confidence Color**|Defines the color for the high confidence points in the gradient.|

## Face landmark visualizer (`MRFaceLandmarkVisualizer`)
![Visualizer](images/ReferenceGuide/Visualizers/face-landmark-visualizer.png)

Visualizes landmarks on a face mask.

|**Target Relation**|**Description**|
|---|---|
|**Scale**|Scale of the landmarks that are being displayed (in centimeters).|


## Light estimation visualizer (`MARSLightEstimationVisualizer`)
![Visualizer](images/ReferenceGuide/Visualizers/light-estimation-visualizer.png)

Shades your 3D content according to the light direction gathered from the environment.
The Light Estimation Visualizer is an IUsesLightEstimation that if added to a light in the scene will use it do drive the light values from MARS, so you can light AR content.
The light can be directional or ambient depending on device capabilities.