# Traits

A Trait in Unity MARS is a semantically meaningful piece of data. Traits have a name and a data type. When Proxies match themselves to real-world objects, Unity MARS defines the match by ensuring that the object has a defined property and that its value is in a given range. You can add custom data to the MARS Database as traits added to entities, and then create Proxies that require those traits. You can also use a [MARS Reasoning API](SoftwareDevelopmentGuide.md#reasoning-apis) to automatically add traits to existing entities.

## Semantic tags

Semantic tags are a specific type of trait which tags data with a descriptive label. The "plane" trait is a semantic tag and labels data as an AR plane. Semantic tag traits have a `bool` value which must be true for the tag to have an effect. You can set the `SemanticTagCondition` to **Match** or **Exclude** the tag. **Match** means that the data must include the given semantic tag trait for a successful match. **Exclude** means that the Proxy only matches if the data does _not_ include the tag.

## Standard traits

Unity MARS includes many common traits (listed below). You can add your own custom types to the database.

| Trait | Type | Notes |
| ----- | ---- | ----- |
| pose | Pose | position and rotation |
| alignment | MarsPlaneAlignment | vertical/horizontal/none |
| bounds2d | Vector2 | extents of available 2D space |
| markerid | string | id of this marker |
| geolocation | GeographicCoordinate | latitude and longitude of geographic location |
| environment |  bool | is this the user's immediate environment |
| face |  bool | is this a face |
| inView | bool | is this in view |
| marker | bool | is this a marker |
| plane | bool | is this a plane |
| point | bool | is this a point |
| user | bool | is this a user |
| body | bool | is this a body |

## Adding trait requirements to Proxies

To add a trait requirement to a Proxy, click the **Add MARS Component** button, then select **Condition &gt; Semantic Tag** or **Trait** and select the tag or trait you want your Proxy to require.

![Adding traits to a Proxy](images/Traits/adding-traits.png)

## Adding trait requirements via scripts

In code, you can use the `IRequiresTraits<T>` interface to request and access those traits in matching data objects. Any requirements that actions specify have the resulting value for the trait put into the appropriate dictionary in the `QueryResult`, where actions can then access them to do their work. If the trait is optional, the action doesn't prevent a Proxy without that trait from matching. For more information about actions, see [Writing Actions](./SoftwareDevelopmentGuide.md#writing-actions).

To define a trait requirement, use a `TraitDefinition` and specify whether it's optional or not. By default, trait requirements are not optional. For example:

```
var nonOptionalRequirement = new TraitRequirement(TraitDefinitions.Pose);
var optionalRequirement = new TraitRequirement(TraitDefinitions.Bounds2D, false);
```

## Providing traits via scripts

Classes that implement `IProvidesTraits<T>` have access to the extension method `AddOrUpdateTrait(int dataID, string traitName, T value)` that you can use to associate traits with particular data IDs. To create a data ID in the first place, use `AddOrUpdateData`, which comes from `IUsesMARSTrackableData`.

Classes that implement `IRequiresTraits `have access to the extension method `TryGetTraitValue`.

You can perform Create, Update, and Delete operations on any trait in the system. For more information, see documentation on [Reasoning APIs](./SoftwareDevelopmentGuide.md#writing-reasoning-apis).

## Custom trait types

It's possible to use your own data types as a trait value.  

Trait types must be a _struct_, not a class (except for strings). This is because a trait should be a _property_ of a single entity (like a surface or face) and not a reference to another object. They also should only have other value types as fields, not reference types.

### Example

Here's what a simple custom trait type representing the lighting estimate for a surface might look like.

in `SurfaceLightTrait.cs`:

```csharp
public struct SurfaceLightTrait
{
    public float Confidence;
    public float SurfaceBrightnessEstimate;
}
```

Plus, a condition that uses that surface lighting data type.  

Writing a `Condition` or `Relation` that uses your type is how Unity MARS knows that you want to use it as a trait.

in `SurfaceBrightnessCondition.cs`:
```csharp
public class SurfaceBrightnessCondition : Condition<SurfaceLightTrait>
{
    public override float RateDataMatch(ref SurfaceLightTrait data)
    {
        // Here you would have real rating logic, this is just a stub
        return data.Confidence - 0.5f;
    }

    static readonly TraitRequirement[] k_RequiredTraits = { new TraitRequirement("surfaceBrightness", typeof(SurfaceLightTrait)) };
    public override TraitRequirement[] GetRequiredTraits() => k_RequiredTraits;
```

### Adding your type

For Unity MARS to use your type as a trait, it must compile your type into its assembly and generate some code.  

To make that happen, move the file containing only your data type (`SurfaceLightTrait.cs` in the above example) into the `Assets/MARS/Extension Types` folder.  A recompile will happen, and then your trait type is ready to use.

If you've already written a `Condition` or `Relation` that uses your data type, but it's not in the extension types folder, MARS will detect this and log a message in the console reminding you to move the data type's file.
