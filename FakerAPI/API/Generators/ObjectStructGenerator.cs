using System;
using System.Collections.Generic;
using System.Reflection;

namespace FakerAPI.API.Generators
{
    class ObjectStructGenerator : IValueGenerator
    {
        Dictionary<string,int> cycleTable;
        public ObjectStructGenerator() {
            cycleTable = new Dictionary<string, int>();
        }
        public bool CanGenerate(Type type)
        {
            return !IsPrimitive(type)
                    && !type.IsEnum;
        }

        private bool IsPrimitive(Type type) {
            return type.IsPrimitive || Type.GetTypeCode(type) == TypeCode.Decimal;
        }
        private bool CycleType(Type type) {

            if (type.IsClass)
            {
                if (cycleTable.ContainsKey(type.FullName))
                {
                    if (cycleTable[type.FullName] == 4)
                    {
                        return true;
                    }
                    else 
                    {
                        cycleTable[type.FullName]++;
                    }
                }
                else {
                    cycleTable.Add(type.FullName, 1);
                }
            }
            return false;
        }

        private void UnCycleType(Type type)
        {

            if (type.IsClass)
            {
                if (cycleTable.ContainsKey(type.FullName))
                {
                    cycleTable[type.FullName]--;    
                }
            }
        }

        public object Generate(GeneratorContext context)
        {
            if (CycleType(context.TargetType)) {
                UnCycleType(context.TargetType);
                return null;
            }
            object result = InitializeObj(context);
            if (result != null)
            {
                InitializeProperty(context, result);
                InitializeField(context, result);
            }
            UnCycleType(context.TargetType);
            return result;
        }

        private object InitializeObj(GeneratorContext context)
        {
            ConstructorInfo[] constructorInfos = context.TargetType.GetConstructors();
            if (constructorInfos.Length != 0)
            {
                for (int i = constructorInfos.Length - 1; i >= 0; i--)
                {
                    try
                    {
                        ParameterInfo[] parameterInfo = constructorInfos[i].GetParameters();
                        object[] parameters = new object[parameterInfo.Length];
                        for (int j = 0; j < parameterInfo.Length; j++)
                        {
                            parameters[j] = context.Faker.Create(parameterInfo[j].ParameterType);
                        }
                        return Activator.CreateInstance(context.TargetType, parameters);
                    }
                    catch (Exception e) { };
                }
            }
            else
            {
                return Activator.CreateInstance(context.TargetType);
            }
            return null;
        }
        private void InitializeProperty(GeneratorContext context, object obj)
        {
            PropertyInfo[] propertyInfo = context.TargetType.GetProperties();
            foreach (var property in propertyInfo)
            {
                if (InitProperty(property, obj))
                {
                    property.SetValue(obj,context.Faker.Create(property.PropertyType));
                }
            }
        }

        private void InitializeField(GeneratorContext context, object obj)
        {
            FieldInfo[] fieldInfos = context.TargetType.GetFields();
            foreach (var field in fieldInfos)
            {
                if (InitField(field, obj))
                {
                    field.SetValue(obj, context.Faker.Create(field.FieldType));
                }
            }
        }

        private bool InitProperty(PropertyInfo info, object obj)
        {
            if (info.CanRead && info.GetType().IsClass && info.GetValue(obj) != null)
            {
                return false;
            }
            return info.CanWrite;
        }

        private bool InitField(FieldInfo info, object obj)
        {
            if (info.GetType().IsClass && info.GetValue(obj) != null)
            {
                return false;
            }
            return !info.IsInitOnly;
        }
    }
}
