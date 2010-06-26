using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersDictionary.Model;
using UsersDictionary.Controllers;
using System.Configuration;

namespace UsersDictionary.Presenters
{
    public class UserPresenter
    {
        public UserPresenter()
        {
            CurrentPage = 0;
            Users = new List<User>();
            pageSize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
        }

        public int CurrentPage
        {
            get;
            set;
        }

        private int pageSize;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        public List<User> Users { get; set; }

        public void GetNextUserPage()
        {
            Users = new UserController().GetAllUsersWithPaging(
                string.Empty, 
                string.Empty, 
                string.Empty, 
                CurrentPage, 
                PageSize);
            CurrentPage++;
        }
    }
}
