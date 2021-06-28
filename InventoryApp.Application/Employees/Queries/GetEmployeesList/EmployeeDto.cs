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
        public string Position { get; set; }
        public string FullName { get; set; }

        public IEnumerable<CheckoutDto> Checkouts { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Position,
                opt => opt.MapFrom(src => src.Position.Name))
                .ForMember(dest => dest.Department,
                opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src =>
                $"{src.LastName} {src.Name.FirstOrDefault()}.{src.Patronymic.FirstOrDefault()}."));
        }
    }
}
