using InventoryApp.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Device> Devices { get; set; }
        DbSet<DeviceType> DeviceTypes { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Cable> Cables { get; set; }
        DbSet<Checkout> Checkouts { get; set; }
        DbSet<Position> Positions { get; set; }
        DbSet<Department> Departments { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancelationToken);
    }
}
