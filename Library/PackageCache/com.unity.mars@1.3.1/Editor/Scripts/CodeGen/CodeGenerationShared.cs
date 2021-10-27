using System.IO;
using Unity.MARS.Settings;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;

namespace Unity.MARS.CodeGen
{
    static class CodeGenerationShared
    {
        public const string Indent = "    ";

        internal static string TemplatesFolder = GetTemplatesFolder();

        // NOTE: These must match: PackageSource/com.unity.mars/Editor/Bootstrap/Constants.cs
        internal const string OutputFolder = MARSCore.AssetMarsRootFolder + "/Generated/";
        internal const string DefaultExtensionPath = MARSCore.AssetMarsRootFolder + "/ExtensionTypes/";

        const string k_MarsEditorAssembly = "Unity.MARS.Editor";

        internal static string GetDictionaryPool(CodeGenerationTypeData data)
        {
            return $"Pools.{data.MemberPrefix}Results";
        }

        public static void EnsureOutputFolder()
        {
            EnsureAssetsFolderExists(MARSCore.AssetMarsRootFolder);

            EnsureAssetsFolderExists(DefaultExtensionPath);

            EnsureAssetsFolderExists(OutputFolder);
        }

        public static void EnsureAssetsFolderExists(string path)
        {
            var pathParts = path.Split('/');
            var prefix = "";
            foreach (var dir in pathParts)
            {
                if (string.IsNullOrEmpty(dir))
                    continue;

                if (string.IsNullOrEmpty(prefix))
                {
                    Debug.Assert(dir == "Assets");
                    prefix = dir;
                    continue;
                }

                var curDir = prefix + "/" + dir;
                if (!AssetDatabase.IsValidFolder(curDir))
                {
                    AssetDatabase.CreateFolder(prefix, dir);
                }
                prefix = curDir;
            }
        }

        static string GetTemplatesFolder()
        {
            var asmdefPath = CompilationPipeline.GetAssemblyDefinitionFilePathFromAssemblyName(k_MarsEditorAssembly);
            var asmdefFolder = Path.GetDirectoryName(asmdefPath);
            return $"{asmdefFolder}/Scripts/CodeGen/Templates/";
        }
    }
}
