using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Eczamen.AppContext;
using Eczamen.Entitie;
using Eczamen.Models;
using Eczamen.Models.Utility;
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

        public async Task<bool> DetailsShoppingCartPost(ShoppingCart cart, Claim claim)
        {
            cart.Id = 0;
            cart.ApplicationUserId = claim.Value;
            var carts = await AllItems.Where(z => z.MenuItemId == cart.MenuItemId && z.ApplicationUserId == cart.ApplicationUserId).FirstOrDefaultAsync();
            if (carts == null)
            {
                return await AddItemAsync(cart);
            }
            else
            {
                carts.Count = carts.Count + cart.Count;
                return await UpdateItem(carts);
            }
        }

        public async Task<int> CountShoppingCart(string id)
        {
            return AllItems.Where(z => z.ApplicationUserId == id).ToList().Count();
        }

        public async Task<List<ShoppingCart>> GetShoppingCartFoUser(string id)
        {
            return await AllItems.Where(z => z.ApplicationUserId == id).ToListAsync();
        }

        public async Task<OrderDetailsCart> GetOrderDetailsCart(Claim claim, IMenuItemRepository menuItem)
        {
            OrderDetailsCart order = new OrderDetailsCart
            {
                OrderHeader = new OrderHeader(),
                ShoppingCarts = await GetShoppingCartFoUser(claim.Value)
            };
            order.OrderHeader.OrderTotal = 0;
            foreach (var VARIABLE in order.ShoppingCarts)
            {
                VARIABLE.MenuItem = await menuItem.GetItemAsync(VARIABLE.MenuItemId);
                order.OrderHeader.OrderTotal =
                    order.OrderHeader.OrderTotal + (VARIABLE.MenuItem.Price * VARIABLE.Count);
                VARIABLE.MenuItem.Description = SD.ConvertToRawHtml(VARIABLE.MenuItem.Description);
                if (VARIABLE.MenuItem.Description.Length > 100)
                {
                    VARIABLE.MenuItem.Description = VARIABLE.MenuItem.Description.Substring(0, 99) + "...";
                }
            }

            order.OrderHeader.OrderTotalOriginal = order.OrderHeader.OrderTotal;
            
            return order;
        }
    }
}
