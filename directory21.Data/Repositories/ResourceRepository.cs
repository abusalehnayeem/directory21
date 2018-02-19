using directory21.Core.Data;
using directory21.Core.Domain;

namespace directory21.Data.Repositories
{
    public class ResourceRepository:Repository<Resources>,IResourceRepository
    {
        public ResourceRepository(SimpleContext context) : base(context)
        {
        }
    }
}
