# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.3.1] - 2021-05-17
### Fixed
- Fixed a malformed fileID that would prevent bodytracking from working in specific Unity versions.
- Compile error in SimulationView.cs due to NUnit reference which can occur if the project does not contain the test framework package
- Fixed bug in the Compare Tool where "Include All" or "Optimize All" print a null reference exception when there is no data selected to be compared with
- Fixed missing tooltips bug in the Simulation View Controls
- Fixed ragged edges bug in the Proxy and ProxyGroup inspector
- Proxy presets created at non-1-to-1 world scale will be created at correct scale
- The shader on `SimulatedPlanesMaterial` used for synthetic planes in the Simulated Environment has been changed to a version where the back faces are not selectable.
- Issue where MARS Shader Material Inspectors would display incorrectly if URP package is not present.
- Simulated point & plane discovery now respect runtime changes to world scale.
- Fixed bug in the Device view that required users to drag the mouse before they could move
- Fixed Replicators limit field losing focus when editing it in the ProxyRuleSet
- Incorrect colors on some Proxy preset icons when in Personal skin.
- Fixed a few materials (old image markers and a bedroom floor) that were not using the cross-renderer compatible shaders
- Fixed MARS gizmo line handles to use cross-renderer compatible shaders
- Updated the MARS body and face gizmo shader for proper URP support.
- Fixed duplicated Replicators in the ProxyRuleSet when entering playmode
- Enabled the bodytracking template in the template selector
- Fixed SynthesizedMarkerId import warning in Unity 2020
- Fixed Create Tool bugs with Simulation Scene picking in Unity 2020.2
- Fixed composite not rendering in legacy render paths when the camera had an opaque background. This is an issue with Unity 2019.4.23f1 and going forward where the scene view always has an opaque background.
- ProxyRuleSet UI objects are now recreated only when hierarchy changes occur.
- Updated the documentation for graphics and AR Background setup.
- Primitive MARS object presets now include a HasPoseCondition, ensuring that they match without additional setup.

### Added
- Scripting API documentation have been added or updated for many items missing documentation
- Tooltips have been added or updated for many items missing documentation
- Added icons for the Body workflow (MARS Panel and Body scene visualization)
- Added MARS components reference guide
- Added docs link to point to the current installed Unity MARS version 1.3
- Added info message on Build Surface action for quickly add missing components for the component to work correctly

## [1.3.0] - 2021-03-03
### Added
- Texture field to MRMarker
- Face tracking properties to expose multi-face tracking settings (where supported). The new properties are only supported in 3.X and 4.X or higher
- Simulation view saves its view for each synthetic environment
- Users of `IUsesHitTesting` now get hit test results against discovered planes and points in simulation
- Content packs for Content Manager
- Privacy & Legal page to documentation
- Missing Save Simulated Environment dialog when opening the simulated environment prefab from the MARS Environment Hierarchy Panel
- Known limitation related to Player build errors
- Expose ResetOnLoss var that was missing from the `SetPoseAction` action

### Changed
- GeoLocation Module does not reference location services unless UNITY_MARS_USE_LOCATION is defined, or when building scenes which require the geolocation trait
- Made IUsesLightEstimation extension methods public
- Behavior of `SimulationView.CacheLookAt` has changed - it is now used to save the non-offset look-at data for the current synthetic environment, regardless of view type
- When installing MARS, it will try to use an unused user layer for the simulation layer rather than layer 3, which is reserved

### Deprecated
- Cloud Storage API (IUses/ProvidesCloudDataStorage)
- The rotateView parameter of `MARSEnvironmentManager.TryFrameSimViewOnEnvironment` is obsolete; Use the overload with two parameters instead

### Removed
- Occlusion material in Training Template
- Unmatched proxy visibility in Training Template
- Warnings about naming of the simulation environment layer
- Unused 'Extract Planes On Save' user preference

### Fixed
- Exception in `UnpackPrefabInstance` that can occur when exiting play mode with a simulation environment open
- Simulated light estimation now updates in one-shot simulation
- Reference image markers have been modified for wider platform support
- Issues in recorded camera path animation curve smoothing
- Issue where the requested face count was incorrectly set to 0
- Text alignment in Training Template prefabs
- Simulation view no longer resets to the default view of the environment on domain reload, modules reload, or simulation resync
- Issue where companion video recordings would show up rotated in play mode
- The Reference (question mark) button on core MARS components (Proxy, ProxyGroup, Replicator, & MARSSession) link to the correct MARS documentation locations
- Face depth mask was not working on device
- Null reference exception in MARS Session
- Issue where content of a Face Proxy preset would display despite no face being matched
- PhysX error from Build Surface Action


