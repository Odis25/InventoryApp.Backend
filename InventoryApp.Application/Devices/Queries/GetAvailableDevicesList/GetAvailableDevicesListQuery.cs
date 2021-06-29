using MediatR;

namespace InventoryApp.Application.Devices.Queries.GetAvailableDevicesList
{
    public class GetAvailableDevicesListQuery 
        : IRequest<DevicesListVm>
    {       
    }
}
