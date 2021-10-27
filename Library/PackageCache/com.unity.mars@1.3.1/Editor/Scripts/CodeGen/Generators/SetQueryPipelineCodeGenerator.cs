namespace Unity.MARS.CodeGen
{
    class SetQueryPipelineCodeGenerator : BaseCodeGenerator
    {
        const string k_TemplateFileName = "GroupQueryPipeline.Template.txt";
        const string k_OutputFileName = "GroupQueryPipeline.Generated.cs";

        public override string TemplateFileName => k_TemplateFileName;
        public override string OutputFileName => k_OutputFileName;

        public override GeneratedTypeSet TypeSet => GeneratedTypeSet.Relations;

        public override bool TryGenerateCode(CodeGenerationTypeData[] typeData)
        {
            WriteGetAllIndexPairs(typeData);
            return TryWriteToFile();
        }

        void WriteGetAllIndexPairs(CodeGenerationTypeData[] codeGenerationTypeData)
        {
            ChangeIndent(3);
            const string toReplace = "{GetAllIndexPairs_METHOD}";
            WriteBlock(toReplace, codeGenerationTypeData, (data) =>
            {
                if (data.Type == typeof(bool))
                    return "";

                var prefix = data.LocalVarPrefix;
                var iRelation = GetRelationTypeInterface(data.Type);
                var relationsVar = $"{prefix}Relations";
                WriteLine($"if(relations.TryGetType(out {iRelation}[] {relationsVar}))");
                WriteLine($"    GetIndexPairs(id, {relationsVar});");

                return DumpBufferContents();
            });
            ChangeIndent(2);
        }
    }
}
