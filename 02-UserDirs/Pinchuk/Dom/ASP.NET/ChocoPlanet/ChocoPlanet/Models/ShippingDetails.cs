using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChocoPlanet.Models
{
    public class ShippingDetails : IDataErrorInfo
    {
        [Required(ErrorMessage = "Мінімальна довжина 1 символ!")]
        public string Name { get; set; }
       [Required(ErrorMessage = "Мінімальна довжина 1 символ!")]
       [RegularExpression(@"\d{3}-\d{3}-\d{2}", ErrorMessage = "Телефонний формат xxx-xxx-xx")]
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Мінімальна довжина 1 символ!")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Мінімальна довжина 1 символ!")]
        public string Town { get; set; }
        [Required(ErrorMessage = "Мінімальна довжина 1 символ!")]
        public string Stret { get; set; }
        
       
        
       

        public string this[string columnName]
        {
            get
            {
                if ((columnName == "City") && string.IsNullOrEmpty("City"))
                    return "City";
                return null;
            }
        }

        public string Error
        {
            get { return null; }
        }
    }
}