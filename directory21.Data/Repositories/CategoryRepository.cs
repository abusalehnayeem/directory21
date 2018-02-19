using directory21.Core.Data;
using directory21.Core.Domain;

namespace directory21.Data.Repositories
{
    public class CategoryRepository:Repository<Categories>, ICategoryRepository
    {
        public CategoryRepository(SimpleContext context) : base(context)
        {
        }
    }
}
