using Unity.MARS.Data;

namespace Unity.MARS.CodeGen
{
    class ResultFillCodeGenerator : BaseCodeGenerator
    {
        const string k_TemplateFileName = "ResultFillStage.Template.txt";
        const string k_OutputFileName = "ResultFillStage.Generated.cs";

        public override string TemplateFileName => k_TemplateFileName;
        public override string OutputFileName => k_OutputFileName;

        public override bool TryGenerateCode(CodeGenerationTypeData[] typeData)
        {
            WriteFillQueryResult(typeData);
            BufferContents = BufferContents.Replace("{TraitCollectionClassName}", nameof(CachedTraitCollection));
            return TryWriteToFile();
        }

        void WriteFillQueryResult(CodeGenerationTypeData[] typeData)
        {
            ChangeIndent(3);
            const string toReplace = "{FillQueryResult_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                if (data.Type == typeof(bool))
                    return "";

                var typeName = data.Type.FullName;
                var prefix = data.LocalVarPrefix;
                var iCondition = GetConditionTypeInterface(data.Type);
                var traitsVar = $"{prefix}Collections";
                var conditionsVar = $"{prefix}Conditions";
                WriteLine($"traits.TryGetType(out List<Dictionary<int, {typeName}>> {traitsVar});");
                WriteLine($"conditions.TryGetType(out {iCondition}[] {conditionsVar});");
                WriteLine($"FillQueryResult<{typeName}>(dataId, {conditionsVar}, {traitsVar}, result);");

                return DumpBufferContents();
            });
            ChangeIndent(2);
        }
    }
}
