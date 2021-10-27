using NUnit.Framework;
using Unity.Collections;
using Unity.Properties;
using Unity.Serialization.Tests;

namespace Unity.Serialization.Json.Tests
{
    partial class JsonSerializationTests
    {
        [TestFixture]
        class Allocations
        {
            [GeneratePropertyBag]
            struct StructWithInt32Property
            {
                public int Int32Property { get; set; }
                public float Float32Property { get; set; }
            }

            [Test]
            public void ToJson_StructWithInt32Property_DoesNotAllocate()
            {
                var container = new StructWithInt32Property();
                GCAllocTest.Method(() =>
                           {
                               using (var writer = new JsonStringBuffer(16, Allocator.Temp))
                               {
                                   JsonSerialization.ToJson(writer, container);
                               }
                           })
                           .ExpectedCount(0)
                           .Warmup()
                           .Run();
            }
            
            [Test]
            public void FromJson_StructWithInt32Property_DoesNotAllocate()
            {
                var json = "{\"Int32Property\": 42}";
                
                GCAllocTest.Method(() => { JsonSerialization.FromJson<StructWithInt32Property>(json); })
                           .ExpectedCount(0)
                           .Warmup()
                           .Run();
            }
        }
    }
}