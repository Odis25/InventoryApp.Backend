using AutoMapper;
using InventoryApp.Application.Common.Mappings;
using InventoryApp.Domain;
using System.Collections.Generic;
using System.Linq;

namespace InventoryApp.Application.Employees.Queries.GetEmployeesList
{
    public class EmployeeDto : IMapWith<Employee>
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public string FullName { get; set; }

        public IEnumerable<DeviceDto> Devices { get; set; }
        public IEnumerable<CableDto> Cables { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Department,
                opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src =>
                $"{src.LastName} {src.Name.FirstOrDefault()}.{src.Patronymic.FirstOrDefault()}."))
                .ForMember(dest => dest.Devices,
                opt => opt.MapFrom(src => src.Checkouts.Where(c=> c.CheckedOut == null && c.Item is Device).Select(c=> (Device)c.Item)))
                .ForMember(dest => dest.Cables,
                opt => opt.MapFrom(src => src.Checkouts.Where(c => c.CheckedOut == null && c.Item is Cable).Select(c => (Cable)c.Item)));
        }
    }
}
