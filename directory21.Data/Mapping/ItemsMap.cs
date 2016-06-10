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
    public class ItemsMap:EntityTypeConfiguration<Items>
    {
        public ItemsMap()
        {
            //Key
            HasKey(i => i.Id);
            //fields
            Property(i => i.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.ItemName).IsRequired().HasMaxLength(20).HasColumnType("nvarchar");
            Property(i => i.ItemDescription).HasMaxLength(100).HasColumnType("nvarchar");
            Property(i => i.CategoriesId).IsRequired().HasColumnType("int");
            //Tables
            ToTable("Items");
            //Relationship
            HasRequired(i => i.Categories).WithMany(c => c.Items).HasForeignKey(i => i.CategoriesId);
        }
    }
}