## [1.2.0] - 2020-11-13
### Added
- New behaviour `SimulatedPlayable` that pauses and resumes a playable in the simulated environment when in Temporal simulation. This can improve the Unity Editor idling when not in simulation.  
- Distance relation can now be constrained to the horizontal or vertical axis.
- Polygon landmarks can now target the closest pose, in addition to closest point and edge.
- New method `AddRuntimeSceneObjects` in `MARSSceneModule` for including custom objects in play mode MARS setup, to affect which functionality providers are setup
- Utility method `HasMarsBehaviors` which checks if a given scene contains any MARS behaviors
- `MARSSession.EnsureSessionInActiveScene()` can successfully create a MARS Session at runtime if there are no other MARS behaviors in the scene, enabling AR Foundation based applications to use data from MARS simulation in play mode in the editor.
- TrackingStateCondition and tracking state properties added for image markers.

### Changed
- Simulation recording metadata and setup process to support MARS companion data recordings
- The Simulation Environment Layer is now Project Setting found in 'Project Settings -> MARS -> Simulation -> Simulation Environment Layer'.
- Creating a new MARS Session does not alter the hierarchy of the main camera if the camera already has a parent transform. Instead the `MARSSession` component is added to either the camera's immediate parent or a game object with `ARSessionOrigin` if such an object exists in the camera's parent hierarchy.
- `MARSCamera` does not drive the pose of its transform if it already has an `ARPoseDriver` or a `TrackedPoseDriver`.
- Updated Simulation View toolbar UI to show only relevant controls when using only AR Foundation simulation, in scenes without MARS content.
- In scenes with MARS content, added UI to the Simulation View toolbar to access Create and Compare Tools.
- Proxy documentation links to always point to latest version
- Package name to Unity MARS

### Deprecated
- Google Cloud Storage Module

### Removed
- Removed requirements for MARS Session game object to have a specific name and position in the scene hierarchy.

### Fixed
- Issues with how the Unity Editor was idling when a simulation is active caused by when `EditorApplication.QueuePlayerLoopUpdate()` was being called in  `QuerySimulationModule` and `SimulatedObjectsManager`.
- Issue where video content would be misaligned in Game View due to MarsCamera not updating screen size or FOV in Editor.
- MARS Session gathers trait requirements from all loaded scenes in play mode.
- MARS Session and Module provider injection now work in multi-scene scenarios.
- Resolved 'Unassigned renderer' error on synthesized image markers.
- Fixed visual artifacts on the head bust scene visual.
- Composite Rendering Options import will no longer cause a race condition with URP when on 2020.1 or later.
- Distance Relation inspector label for Active Planes (MARS-579)
- Errors that can occur during environment teardown
- Ticking of MARS editor tasks such as checking for simulation resync no longer depends on interaction with editor windows

## [1.1.1] - 2020-08-26
### Added
- Rules workflow (Window > MARS > Proxy Rule Set): a specialized authoring interface for working with MARS objects. See [Rules](../manual/Rules.html) documentation.
- `TrackingStateCondition` for Proxies to require certain levels of tracking quality for image markers; with `trackingState` trait on these database entries.
- Public API to do plane extraction.
- Scriptable events on `Proxy` and `ProxyGroup` for when their match changes.
- Added `KeepMatchPlane` option on `ProxyRegionForcePlane2D` to stay on originally matched plane.
- Added a warning message when the light type is different from directional on Light Estimation Visualizer.
- Added the large park to the list of simulation environments
- `CloudLoadAsync` and `LoadLocalTextureAsync` methods for loading textures from local and cloud storage
- `callback` parameter of `CloudSaveAsync` method is now optional
- Added public set to `PlaneExtractionSettings.VoxelGenerationParams` and `PlaneFindingParams`, so simulation environment setup is scriptable by users.
- Light estimation visualizer, Floor and Height above Floor presets now live in the MARS Panel.
- `MarsObjectCreation` API for creating MARS preset objects
- Public accessors for MarsTrackableId sub-ids

