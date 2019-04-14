using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Eczamen.Abstractions;
using Eczamen.Entitie.AplicUser;

namespace Eczamen.Entitie
{
    public class ShoppingCart: DbEntity
    {
        public ShoppingCart()
        {
            Count = 1;
        }
        public string ApplicationUserId { get; set; }
        [NotMapped]
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int MenuItemId { get; set; }
        [NotMapped]
        [ForeignKey("MenuItemId")]
        public virtual MenuItem MenuItem { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than or equal to {1}")]
        public int Count { get; set; }
    }
}
