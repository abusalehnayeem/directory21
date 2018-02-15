using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using directory21.Core;
using directory21.Core.Domain;

namespace directory21.Service.ItemsService
{
    public class ItemsService : IItemsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteItem(int itemId)
        {
            var item = _unitOfWork.ItemRepository.FindById(itemId);
            if (item == null) throw new ArgumentException("Items");
            _unitOfWork.ItemRepository.Remove(item);
            _unitOfWork.SaveChanges();
        }

        public void InsertItem(Items item)
        {
            if (item == null) throw new ArgumentException("item");
            _unitOfWork.ItemRepository.Add(item);
            _unitOfWork.SaveChanges();
        }

        public void UpdateItem(Items item)
        {
            if (item == null) throw new ArgumentException("item");
            _unitOfWork.ItemRepository.Update(item);
            _unitOfWork.SaveChanges();
        }

        public void UpdateItem(int itemId)
        {
            var itm = _unitOfWork.ItemRepository.FindById(itemId);
            if (itm == null) return;
            _unitOfWork.ItemRepository.Update(itm);
            _unitOfWork.SaveChanges();
        }

        public Items GetItemById(int itemId)
        {
            return _unitOfWork.ItemRepository.FindById(itemId);
        }

        public async Task<List<Items>> GetAllItems()
        {
            return await _unitOfWork.ItemRepository.GetAllAsync();
        }
    }
}
