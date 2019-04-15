using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Eczamen.Abstractions;

namespace Eczamen.Entitie
{
    public class OrderDetails: DbEntity
    {
        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual OrderHeader OrderHeader { get; set; }

        [Required]
        public int MenuItemId { get; set; }

        [ForeignKey("MenuItemId")]
        public virtual MenuItem MenuItem { get; set; }

        public int Count { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
