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
        void DeleteCategories(Categories categories);
        void InsertCategories(Categories categories);
        void UpdateCategories(Categories categories);
        Categories GetCategoriesById(int categoriesId);
        IQueryable<Categories> GetAllCategories();
    }
}
