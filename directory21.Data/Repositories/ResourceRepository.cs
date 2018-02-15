using directory21.Core.Data;
using directory21.Core.Domain;

namespace directory21.Data.Repositories
{
    internal class ResourceRepository:Repository<Resources>,IResourceRepository
    {
        internal ResourceRepository(SimpleContext context) : base(context)
        {
        }
    }
}
