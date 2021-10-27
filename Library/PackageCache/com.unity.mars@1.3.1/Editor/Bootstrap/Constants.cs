namespace Unity.MARS
{
    static class Constants
    {
        // NOTE: These must match: com.unity.mars/Editor/Scripts/CodeGen/CodeGenerationShared.cs
        internal const string AssetMarsRootFolder = "Assets/MARS";
        internal const string OutputFolder = AssetMarsRootFolder + "/Generated/";

        // Specific to Bootstrap assembly:
        internal const string MarsPackageName = "com.unity.mars";
        internal const string GeneratedPath = OutputFolder;
    }
}