### Fixed
- Issue where serialized `MARSEnvironmentInfo.EnvironmentBounds` were not being used and were being constantly overwritten.
- Fix for saving simulation starting pose and default camera starting pose for `MARSEnvironmentSettings` from inspector of the simulated environment.
- Null reference exception in TransformInspector when selecting prefabs without MARS simulation loaded.
- Warnings for replacing X-Ray Regions when switching environments in play mode.
- Fix rendering of the X-Ray materials in URP by adding new base shader for x-ray.
- Fix issue with `DepthMask.shader` & `TextureStableFresnel.shader` not drawing correctly in URP due to missing depth pass tag for depth pre pass.
- Fix for null ref from `EntityVisualsModule` when selecting non game objects in the project view.
- Issues in simulation setup caused by scripts with `[ExecuteInEditMode]` that modify the hierarchy
- Reduced heap allocations in MARSPlaneVisualizer
- Issue where `ComponentListEditor` could potentially gather multiple Component Editor types for the same Component type
- Fix for missing snapping placement GUI in main toolbar in 2019.4 and added back in the placement panel for 2020 release cycle.
- Issue where unmatched plane data visual proxies would still show their plane outlines
- MissingReferenceException when dragging and dropping a prefab into Simulation view to create a proxy
- Issue where dragging a prefab into the Simulation view causes the environment to stop running in edit mode and remove its data
- GeoFence conditions not matching in Play Mode
- Errors related to simulation cleanup and objects which are the target of open Editors

### Changed
- Simulation environment is now deactivated before it is destroyed in teardown, so that objects in the environment can immediately respond to teardown before the next environment is setup.
- To use Geofence conditions (or any geolocation traits) you now need to turn on "Auto Start Location Service" in the GeoLocationModule (Assets/MARS/UserSetting/Resources).
- MARSUserPreferences are displayed in the Preferences window and use EditorPrefs instead of an asset in the project. The MARSUserPreferences asset should be deleted.
- MARS ProjectSettings providers have been re-organized and updated to be easier to understand
- Renamed the type `Conditions` to `ProxyConditions`
- Renamed the type `MARSUtils` to `MarsEditorUtils` and moved it to the `UnityEditor.MARS` namespace
- Moved `IComponentList<TObject>`, `MenuConstants`, and `MonoBehaviourComponentList` to `Unity.MARS.Editor` assembly
- Several custom Editor types are no longer public
- Synthesized Light Estimation component now uses color and intensity values from the Light component on the GameObject.
- Many types have been moved to different namespaces
- `IModule` and `IModuleDependency` and other interface method implementations on public types are no longer public
- `QuerySimulationModule`
  - `simulatedDataAvailable` removed
  - `StopTemporalSimulation` is no longer public
- Reduced minimum version of com.unity.timeline to 1.2.6 to pass verification tests

### Removed
- The following unused types have been removed: `Complexity`, `ARFacepaint`, `BlendMode`, `DecalLayer`, `TestReasoningAPI`, `SetChildDataCandidate`, `ARFacepaintEditor`, `DecalLayerDrawer`, `HandleUtils`, `IProvidesFallbackLandmarks`, `ITrait`, and `ITrait<T>`

## [1.0.2] - 2020-06-18
### Fixed
- Simulated environment no longer affects 3D physics of simulated content
- Device view movement is locked when no MARSSession / controlling camera is present in the scene.
- Missing warning for scene that can't be simulated when the scene has a functionality user but no MARS Session
- Fix issue where zoom controls still worked in Device view when not simulating temporally and could cause issues with the clipping planes.
- Simulation view is no longer stuck in "Back" view mode for newly created environments
- New environments now use reasonable default values for PlaneExtractionSettings
- Geolocation shortcut buttons correctly pass longitude in the `shortcutAction` callback.
- Simulation Environment GameObject Inspectors are no longer locked when URP or Composite Fallback is enabled.
- Simulation Environment lighting will not be lost when undoing after environment is loaded or after editor nUnit tests are run.
- Fix crash on startup of the editor when using URP and have a Simulation View open.
- Fix error when moving a GameObject to the Simulation Scene Root when it is not a root GameObject.
- Fix for properly sizing data supplied by synthesized planes that has undergone a local transformation.

### Changed
- GeneratedPlanesRoot no longer keeps track of modifications. Saving planes from simulation or extracting planes now always warns the user that previous planes will be destroyed, explains that they can preserve planes by moving them out of the root, and asks confirmation to continue.

### Added
- Inspector for MARSEnvironmentSettings has button to ensure the environment asset has the 'Environment' label and refresh environments.

## [1.0.1] - 2020-06-02
- Updated Unity MARS license

## [1.0.0] - 2020-05-29
### Fixed
- Game template scenes leaving duplicates of character in simulation when cycling environments
- Issue where proxy group update events were not being called
- Simulation selection mode changes when adding a synthetic image marker

