using System.Collections.Generic;
using System.Threading.Tasks;
using directory21.Core.Domain;

namespace directory21.Service.ItemsService
{
    public interface IItemsService
    {
        void DeleteItem(int itemId);
        void InsertItem(Items item);
        void UpdateItem(Items item);
        void UpdateItem(int itemId);
        Items GetItemById(int itemId);
        Task<List<Items>> GetAllItems();
    }
}
