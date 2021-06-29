using MediatR;

namespace InventoryApp.Application.Cables.Queries.GetAvailableCablesList
{
    public class GetAvailableCablesListQuery
        : IRequest<CablesListVm>
    {       
    }
}
