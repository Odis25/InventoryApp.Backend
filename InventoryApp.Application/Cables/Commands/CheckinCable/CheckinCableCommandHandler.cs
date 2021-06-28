using InventoryApp.Application.Common.Exceptions;
using InventoryApp.Application.Interfaces;
using InventoryApp.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Cables.Commands.CheckinCable
{
    public class CheckinCableCommandHandler
        : IRequestHandler<CheckinCableCommand, long>
    {
        private readonly IAppDbContext _dbContext;

        public CheckinCableCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<long> Handle(CheckinCableCommand request, CancellationToken cancellationToken)
        {
            var cable = await _dbContext.Cables.FindAsync(request.CableId, cancellationToken);

            if (cable == null)
            {
                throw new NotFoundException(nameof(Device), request.CableId);
            }

            var employee = await _dbContext.Employees.FindAsync(request.EmployeeId, cancellationToken);

            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.EmployeeId);
            }

            var checkout = new Checkout
            {
                Item = cable,
                Employee = employee,
                CheckedIn = DateTime.Now
            };

            await _dbContext.Checkouts.AddAsync(checkout, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return checkout.Id;
        }
    }
}
