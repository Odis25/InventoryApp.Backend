using MediatR;
using System.Collections.Generic;

namespace InventoryApp.Application.Cables.Commands.CheckinCable
{
    public class CheckinCableCommand : IRequest
    {
        public IList<int> CablesId { get; set; }
        public int EmployeeId { get; set; }
    }
}
