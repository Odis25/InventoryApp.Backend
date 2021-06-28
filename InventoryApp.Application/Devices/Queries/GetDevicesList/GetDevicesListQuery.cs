using MediatR;

namespace InventoryApp.Application.Devices.Queries.GetDevicesList
{
    public class GetDevicesListQuery 
        : IRequest<DevicesListVm>
    {      
    }
}
