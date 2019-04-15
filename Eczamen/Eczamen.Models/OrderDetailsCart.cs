using System;
using System.Collections.Generic;
using System.Text;
using Eczamen.Entitie;

namespace Eczamen.Models
{
    public class OrderDetailsCart
    {
        public List<ShoppingCart> ShoppingCarts { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}
