namespace Unity.MARS.CodeGen
{
    internal interface IGeneratesCode
    {
        GeneratedTypeSet TypeSet { get; }

        bool TryGenerateCode(CodeGenerationTypeData[] codeGenerationTypeData);
    }
}
