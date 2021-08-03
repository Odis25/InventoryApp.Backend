using MediatR;
using System.Collections.Generic;

namespace InventoryApp.Application.Devices.Commands.CheckinDevice
{
    public class CheckinDeviceCommand : IRequest
    {
        public IList<int> DevicesId { get; set; }
        public int EmployeeId { get; set; }
    }
}
