# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.3.1] - 2021-05-17
### Fixed
- Issues related to provider setup in `PrepareProviders`
- Update utils dependency version to 1.3.1

## [1.3.0] - 2021-03-03
### Changed
- Update utils dependency version to 1.3.0

## [1.2.0] - 2020-11-13
## Changed
- Package version and dependencies to 1.2.0

## [1.1.1] - 2020-08-26
### Changed
- Update utils dependency version
- Move Editor types into the UnityEditor namespace
- Update examples to explicit, private implementation of interface methods as best practice to avoid public API clutter
- Use DebugUtils.Log to avoid logging normal first-time setup messages during tests

## [1.0.1] - 2020-06-18
- Add [Preserve] attribute to IModuleDependency<>.ConnectDependency to fix errors on IL2CPP in Unity 2020.1+
- Add InternalsVisibleTo for `Assembly-CSharp-testable` and `Assembly-CSharp-Editor-testable` assemblies

## [1.0.0] - 2020-05-29
- Set version number to 1.0.0 for public release

## [0.1.15-preview] - 2020-05-21
- Rename Labs to XRTools
- Update utils dependency with name/namespace change

## [0.1.14-preview] - 2020-05-19
- Disable module reload on ScriptableSettings in Play mode to avoid causing unexpected issues on saving project

## [0.1.13-preview] - 2020-05-15
- Update package metadata

## [0.1.12-preview] - 2020-05-11
- Add TryConnectSubscriber extension method to simplify implementation of ConnectSubscriber

## [0.1.11-preview] - 2020-05-05
- Update com.unity.labs.utils dependency version to 0.1.12-preview

## [0.1.10-preview] - 2020-04-30
- Re-organized settings assets to reduce clutter in Assets folder
- Added `DisallowAutoCreation` flag to `ProviderSelectionOptionsAttribute` to exclude providers which require a prefab or manual setup from automatic provider creation

## [0.1.9-preview] - 2020-04-21
- Add WSA and Unknown platform to OverridePlatforms

## [0.1.8-preview] - 2020-04-16
- Sort modules by full type name as a fallback in case their callback orders are equal to ensure deterministic callback ordering
- Fix exceptions in ModuleLoaderSettings if a module is the global namespace
- Add PrepareFunctionalityForSubscriberTypes method to FunctionalityIsland
- Remove unbalanced call to UnloadModules in UnloadScene

## [0.1.7-preview] - 2020-03-17
- Rename ProviderPriority to ProviderSelectionOptions and add Excluded Providers feature
- Add EnsureFunctionalityInjected extension method for IUsesFunctionalityInjection

## [0.1.6-preview] - 2020-03-02
- Fix ModuleLoaderCore scriptable settings paths

## [0.1.5-preview] - 2020-03-02
- Update com.unity.labs.utils dependency version to 0.1.6-preview
- Update example ScriptableSettingsPath to include Assets folder

## [0.1.4-preview] - 2020-03-02
- Add Preferred Provider attribute to break ties when multiple types implement the same provider interface
- Fix foldout fields in custom inspectors
- Optimize ModuleLoaderSettingsEditor setup
- Fix InvalidOperationException in FuncitonalityIsland.OnValidate

## [0.1.3-preview] - 2020-01-31
- Update Utilities dependency version to fix Tag Manager bug

## [0.1.2-preview] - 2020-01-27
- PR #19
- PR #23
- PR #24

## [0.1.1-preview] - 2020-01-03
-- Cleanup and documentation update for package release

## [0.1.0] - 2019-11-14

### This is the first release of *XR Tools Module Loader*.

This version serves as the foundation for the initial package release of EditorXR
