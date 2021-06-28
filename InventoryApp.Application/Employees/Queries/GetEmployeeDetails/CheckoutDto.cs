﻿using InventoryApp.Application.Common.Mappings;
using InventoryApp.Domain;
using System;

namespace InventoryApp.Application.Employees.Queries.GetEmployeeDetails
{
    public class CheckoutDto : IMapWith<Checkout>
    {
        public long Id { get; set; }
        public DeviceDto Device { get; set; }
        public DateTime CheckedIn { get; set; }
        public DateTime? CheckedOut { get; set; }
    }
}