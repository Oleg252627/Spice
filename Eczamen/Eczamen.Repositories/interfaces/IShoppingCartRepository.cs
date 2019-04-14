using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Eczamen.Abstractions;
using Eczamen.Entitie;

namespace Eczamen.Repositories.interfaces
{
    public interface IShoppingCartRepository: IDbRepository<ShoppingCart>
    {
        Task<ShoppingCart> DetailsShoppingCartGet(int? id, IMenuItemRepository iMenuItemRepository);
    }
}
