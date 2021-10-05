using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FakerAPI.API
{
    class Faker
    {
        Random rnd;
        public T Create<T>() {
            return (T)Create(typeof(T));
        }

        private object Create(Type type) {
            if (type.IsValueType)
            {

            }
            else
            {
                ConstructorInfo[] constructorInfos = type.GetConstructors();
            }
        }

        private void Create(out bool result)
        {
            result = rnd.Next() >= rnd.Next();
        }

        private void Create(out byte result)
        {
            result = (byte)rnd.Next();
        }

        private void Create(out sbyte result)
        {
            result = (sbyte)rnd.Next();
        }

        private void Create(out char result)
        {
            result = (char)rnd.Next();
        }

        private void Create(out short result)
        {
            result = (short)rnd.Next();
        }

        private void Create(out ushort result)
        {
            result = (ushort)rnd.Next();
        }

        private void Create(out int result) {
            result = rnd.Next();
        }

        private void Create(out uint result)
        {
            result = (uint)rnd.Next();
        }

        private void Create(out long result)
        {
            result = rnd.Next();
            result = result * rnd.Next();
        }

        private void Create(out ulong result)
        {
            result = ((ulong)rnd.Next());
            result = (result * ((ulong)rnd.Next()));
        }

        private void Create(out float result)
        {
            result =(float)rnd.NextDouble()*rnd.Next();
        }

        private void Create(out double result)
        {
            result = rnd.NextDouble()*rnd.Next();
        }
        private void Create(out decimal result)
        {
            result =(decimal) rnd.NextDouble() / rnd.Next() * rnd.Next();
        }
    }
}
