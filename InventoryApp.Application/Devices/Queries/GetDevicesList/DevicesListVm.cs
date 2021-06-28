using System.Collections.Generic;

namespace InventoryApp.Application.Devices.Queries.GetDevicesList
{
    public class DevicesListVm
    {
        public IList<DeviceDto> Devices { get; set; }
    }
}