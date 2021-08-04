using AutoMapper;
using InventoryApp.Application.Common.Mappings;
using InventoryApp.Domain;
using System;

namespace InventoryApp.Application.Employees.Queries.GetEmployeeDetails
{
    public class CheckoutCableDto : IMapWith<Checkout>
    {
        public long Id { get; set; }
        public CableDto Cable { get; set; }
        public DateTime CheckedIn { get; set; }
        public DateTime? CheckedOut { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Checkout, CheckoutCableDto>()
                .ForMember(c => c.Cable, opt =>
                 opt.MapFrom(src => src.Item as Cable));
        }
    }
}
