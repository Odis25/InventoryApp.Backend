using MediatR;

namespace InventoryApp.Application.Devices.Commands.CreateDevice
{
    public class CreateDeviceCommand : IRequest<int>
    {
        public int? Year { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
    }
}
