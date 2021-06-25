using InventoryApp.Application.Common.Exceptions;
using InventoryApp.Application.Interfaces;
using InventoryApp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Checkouts.Commands.CheckoutDevice
{
    public class CheckoutDeviceCommandHandler : IRequestHandler<CheckoutDeviceCommand, long>
    {
        private readonly IAppDbContext _dbContext;

        public CheckoutDeviceCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<long> Handle(CheckoutDeviceCommand request, CancellationToken cancellationToken)
        {
            var checkout = await _dbContext.Checkouts
                .FirstOrDefaultAsync(checkout => checkout.Item.Id == request.DeviceId && checkout.CheckedOut == null);

            if (checkout == null)
            {
                throw new NotFoundException(nameof(Checkout), $"DeviceId = {request.DeviceId}");
            }

            checkout.CheckedOut = DateTime.Now;

            return checkout.Id;
        }
    }
}
