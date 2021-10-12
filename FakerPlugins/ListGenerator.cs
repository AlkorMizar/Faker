using FakerInterfaces;
using System;
using System.Collections.Generic;

namespace FakerPlugins
{
    public class ListGenerator : IValueGenerator
    {
        private static ListGenerator instance;
        private ListGenerator() { }
        public bool CanGenerate(Type type)
        {
            return type.Name ==typeof(List<>).Name;
        }

        public object Generate(IGeneratorContext context)
        {
            int length = (byte)context.Random.Next() + 1;
            var obj =Activator.CreateInstance(context.TargetType);
            var method=context.TargetType.GetMethod("Add");
            while (length-- > 0)
            {
                method.Invoke(obj, new object[] { context.Faker.Create(context.TargetType.GetGenericArguments()[0]) });
            }
            return obj;
        }

        public static IValueGenerator GetInstance()
        {
            if (instance == null)
            {
                instance = new ListGenerator();
            }
            return instance;
        }
    }
}
