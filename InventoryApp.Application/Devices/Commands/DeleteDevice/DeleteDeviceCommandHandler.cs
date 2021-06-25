using InventoryApp.Application.Common.Exceptions;
using InventoryApp.Application.Interfaces;
using InventoryApp.Domain;
using InventoryApp.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Devices.Commands.DeleteDevice
{
    public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand>
    {
        private readonly IAppDbContext _dbContext;

        public DeleteDeviceCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
        {
            var device = await _dbContext.Devices.FindAsync(request.Id, cancellationToken);
           
            if (device == null)
            {
                throw new NotFoundException(nameof(Device), request.Id);
            }

            var checkouts = await _dbContext.Checkouts
                .Where(checkout => checkout.Item == device
                && checkout.CheckedOut == null)
                .ToListAsync();

            foreach (var checkout in checkouts)
            {
                checkout.CheckedOut = DateTime.Now;
            }

            device.Status = Status.Deleted;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
