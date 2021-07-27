using AutoMapper;
using InventoryApp.Application.Common.Mappings;
using InventoryApp.Domain;
using System;
using System.Collections.Generic;

namespace InventoryApp.Application.Devices.Queries.GetDeviceDetails
{
    public class DeviceDetailsVm : IMapWith<Device>
    {
        public int Id { get; set; }
        public int? Year { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string EditedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
        public DeviceTypeDto Type { get; set; }

        public IList<CheckoutDto> Checkouts { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Device, DeviceDetailsVm>();
        }
    }
}