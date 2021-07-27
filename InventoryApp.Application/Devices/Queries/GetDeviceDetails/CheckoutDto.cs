using AutoMapper;
using InventoryApp.Application.Common.Mappings;
using InventoryApp.Domain;
using System;

namespace InventoryApp.Application.Devices.Queries.GetDeviceDetails
{
    public class CheckoutDto : IMapWith<Checkout>
    {
        public long Id { get; set; }
        public EmployeeDto Employee { get; set; }
        public DateTime CheckedIn { get; set; }
        public DateTime? CheckedOut { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Checkout, CheckoutDto>();
        }
    }
}