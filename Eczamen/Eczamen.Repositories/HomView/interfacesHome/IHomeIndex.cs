using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Eczamen.Models;
using Eczamen.Repositories.interfaces;

namespace Eczamen.Repositories.HomView.interfacesHome
{
    public interface IHomeIndex
    {
        Task<IndexViewModel> GetModelIndex(ICategoryRepository iCategoryRepository, ICouponRepository iCouponRepository,
            IMenuItemRepository iMenuItemRepository);
    }
}
