using FakerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerAPI.API.Generators
{
    public class PrimitiveValGenerator : IValueGenerator
    {
        private static PrimitiveValGenerator instance;
        private PrimitiveValGenerator() { }
        public bool CanGenerate(Type type)
        {
            return type.IsPrimitive || Type.GetTypeCode(type) == TypeCode.Decimal;
        }

        public object Generate(IGeneratorContext context)
        {
            switch (Type.GetTypeCode(context.TargetType))
            {
                case TypeCode.Boolean:
                    {
                        return CreateBoolean(context);
                    }
                case TypeCode.Byte:
                    {
                        return CreateByte(context);
                    }
                case TypeCode.SByte:
                    {
                        return CreateSbyte(context);
                    }
                case TypeCode.Char:
                    {
                        return CreateChar(context);
                    }
                case TypeCode.Int16:
                    {
                        return CreateShort(context);
                    }
                case TypeCode.UInt16:
                    {
                        return CreateUShort(context);
                    }
                case TypeCode.Int32:
                    {
                        return CreateInt(context);
                    }
                case TypeCode.UInt32:
                    {
                        return CreateUInt(context);
                    }
                case TypeCode.Int64:
                    {
                        return CreateLong(context);
                    }
                case TypeCode.UInt64:
                    {
                        return CreateULong(context);
                    }
                case TypeCode.Single:
                    {
                        return CreateFloat(context);
                    }
                case TypeCode.Double:
                    {
                        return CreateDouble(context);
                    }
                case TypeCode.Decimal:
                    {
                        return CreateDecimal(context);
                    }
                default:
                    return null;
            }

        }

        private bool CreateBoolean(IGeneratorContext context)
        {
            return context.Random.Next() > context.Random.Next();
        }
        private byte CreateByte(IGeneratorContext context)
        {
            return (byte)context.Random.Next();
        }

        private sbyte CreateSbyte(IGeneratorContext context)
        {
            return (sbyte)context.Random.Next();
        }
        private char CreateChar(IGeneratorContext context)
        {
            return (char)context.Random.Next();
        }

        private short CreateShort(IGeneratorContext context)
        {
            return (short)context.Random.Next();
        }

        private ushort CreateUShort(IGeneratorContext context)
        {
            return (ushort)context.Random.Next();
        }

        private int CreateInt(IGeneratorContext context)
        {
            return context.Random.Next();
        }

        private uint CreateUInt(IGeneratorContext context)
        {
            return (uint)context.Random.Next();
        }

        private long CreateLong(IGeneratorContext context)
        {
            return (long)context.Random.Next() * (long)context.Random.Next();
        }

        private ulong CreateULong(IGeneratorContext context)
        {
            return ((ulong)context.Random.Next()) * ((ulong)context.Random.Next());
        }

        private float CreateFloat(IGeneratorContext context)
        {
            return (float)context.Random.NextDouble() * context.Random.Next();
        }

        private double CreateDouble(IGeneratorContext context)
        {
            return context.Random.NextDouble() * context.Random.Next();
        }
        private decimal CreateDecimal(IGeneratorContext context)
        {
            return (decimal)context.Random.NextDouble() / context.Random.Next() * context.Random.Next();
        }
        public static IValueGenerator GetInstance()
        {
            if (instance == null)
            {
                instance = new PrimitiveValGenerator();
            }
            return instance;
        }
    }
}
