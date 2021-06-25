using MediatR;

namespace InventoryApp.Application.Checkouts.Commands.CheckinDevice
{
    public class CheckinDeviceCommand : IRequest<long>
    {
        public int DeviceId { get; set; }
        public int EmployeeId { get; set; }
    }
}
