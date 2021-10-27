# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [0.3.11-preview] - 2021-07-29
### Changed
- Revert GenesisCloudStorageModule to using UnityWebRequest
- Data Usage List model updates for organization-based view

### Fixed
- Compile errors in 2021.2

## [0.3.10-preview] - 2021-06-08
### Fixed
- Use guid instead of id for unique project ID in data usage list

### Added
- Issues raised for user not signed in and network unreachable
- License for Inter font

## [0.3.9-preview] - 2021-03-08
### Added
- IssueHandler API for error feedback

### Fixed
- Issue where users could not switch accounts on iOS

## [0.3.8-preview] - 2021-01-28
### Added
- App Store login query parameter to iOS login URL

### Fixed
- Issue where resource list is not updated if a resource fails to upload

## [0.3.7-preview] - 2021-01-12
### Changed
- Updated documentation

## [0.3.6-preview] - 2021-01-09
### Changed
- Made many types internal which were not intended to be public APIs

## [0.3.5-preview] - 2021-01-07
### Added
- More log information for when AssetBundles fail to load

### Fixed
- Issues where the app would not close gracefully due to lingering web requests

## [0.3.4-preview] - 2021-01-07
### Fixed
- Use HTTPClient API to work around issues with UnityWebRequest

## [0.3.3-preview] - 2021-01-05
### Fixed
- Console error on importing scenes

## [0.3.2-preview] - 2021-01-03
### Added
- Explicit dependencies for built-in packages

### Changed
- Update serialization dependency to latest version

### Fixed
- Issue where you could not publish scenes from the editor if you canceled one

## [0.3.1-preview] - 2020-12-28
### Added
- CloudStorage functionality interfaces, RequestHandle struct for canceling requests, and timeout parameter for cloud storage requests

## [0.3.0-preview] - 2020-12-14
### Added
- Safari Web View for sign-in on iOS

### Changed
- Documented known limitations to include Burst errors on Big Sur
- Package name to Unity MARS Companion Core

### Fixed
- Update resource UI on importing new scenes so that the scene asset shows up in the object field
- Set scene name when importing scenes for the first time

## [0.2.3-preview] - 2020-11-23
### Fixed
- Warnings and errors that can occur when publishing asset bundles
- Issue where Companion Resource UI would show no resources for an empty resource folder
- Destroy Temp camera objects before saving scenes
- Improved legibility of error feedback in CompanionResourceUI

## [0.2.2-preview] - 2020-11-17
### Added
- Analytics utilities with optional DeltaDNA integration
- Errors field to DataUsageList to check for retry

### Updated
- Companion resource UI to new design
- Thumbnails are generated for all resource types
- Resources are deleted on the cloud--previously they were just cleared from the List

## [0.2.1-preview] - 2020-10-05
### Fixed
- Issues loading downloaded scenes while offline

## [0.2.0-preview] - 2020-10-05
### Fixed
- Issue where logging out did not clear cached authentication token
- Issue where video recordings failed to save for anonymous users

## [0.1.9-preview] - 2020-09-30
### Fixed
- References to missing guids in built-in prefabs

## [0.1.8-preview] - 2020-09-30
### Added
- Builtin prefabs and primitives from MARS default content and AR Placeables

### Changed
- Update documentation

### Fixed
- Issues with saving and importing image markers

## [0.1.7-preview] - 2020-09-29
### Added
- Documentation for mobile app
- Storage key validation methods

### Changed
- Use guids instead of resource names for all resource keys
- Replace component keys with bools in data recording metadata to indicate whether components have been uploaded

### Fixed
- Exceptions that can occur when publishing prefabs

## [0.1.6-preview] - 2020-09-28
### Fixed
- Issues with saving and importing data recordings

## [0.1.5-preview] - 2020-09-25
### Added
- Success parameter to callback for GetResourceList and resouceListChanged event

### Changed
- Validate behavior of Publish context menu item; does not block scenes from getting published and prompts users about build platform issues
- Update the list of marker libraries in Companion Resource Window when MarsMarkerLibraries are imported

### Removed
- Menu item for UI Toolkit resource window

### Fixed
- Do not show users a prompt and attempt to save video files that were not uploaded
- Issues in ProxyListViewData related to serialization in the Editor
- Issues with loading local asset bundles
- Spelling mistake in default project name

## [0.1.4-preview] - 2020-09-18
### Added
- Added CompanionSceneUtils.CopySceneResource to duplicate scenes
- DataUsageData serialized type
- IFormatVersion implementation for resource types

### Changed
- ProxyListViewData and related types to handle setting changes to properties as prefab overrides
- Use CloudProjectSettings.accessToken for authentication in editor outside of play mode
- Methods in CompanionFileUtils now return file contents in callback

### Removed
- Usage of API key in GenesisCloudDataStorageModule, and Link Account button in resource UIs

## [0.1.3-preview] - 2020-09-11
### Changed
- Incorporate FOV and ZRotation properties into data recordings
- Update dependency version of MARS to support video playback in data recordings

## [0.1.2-preview] - 2020-09-11
### Changed
- List view dependency version for multi-select update
- TextMeshPro dependency version to fix text alignment

### Fixed
- Issue where GenesisCloudDataStorageModule would open a browser to sign in on import
- Sharing violation exception on entering play mode

## [0.1.1-preview] - 2020-09-09
### Added
- GenesisCloudDataStorageModule, OAuthTokenGenesisModule, and other infrastructure for authenticated storage

## [0.1.0-preview] - 2020-08-27

### This is the first release of *MARS Companion Core*.

This package contains Editor functionality and core APIs for the MARS Companion Apps
