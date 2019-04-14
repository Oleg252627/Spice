using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eczamen.AppContext;
using Eczamen.Entitie;
using Eczamen.Models;
using Eczamen.Repositories.Generic;
using Eczamen.Repositories.interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Eczamen.Repositories
{
    public class SubCategoryRepository: DbRepository<SubCategory>, ISubCategoryRepositiry
    {
        public SubCategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<SubCategory>> GetListSubCategory()
        {
            return await AllItems.Include(z => z.Category).ToListAsync();
        }

        public async Task<SubCategoryAndCategoryModel> CreateSubCategoryModel(ICategoryRepository iCategoryRepository)
        {
            SubCategoryAndCategoryModel model = new SubCategoryAndCategoryModel
            {
                Categories = await iCategoryRepository.GetAllCategory(),
                SubCategoryModel = new SubCategoryModel()
            };
            return model;
        }

        public async Task<bool> CreatePostSubCategory(SubCategoryAndCategoryModel model)
        {
            SubCategory subCategory = new SubCategory{NameSubCategory = model.SubCategoryModel.Name, CategoryId = Int32.Parse(model.SubCategoryModel.CategoryId)};
            return await AddItemAsync(subCategory);
        }

        public async Task<SubCategoryAndCategoryModel> ExistSubCategory(SubCategoryAndCategoryModel model, ICategoryRepository iCategoryRepository)
        {
            var exist = await AllItems.Include(z => z.Category).Where(x => x.NameSubCategory == model.SubCategoryModel.Name && x.Category.Id == Int32.Parse(model.SubCategoryModel.CategoryId)).ToListAsync();
            if (exist.Count > 0)
            {
                model.StatusMessage = "Error: Sub category exist under" + model.SubCategoryModel.Name + "category. Please use another name.";
                model.SubCategoryModel.Category =
                    await iCategoryRepository.AllItems.FirstOrDefaultAsync(z =>
                        z.Id == Int32.Parse(model.SubCategoryModel.CategoryId));
                model.Categories = await iCategoryRepository.GetAllCategory();
                return model;
            }

            return null;
        }

        public async Task<SelectList> GetJsonSubCategory(int id)
        {
            return new SelectList (await AllItems.Where(z => z.CategoryId == id).ToListAsync(),"Id", "NameSubCategory");
        }

        public async Task<SubCategoryAndCategoryModel> EditGetSubCategory(int? id, ICategoryRepository iCategoryRepository)
        {
            if (id == null)
            {
                return null;
            }
            var subCategory = await AllItems.Include(z => z.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (subCategory == null)
            {
                return null;
            }
            SubCategoryModel sub = new SubCategoryModel{Id = subCategory.Id, Name = subCategory.NameSubCategory, Category = subCategory.Category};
            SubCategoryAndCategoryModel model = new SubCategoryAndCategoryModel
            {
                Categories = await iCategoryRepository.GetAllCategory(),
                SubCategoryModel = sub
            };
            return model;
        }

        public async Task<bool> EditPostSubCategory(SubCategoryAndCategoryModel model)
        {
            var subCategory = await GetItemAsync(model.SubCategoryModel.Id);
            subCategory.NameSubCategory = model.SubCategoryModel.Name;
            subCategory.CategoryId = Int32.Parse(model.SubCategoryModel.CategoryId);
            return await UpdateItem(subCategory);
        }

        public async Task<SubCategoryModel> DeleteSubCategoryGet(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var subCategory = await AllItems.Include(z => z.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (subCategory == null)
            {
                return null;
            }
            SubCategoryModel model = new SubCategoryModel{Id = subCategory.Id, Name = subCategory.NameSubCategory, Category = subCategory.Category};
            return model;
        }

        public async Task<bool> DeleteSubCategoryPost(SubCategoryModel model)
        {
            return await DeleteItemAsync(model.Id);
        }
    }
}
