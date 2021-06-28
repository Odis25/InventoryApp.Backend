using InventoryApp.Application.Common.Mappings;
using InventoryApp.Domain;

namespace InventoryApp.Application.Employees.Queries.GetEmployeeDetails
{
    public class DeviceDto : IMapWith<Device>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
    }
}