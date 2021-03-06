### Module Loader

The module loader package enables multiple systems to coexist within a single project and interact with each other in a predictable, configurable way.  Packages that depend on it implement classes which extend `IModule` or some variant, which enables them to be loaded and unloaded in the Editor and at Runtime in a configurable order, and connect to each other in a systematic, predictable fashion. Included in this package is the `FunctionalityInjectionModule` which enables packages to expose functionality to each other, or to user code, without directly referencing each other.

To access the module loader, go to 'Edit/Project Settings -> Module Loader', or select the `ModuleLoaderCore` asset in the Project Window.

You can un-check toggle fields here to turn off modules. Some toggles are disabled because other enabled modules depend on them via `IModuleDependency`. As you disable modules, you will be able to disable more and more modules as you go. It is possible to create cyclic dependencies which results in a group of modules which can never be disabled. It is best to avoid this situation, but if it occurs, and these modules _must_ be disabled, it is possible to add the class names to the list of excluded modules manually by modifying the `ModuleLoaderCore.asset` file. The foldout for each module row contains a list of Dependencies and Dependent models for more information about what modules depend on each other. The Functionality Injection Module is decorated by the `ImmortalModule` attribute and cannot be disabled.

Below the Enabled Modules UI is a series of read-only lists which display the various module orders. Load and Unload should contain all modules, but the callback orders only apply to modules which implement those specific interfaces.

See the Module Loader package for further documentation.


#### Reload Modules

`ReloadModules()` does what it says on the tin. It is useful in editor tools, in case you find yourself in an unrecoverable state. It is a convenience we have added for development use to avoid having to restart the Unity Editor in order to reset the state of editor tools.

To reload modules, click the 'Reload Modules' button in the `ModuleLoaderCore` settings.


## Architecture
The architecture is a classic hub-and-spoke model. As you may notice, the modules themselves can reference each other via `IModuleDependency`, but the goal is to keep the modules as self-contained as possible, so that they can be added/removed/shared easily. When modules do inevitably have dependencies, they should be very clearly identified by the class definition. The nice thing about `IModuleDependency` is that its generic argument tells you exactly what class is being referenced.

## Module Loader Class
The "hub" is the `ModuleLoader` class which defines the entry point of your application/extension. It is only responsible for loading, unloading, and supporting the functionality of modules.

The loader allows control of the order in which modules are initialized. The `IModuleBehaviorCallbacks` interface which lets modules subscribe to MonoBehaviour Awake/Enable/Update/etc. callbacks, and provides an attribute to specify in which part of the order your module should get its methods called, similar to ScriptExecutionOrder. We do the same for scene load/unload and other Editor callbacks so that modules can "wait" for other modules to do their lifecyle event, or respond to a given callback, first and then act after. This callback order is implemented by simply sorting the modules into a number of lists based on their type, and iterating through those lists in order when executing the methods.

A planned improvement to ModuleLoader will allow users to serialize project-specific profiles for custom module load and callback orders.

## Modules
Modules are where your actual application code should reside. Try to keep them as small and single-purpose as possible. Consider the Unix philosophy, where programs should "do one thing and do it well." There will inevitably be need for "manager" code that utilizes a number of modules to do a complex task, but it can also be a module which implements IModuleDependency a number of times with the individual dependencies it relies upon. The reason to use `IModuleDependency` instead of just calling GetModule on the loader to get dependencies is to explicitly declare that these modules depend on each other for readability. Of course, the method of hooking up dependencies before load is also slightly faster than having to search for dependencies in the load method, and also provides interesting opportunities to do some logic inside `ConnectDependency`. Combined with a compiler define to only include the implementation of `IModuleDependency` when the other module exists, we have a basic system for supporting optional dependencies.

