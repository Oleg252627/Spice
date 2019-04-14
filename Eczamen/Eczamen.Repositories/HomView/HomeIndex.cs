using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eczamen.AppContext;
using Eczamen.Models;
using Eczamen.Repositories.HomView.interfacesHome;
using Eczamen.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Eczamen.Repositories.HomView
{
    public class HomeIndex: IHomeIndex
    {

        public async Task<IndexViewModel> GetModelIndex(ICategoryRepository iCategoryRepository, ICouponRepository iCouponRepository,
            IMenuItemRepository iMenuItemRepository)
        {
            IndexViewModel model = new IndexViewModel
            {
                Categories = await iCategoryRepository.ToListAsync(),
                Coupons = await iCouponRepository.AllItems.Where(z => z.IsActive == true).ToListAsync(),
                MenuItems = await iMenuItemRepository.AllItems.Include(z => z.SubCategory).ThenInclude(x =>x.Category).ToListAsync()
            };
            return model;
        }
    }
}
