namespace Unity.MARS.CodeGen
{
    class QueryResultCodeGenerator : BaseCodeGenerator
    {
        protected const string k_TemplateFileName = "QueryResult.Template.txt";
        protected const string k_OutputFileName = "QueryResult.Generated.cs";

        public override string TemplateFileName => k_TemplateFileName;
        public override string OutputFileName => k_OutputFileName;

        public override bool TryGenerateCode(CodeGenerationTypeData[] typeData)
        {
            WriteBackingValueFieldsBlock(typeData);
            WriteTryGetTraitBlock(typeData);
            WriteSetTraitBlock(typeData);
            WriteClearBlock(typeData);
            return TryWriteToFile();
        }

        void WriteTryGetTraitBlock(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{TryGetTrait_METHODS}";
            WriteBlock(toReplace, typeData, WriteTryGetTraitMethod);
        }

        void WriteSetTraitBlock(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{SetTrait_METHODS}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                var backingField = GetBackingFieldName(data);
                var pool = CodeGenerationShared.GetDictionaryPool(data);

                WriteLine($"public void SetTrait(string traitName, {data.Type.FullName} value)");
                WriteLine( "{");
                WriteLine($"    if(!{backingField}.TryGetValue(this, out var typeValues))");
                WriteLine( "    {");
                WriteLine($"        typeValues = {pool}.Get();");
                WriteLine($"        {backingField}[this] = typeValues;");
                WriteLine( "    }");
                WriteLine();
                WriteLine( "    typeValues[traitName] = value;");
                WriteLine( "}");

                return DumpBufferContents();
            });
        }

        string WriteTryGetTraitMethod(CodeGenerationTypeData typeData)
        {
            k_WriteBuilder.Clear();
            var type = typeData.Type;

            WriteSummary($"Get the value for a trait of type {type} in this query");

            WriteLine($"public bool TryGetTrait(string traitName, out {type.FullName} value)");
            WriteLine( "{");
            WriteLine($"    if(!{GetBackingFieldName(typeData)}.TryGetValue(this, out var typeValues))");
            WriteLine( "    {");
            WriteLine( "        value = default;");
            WriteLine( "        return false;");
            WriteLine( "    }");
            WriteLine();
            WriteLine( "    if(!typeValues.TryGetValue(traitName, out value))");
            WriteLine( "    {");
            WriteLine( "        value = default;");
            WriteLine( "        return false;");
            WriteLine( "    }");
            WriteLine();
            WriteLine( "    return true;");
            WriteLine( "}");

            return DumpBufferContents();
        }

        void WriteBackingValueFieldsBlock(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{BackingValue_FIELDS}";
            WriteBlock(toReplace, typeData, WriteBackingCollection);
        }

        static string GetBackingFieldName(CodeGenerationTypeData typeData)
        {
            return $"{typeData.MemberPrefix}Values";
        }

        void WriteClearBlock(CodeGenerationTypeData[] typeData)
        {
            const string toReplace = "{Clear_METHOD}";
            WriteBlock(toReplace, typeData, (data) =>
            {
                var property = GetBackingFieldName(data);
                WriteLine($"    if({property}.ContainsKey(result))");
                WriteLine($"        {property}.Remove(result);");

                return DumpBufferContents();
            });
        }

        /*
         *  each type is backed by a static dictionary-of-dictionaries, like
         *  static readonly Dictionary<QueryMatchID, Dictionary<string, T>> {TypeName}Values
         */
        string WriteBackingCollection(CodeGenerationTypeData typeData)
        {
            k_WriteBuilder.Clear();
            var type = typeData.Type;
            var concreteType = $"Dictionary<QueryResult, Dictionary<string, {type.FullName}>>";

            WriteSummary($"Values for all matched queries' results of type {type.Name}");
            WriteLine($"internal static readonly {concreteType} {GetBackingFieldName(typeData)} = ");
            WriteLine($"    new {concreteType}();");

            return DumpBufferContents();
        }
    }
}
