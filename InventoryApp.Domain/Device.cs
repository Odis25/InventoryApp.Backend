using InventoryApp.Domain.Common;

namespace InventoryApp.Domain
{
    public class Device : Item
    {
        public int? Year { get; set; }
        public virtual DeviceType Type { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }       
        
    }
}
