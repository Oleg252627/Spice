using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Eczamen.Abstractions;
using Eczamen.Entitie;
using Eczamen.Models;

namespace Eczamen.Repositories.interfaces
{
    public interface ICategoryRepository: IDbRepository<Category>
    {
        Task<List<Category>> GetAllCategory();
        Task<bool> CreateCategory(CategoryModel category);
        Task<CategoryModel> EditGetCategory(int? id);
        Task<bool> EditPostCategory(CategoryModel model);
        Task<bool> DeleteCategory(CategoryModel model);
    }
}
