namespace Unity.MARS.CodeGen
{
    class RelationsCodeGenerator : BaseCodeGenerator
    {
        protected const string k_TemplateFileName = "Relations.Template.txt";
        protected const string k_OutputFileName = "Relations.Generated.cs";

        public override string TemplateFileName => k_TemplateFileName;
        public override string OutputFileName => k_OutputFileName;
        public override GeneratedTypeSet TypeSet => GeneratedTypeSet.Relations;

        public override bool TryGenerateCode(CodeGenerationTypeData[] typeData)
        {
            WriteBackingValueFieldsBlock(typeData);
            WriteTryGetConditionsBlock(typeData);
            WriteGetTypeCountBlock(typeData);
            WriteGatherComponentsBlock(typeData);
            WriteFromRelationBlock(typeData);
            return TryWriteToFile();
        }

        void WriteTryGetConditionsBlock(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{TryGetType_METHOD}";
            WriteBlock(toReplace, typeData, WriteTryGetType);
        }

        string WriteTryGetType(CodeGenerationTypeData data)
        {
            k_WriteBuilder.Clear();
            var type = data.Type;
            var backingField = GetBackingFieldName(data);

            WriteLine($"public bool TryGetType(out {GetRelationTypeInterface(type)}[] relations)");
            WriteLine( "{");
            WriteLine($"    relations = {backingField};");
            WriteLine( "    return relations != null;");
            WriteLine( "}");

            return DumpBufferContents();
        }

        void WriteBackingValueFieldsBlock(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{BackingValue_FIELDS}";
            WriteBlock(toReplace, typeData, WriteBackingCollection);
        }

        void WriteGatherComponentsBlock(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{GatherComponents_METHOD}";
            WriteBlock(toReplace, typeData, WriteGetMatching);
        }

        string WriteGetMatching(CodeGenerationTypeData typeData)
        {
            const string getMatching = "componentFilter.GetMatchingComponents";
            var backing = GetBackingFieldName(typeData);
            WriteLine($"    {backing} = {getMatching}<{GetRelationTypeInterface(typeData.Type)}>();");
            WriteLine($"    Count += {backing}.Length;");

            return DumpBufferContents();
        }

        static string GetBackingFieldName(CodeGenerationTypeData typeData)
        {
            return $"{typeData.MemberPrefix}Relations";
        }

        string WriteBackingCollection(CodeGenerationTypeData typeData)
        {
            WriteSummary($"All Relations of type {typeData.Type.Name} associated with this context");
            WriteLine($"{GetRelationTypeInterface(typeData.Type)}[] {GetBackingFieldName(typeData)};");

            return DumpBufferContents();
        }

        void WriteGetTypeCountBlock(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{GetTypeCount_METHOD}";
            WriteBlock(toReplace, typeData, WriteTypeCountMethod);
        }

        string WriteTypeCountMethod(CodeGenerationTypeData typeData)
        {
            WriteSummary($"Get the number of conditions of type {typeData.Type.Name} associated with this context");
            WriteLine($"public int GetTypeCount(out {GetRelationTypeInterface(typeData.Type)}[] relations)");
            WriteLine( "{");
            WriteLine( "    return !TryGetType(out relations) ? 0 : relations.Length;");
            WriteLine( "}");

            return DumpBufferContents();
        }

        void WriteFromRelationBlock(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{FromRelation_CONSTRUCTOR}";
            ChangeIndent(3);
            WriteBlock(toReplace, typeData, (data) =>
            {
                var varName = $"{data.LocalVarPrefix}Condition";
                WriteLine($"var {varName} = relation as {GetRelationTypeInterface(data.Type)};");
                WriteLine($"{GetBackingFieldName(data)} = {varName} != null ? new[] {{ {varName} }} : null;");

                return DumpBufferContents();
            });
        }
    }
}
