using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using directory21.Core.Domain;

namespace directory21.Data.Mapping
{
    public class ResourcesMap : EntityTypeConfiguration<Resources>
    {
        public ResourcesMap()
        {
            //key
            HasKey(r => r.Id);
            //fields
            Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(r => r.ResourceName).IsRequired().HasMaxLength(20).HasColumnType("nvarchar");
            Property(r => r.ResourceDescription).HasMaxLength(100).HasColumnType("nvarchar");

            //Table
            ToTable("Resources");

            HasOptional(r => r.Categories).WithRequired(c => c.Resources);
        }
    }
}
