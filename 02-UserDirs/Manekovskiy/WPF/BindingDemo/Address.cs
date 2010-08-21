namespace BindingDemo
{
    // Если мы хотим обновления байндинга на изменение свойств экземпляра, то должны реализовать интерфейс INotifyPropertyChanged
    // как в User.cs
    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}