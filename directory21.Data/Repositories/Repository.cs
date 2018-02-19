using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using directory21.Core.Data;

namespace directory21.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly SimpleContext _context;
        private DbSet<TEntity> _set;

        public Repository(SimpleContext context)
        {
            _context = context;
        }

        protected DbSet<TEntity> Set => _set ?? (_set = _context.Set<TEntity>());

        public List<TEntity> GetAll()
        {
            return Set.ToList();
        }

        public IQueryable<TEntity> GetAllQueryable()
        {
            return Set.AsQueryable();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return Set.ToListAsync();
        }

        public Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return Set.ToListAsync(cancellationToken);
        }

        public List<TEntity> PageAll(int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToList();
        }

        public Task<List<TEntity>> PageAllAsync(int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToListAsync();
        }

        public Task<List<TEntity>> PageAllAsync(CancellationToken cancellationToken, int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToListAsync(cancellationToken);
        }

        public TEntity FindById(object id)
        {
            return Set.Find(id);
        }

        public Task<TEntity> FindByIdAsync(object id)
        {
            return Set.FindAsync(id);
        }

        public Task<TEntity> FindByIdAsync(CancellationToken cancellationToken, object id)
        {
            return Set.FindAsync(cancellationToken, id);
        }

        public void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Set.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Set.Attach(entity);
                entry = _context.Entry(entity);
            }
            entry.State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            Set.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Set.RemoveRange(entities);
        }

        public bool AnyItem(object id)
        {
            return Set.Find(id) != null;
        }

        public int TotalCount()
        {
            return Set.Count();
        }

        Task<int> IRepository<TEntity>.TotalCountAsync()
        {
            return Set.CountAsync();
        }
    }
}
