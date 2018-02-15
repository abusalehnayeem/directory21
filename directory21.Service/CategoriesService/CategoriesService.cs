using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using directory21.Core;
using directory21.Core.Data;
using directory21.Core.Domain;

namespace directory21.Service.CategoriesService
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteCategory(int categoryId)
        {
            var cat = _unitOfWork.CategoryRepository.FindById(categoryId);
            if (cat == null) throw new ArgumentException("Categories");
            _unitOfWork.CategoryRepository.Remove(cat);
            _unitOfWork.SaveChanges();
        }

        public void InsertCategory(Categories category)
        {
            if (category == null) throw new ArgumentException("category");
            _unitOfWork.CategoryRepository.Add(category);
            _unitOfWork.SaveChanges();
        }

        public void UpdateCategory(Categories category)
        {
            if (category == null) throw new ArgumentException("category");
            _unitOfWork.CategoryRepository.Update(category);
            _unitOfWork.SaveChanges();
        }

        public void UpdateCategory(int categoryId)
        {
            var cat = _unitOfWork.CategoryRepository.FindById(categoryId);
            if (cat == null) return;
            _unitOfWork.CategoryRepository.Update(cat);
            _unitOfWork.SaveChanges();
        }

        public Categories GetCategoryById(int categoryId)
        {
            return _unitOfWork.CategoryRepository.FindById(categoryId);
        }

        public async Task<List<Categories>> GetAllCategories()
        {
            return await _unitOfWork.CategoryRepository.GetAllAsync();
        }
    }
}
