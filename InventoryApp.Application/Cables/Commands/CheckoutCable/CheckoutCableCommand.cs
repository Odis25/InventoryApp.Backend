using MediatR;

namespace InventoryApp.Application.Checkouts.Commands.CheckoutCable
{
    public class CheckoutCableCommand : IRequest
    {
        public int CableId { get; set; }
    }
}
