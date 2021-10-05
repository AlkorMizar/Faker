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
            
            if (type.IsPrimitive)
            {
                return CreateValueType(Type.GetTypeCode(type));
            }
            else if (type.IsEnum) {
                return CreateEnum(type);
            }else
            {
                object result;
                ConstructorInfo[] constructorInfos = type.GetConstructors();
                if (constructorInfos.Length != 0)
                {
                    ConstructorInfo maxParamConstructor = constructorInfos[0];
                    ParameterInfo[] maxParamInfo = maxParamConstructor.GetParameters();
                    foreach (var info in constructorInfos)
                    {
                        if (info.GetParameters().Length > maxParamInfo.Length)
                        {
                            maxParamConstructor = info;
                            maxParamInfo = info.GetParameters();
                        }
                    }
                    object[] parameters = new object[maxParamInfo.Length];
                    for (int i = 0; i < maxParamInfo.Length; i++)
                    {
                        parameters[i] = Create(maxParamInfo[i].ParameterType);
                    }
                    result = Activator.CreateInstance(type, parameters);
                }
                else 
                {
                    result = Activator.CreateInstance(type);
                }
                PropertyInfo[] propertyInfo = type.GetProperties();
                foreach (var property in propertyInfo)
                {
                    if (property.CanRead && property.GetValue(result)!=null && property.CanWrite) {
                        property.SetValue(result,Create(property.PropertyType));
                    }
                }
                FieldInfo[] fieldInfos = type.GetFields();
                foreach (var field in fieldInfos)
                {

                    field.SetValue(result, Create(field.FieldType));
                }

            }
            return null;
        }

        private object CreateValueType(TypeCode type)
        {
            switch (type) {
                case TypeCode.Boolean: {
                     return CreateBoolean();
                }
                case TypeCode.Byte:
                {
                    return CreateByte();
                }
                case TypeCode.SByte:
                {
                    return CreateSbyte();
                }
                case TypeCode.Char:
                {
                    return CreateChar();
                }
                case TypeCode.Int16:
                {
                    return CreateShort();
                }
                case TypeCode.UInt16:
                {
                    return CreateUShort();
                }
                case TypeCode.Int32:
                {
                    return CreateInt();
                }
                case TypeCode.UInt32:
                {
                    return CreateUInt();
                }
                case TypeCode.Int64:
                {
                    return CreateLong();
                }
                case TypeCode.UInt64:
                {
                    return CreateULong();
                }
                case TypeCode.Single:
                {
                    return CreateFloat();
                }
                case TypeCode.Double:
                {
                    return CreateDouble();
                }
                case TypeCode.Decimal:
                {
                    return CreateDecimal();
                }
                default:
                    return null;
            }
            
        }

        private bool CreateBoolean() {
            return rnd.Next() > rnd.Next();
        }
        private byte CreateByte()
        {
            return (byte)rnd.Next();
        }

        private sbyte CreateSbyte()
        {
            return (sbyte)rnd.Next();
        }
        private char CreateChar()
        {
            return (char)rnd.Next();
        }

        private short CreateShort()
        {
            return (short)rnd.Next();
        }

        private ushort CreateUShort()
        {
            return (ushort)rnd.Next();
        }

        private int CreateInt() {
            return rnd.Next();
        }

        private uint CreateUInt()
        {
            return (uint)rnd.Next();
        }

        private long CreateLong()
        {
            return (long)rnd.Next() * (long)rnd.Next();
        }

        private ulong CreateULong()
        {
            return ((ulong)rnd.Next()) * ((ulong)rnd.Next());
        }

        private float CreateFloat()
        {
            return (float)rnd.NextDouble()*rnd.Next();
        }

        private double CreateDouble()
        {
            return rnd.NextDouble()*rnd.Next();
        }
        private decimal CreateDecimal()
        {
            return(decimal) rnd.NextDouble() / rnd.Next() * rnd.Next();
        }

        private object CreateEnum(Type type) {
            string[] enumConst = Enum.GetNames(type);
            int ind = rnd.Next() % enumConst.Length;
            return Enum.Parse(type, enumConst[ind]);
        }
            
    }
}
