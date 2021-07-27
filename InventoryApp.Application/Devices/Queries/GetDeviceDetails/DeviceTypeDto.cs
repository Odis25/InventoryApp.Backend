using AutoMapper;
using InventoryApp.Application.Common.Mappings;
using InventoryApp.Domain;

namespace InventoryApp.Application.Devices.Queries.GetDeviceDetails
{
    public class DeviceTypeDto : IMapWith<DeviceType>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeviceType, DeviceTypeDto>();
        }
    }
}