# Unity MARS concepts

Unity MARS uses several concepts that are unique to it. This page explains the different terminology used across the extension.

## Proxy
<img align="left" src="images/MARSConcepts/proxies.png" style="padding-right: 16px;">

A **Proxy** is a GameObject in a Scene that acts as a stand-in for a real-world object that your app can detect and use, such as a table, a face, or a cat. AR app creation relies heavily on associating your digital content with objects or locations in the real world. Think about proxies like placeholders that connect the real world with digital content in your app.

Abstract proxies can be any condition-matching data, such as time- or weather-based conditions. While these don't exist in Unity MARS currently, they might in the future.

Proxies can have Unity MARS components such as conditions or actions that define and restrict when and how they match real-world objects.
<br clear="left"/><!-- With this we end the command for placing text right to the image. -->

## Proxy Groups
<img align="left" src="images/MARSConcepts/proxy-group.png" style="padding-right: 16px;">

A **Proxy Group** represents a grouping of multiple real-world objects that must all exist for your app to work. For example, "a room with two tables, a floor, and at least one wall". If any of these objects don't exist, the entire Proxy Group fails to match.

You can add multiple relations to the Proxy Group to make matching even stricter. For example, consider two Proxies that both expect planes. You can add a Proxy Group that contains an Elevation Relation specifying that the first plane needs to be 1 meter or more above the second. Neither Proxy matches these criteria until your app detects both these objects _and_ the relation between them.

<br clear="left"/>

## Replicators
<img align="left" src="images/MARSConcepts/replicator.png" style="padding-right: 16px;">

You can instruct your app to associate a single instance of a prefab with a particular Proxy or Proxy Group that your app discovers. However, to associate multiple instances of a prefab with numerous matching objects in the real-world, you can use a **Replicator**.

For example, you can set up a Proxy with a plane condition so that a piece of your app's environment appears on top of it when it gets matched. If you then put this Proxy into a Replicator, this replicates that Proxy on every other real-world object that matches that condition. In this case, your app's environment appears on every surrounding surface.

For a more code-centric definition, a Replicator is a component that continuously duplicates a Proxy or Proxy Group while the Replicator encounters matching data within the MARS Database until a user-defined limit is reached. In other words, Replicators essentially turn Proxies and ProxyGroups into _"for every* "_ rules.

<br clear="left"/>

## Rules
The [Rules workflow](Rules.md) is a MARS UI feature that doesn't introduce any new object types. It presents many of the existing types on this page in a unified view intended to guide users through new and/or advanced functionality. The Rules UI incorporates Replicators, Proxies, Proxy Groups, Landmarks, and Forces.

## Proxy Forces
A [Proxy Force](Forces.md) allows you to tune the final placement of a Proxy and interact with said placement in real-time. To do this, you can apply multiple 'soft influences' such as alignment regions and spatial relationships to GameObjects; Unity MARS uses a physics model to balance out these forces.

While the [ProxyForce](https://docs.unity3d.com/Packages/com.unity.mars@1.0/api/Unity.MARS.Forces.ProxyForces.html) component lets you configure how the GameObject can move (such as only rotating about the Y axis, and enabling real-time solving), the actual forces are usually either a ProxyAlignmentForce, ProxyRegionOccupancy, or ProxyRegionForceTowards. These components apply forces that move the Proxy relative to another GameObject, keep occupied/padding regions from colliding, and pull the Proxy towards certain filtered shapes, respectively.

<br clear="left"/>

## Synthetic Objects and Simulation View
<img align="left" src="images/MARSConcepts/synthetic-object.png" style="padding-right: 16px;">

During development, you can try out your app in Unity MARS by testing it against **Synthetic Objects** in the **Simulation View**.

The **Simulation View** allows you to test your app against a variety of data sources, such as synthetic environments, pre-authored recorded streams, and remote streams from live devices. This view can show a Scene in one of two modes: **instant** and **continuous**:

* Instant simulations run a Scene as an 'instant' (a moment) in time, with all the Proxies in the simulated environment that Unity MARS has already tested for matches against all of the data.
* In continuous simulations, the **Device View** matches Proxies as the camera encounters data while it moves to explore the simulated environment. The Device View acts as though you are holding your AR device and using it to scan your surroundings.

You can tag any GameObject with synthetic semantic tags (see the [Glossary](Glossary.md) for more information), then use that Prefab as a synthetic environment in the Simulation View. You can also specify semantic tag conditions as matching criteria for locating tagged Synthetic Objects.

At runtime, your app can place semantic tags on discovered Proxies (for example, tag the beginning and end of a bridge), or prompt the user to define where a tag appears in the real world.

<br clear="left"/>

## The MARS Database
Unity MARS maintains a database of real-world data it has discovered (on a device or in simulation). Using Proxies, you can define criteria for associating your GameObjects with real-world data and contexts that your application is designed for. For example, a GameObject that has a Proxy component with conditions describing a table is only relevant when a piece of matching data in the MARS Database becomes available.

For more in-depth information about the MARS Database, see the [MARS Database section in the Software Development Guide](./SoftwareDevelopmentGuide.md#mars-database).

## The MARS Session and the Camera
![MARS Camera](images/MARSConcepts/mars-camera.png)

Unity MARS automatically adds a MARS Session GameObject to the hierarchy of the active Scene when you add a MARS Entity to any Scene. A MARS Session must exist in a loaded Scene in order to use the Simulation View.

If there is already a camera in the active Scene, it becomes a child of the MARS Session object, and Unity MARS adds a MARSCamera script to it. If you do not have a camera in the active Scene, Unity MARS creates one with a MARSCamera script on it and adds it as a child GameObject of the MARS Session.

The Camera with a MARS Camera script on it must always have a MARS Session somewhere in its list of parents. It is possible to add a child GameObject to the MARS Session GameObject and add the MARS Camera as a child of that GameObject, but Unity MARS prevents you from moving the MARS camera outside of the Session's hierarchy. This is because Unity MARS relies on the ability to transform and scale the MARS Session and have that impact the AR tracking space of the MARS camera.
