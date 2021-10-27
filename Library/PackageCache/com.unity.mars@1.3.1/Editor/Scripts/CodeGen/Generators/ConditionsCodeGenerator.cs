namespace Unity.MARS.CodeGen
{
    class ConditionsCodeGenerator : BaseCodeGenerator
    {
        protected const string k_TemplateFileName = "Conditions.Template.txt";
        protected const string k_OutputFileName = "Conditions.Generated.cs";

        public override string TemplateFileName => k_TemplateFileName;
        public override string OutputFileName => k_OutputFileName;

        public override bool TryGenerateCode(CodeGenerationTypeData[] typeData)
        {
            WriteBackingValueFieldsBlock(typeData);
            WriteTryGetConditionsBlock(typeData);
            WriteGetTypeCountBlock(typeData);
            WriteGatherComponentsBlock(typeData);
            WriteFromConditionBlock(typeData);
            WriteCountInternalMethod(typeData);
            return TryWriteToFile();
        }

        void WriteTryGetConditionsBlock(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{TryGetType_METHOD}";
            WriteBlock(toReplace, typeData, WriteTryGetType);
        }

        string WriteTryGetType(CodeGenerationTypeData typeData)
        {
            var type = typeData.Type;
            var backingField = GetBackingFieldName(typeData);

            WriteLine($"public bool TryGetType(out {GetConditionTypeInterface(type)}[] conditions)");
            WriteLine( "{");
            WriteLine($"    conditions = {backingField};");
            WriteLine( "    return conditions != null;");
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
            WriteBlock(toReplace, typeData, WriteGetMatching, false);
        }

        string WriteGetMatching(CodeGenerationTypeData typeData)
        {
            const string getMatching = "componentFilter.GetMatchingComponents";
            WriteLine($"    {GetBackingFieldName(typeData)} = {getMatching}<{GetConditionTypeInterface(typeData.Type)}>();");

            return DumpBufferContents();
        }

        static string GetBackingFieldName(CodeGenerationTypeData typeData)
        {
            return $"{typeData.MemberPrefix}Conditions";
        }

        string WriteBackingCollection(CodeGenerationTypeData typeData)
        {
            WriteSummary($"All Conditions of type {typeData.Type.Name} associated with this context");
            WriteLine($"{GetConditionTypeInterface(typeData.Type)}[] {GetBackingFieldName(typeData)};");

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
            WriteLine($"public int GetTypeCount(out {GetConditionTypeInterface(typeData.Type)}[] conditions)");
            WriteLine( "{");
            WriteLine( "    return !TryGetType(out conditions) ? 0 : conditions.Length;");
            WriteLine( "}");

            return DumpBufferContents();
        }

        void WriteFromConditionBlock(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{FromCondition_CONSTRUCTOR}";
            ChangeIndent(3);
            WriteBlock(toReplace, typeData, (data) =>
            {
                var varName = $"{data.LocalVarPrefix}Condition";
                WriteLine($"var {varName} = condition as {GetConditionTypeInterface(data.Type)};");
                WriteLine($"{GetBackingFieldName(data)} = {varName} != null ? new[] {{ {varName} }} : null;");

                return DumpBufferContents();
            });
        }

        void WriteCountInternalMethod(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{CountInternal_METHOD}";
            ChangeIndent(3);
            WriteBlock(toReplace, typeData, (data) =>
            {
                var field = GetBackingFieldName(data);
                WriteLine($"count += self.{field}.Length;");

                return DumpBufferContents();
            }, false);
        }
    }
}
