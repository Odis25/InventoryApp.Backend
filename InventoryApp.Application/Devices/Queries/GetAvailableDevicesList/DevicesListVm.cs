using System.Collections.Generic;

namespace InventoryApp.Application.Devices.Queries.GetAvailableDevicesList
{
    public class DevicesListVm
    {
        public IList<DeviceDto> Devices { get; set; }
    }
}