using System.Collections.Generic;

namespace InventoryApp.Application.Devices.Queries.GetDeviceTypesList
{
    public class DeviceTypesListVm
    {
        public IEnumerable<DeviceTypeDto> DeviceTypes { get; set; }
    }
}