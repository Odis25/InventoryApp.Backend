using InventoryApp.Application.Interfaces;
using InventoryApp.Domain;
using InventoryApp.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Devices.Commands.CreateDevice
{
    public class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand, int>
    {
        private readonly IAppDbContext _dbContext;
        public CreateDeviceCommandHandler(IAppDbContext dbContext) => 
            _dbContext = dbContext;

        public async Task<int> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
        {
            var device = new Device
            {
                Name = request.Name,
                Model = request.Model,
                Manufacturer = request.Manufacturer,
                SerialNumber = request.SerialNumber,
                Description = request.Description,
                Year = request.Year,
                Status = Status.Available,
                Type = await _dbContext.DeviceTypes.FindAsync(request.TypeId, cancellationToken)
            };

            await _dbContext.Devices.AddAsync(device, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return device.Id;
        }
    }
}
