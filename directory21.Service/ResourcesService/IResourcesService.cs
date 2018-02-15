using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using directory21.Core.Domain;

namespace directory21.Service.ResourcesService
{
    public interface IResourcesService
    {
        void DeleteResources(int resourcesId);
        void InsertResources(Resources resources);
        void UpdateResources(Resources resources);
        void UpdateResources(int resourcesId);
        Resources GetResourcesById(int resourcesId);
        Task<List<Resources>> GetAllResources();
    }
}
