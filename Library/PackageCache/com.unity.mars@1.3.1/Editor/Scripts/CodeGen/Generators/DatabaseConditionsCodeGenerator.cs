using Unity.MARS.Data;
using UnityEngine;

namespace Unity.MARS.CodeGen
{
    class DatabaseConditionsCodeGenerator : BaseCodeGenerator
    {
        const string k_TemplateFileName = "MARSDatabase.Conditions.Template.txt";
        const string k_OutputFileName = "MARSDatabase.Conditions.Generated.cs";

        public override string TemplateFileName => k_TemplateFileName;
        public override string OutputFileName => k_OutputFileName;

        public override bool TryGenerateCode(CodeGenerationTypeData[] typeData)
        {
            WriteFindTraitsInternal(typeData);
            WriteFillRequirementType(typeData);
            WriteUpdateRequirementType(typeData);
            WriteUpdateQueryMatch(typeData);
            WriteDataPassesAllConditionsInternal(typeData);

            BufferContents = BufferContents.Replace("{TraitCollectionClassName}", nameof(CachedTraitCollection));
            return TryWriteToFile();
        }
        
        void WriteDataPassesAllConditionsInternal(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{DataPassesAllConditionsInternal_METHOD}";
            ChangeIndent(3);
            WriteBlock(toReplace, typeData, (data) =>
            {
                // semantic tag conditions handled in non generated code
                if (data.Type == typeof(bool)) 
                    return "";
                
                var conditionsVar = $"{data.LocalVarPrefix}Conditions";
                var providerProperty = GetTraitProviderFieldName(data);

                WriteLine($"if(conditions.TryGetType(out {GetConditionTypeInterface(data.Type)}[] {conditionsVar}))");
                WriteLine( "{");
                WriteLine($"    if(!ConditionsPass({providerProperty}, {conditionsVar}, dataId))");
                WriteLine( "        return false;");
                WriteLine( "}");

                return DumpBufferContents();
            });
        }

