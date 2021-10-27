namespace Unity.MARS.CodeGen
{
    class RelationTraitCacheCodeGenerator : BaseCodeGenerator
    {
        const string k_TemplateFileName = "RelationTraitCache.Template.txt";
        const string k_OutputFileName = "RelationTraitCache.Generated.cs";

        public override string TemplateFileName => k_TemplateFileName;
        public override string OutputFileName => k_OutputFileName;

        public override GeneratedTypeSet TypeSet => GeneratedTypeSet.Relations;

        public override bool TryGenerateCode(CodeGenerationTypeData[] typeData)
        {
            WriteBackingValueFieldsBlock(typeData);
            WriteClearInternalBlock(typeData);
            WriteFromRelationsBlock(typeData);
            WriteCheckDestroyedBlock(typeData);
            WriteTryGetTypeBlock(typeData);
            return TryWriteToFile();
        }

        void WriteBackingValueFieldsBlock(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{BackingValue_FIELDS}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                WriteSummary($"All trait values of type {data.Type.Name} associated with this Proxy's Relations");
                WriteLine($"{GetChildTraitsType(data)} {GetBackingFieldName(data)};");

                return DumpBufferContents();
            });
        }

        static string GetBackingFieldName(CodeGenerationTypeData typeData)
        {
            return $"{typeData.MemberPrefix}Collections";
        }

        static string GetChildTraitsType(CodeGenerationTypeData typeData)
        {
            return $"List<ChildTraits<{typeData.Type.FullName}>>";
        }

        void WriteClearInternalBlock(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(3);
            const string toReplace = "{ClearInternal_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                var field = GetBackingFieldName(data);
                WriteLine($"if({field} != null)");
                WriteLine( "{");
                WriteLine($"    for(var i = 0; i < {field}.Count; i++)");
                WriteLine( "    {");
                WriteLine($"        {field}[i] = null;");
                WriteLine( "    }");
                WriteLine( "}");

                return DumpBufferContents();
            });
            ChangeIndent(2);
        }

        void WriteCheckDestroyedBlock(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(3);
            const string toReplace = "{CheckDestroyed_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                var field = GetBackingFieldName(data);
                WriteLine($"if({field} != null)");
                WriteLine( "{");
                WriteLine($"    foreach(var dictionary in {field})");
                WriteLine( "    {");
                WriteLine($"        if(dictionary == null)");
                WriteLine($"            return true;");
                WriteLine( "    }");
                WriteLine( "}");

                return DumpBufferContents();
            });
            ChangeIndent(2);
        }

        void WriteFromRelationsBlock(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(3);
            const string toReplace = "{FromRelations_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                var prefix = data.LocalVarPrefix;
                var relationInterface = GetRelationTypeInterface(data.Type);
                var varName = $"{prefix}Relations";
                var lengthVarName = $"{prefix}Length";
                var field = GetBackingFieldName(data);

                WriteLine($"var {lengthVarName} = relations.GetTypeCount(out {relationInterface}[] {varName});");
                WriteLine($"if({lengthVarName} > 0)");
                WriteLine( "{");
                WriteLine($"    {field} = new {GetChildTraitsType(data)}();");
                WriteLine($"    {field}.Fill({lengthVarName});");
                WriteLine( "}");

                return DumpBufferContents();
            });
            ChangeIndent(2);
        }

        void WriteTryGetTypeBlock(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{TryGetType_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                var field = GetBackingFieldName(data);
                WriteLine($"public bool TryGetType(out {GetChildTraitsType(data)} traits)");
                WriteLine( "{");
                WriteLine($"    traits = {field};");
                WriteLine($"    return {field} != null;");
                WriteLine( "}");

                return DumpBufferContents();
            });
        }
    }
}
