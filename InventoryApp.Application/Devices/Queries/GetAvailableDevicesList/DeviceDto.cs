using AutoMapper;
using InventoryApp.Application.Common.Mappings;
using InventoryApp.Domain;

namespace InventoryApp.Application.Devices.Queries.GetAvailableDevicesList
{
    public class DeviceDto : IMapWith<Device>
    {
        public int Id { get; set; }
        public int? Year { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Device, DeviceDto>()
                .ForMember(dest => dest.Type,
                opt => opt.MapFrom(src => src.Type.Name));
        }
    }
}