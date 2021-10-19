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
    public class PrimitiveValGeneratorTests
    {
        IValueGenerator generator;
        IFaker faker;
        Random random;

        [TestInitialize]
        public void Initialize()
        {
            generator = PrimitiveValGenerator.GetInstance();
            faker = new Faker();
            random = new Random();
        }

        [TestMethod()]
        public void CanGenerateTest_Char_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(char)));
        }

        [TestMethod()]
        public void CanGenerateTest_bool_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(bool)));
        }

        [TestMethod()]
        public void CanGenerateTest_Byte_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(byte)));
        }

        [TestMethod()]
        public void CanGenerateTest_sbyte_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(sbyte)));
        }

        [TestMethod()]
        public void CanGenerateTest_short_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(short)));
        }

        [TestMethod()]
        public void CanGenerateTest_ushort_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(ushort)));
        }

        [TestMethod()]
        public void CanGenerateTest_int_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(int)));
        }

        [TestMethod()]
        public void CanGenerateTest_uint_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(uint)));
        }
        [TestMethod()]
        public void CanGenerateTest_long_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(long)));
        }

        [TestMethod()]
        public void CanGenerateTest_ulong_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(ulong)));
        }

        [TestMethod()]
        public void CanGenerateTest_float_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(float)));
        }

        [TestMethod()]
        public void CanGenerateTest_double_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(double)));
        }

        [TestMethod()]
        public void CanGenerateTest_decimal_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(decimal)));
        }

        [TestMethod()]
        public void CanGenerateTest_object_False()
        {
            Assert.IsFalse(generator.CanGenerate(typeof(object)));
        }

        [TestMethod()]
        public void GenerateTest_Char_True()
        {
            var context = new GeneratorContext(random, typeof(char),faker);
            var result = generator.Generate(context);
            Assert.IsTrue(result is not null && result is char);
        }

        [TestMethod()]
        public void GenerateTest_bool_True()
        {
            var context = new GeneratorContext(random, typeof(bool), faker);
            var result = generator.Generate(context);
            Assert.IsTrue(result is not null && result is bool);
        }

        [TestMethod()]
        public void GenerateTest_Byte_True()
        {
            var context = new GeneratorContext(random, typeof(byte), faker);
            var result1 = generator.Generate(context);
            var result2 = generator.Generate(context);
            Assert.IsTrue(result1 is not null && result1 is byte);
            Assert.IsTrue(result2 is not null && result2 is byte);
            Assert.IsTrue(!result1.Equals(result2));
        }

        [TestMethod()]
        public void GenerateTest_sbyte_True()
        {
            var context = new GeneratorContext(random, typeof(sbyte), faker);
            var result1 = generator.Generate(context);
            Assert.IsTrue(result1 is not null && result1 is sbyte);
            var result2 = generator.Generate(context);
            Assert.IsTrue(result2 is not null && result2 is sbyte);
            Assert.IsTrue(!result1.Equals(result2));
        }

        [TestMethod()]
        public void GenerateTest_short_True()
        {
            var context = new GeneratorContext(random, typeof(short), faker);
            var result1 = generator.Generate(context);
            Assert.IsTrue(result1 is not null && result1 is short);
            var result2 = generator.Generate(context);
            Assert.IsTrue(result2 is not null && result2 is short);
            Assert.IsTrue(!result1.Equals(result2));
        }

        [TestMethod()]
        public void GenerateTest_ushort_True()
        {
            var context = new GeneratorContext(random, typeof(ushort), faker);
            var result1 = generator.Generate(context);
            Assert.IsTrue(result1 is not null && result1 is ushort);
            var result2 = generator.Generate(context);
            Assert.IsTrue(result2 is not null && result2 is ushort);
            Assert.IsTrue(!result1.Equals(result2));
        }

        [TestMethod()]
        public void GenerateTest_int_True()
        {
            var context = new GeneratorContext(random, typeof(int), faker);
            var result1 = generator.Generate(context);
            Assert.IsTrue(result1 is not null && result1 is int);
            var result2 = generator.Generate(context);
            Assert.IsTrue(result2 is not null && result2 is int);
            Assert.IsTrue(!result1.Equals(result2));
        }

        [TestMethod()]
        public void GenerateTest_uint_True()
        {
            var context = new GeneratorContext(random, typeof(uint), faker);
            var result1 = generator.Generate(context);
            Assert.IsTrue(result1 is not null && result1 is uint);
            var result2 = generator.Generate(context);
            Assert.IsTrue(result2 is not null && result2 is uint);
            Assert.IsTrue(!result1.Equals(result2));
        }
        [TestMethod()]
        public void GenerateTest_long_True()
        {
            var context = new GeneratorContext(random, typeof(long), faker);
            var result1 = generator.Generate(context);
            Assert.IsTrue(result1 is not null && result1 is long);
            var result2 = generator.Generate(context);
            Assert.IsTrue(result2 is not null && result2 is long);
            Assert.IsTrue(!result1.Equals(result2));
        }

        [TestMethod()]
        public void GenerateTest_ulong_True()
        {
            var context = new GeneratorContext(random, typeof(ulong), faker);
            var result1 = generator.Generate(context);
            Assert.IsTrue(result1 is not null && result1 is ulong);
            var result2 = generator.Generate(context);
            Assert.IsTrue(result2 is not null && result2 is ulong);
            Assert.IsTrue(!result1.Equals(result2));
        }

        [TestMethod()]
        public void GenerateTest_float_True()
        {
            var context = new GeneratorContext(random, typeof(float), faker);
            var result1 = generator.Generate(context);
            Assert.IsTrue(result1 is not null && result1 is float);
            var result2 = generator.Generate(context);
            Assert.IsTrue(result2 is not null && result2 is float);
            Assert.IsTrue(!result1.Equals(result2));
        }

        [TestMethod()]
        public void GenerateTest_double_True()
        {
            var context = new GeneratorContext(random, typeof(double), faker);
            var result1 = generator.Generate(context);
            Assert.IsTrue(result1 is not null && result1 is double);
            var result2 = generator.Generate(context);
            Assert.IsTrue(result2 is not null && result2 is double);
            Assert.IsTrue(!result1.Equals(result2));
        }

        [TestMethod()]
        public void GenerateTest_decimal_True()
        {
            var context = new GeneratorContext(random, typeof(decimal), faker);
            var result1 = generator.Generate(context);
            Assert.IsTrue(result1 is not null && result1 is decimal);
            var result2 = generator.Generate(context);
            Assert.IsTrue(result2 is not null && result2 is decimal);
            Assert.IsTrue(!result1.Equals(result2));
        }
    }
}