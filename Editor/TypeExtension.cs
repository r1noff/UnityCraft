using System;
using System.Reflection;

namespace UnityCraft.Editor
{
    public static class TypeExtension
    {
        public static T GetStaticFieldValue<T>(this Type type, string name, bool isPublic) where T : class =>
            type
                .GetField(name, BindingFlags.Static | (isPublic ? BindingFlags.Public : BindingFlags.NonPublic))
                ?.GetValue(null) as T;
    }
}