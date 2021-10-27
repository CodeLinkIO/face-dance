using System;
using System.Linq;
using Unity.XRTools.Utils;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System.Text.RegularExpressions;
using Unity.MARS;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Build
{
    [MovedFrom("Unity.MARS.Build")]
    public abstract class ElectiveExtensions : IPreprocessBuildWithReport
    {
        public int callbackOrder { get { return 0; } }

        public abstract void OnPreprocessBuild(BuildReport report);

        public static string RunReport(SupportedConfiguration config)
        {
            if (config.ReportOutputLevel == SupportedConfiguration.ReportOutputLevels.ReportDisabled)
            {
                return "Reporting disabled.";
            }

            ElectiveReport[] reports =
            {
                CheckGraphicsAPI(config),
                CheckPackageVersions(config),
                CheckDefineSymbols(config),
            };

            if (MarsUserPreferences.ElectiveExtensionsReportsErrors)
            {
                config.ReportOutputLevel = SupportedConfiguration.ReportOutputLevels.ErrorOnIssue;
            }
            else if (config.ReportOutputLevel == SupportedConfiguration.ReportOutputLevels.ErrorOnIssue)
            {
                config.ReportOutputLevel = SupportedConfiguration.ReportOutputLevels.WarnOnIssue;
            }

            var result = "";
            if (config.ReportOutputLevel != SupportedConfiguration.ReportOutputLevels.ReportDisabled)
            {
                result = ReportAsString(reports, config);
            }

            switch (config.ReportOutputLevel) {
                case SupportedConfiguration.ReportOutputLevels.ErrorOnIssue when reports.Any(report => !report.Succeeded):
                    Debug.LogError(result + Messages.LogErrorOnIssueDetectedNotice);
                    break;
                case SupportedConfiguration.ReportOutputLevels.WarnOnIssue when reports.Any(report => !report.Succeeded):
                    Debug.LogWarning(result);
                    break;
                case SupportedConfiguration.ReportOutputLevels.ReportDisabled:
                    break;
                case SupportedConfiguration.ReportOutputLevels.DebugLogOnly:
                    Debug.Log(result);
                    break;
                default:
                    Debug.Log(result);
                    break;
            }

            return result;
        }

        static string ReportAsString(IEnumerable<ElectiveReport> reports, SupportedConfiguration config)
        {
            var messagesPass = "";
            var messagesFail = "";
            foreach (var report in reports)
            {
                messagesPass += report.MessagePass;
                messagesFail += report.MessageFail;
            }

            if (reports.All(report => report.Succeeded))
            {
                return Messages.NoIssuesFound + messagesPass + Messages.ReportUsedConfig + config.FriendlyName +
                       Messages.EndQuoteNewLine;
            }

            return messagesFail + Environment.NewLine + Messages.FollowingPassed + Environment.NewLine + messagesPass + Messages.ReportUsedConfig + config.FriendlyName +
                   Messages.EndQuoteNewLine;
        }

        // Compare major and minor versions, ignoring patch number
        static bool EqualOrNewerVersion(string current, string minimum)
        {
            // Regex that matches the first two number components in the version
            // i.e. for "2019.4.5f1" it matches "2019.4", which we can treat as a float for comparisons
            var regex = new Regex(@"^\d+\.\d+");
            var currentMatch = regex.Match(current);
            var minimumMatch = regex.Match(minimum);

            if (!(currentMatch.Success && minimumMatch.Success))
                return false;

            var currentVersion = float.Parse(currentMatch.Groups[0].Value);
            var minimumVersion = float.Parse(minimumMatch.Groups[0].Value);

            return currentVersion >= minimumVersion;
        }

        static ElectiveReport CheckGraphicsAPI(SupportedConfiguration config)
        {
            var report = new ElectiveReport();

            if (config.SupportedGraphicsAPIs == null || config.SupportedGraphicsAPIs.Length == 0)
            {
                return report;
            }

            if (config.SupportedGraphicsAPIs.Any(api => api == SystemInfo.graphicsDeviceType))
            {
                if (config.SupportedGraphicsAPIsIsOrdered &&
                    config.SupportedGraphicsAPIs[0] != SystemInfo.graphicsDeviceType)
                {
                    report.AddMessageFail(Messages.UnsupportedGraphicsSupportedVersionsAre +
                                          config.SupportedGraphicsAPIs.Stringify() +
                                          Messages.DetectedVersionIs + SystemInfo.graphicsDeviceType +
                                          Messages.EndQuoteNewLine + Messages.GraphicsApiIsUnsupportedOrder);
                }
                else
                {
                    report.AddMessagePass(Messages.GraphicsApiIsSupported +
                                          config.SupportedGraphicsAPIs.Stringify() + Messages.EndQuoteNewLine);
                }
            }
            else
            {
                report.AddMessageFail(Messages.UnsupportedGraphicsSupportedVersionsAre +
                                      config.SupportedGraphicsAPIs.Stringify() +
                                      Messages.DetectedVersionIs + SystemInfo.graphicsDeviceType +
                                      Messages.EndQuoteNewLine + Messages.GraphicsApiIsUnsupported);
            }

            return report;
        }

        static ElectiveReport CheckPackageVersions(SupportedConfiguration config)
        {
            var report = new ElectiveReport();

            if (config.Dependencies == null || config.Dependencies.Length == 0)
            {
                return report;
            }

            var installedPackages = InstalledPackages.Infos;
            var pairs = new List<MatchedPackagePair>();
            foreach (var dependency in config.Dependencies)
            {
                var pair = new MatchedPackagePair {dependencyPackage = dependency};
                foreach (var installedPackage in installedPackages)
                {
                    if (dependency.Name == installedPackage.name) {
                        pair.installedPackage = installedPackage;
                        pair.foundNameMatch = true;
                        break;
                    }
                }
                pairs.Add(pair);
            }

            foreach (var pair in pairs)
            {
                report = ComparePackagesForReport(pair, report);
            }

            return report;
        }

        static bool CheckSinglePackageVersion(string version, IEnumerable<string> listVersions)
        {
            return listVersions.Any(listVersion => EqualOrNewerVersion(version, listVersion));
        }

        class MatchedPackagePair
        {
            public PackageItem dependencyPackage;
            public PackageManager.PackageInfo installedPackage;
            public bool foundNameMatch;
        }

        static ElectiveReport ComparePackagesForReport(MatchedPackagePair pair, ElectiveReport report)
        {
            var installedPackage = pair.installedPackage;
            var dependency = pair.dependencyPackage;
            if (pair.foundNameMatch)
            {
                if (dependency.Required)
                {
                    if (CheckSinglePackageVersion(installedPackage.version,
                        new[] {dependency.Version}))
                    {
                        report.AddMessagePass(
                            Messages.PackageVersionIsSupported + dependency.Name +
                            " : " + dependency.Version + Messages.DetectedVersionIs +
                            installedPackage.name + " : " +
                            installedPackage.version + Messages.EndQuoteNewLine);
                    }
                    else
                    {
                        report.AddMessageFail(Messages.PackageVersionIsUnsupported +
                            dependency.Name + " : " +
                            dependency.Version + Messages.DetectedVersionIs +
                            installedPackage.name + " : " +
                            installedPackage.version +
                            Messages.EndQuoteNewLine);
                    }
                }
                else
                {
                    report.AddMessagePass(Messages.PackageVersionIsOptional +
                        dependency.Name + " : " +
                        dependency.Version + Messages.DetectedVersionIs +
                        installedPackage.name + " : " +
                        installedPackage.version + Messages.EndQuoteNewLine);
                }
            }
            else
            {
                if (dependency.Required)
                {
                    report.AddMessageFail(Messages.PackageVersionIsMissing + dependency.Name +
                        " : " + dependency.Version + Messages.EndQuoteNewLine);
                }
                else
                {
                    report.AddMessagePass(Messages.PackageVersionIsMissingAndOptional +
                        dependency.Name + " : " +
                        dependency.Version + Messages.EndQuoteNewLine);
                }
            }

            return report;
        }

        static class Messages
        {
            public const string PackageVersionIsUnsupported =
                "Caution! The package dependency version is unsupported: '";

            public const string PackageVersionIsOptional =
                "Optional package dependency specified version is: '";

            public const string PackageVersionIsMissing =
                "Caution! The package dependency version could not be found and needs to be added to the package manager: '";

            public const string PackageVersionIsSupported = "The supported package dependency version is: '";

            public const string PackageVersionIsMissingAndOptional = "The optional package is missing: '";

            public const string GraphicsApiIsSupported =
                "Graphics API Supported. The supported graphics API is '";

            public const string UnsupportedGraphicsSupportedVersionsAre =
                "Caution! Unsupported graphics API detected. Supported Graphics API(s) are:  '";

            public const string GraphicsApiIsUnsupportedOrder =
                "To set a custom graphics API order: \n" +
                "    - Open Player Settings\n" +
                "    - Navigate to 'Other Settings'\n" +
                "    - Uncheck 'Auto Graphics API'\n" +
                "    - Reorder entries as needed\n" +
                "    - Check if Standalone platform matches and if the required API is loaded first. Some platforms (e.g.: Lumin) require this. \n";

            public const string GraphicsApiIsUnsupported =
                "To set a custom graphics API: \n" +
                "    - Open Player Settings\n" +
                "    - Navigate to 'Other Settings'\n" +
                "    - Uncheck 'Auto Graphics API'\n" +
                "    - Add/Remove entries as needed\n" +
                "    - Check if Standalone platform matches and if the required API is loaded first. Some platforms (e.g.: Lumin) require this. \n";

            public const string LogErrorOnIssueDetectedNotice =
                "\nMARS ElectiveExtensions is currently set to report detected issues as ERRORs. To disable this behaviour:\n" +
                "    - Open Project Settings from the 'Edit' menu\n" +
                "    - Navigate to 'MARS' subwindow 'User Preferences'\n" +
                "    - Uncheck 'ElectiveExtensions Reports Errors'\n" +
                "    - With 'ElectiveExtensions Reports Errors' unchecked, ElectiveExtensions reports will log a maximum level of LogWarning\n";

            public const string DefineSymbolsFound = "    Found : '";

            public const string DefineSymbolsMissed = "    MISSED : '";

            public const string DefineSymbolsMissedNotRequired = "    Missed, not required : '";

            public const string DefineSymbolsFoundAll =
                "Required define symbols were all detected. The checked defines were: \n";

            public const string DefineSymbolsNotFoundHeader =
                "Caution! Required define symbols were NOT detected. The checked defines were: \n";

            public const string DefineSymbolsExampleHeader =
                "Project defines can be found in: \n" +
                "    'Project Settings' -> 'Player' ->  'Other Settings' -> 'Scripting Define Symbols' \n" +
                "An example string containing the required defines is:\n" +
                "    ";

            public const string ReportUsedConfig =
                "This report was generated using the Elective Extensions config with FriendlyName: '";

            public const string DetectedVersionIs = "'; the detected version is '";

            public const string NoIssuesFound =
                "MARS Elective Extensions found no issues with the build configuration \n\n";

            public const string EndQuoteNewLine = "' \n\n";

            public const string FollowingPassed = "--- The following checks were run and reported passed ---";
        }

        public class SupportedConfiguration
        {
            public string FriendlyName { get; }
            public BuildTarget[] BuildTargets { get; }
            public PackageItem[] Dependencies { get; }

            public DefineSymbolItem[] DefineSymbols { get; }
            public UnityEngine.Rendering.GraphicsDeviceType[] SupportedGraphicsAPIs { get; }

            [Obsolete]
            public string[] SupportedEditorVersions { get; }
            public ReportOutputLevels ReportOutputLevel { get; set; }
            public bool SupportedGraphicsAPIsIsOrdered { get; }

            public SupportedConfiguration(string friendlyName = "", BuildTarget[] buildTargets = null,
                PackageItem[] dependencies = null, DefineSymbolItem[] defineSymbols = null,
                UnityEngine.Rendering.GraphicsDeviceType[] supportedGraphicsApis = null,
                string[] supportedEditorVersions = null,
                ReportOutputLevels reportOutputLevel = ReportOutputLevels.WarnOnIssue, bool supportedGraphicsApIsIsOrdered = false)
            {
                FriendlyName = friendlyName;
                BuildTargets = buildTargets;
                Dependencies = dependencies;
                DefineSymbols = defineSymbols;
                SupportedGraphicsAPIs = supportedGraphicsApis;
                ReportOutputLevel = reportOutputLevel;
                SupportedGraphicsAPIsIsOrdered = supportedGraphicsApIsIsOrdered;
            }

            public enum ReportOutputLevels
            {
                ReportDisabled,
                DebugLogOnly,
                WarnOnIssue,
                ErrorOnIssue
            }
        }

        public class PackageItem
        {
            public string Name { get; }
            public string Version { get; }
            public bool Required { get; }

            public PackageItem(string name, string version, bool required = true)
            {
                Name = name;
                Version = version;
                Required = required;
            }
        }

        public class DefineSymbolItem
        {
            public string Name { get; }
            public bool Required { get; }
            public bool Present { get; }

            public DefineSymbolItem(string name, bool required, bool present = false)
            {
                Name = name;
                Required = required;
                Present = present;
            }
        }

        /// <summary>
        /// Search the local Unity Package Manager offline for installed packages synchronously
        /// </summary>
        /// <returns></returns>
        static class InstalledPackages
        {
            public static IEnumerable<PackageManager.PackageInfo> Infos { get { return SearchForInstalledPackageItems(); } }


            static IEnumerable<PackageManager.PackageInfo> SearchForInstalledPackageItems()
            {
                var packageInfos = new List<PackageManager.PackageInfo>();
                var packageItemsRequest = UnityEditor.PackageManager.Client.List(true, true);
                while (!packageItemsRequest.IsCompleted)
                {
                    // Wait a short time until results are ready. async is not supported
                    System.Threading.Thread.Sleep(50);
                }

                if (packageItemsRequest.Error != null)
                {
                    Debug.LogWarning("Error searching for installed packages");
                    return packageInfos;
                }
                packageInfos = packageItemsRequest.Result.ToList();

                return packageInfos;
            }
        }

        static ElectiveReport CheckDefineSymbols(SupportedConfiguration config)
        {
            var report = new ElectiveReport();

            if (config.DefineSymbols == null || config.DefineSymbols.Length == 0)
            {
                return report;
            }

            var definesAreMissing = false;
            foreach (var define in config.DefineSymbols)
            {
                if (define.Required && !define.Present)
                {
                    definesAreMissing = true;
                }
            }

            if (!definesAreMissing)
            {
                report.AddMessagePass(Messages.DefineSymbolsFoundAll);
            }
            else
            {
                report.AddMessageFail(Messages.DefineSymbolsNotFoundHeader);
            }

            foreach (var define in config.DefineSymbols)
            {
                if (define.Present)
                {
                    report.AddMessagePass(Messages.DefineSymbolsFound + define.Name + Messages.EndQuoteNewLine);
                }
                else
                {
                    if (define.Required)
                    {
                        report.AddMessageFail(Messages.DefineSymbolsMissed + define.Name + Messages.EndQuoteNewLine);
                    }

                    else
                    {
                        report.AddMessagePass(Messages.DefineSymbolsMissedNotRequired + define.Name +
                            Messages.EndQuoteNewLine);
                    }
                }
            }

            if (definesAreMissing)
            {
                var suggestedString = string.Join(";",config.DefineSymbols.Select(m => m.Name).ToArray());
                report.MessageFail += Messages.DefineSymbolsExampleHeader + suggestedString + Environment.NewLine;
            }

            return report;
        }

        class ElectiveReport
        {
            public string MessagePass { get; set; }
            public string MessageFail { get; set; }
            public int NumPass { get; set; }
            public int NumFail { get; set; }

            public bool Succeeded { get { return NumFail == 0; } }

            public ElectiveReport(int numPass = 0, int numFail = 0, string messagePassed = "",
                string messageFailed = "")
            {
                MessagePass = messagePassed;
                MessageFail = messageFailed;
                NumPass = numPass;
                NumFail = numFail;
            }

            public void AddMessageFail(string message)
            {
                NumFail++;
                MessageFail += message;
            }

            public void AddMessagePass(string message)
            {
                NumPass++;
                MessagePass += message;
            }
        }
    }
}
