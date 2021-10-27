# About the Unity Content Manager

The Unity Content Manager shows samples, extension packages, and other pieces of content available for a product. All of these types of content are packages that you can install and manage from the Package Manager window.

The Content Manager enables you to configure and extend a project. It streamlines installation for various sample types and automatically handles soft dependencies. This allows a sample to depend on packages that the main package does not include.

## Installing the Unity Content Manager

Unity automatically installs the Content Manager when you install a supported product, such as Unity MARS.

## Using the Unity Content Manager

To open the Content Manager, from Unity's main menu, go to **Window &gt; Content Manager**.

The top-left corner of the **Content Manager** window shows supported products. Select different categories to see which content packs are available to install. 

The Unity Content Manager uses the following terminology:

*   **Content Product**: A scriptable object that lists a **Product** entry in the Content Manager, along with the categories it supports and the folder that contains all the content packs it will show
*   **Content Pack**: A custom reference to a Package Manager package.

You can install content packs in one of the following three ways:<a name="installation-type"/>
|**Installation type**|**Notes**|
|---|---|
|**Package**|Installs like a typical Unity package.|
|**Embedded package (writable)**|Installs like a typical Unity package and embeds it (that is, it copies the package into your project's `Packages` folder) to make package contents writable.|
|**Direct import**|Installs like a typical Unity package and imports the first available sample into your Unity project (that is, the first sample listed within the `package.json` file).|
## Package contents
The following table describes the package folder structure:
|**Location**|**Description**|
|---|---|
|`Tests/ContentPacks`|Contains the **Test** product, and TestPacks used for manual testing.|
|`Tests/Editor/ContentManagerTests`|Contains the code for the **TestAddRemoveContent** test.|
## Requirements
This version of Unity Content Manager is compatible with the following versions of the Unity Editor:
*   2019.4 and later
## Known limitations
*   After you uninstall an embedded package, you must remove it manually from the `Packages` folder.
