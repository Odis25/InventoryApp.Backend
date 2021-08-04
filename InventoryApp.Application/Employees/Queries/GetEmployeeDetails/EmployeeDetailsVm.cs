using AutoMapper;
using InventoryApp.Application.Common.Mappings;
using InventoryApp.Domain;
using System.Collections.Generic;
using System.Linq;

namespace InventoryApp.Application.Employees.Queries.GetEmployeeDetails
{
    public class EmployeeDetailsVm : IMapWith<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DepartmentDto Department { get; set; }

        public IEnumerable<CheckoutDeviceDto> DeviceCheckouts { get; set; }
        public IEnumerable<CheckoutCableDto> CableCheckouts { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDetailsVm>()
                .ForMember(dest => dest.DeviceCheckouts, opt =>
                opt.MapFrom(src => src.Checkouts.Where(c=> c.Item is Device)))
                .ForMember(dest => dest.CableCheckouts, opt =>
                opt.MapFrom(src => src.Checkouts.Where(c => c.Item is Cable)));
        }
    }
}