### API Changes
- Added public `GetSimulatedObjectsRoot` delegate to `EditorOnlyDelegates`

## [0.9.16-preview] - 2020-05-27
### Fixed
- Exceptions when discovering simulated planes with debug vertices drawing enabled
- Documentation table of contents

## [0.9.15-preview] - 2020-05-25
### Fixed
- Performance issue in non-synthetic temporal simulation
- Issue where Simulation View or Device View would close itself on maximizing
- Ensure Sim Test Runner doesn't run during play Mode
- Memory/GC optimizations for simulated discovery
- Updated all documentation images
- Issue where exceptions are logged when choosing a template
- Issue where exceptions are logged when opening Database Viewer
- Issue where names in Templates window were clipped

## [0.9.14-preview] - 2020-05-22
### Fixed
- Misc issues that can occur when entitlements check fails

## [0.9.13-preview] - 2020-05-21
### Changed
- Rename package and all namespaces to remove "Labs"
- Updated entitlements logic to use production server
- Final docs review

## [0.9.12-preview] - 2020-05-19
### Added
- Give user ability to manually tweak focal length settings per-video playable asset, and have those changes reflected in the Simulation View. Will fall back to value defined in SimulationVideoContextSettings in Live mode.

### Changed
- Composite Rendering automatically enters fallback rendering mode when a Scriptable Render Pipeline (SRP) is in use.

## [0.9.11-preview] - 2020-05-19
### Fixed
- Reloading in play mode no longer causes errors in the Composite Renderer.
- Pressing "record" button with a synthetic recording selected in simulation now starts simulation in manual movement mode instead of playing the recording.
- Generated planes are now added to the `Simulation Environment` layer when created via plane extraction and saving planes from simulation.
- UI hints remain dismissed between Editor sessions.

### Added
- Camera permission dialog for Live simulation mode
- 'Simulation Data Visual Settings' Project Settings section.  This includes an option to set the Rating Gradient, the colors that are used to display feedback on the Compare Tool.
- Support for scriptable simulation environment mode.
- Game and training template moved to installable sample pack.

### Removed
- `CompositeRenderModule.SetupGameView()` & `CompositeRenderModule.TearDownGameView` have been made private.

## [0.9.10-preview] - 2020-05-15
### Fixed
- Specify earlier versions of Timeline and TextMeshPro to fix package dependency errors in later patch versions of 2019.3
- Simulation no longer stays in temporal mode when switching from Live or Recorded environment mode to Synthetic mode
- Fixed an issue where the MarkerCondition inspector after doesn't draw after Player builds
- Disabling simulate in play mode no longer causes errors when entering play mode - use DisallowAutoCreation flag for simulated discovery providers so that they do not get created unless the SimulatedDiscovery functionality island is active.
- Unity MARS enables the `Generate all .csproj files` preference on first import to fix an issue where IDE projects fail to find references to MARS types
- Pressing "play" button during temporal simulation to stop simulation now resets the state to a single-frame simulation, instead of leaving simulation in a state where data is gone but proxies are still matched.
- Game and training templates added

### Added
- MARSSession.EnsureSessionConfigured now checks if existing camera's near plane is greater than a max value, and logs a warning and sets it to the max value if so. It also sets the near plane for a newly created camera to a smaller default value.

## [0.9.9-preview] - 2020-05-11
### Fixed
- Use version defines to handle conditional compiling related to Post Processing package--fixes errors when Post Processing package is removed
- Use filesystem to copy default Unity MARS content into Assets folder

- Add PostProcessUtils to Bootstrap assembly to strip UNITY_POST_PROCESSING_STACK_V2 from player defines if post processing package is missing

## [0.9.8-preview] - 2020-05-10
### Changed
- Removed `bool forceTemporal` parameter from simulation restart methods and replaced with method `RequestSimulationModeSelection`, which enables explicit control over whether the next simulation is single-frame or temporal.
- Environment manager now auto-selects mode when loaded in edit mode as well as play mode. Fixes issue of mode mapped to camera facing getting potentially overwritten by accident when exiting play mode from a scene other than the opened edit scene.

### Added
- Support for face tracking and expressions data recordings in simulation
- Support for looping data recordings in simulation
- Face tracking and expressions data has been added to sample video recordings

### Removed
- A user-available layer is no longer used for simulation environment objects.
- The simulation content can no longer be hidden or locked in the Simulation View display options.

## [0.9.7-preview] - 2020-05-06
- Iterate on auto-import fix

