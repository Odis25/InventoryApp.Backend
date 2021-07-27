using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryApp.Application.Interfaces;
using InventoryApp.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Devices.Queries.GetDevicesList
{
    public class GetDevicesListQueryHandler : IRequestHandler<GetDevicesListQuery, DevicesListVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDevicesListQueryHandler(IAppDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<DevicesListVm> Handle(GetDevicesListQuery request, CancellationToken cancellationToken)
        {
            var dev = await _dbContext.Devices.FirstOrDefaultAsync();
            var devices = await _dbContext.Devices
                .Where(device => device.Status != Status.Deleted)
                .ProjectTo<DeviceDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new DevicesListVm { Devices = devices };
        }
    }
}
