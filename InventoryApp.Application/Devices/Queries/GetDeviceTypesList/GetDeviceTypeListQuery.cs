using MediatR;

namespace InventoryApp.Application.Devices.Queries.GetDeviceTypesList
{
    public class GetDeviceTypeListQuery 
        : IRequest<DeviceTypesListVm>
    {
    }
}
