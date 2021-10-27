using Unity.MARS.Data;
using UnityEngine;

namespace Unity.MARS.CodeGen
{
    class DatabaseTraitsCodeGenerator : BaseCodeGenerator
    {
        const string k_TemplateFileName = "MARSDatabase.Traits.Template.txt";
        const string k_OutputFileName = "MARSDatabase.Traits.Generated.cs";

        public override string TemplateFileName => k_TemplateFileName;
        public override string OutputFileName => k_OutputFileName;

        // since trait providers underlie both conditions and relations, we generate all types.
        public override GeneratedTypeSet TypeSet => GeneratedTypeSet.All;


        public override bool TryGenerateCode(CodeGenerationTypeData[] typeData)
        {
            WriteBackingFields(typeData);
            WriteGetTraitProviderBlock(typeData);
            WriteStartBufferingBlock(typeData);
            WriteStopBufferingBlock(typeData);
            WriteInitializeTraitProviders(typeData);
            WriteUnloadTraitsBlock(typeData);
            WriteClearTraitsBlock(typeData);
            BufferContents = BufferContents.Replace("{TraitCollectionClassName}", nameof(CachedTraitCollection));
            return TryWriteToFile();
        }

        void WriteInitializeTraitProviders(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(3);
            const string toReplace = "{InitializeTraitProviders_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                var field = GetTraitProviderFieldName(data);
                WriteLine($"{field} = new {GetTraitProviderType(data)}(setDirtyIfNeeded, this);");
                WriteLine($"RegisterTraitTypeProvider({field});");
                return DumpBufferContents();
            });
            ChangeIndent(2);
        }

        void WriteStartBufferingBlock(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(3);
            const string toReplace = "{StartBufferingInternal_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                if (data.Type == typeof(Pose))    // we don't currently delay pose updates
                    return "";

                WriteLine($"{GetTraitProviderFieldName(data)}.StartUpdateBuffering();");
                return DumpBufferContents();
            });
            ChangeIndent(2);
        }

        void WriteStopBufferingBlock(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(3);
            const string toReplace = "{StopBufferingInternal_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                if (data.Type == typeof(Pose))
                    return "";

                WriteLine($"{GetTraitProviderFieldName(data)}.StopUpdateBuffering();");
                return DumpBufferContents();
            });
            ChangeIndent(2);
        }

        static string GetTraitProviderFieldName(CodeGenerationTypeData typeData)
        {
            return $"{typeData.MemberPrefix}TraitProvider";
        }

        static string GetTraitProviderType(CodeGenerationTypeData typeData)
        {
            return $"MARSTraitDataProvider<{typeData.Type.FullName}>";
        }

        void WriteBackingFields(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{TraitProvider_FIELDS}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                var providerType = GetTraitProviderType(data);
                var providerProperty = GetTraitProviderFieldName(data);

                WriteSummary($"Provides all trait data of type {data.Type.Name}");
                WriteLine($"internal {providerType} {providerProperty} {{ get; private set; }}");

                return DumpBufferContents();
            });
        }

        void WriteGetTraitProviderBlock(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{GetTraitProvider_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                var providerProperty = GetTraitProviderFieldName(data);
                var providerType = GetTraitProviderType(data);

                WriteLine($"internal void GetTraitProvider(out {providerType} provider)");
                WriteLine( "{");
                WriteLine($"    provider = {providerProperty};");
                WriteLine( "}");

                return DumpBufferContents();
            });
        }

        void WriteUnloadTraitsBlock(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(3);
            const string toReplace = "{UnloadTraits_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                var providerProperty = GetTraitProviderFieldName(data);
                WriteLine($"self.{providerProperty}.Unload();");
                return DumpBufferContents();
            }, false);
            ChangeIndent(2);
        }

        void WriteClearTraitsBlock(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(3);
            const string toReplace = "{ClearTraits_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                WriteLine($"self.{GetTraitProviderFieldName(data)}.Clear();");
                return DumpBufferContents();
            }, false);
            ChangeIndent(2);
        }
    }
}
