using FakerAPI.API;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace FakerAPI
{
    struct str {
        public int a;
        int b;
        float bd;
        public string N;
        public object obj;
        public string[,] arr;
    }

    class a {
        public int aaa;
        public string b;
        public string AAA { get; }
        public str AAAA { get; set; }
        public a() {
            aaa = 1;
        }
    }

    class aa {
        int aaa;
        private aa() { }
    }

    enum em { 
        Red,
        White,
        Blue,
        Purple
    }

    class A
    {
        public B  b { get; set; }
}

    class B
    {
        public C  c{ get; set; }
    }

    class C
    {
        public A a { get; set; } // циклическая зависимость, 
                                // может быть на любом уровне вложенности
    }

    class Program
    {
        private String val = "test";

        public static void Main()
        {
            Faker faker = new Faker();
            var a = faker.Create<A>();
            Console.WriteLine(a);
        }
    }
}
