using Unity.MARS.Data;

namespace Unity.MARS.CodeGen
{
    class TraitDataSnapshotCodeGenerator : BaseCodeGenerator
    {
        const string k_TemplateFileName = "TraitDataSnapshot.Template.txt";
        const string k_OutputFileName = "TraitDataSnapshot.Generated.cs";

        public override string TemplateFileName => k_TemplateFileName;
        public override string OutputFileName => k_OutputFileName;

        // since trait providers underlie both conditions and relations, we generate all types.
        public override GeneratedTypeSet TypeSet => GeneratedTypeSet.All;


        public override bool TryGenerateCode(CodeGenerationTypeData[] codeGenerationTypeRegistry)
        {
            WriteTraitDataFields(codeGenerationTypeRegistry);
            WriteClearBlock(codeGenerationTypeRegistry);
            WriteTakeSnapshotBlock(codeGenerationTypeRegistry);
            WriteGetTraitsBlock(codeGenerationTypeRegistry);
            WriteTryGetTraitBlock(codeGenerationTypeRegistry);
            WriteGetPotentialConditionsBlock(codeGenerationTypeRegistry);
            WriteCollectPotentialRelationsBlock(codeGenerationTypeRegistry);
            WriteGetAllTraitNamesBlock(codeGenerationTypeRegistry);
            BufferContents = BufferContents.Replace("{TraitCollectionClassName}", nameof(CachedTraitCollection));
            return TryWriteToFile();
        }

        void WriteTraitDataFields(CodeGenerationTypeData[] codeGenerationTypeRegistry)
        {
            ChangeIndent(2);
            const string toReplace = "{TraitData_FIELDS}";
            WriteBlock(toReplace, codeGenerationTypeRegistry, (data) =>
            {
                WriteLine($"readonly Dictionary<string, {data.Type}> {GetTypeDictionaryFieldName(data)} = {CodeGenerationShared.GetDictionaryPool(data)}.Get();");//method for pool
                return DumpBufferContents();
            });
        }

        void WriteTakeSnapshotBlock(CodeGenerationTypeData[] codeGenerationTypeRegistry)
        {
            ChangeIndent(3);

            const string toReplace = "{TakeSnapshot_METHOD}";
            WriteBlock(toReplace, codeGenerationTypeRegistry, (data) =>
            {
                WriteLine($"db.GetTraitProvider(out MARSTraitDataProvider<{data.Type}> {data.LocalVarPrefix}Provider);");
                WriteLine($"MARSDatabase.GetAllTraitsForId(queryResult.DataID, {data.LocalVarPrefix}Provider, {GetTypeDictionaryFieldName(data)});");
                return DumpBufferContents();
            });
        }

        void WriteGetTraitsBlock(CodeGenerationTypeData[] codeGenerationTypeRegistry)
        {
            ChangeIndent(2);

            const string toReplace = "{GetTraits_METHOD}";
            WriteBlock(toReplace, codeGenerationTypeRegistry, (data) =>
            {
                WriteSummary($"Get the {data.LocalVarPrefix} traits");
                WriteLine($"public void GetTraits(out Dictionary<string, {data.Type}> traits)");
                WriteLine( "{");
                WriteLine( $"    traits = {GetTypeDictionaryFieldName(data)};");
                WriteLine( "}");
                return DumpBufferContents();
            });
        }

        void WriteTryGetTraitBlock(CodeGenerationTypeData[] codeGenerationTypeRegistry)
        {
            ChangeIndent(2);

            const string toReplace = "{TryGetTrait_METHOD}";
            WriteBlock(toReplace, codeGenerationTypeRegistry, (data) =>
            {
                WriteSummary("Get value of a particular trait by name");
                WriteLine($"public bool TryGetTrait(string traitName, out {data.Type} value)");
                WriteLine( "{");
                WriteLine($"    if(!{GetTypeDictionaryFieldName(data)}.TryGetValue(traitName, out value))");
                WriteLine( "    {");
                WriteLine( "        value = default;");
                WriteLine( "        return false;");
                WriteLine( "    }");
                WriteLine();
                WriteLine( "    return true;");
                WriteLine( "}");

                return DumpBufferContents();
            });
        }

        void WriteGetPotentialConditionsBlock(CodeGenerationTypeData[] codeGenerationTypeRegistry)
        {
            ChangeIndent(3);

            const string toReplace = "{GetPotentialConditions_METHOD}";
            WriteBlock(toReplace, codeGenerationTypeRegistry, data =>
            {
                WriteLine($"GetTraits(out Dictionary<string, {data.Type}> {data.LocalVarPrefix}Traits);");
                WriteLine( $"CollectPotentialConditions({data.LocalVarPrefix}Traits, results, gameObject);");
                return DumpBufferContents();
            });
        }

        void WriteCollectPotentialRelationsBlock(CodeGenerationTypeData[] codeGenerationTypeRegistry)
        {
            ChangeIndent(3);

            const string toReplace = "{CollectPotentialRelations_METHOD}";
            WriteBlock(toReplace, codeGenerationTypeRegistry, data =>
            {
                var varName = $"{data.LocalVarPrefix}Traits";
                WriteLine($"GetTraits(out Dictionary<string, {data.Type}> {varName});");
                WriteLine( $"CollectPotentialRelationsOfType({varName}, childRelationTypes[index], index);");
                return DumpBufferContents();
            });
        }

        void WriteGetAllTraitNamesBlock(CodeGenerationTypeData[] codeGenerationTypeRegistry)
        {
            ChangeIndent(3);

            const string toReplace = "{GetAllTraitNames_METHOD}";
            WriteBlock(toReplace, codeGenerationTypeRegistry, data =>
            {
                var varName = $"{data.LocalVarPrefix}Traits";
                WriteLine($"GetTraits(out Dictionary<string, {data.Type}> {varName});");
                WriteLine($"foreach (var trait in {varName})");
                WriteLine("    results.Add(trait.Key);");
                return DumpBufferContents();
            });
        }

        void WriteClearBlock(CodeGenerationTypeData[] codeGenerationTypeData)
        {
            ChangeIndent(3);

            const string toReplace = "{Clear_METHOD}";
            WriteBlock(toReplace, codeGenerationTypeData, data =>
            {
                var property = GetTypeDictionaryFieldName(data);
                WriteLine($"{property}.Clear();");
                return DumpBufferContents();
            });
        }

        static object GetTypeDictionaryFieldName(CodeGenerationTypeData data)
        {
            return $"m_{data.MemberPrefix}Traits";
        }
    }
}
