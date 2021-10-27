# Software development guide

This guide describes how to extend Unity MARS or develop custom behaviors specific to your app. It covers how different MARS subsystems work, and offers some examples that can help you start expanding it to better suit your needs.

## Package contents

Unity MARS is a package that contains the following folders:

|Location|Description|
|---|---|
|`Editor`|Unity Editor scripts that add or modify the 2D editor UI.|
|`Interfaces`|Interface scripts necessary to write extensions to Unity MARS.|
|`Runtime`|The core Unity MARS runtime systems.|
|`Tests`|Unit tests.|
|`Videos`|Sample video files to use for testing.|

Unity MARS has the following package dependencies:
- `com.unity.xrtools.module-loader`
- `com.unity.xrtools.utils`
- `com.unity.textmeshpro`
- `com.unity.timeline`

## Software developer topics

This section covers advanced topics. It is aimed at developers who need direct access to these portions of Unity MARS for special cases, such as default providers.

### Generate all .csproj files
When you write code that references the `Unity.MARS` assembly, you need to enable the **Generate all .csproj files** option under **Preferences &gt; External Tools**. Unity MARS includes generated code that is compiled into the `Unity.MARS` assembly using an Assembly Definition Reference in `Assets/MARS/Generated`. By default, Unity does not generate `.csproj` files for package assemblies, but because of this `.asmref` in Assets, it does generate one for `Unity.MARS`. Unfortunately, this project does not reference any of the code in the MARS package, so most types in this assembly will appear to be missing. With the **Generate all .csproj files** option, Unity will generate a project for the main `Unity.MARS` assembly and your IDE will work as expected when working with MARS code.

Note that this setting affects all Unity projects for the current user.

Unity recommends that users update to the latest version of the integration package for their IDE, for example `com.unity.ide.rider`, when working with Unity MARS. In later versions, the option for generating additional project files is broken down by package type. In this case, ensure that `Registry packages` is enabled.

### MARS Session

The MARS Session component serves multiple purposes in a MARS Scene. Unity MARS primarily uses the MARS Session component itself to store Scene metadata like the list of required traits, and automatically populates this component based on the traits required by entities in your Scene. As you make changes, the MARS Editor extension analyzes your Scene and adds or removes traits from the Requirements list on the MARS Session. You cannot edit this list.

The MARS Editor extension ensures that the MARS Session exists and is the parent of the Main Camera whenever MARS Entities exist in the active Scene. When you add the first MARS Entity to a Scene, a MARS Session is automatically added as well.

If you already have a camera in your Scene, this becomes a child of the MARS Session GameObject, and a MARSCamera script is added to it. If you don't have a camera in your Scene, MARS creates one for you. If you try to delete the MARS Session or camera, MARS automatically recreates it. The automatically generated MARS Session also adds a User GameObject which synthesizes a pose for the camera position; this allows queries in the Scene to relate to the user. You can safely delete the User GameObject if you don't need it.

To prevent this behavior, from Unity's main menu, go to **Project Settings &gt; MARS &gt; Scene Tracking &gt; Scene Module** and enable the **Block Ensure Session** option. MARS saves this setting to the project. This setting also affects the "ensure session" behavior at runtime. This option is exposed to scripts via the public property `MARSSceneModule.BlockEnsureSession`. You can enable it temporarily to make modifications to the session hierarchy or create Proxies at runtime without starting up MARS automatically.

MARS turns the camera GameObject into a child of the MARS Session GameObject in order to support the MARS World Scale feature. Systems in MARS always expect the camera to have a parent, which simplifies code complexity in cases where you need to get/set the world scale or camera offset.

You can set a per-Scene functionality island override in the MARS Session component's Inspector. This indicates that Scene has an alternative provider set from the global Default Functionality Island. This field is optional, and in most cases you should leave it empty.

![](images/SoftwareDevelopmentGuide/mars-session.png)

### Functionality Injection

