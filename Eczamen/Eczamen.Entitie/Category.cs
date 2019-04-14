using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Eczamen.Abstractions;

namespace Eczamen.Entitie
{
    public class Category : DbEntity
    {
        [Column("nameCategory")]
        [Required]
        public string NameCategory { get; set; }
        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
