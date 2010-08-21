using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BindingDemo
{
    public class DataModel
    {
        public ObservableCollection<User> Users { get; set; }

        public DataModel()
        {
            // TODO: Replace with load from DB
            Users = new ObservableCollection<User>();

            Users.Add(new User() { Name = "User1", Address = new Address() { City = "Rivne", Country = "Ukraine" } });
            Users.Add(new User() { Name = "User2", Address = new Address() { City = "Kyiv", Country = "Ukraine" } });
            Users.Add(new User() { Name = "User3", Address = new Address() { City = "Odessa", Country = "Ukraine" } });
            Users.Add(new User() { Name = "User4", Address = new Address() { City = "Kharkiv", Country = "Ukraine" } });
        }
    }
}