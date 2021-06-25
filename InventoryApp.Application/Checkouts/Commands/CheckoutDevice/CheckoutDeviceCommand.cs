using MediatR;

namespace InventoryApp.Application.Checkouts.Commands.CheckoutDevice
{
    public class CheckoutDeviceCommand : IRequest<long>
    {
        public int DeviceId { get; set; }
    }
}
