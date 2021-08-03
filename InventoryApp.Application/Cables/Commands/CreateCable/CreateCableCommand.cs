using MediatR;

namespace InventoryApp.Application.Cables.Commands.CreateCable
{
    public class CreateCableCommand : IRequest<int>
    {
        public int Length { get; set; }
        public string Name { get; set; }
        public string Mark { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
