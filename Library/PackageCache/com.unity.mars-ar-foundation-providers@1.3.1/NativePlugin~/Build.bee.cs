using System.Collections.Generic;
using System.Linq;
using Bee.NativeProgramSupport;
using NiceIO;

class Build
{
    const string k_PluginName = "MARSXRSubsystem";
    const CodeGen k_CodeGen = CodeGen.Release;

    static void Main()
    {
        BuildStarterKitPlugin();
    }

    private static void BuildStarterKitPlugin()
    {
        var np = new NativeProgram(k_PluginName)
        {
            Sources = { "Source" },
            IncludeDirectories = { "External/Unity" },
        };

        var architectures = new Dictionary<string, ToolChain>
        {
            { "windows", ToolChain.Store.Windows().VS2017().Sdk_17134().x64() },
            { "mac_x64", ToolChain.Store.Mac().Sdk_11_1().x64("10.12") },
            { "mac_arm64", ToolChain.Store.Mac().Sdk_11_1().ARM64() },
        };

        var outputs = new Dictionary<string, NPath>();
        foreach (var architecture in architectures.Where(x => x.Value.CanBuild))
        {
            var toolchain = architecture.Value;

            var platform = $"{toolchain.Platform.DisplayName.ToLower()}_{toolchain.Architecture.DisplayName.ToLower()}";
            var deployFolder = new NPath("build").Combine(platform);

            var config = new NativeProgramConfiguration(k_CodeGen, toolchain, false);
            var output = np.SetupSpecificConfiguration(config, toolchain.DynamicLibraryFormat).DeployTo(deployFolder);
            outputs[architecture.Key] = output.Path;
        }

        // TODO: lipo is broken.  Once it is fixed we can automatically build the universal version.
        // https://unity.slack.com/archives/C1RM0NBLY/p1618961132187700
        //var universal = Lipo.Setup((XcodeSdk)(architectures["mac_x64"].Sdk), new [] {outputs["mac_arm64"], outputs["mac_x64"]});
    }
}
