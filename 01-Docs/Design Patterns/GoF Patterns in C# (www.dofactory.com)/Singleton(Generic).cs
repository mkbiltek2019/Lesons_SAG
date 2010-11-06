namespace LP.Core
{
    public class Singleton<T> where T : new()
    {
        public static T Instance
        {
            get
            {
                return Nested.instance;
            }
        }
        
        class Nested
        {
            // ReSharper disable EmptyConstructor
            static Nested() { }
            // ReSharper restore EmptyConstructor

            internal static readonly T instance = new T();
        }
    }

    public static class Sigleton1<T> where T : new()
    {
        private static readonly T  _Instance;
        
        static Sigleton1()
        {
            _Instance = new T();
        }

        public static T Instance
        {
            get
            {
                return _Instance;
            }
        }
    }
}