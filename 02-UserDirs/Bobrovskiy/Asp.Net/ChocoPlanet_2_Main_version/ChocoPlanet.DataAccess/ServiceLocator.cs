using System;
using System.Collections.Generic;
using ChocoPlanet.DataAccess.Abstraction;

namespace ChocoPlanet.DataAccess
{
    public static class ServiceLocator
    {
        private static Dictionary<Type, object> instantiatedTypes = new Dictionary<Type, object>();

        public static T GetType<T>()
        {
            T result;
            if (instantiatedTypes.ContainsKey(typeof(T)))
            {
                result = (T) instantiatedTypes[typeof (T)];
            }
            else
            {
                result = (T) Activator.CreateInstance(typeof (T));
            }
            return result;
        }

        public static void RegisterInstance<T>(T instance)
        {
            instantiatedTypes[typeof (T)] = instance;
        }
    }
}