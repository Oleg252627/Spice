using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Eczamen.Abstractions;
using Eczamen.Entitie;
using Eczamen.Models;

namespace Eczamen.Repositories.interfaces
{
    public interface IShoppingCartRepository: IDbRepository<ShoppingCart>
    {
        Task<ShoppingCart> DetailsShoppingCartGet(int? id, IMenuItemRepository iMenuItemRepository);
        Task<bool> DetailsShoppingCartPost(ShoppingCart cart, Claim claim);
        Task<int> CountShoppingCart(string id);
        Task<List<ShoppingCart>> GetShoppingCartFoUser(string id);
        Task<OrderDetailsCart> GetOrderDetailsCart(Claim claim, IMenuItemRepository menuItem, string code,
            ICouponRepository couponRepository);

        Task<bool> PlusCartRepository(int cartId);
        Task<bool> MinusCartRepository(int cartId);
        Task<bool> DeleteCartRepository(int cartId);
    }
}
