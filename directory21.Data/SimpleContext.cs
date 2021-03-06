﻿using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using directory21.Core.Domain;
using MySql.Data.Entity;

namespace directory21.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class SimpleContext : DbContext
    {
        static SimpleContext()
        {
            // static constructors are guaranteed to only fire once per application.
            // I do this here instead of App_Start so I can avoid including EF
            // in my MVC project (I use UnitOfWork/Repository pattern instead)
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
        }

        public SimpleContext()
            : base("name = DefaultDbConnection")
        {
        }


        public DbSet<Resources> Resources { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Items> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new ResourcesMap());

            //modelBuilder.Configurations.Add(new CategoriesMap());

            //modelBuilder.Configurations.Add(new ItemsMap());

            /*Or We can write it  this way*/

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                               type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}