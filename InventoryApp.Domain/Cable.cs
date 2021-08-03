using InventoryApp.Domain.Common;

namespace InventoryApp.Domain
{
    public class Cable: Item
    {
        public int Length { get; set; }
        public string Name { get; set; }
        public string Mark { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
