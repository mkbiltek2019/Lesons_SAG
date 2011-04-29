using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChocoPlanet.Models
{
    [MetadataType(typeof(CategoryValidation))]
    public partial class Category
    {
    }

    public class CategoryValidation
    {
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string Name { get; set; }
    }
}