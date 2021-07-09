using InventoryApp.Application.Interfaces;
using InventoryApp.Domain;
using InventoryApp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public DbSet<Device> Devices { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Cable> Cables { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options,
            ICurrentUserService currentUserService)
            : base(options) =>
            _currentUserService = currentUserService;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entity in ChangeTracker.Entries<Item>())
            {
                switch (entity.State)
                {
                    case EntityState.Modified:
                        entity.Entity.EditDate = DateTime.Now;
                        entity.Entity.EditedBy = _currentUserService.UserName;
                        break;
                    case EntityState.Added:
                        entity.Entity.CreationDate = DateTime.Now;
                        entity.Entity.CreatedBy = _currentUserService.UserName;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
