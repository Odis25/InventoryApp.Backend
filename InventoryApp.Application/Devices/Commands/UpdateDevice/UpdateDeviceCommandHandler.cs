using InventoryApp.Application.Common.Exceptions;
using InventoryApp.Application.Interfaces;
using InventoryApp.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Devices.Commands.UpdateDevice
{
    public class UpdateDeviceCommandHandler 
        : IRequestHandler<UpdateDeviceCommand>
    {
        private readonly IAppDbContext _dbContext;

        public UpdateDeviceCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
        {
            var device = await _dbContext.Devices.FindAsync(new object[] { request.Id }, cancellationToken);

            if (device == null)
            {
                throw new NotFoundException(nameof(Device), request.Id);
            }

            device.Name = request.Name;
            device.Model = request.Model;
            device.Manufacturer = request.Manufacturer;
            device.SerialNumber = request.SerialNumber;
            device.Year = request.Year;
            device.Description = request.Description;
            device.Type = await _dbContext.DeviceTypes.FindAsync(new object[] { request.TypeId }, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
