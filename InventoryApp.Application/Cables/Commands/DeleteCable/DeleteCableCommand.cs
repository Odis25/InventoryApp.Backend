using MediatR;

namespace InventoryApp.Application.Cables.Commands.DeleteCable
{
    public class DeleteCableCommand : IRequest
    { 
        public int CableId { get; set; }
    }
}
