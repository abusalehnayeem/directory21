using System.Linq;
using directory21.Core.Domain;

namespace directory21.Service.ResourcesService
{
    public interface IResourcesService
    {
        void DeleteResources(Resources resources);
        void InsertResources(Resources resources);
        void UpdateResources(Resources resources);
        Resources GetResourcesById(int resourcesId);
        IQueryable<Resources> GetAllResources();
    }
}
