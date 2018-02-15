using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace directory21.Core.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        IQueryable<TEntity> GetAllQueryable();
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);

        List<TEntity> PageAll(int skip, int take);
        Task<List<TEntity>> PageAllAsync(int skip, int take);
        Task<List<TEntity>> PageAllAsync(CancellationToken cancellationToken, int skip, int take);

        TEntity FindById(object id);
        Task<TEntity> FindByIdAsync(object id);
        Task<TEntity> FindByIdAsync(CancellationToken cancellationToken, object id);

        bool AnyItem(object id);

        int TotalCount();

        Task<int> TotalCountAsync();

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);


        void Update(TEntity entity);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
