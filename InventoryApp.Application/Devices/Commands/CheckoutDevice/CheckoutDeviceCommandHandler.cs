using InventoryApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Devices.Commands.CheckoutDevice
{
    public class CheckoutDeviceCommandHandler
        : IRequestHandler<CheckoutDeviceCommand>
    {
        private readonly IAppDbContext _dbContext;

        public CheckoutDeviceCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(CheckoutDeviceCommand request, CancellationToken cancellationToken)
        {
            var checkout = await _dbContext.Checkouts.FirstOrDefaultAsync(checkout =>
                checkout.Item.Id == request.DeviceId
                && checkout.CheckedOut == null);

            if (checkout != null)
            {
                checkout.CheckedOut = DateTime.Now;
            }

            return Unit.Value;
        }
    }
}
