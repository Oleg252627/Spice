using Eczamen.Entitie;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Transactions;

namespace Eczamen.Models
{
    public class SubCategoryModel
    {
        public int Id { get; set; }
        [Display(Name = "Sub category name")]
        [Required(ErrorMessage = "Enter Sub category name!")]
        public string Name { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Select a category!")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
