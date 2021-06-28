using AutoMapper;
using InventoryApp.Application.Common.Mappings;
using InventoryApp.Domain;
using System.Linq;

namespace InventoryApp.Application.Devices.Queries.GetDevicesList
{
    public class EmployeeDto : IMapWith<Employee>
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.LastName} {src.Name.FirstOrDefault()}.{src.Patronymic.FirstOrDefault()}."));
        }
    }
}
