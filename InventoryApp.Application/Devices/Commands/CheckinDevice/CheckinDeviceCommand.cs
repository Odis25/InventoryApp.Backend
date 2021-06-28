using MediatR;

namespace InventoryApp.Application.Devices.Commands.CheckinDevice
{
    public class CheckinDeviceCommand : IRequest<long>
    {
        public int DeviceId { get; set; }
        public int EmployeeId { get; set; }
    }
}
