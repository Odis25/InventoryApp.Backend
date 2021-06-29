﻿using InventoryApp.Application.Common.Exceptions;
using InventoryApp.Application.Interfaces;
using InventoryApp.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Devices.Commands.CheckinDevice
{
    public class CheckinDeviceCommandHandler
        : IRequestHandler<CheckinDeviceCommand, long>
    {
        private readonly IAppDbContext _dbContext;

        public CheckinDeviceCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<long> Handle(CheckinDeviceCommand request, CancellationToken cancellationToken)
        {
            var device = await _dbContext.Devices.FindAsync(new object[] { request.DeviceId }, cancellationToken);

            if (device == null)
            {
                throw new NotFoundException(nameof(Device), request.DeviceId);
            }

            var employee = await _dbContext.Employees.FindAsync(new object[] { request.EmployeeId }, cancellationToken);

            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.EmployeeId);
            }

            var checkout = new Checkout
            {
                Item = device,
                Employee = employee,
                CheckedIn = DateTime.Now
            };

            await _dbContext.Checkouts.AddAsync(checkout, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return checkout.Id;
        }
    }
}
