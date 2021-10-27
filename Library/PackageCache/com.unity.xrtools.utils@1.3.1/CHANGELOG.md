# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.3.1] - 2021-05-17
### Fixed
- Fixed compiler warning for obsolete API in Unity 2021
- Clear out EditorMonoBehaviour.instance in OnDestroy
- Use Start/StopRunInEditMode in SetRunInEditModeRecursively to ensure proper lifecycle calls

## [1.3.0] - 2021-03-03
### Fixed
- Issues related to projects without default packages, such as physics
- Issue in ConditionalCompilationUtility where unrelated attribute types were being checked for optional dependencies

### Added
- `GameObjectUtils.GetNamedChild` method

### Removed
- CompilationTest, which is no longer needed and was causing issues in 2021.1

## [1.2.0] - 2020-11-13
### Added
- `GameObjectUtils.GetComponentsInAllScenes` method

## [1.1.1] - 2020-08-26
### Added
- Version defines for Physics module and uGUI references to fix compile errors if those are removed
- DebugUtils class with wrapper methods for Debug.Log, etc. which do not print logs during tests
- Type.GetPropertiesRecursively extension method

### Fixed
- Issues where EditorScriptableSettings would fail to find existing assets and overwrite them
- Exceptions that do not get logged, but occurred in OptionalDependencyUtility.OnAssemblyCompilationStarted

### Changed
- Organize type namespaces and make some types internal which were not meant to be public
- Use DebugUtils to avoid logging normal first-time setup messages during tests

## [1.0.1] - 2020-06-18
- Update AssemblyDefinition class to include versionDefines
- Ensure consistent UnityEngine.Random seed in tests
- Add InternalsVisibleTo for `Assembly-CSharp-testable` and `Assembly-CSharp-Editor-testable` assemblies

## [1.0.0] - 2020-05-29
- Set version number to 1.0.0 for public release

## [0.1.14-preview] - 2020-05-21
- Rename Labs to XRTools

## [0.1.13-preview] - 2020-05-11
- Fix an issue with EditorScriptableSettings where path strings can have an extra `/`

## [0.1.12-preview] - 2020-05-05
- Fix issues in `ReflectionUtils.NicifyVariableName`

## [0.1.11-preview] - 2020-04-30
- Updated `ScriptableSettings` class to remove `ScriptableSettings/` from asset paths when `ScriptableSettingsPath` attribute is used

## [0.1.10-preview] - 2020-04-21
- Update changelog

## [0.1.9-preview] - 2020-04-21
### Added
- Added `GetChildGameObjects` extension method to `GameObject`. This adds the direct children of the game object to a list.

## [0.1.8-preview] - 2020-04-16
- Update changelog

## [0.1.7-preview] - 2020-04-16
- Add SetRenderMode method to MaterialUtils

## [0.1.6-preview] - 2020-03-02
- Fix package-related bugs in ScriptableSettings
- Fix an issue where ScriptableSettingsProvider could improperly initialize an EditorScriptableSettings asset

## [0.1.5-preview] - 2020-02-24
- Expose AssemblyDefinition class for modifying AssemblyDefinition assets
- Optimize and add tests for GeometryUtils.PointInPolygon
- Add ReflectionUtils.FindTypeInAssembly method

## [0.1.4-preview] - 2020-02-12
- Add extension classes for Bounds, Vector2 and Vector3
- Add performance test abstraction classes
- Add performance tests for some utility methods
- Optimize some geometry utility methods with inlined arithmetic

## [0.1.3-preview] - 2020-01-31
- Fix off-by-one error in TagManager

## [0.1.2-preview] - 2020-01-27
- Added GetPolygonData to geo utils
- Update TagManager to check for required tags and layers in an InitializeOnLoad static constructor
- Use cached TypesPerAssembly list in ForEachType
- Use TypeCache for TagManager attribute check in 2019.2 or newer
- Added GetPolygonData to geo utils, calculates uvs correctly
- Improved Orientation handling on devices and in editor
- Fix for UV center issue #119
- Fix for startup optimization #118

## [0.1.1-preview] - 2020-01-03
- Update XML documentation and package metadata
- Updates supporting development of MARS

## [0.1.0] - 2019-04-07

### This is the first release of *Unity XR Tools Utilities*.

This includes the current state in use by Project MARS.
This repository includes utility methods used by XR Tools projects, starting with EditorXR and Project MARS
