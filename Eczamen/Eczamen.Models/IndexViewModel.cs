using System;
using System.Collections.Generic;
using System.Text;
using Eczamen.Entitie;

namespace Eczamen.Models
{
    public class IndexViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Coupon> Coupons { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}
