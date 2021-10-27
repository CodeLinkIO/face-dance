# Working with Unity MARS

This page describes how to work with [Proxies](Glossary.md#proxy), [Proxy Groups](Glossary.md#proxy-group), and [Replicators](Glossary.md#replicator), how to assess how well-matched content converges with a [compare tool](CompareTool.md). It also contains [tips for authoring AR content with MARS](#tips-for-authoring-ar-content-with-unity-mars). The page is structured like a series of hands-on mini-tutorials.

This page covers the following Unity MARS workflows:

* [Authoring MARS content with the Rules workflow](#authoring-mars-content-with-the-rules-workflow)
* [Placing digital content on a table](#placing-digital-content-on-a-table)
* [Creating a Proxy automatically from simulated data (Create Tool)](#creating-a-proxy-automatically-from-simulated-data-create-tool)
* [Debugging a Proxy against simulation data (Compare Tool)](#debugging-a-proxy-against-simulation-data-compare-tool)
* [Using a Replicator to place content on multiple surfaces](#using-a-replicator-to-place-content-on-multiple-surfaces)
* [Scaling AR content with World Scale](#scaling-ar-content-with-world-scale)
* [Scene evaluation](#scene-evaluation)

## Authoring MARS content with the Rules workflow

The Rules workflow is designed to guide you through setting up your AR content, and is particularly useful for new users. This workflow includes configuring Proxies, Replicators, Proxy Groups, and Landmarks. For a full walkthrough, see the [Rules documentation](Rules.md). 

## Placing digital content on a table

You can use MARS templates to quickly place digital content on a table. From Unity's main menu, go to **Window &gt; MARS &gt; Choose Template**, then select the **Tabletop** template. This opens a template Scene with all the elements you need to implement a simple tabletop Scene, which you then need to save separately (menu: **File &gt; Save As**).

![Using the Tabletop template in Unity MARS](images/WorkingWithMars/template-tabletop.png)

In the Scene **Hierarchy**, look for the **Table** element. This is a Proxy with conditions to match it with flat surfaces that are 0.5x0.5 meters (around 2.25 square feet) and larger. When your app finds matching data in the real world, any GameObjects listed as children of this Proxy become active.

By default, a cube is set to appear on the surface. You should remove it and replace it with your own content.

![Table Proxy in the Scene's Hierarchy window](images/WorkingWithMars/table-inspector.png)

You can put a Prefab directly under this element, or drag it onto the plane in the middle of your Scene. The plane is an abstract representation of the Table element mentioned above. Any local position offset your GameObject has from the center of the Table element remains in absolute units, and not as a percentage of the offset value relative to the size of the real-world surface.

**Note:** Most AR devices don't support object recognition yet. There might be flat surfaces that register as appropriate for tabletop content, but which aren't tables, such as couches or chairs. You can test your app in **Simulation Mode** (menu: **Window &gt; MARS &gt; Simulation View**) to see how it will behave with real-world data, and how you can tweak your conditions to get a better fit.

### Creating a Proxy from scratch

You can create a Proxy from scratch, instead of using a template. To do this, from Unity's main menu, go to **GameObject &gt; MARS &gt; Proxy**. This creates an empty Proxy in the Scene.

A new (empty) Proxy contains a few default Actions and conditions. It expects the data it matches to have a position and orientation, then shows or hides its child GameObjects based on whether it has found a match. To make the Proxy match any type of Plane, add a new condition to it. Click the **Add MARS Component** button in the Inspector, then select **Condition &gt; Trait &gt; Plane**.

![Adding a Plane condition to an empty Proxy](images/WorkingWithMars/proxy-from-scratch.png)

The Proxy now matches against any single surface found in the world.

### Attaching content to the Proxy

In the **Hierarchy** view, you can drag and drop Prefabs, meshes, or Assets as child GameObjects of the Proxy you created. When you drag a GameObject over a Proxy visualization, the visualization is highlighted and a tooltip with its name appears. When you release the GameObject, Unity MARS adds the Asset as a child of the Proxy in the **Hierarchy** view.

![Attaching a child GameObject to the Proxy](images/WorkingWithMars/drag-prefab.png)

**Note:** MARS retains the Asset's local position offset. If you want the Asset to appear in the center of the detected surface, set its local position to (0, 0, 0).

## Creating a Proxy automatically from simulated data (Create Tool)

The Create Tool allows you to sample data from the **Simulation View** and automatically create Proxies with Conditions that describe the sampled data.

For more information, see [Create Tool documentation](CreateTool.md).

## Debugging a Proxy against simulation data (Compare Tool)

The Compare Tool allows you to inspect how Unity MARS evaluates a Proxy against data in the **Simulation View**.

For more information, see [Compare Tool documentation](CompareTool.md).

## Aligning a Proxy with the world's Y (Up) axis

When a Proxy finds a match, the Set Pose Action moves its Transform's position and rotation to align with the data's pose.

If the match data is a vertical plane, it might be useful to enable the **Align with World Up** option to make the content have a consistent vertical orientation. The option has three different modes:

* None: (Default) The Proxy directly matches the data's pose. The rotation of the pose data depends on the data provider.
* Y: The Proxy's local Y axis (Up) is always be aligned to the world's Up direction.
* Z: The Proxy's local Z axis (Forward) is always aligned to the world's Up direction.

When the mode is set to align either Y or Z to Up, the other axis is always perpendicular to the world's Up and aligned towards the data's Up. If the data's Up direction is parallel to the world Up, then it falls back to the data's Forward.

## Using a Replicator to place content on multiple surfaces

Each Proxy represents exactly one match with real-world data. However, you can also spawn content on every match of a query. For example, you might want to spawn a grassy ground on every horizontal plane your app detects. For this, you can use a Replicator.

To use a Replicator, follow these steps:

1. Create a Proxy, following the method outlined in the **Creating a Proxy from scratch** section above.

2. Create a Replicator GameObject: click the **Replicator** button in the **MARS Panel**, or from Unity's main menu go to **GameObject &gt; MARS &gt; Replicator**.

3. Select the GameObject. In its Inspector window, you can set how many instances of a match your app supports in the **Max Instances** property, and whether they should be created as children of the Replicator or as siblings of it by enabling or disabling the **Spawn As Child** property. A value of 0 for **Max Instances** indicates no limit on the number of instances.

4. Move your Proxy to be a child of the Replicator.

![Working with Replicators](images/WorkingWithMars/replicator.png)

## Creating Proxy Groups

The previous sections described how to work on a single Proxy - that is, a single collection of real-world traits. Unity MARS also offers a feature called Proxy Groups, which allow you to relate multiple Proxies together.

Proxy Groups follow the same pattern as individual Proxies. They contain Relations to address or locate them and actions to invoke scripts when a Proxy Group is matched or updated. The difference is that Relation scripts refer to multiple Proxies rather than a single one.

Proxy Groups have the following structure:

```
GameObject (ProxyGroup) (Relation)
   -Child GameObject (Proxy) (Condition)
   -Child GameObject (Proxy) (Condition)
    -...
```

The list of child GameObjects that are available to this Proxy Group displays in the group's Inspector. To indicate that Unity MARS requires a child GameObject, check the box next to it in the **Required Children** list. MARS uses child GameObjects that aren't required to find the Proxy Group. Once that happens, the Proxy Group doesn't lose its data even if these child GameObjects are lost or removed.

There are three ways to create a Proxy Group:

* Click the **Proxy Group** button on the MARS Panel
* From Unity's main menu, go to **GameObject &gt; MARS &gt; Proxy Group**.
* Add a ProxyGroup component to a new GameObject.

All of these methods create a GameObject with a Proxy Group and two Proxy child GameObjects. To add a Relation, click the **Add MARS Component** button in the Proxy Group's Inspector, then select **Relation** and choose a Relation type from the menu.

![A Proxy Group's Inspector window](images/WorkingWithMars/proxy-group.png)

You can also place Proxy Groups inside Replicators. This creates as many instances of that Proxy Group as there are matches.

## Scaling AR content with World Scale

Due to floating point precision, the Unity Editor works best on a real-world object scale, where 1 unit = 1 meter. Scaling your content to achieve “world-in-miniature” behavior doesn't account for effects such as gravity, lighting, physics, AI, and so on. These systems still operate on a normal scale.

<img src="images/WorkingWithMars/world-scale.png">

Unity MARS uses a concept called World Scale that allows you to develop content at real-world scale, and display it at a miniature scale. You can adjust the World Scale for the current Scene in the **MARS Session** Inspector. In general, MARS uses a scale of 1:1 for life-sized AR and 1:10 for tabletop miniatures.

**Note:** Unity MARS currently doesn't support a combination of miniature scaled and real-life scaled GameObjects.

To achieve the World Scale effect, leave GameObjects at their “real” size and instead modify the camera offset so that physical systems (such as physics, particles, and lighting) continue to work as expected. For more information, see [Dealing With Scale in AR](https://blogs.unity3d.com/2017/11/16/dealing-with-scale-in-ar/) on the Unity blog, and Unity's [AR Lightning Talks at GDC](https://www.youtube.com/watch?v=VP1BkhvcWs4&feature=youtu.be&t=37).

## Scene evaluation

There are two ways to control when Unity MARS evaluates the matches for your Scene. To select which mode MARS starts with, view the EvaluationSchedulerModule Asset and set the **Startup Mode** option:

* **EvaluateOnInterval**: By default, MARS attempts to solve your scene on a fixed time interval, which you enter in the EvaluationSchedulerModule's **Evaluation Interval** field.
* **WaitForRequest**: In this mode, MARS does not evaluate matches for your Scene until it receives a request to do so.

![Evaluation Scheduler module](images/WorkingWithMars/evaluation-scheduler-module.png)

The EvaluationSchedulerModule Asset's **Minimum Evaluation Time** field controls the minimum time that has to elapse between evaluations. Use it to prevent your app from spamming evaluation requests that would result in running Scene evaluation every frame. Set this field to 0 to not enforce any time between evaluations.

## Placing content based on synthetic data

In a previous section on this page, you learned to [attach a GameObject to a Proxy](#attaching-content-to-the-proxy) that matched your criteria. Synthetic data offers additional flexibility, such as comparing Proxies against one another. Based on queries, Unity MARS creates synthetic data that goes back into the database. You can query against a synthetic data semantic tag, and add more conditions to it.

For example, if you're making an AR game, you can define some base conditions for placing enemies using Replicators, but you might want a weaker version of the enemy to spawn near the player character's spawn point. If you add "player_spawn" and "enemy_spawn" semantic tags to the hero Replicator and enemy Replicator synthetic data, you can also add distance conditions on the Replicators that determine whether a weaker enemy spawns or not.

## Tips for authoring AR content with Unity MARS

1. You might like to think of surfaces matching the axes that you see in the Simulation View, but in the real world you can't count on strict orientations. In general, planes coming from AR devices have fairly random yaw rotations, especially for surfaces that are not rectangles.

2. It's usually better to make content that can adapt to the world, rather than limit situations where your content can be used. Unity MARS doesn't scan even ideal environments as perfectly axis-aligned rectilinear planes. Making your content adaptable is the best way to ensure that it works.

3. Don’t be afraid to design around abstract concepts or other kinds of data that a device doesn't provide directly. If your application requires a sofa, then make your Proxy have a condition that requires the ‘sofa’ semantic tag. During development, this allows you to mock up the experience in Simulation View, where you can label the environment content manually. When you build your app, Unity MARS notifies you of what traits and requirements are currently missing. This tells you what data you need to infer via the [Reasoning API](SoftwareDevelopmentGuide.md#reasoning-apis) or another provider.

4. AR is unpredictable. Include contingencies and fallbacks for any critical features of your app.

5. It’s usually best to leave room scanning and debug visualizations on, at least until you have placed content. This reassures end users that your app works.

6. Synthetic data offers a way for you to build up an AR experience in layers. For example, it's often better to author Synthetic ‘spawn points’ on your environments rather than placing critical content on them directly. This way, you can author conditions that look for the spawn point that's closest to the user. For more information, see [Placing Content based on Synthetic Data](#placing-content-based-on-synthetic-data).
