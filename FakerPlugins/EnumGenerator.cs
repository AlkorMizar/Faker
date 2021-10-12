using FakerInterfaces;
using System;

namespace FakerPlugins
{
    public class EnumGenerator : IValueGenerator
    {
        private static EnumGenerator instace;
        private EnumGenerator() { }
        public bool CanGenerate(Type type)
        {
            return type.IsEnum;
        }

        public object Generate(IGeneratorContext context)
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
