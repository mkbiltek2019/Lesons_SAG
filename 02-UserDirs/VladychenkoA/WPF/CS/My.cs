using System;
namespace RibbonSample.My
{
    internal class ThreadSafeObjectProvider<T>
    {
        private T _instance;
        public T GetInstance()
        {
            if (_instance == null)
                _instance = Activator.CreateInstance<T>();
            return _instance;
         }
    }
}
