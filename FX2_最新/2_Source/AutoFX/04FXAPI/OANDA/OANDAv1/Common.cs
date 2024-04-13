using System;
using System.Reflection;


namespace OANDAv1
{
    public class Common
    {
        public static object GetDefault(Type t)
        {
            return typeof(Common).GetTypeInfo().GetDeclaredMethod("GetDefaultGeneric").MakeGenericMethod(t).Invoke(null, null);
        }

        public static T GetDefaultGeneric<T>()
        {
            return default(T);
        }
    }
}
