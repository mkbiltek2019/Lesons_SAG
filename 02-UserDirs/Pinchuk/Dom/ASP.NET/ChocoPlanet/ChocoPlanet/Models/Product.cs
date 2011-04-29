using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChocoPlanet.Models
{
    [MetadataType(typeof(ProductValidation))]
    public partial class Product
    {
    }

    public class ProductValidation
    {
       [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string Price { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string Description { get; set; }
    }
}