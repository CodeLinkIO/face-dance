# About List View Framework

The List View Framework is a set of core classes which can be used as-is or extended to create dynamic, scrollable lists in Unity applications.

The code is set up to be customizable, but not "intelligent" or comprehensive. In other words, this is not a one-size-fits-all solution with lots of options and internal logic to adapt to the type of data set.  Instead, the idea is to extend the core classes into a number of list types which handle different requirements throughout your project.  In this way, we avoid a single, monolithic and complex script file which is hard to read, and at the same time, we can ensure that our lists aren't wasting CPU cycles on unnecessary branching, i.e. `if (horizontal)` or `if (smoothScrolling)`.  At the same time, developers are free to create their own one-size-fits-all implementation if they have the need to switch options on-the-fly, or if for some other reason their use case demands it.

More details about the design and implementation of this framework on the [Unity Blog](https://blogs.unity3d.com/2016/08/05/list-view-framework/)

## Usage
List view implementations will require at a minimum:

1. A GameObject with a ListViewController (or extension) component
2. At least one template prefab with a ListViewItem (or extension) component
3. A data source composed of ListViewData objects

## Requirements

This version of List View Framework is compatible with the following versions of the Unity Editor:

* 2018.4.20f1 and later (recommended)
