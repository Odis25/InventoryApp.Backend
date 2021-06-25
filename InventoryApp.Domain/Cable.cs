using InventoryApp.Domain.Common;
using InventoryApp.Domain.Enums;

namespace InventoryApp.Domain
{
    public class Cable: Item
    {
        public int Length { get; set; }
        public string Name { get; set; }
        public string Mark { get; set; }
        public string Type { get; set; }
    }
}
