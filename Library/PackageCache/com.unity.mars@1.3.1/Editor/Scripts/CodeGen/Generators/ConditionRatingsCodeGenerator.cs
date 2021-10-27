namespace Unity.MARS.CodeGen
{
    class ConditionsRatingsCodeGenerator : BaseCodeGenerator
    {
        protected const string k_TemplateFileName = "ConditionRatingsData.Template.txt";
        protected const string k_OutputFileName = "ConditionRatingsData.Generated.cs";

        public override string TemplateFileName => k_TemplateFileName;
        public override string OutputFileName => k_OutputFileName;

        public override bool TryGenerateCode(CodeGenerationTypeData[] typeData)
        {
            WriteFromConditionsBlock(typeData);
            return TryWriteToFile();
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
                const string typeIndexVar = "s_TypeIndex";
                const string tagListIndexVar = "m_SemanticTagListIndex";

                WriteLine($"var {lengthVarName} = conditions.GetTypeCount(out {conditionInterface}[] {varName});");
                WriteLine($"if({lengthVarName} > 0)");
                WriteLine( "{");
                WriteLine($"    m_Count += {lengthVarName};");
                WriteLine($"    TypeToIndex[typeof({data.Type})] = {typeIndexVar};");
                WriteLine( "    var list = new List<Dictionary<int, float>>();");
                WriteLine($"    list.Fill({lengthVarName});");
                WriteLine($"    AllRatings.Add(list);");
                // we need to keep track of which index is associated with semantic tags,
                // in order to provide exclusive tags functionality
                if(data.Type == typeof(bool))
                    WriteLine($"    {tagListIndexVar} = {typeIndexVar};");
                WriteLine($"    {typeIndexVar}++;");
                WriteLine( "}");

                return DumpBufferContents();
            });
            ChangeIndent(2);
        }
    }
}
