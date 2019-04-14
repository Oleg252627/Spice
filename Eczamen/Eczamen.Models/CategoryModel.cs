using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eczamen.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Enter category name!")]
        public string Name { get; set; }
    }
}
