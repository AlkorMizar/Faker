using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerAPI.API.Generators
{
    class EnumGenerator : IValueGenerator
    {
        private static EnumGenerator instace;
        private EnumGenerator() { }
        public bool CanGenerate(Type type)
        {
            return type.IsEnum;
        }

        public object Generate(GeneratorContext context)
        {
            string[] enumConst = Enum.GetNames(context.TargetType);
            int ind = context.Random.Next();
            ind = ind % enumConst.Length;
            return Enum.Parse(context.TargetType, enumConst[ind]);
        }
        public static IValueGenerator GetInstance()
        {
            if (instace == null) {
                instace = new EnumGenerator();
            }
            return instace;
        }
    }
}
