using InventoryApp.Application.Cables.Commands.CheckoutCable;
using InventoryApp.Application.Common.Exceptions;
using InventoryApp.Application.Interfaces;
using InventoryApp.Domain;
using InventoryApp.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Cables.Commands.DeleteCable
{
    public class DeleteCableCommandHandler 
        : IRequestHandler<DeleteCableCommand>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMediator _mediator;

        public DeleteCableCommandHandler(IAppDbContext dbContext, IMediator mediator) =>
            (_dbContext, _mediator) = (dbContext, mediator);

        public async Task<Unit> Handle(DeleteCableCommand request, CancellationToken cancellationToken)
        {
            var cable = await _dbContext.Cables.FindAsync(new object[] { request.CableId }, cancellationToken);

            if (cable == null)
            {
                throw new NotFoundException(nameof(Cable), request.CableId);
            }

            await _mediator.Send(new CheckoutCableCommand { CableId = cable.Id });

            cable.Status = Status.Deleted;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
