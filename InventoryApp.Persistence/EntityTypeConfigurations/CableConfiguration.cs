using InventoryApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryApp.Persistence.EntityTypeConfigurations
{
    public class CableConfiguration : IEntityTypeConfiguration<Cable>
    {
        public void Configure(EntityTypeBuilder<Cable> builder)
        {
            builder.ToTable("Cables");
            builder.Property(cable => cable.Length).IsRequired();
            builder.Property(cable => cable.Name).HasMaxLength(50).IsRequired();
            builder.Property(cable => cable.Mark).HasMaxLength(50).IsRequired();
            builder.Property(cable => cable.Type).HasMaxLength(50).IsRequired();
        }
    }
}
