using InventoryApp.Application.Common.Exceptions;
using InventoryApp.Application.Interfaces;
using InventoryApp.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Cables.Commands.UpdateCable
{
    public class UpdateCableCommandHandler 
        : IRequestHandler<UpdateCableCommand>
    {
        private readonly IAppDbContext _dbContext;

        public UpdateCableCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateCableCommand request, CancellationToken cancellationToken)
        {
            var cable = await _dbContext.Cables.FindAsync(new object[] { request.Id }, cancellationToken);

            if (cable == null)
            {
                throw new NotFoundException(nameof(Cable), request.Id);
            }

            cable.Length = request.Length;
            cable.Mark = request.Mark;
            cable.Name = request.Name;
            cable.Type = request.Type;
            cable.Description = request.Description;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
