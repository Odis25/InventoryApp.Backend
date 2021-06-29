using System.Collections.Generic;

namespace InventoryApp.Application.Cables.Queries.GetAvailableCablesList
{
    public class CablesListVm
    {
        public IList<CableDto> Cables { get; set; }
    }
}