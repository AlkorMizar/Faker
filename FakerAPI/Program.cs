using FakerAPI.API;
using FakerInterfaces;
using System;

namespace FakerAPI
{
    class Program
    {
        public static void Main()
        {
            IFaker faker = new Faker();
            var test = faker.Create<Class>();
            Console.WriteLine(test);
            var a = faker.Create<A>();
            Console.WriteLine(a);
        }
    }
}
