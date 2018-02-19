using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using directory21.Core.Domain;

namespace directory21.Service.CategoriesService
{
    public interface ICategoriesService
    {
        void DeleteCategory(int categoryId);
        void InsertCategory(Categories category);
        void UpdateCategory(Categories category);
        void UpdateCategory(int categoryId);
        Categories GetCategoryById(int categoryId);
        Task<List<Categories>> GetAllCategoriesAsyn();
        List<Categories> GetAllCategories();
    }
}
