using AutoMapper;
using InventoryApp.Application.Common.Exceptions;
using InventoryApp.Application.Interfaces;
using InventoryApp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Devices.Queries.GetDeviceDetails
{
    public class GetDeviceDetailsQueryHandler : IRequestHandler<GetDeviceDetailsQuery, DeviceDetailsVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDeviceDetailsQueryHandler(IAppDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<DeviceDetailsVm> Handle(GetDeviceDetailsQuery request, CancellationToken cancellationToken)
        {
            var device = await _dbContext.Devices
                .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

            if (device == null)
            {
                throw new NotFoundException(nameof(Device), request.Id);
            }

            return _mapper.Map<DeviceDetailsVm>(device);
        }
    }
}
