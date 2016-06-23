using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using directory21.Core.Data;
using directory21.Core.Domain;

namespace directory21.Service.ResourcesService
{
    public class ResourcesService:IResourcesService
    {
        #region Variables

        private readonly IRepository<Resources> _resourcesRepository;
        #endregion

        #region Constructor
        public ResourcesService(IRepository<Resources> resourcesRepository)
        {
            if (resourcesRepository == null) throw new ArgumentNullException("resourcesRepository");
            _resourcesRepository = resourcesRepository;
        }

        #endregion
        
        #region Implementation of IResourcesService

        public void DeleteResources(Resources resources)
        {
            if (resources == null)
            {
                throw new ArgumentException("resources");
            }
            _resourcesRepository.Delete(resources);
        }

        public void InsertResources(Resources resources)
        {
            if(resources==null)
            {
                throw new ArgumentException("resources");
            }
            _resourcesRepository.Insert(resources);
        }

        public void UpdateResources(Resources resources)
        {
            if (resources == null)
            {
                throw new ArgumentException("resources");
            }
            _resourcesRepository.Update(resources);
        }

        public Resources GetResourcesById(int resourcesId)
        {
            return resourcesId == 0 ? null : _resourcesRepository.GetById(resourcesId);
        }

        public IQueryable<Resources> GetAllResources()
        {
            return _resourcesRepository.Table;
        }

        #endregion
    }
}
