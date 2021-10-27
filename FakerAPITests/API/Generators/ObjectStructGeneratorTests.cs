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
    public class ObjectStructGeneratorTests
    {
        IValueGenerator generator;
        IFaker faker;
        Random random;

        [TestInitialize]
        public void Initialize()
        {
            generator = new ObjectStructGenerator();
            faker = new Faker();
            random = new Random();
        }

        [TestMethod()]
        public void CanGenerateTest_Object_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(TestClass)));
        }

        [TestMethod()]
        public void CanGenerateTest_Struct_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(TestStruct)));
        }

        [TestMethod()]
        public void CanGenerateTest_Int_false()
        {
            Assert.IsFalse(generator.CanGenerate(typeof(int)));
        }

        [TestMethod()]
        public void GenerateTest_TestClass_True()
        {
            var context = new GeneratorContext(random, typeof(TestClass), faker);
            var obj = generator.Generate(context);
            var typedObj = obj as TestClass;
            Assert.IsNotNull(typedObj);
            Assert.IsTrue(typedObj.NumberOfConstructor == 3);
            Assert.IsTrue(typedObj.charReadOnlY == 'c');
            Assert.IsTrue(typedObj.UnInitField == default(byte));
            Assert.IsTrue(typedObj.IntProperty != default(int));
            Assert.IsTrue(typedObj.shortField != default(short));
            Assert.IsTrue(typedObj._sbyte != default(sbyte));

        }

        [TestMethod()]
        public void GenerateTest_Struct_True()
        {
            var context = new GeneratorContext(random, typeof(TestStruct), faker);
            var obj = generator.Generate(context);
            Assert.IsTrue(obj is TestStruct);
            var typedObj = (TestStruct)obj;
            Assert.IsNotNull(typedObj);
            Assert.IsTrue(typedObj.NumberOfConstructor == 3);
            Assert.IsTrue(typedObj.charReadOnlY == 'c');
            Assert.IsTrue(typedObj.UnInitField == default(byte));
            Assert.IsTrue(typedObj.IntProperty != default(int));
            Assert.IsTrue(typedObj.shortField != default(short));
            Assert.IsTrue(typedObj._sbyte != default(sbyte));
        }

        [TestMethod()]
        public void CanGenerateTest_DateTime_false()
        {
            var context = new GeneratorContext(random, typeof(DateTime), faker);
            var obj = generator.Generate(context);
            Assert.IsTrue(obj is DateTime);
            var typedObj = (DateTime)obj;
            Assert.IsTrue(typedObj != default(DateTime));
        }

        [TestMethod()]
        public void CanGenerateTest_PrivateConstruct_IsNotNull()
        {
            var context = new GeneratorContext(random, typeof(Private), faker);
            var obj = generator.Generate(context);
            Assert.IsNotNull(obj);
        }
    }

}