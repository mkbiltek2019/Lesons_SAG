using System.ComponentModel;

namespace BindingDemo
{
    public class User : INotifyPropertyChanged
    {
        private const string NameProperty = "Name";
        private const string AddressProperty = "Address";

        private string _name;
        private Address _address;

        public string Name 
        {
            get { return _name; }
            set
            {
                if (_name == value) return;

                _name = value;
                RaisePropertyChanged(NameProperty);
            }
        }
        public Address Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (_address == value) return;

                _address = value;
                RaisePropertyChanged(AddressProperty);
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            Guard<User>.EnsurePropertyNameExist(propertyName);

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}