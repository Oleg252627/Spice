using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Eczamen.Abstractions;
using Eczamen.Entitie;
using Eczamen.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Eczamen.Repositories.interfaces
{
    public interface IMenuItemRepository: IDbRepository<MenuItem>
    {
        Task<List<MenuItem>> GetAllMenuItem();

        Task<MenuItemModel> CreateNenuItemGet(ICategoryRepository iCategoryRepository,
            ISubCategoryRepositiry iSubCategoryRepositiry);

        Task<bool> CreateMenuItemPost(MenuItemModel model);
        Task<bool> AddImageMenuItem(string path,IFormFileCollection files);
        Task<MenuItemModel> EditMenuItemGet(int? id, ICategoryRepository iCategoryRepository, ISubCategoryRepositiry iSubCategoryRepositiry);
        Task<bool> EditMenuItemPost(MenuItemModel model);
        Task<bool> EditImageMenuItem(int id, string path, IFormFileCollection files);
        Task<MenuItem> DeleteMenuItemGet(int? id);
        Task<bool> DeleteMenuItemPost(MenuItem model, string path);

        Task<MenuItemModel> ExistMenuItem(MenuItemModel model, ICategoryRepository iCategoryRepository,
            ISubCategoryRepositiry iSubCategoryRepositiry);
    }
}
