using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerAPI.API.Generators
{
    class StringGenerator : IValueGenerator
    {
        private static StringGenerator instance;
        private StringGenerator() { }
        public bool CanGenerate(Type type)
        {
            return type==typeof(string);
        }

        public object Generate(GeneratorContext context)
        {
            StringBuilder builder = new StringBuilder();
            int lenght = ((byte)context.Random.Next()) + 1;
            for (int i = 0; i < lenght; i++)
            {
                builder.Append(context.Faker.Create<char>());
            }
            return builder.ToString();
        }

        public static IValueGenerator GetInstance()
        {
            if (instance==null) {
                instance = new StringGenerator();
            }
            return instance;
        }
    }
}
