using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using directory21.Core.Domain;

namespace directory21.Data.Mapping
{
    public class CategoriesMap : EntityTypeConfiguration<Categories>
    {
        public CategoriesMap()
        {
            //key
            HasKey(c => c.Id);
            //fields
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.CategotyName).IsRequired().HasMaxLength(20).HasColumnType("nvarchar");
            Property(c => c.CategoryDescription).HasMaxLength(100).HasColumnType("nvarchar");
            //Table
            ToTable("Categories");
            //Relationship
            HasRequired(c => c.Resources).WithRequiredPrincipal(r => r.Categories);
        }
    }
}
