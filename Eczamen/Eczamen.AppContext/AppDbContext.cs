using System;
using System.Collections.Generic;
using System.Text;
using Eczamen.Entitie;
using Eczamen.Entitie.AplicUser;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eczamen.AppContext
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ShoppingCart> Carts { get; set; }
    }
}
