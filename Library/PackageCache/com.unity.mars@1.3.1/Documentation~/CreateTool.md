# Create tool

The Create tool allows you to sample data from the Simulation view and automatically create Proxy GameObjects with Conditions that match the sampled data. While using the Create tool, the Simulation view will display visualizations of the AR data.

## Placing prefabs with drag-and-drop

Click any prefab and drag it from the Project window into the Simulation view. While you drag the prefab, the Editor will temporarily switch to the Create tool. When you drop the prefab onto data, it becomes a child of the Proxy that Unity MARS creates.

**Note:** Your Scene needs to contain a MARSSession for this to work.

![Using drag-and-drop](images/CreateTool/DragDrop.png)

## Using the Create tool

To access the Create tool, from Unity's Tools menu, select the **MARS Create Tool**. You can also access it from **Available Custom Editor Tools**.

![Accessing the Create tool](images/CreateTool/ChooseCreateTool.png)

To learn more about a piece of data, hover your mouse cursor over it. The data's visual representation turns blue, and a box displays in the top-left corner with that data's known Traits.

![Hovering over data](images/CreateTool/DataVisuals.png)

You can interact with this data in two ways:

* Click on the data to select it. The data turns orange, and a **Create Proxy** button appears where you clicked.
* Shift-click to select two pieces of data. On the second click, a **Create Proxy Group** button appears.

![Create Proxy button](images/CreateTool/CreateProxyButton.png)
![Create Proxy Group button](images/CreateTool/CreateProxyGroupButton.png)

Click the **Create** button to generate a new Proxy or Proxy Group in your Scene based on the selected data. A new window appears, where you can give the new object a name, and enable or disable individual conditions.

![Create Proxy window](images/CreateTool/CreateWindow.png)
![Create Proxy Group window](images/CreateTool/CreateGroupWindow.png)

The **Max Count** option allows you to specify the maximum number of matches that the created proxy will be duplicated for. By default, there is a limit of 1. If disabled, there will be no limit. If **Max Count** is *not* 1, the created proxy or proxy group will also have a parent [Replicator](MARSConcepts.md#replicators) to manage the matches.

If you're creating a Proxy Group, you can click **Modify** to adjust child proxies individually.

To finalize the creation, click **Create**. To close the window and abandon all changes, click **Cancel**. If you clicked **Create**, the created object appears in the active Scene, where you can make further changes to it.
