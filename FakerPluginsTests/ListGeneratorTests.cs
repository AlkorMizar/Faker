using FakerPlugins;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FakerInterfaces;
using FakerAPI.API;
using System;

namespace FakerPlugins.Tests
{
    [TestClass()]
    public class ListGeneratorTests
    {
        IValueGenerator generator;
        IFaker faker;

        [TestInitialize]
        public void Initialize()
        {
            generator = ListGenerator.GetInstance();
            faker = new Faker();
        }
        [TestMethod()]
        public void CanGenerateTest_ListType_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(List<List<string>>)));
        }

        [TestMethod()]
        public void CanGenerateTest_NotListType_False()
        {
            Assert.IsFalse(generator.CanGenerate(typeof(LinkedList<>)));
        }

        [TestMethod()]
        public void GenerateTest_Context_NotNullObject()
        {
            var context = new GeneratorContext(new Random(), typeof( List<object> ), faker);
            var result = generator.Generate(context);
            Assert.IsTrue(result is List<object>);
            Assert.IsNotNull((result as List<object>) != default(object));
        }
    }
}