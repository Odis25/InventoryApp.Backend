using MediatR;

namespace InventoryApp.Application.Cables.Commands.CheckoutCable
{
    public class CheckoutCableCommand : IRequest
    {
        public int CableId { get; set; }
    }
}
