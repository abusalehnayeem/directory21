using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using directory21.Core.Data;
using directory21.Core.Domain;

namespace directory21.Service.ItemsService
{
    public class ItemsService : IItemsService
    {
        #region Variables

        private readonly IRepository<Items> _itemsRepository;

        #endregion

        #region Constructor

        public ItemsService(IRepository<Items> itemsRepository)
        {
            if (itemsRepository == null) throw new ArgumentNullException(nameof(itemsRepository));
            _itemsRepository = itemsRepository;
        }

        #endregion

        #region Implementation of IResourcesService

        public void DeleteItems(Items items)
        {
            if (items == null)
            {
                throw new ArgumentException("items");
            }
            _itemsRepository.Delete(items);
        }

        public void InsertItems(Items items)
        {
            if (items == null)
            {
                throw new ArgumentException("resources");
            }
            _itemsRepository.Insert(items);
        }

        public void UpdateItems(Items items)
        {
            if (items == null)
            {
                throw new ArgumentException("resources");
            }
            _itemsRepository.Update(items);
        }

        public Items GetItemsById(int itemsId)
        {
            return itemsId == 0 ? null : _itemsRepository.GetById(itemsId);
        }

        public IQueryable<Items> GetAllItems()
        {
            return _itemsRepository.Table;
        }

        #endregion
    }
}
