namespace Unity.MARS.CodeGen
{
    class RelationMatchRatingCodeGenerator : BaseCodeGenerator
    {
        const string k_TemplateFileName = "RelationMatchRating.Template.txt";
        const string k_OutputFileName = "RelationRatingTransform.Generated.cs";

        public override string TemplateFileName => k_TemplateFileName;
        public override string OutputFileName => k_OutputFileName;

        public override GeneratedTypeSet TypeSet => GeneratedTypeSet.Relations;

        public override bool TryGenerateCode(CodeGenerationTypeData[] typeData)
        {
            WriteTryMatchAllInternal(typeData);
            return TryWriteToFile();
        }

        void WriteTryMatchAllInternal(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(3);
            const string toReplace = "{TryMatchAllInternal_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                if (data.Type == typeof(bool))                            // no semantic tag relations
                    return "";

                var iRelation = GetRelationTypeInterface(data.Type);
                var tChildTraits = $"List<RelationTraitCache.ChildTraits<{data.Type.FullName}>>";
                var prefix = data.LocalVarPrefix;
                var relationsVar = $"{prefix}Relations";
                var traitsVar = $"{prefix}Traits";

                WriteLine($"if(relations.GetTypeCount(out {iRelation}[] {relationsVar}) > 0)");
                WriteLine( "{");
                WriteLine($"    if(!traits.TryGetType(out {tChildTraits} {traitsVar}) ||");
                WriteLine($"        !RateMatches({relationsVar}, {traitsVar}, relationPairs, memberRatings, ratings))");
                WriteLine( "        return false;");
                WriteLine( "}");

                return DumpBufferContents();
            });
            ChangeIndent(2);
        }
    }
}
