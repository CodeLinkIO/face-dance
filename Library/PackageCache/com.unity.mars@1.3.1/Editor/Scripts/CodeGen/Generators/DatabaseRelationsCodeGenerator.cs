using UnityEngine;

namespace Unity.MARS.CodeGen
{
    class DatabaseRelationsCodeGenerator : BaseCodeGenerator
    {
        const string k_TemplateFileName = "MARSDatabase.Relations.Template.txt";
        const string k_OutputFileName = "MARSDatabase.Relations.Generated.cs";

        public override string TemplateFileName => k_TemplateFileName;
        public override string OutputFileName => k_OutputFileName;
        public override GeneratedTypeSet TypeSet => GeneratedTypeSet.Relations;

        public override bool TryGenerateCode(CodeGenerationTypeData[] typeData)
        {
            WriteFindRelationTraits(typeData);
            WriteDataStillMatches(typeData);
            WriteFillRelationTraits(typeData);
            return TryWriteToFile();
        }

        void WriteFillRelationTraits(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(3);
            const string toReplace = "{FillRelationTraits_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                // as long as poses need offsetting before output to results, they're filled in non-generated code
                if (data.Type == typeof(Pose))
                    return "";

                var iRelation = GetRelationTypeInterface(data.Type);
                var relationsVar = $"{ data.LocalVarPrefix}Relations";
                var providerProperty = GetTraitProviderFieldName(data);

                WriteLine($"if (relations.TryGetType(out {iRelation}[] {relationsVar}) && {relationsVar}.Length > 0)");
                WriteLine( "{");
                WriteLine($"    foreach (var relation in {relationsVar})");
                WriteLine( "    {");
                WriteLine( "        var child1 = relation.child1;");
                WriteLine( "        if (childResults.TryGetValue(child1, out var child1Result))");
                WriteLine( "        {");
                WriteLine( "            var trait1Name = relation.child1TraitName;");
                WriteLine($"            {providerProperty}.TryGetTraitValue(dataAssignments[child1], trait1Name, out var value1);");
                WriteLine( "            child1Result.SetTrait(trait1Name, value1);");
                WriteLine( "        }");
                WriteLine();
                WriteLine( "        var child2 = relation.child2;");
                WriteLine( "        if (childResults.TryGetValue(child2, out var child2Result))");
                WriteLine( "        {");
                WriteLine( "            var trait2Name = relation.child2TraitName;");
                WriteLine($"            {providerProperty}.TryGetTraitValue(dataAssignments[child2], trait2Name, out var value2);");
                WriteLine( "            child2Result.SetTrait(trait2Name, value2);");
                WriteLine( "        }");
                WriteLine( "    }");
                WriteLine( "}");

                return DumpBufferContents();
            });
            ChangeIndent(2);
        }

        void WriteDataStillMatches(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(3);
            const string toReplace = "{DataStillMatches_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                if (data.Type == typeof(bool))            // no semantic tag relations
                    return "";

                var iRelation = GetRelationTypeInterface(data.Type);
                var relationsVar = $"{ data.LocalVarPrefix}Relations";
                var providerProperty = GetTraitProviderFieldName(data);

                WriteLine($"if (relations.TryGetType(out {iRelation}[] {relationsVar}) && {relationsVar}.Length > 0)");
                WriteLine( "{");
                WriteLine($"    if (!CheckIfDataStillMatches(dataAssignments, {relationsVar}, {providerProperty}, ");
                WriteLine($"        children, nonRequiredChildrenLost))");
                WriteLine( "        return false;");
                WriteLine( "}");

                return DumpBufferContents();
            });
            ChangeIndent(2);
        }

        static string GetTraitProviderFieldName(CodeGenerationTypeData typeData)
        {
            return $"{typeData.MemberPrefix}TraitProvider";
        }

        void WriteFindRelationTraits(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(3);
            const string toReplace = "{FindRelationTraits_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                if (data.Type == typeof(bool))            // no semantic tag relations
                    return "";

                var iRelation = GetRelationTypeInterface(data.Type);
                var prefix = data.LocalVarPrefix;
                var relationsVar = $"{prefix}Relations";
                var traitsVar = $"{prefix}Traits";
                var tChildTraits = $"List<RelationTraitCache.ChildTraits<{data.Type.FullName}>>";
                var providerProperty = GetTraitProviderFieldName(data);

                WriteLine($"if (relations.GetTypeCount(out {iRelation}[] {relationsVar}) > 0)");
                WriteLine( "{");
                WriteLine($"    if (!cache.TryGetType(out {tChildTraits} {traitsVar}))");
                WriteLine( "        return false;");
                WriteLine();
                WriteLine($"    if (!FindTraitCollections({providerProperty}, {relationsVar}, {traitsVar}))");
                WriteLine( "        return false;");
                WriteLine( "}");

                return DumpBufferContents();
            });
            ChangeIndent(2);
        }
    }
}
