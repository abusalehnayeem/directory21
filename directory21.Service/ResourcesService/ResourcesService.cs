using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using directory21.Core;
using directory21.Core.Data;
using directory21.Core.Domain;

namespace directory21.Service.ResourcesService
{
    public class ResourcesService:IResourcesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResourcesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteResources(int resourcesId)
        {
            var res = _unitOfWork.ResourceRepository.FindById(resourcesId);
            if (res == null) throw new ArgumentException("resources");
            _unitOfWork.ResourceRepository.Remove(res);
            _unitOfWork.SaveChanges();
        }

        public void InsertResources(Resources resources)
        {
            if (resources == null)
            {
                throw new ArgumentException("resources");
            }
            _unitOfWork.ResourceRepository.Add(resources);
            _unitOfWork.SaveChanges();
        }

        public void UpdateResources(Resources resources)
        {
            _unitOfWork.ResourceRepository.Update(resources);
            _unitOfWork.SaveChanges();
        }

        public void UpdateResources(int resourcesId)
        {
            var res = _unitOfWork.ResourceRepository.FindById(resourcesId);
            if (res == null) throw new ArgumentException("resources");
            _unitOfWork.ResourceRepository.Update(res);
            _unitOfWork.SaveChanges();
        }

        public Resources GetResourcesById(int resourcesId)
        {
            return _unitOfWork.ResourceRepository.FindById(resourcesId);
        }

        public async Task<List<Resources>> GetAllResources()
        {
            return await _unitOfWork.ResourceRepository.GetAllAsync();
        }
    }
}
