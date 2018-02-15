using directory21.Core.Data;
using directory21.Core.Domain;

namespace directory21.Data.Repositories
{
    internal class CategoryRepository:Repository<Categories>, ICategoryRepository
    {
        internal CategoryRepository(SimpleContext context) : base(context)
        {
        }
    }
}
