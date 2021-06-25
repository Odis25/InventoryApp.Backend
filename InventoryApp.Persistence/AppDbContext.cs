using InventoryApp.Application.Interfaces;
using InventoryApp.Domain;
using InventoryApp.Domain.Common;
using InventoryApp.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Cable> Cables { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DeviceConfiguration());
            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entity in ChangeTracker.Entries<Item>())
            {
                switch (entity.State)
                {
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entity.Entity.EditDate = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entity.Entity.EditDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
