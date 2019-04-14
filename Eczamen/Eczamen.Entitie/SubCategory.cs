using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Eczamen.Abstractions;

namespace Eczamen.Entitie
{
    public class SubCategory: DbEntity
    {
        [Column("name")]
        [Required]
        public string NameSubCategory { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public virtual List<MenuItem> MenuItems { get; set; }
    }
}
