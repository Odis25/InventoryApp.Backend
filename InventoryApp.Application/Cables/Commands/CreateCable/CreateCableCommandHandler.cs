using InventoryApp.Application.Interfaces;
using InventoryApp.Domain;
using InventoryApp.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Cables.Commands.CreateCable
{
    public class CreateCableCommandHandler 
        : IRequestHandler<CreateCableCommand, int>
    {
        private readonly IAppDbContext _dbContext;

        public CreateCableCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateCableCommand request, CancellationToken cancellationToken)
        {
            var cable = new Cable
            {
                Length = request.Length,
                Mark = request.Mark,
                Name = request.Name,
                Type = request.Type,
                Status = Status.Available
            };

            await _dbContext.Cables.AddAsync(cable, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return cable.Id;
        }
    }
}
