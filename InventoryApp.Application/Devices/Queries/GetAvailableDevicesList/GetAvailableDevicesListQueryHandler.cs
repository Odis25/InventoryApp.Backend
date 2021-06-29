using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryApp.Application.Interfaces;
using InventoryApp.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Devices.Queries.GetAvailableDevicesList
{
    public class GetAvailableDevicesListQueryHandler : IRequestHandler<GetAvailableDevicesListQuery, DevicesListVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAvailableDevicesListQueryHandler(IAppDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<DevicesListVm> Handle(GetAvailableDevicesListQuery request, CancellationToken cancellationToken)
        {
            var devices = await _dbContext.Devices
                .Where(device => device.Status == Status.Available)
                .ProjectTo<DeviceDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new DevicesListVm { Devices = devices };
        }
    }
}
