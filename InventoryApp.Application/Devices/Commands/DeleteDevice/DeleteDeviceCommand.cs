using MediatR;

namespace InventoryApp.Application.Devices.Commands.DeleteDevice
{
    public class DeleteDeviceCommand : IRequest
    {
        public int Id { get; set; }
    }
}
