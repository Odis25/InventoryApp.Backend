using AutoMapper;
using InventoryApp.Application.Common.Mappings;
using InventoryApp.Domain;
using System;
using System.Collections.Generic;

namespace InventoryApp.Application.Cables.Queries.GetCableDetails
{
    public class CableDetailsVm : IMapWith<Cable>
    {
        public int Id { get; set; }
        public int Length { get; set; }
        public string Name { get; set; }
        public string Mark { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string EditedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
        public IList<CheckoutDto> Checkouts { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Cable, CableDetailsVm>();
        }
    }
}