Functionality Injection is an integration pattern that gives generic access to a wide variety of data provider packages. A pair of C# interfaces define the API for a given feature. One has a name beginning with `IProvides`, and defines methods or events that a data provider class must implement in order for Unity MARS to use them. The other interface, the name of which always begins with `IUses`, is implemented by classes that need access to the provider methods. The goal is to make it as easy as possible to add extra functionality to user scripts. You can add/remove a subscriber interface without changing anything else in your class.

For more information, see [Functionality Injection Explained](https://docs.google.com/document/d/11W-RWHVOTphBgtvi38gktCPh4jo8SOPKafWxKNjKoqM/edit) on Google Docs.

### Functionality islands

The Functionality Injection Module (FI Module) manages functionality islands. To ensure that all modules that provide functionality can be added to all islands, all islands must be added to the FI Module before modules finish loading. Unity MARS assumes that the modules are always accessible. If you're using an island that hasn't been set up, or if you try to set up an island too late in the workflow, MARS generates a warning. This ensures that you don't receive any confusing errors later on. In most cases, you don't need to write code that manipulates islands; instead, you set the Island reference on the MARS Session GameObject in the Scene, or use the active island to inject functionality into GameObjects.

The active island is set in MARSSceneModule on Scene start, based on the override set in MARSSession. If no override is set, the active island is always the default island. Islands hold serialized references to a list of default providers. These serialized settings define configuration-specific defaults for when you set up the Scene. The `FunctionalityIsland.SetupDefaultProviders()` method is responsible for this step. MARSSceneModule calls this method when the Scene starts.

The defaults contained in functionality islands factor into provider selection. Create and modify functionality island Assets to control what providers are used in which Scenes and on which platforms. If your Project only has one provider for a given provider type, you don't need to create defaults unless the provider requires a prefab.

To set up a default, navigate to the functionality island's Inspector window and follow these steps:

1. Add a new row in the **Default Providers** list.
2. Choose the provider interface that needs a default.
3. Either choose the default provider type, or set a Prefab reference for that provider.

When you add a Prefab, all provider components within that Prefab are used, if required. You don't need to specify the Prefab for each provider type you want to load. If you do need to specify your Prefab twice (which can happen in certain overlapping situations), it is only instanced once, and the same instance is re-used when MARS processes the next row that contains it.

### Module Loader
The Module Loader package (`com.unity.xrtools.module-loader`) enables multiple systems to coexist within a single Project and interact with each other. Packages that depend on it implement classes that extend `IModule` or some variant which enables them to be loaded and unloaded in the Editor and at runtime in a configurable order, as well as connect in a systematic, predictable way. This package includes the Functionality Injection Module, which enables packages to expose functionality to each other, or user code, without directly referencing each other.

You can access the Module Loader in two ways:

* From Unity's main menu, go to **Edit &gt; Project Settings**, then select the **Module Loader** tab.
* Select the ModuleLoaderCore Asset in your Project.

You can toggle parts of Unity MARS on or off here. Some toggles are disabled because other enabled modules depend on them. Because of cyclic dependencies, you can't turn off all of MARS at once. When you disable a module, you can also disable the modules that depend on it. See the Dependencies and Dependent models to get more information about which modules depend on each other. Example modules are disabled by default and might cause issues if you enable them. The Functionality Injection Module can't be disabled.

Below the Enabled Modules UI is a series of read-only lists that display the various module orders. Load and Unload should contain all modules, but the callback orders only apply to modules that implement those specific interfaces.

For more information, see Module Loader package documentation.

#### Reload Modules

If you need to reset the state of Unity MARS systems, you don't need to restart the Unity Editor. You can use Reload Modules to only restart the MARS Editor extension. To do that, go to the module loader, and click **Reload Modules**.

### MARS Database
Unity MARS is built on top of a flexible database layer. This layer is built up at runtime and consists of built-in types that MARS supports natively, along with any new custom types added by providers or user scripts.

In the database, observations about the world are broken down into data, which consists of single variables of any type, and described with a trait, which is a string identifier for the data. Some data and traits are passive (for example, semantic tags, like labeling a plane as a 'wall' or 'floor'). Others are active (for example, the pose of a face is an active trait with a value that is constantly changing).

The following three classes access the MARS database:

#### MARSBackend (read)

These are queries to find a matching piece of data (or set of data in the case of Proxy Groups) and return this data to the class or functions that asked for it.

#### Synthetic objects (write)

Components placed on GameObjects that consist of synthetic objects and synthetic traits. When these GameObjects are active, they write data back into the MARS Database. This is the mechanism used to make simulated environments interact with Unity MARS the same way a real-world environment does.

Synthetic data allows many different types of conditions to funnel down into a single design-friendly semantic piece of data to author against. Synthetic data in a Replicated Proxy or Proxy Group is essentially a visually authored Reasoning API. You can also use it to mark key locations or data in user-authored content, such as good locations for spawn points, landmark points or edges in digital environments, or spaces to connect bridges. This data can then be used/reserved in further Proxies or Proxy Groups, therefore allowing many different pieces of content or environment types to interact with one another with a simple, flat hierarchy.

#### Reasoning APIs (read and write)

A Reasoning API is a set of advanced scripts and systems that examine the state of the database to make new semantic interfaces or create additional data. For more information, see the [Reasoning APIs](#reasoning-apis) section on this page.

### Queries

This is the method to address data in the MARS Database. You don’t make queries directly, but rather construct objects that do that. Queries are made of from conditions that must be matched, and actions to take when matching data is found.

Beyond conditions, queries have two extra configuration options: common query data, and exclusivity.

#### Common query data

The following parameters relate to how the MARS backend manages the query. Regular queries and Proxy Group queries use these parameters.

|**Parameter**|**Definition**|
|---|---|
|**Time Out**|Specifies how much time the query has to find a match before it stops trying.|
|**Update Match Interval**|Specifies how often to check for updates to the query's match.|
|**Reacquire on Loss**|Specifies whether the query tries to find another match when a condition no longer matches.|

#### Exclusivity

This controls whether other queries can read data that has already been matched. Exclusivity can also be read-only, which allows for matches with all data but shouldn't interfere with the application’s visual flow. For example, if you have two proxies that look like a table, your app detects the first one and places content on it, then ignores the second one.

### Proxy Group queries

The term ‘query’ typically refers to a query for a collection of data on one Proxy (such as one table, or one floor plane). Proxy Group queries reference multiple regular queries, along with a series of relations that must match between each Proxy.

#### Required child Proxies

You mark each child Proxy in a ProxyGroup as either required or not required. All child Proxies, whether required or not, must match for the Proxy Group to initially match. If a required child Proxy's condition or a relation involving the child Proxy no longer matches, the entire Proxy Group loses its match. However, if a non-required child Proxy is lost, the Proxy Group continues to use its other child Proxies' matching data.

### Writing Conditions

A Condition component on a Proxy defines a trait (and, optionally, a value range) that is tested for a match with data in the MARS Database. Unity MARS includes a number of these scripts for common use cases and provides an API for you to write your own.

All conditions operate on a single type of data filtered in the database with a trait name.

To write a condition, follow these steps:

1. Create a new script with the following template:
   ```
   public class _ConditionName_Condition : Condition<_dataType_>
   {
     static readonly TraitRequirement[] k_RequiredTraits = { _TraitDefinition_ };

     public override TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

     public override float RateDataMatch(ref _dataType_ data)
   }
   ```

2. Fill in the `k_RequiredTraits` field and `RateDataMatch()` method.

3. The `k_RequiredTraits` array must contain exactly one `TraitRequirement`, which should be the definition of the trait that this condition operates on.

4. The `RateDataMatch()` method takes in a single element of your specified dataType, and returns a number in the range of 0-1 that indicates how well it matches the condition (where 0 is no match and 1 is a perfect match). This corresponds to one entry at a time in the MARS Database that is being tested.

Conditions only operate on one trait and setup at a time. You can have multiple conditions on a single object. This is the recommended workflow. If your condition needs to be aware of more data at once, use MultiConditions.

### Writing MultiConditions

A MultiCondition component on a Proxy defines multiple traits that are tested for a match with data in the MARS Database. Unity MARS includes a few of these scripts for common use cases and provides an API for you to write your own.

To write a MultiCondition, follow these steps:

1. Create a new script with the following template:
   ```
   public class _MultiConditionName_Condition : MultiCondition<_conditionType1_,_conditionType2_>
   {
       [System.Serializable]
       public class _conditionType1_ : SubCondition, ICondition<_dataType_>
       {
           static readonly TraitRequirement[] k_RequiredTraits = { _TraitDefinition_ };

           public string traitName { get { return k_RequiredTraits[0].TraitName; } }

           public TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

           public float RateDataMatch(ref _dataType_ data) { }
       }

       [System.Serializable]
       public class _conditionType2_ : SubCondition, ICondition<_dataType_>
       {
           static readonly TraitRequirement[] k_RequiredTraits = { _TraitDefinition_ };

           public string traitName { get { return k_RequiredTraits[0].TraitName; } }

           public TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

           public float RateDataMatch(ref _dataType_ data) { }
       }
   }
   ```
2. Fill in the `k_RequiredTraits` field and `RateDataMatch` method for each SubCondition.

3. If you need an [OnValidate](https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnValidate.html) method for the SubConditions, it should be implemented for both in the outer class.

### Writing Relations

A Relation component on a ProxyGroup defines a trait (and, optionally, a value range) that is tested for a match with data in the MARS Database. Unity MARS includes a number of these scripts for common use cases and provides an API for you to write your own.

To write a Relation, follow these steps:

1. Create a new script with the following template:
   ```
   public class _RelationName_Relation : Relation<_dataType_>
   {
     static readonly TraitRequirement[] k_RequiredTraits = { _child1TraitDefinition_, _child2TraitDefinition_ };

     public override TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

     public override float RateDataMatch(ref _dataType_ child1Data, ref _dataType_ child2Data) { }
   }
   ```

2. Fill in the `k_RequiredTraits` field and `RateDataMatch()` method.

3. The `k_RequiredTraits` array must contain exactly two `TraitRequirement`s. The first entry should be the definition of the trait used for the first child, and the second entry should be the trait used for the second child.

3. The `RateDataMatch` method takes in two elements of your specified dataType. This corresponds to a pair of contexts in the MARS Database that are being tested at the same time. In general, relations only check one property and setup at a time.

### Writing MultiRelations

A MultiRelation component on a ProxyGroup defines multiple relations between two Proxies within the group, each of which is tested for a match. Unity MARS includes one of these scripts as an example and provides an API for you to write your own.

To write a MultiRelation, follow these steps:

1. Create a new script with the following template:
   ```
   public class _MultiRelationName_ : MultiRelation<_relationType1_,_relationType2_>
   {
       [System.Serializable]
       public class _relationType1_ : SubRelation, IRelation<_dataType_>
       {
           static readonly TraitRequirement[] k_RequiredTraits = { _child1TraitDefinition_, _child2TraitDefinition_ };

           public string child1TraitName { get { return k_RequiredTraits[0].TraitName; } }
           public string child2TraitName { get { return k_RequiredTraits[1].TraitName; } }

           public TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

           public float RateDataMatch(ref _dataType_ child1Data, ref _dataType_ child2Data) { }
       }

       [System.Serializable]
       public class _relationType2_ : SubRelation, IRelation<_dataType_>
       {
           static readonly TraitRequirement[] k_RequiredTraits = { _child1TraitDefinition_, _child2TraitDefinition_ };

           public string child1TraitName { get { return k_RequiredTraits[0].TraitName; } }
           public string child2TraitName { get { return k_RequiredTraits[1].TraitName; } }

           public TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

           public float RateDataMatch(ref _dataType_ child1Data, ref _dataType_ child2Data) { }
       }
   }
   ```

2. Fill in the `k_RequiredTraits` field and `RateDataMatch` method for each SubRelation.

3. If you need an [OnValidate](https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnValidate.html) method for the SubRelations, it should be implemented for both in the outer class.

### Writing Actions

Actions translate changes in the Database into changes in your Unity Scene as AR lifecycle events. To create these components, you write code that implements an interface for an Action or ProxyGroup Action. You can apply an Action component to a Proxy, or a ProxyGroup Action component to a ProxyGroup.

Applicable AR lifecycle events are:

* **Acquire**: Triggers when matching real-world data is first found and applied.
* **Update**: Triggers at a specified interval when matched real-world data changes.
* **Timeout**: Triggers if a specific set of conditions is not found in a given time frame.
* **Loss**: Triggers if a matched set of real-world data changes so much that it no longer satisfies the given conditions.

To write an Action, follow these steps:

1. Create a new script with the following template:
   ```
   public class _ActionName_Action : MonoBehaviour, IMatchAcquireHandler, IMatchUpdateHandler, IMatchLossHandler, IMatchTimeoutHandler, IRequiresTraits
   {
     static readonly TraitRequirement[] k_RequiredTraits;

     public void OnMatchAcquire(QueryResult queryResult) {}

     public void OnMatchUpdate(QueryResult queryResult) {}

     public void OnMatchLoss(QueryResult queryResult) {}

     public void OnMatchTimeout(QueryArgs queryArgs) {}

     public TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }
   }
   ```

2. For each AR lifecycle event you want to respond to (acquire, update, timeout, and loss), add the appropriate interface and fill in the corresponding function.

3. The QueryResult contains at least the data required by the object’s conditions. It can also contain other data, and you can check if such data exists. You can choose whether a certain action must occur on a matching option, or if this action is optional.

4. `k_RequiredTraits` should contain all the traits this Action requires to operate. For an example, see the `SetAlignedPoseAction` class. For more information about traits and how to require them, see documentation on [Traits](./Traits.md).

### Populating the MARSEntity Inspector with your classes

New Actions and conditions that you write appear in the MARS Entity Inspector UI, under **Add MARS Component &gt; Action/Condition &gt; Other**, and automatically take on the stacked Inspector style. You can provide a custom menu path for them; to do this, add the `MonoBehaviorComponentMenu` attribute to your class, like this:
```
[MonoBehaviourComponentMenu(typeof(_YourAction_), "Action/_YourActionPath_")]
```

### Synthetic data

MARS Proxies are referenced through building up a list of required data with conditions. The Synthetic Data system mirrors this. It decorates GameObjects and traditional content with synthetic components that collect and add these properties into the MARS Database. Synthetic data can even act as a visual interface for many reasoning API-like activities. Most advanced world-decorating workflows rely on this system.

To use synthetic data, follow these steps:

1. Create or locate a GameObject you would like to mirror in the MARS Database. This can be a child GameObject of a Proxy GameObject if you are decorating existing AR data with more semantic information, or a GameObject at the root level if you are working on a purely simulated piece of data.

2. Add the ‘SynthesizedObject’ component.

3. Add any number of **Synthesized Traits** or **Synthesized Data** components. Each of these mirrors a different aspect of the GameObject into the MARS Database.


4. At runtime or simulation time, MARS adds or removes Synthesized Objects at the root level as they are enabled or disabled. Synthesized Objects that are children of a MARSEntity are added or removed from the database when the parent is acquired or lost.
5. Certain traits, such as those based on position, update their value when the transform of the SynthesizedObject changes. The update AR lifecycle method also triggers an update of the SynthesizedObject’s values.

#### Writing a SynthesizedTrait

To write a SynthesizedTrait, follow these steps:

1. Create a script with the following template:

   ```
   public class Synthesized_TraitName_ : SynthesizedTrait<_DataType_>
   {
     public override string TraitName { get; }

     public override bool UpdateWithTransform { get; }

     public override _DataType _GetTraitData()
   }
   ```

2. Fill in the method above.

3. Add it to the desired SynthesizedObject as you would any other SynthesizedTrait.

### Reasoning APIs

Unity MARS is based on the concept of richly-decorated AR Scenes; for example, Scenes that consist of a plane labeled as ‘floor’, a bounding volume labeled as furniture and with an attached light value, and many other labeled elements. Most providers today only offer a single type of data at a time, such as a plane or a face, without this rich data.

Reasoning APIs fill this gap and take full advantage of your AR hardware/software stack. To do this, they create or mutate data in the MARS Database. They can look at all the different pieces of data in the database at once, and correlate different data sets together, or make extra inferences based on existing data.

The package comes with an example reasoning API which labels the floor plane. This unlocks powerful functionality for phone-based AR.

#### Selection criteria for Reasoning APIs

Reasoning APIs are selected and run based on the following criteria:

1. Does the data it needs to run exist? For example, the Floor reasoning API needs planes to already exist in the database, so it can examine them and infer which one is likely correlated to the floor plane.

2. Does the app require the data the Reasoning API provides?  For example, if an app designed in Unity MARS does not make use of any conditions requiring a floor trait, the Floor Reasoning API doesn't run (even though it can), because it has no reason to run.

3. Does the data this reasoning API provides come from another source? For example, a user might run a MARS app on a piece of AR hardware that offers semantically labeled planes. These are already getting added into the database with the ‘floor’ label. In this case, the Floor Reasoning API doesn't run, because it can't add anything new.

#### Writing Reasoning APIs

A reasoning API starts as a script with this template:
   ```
   [CreateAssetMenu(menuName = “Mars/_Name_ ReasoningAPI”)]
   public class _Name_ReasoningAPI : ScriptableObject, IReasoningAPI
   {
      static readonly TraitDefinition[] k_ProvidedTraits;
      static readonly TraitRequirement[] k_RequiredTraits;

      public float processSceneInterval { get; }

      public TraitDefinition[] GetProvidedTraits() { return k_ProvidedTraits; }

      public TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

      public void Setup()

      public void TearDown()

      public void ProcessScene()

      public void UpdateData()
   }
   ```

This template consists of the following parts:

* `k_ProvidedTraits` is the array of traits that this reasoning API adds to an active MARS Scene.
* `k_RequiredTraits` is the array of traits that must exist in the database in order for the reasoning API to run.
* `Setup()` performs a one-time setup for acquiring references to the database and its content.
* `TearDown()` frees the resources set up in the `Setup()` method.
* `ProcessScene()` is a method that is called on a frequent (but not per-frame) interval, for resource-intensive operations.
* `UpdateData()` is a per-frame method that is called to make sure that data created or altered by the Reasoning API stays up to date with the Scene.

Once you've created your Reasoning API, you can start using it. Follow these steps:

1. Add data into the Reasoning API. To do this, add the `IProvidesTraits<T>`, `IRequiresTraits<T>`, or `IUsesMARSData<T>` interfaces. These give you access to data in the MARS Database, and the ability to add, edit, and remove data in those database entries as well. The `GetCollection<T>` method provided by `IUsesMARSData` is particularly useful for getting all data in the database of a specific type.

2. Create an instance of the reasoning API in your Project. Right-click in the Project View and select **Create &gt; MARS &gt; _Name_ Reasoning API**.

3. Find the ReasoningModule GameObject in your Project and expand the **Reasoning APIs** section.

4. Add your Reasoning API to this array.

### Providers

#### How a provider is selected

Unity MARS apps are expected to have a wide variety of integrations. The Functionality Injection (FI) module and functionality islands handle many different scenarios, including:

* Having one, obvious choice for a particular type of functionality.
* Having several choices where you must specify the default for certain situations.
* Specifying exactly which providers are used in which situations, and for which GameObjects.

The Scene and Functionality Injection modules automatically load providers that:

* Match the subscriber interfaces on GameObjects in the Scene.
* Provide the traits required by conditions within the Scene.

Any Scene GameObjects that implement provider interfaces take precedence over providers in the active functionality island’s defaults. This way, you can make sure that the provider you need is present and running in the Scene. Scripts can set a different provider of the same type to the active island at runtime, but the standard behavior is that providers are set up at Scene load and stay the same throughout the run of the Scene.

When `InjectFunctionality` is called on a list of objects (for example, when setting up Simulation or setting up MARS at runtime), the system selects and initializes providers based on **functionality subscribers** in the Scene. The `ProviderSelectionOptions` attribute allows you to annotate their provider types with extra information. The first parameter is `Priority`, which you can use to "promote" or "demote" a provider in the provider selection process. If more than one type implements a certain provider interface, MARS selects the provider with the highest `Priority` value. If more than one provider type with the same `Priority` value exists, MARS chooses the first type in the list arbitrarily and logs a warning. The behavior, in this case, is undefined and can change unexpectedly.

When selecting providers based on **trait requirements** (generally done at the same time as subscriber requirements), the system first collects all providers which implement `IProvidesTraits` and provide at least one of the required traits. This is done by calling `RequireProvidersWithDefaultProviders`. If there is only one provider in the list, MARS selects it. Otherwise, this list of providers is then sorted by the number of traits the provider contains and the Scene requires (the "score"), in descending order. If two providers have an equal score, MARS checks if either one is a default provider in the functionality island and, if so, that provider takes precedence. If both providers are or aren't in the defaults list, MARS compares their priorities and sorts the types in descending order. If the first two providers in the list do not have an equal "score" and priority, MARS selects the first one. Otherwise, MARS still selects the first one but also logs a warning. The behavior, in this case, is undefined and can change unexpectedly.

You can use **functionality islands** to manually override provider selection. Adding a provider class or prefab to a functionality island does not guarantee that MARS will load it at runtime. The defaults only exist to disambiguate provider selection in SetupDefaultProviders. Functionality island defaults take precedence over `Priority` when selecting providers based on subscriber requirements. As explained above, defaults take precedence over `Priority` when selecting based on trait requirements, but are only taken into  account when providers have an equal "score." In all cases where more than one provider exists for a given provider type, you should make sure a default is set on the active island.

Generally, provider packages should provide example functionality island Assets as a starting point. In most cases, apps start with a foundational provider like the XRSDK provider package or a face tracker and add extra default providers to the included functionality islands as needed.

#### Elective Extensions

Elective Extensions runs when building for a configured build target (currently Android, iOS, and Lumin) and checks against a known good list of settings and package versions.

When building a project to different build targets, there might be situations where packages required for a build target are missing or incompatible with another build target. When building to a new build target for the first time, you might also overlook specific settings in Player Settings and elsewhere. To ease this process, when Elective Extensions detects a mismatch, it prints a warning to the console that contains the potential issue and suggestions for how to resolve it.

![](images/SoftwareDevelopmentGuide/elective-extensions.png)

You can adjust configuration files to suit your project requirements. These files are located in `com.unity.mars\Editor\Scripts\Build\ElectiveExtensionsConfiguration<platform name>.cs`

### Writing behaviors compatible with Simulation

Simulations in Unity MARS copy all GameObjects in the active Scene to a Simulation Scene and set the [`runInEditMode`](https://docs.unity3d.com/ScriptReference/MonoBehaviour-runInEditMode.html) property on copied `MonoBehaviour`s that implement the `ISimulatable` interface.

If you're writing a custom behavior that runs in Simulation, be aware of the following:

* The behavior must implement `ISimulatable` to receive `MonoBehaviour` callbacks during Simulation.
* If the behavior instantiates a GameObject, it should use `GameObjectUtils.Create` or `GameObjectUtils.Instantiate`. These utilities are wrappers for the `GameObject` constructor and `Object.Instantiate` respectively. When called during Simulation, the instantiated GameObject is added to the Simulation Scene and its `ISimulatable` behaviors run in Edit mode.
* If the behavior destroys a GameObject, it should use `UnityObjectUtils.Destroy`. This utility calls `Object.Destroy` when called in Play mode, or `Object.DestroyImmediate` when called in Edit mode.
* In some circumstances, simulated GameObjects persist between Simulations (rather than being destroyed and replaced with new copies). This means if a custom `ISimulatable` behavior changes any state for itself or another GameObject, it must reset that state in `OnDisable`. Also, if the behavior needs to perform any setup that should happen when Simulation starts, it must do so in `OnEnable`. `Awake` is only called the first time a behavior has `runInEditMode` set to `true`.

#### MARS Time
`MarsTime.Time` is the time that has passed since the start of the Unity MARS lifecycle (when the active MARS Session receives `OnEnable`). It ticks on a fixed time interval (`MarsTime.TimeStep`), and the `MarsTime.MarsUpdate` callback triggers after each tick.

`MarsTime.TimeScale` affects `MarsTime.Time`, but it does not affect `MarsTime.TimeStep`. This effectively means the number of `MarsUpdate`s per player loop update increases as `MarsTime.TimeScale` increases.

Because Simulation is capable of running at various time scales, core MARS systems and simulated data providers must use `MarsTime` properties and the `MarsUpdate` callback to ensure deterministic behavior. For some custom simulatable behaviors, it might be important that they also act deterministically regardless of time scale.

Such custom behaviors should use the MARS Time API and follow these guidelines:

* use `MarsTime.MarsUpdate` instead of `MonoBehaviour.Update`
* use `MarsTime.Time` instead of `Time.time`
* use `MarsTime.TimeStep` instead of `Time.deltaTime`
* use `MarsTime.FrameCount` instead of `Time.frameCount`
* use `MarsTime.TimeScale` instead of `Time.timeScale`

If you want a behavior to use `MonoBehaviour.Update` and still be compatible with time-scaled Simulation, you must factor `MarsTime.TimeScale` into time-based calculations by following these guidelines:
* use `MarsTime.Time` instead of `Time.time`
* use `MarsTime.ScaledDeltaTime` instead of `Time.deltaTime`

#### Finding the Camera
If you are getting a camera in an `ISimulatable`, you should use `MarsRuntimeUtils.GetActiveCamera()`, unless you need to serialize a direct reference to the Scene camera. Use the following methods for specific scenarios:

* `GetActiveCamera()` gets the active camera from the simulation when simulating, or the MARS Session camera when in Play mode.
* `MarsRuntimeUtils.GetSessionAssociatedCamera()` returns the active (`MARSSession.Instance`) MARSSession camera.

Both methods have the option to fall back to `Camera.main` or, if that is null, find any camera.

### MARS Editor Systems

#### Data visuals

Data visuals are Proxies created by hidden Replicators in the simulation. These objects are used by editor tools such as the [Create Tool](CreateTool.md) and [Compare Tool](CompareTool.md).

You can view the data visuals in the Content Scene Hierarchy panel by enabling the **Show Data Visuals In Hierarchy** option in **Project Settings &gt; MARS &gt; Editor Visuals &gt; Simulation Data Visuals**.

From the Project Settings, you can also toggle **Disable Simulation Data Visuals** to stop the data visuals from being generated when the simulation starts. Note that when Data Visuals are disabled, tools that rely on them will not work.  
