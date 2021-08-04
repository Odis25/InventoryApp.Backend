using AutoMapper;
using InventoryApp.Application.Common.Mappings;
using InventoryApp.Domain;
using System;

namespace InventoryApp.Application.Employees.Queries.GetEmployeeDetails
{
    public class CheckoutDeviceDto : IMapWith<Checkout>
    {
        public long Id { get; set; }
        public DeviceDto Device { get; set; }
        public DateTime CheckedIn { get; set; }
        public DateTime? CheckedOut { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Checkout, CheckoutDeviceDto>()
                .ForMember(c => c.Device, opt =>
                 opt.MapFrom(src => src.Item as Device));
        }
    }
}
