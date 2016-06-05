using System.Data.Entity;
using directory21.Core.Domain;
using directory21.Data.Migrations;
using directory21.Data.Mapping;

namespace directory21.Data
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class SimpleContext : DbContext, IDbContext
    {
        public SimpleContext()
            : base("name = DefaultDbContext")
        {
            Database.SetInitializer(new MyDbInitializer());
        }

        static SimpleContext()
        {
            // static constructors are guaranteed to only fire once per application.
            // I do this here instead of App_Start so I can avoid including EF
            // in my MVC project (I use UnitOfWork/Repository pattern instead)
            DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // I have an abstract base EntityMap class that maps Ids for my entities.
            // It is used as the base for all my class mappings
            modelBuilder.Configurations.AddFromAssembly(typeof(ResourcesMap).Assembly);
            base.OnModelCreating(modelBuilder);
        }


        public object ResourcesMap { get; set; }
    }
}
