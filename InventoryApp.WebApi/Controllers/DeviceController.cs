using InventoryApp.Application.Devices.Commands.CreateDevice;
using InventoryApp.Application.Devices.Queries.GetDevice;
using InventoryApp.Application.Devices.Queries.GetDevicesList;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventoryApp.WebApi.Controllers
{
    public class DeviceController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vm = await Mediator.Send(new GetDevicesListQuery());

            return Ok(vm);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int deviceId)
        {
            var vm = await Mediator.Send(new GetDeviceDetailsQuery { Id = deviceId });

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDeviceCommand command)
        {
            var deviceId = await Mediator.Send(command);

            return Ok(deviceId);
        }
    }
}
