using MediatR;

namespace InventoryApp.Application.Devices.Queries.GetDevice
{
    public class GetDeviceDetailsQuery : IRequest<DeviceDetailsVm>
    {
        public int Id { get; set; }
    }
}
