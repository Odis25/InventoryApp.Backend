using MediatR;

namespace InventoryApp.Application.Devices.Commands.CheckoutDevice
{
    public class CheckoutDeviceCommand : IRequest
    {
        public int DeviceId { get; set; }
    }
}
