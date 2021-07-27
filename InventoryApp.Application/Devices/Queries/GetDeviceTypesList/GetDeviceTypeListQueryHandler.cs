using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Devices.Queries.GetDeviceTypesList
{
    public class GetDeviceTypeListQueryHandler 
        : IRequestHandler<GetDeviceTypeListQuery, DeviceTypesListVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetDeviceTypeListQueryHandler(IAppDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<DeviceTypesListVm> Handle(GetDeviceTypeListQuery request, CancellationToken cancellationToken)
        {
            var deviceTypes = await _dbContext.DeviceTypes
                .ProjectTo<DeviceTypeDto>( _mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new DeviceTypesListVm { DeviceTypes = deviceTypes };
        }
    }
}