## [0.9.6-preview] - 2020-05-06
- Fix content samples auto-import

## [0.9.5-preview] - 2020-05-06
### Added
- **Create Tool window**: 'Max Count' option. A non-1 value will set up a Replicator parent of the created Proxy. If 'Max Count' is disabled, the Replicator count will be unbounded (infinite).
- Compare Tool now supports Height Above Floor Condition
- **Set Pose Action**: 'Align with World Up' option. Allows for Proxies to keep their Y or Z axis aligned with the world Up direction.
- Live (Face) simulation environment mode now lets the user select which camera to use.
- Light Estimation visualizer to drive a light from ARCore/ARKit lighting estimates, and a simple simulation counterpart.

### Changed
- Synthetic image marker assets are now saved to `Assets/SyntheticImageMarkers`, rather than a folder associated with the active scene.
- Re-organized settings assets to reduce clutter in Assets folder
- Proxy Inspector: The 'Add MARS Component' menu will now only present the type of component being filtered, eg. if you have 'Conditions' selected as the filter, the button will only show Conditions to be added.

## [0.9.4-preview] - 2020-04-23
### Fixed
- Drag+Drop functionality restored
- Blank 'Create' window in Unity 2019.3.10
- 'Create' window colors when using Personal editor theme
- Face landmark droptargets (drag+drop to attach content to specific face regions) functionality restored for face proxies created from scratch

## [0.9.3-preview] - 2020-04-22
### Fixed
- Unused Default Environment is shown on first import

## [0.9.2-preview] - 2020-04-22
### API Changes
- Added `GetMarsSessionInScene()` and `GetMarsSessionInActiveScene()` to `MarsRuntimeUtils`

## [0.9.1-preview] - 2020-04-16
- Internal draft

## [0.9.0-preview] - 2020-04-16
### Added
- **Simulated Environment Modification**: Users can now save edits to Simulation environment made within the Simulation View. After a change has been made, the user will receive a prompt to save or discard changes upon switching environments or recompile.
	- **Simulated Image Marker Workflow**: Simulated image markers now provide an Inspector similar to the Marker Condition for selecting which library image to simulate. A button has been added to the MARS Panel &gt; Create Panel to add a new simulated marker to the current environment.  
- **Immersion Semantics**: “displayFlat” or “displaySpatial” for if a user is using a flat (phone, laptop, etc.) or spatial (VR, AR, etc.) devices.
- **User Type Support**: users can use their own data Trait types (class MyCondition : Condition<MyType>), and the backend code will auto-regenerate itself.

