using MediatR;

namespace InventoryApp.Application.Cables.Commands.UpdateCable
{
    public class UpdateCableCommand : IRequest
    {
        public int Id { get; set; }
        public int Length { get; set; }
        public string Name { get; set; }
        public string Mark { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
