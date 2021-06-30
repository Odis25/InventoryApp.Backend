using InventoryApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryApp.Persistence.EntityTypeConfigurations
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("Devices");
            builder.Property(device => device.Name).HasMaxLength(50).IsRequired();
            builder.Property(device => device.Model).HasMaxLength(50).IsRequired();
            builder.Property(device => device.Manufacturer).HasMaxLength(50).IsRequired();
            builder.Property(device => device.SerialNumber).HasMaxLength(50).IsRequired();
        }
    }
}
