using MediatR;

namespace InventoryApp.Application.Cables.Commands.CheckinCable
{
    public class CheckinCableCommand : IRequest<long>
    {
        public int CableId { get; set; }
        public int EmployeeId { get; set; }
    }
}
