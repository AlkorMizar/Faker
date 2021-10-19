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
    public class ArrayGeneratorTests
    {

        IValueGenerator generator;
        IFaker faker;
        Random random;

        [TestInitialize]
        public void Initialize()
        {
            generator = ArrayGenerator.GetInstance();
            faker = new Faker();
            random = new Random();
        }
        [TestMethod()]
        public void CanGenerateTest_ArrayOneDimensionType_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(object[])));
        }

        [TestMethod()]
        public void CanGenerateTest_ArraySeveralDimensionsType_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(object[,,])));
        }

        [TestMethod()]
        public void CanGenerateTest_JaggedArrayType_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(object[][])));
        }

        [TestMethod()]
        public void CanGenerateTest_NotArrayType_True()
        {
            Assert.IsFalse(generator.CanGenerate(typeof(string)));
        }

        [TestMethod()]
        public void GenerateTest_ArrayOneDimensionType_NotNullObject()
        {
            var context = new GeneratorContext(random,typeof(object[]),faker);
            var result = generator.Generate(context);
            Assert.IsTrue(result is object[]);
            Assert.IsNotNull((result as object[])[0]);
        }
        [TestMethod()]
        public void GenerateTest_ArraySeveralDimensionsType_NotNullObject()
        {
            var context = new GeneratorContext(random, typeof(object[,,]), faker);
            var result = generator.Generate(context);
            Assert.IsTrue(result is object[,,] );
            Assert.IsNotNull((result as object[,,])[0,0,0]);
        }
        [TestMethod()]
        public void GenerateTest_JaggedArrayType_NotNullObject()
        {
            var context = new GeneratorContext(random, typeof(object[][]), faker);
            var result = generator.Generate(context);
            Assert.IsTrue(result is object[][]);
            Assert.IsNotNull((result as object[][])[0][0]);
        }
    }
}