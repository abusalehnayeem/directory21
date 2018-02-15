using System;
using System.Threading;
using System.Threading.Tasks;
using directory21.Core;
using directory21.Core.Data;
using directory21.Data.Repositories;

namespace directory21.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SimpleContext _context;
        private ICategoryRepository _categoryRepository;
        private IItemRepository _itemRepository;
        private IResourceRepository _resourceRepository;

        public UnitOfWork()
        {
            _context = new SimpleContext();
        }

        void IDisposable.Dispose()
        {
            _resourceRepository = null;
            _categoryRepository = null;
            _itemRepository = null;
        }

        IResourceRepository IUnitOfWork.ResourceRepository => _resourceRepository??(_resourceRepository=new ResourceRepository(_context));

        ICategoryRepository IUnitOfWork.CategoryRepository => _categoryRepository??(_categoryRepository=new CategoryRepository(_context));

        IItemRepository IUnitOfWork.ItemRepository => _itemRepository??(_itemRepository=new ItemRepository(_context));

        int IUnitOfWork.SaveChanges()
        {
            return _context.SaveChanges();
        }

        async Task<int> IUnitOfWork.SaveChangesAsyn()
        {
            return await _context.SaveChangesAsync();
        }

        async Task<int> IUnitOfWork.SaveChangesAsyn(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}