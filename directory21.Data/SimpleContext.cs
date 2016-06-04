using System.Data.Entity;
using directory21.Core.Domain;

namespace directory21.Data
{
    public class SimpleContext : DbContext, IDbContext
    {
        public SimpleContext()
            : base("name = DefaultDbContext")
        {

        }

        #region Implementation of IDbContext

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        #endregion

        public DbSet<Resources> Resources { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Items> Items { get; set; }

    }
}
