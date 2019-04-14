using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Eczamen.Abstractions;
using Eczamen.Entitie;
using Eczamen.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eczamen.Repositories.interfaces
{
    public interface ISubCategoryRepositiry: IDbRepository<SubCategory>
    {
        Task<List<SubCategory>> GetListSubCategory();
        Task<SubCategoryAndCategoryModel> CreateSubCategoryModel(ICategoryRepository iCategoryRepository);
        Task<bool> CreatePostSubCategory(SubCategoryAndCategoryModel model);
        Task<SubCategoryAndCategoryModel> ExistSubCategory(SubCategoryAndCategoryModel model, ICategoryRepository iCategoryRepository);
        Task<SelectList> GetJsonSubCategory(int id);
        Task<SubCategoryAndCategoryModel> EditGetSubCategory(int? id, ICategoryRepository iCategoryRepository);
        Task<bool> EditPostSubCategory(SubCategoryAndCategoryModel model);
        Task<SubCategoryModel> DeleteSubCategoryGet(int? id);
        Task<bool> DeleteSubCategoryPost(SubCategoryModel model);

    }
}
