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
        : IRequestHandler<CheckinCableCommand>
    {
        private readonly IAppDbContext _dbContext;

        public CheckinCableCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(CheckinCableCommand request, CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees.FindAsync(new object[] { request.EmployeeId }, cancellationToken);

            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.EmployeeId);
            }

            foreach (var id in request.CablesId)
            {
                var cable = await _dbContext.Cables.FindAsync(new object[] { id }, cancellationToken);

                if (cable == null)
                {
                    throw new NotFoundException(nameof(Cable), id);
                }

                cable.Status = Domain.Enums.Status.InUse;

                var checkout = new Checkout
                {
                    Item = cable,
                    Employee = employee,
                    CheckedIn = DateTime.Now
                };

                await _dbContext.Checkouts.AddAsync(checkout, cancellationToken);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