        void WriteUpdateQueryMatch(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(3);
            const string toReplace = "{UpdateQueryMatchInternal_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                // poses & semantic tags have special handling in non-generated code
                if (data.Type == typeof(Pose) || data.Type == typeof(bool))
                    return "";

                var iCondition = GetConditionTypeInterface(data.Type);
                var prefix = data.LocalVarPrefix;
                var conditionsVar = $"{prefix}Conditions";
                var providerProperty = GetTraitProviderFieldName(data);

                WriteLine($"if (conditions.TryGetType(out {iCondition}[] {conditionsVar}))");
                WriteLine( "{");
                WriteLine($"    foreach (var condition in {conditionsVar})");
                WriteLine( "    {");
                WriteLine($"        if (!{providerProperty}.TryGetTraitValue(dataID, condition.traitName, out var traitValue))");
                WriteLine( "            return false;");
                WriteLine( "        if (condition.PassesCondition(ref traitValue))");
                WriteLine( "            result.SetTrait(condition.traitName, traitValue);");
                WriteLine( "        else");
                WriteLine( "            return false;");
                WriteLine( "    }");
                WriteLine( "}");

                return DumpBufferContents();
            });
            ChangeIndent(2);
        }

        void WriteFillRequirementType(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{FillRequirementType_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                // poses have special handling until we remove offsets from the results
                if (data.Type == typeof(Pose))
                    return "";

                var providerProperty = GetTraitProviderFieldName(data);
                const string parameters = "(TraitRequirement requirement, int dataId, QueryResult result)";
                WriteLine($"internal void {GetRequirementFillMethodName(data)}{parameters}");
                WriteLine( "{");
                WriteLine( "    if (requirement.Required)");
                WriteLine( "    {");
                WriteLine($"        var value = {providerProperty}.dictionary[requirement.TraitName][dataId];");
                WriteLine( "        result.SetTrait(requirement.TraitName, value);");
                WriteLine( "    }");
                WriteLine( "    else");
                WriteLine( "    {");
                WriteLine($"        if (!{providerProperty}.dictionary.TryGetValue(requirement.TraitName, out var traitValues))");
                WriteLine( "            return;");
                WriteLine( "        if(traitValues.TryGetValue(dataId, out var value))");
                WriteLine( "            result.SetTrait(requirement.TraitName, value);");
                WriteLine( "    }");
                WriteLine( "}");

                return DumpBufferContents();
            });
        }

        void WriteUpdateRequirementType(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{UpdateRequirementType_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                // poses have special handling until we remove offsets from the results
                if (data.Type == typeof(Pose))
                    return "";

                var providerProperty = GetTraitProviderFieldName(data);
                const string parameters = "(TraitRequirement requirement, int dataId, QueryResult result)";
                WriteLine($"internal bool {GetRequirementUpdateMethodName(data)}{parameters}");
                WriteLine( "{");
                WriteLine($"    return TryUpdateRequirementType(requirement, dataId, result, {providerProperty});");
                WriteLine( "}");

                return DumpBufferContents();
            });

            ChangeIndent(3);
            const string addMethodToReplace = "{AddTraitRequirementMethods_METHOD}";
            WriteBlock(addMethodToReplace, typeData, (data) =>
            {
                if (data.Type == typeof(Pose))
                    return "";

                var updateMethodName = GetRequirementUpdateMethodName(data);
                var fillMethodName = GetRequirementFillMethodName(data);
                const string dictionaryFieldName = nameof(MARSDatabase.TypeToRequirementUpdate);
                const string fillDictionary = nameof(MARSDatabase.TypeToRequirementFill);
                WriteLine($"{dictionaryFieldName}[(MarsDataType) typeof({data.Type.FullName})] = {updateMethodName};");
                WriteLine($"{fillDictionary}[(MarsDataType) typeof({data.Type.FullName})] = {fillMethodName};");

                return DumpBufferContents();
            });
            ChangeIndent(2);
        }


        // filling the initial match result and updating it are different functions
        // because updating needs to handle triggering loss events
        static string GetRequirementFillMethodName(CodeGenerationTypeData typeData)
        {
            return $"Fill{typeData.MemberPrefix}Requirement";
        }

        static string GetRequirementUpdateMethodName(CodeGenerationTypeData typeData)
        {
            return $"Update{typeData.MemberPrefix}Requirement";
        }

        static string GetTraitProviderFieldName(CodeGenerationTypeData typeData)
        {
            return $"{typeData.MemberPrefix}TraitProvider";
        }

        void WriteFindTraitsInternal(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(3);
            const string toReplace = "{FindTraitsInternal_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                var prefix = data.LocalVarPrefix;
                var conditionsVar = $"{prefix}Conditions";
                var traitsVar = $"{prefix}Collections";
                var iCondition = GetConditionTypeInterface(data.Type);
                var traitDictionary = $"Dictionary<int, {data.Type.FullName}>";
                var listType = $"List<{traitDictionary}>";
                var providerField = GetTraitProviderFieldName(data);

                WriteLine($"if (conditions.GetTypeCount(out {iCondition}[] {conditionsVar}) > 0)");
                WriteLine( "{");
                WriteLine($"    if(!cache.TryGetType(out {listType} {traitsVar}))");
                WriteLine( "        return false;");
                WriteLine();
                WriteLine($"    for(var i = 0; i < {conditionsVar}.Length; i++)");
                WriteLine( "    {");
                WriteLine($"        var condition = {conditionsVar}[i];");
                WriteLine($"        if(!{providerField}.TryGetAllTraitValues(condition.traitName, out {traitDictionary} traits))");

                // handle semantic tag exclusion - it's ok to not find the trait collection if it's excluding
                if (data.Type == typeof(bool))
                {
                    WriteLine( "            if(condition.matchRule == SemanticTagMatchRule.Match)");
                    WriteLine( "                return false;");
                }
                else
                {
                    WriteLine( "            return false;");
                }
                WriteLine();
                WriteLine($"        {traitsVar}[i] = traits;");
                WriteLine( "    }");
                WriteLine( "}");

                return DumpBufferContents();
            });
            ChangeIndent(2);
        }
    }
}
