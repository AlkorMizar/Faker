using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakerPlugins;
using System;
using System.Collections.Generic;
using System.Text;
using FakerInterfaces;
using FakerAPI.API;

namespace FakerPlugins.Tests
{
    [Flags]
    enum EmTest { 
        Red    = 0b_0000_0001,
        White  = 0b_0000_0010,
        Green  = 0b_0000_0100,
        Blue   = 0b_0000_1000,
        Pink   = 0b_0001_0000,
        Black  = 0b_0010_0010,
        Purple = 0b_0100_0100,
        Gray   = 0b_1000_1000,
    }

    [TestClass()]
    public class EnumGeneratorTests
    {
        IValueGenerator generator;

        [TestInitialize]
        public void Initialize() {
            generator = EnumGenerator.GetInstance();
        }

        [TestMethod()]
        public void CanGenerateTest_EnumType_True()
        {
            Assert.IsTrue(generator.CanGenerate(typeof(EmTest)));
        }

        [TestMethod()]
        public void CanGenerateTest_NotEnumType_False()
        {
            Assert.IsFalse(generator.CanGenerate(typeof(object)));
        }

        [TestMethod()]
        public void GenerateTest_Context_EnumWithNotDefaultValue()
        {
            IGeneratorContext context = new GeneratorContext(new Random(), typeof(EmTest), null);
            int tryCount = 15;
            while (tryCount-- > 0 && (EmTest)generator.Generate(context) == default(EmTest)) ;
            Assert.IsTrue(tryCount > 0);
        }
    }
}