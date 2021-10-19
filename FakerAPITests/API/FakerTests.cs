using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using FakerInterfaces;

namespace FakerAPI.API.Tests
{
    [TestClass()]
    public class FakerTests
    {
        IFaker faker;
        Random random;

        [TestInitialize]
        public void Initialize()
        {
            faker = new Faker();
            random = new Random();
        }
        [TestMethod()]
        public void Create_Composit_NotNullObject()
        {
            var result = faker.Create<List<ListELemWithStructAndString[]>>();
            Assert.IsNotNull(result);
            var listElem = result.ElementAt<ListELemWithStructAndString[]>(0);
            Assert.IsNotNull(listElem);
            Assert.IsNotNull(listElem[0]);
            Assert.IsTrue(listElem[0].NumOfConstructor == 4);
            Assert.IsNotNull(listElem[0].Str);
            Assert.IsTrue(!listElem[0].fieldStruct.Equals(default(StructWithEnumAndDataTime)));
            Assert.IsTrue(!listElem[0].PropertyStruct.Equals(default(StructWithEnumAndDataTime)));
        }

        [TestMethod()]
        public void Create_Cycled_NotNullObject()
        {
            var expected = "ABCABCABCABC";
            var result = faker.Create<A>();
            Assert.AreEqual(result.ToString(), expected);
        }
    }
}