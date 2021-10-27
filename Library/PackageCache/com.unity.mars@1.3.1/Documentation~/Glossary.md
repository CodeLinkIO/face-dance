# Glossary

## Action

Actions are behaviors that execute when a [Proxy](#proxy) match occurs. They are a type of component (that you can write), and come in two varieties that can be placed on their corresponding GameObjects:
1. Actions for [Proxies](#proxy)
2. Actions for [Proxy Groups](#proxy-group)

Actions respond to a change in [QueryState](#query-state), such as a Proxy getting or losing matching data, or having its data updated.

## Application logic
Traditional scripts and components that interact with purely digital content, and don't take into account or interact with anything in the real world. Unity MARS doesn't provide scripts and utilities for application logic. You can add your own logic to existing Unity MARS functionality for your applications.

## Capability

Features that a given Scene requires. This includes whether the Scene requires cloud data, along with a list of [TraitRequirements](#trait-requirement) which specify features such as "Points in space", "GPS coordinates", "Models", "Planes", "Semantic Tags", "Voice Commands", and "Faces". Capabilities can be provided by hardware providers or synthetic data. For more information on hardware providers, see [Functionality Injection](#functionality-injection-fi).

<!-- ## Complexity
Refers to the minimum types of data needed to fulfill conditions required by proxies in a given Unity MARS Scene.
This is calculated implicitly from Unity MARS objects in the scene. -->

## Companion apps
Standalone executables for mobile phones and AR HMDs that allow you to do a subset of Unity MARS-related tasks on-location. These tasks include:

* Defining Proxies and conditions
* Capturing image markers and room plans
* Syncing project Assets and placing them in real-world spaces
* Recording AR data, camera tracking, and video, and syncing it back into Unity MARS

## Compare in Simulation View
Allows you to compare the results of whatever you've defined in the Inspector against the Simulation View. You enter Compare mode from a specific Proxy, hover over data (for example, surfaces) in the Simulation View, and see feedback in the Inspector about why the selected Proxy is not a match for the data you're currently hovering.

## Condition
A condition defines specific requirements on world data, such as plane size, alignment, or semantic tags (for example, 'face', 'floor', and future object classification tags). [Proxies](#proxy) often contain multiple conditions, where each condition describes a different individual requirement. For example, a 'large table' Proxy can have the conditions IsPlane, PlaneSize (large), and Alignment (Horizontal+Up). Unity MARS includes a number of Conditions for common use cases and provides an API for you to write your own Conditions.

## Data ID
A unique auto-incrementing number used to identify what [Proxy](#proxy) a piece of data is associated with. Every individual query has all of its result data supplied by the same Data ID.

For example, all semantic tags related to a given detected plane have the same data ID, because they are pieces of information about the same surface.

## Database
The central storage location for all the data recognized by Unity MARS. [Providers](#provider) and [Synthetic Objects](#synthetic-object) write data into the Database. [MARSEntities](#marsentity) read data from it, both to find data that matches their conditions and to run their Actions. The Database provides the means to search, update, and 'reserve' data so that two MARSEntities don't try to place content in the same area.

## Face tracking
Technology that tracks features of the human face. To enable face tracking in Unity MARS, use a face tracking provider. The provider inserts the face data into the database and then matches it with conditions. Unity MARS then accesses face tracking feature points as landmarks.

## Facial expressions
A single-value tag that corresponds to a concept that communicates a visual state, such as 'smile', 'shrug', 'mouth open', 'eyebrow raise', etc. Unity MARS currently calculates facial expressions in two ways:
* It observes visual landmarks in a video stream
* It analyzes blendshapes on a facial mesh

## Fallbacks
Fallbacks define what to do when Unity MARS can't find the requested Proxies. Fallbacks are a way to compartmentalize the problem you are trying to solve and make it easier to think about.

## Forces
Forces describe complex spatial alignment on Proxies (pose relative, edge/surface relative, occupancy relative, etc.). The name [Forces](Forces.md) refers to the fact that Unity MARS uses a physics-style simulation to balance out multiple influences as if they were springs around the Proxy GameObject.

## Functionality Injection (FI)

The main method by which pieces of Unity MARS are decoupled so that they don't depend on each other. [Modules](#module), components, and other Unity MARS features can either subscribe to, or provide, common sets of functionality. This is enabled by using pairs of interfaces that define the contract between a provider and its subscribers. These interfaces allow subscriber code to access features through a generic interface without knowing any implementation details of the hardware or the service providing them. It also allows for swapping providers at runtime. Functionality Injection provides a more code-oriented abstraction of AR data than the Database.

## Hardware provider
Code that wraps a hardware SDK or abstraction layer and feeds data into Unity MARS as a functionality provider. For example, the MARS AR Foundation Providers package inserts device data into the Database using AR Foundation.

## Head pose estimation
Technology used to determine where a head is located in the user's local coordinate frame, and which direction it is looking at. Depending on the provider, sometimes this data is exposed natively in 3D, and sometimes a 2D headpose is extracted and the 3D position must be calculated from that information.

## Integrations
External APIs and tools that provide functionality and support to Unity MARS. Providers are integrations (for example, ARCore and ARKit are providers that support platform-dependent localization and mapping for AR), but integrations can be more than just providers.

## Landmark
A named set of spatial or geometric data, such as a point, [pose](#pose), edge, spline, mesh, bounding region, eyes, nose, etc. Landmarks are very useful for positioning and alignment. In Unity MARS, Landmarks encapsulate the industry-standard Facial Landmark term.

## Live data
Live data is real-world data (as opposed to synthetic data) that's simultaneously happening in the real world and being processed by the computer. Live data can come from a feed, for example.

## MARSEntity
Base class for the three major constructs of Unity MARS: [Proxies](#proxy), [Proxy Groups](#proxy-group), and [Replicators](#replicator). This helps Unity create functionality, like data visualizers, that can apply to any type of Unity MARS GameObject.

## Match rating
A number between 0 (failing) and 1 (perfect) that indicates how well a data set matches user-authored conditions and relations. Unity MARS aggregates ratings for conditions and for the entire query to determine this.

Match ratings exist at several levels. For example:
- [Condition](#condition): How exact is this plane size match?
- [Query](#query): How well does this match all of this Proxy’s conditions combined?
- [Proxy Group](#proxy-group): How well do all members of a query set match?
- [Relation](#relation): How exact is this distance or elevation match?

## Module
Unity MARS is made up of separate pieces of major functionality - such as the Database, Functionality Injection, etc. - that don't depend on each other to work. These pieces of functionality are known as Modules.

## Pose
A pose is similar to Unity's Transform property, in that it describes position and orientation. However, poses don't contain scale information, so they need a unique identifier separate from Transform. For more information about why poses exclude scale, see [World Scale](#world-scale).

## Provider
Any external source of data for the MARS Database and AR Events in general. In this case, providers refer to the scripts that actually pipe this data source into Unity MARS.

## Proxy
A MARS Proxy is a component added to a GameObject to specify that it represents something that exists in the real world. Proxies are defined by a set of [Conditions](#condition) attached to them. The MARS [Database](#database) uses proxies to match data against the conditions.

## Proxy Group
A Proxy Group is a component that contains a collection of two or more Proxies GameObjects as child GameObjects. For the Proxy Group to match, all the conditions must match on each of the Proxies or no match can occur for any of them. You can add more [Relations](#relation) to this GameObject to impose additional rules or constraints on any data that would be used to match these Proxies.

## Query

A query is a persistent request to the database to find a match for a given set of conditions. When these conditions are found, the query executes a given set of actions. Every Proxy or Proxy Group makes a query when it becomes active, but you won't deal with queries directly most of the time.

## Query state
Refers to the stage in the process of matching with data in the Database that a Proxy or a Proxy Group is in.

## Rating configuration
A rating configuration consists of two numbers that control what a [Condition](#condition) / [Relation](#relation) optimizes for. It can be defined as either Center, a number between 0.001 - 0.999, or a Dead Zone (a number between 0 - 0.99):
- Center: Indicates where within the statistical distribution of possible matches you want to say the best ones are.
- Dead Zone: Indicates how much of the statistical distribution around the ideal center point is also considered an ideal match.

## Reasoning API
Reasoning APIs are an advanced feature that consists of user scripts that can interface with the entire MARS Database at once, rather than one trait at a time. This allows the scripts to make advanced inferences and combine, create, and mutate data.

## Recorded data
Recorded data refers to a type of data that has been captured from the real world and preserved. It references and plays back a real-world dataset rather than a synthetic dataset. Recorded data can come from the companion apps or a feed in the Editor.

## Relation
Refers to the constraint on a [Proxy Group](#proxy-group) that evaluates the relationship between real-world data that matches two child [Proxies](#proxy).

## Replicator
Refers to a GameObject with a Replicator component. A Replicator contains either a Proxy or a Proxy Group. Replicators continually create new ones as the existing GameObject is matched with data in the database until it meets a limit you specify. Replicators essentially turn Proxies and Proxy Groups into a 'For every* ' rule.

## Required children
Child [Proxies](#proxy) of a [Proxy Group](#proxy-group) that must maintain their matches for the Proxy Group to maintain its match.

## Semantic tag
A semantic tag is a specific kind of [Trait](#trait) in which the name is the data itself. Queries can check whether or not semantic tags exist.

## Simulation Mode
The Simulation Mode changes how Simulation behaves. Its built-in values are:
- Synthetic, for working with modeled environments inside Unity MARS
- Recorded, for testing Unity MARS against recorded data
- Live, for testing Unity MARS against live data, like a video feed from an attached camera

## Simulation View

The Simulation View is a custom Unity MARS view that shows your Scene running against a variety of data sources, spanning from synthetic environments and recorded streams to feeds from live devices. This view can show how a Scene reacts to a snapshot of data or to data changing over time. It runs in a hybrid of Edit and Play mode that offers some degree of playback and also allows you to edit your content at the same time.

## Synthetic data
Data that is artificially manufactured rather than generated by real-world events. Unity MARS uses synthetic data for many reasons. In some use cases, synthetic data is better - for example, if your app needs to work with data that doesn't exist in the real world (if the app requires a wall, but the device is located in a field, you can use synthetic data to have that wall anyway).

Synthetic data can be used to allow many different types of conditions to funnel down into a single design-friendly semantic piece of data to author against (for example, synthetic points where characters should spawn).

## Synthetic environments
Virtual environments that populate the MARS Database with data as if they are a physical environment read by a device. These environments are prefabs loaded by the Environment Manager.

## Synthetic object
A GameObject that Unity MARS treats like a real-world object. When these GameObjects are active, they write custom data to the [Database](#database).

Synthetic objects have the following uses:

- This is the mechanism used to make [Synthetic Environments](#synthetic-environments) interact with Unity MARS the same way a real-world environment does.
- These simulated synthetic objects can be used to emulate future platform functionality, for example by providing more detailed semantic tagging than is currently available.
- Synthetic data can be used to allow many different types of conditions to funnel down into a single design-friendly semantic piece of data to author against (for example, a synthetic point where characters would spawn).

## Trait
A named property of a Proxy, defined by its Name and Type. The name can be the data itself and is paired with any built-in or custom type. You can also test for the existence of a trait by name (that is, a semantic tag) regardless of its type or value.

Traits are how:
- All data in the MARS Database is stored
- Actions and conditions expect data to be read
- Providers and synthetic objects write their data to the database.

## Trait requirement
Specifies a given [Trait](#trait) and a true/false value indicating whether it is required.

## Unity MARS
Mixed & Augmented Reality Studio: a combination of a Unity extension and companion apps that allow users to create applications that span across digital devices and adapt to real-world data.

## World scale
Refers to both the system and the scale factor Unity MARS uses to make digital content appear larger or smaller in relation to real-world or synthetic environments. This is often necessary because scaling GameObjects for extremely large or small scales doesn't work as well for many Unity systems, such as Physics and Navmesh. The workaround is to process them at *n* scale and render them at scale ratio.
