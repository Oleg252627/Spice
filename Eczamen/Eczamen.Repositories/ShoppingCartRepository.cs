using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Eczamen.AppContext;
using Eczamen.Entitie;
using Eczamen.Repositories.Generic;
using Eczamen.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Eczamen.Repositories
{
    public class ShoppingCartRepository: DbRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ShoppingCart> DetailsShoppingCartGet(int? id, IMenuItemRepository iMenuItemRepository)
        {
            if (id == null)
            {
                return null;
            }

            var menuItem = await iMenuItemRepository.AllItems.Include(z => z.SubCategory).ThenInclude(x => x.Category)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (menuItem == null)
            {
                return null;
            }
            ShoppingCart shoppingCart = new ShoppingCart
            {
                MenuItem = menuItem,
                MenuItemId = menuItem.Id
            };
            return shoppingCart;
        }
    }
}
