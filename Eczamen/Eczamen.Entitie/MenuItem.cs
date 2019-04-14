using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Eczamen.Abstractions;

namespace Eczamen.Entitie
{
    public class MenuItem: DbEntity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Spicyness { get; set; }
        public enum ESpicy
        {
            NA = 0,
            NotSpicy = 1,
            Spicy = 2,
            VerySpicy = 3
        }
        public string Image { get; set; }
        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }
        public double Price { get; set; }
    }
}
