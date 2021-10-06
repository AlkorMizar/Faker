using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FakerAPI.API
{
    class Faker
    {
        Random rnd;

        public Faker() {
            rnd = new Random();
        }
        public T Create<T>() {
            return (T)Create(typeof(T));
        }

        private bool IsPrimiteve(Type type) {
            return type.IsPrimitive || Type.GetTypeCode(type)==TypeCode.Decimal;
        }

        private object Create(Type type) {

            if (IsPrimiteve(type))
            {
                return CreateValueType(Type.GetTypeCode(type));
            }
            else if (type.IsEnum)
            {
                return CreateEnum(type);
            }
            else if (type == typeof(string))
            {
                return CreateString();
            } else if (type.IsArray) 
            {
                return CreateArray(type);
            }
            else
            {
                return CreateObject(type);
            }
            
        }

        private object CreateArray(Type type) {
            ParameterInfo[] parameterInfo = type.GetConstructors()[0].GetParameters();
            object[] parameters = new object[parameterInfo.Length];
            for (int i = 0; i < parameterInfo.Length; i++)
            {
                parameters[i] = CreateByte();
            }
            Array arr=(Array)Activator.CreateInstance(type, parameters);
            FillArray(new int[arr.Rank], arr, 0, type.GetElementType());
            return arr;
        }

        private void FillArray(int[] position,Array arr,int currentRank,Type type) {
            for (int i = 0; i < arr.GetLength(currentRank); i++) {
                position[currentRank] = i;
                if (currentRank == arr.Rank-1)
                {
                    arr.SetValue(Create(type), position);
                }
                else {
                    FillArray(position, arr, currentRank + 1,type);
                }
            }
        }

        private bool Checker(Type type, object obj) {
            return obj == null ||
                   (IsPrimiteve(type) && obj.Equals(0)) ||
                   (type.IsValueType && !IsPrimiteve(type));
        }

        private bool CheckProperty(PropertyInfo info, object obj)
        {
            if (info.CanWrite)
            {
                if (info.CanRead)
                {
                    return Checker(info.PropertyType, info.GetValue(obj));
                }
                return true;

            }
            return false;
        }

        private bool CheckField(FieldInfo info, object obj)
        {
            return Checker(info.FieldType, info.GetValue(obj));
        }

        private object InitializeObj(Type type) {
            ConstructorInfo[] constructorInfos = type.GetConstructors();
            if (constructorInfos.Length != 0)
            {
                for(int i=constructorInfos.Length-1;i>=0;i--)
                {
                    try
                    {
                        ParameterInfo[] parameterInfo = constructorInfos[i].GetParameters();
                        object[] parameters = new object[parameterInfo.Length];
                        for (int j = 0; j < parameterInfo.Length; j++)
                        {
                            parameters[j] = Create(parameterInfo[j].ParameterType);
                        }
                        return Activator.CreateInstance(type, parameters);
                    }
                    catch (Exception e) { }; 
                }
            }
            else
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }

        private void InitializeProperty(Type type,object obj) {
            PropertyInfo[] propertyInfo = type.GetProperties();
            foreach (var property in propertyInfo)
            {
                if (CheckProperty(property, obj))
                {
                    property.SetValue(obj, Create(property.PropertyType));
                }
            }
        }

        private void InitializeField(Type type,object obj) {
            FieldInfo[] fieldInfos = type.GetFields();
            foreach (var field in fieldInfos)
            {
                if (CheckField(field, obj))
                {
                    field.SetValue(obj, Create(field.FieldType));
                }

            }
        }

        private object CreateObject(Type type) {
            object result = InitializeObj(type);
            if (result != null)
            {
                InitializeProperty(type, result);
                InitializeField(type, result);
            }
            return result;
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
            int ind = rnd.Next();
            ind = ind % enumConst.Length;
            return Enum.Parse(type, enumConst[ind]);
        }

        private string CreateString() {
            StringBuilder builder = new StringBuilder();
            int lenght = CreateByte() + 1;
            for (int i = 0; i < lenght; i++)
            {
                builder.Append(CreateChar());
            }
            return builder.ToString();
        }
            
    }
}
