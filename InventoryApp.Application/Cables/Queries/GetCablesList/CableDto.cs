using AutoMapper;
using InventoryApp.Application.Common.Mappings;
using InventoryApp.Domain;
using System.Linq;

namespace InventoryApp.Application.Cables.Queries.GetCablesList
{
    public class CableDto : IMapWith<Cable>
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Length { get; set; }
        public EmployeeDto CurrentUser { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Cable, CableDto>()
                .ForMember(dest => dest.CurrentUser,
                opt => opt.MapFrom(src => src.Checkouts.FirstOrDefault(checkout => checkout.CheckedOut == null).Employee)); ;
        }
    }
}
