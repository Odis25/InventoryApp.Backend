using InventoryApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Cables.Commands.CheckoutCable
{
    public class CheckoutCableCommandHandler
        : IRequestHandler<CheckoutCableCommand>
    {
        private readonly IAppDbContext _dbContext;

        public CheckoutCableCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(CheckoutCableCommand request, CancellationToken cancellationToken)
        {
            var checkout = await _dbContext.Checkouts.FirstOrDefaultAsync(checkout =>
                checkout.Item.Id == request.CableId
                && checkout.CheckedOut == null);

            if (checkout != null)
            {
                checkout.CheckedOut = DateTime.Now;
            }

            return Unit.Value;

        }
    }
}
