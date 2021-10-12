using FakerInterfaces;
using System;
using System.Reflection;

namespace FakerAPI.API.Generators
{
    class ArrayGenerator : IValueGenerator
    {
        private static ArrayGenerator instance;
        private ArrayGenerator() {}
        public bool CanGenerate(Type type)
        {
            return type.IsArray;
        }

        public object Generate(IGeneratorContext context)
        {
            ParameterInfo[] parameterInfo = context.TargetType.GetConstructors()[0].GetParameters();
            object[] parameters = new object[parameterInfo.Length];
            for (int i = 0; i < parameterInfo.Length; i++)
            {
                parameters[i] = ((byte)context.Random.Next())+1;
            }
            Array arr = (Array)Activator.CreateInstance(context.TargetType, parameters);
            var elemContext = new GeneratorContext(context.Random,context.TargetType.GetElementType(), context.Faker);
            FillArray(new int[arr.Rank], arr, 0, elemContext);
            return arr;
        }
        private void FillArray(int[] position, Array arr, int currentRank, GeneratorContext context)
        {
            for (int i = 0; i < arr.GetLength(currentRank); i++)
            {
                position[currentRank] = i;
                if (currentRank == arr.Rank - 1)
                {
                    arr.SetValue(context.Faker.Create(context.TargetType), position);
                }
                else
                {
                    FillArray(position, arr, currentRank + 1, context);
                }
            }
        }

        public static IValueGenerator GetInstance()
        {
            if (instance == null) {
                instance = new ArrayGenerator();
            }
            return instance;
        }
    }
}
