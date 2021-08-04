using AutoMapper;
using InventoryApp.Application.Common.Mappings;
using InventoryApp.Domain;

namespace InventoryApp.Application.Employees.Queries.GetEmployeeDetails
{
    public class CableDto : IMapWith<Cable>
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Length { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Cable, CableDto>();
        }
    }
}
