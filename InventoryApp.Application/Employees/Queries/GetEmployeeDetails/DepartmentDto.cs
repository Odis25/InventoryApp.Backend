using AutoMapper;
using InventoryApp.Application.Common.Mappings;
using InventoryApp.Domain;

namespace InventoryApp.Application.Employees.Queries.GetEmployeeDetails
{
    public class DepartmentDto : IMapWith<Department>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Department, DepartmentDto>();
        }
    }
}
