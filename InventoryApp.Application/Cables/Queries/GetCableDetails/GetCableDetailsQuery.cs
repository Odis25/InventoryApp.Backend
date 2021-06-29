using MediatR;

namespace InventoryApp.Application.Cables.Queries.GetCableDetails
{
    public class GetCableDetailsQuery : IRequest<CableDetailsVm>
    {
        public int Id { get; set; }
    }
}
