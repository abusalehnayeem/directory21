using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using directory21.Core.Data;
using directory21.Core.Domain;

namespace directory21.Service.CategoriesService
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Categories> _categoriesRepository;

        #region   Constructor

        public CategoriesService(IRepository<Categories> categoriesRepository)
        {
            if (categoriesRepository == null) throw new ArgumentNullException("categoriesRepository");
            _categoriesRepository = categoriesRepository;
        }

        #endregion

        #region Implementation of ICategoriesService

        public void DeleteCategories(Categories categories)
        {

        }

        public void InsertCategories(Categories categories)
        {
            
        }

        public void UpdateCategories(Categories categories)
        {
            if (categories == null)
            {
                throw new ArgumentException("categories");
            }
            _categoriesRepository.Update(categories);
        }

        public Categories GetCategoriesById(int categoriesId)
        {
            return categoriesId == 0 ? null : _categoriesRepository.GetById(categoriesId);
        }

        public IQueryable<Categories> GetAllCategories()
        {
            return _categoriesRepository.Table;
        }

        #endregion
    }
}