### API Changes
- Renamed `MARSRuntimeUtils` to `MarsRuntimeUtils`
	- Replaced `MarsRuntimeUtils.GetMainOrSimulatedCamera()` with `GetActiveCamera()` and `GetSessionAssociatedCamera()`. See [Finding the Camera](../manual/SoftwareDevelopmentGuide.html#finding-the-camera) documentation.
- Added documentation and exposed data structs in Unity.Labs.MARS.Recording namespace
- `SimulationSettings` properties (`EnvironmentMode`, `EnvironmentPrefab`, etc) are now non-static and require instance access.

### Changed
- Setup of video background in simulation happens entirely in `SimulationVideoContextManager`, removing dependency on face tracking providers to show video in simulation
- Simulation video framing happens via `MARSCamera` setting camera field of view, and framing happens in Device View rather than Simulation View
- Split up `SimulatedCameraProvider` into `SimulationCameraPoseProvider`, which only provides camera pose, and `SimulatedCameraViewProvider`, which provides camera texture, intrinsics, and projection matrix
- Updated color preferences (menu: **Edit &gt; Project Settings &gt; MARS &gt; User Preferences**): added 'Condition Fail Text Color', which is used by the Compare Tool to display unmatched data in the Inspector. Removed color preferences which are no longer being used.
- `SimulationSceneModule` has been changed to use the same scene for `ContentScene` and `EnvironmentScene` when using fallback composite rendering.
- New root game object added to simulation scenes; `ContentRoot` for `ContentScene` and `EnvironmentRoot` for `EnvironmentScene`
  - Objects added to the simulation scene from `AddContentGameObject()` or `AddEnvironmentGameObject()` will be added to that scene's root game object unless `keepAtRoot` is `true`.

### Fixed
- WorldScale now affects all lights and audio sources in a simulation environment.
- The 'Turn Into' options accessed from Unity's main menu: **GameObject &gt; MARS &gt; Turn Into &gt; ...** will now work as expected.
- Graphics issue where content could appear upside-down in Play mode in DX11 graphics mode.
- Recorded videos will now play correctly in simulated views without a face tracking library present.  

### Removed
- **UnityCloudStorageModule**: Cloud storage provider based on Google Cloud Storage

## [0.8.4-preview] - 2020-03-18
### Fixed
- Device View input bug on macOS

## [0.8.3-preview] - 2020-03-18
### Added
- Add support for simulated image markers by default in a new project
- Get & Set API for Unity MARS scene evaluation interval (see `IUsesMarsSceneEvaluation` interface)
- Add `ExcludedProviders` field on the `[ProviderPriority]` attribute, to simplify user setup of platform-specific providers.  See the [Provider Selection](../manual/SoftwareDevelopmentGuide.html#providers) documentation.

### Fixed
- Fix face mask scale: face content is now at 1:1 scale by default
- Improved handling of Proxies being enabled/disabled at runtime
- Fix errors when instantiating SyntheticObject from script
- Fix visual artifacts introduced by composited rendering
- Fix errors in Forces Editor UI
- Removed erroneous component tabs from Proxy Groups and Replicators

### Updated
- All documentation for clarity & consistency
- Post Processing package no longer required, but supported
- Removed wandering horse from test scenes

## [0.8.2-preview] - 2020-03-03
### Added
#### MARS Proxy System
- **Forces**: allows configuration of spring-like and magnet-like forces for layout tuning, multi-occupancy, etc.
- **Priority**: option on Proxy which defines priority for matching against data ids
- **HeightAboveFloorCondition**: easy way to ensure that an object is off of the floor, and optionally by how much (use SemanticTagCondition and “floor” to ensure it is on the floor).
- **Better Filtering**: of component types in Proxy inspector UI.

#### Simulation System
- **Recordings in Play Mode**: Simulation recordings can now be used in Play Mode (select a recording in Simulation Controls, then press normal Play button)
- **Time Scrubbing**: Recordings can be scrubbed using Timeline (Simulation / Menu / Open Timeline).
- **Composite Rendering for Simulation**:
	- Improved multi camera rendering for displaying scene content composited and occluding the simulated environment.
	- Fixed issues with alpha blending in simulation and device views with content scene active.
	- Improved handling of render and image effect settings in composite views.

## [0.8.1-preview] - 2020-02-05
- Added Home Office and Open Office simulation environments
- Simulation environments now support playables
- Existing simulation environments updated with more objects
- Bugfix: adding MARS components with the "All" filter selected won't change the filter
- Add Provider Priority feature

## [0.8.0-preview] - 2020-02-12
- Add SpatialDataModule and dependency on com.unity.labs.spatial-hash: useful for doing efficient spatial queries into complex scenes

## [0.7.2-preview] - 2020-02-18
### Added
- Tabbed Proxy inspector for filtering which MARS components are displayed
- New simulation environments
    - Bedrooms
    - Dining Rooms
- Automated configuration detection on platforms requiring specific settings, including Magic Leap

### Changed
- Newly refreshed & easier to digest documentation.
- [Create](../manual/CreateTool.html) & [Compare](../manual/CompareTool.html) workflows

### Fixed
- Fix handles block simulation from auto-resync
- GeoLocation fixes

## [0.6.11-preview] - 2020-02-04
### Added
- Time scale to MarsTime
- Bedroom and dining room simulation environments
- Elective Extensions feature to help with Magic Leap builds
### Changed
- Update package dependencies
- Improve Create and Compare tool

## [0.6.10-preview] - 2020-01-30
### Fixed
- Fix issues in codegen templates which cause compile errors on import

## [0.6.9-preview] - 2020-01-30
### Removed
- Disable codegen in batch mode to fix CI issues in packages that depend on Unity MARS

## [0.6.8-preview] - 2020-01-29
### Added
- MARS Content folder

### Fixed
- fix issue with flatfloor condition
- fix issue with multi-relation condition
- fix issue with geolocation not re-evaluating
- fix issue with doubled normals an uvs
- Clean up and fix minor issues

## [0.6.7-preview] - 2020-01-23
### Added
- Image marker support
- Occluder mask to work with simulation environments with 4 walls and ceilings
- New simulation environments

## [0.1.1-preview.1] - 2020-01-10
### Changed
- Update terminology

## [0.1.1-preview] - 2020-01-03
### Changed
- Clean up and update documentation for package release
- Editor UI update

## [0.1.0-preview] - 2019-11-27
### Added
- initial version
