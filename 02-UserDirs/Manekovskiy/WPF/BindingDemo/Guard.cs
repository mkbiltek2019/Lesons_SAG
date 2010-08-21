namespace BindingDemo
{
    public static class Guard<T>
    {
        public static void EnsurePropertyNameExist(string propertyName)
        {
#if DEBUG
            if(typeof(T).GetProperty(propertyName) == null)
            {
                throw new PropertyDoesNotExistException(propertyName);
            }
#endif
        }
    }
}