using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Eczamen.AppContext;
using Eczamen.Entitie;
using Eczamen.Models;
using Eczamen.Repositories.Generic;
using Eczamen.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Eczamen.Repositories
{
    public class CategoryRepository: DbRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await AllItems.ToListAsync();
        }

        public async Task<bool> CreateCategory(CategoryModel cat)
        {
            Category category = new Category{NameCategory = cat.Name};
            return await AddItemAsync(category);
        }

        public async Task<CategoryModel> EditGetCategory(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var category = await GetItemAsync(id);
            if (category == null)
            {
                return null;
            }
            CategoryModel model = new CategoryModel{Id = category.Id, Name = category.NameCategory};
            return model;
        }

        public async Task<bool> EditPostCategory(CategoryModel model)
        {
            var category = await GetItemAsync(model.Id);
            category.NameCategory = model.Name;
            return await UpdateItem(category);
        }

        public async Task<bool> DeleteCategory(CategoryModel model)
        {
            return await DeleteItemAsync(model.Id);
        }
    }
}
