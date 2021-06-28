using AutoMapper;
using InventoryApp.Application.Common.Mappings;
using InventoryApp.Domain;
using System.Linq;

namespace InventoryApp.Application.Devices.Queries.GetDevicesList
{
    public class DeviceDto: IMapWith<Device>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }

        public EmployeeDto CurrentUser { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Device, DeviceDto>()
                .ForMember(dest => dest.Type,
                opt => opt.MapFrom(src => src.Type.Name))
                .ForMember(dest => dest.CurrentUser,
                opt => opt.MapFrom(src => src.Checkouts.FirstOrDefault(checkout => checkout.CheckedOut == null)));
        }
    }
}
