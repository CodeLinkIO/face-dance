namespace Unity.MARS.CodeGen
{
    class PoolsCodeGenerator : BaseCodeGenerator
    {
        const string k_TemplateFileName = "Pools.Template.txt";
        const string k_OutputFileName = "Pools.Generated.cs";

        public override string TemplateFileName => k_TemplateFileName;
        public override string OutputFileName => k_OutputFileName;

        public override bool TryGenerateCode(CodeGenerationTypeData[] typeData)
        {
            WriteDictionaryPools(typeData);
            return TryWriteToFile();
        }

        static string GetBacking(CodeGenerationTypeData data)
        {
            return $"{data.MemberPrefix}Results";
        }

        void WriteDictionaryPools(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{Dictionary_PROPERTIES}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                var typeName = $"QueryResultDictionaryPool<{data.Type.FullName}>";
                WriteLine($"public static {typeName} {GetBacking(data)}");
                WriteLine($"    = new {typeName}();");

                return DumpBufferContents();
            });
        }
    }
}
