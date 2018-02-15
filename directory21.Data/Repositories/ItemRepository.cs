using directory21.Core.Data;
using directory21.Core.Domain;

namespace directory21.Data.Repositories
{
    internal class ItemRepository:Repository<Items>,IItemRepository
    {
        internal ItemRepository(SimpleContext context) : base(context)
        {
        }
    }
}
