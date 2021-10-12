using FakerAPI.API;
using FakerInterfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace FakerAPI
{
    class Program
    {
        public static void Main()
        {
            IFaker faker = new Faker();
            var test = faker.Create<Class>();
            Console.WriteLine(test);
        }
    }
}
