namespace Unity.MARS.CodeGen
{
    class CachedTraitCollectionsCodeGenerator : BaseCodeGenerator
    {
        protected const string k_TemplateFileName = "CachedTraitCollections.Template.txt";
        protected const string k_OutputFileName = "CachedTraitCollections.Generated.cs";

        public override string TemplateFileName => k_TemplateFileName;
        public override string OutputFileName => k_OutputFileName;

        public override bool TryGenerateCode(CodeGenerationTypeData[] typeData)
        {
            WriteBackingValueFieldsBlock(typeData);
            WriteClearInternalBlock(typeData);
            WriteFromConditionsBlock(typeData);
            WriteCheckDestroyedBlock(typeData);
            WriteTryGetTypeBlock(typeData);
            return TryWriteToFile();
        }

        void WriteBackingValueFieldsBlock(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{BackingValue_FIELDS}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                WriteSummary($"All trait values of type {data.Type.Name} associated with this context");
                WriteLine($"List<Dictionary<int, {data.Type.FullName}>> {GetBackingFieldName(data)};");
                return DumpBufferContents();
            });
        }

        static string GetBackingFieldName(CodeGenerationTypeData data)
        {
            return $"{data.MemberPrefix}Collections";
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

        void WriteFromConditionsBlock(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(3);
            const string toReplace = "{FromConditions_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                var prefix = data.LocalVarPrefix;
                var conditionInterface = GetConditionTypeInterface(data.Type);
                var varName = $"{prefix}Conditions";
                var lengthVarName = $"{prefix}Length";
                var field = GetBackingFieldName(data);

                WriteLine($"var {lengthVarName} = conditions.GetTypeCount(out {conditionInterface}[] {varName});");
                WriteLine($"if({lengthVarName} > 0)");
                WriteLine( "{");
                WriteLine($"    {field} = new List<Dictionary<int, {data.Type.FullName}>>();");
                WriteLine($"    for(var i = 0; i < {lengthVarName}; i++)");
                WriteLine( "    {");
                WriteLine($"        {field}.Add(null);");
                WriteLine( "    }");
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

                WriteLine($"public bool TryGetType(out List<Dictionary<int, {data.Type.FullName}>> traits)");
                WriteLine( "{");
                WriteLine($"    traits = {field};");
                WriteLine($"    return {field} != null;");
                WriteLine( "}");

                return DumpBufferContents();
            });
        }
    }
}