## Loading Modules
`ModuleLoader.LoadModules` uses reflection to find all classes that implement `IModule` (excluding those with "test" in the name) and tries to load them. If your class exists in any loaded assembly and implements IModule, it will be loaded. Because of the restrictions around creating certain types of objects, we have a few different ways to initialize modules. Once all modules are initialized, we call `LoadModule` on them in the order determined by the `ModuleOrder` attribute.

### Vanilla class modules
The simplest possible module (`VanillaModule` in this repo) is a C# class that implements `IModule`. It will be initialized by calling `Activator.CreateInstance` on its type.

### MonoBehaviour modules
Because we cannot call the constructor on a MonoBehaviour, and it wants to be a component on a GameObject, we special-case classes that inherit from `MonoBehaviour` and implement `IModule`. For every `IModule` type we encounter that inherits from `MonoBehaviour`, we create a new gameobject and add a new component with that type. We do not record undo on this object, and apply the default HideFlags specified in `ModuleLoaderUserSettings`. Users can modify the default HideFlags to see these modules get added and removed from the scene and inspect their state. We have found that this is generally helpful in debugging module setup or other issues during development, but likely shouldn't be exposed to users as a part of "normal" workflow. Unfortunately, hideflags will alter the behavior of your modules. For example, modules with HideAndDontSave hideflags will not get their Awake and OnDestroy methods called when entering and exiting play mode. However those methods _do_ get called when hideflags are set to None. Bear this in mind when setting up your systems, and make sure that you always test things in the final state that you will deliver to users. You will likely want to use `IModuleBehaviorCallbacks` to respond to these callbacks, since they will be called consistently regardless of the default HideFlags.

### ScriptableSettings modules
Modules often want to store settings or other data persistently. One reason would be to save the data to disk so it can survive restarting the editor or be built into players. Another would be to survive domain reload. In both of these cases, we need to be able to get to that serialized data on load, which means that a regular `ScriptableObject` doesn't quite cut it. The `ScriptableSettings` class adds some extra logic around `ScriptableObject` to provide static access to a single instance of the ScriptableObject and always save/load it from the same asset. We do our best to ensure that there is only one of these assets in your project, and set one up for you automatically in a customizable path. There is also an editor-only `EditorScriptableSettings` type which you can inherit from if your module lives in the Editor assembly and its asset should not be included in builds. This is helpful if you need to reference GUI or other assets that would unnecessarily bloat your runtime builds.

Both `ScriptableSettings` and `EditorScriptableSettings` are initialized by accessing their static instance property via reflection. This will create an instance by loading the asset, or access an existing instance if something has already accessed the instance property. It will also call the OnLoaded method as normal. `ScriptableSettings` modules should still use the `LoadModule` method to initialize if they need to take advantage of module order. Modules are only loaded in order--their instances are created in an order determined by the list of types returned by Reflection.

## Interfaces
The interfaces for modules and Functionality Injection are in their own assembly. This is intended to provide a single, minimal public API surface for integration with other code. As more packages use FunctionalityInjection and this package, we will probably have to extract the common interfaces into a shared set, but for now the plan is to keep everything namespaced on a per-project basis and allow for customization of Functionality Injection within each.

## Functionality Injection
Functionality Injection is an Inversion of Control (IoC) pattern intended to expose public APIs via interface, rather than static methods. You can read more about it in its own [documentation](https://docs.google.com/document/d/11W-RWHVOTphBgtvi38gktCPh4jo8SOPKafWxKNjKoqM)

### When to use a Module vs. a Provider
Functionality providers can be modules, or they can be picked up by the Functionality Injection Module. What is the difference? The intent of modules is that they are _part of a larger whole_. This means that they all live and die together with the "entire application," whether that's just an editor extension or a full game project. The point of using a modular architecture is to avoid a situation where you have one giant class for all of your app code, and to allow core features to be easily added/removed and shared between projects. However, if the lifecycle of your object is more situation-dependant, or you have a situation where two different providers can't co-exist because they, for example, require exclusive access to hardware, you don't want to use a module. If something is fundamental to your experience, then it should be a module which you can treat as "always available."
