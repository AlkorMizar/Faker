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
        public int aaa;
        public aa() { }
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

    struct dick {
        public int key;
        public float val;
    }

    class Program
    {
        private String val = "test";

        public static void Main()
        {
            IFaker faker = new Faker();
            var _int = faker.Create<List<aa>>();
            
        }
    }
}
