using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RedPet.Common.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsSimple(this Type type)
        {
            var typeInfo = type.GetTypeInfo();
            if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // nullable type, check if the nested type is simple.
                return IsSimple(typeInfo.GetGenericArguments()[0]);
            }

            return typeInfo.IsPrimitive || typeInfo.IsEnum || type == typeof(string) || type == typeof(decimal);
        }
    }
}