namespace Unity.MARS.CodeGen
{
    class FindMatchProposalsCodeGenerator : BaseCodeGenerator
    {
        const string k_TemplateFileName = "FindMatchProposals.Template.txt";
        const string k_OutputFileName = "FindMatchProposalsTransform.Generated.cs";

        public override string TemplateFileName => k_TemplateFileName;
        public override string OutputFileName => k_OutputFileName;

        public override bool TryGenerateCode(CodeGenerationTypeData[] typeData)
        {
            WriteGetStartingIdSet(typeData);
            WriteFindIntersection(typeData);
            return TryWriteToFile();
        }

        void WriteGetStartingIdSet(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(3);
            const string toReplace = "{GetStartingIdSet_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                if (data.Type == typeof(bool))
                {
                    WriteLine("var tagRatings = data[typeof(bool)];");
                    WriteLine("if (tagRatings != null && tagRatings.Count > 0)");
                    WriteLine("{");
                    WriteLine("    for (var i = 0; i < tagRatings.Count; i++)");
                    WriteLine("    {");
                    WriteLine("        // If we're excluding, we can't use this set as the starting point");
                    WriteLine("        if (data.MatchRuleIndexes[i] == SemanticTagMatchRule.Exclude)");
                    WriteLine("            continue;");
                    WriteLine();
                    WriteLine("        var dictionary = tagRatings[i];");
                    WriteLine("        foreach (var kvp in dictionary)");
                    WriteLine("        {");
                    WriteLine("            idSet.Add(kvp.Key);");
                    WriteLine("        }");
                    WriteLine();
                    WriteLine("        return;");
                    WriteLine("    }");
                    WriteLine("}");
                }
                else
                {
                    var prefix = data.LocalVarPrefix;
                    var ratingsVar = $"{prefix}Ratings";
                    var typeName = data.Type.FullName;

                    WriteLine($"var {ratingsVar} = data[typeof({typeName})];");
                    WriteLine($"if ({ratingsVar} != null && {ratingsVar}.Count > 0)");
                    WriteLine("{");
                    WriteLine($"    foreach (var kvp in {ratingsVar}[0])");
                    WriteLine("    {");
                    WriteLine("        idSet.Add(kvp.Key);");
                    WriteLine("    }");
                    WriteLine();
                    WriteLine("    return;");
                    WriteLine("}");
                }

                return DumpBufferContents();
            });
        }

        void WriteFindIntersection(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(3);
            const string toReplace = "{FindIntersection_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                if (data.Type == typeof(bool))
                    return "";

                var prefix = data.LocalVarPrefix;
                var dataVar = $"{prefix}Data";

                WriteLine($"var {dataVar} = data[typeof({data.Type.FullName})];");
                WriteLine($"if ({dataVar} != null)");
                WriteLine( "{");
                WriteLine($"    foreach (var dictionary in {dataVar})");
                WriteLine( "    {");
                WriteLine( "        k_IDsMatchingCondition.Clear();");
                WriteLine( "        foreach (var kvp in dictionary)");
                WriteLine( "        {");
                WriteLine( "            k_IDsMatchingCondition.Add(kvp.Key);");
                WriteLine( "        }");
                WriteLine();
                WriteLine( "        matchSet.IntersectWith(k_IDsMatchingCondition);");
                WriteLine( "    }");
                WriteLine( "}");
                WriteLine();
                WriteLine( "if (matchSet.Count == 0)");
                WriteLine( "    return false;");

                return DumpBufferContents();
            });
        }
    }
}
