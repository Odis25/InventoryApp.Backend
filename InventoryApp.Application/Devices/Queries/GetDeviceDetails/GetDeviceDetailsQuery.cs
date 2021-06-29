using MediatR;

namespace InventoryApp.Application.Devices.Queries.GetDeviceDetails
{
    public class GetDeviceDetailsQuery : IRequest<DeviceDetailsVm>
    {
        public int Id { get; set; }
    }
}
