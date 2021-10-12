using FakerAPI.API;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace FakerAPI
{
    class Foo {
        string name;
        
    }
    struct Bar { 
    }
    enum Color
    {

    }
    class Program
    {
        private String val = "test";

        public static void Main()
        {
            IFaker faker = new Faker();
            /*Foo foo = faker.Create<Foo>(); 
            Bar bar = faker.Create<Bar>(); 
            int i = faker.Create<int>();
            // Далее в примерах List носит иллюстративный характер. 
            // Вместо него может быть выбрана любая коллекция из условия.
            List<Foo> foos = faker.Create<List<Foo>>();
            List<List<Foo>> lists = faker.Create<List<List<Foo>>>();
            List<int> ints = faker.Create<List<int>>();*/
            var url = faker.Create<DateTime>();
            faker = new Faker();
        }
    }
}
