using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using directory21.Core.Domain;

namespace directory21.Service.ItemsService
{
    public interface IItemsService
    {
        void DeleteItems(Items items);
        void InsertItems(Items items);
        void UpdateItems(Items items);
        Items GetItemsById(int itemsId);
        IQueryable<Items> GetAllItems();
    }
}
