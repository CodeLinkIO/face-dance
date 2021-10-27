using System.IO;
using NUnit.Framework;
using Unity.Properties;

namespace Unity.Serialization.Json.Tests
{
    partial class JsonSerializationTests
    {
        [GeneratePropertyBag]
        class ClassWithSystemIOTypes
        {
            public FileInfo FieldInfo;
            public DirectoryInfo DirectoryInfo;
        }
        
        [Test]
        public void ClassWithSystemIOTypes_WhenValuesAreNotNull_CanBeSerializedAndDeserialized()
        {
            var src = new ClassWithSystemIOTypes
            {
                FieldInfo = new FileInfo("a/b/c"),
                DirectoryInfo = new DirectoryInfo("d/e/f")
            };

            var dst = SerializeAndDeserialize(src);
            
            Assert.That(dst.FieldInfo.FullName, Is.EqualTo(src.FieldInfo.FullName));
            Assert.That(dst.DirectoryInfo.FullName, Is.EqualTo(src.DirectoryInfo.FullName));
        }

        [Test]
        public void ClassWithSystemIOTypes_WhenValuesAreNull_CanBeSerializedAndDeserialized()
        {
            var src = new ClassWithSystemIOTypes();

            var dst = SerializeAndDeserialize(src);
            
            Assert.That(dst.FieldInfo, Is.EqualTo(src.FieldInfo));
            Assert.That(dst.DirectoryInfo, Is.EqualTo(src.DirectoryInfo));
        }
    }
}