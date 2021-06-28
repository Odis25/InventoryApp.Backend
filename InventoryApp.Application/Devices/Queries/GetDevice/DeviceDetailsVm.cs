using AutoMapper;
using InventoryApp.Application.Common.Mappings;
using InventoryApp.Domain;
using System.Collections.Generic;

namespace InventoryApp.Application.Devices.Queries.GetDevice
{
    public class DeviceDetailsVm : IMapWith<Device>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }

        public IList<CheckoutDto> Checkouts { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Device, DeviceDetailsVm>()
                .ForMember(dest => dest.Type,
                opt => opt.MapFrom(src => src.Type.Name));
        }
    }
}