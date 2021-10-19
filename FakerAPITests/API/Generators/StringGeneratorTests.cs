using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakerAPI.API.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakerInterfaces;

namespace FakerAPI.API.Generators.Tests
{
    [TestClass()]
    public class StringGeneratorTests
    {
        IValueGenerator generator;
        IFaker faker;
        Random random;

        [TestInitialize]
        public void Initialize()
        {
            generator = StringGenerator.GetInstance();
            faker = new Faker();
            random = new Random();
        }

        [TestMethod()]
        public void CanGenerateTest_StringType_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(string)));
        }

        [TestMethod()]
        public void CanGenerateTest_NotStringType_False()
        {
            Assert.IsFalse(generator.CanGenerate(typeof(char[])));
        }

        [TestMethod()]
        public void GenerateTest_Context_NotNullObject()
        {
            var context = new GeneratorContext(random,typeof(string),faker);
            var result1 = generator.Generate(context);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 is string);
            var result2 = generator.Generate(context);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2 is string);
            Assert.IsTrue(!result1.Equals(result2));
        }
    }
}