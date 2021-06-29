using InventoryApp.Application.Common.Exceptions;
using InventoryApp.Application.Devices.Commands.CheckoutDevice;
using InventoryApp.Application.Interfaces;
using InventoryApp.Domain;
using InventoryApp.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Devices.Commands.DeleteDevice
{
    public class DeleteDeviceCommandHandler 
        : IRequestHandler<DeleteDeviceCommand>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMediator _mediator;

        public DeleteDeviceCommandHandler(IAppDbContext dbContext, IMediator mediator) =>
            (_dbContext, _mediator) = (dbContext, mediator);

        public async Task<Unit> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
        {
            var device = await _dbContext.Devices.FindAsync(new object[] { request.Id }, cancellationToken);
           
            if (device == null)
            {
                throw new NotFoundException(nameof(Device), request.Id);
            }

            await _mediator.Send(new CheckoutDeviceCommand { DeviceId = device.Id }, cancellationToken);

            device.Status = Status.Deleted;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
