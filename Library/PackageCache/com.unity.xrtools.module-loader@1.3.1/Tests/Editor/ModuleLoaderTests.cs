using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.XRTools.ModuleLoader;

namespace UnityEditor.XRTools.ModuleLoader.Tests
{
    class ModuleLoaderTests
    {
        [ModuleOrder(0)]
        class TestModule1 : IModule
        {
            void IModule.LoadModule() { }
            void IModule.UnloadModule() { }
        }

        [ModuleOrder(1)]
        class TestModule2 : IModule
        {
            void IModule.LoadModule() { }
            void IModule.UnloadModule() { }
        }

        [ModuleOrder(2)]
        class TestModule3 : IModule
        {
            void IModule.LoadModule() { }
            void IModule.UnloadModule() { }
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            ModuleLoaderCore.instance.UnloadModules();
            ModuleLoaderCore.instance.LoadModulesWithTypes(new List<Type>
                { typeof(TestModule3), typeof(TestModule1), typeof(TestModule2) });
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            ModuleLoaderCore.instance.ReloadModules();
        }

        [Test]
        public void ModuleOrderTest()
        {
            var modules = ModuleLoaderCore.instance.modules;
            var module1Index = modules.IndexOf(modules.OfType<TestModule1>().First());
            var module2Index = modules.IndexOf(modules.OfType<TestModule2>().First());
            var module3Index = modules.IndexOf(modules.OfType<TestModule3>().First());
            Assert.Less(module1Index, module2Index);
            Assert.Less(module2Index, module3Index);
        }
    }
}
