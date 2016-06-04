using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using directory21.Core.Domain;

namespace directory21.Data.Migrations
{
    internal class Configuration : DbMigrationsConfiguration<SimpleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
        protected override void Seed(SimpleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Resources.AddOrUpdate(
                new Resources()
                {
                    Id = Guid.NewGuid(),
                    ResourceName = "Accounting",
                    ResourceDescription = "Test Entry"
                });
            context.Categories.AddOrUpdate(
                new Categories()
                {
                    Id = Guid.NewGuid(),
                    CategotyName = "Test Categoty",
                    CategoryDescription = "Test Entry"
                });
            context.Items.AddOrUpdate(
                new Items()
                {
                    Id = Guid.NewGuid(),
                    ItemName = "Test Item",
                    ItemDescription = "Test Entry"
                });
        }
    }
}
