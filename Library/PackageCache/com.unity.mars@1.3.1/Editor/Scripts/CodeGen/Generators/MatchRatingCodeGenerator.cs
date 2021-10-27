using Unity.MARS.Data;

namespace Unity.MARS.CodeGen
{
    class MatchRatingCodeGenerator : BaseCodeGenerator
    {
        const string k_TemplateFileName = "MatchRating.Template.txt";
        const string k_OutputFileName = "MatchRatingDataTransform.Generated.cs";

        public override string TemplateFileName => k_TemplateFileName;
        public override string OutputFileName => k_OutputFileName;

        public override bool TryGenerateCode(CodeGenerationTypeData[] typeData)
        {
            WriteRateConditionsInternal(typeData);
            WriteRateConditionTypeInternal(typeData);
            BufferContents = BufferContents.Replace("{TraitCollectionClassName}", nameof(CachedTraitCollection));
            return TryWriteToFile();
        }

        void WriteRateConditionTypeInternal(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(2);
            const string toReplace = "{RateConditionType_METHODS}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                if (data.Type == typeof(bool))
                    return "";

                var typeName = data.Type.FullName;
                WriteLine($"internal static bool RateConditionType(ICondition<{typeName}>[] typeConditions,");
                WriteLine( "    CachedTraitCollection traitCollections, List<Dictionary<int, float>> ratings)");
                WriteLine( "{");
                WriteLine( "    if (typeConditions.Length == 0)");
                WriteLine( "        return true;");
                WriteLine();
                WriteLine($"    if (!traitCollections.TryGetType(out List<Dictionary<int, {typeName}>> traits))");
                WriteLine( "        return false;");
                WriteLine();
                WriteLine( "    return RateConditionMatches(typeConditions, traits, ratings);");
                WriteLine( "}");

                return DumpBufferContents();
            });
        }

        void WriteRateConditionsInternal(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(3);
            const string toReplace = "{RateConditionMatchesInternal_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                if (data.Type == typeof(bool))
                    return "";

                var typeName = data.Type.FullName;
                var prefix = data.LocalVarPrefix;
                var conditionsVar = $"{prefix}Conditions";
                WriteLine($"conditions.TryGetType(out ICondition<{typeName}>[] {conditionsVar});");
                WriteLine($"if(!RateConditionType({conditionsVar}, traits, ratings[typeof({data.Type.FullName})]))");
                WriteLine( "    return false;");

                return DumpBufferContents();
            });
        }
    }
}
