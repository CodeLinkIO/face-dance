# Priority

The concept of "priority" in Unity MARS refers to the ability to designate **how important** the quality of the match found for a given Proxy or Proxy Group is.  

If 2 proxies want to match against the same data at the same time, but they're mutually exclusive, priority is used as the first deciding factor in which one gets to claim the data. This results in a higher likelihood of your important content finding a good match.

## Levels

There are 5 possible priority levels, defined by the `MarsEntityPriority` enum.

The levels in descending priority, with `Normal` being the default:

`Maximum, High, Normal, Low, Minimum`

## Proxies

A Proxy that is not a member of a proxy group controls its own priority.  

Priority is set under the "Common query data" dropdown in the Proxy inspector.

![Proxy priority inspector](images/Priority/priority-proxy-inspector.png)

Priority has no effect on an individual proxy when its Exclusivity is not `Reserved` - the control will be disabled in this case.

A Proxy that is a member of a proxy group **does not control its own priority** - the group does.   
In this case, the Priority field will be disabled in the Proxy inspector, and the value set there ignored.

## Groups

Groups control the priority for all proxy members.  
Setting priority works the same way as for proxies, in the common data for the proxy group.

![ProxyGroup priority inspector](images/Priority/priority-group-inspector.png)


## Scripting

Both `Proxy` and `ProxyGroup` have a `.Priority` property of type `MarsEntityPriority` that can be `get` & `set` to adjust their priority from a script.  

Priority for any proxy or group **must be set before they are registered** with the Unity MARS system that finds matches for them.  Changing priority after a proxy or group has been registered will have no effect.
