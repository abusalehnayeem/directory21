using System;
using System.Threading;
using System.Threading.Tasks;
using directory21.Core.Data;

namespace directory21.Core
{
    public interface IUnitOfWork : IDisposable
    {
        #region

        IResourceRepository ResourceRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IItemRepository ItemRepository { get; }

        #endregion

        #region

        int SaveChanges();
        Task<int> SaveChangesAsyn();
        Task<int> SaveChangesAsyn(CancellationToken cancellationToken);

        #endregion
    }
}