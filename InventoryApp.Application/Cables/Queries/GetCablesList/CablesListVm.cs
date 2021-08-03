using System.Collections.Generic;

namespace InventoryApp.Application.Cables.Queries.GetCablesList
{
    public class CablesListVm
    {
        public IList<CableDto> Cables { get; set; }
    }
}