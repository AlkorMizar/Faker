using FakerAPI.API;
using FakerInterfaces;
using System;

namespace FakerAPI
{
    struct b {
        public int a; 
    }
    class Program
    {
        public static void Main()
        {
            IFaker faker = new Faker();
            var s = faker.Create<b>();
            var test = faker.Create<Class>();
            Console.WriteLine(test);
            var a = faker.Create<A>();
            Console.WriteLine(a);
        }
    }
}
