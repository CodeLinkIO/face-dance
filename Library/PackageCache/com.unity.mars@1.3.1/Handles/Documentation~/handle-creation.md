# Getting Started
Handles, by unity design, are not meant to directly move data around. A Handle is meant to **convert user inputs into useable transformation**. This transformation is then applied by a system to a data format. 
In the editor, this system would be an EditorTool. For example, a Move Tool would take a Position Handle Transformation and apply it to the Selection.
**A handle is made using GameObject and Components** like you would normally use in unity.

As the process of creating a handle is the same for any type of handle, we'll use a basic position handle as an example.

## Making a Basic Position Handle
### Step 1: Create Your Prefab
Create a prefab structure as you normally would in unity.
In this example will use a basic 3 axis structure.

![Hierarchy](images/creation/basic-prefab.png)

Create the visual for your handle by **adding any type of renderers** and moving your GameObjects according to your design.
For this example we will use a Mesh Renderer with a cube mesh but **we could use anything including UI components as our renderer**. We are also using a builtin material with the unlit color shader but any material could be used. It should look something like this:

![Inspector](images/creation/adding-renderers.png)

Your position handle will now look something like this:

![Position Handle Visual](images/creation/position-handle-visual.png)

### Step 2: Add Interactive Handles to Interactive Parts 
All the moving part the user will be able to use is done with component inheriting from **[Interactive Handle](builtin-interactive-handles.md)**. 
**This component will determine how the handle will translate user input into movement**
The builtin interactive handles are in the **Add Component Menu under _Prefab Handles/Interactive Handles_**:

![Add Component Menu](images/creation/interactive-handle-menu.png)

Builtin interactive handle use the forward of the object as the directing vector, represented by a gizmo when selecting the object.
This means that **you will have to rotate the object to get the movement you want**.
In our case, we will use the slider 1d handle which is going to move in one axis, the forward of the object, represented by a blue line.

![Direction Preview](images/creation/gizmo-preview.png)

### Step 3: Add Builtin & Custom Visual Behaviours 
You normally want to add some visual feedback to interactions. These can be found in the Add Component Menu under _Prefab Handles/Utility_.
The **nearest parent with an interactive handle is considered the owner of the [Handle Behaviours](handle-behaviours.md)**
Here we'll use a Handle State Colors component to all our renderers to change the color of the material depending on the state of the interaction.
In our example, our renderers should now look like this.

![Add Visual Behaviour](images/creation/add-visual-behaviour.png)

### Step 4: Add Picking Target
To be able to figure out which Interactive Handle is being used by the user, **[Picking Targets](builtin-picking-targets.md) act as collision for the current input system (e.g. mouse)**.
Like the Handle Behaviours, picking target are owned by the nearest parent with an Interactive Handle. 
This means that it's possible for an Interactive Handle to have more than one Picking Target.
These components are located in the Add Component Menu under _Prefab Handles/Picking Targets_.
In our example, we'll use a Box Picking Target. The preview in the scene view should look like this:

![Add Picking Target](images/creation/add-picking-targets.png)

### Step 5: Add a Component to Control the Entire Group of Interactive Handles
**It's a good practice (but not required) to have a component on the root object that unites the output of all interactive handle**.
This makes it easier in code to only work with one component and not a *N* number of them.
In this example, we'll use the **Position Handle** component and add all the sliders to the sliders array value.

![Position Handle Component](images/creation/position-handle-component.png)

### Step 6: Plug the Handle Into your System
You can now **create an instance of your handle using a [handle context](builtin-handle-context.md)** which serves as the **bridge between your handle and a specific input system/rendering pipeline**.

At runtime, no default context currently exists but an example can be found in the *Runtime Sample*.

In the Editor, the most common context is the *Scene View Context* which is implemented by default and the *Editor Window Context* for custom windows.
The following example uses *Editor Tools* to plug in the handle, which is always good practice to do.
You can find the *Editor Tools* Documentation here: https://docs.unity3d.com/Manual/UsingCustomEditorTools.html.

```
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEditor.PrefabHandles;
using UnityEngine;
using UnityEngine.PrefabHandles;

[EditorTool("Position Tool")]
public sealed class PositionTool : EditorTool
{
    GameObject m_MyHandle;

    void OnEnable()
    {
        EditorTools.activeToolChanged += OnToolChanged;

        //For this to work, you'll need to have the handle inside the resources folder
        GameObject myHandlePrefab = Resources.Load<GameObject>("Basic Position Handle");

        m_MyHandle = SceneViewContext.activeViewContext.CreateHandle(myHandlePrefab);
        m_MyHandle.GetComponent<PositionHandle>().translationUpdated += OnTranslationUpdate;
        OnToolChanged();
    }

    void OnDisable()
    {
        EditorTools.activeToolChanged += OnToolChanged;
        SceneViewContext.activeViewContext.DestroyHandle(m_MyHandle);
    }

    public override void OnToolGUI(EditorWindow window)
    {
        if (Event.current.type == EventType.Layout)
        {
            bool isHidden = Tools.hidden || Selection.activeTransform == null;
            if (isHidden)
            {
                m_MyHandle.gameObject.SetActive(false);
            }
            else
            {
                m_MyHandle.gameObject.SetActive(true);
                m_MyHandle.transform.localPosition = Tools.handlePosition;
                m_MyHandle.transform.localRotation = Tools.handleRotation;
            }
        }
    }

    void OnTranslationUpdate(TranslationUpdateInfo info)
    {
        foreach (var transform in Selection.transforms)
        {
            transform.position += info.world.delta;
        }
    }
}
```

