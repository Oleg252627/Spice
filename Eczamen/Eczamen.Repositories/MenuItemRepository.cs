using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eczamen.AppContext;
using Eczamen.Entitie;
using Eczamen.Models;
using Eczamen.Models.Utility;
using Eczamen.Repositories.Generic;
using Eczamen.Repositories.interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Eczamen.Repositories
{
    public class MenuItemRepository:DbRepository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<MenuItem>> GetAllMenuItem()
        {
            return await AllItems.Include(z => z.SubCategory).ThenInclude(x => x.Category).ToListAsync();
        }

        public async Task<MenuItemModel> CreateNenuItemGet(ICategoryRepository iCategoryRepository, ISubCategoryRepositiry iSubCategoryRepositiry)
        {
            Dictionary<Category, List<SubCategory>> dictionary = new Dictionary<Category, List<SubCategory>>();
            var category = await iCategoryRepository.ToListAsync();
            foreach (var VARIABLE in category)
            {
                var subCategory = await iSubCategoryRepositiry.AllItems.Where(x => x.CategoryId == VARIABLE.Id).ToListAsync();
                dictionary.Add(VARIABLE, new List<SubCategory>(subCategory));
            }
            MenuItemModel model = new MenuItemModel{Dictionary = dictionary};
            return model;
        }

        public async Task<bool> CreateMenuItemPost(MenuItemModel model)
        {
            MenuItem menu = new MenuItem
            {
                Name = model.Name,
                Description = model.Description,
                Image = model.Image,
                Spicyness = model.Spicyness,
                SubCategoryId = Int32.Parse(model.SubCategoryId),
                Price = Double.Parse(model.Price)
            };
            return await AddItemAsync(menu);
        }

        public async Task<bool> AddImageMenuItem(string path,IFormFileCollection files)
        {
            var menuItem = await AllItems.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            if (files.Count > 0)
            {
                var uploades = Path.Combine(path, "images");
                var extension = Path.GetExtension(files[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(uploades,menuItem.Id + extension), FileMode.Create))
                {
                   await files[0].CopyToAsync(fileStream);
                }

                menuItem.Image = @"\images\" + menuItem.Id + extension;
            }
            else
            {
                var uploades = Path.Combine(path, @"images\" + SD.DefaultFoodImg);
                File.Copy(uploades, path + @"\images\" + menuItem.Id + ".png");
                menuItem.Image = @"\images\" + menuItem.Id + ".png";
            }

            return await UpdateItem(menuItem);
        }

        public async Task<MenuItemModel> EditMenuItemGet(int? id, ICategoryRepository iCategoryRepository, ISubCategoryRepositiry iSubCategoryRepositiry)
        {
            if (id == null)
            {
                return null;
            }

            var menuItem = await AllItems.Include(z => z.SubCategory).ThenInclude(x => x.Category)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (menuItem == null)
            {
                return null;
            }
            MenuItemModel model = new MenuItemModel
            {
                Id = menuItem.Id,
                Description = menuItem.Description,
                Image = menuItem.Image,
                Name = menuItem.Name,
                Price = $"{menuItem.Price}",
                Spicyness = menuItem.Spicyness,
                SubCategory = menuItem.SubCategory
            };
            Dictionary<Category, List<SubCategory>> dictionary = new Dictionary<Category, List<SubCategory>>();
            var category = await iCategoryRepository.ToListAsync();
            foreach (var VARIABLE in category)
            {
                var subCategory = await iSubCategoryRepositiry.AllItems.Where(x => x.CategoryId == VARIABLE.Id).ToListAsync();
                dictionary.Add(VARIABLE, new List<SubCategory>(subCategory));
            }

            model.Dictionary = dictionary;
            return model;
        }

        public async Task<bool> EditMenuItemPost(MenuItemModel model)
        {
            var menuItem = await GetItemAsync(model.Id);
            menuItem.Name = model.Name;
            menuItem.Description = model.Description;
            menuItem.Image = model.Image;
            menuItem.Price = Double.Parse(model.Price);
            menuItem.SubCategoryId = Int32.Parse(model.SubCategoryId);
            menuItem.Spicyness = model.Spicyness;
            return await UpdateItem(menuItem);
        }

        public async Task<bool> EditImageMenuItem(int id, string path, IFormFileCollection files)
        {
            var menuItem = await GetItemAsync(id);
            var uploades = Path.Combine(path, "images");
            var extension = Path.GetExtension(files[0].FileName);

            var imagePatch = Path.Combine(path, menuItem.Image.TrimStart('\\'));
            if (File.Exists(imagePatch))
            {
                File.Delete(imagePatch);
            }

            using (var fileStream = new FileStream(Path.Combine(uploades, menuItem.Id + extension), FileMode.Create))
            {
                await files[0].CopyToAsync(fileStream);
            }

            menuItem.Image = @"\images\" + menuItem.Id + extension;
            return await UpdateItem(menuItem);
        }

        public async Task<MenuItem> DeleteMenuItemGet(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await AllItems.Include(z => z.SubCategory).ThenInclude(x => x.Category)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> DeleteMenuItemPost(MenuItem model, string path)
        {
            var imagePatch = Path.Combine(path, model.Image.TrimStart('\\'));
            if (File.Exists(imagePatch))
            {
                File.Delete(imagePatch);
            }

            return await DeleteItemAsync(model.Id);
        }

        public async Task<MenuItemModel> ExistMenuItem(MenuItemModel model, ICategoryRepository iCategoryRepository,
            ISubCategoryRepositiry iSubCategoryRepositiry)
        {

            var menuItem = await AllItems.Include(z => z.SubCategory).ThenInclude(x => x.Category)
                .FirstOrDefaultAsync(c => c.Id == model.Id);
            model.SubCategory = menuItem.SubCategory;
            Dictionary<Category, List<SubCategory>> dictionary = new Dictionary<Category, List<SubCategory>>();
            var category = await iCategoryRepository.ToListAsync();
            foreach (var VARIABLE in category)
            {
                var subCategory = await iSubCategoryRepositiry.AllItems.Where(x => x.CategoryId == VARIABLE.Id).ToListAsync();
                dictionary.Add(VARIABLE, new List<SubCategory>(subCategory));
            }

            model.Dictionary = dictionary;
            return model;
        }
    }
}
