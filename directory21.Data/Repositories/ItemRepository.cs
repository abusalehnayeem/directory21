using directory21.Core.Data;
using directory21.Core.Domain;

namespace directory21.Data.Repositories
{
    public class ItemRepository:Repository<Items>,IItemRepository
    {
        public ItemRepository(SimpleContext context) : base(context)
        {
        }
    }
}
