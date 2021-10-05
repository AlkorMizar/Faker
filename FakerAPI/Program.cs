using System;
using System.Collections.Generic;
using System.Reflection;

namespace FakerAPI
{
    struct str {
        int a;
        int b;
        public str( int sd) {
            a = 10;
            b = 1;
        }
    }

    class a {
        public int aaa;
        public string b;
        public string AAA { get; }
        public a() {
            aaa = 1;
        }
    }

    class Program
    {
        private String val = "test";

        public static void Main()
        {
            a aa = new a();
            var fld = typeof(a).GetProperty("AAA");
            if (fld.GetValue(aa) == null) {
                Console.WriteLine();
            }
            double h = default(double);
            Console.WriteLine(fld.GetValue(aa));
        }
    }
}
