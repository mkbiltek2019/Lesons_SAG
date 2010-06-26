using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UsersDictionary.DataAccess;
using UsersDictionary.Model;

namespace UsersDictionary.Controllers
{
    public class UserController
    {
        public List<User> GetAllUsersWithPaging(string name, string phone, string address, int pageNumber, int pageSize)
        {
            UsersDBManager usersDBManager = new UsersDBManager();
            return usersDBManager.GetAllUsersWithPaging(name, phone, address, pageNumber, pageSize)
                .ToList();
        }
    }
}
