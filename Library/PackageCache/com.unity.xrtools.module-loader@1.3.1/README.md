# Module Loader
The module loader package enables multiple systems to coexist within a single project and interact with each other in a predictable, configurable way.  Packages that depend on it implement classes which extend `IModule` or some variant, which enables them to be loaded and unloaded in the Editor and at Runtime in a configurable order, and connect to each other in a systematic, predictable fashion. Included in this package is the `FunctionalityInjectionModule` which enables packages to expose functionality to each other, or to user code, without directly referencing each other.

Dependencies:
- `com.unity.xrtools.utils`
