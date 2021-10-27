using System.IO;
using Unity.MARS.Settings;
using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS
{
    static class PackageUtils
    {
        const string k_SourcePathFormatString = "Packages/{0}/Content~/Defaults";
        const string k_ContentFolder = "Content";
        const string k_ContentAsmdefGuid = "bbc2b2767d45fd24b9ff5a5ac7c2af82";

        [MenuItem(MenuConstants.MenuPrefix + "/Import Content", false, MenuConstants.ImportContentPriority)]
        public static void ImportContentPackage()
        {
            // Triggering a compile at this point causes package validation tests to fail
            if (Application.isBatchMode)
                return;

            if (IsImported())
            {
                Debug.LogWarning("MARS content assembly definition already exists in project--skipping content import to avoid guid conflicts.");
                return;
            }

            var sourcePath = Path.GetFullPath(string.Format(k_SourcePathFormatString, MARSCore.PackageName));
            var destinationPath = Path.GetFullPath(Path.Combine(MARSCore.AssetMarsRootFolder, k_ContentFolder));
            if (Directory.Exists(destinationPath))
            {
                Debug.LogWarning($"Could not copy MARS content--destination already exists. Please move or remove the folder at {destinationPath} and import content via Window > MARS > Import Content");
                return;
            }

            if (!Directory.Exists(sourcePath))
            {
                Debug.LogError("Could not copy MARS content--source does not exist");
                return;
            }

            DirectoryCopy(sourcePath, destinationPath);
            AssetDatabase.Refresh();
        }

        [MenuItem(MenuConstants.MenuPrefix + "/Import Content", true, MenuConstants.ImportContentPriority)]
        public static bool ValidateImportContentPackage()
        {
            return !IsImported();
        }

        static bool IsImported()
        {
            var asmdef = AssetDatabase.GUIDToAssetPath(k_ContentAsmdefGuid);
            if (string.IsNullOrEmpty(asmdef))
                return false;

            var asmdefPath = Path.GetFullPath(asmdef);

            // Use filesystem because AssetDatabase will report assets exist after deletion until editor restart
            return File.Exists(asmdefPath);
        }

        // From https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
        static void DirectoryCopy(string sourcePath, string destinationPath)
        {
            var dir = new DirectoryInfo(sourcePath);
            if (!dir.Exists)
                return;

            var dirs = dir.GetDirectories();
            if (!Directory.Exists(destinationPath))
                Directory.CreateDirectory(destinationPath);

            var files = dir.GetFiles();
            foreach (var file in files)
            {
                var tempPath = Path.Combine(destinationPath, file.Name);
                file.CopyTo(tempPath, true);
            }

            foreach (var subDirectory in dirs)
            {
                var tempPath = Path.Combine(destinationPath, subDirectory.Name);
                DirectoryCopy(subDirectory.FullName, tempPath);
            }
        }
    }
}
