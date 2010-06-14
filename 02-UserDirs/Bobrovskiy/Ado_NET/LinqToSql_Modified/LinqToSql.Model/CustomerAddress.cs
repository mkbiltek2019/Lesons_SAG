using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToSql.Model
{
    public partial class Customer
    {
        public string FullName
        {
            get
            {
                return (this.FirstName + " " + this.LastName)
                    .Trim();
            }
        }
    }
}
