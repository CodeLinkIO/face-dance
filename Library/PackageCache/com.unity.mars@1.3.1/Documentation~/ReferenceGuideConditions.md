# Conditions reference guide
Conditions are components that you add to MARS proxies that lets you specify what type of content you want to match against the real world.  
 
## Alignment condition (`AlignmentCondition`)
![Condition](images/ReferenceGuide/Conditions/alignment-condition.png)

Requires the proxy (a surface) to have the specified alignment (Horizontal, vertical, other).

|**Target Relation**|**Description**|
|---|---|
|**Alignment**|Sets which alignments the proxy can have so this condition can be fulfilled (Can have more than alignment at the same time).|
|**Set rotation**|Sets the rotation of this object in the scene as a visual convenience.|

## Geo fence condition (`GeoFenceCondition`)
![Condition](images/ReferenceGuide/Conditions/geofence-condition.png)

Requires the proxy to be located inside or outside of the specified geolocation.

|**Target Relation**|**Description**|
|---|---|
|**Rule**|Describes whether the condition relies on the user being inside or outside the fence.|
|**Center Latitude**|Center of the latitude position (in degrees) where the condition is applied.|
|**Center Longitude**|Center of the longitude position (in degrees) where the condition is applied.|
|**Extents Latitude**|Distance from the center in latitude degrees that the boundary condition extends.|
|**Extents Longitude**|Distance from the center in longitude degrees that the boundary condition extends.|
|**Go to GeoLocationModule**|Upon pressed takes you quickly to the GeoLocationModule for simulating/setting options.|
|**Geolocation shortcuts**|Dropdown that contains several geolocation presets for some cities in the world.|


## Height above floor condition (`HeightAboveFloorCondition`)
![Condition](images/ReferenceGuide/Conditions/height-above-floor-condition.png)

Requires the proxy to be raised certain distance above the floor.

|**Target Relation**|**Description**|
|---|---|
|**Ideal Height**|Sets the "ideal" height the proxy should be from the floor for this condition to happen.|
|**Range From Ideal Height**|Sets the range from the ideal height in case you want to have a range where the condition should be met.|
|**Require In Range**|Sets the requirement that the height must be within the ideal height +/- the range from the ideal height.|

## Marker condition (`MarkerCondition`)
![Condition](images/ReferenceGuide/Conditions/marker-condition.png)

Requires the proxy to have a particular image marker (the current selected one) with a set size to be matched.

|**Target Relation**|**Description**|
|---|---|
|**Marker Library**|Contains all the image markers available in the current set marker library.|
|**Texture**|Texture selected for this marker condition.|
|**Label**|Optional label to use to refer the image marker.|
|**Size**|Physical size (in meters) the image marker to match against should have.|
|**Marker ID**|Internal marker GUID in the marker library (read only).|

## Flat floor condition (`FlatFloorCondition`)
![Condition](images/ReferenceGuide/Conditions/flat-floor-condition.png)

This condition ensures the proxy to have both a floor tag and a horizontal alignment.

## Plane size condition (`PlaneSizeCondition`)
![Condition](images/ReferenceGuide/Conditions/plane-size-condition.png)

Requires the proxy to be a plane within the specified size range.

|**Target Relation**|**Description**|
|---|---|
|**Edit Condition**|Pressing this toggle lets you edit the plane size in the scene view with handles.|
|**Minimum Size**|Minimum plane size for the condition to be met (optional).|
|**Maximum Size**|Maximum plane size for the condition to be met (optional).|

## Semantic tag condition (`SemanticTagCondition`)
![Condition](images/ReferenceGuide/Conditions/semantic-tag-condition.png)

Requires the proxy to have (or lack) the specified trait.

|**Target Relation**|**Description**|
|---|---|
|**Trait Name**|Sets the name of the trait that must be present (or absent).|
|**Match Rule**|Makes the condition to whether require a semantic tag to be present or be excluded.|

## Tracking state condition (`TrackingStateCondition`)
![Condition](images/ReferenceGuide/Conditions/tracking-state-condition.png)

Requires the trackable object to have a minimum tracking quality.

|**Target Relation**|**Description**|
|---|---|
|**Minimum Tracking State**|The minimum quality of object tracking needed to maintain this Proxy's match. (**Unknown**: No tracking, **Tracking**: Tracking is working normally, **Limited**: Some tracking information is available, but it is limited or of poor quality)|

