# Unity Content Manager

The Content Manager shows samples, extension packages, and other pieces of content available for a product. It is  built on top of package-manager.

It specializes in configuring and extending a project after it has been created. 

It streamlines various types of sample installation, and gracefully handles advanced use-cases like soft dependencies.

## Using the Unity Content Manager

Open the Content Manager in Window->Content Manager.

Supported products will appear in the top-left corner of the Content Manager window.

Select different categories to see which content packs are available to install.

They can install as packages, embedded packages (writable), and directly into the project.

## Deploying your own content with the Content Manager

The Content Manager displays Content Packs found under the search path of the corresponding Content Product.

*Create a Content Product*
* Create->Content Manager->Product
* Add a 48 x 48 icon
* Fill in Name and Descrpition
* Fill in the search path. Note for packages your search path will start with 'Packages/'
* Check 'visible' to make it appear in the Content Manager
* Fill in the categories field if you expect to have a wide variety of content that will need to be filtered down

Once a product has been created, you can create content packs. Content packs are custom references to package manager packages.

*Create a Content Pack*
* Create->Content Manager->Content Pack
* Fill in the fields

Notes on Content Packs
* Package name must match the package name in your content's package.json file
* Url can use any valid packman API reference. You can reference package names to link to the Unity registry directly. 
* Use 'Packages/[Your package name]/~[Some Content Path]' to reference internal packages. Look at the test packs for an example of this.
* Install type has three values
** Package is a typical package installation
** Writable package does a combination of Package installation + Package embedding to make the content writable
** Unitypackage does a combination of Package installation + automatic installation of the first sample content available.  It is expected in this case that your content sample is stored with a .unitypackage file. Look at TestPack_UnityPackage for an example of this.
