using FakerAPI.API.Generators;
using FakerInterfaces;
using System;
using System.Collections.Generic;
using FakerPlugins;

namespace FakerAPI.API
{
    class Faker:IFaker
    {
        Random rnd;
        Stack<IValueGenerator> generators;

        public Faker() {
            rnd = new Random();
            generators = new Stack<IValueGenerator>();
            generators.Push(new ObjectStructGenerator());
            generators.Push(StringGenerator.GetInstance());
            generators.Push(ArrayGenerator.GetInstance());
            generators.Push(ListGenerator.GetInstance());
            generators.Push(PrimitiveValGenerator.GetInstance());
            generators.Push(EnumGenerator.GetInstance());
        }
        T IFaker.Create<T>() {
            return (T)Create(typeof(T));
        }

        object IFaker.Create(Type type)
        {
            return Create(type);
        }


        private object Create(Type type) {
            foreach (var generator in generators)
            {
                if (generator.CanGenerate(type)) {
                    return generator.Generate(new GeneratorContext(rnd, type, this));
                }
            }
            return null;
        }

        

        

        

        

        
    }
}
