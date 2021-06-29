using InventoryApp.Application.Devices.Commands.CreateDevice;
using InventoryApp.Application.Devices.Commands.DeleteDevice;
using InventoryApp.Application.Devices.Commands.UpdateDevice;
using InventoryApp.Application.Devices.Queries.GetAvailableDevicesList;
using InventoryApp.Application.Devices.Queries.GetDeviceDetails;
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
            var query = new GetDevicesListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{available}")]
        public async Task<IActionResult> GetAvailable()
        {
            var query = new GetAvailableDevicesListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetDeviceDetailsQuery { Id = id };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDeviceCommand command)
        {
            var deviceId = await Mediator.Send(command);

            return Ok(deviceId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDeviceCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteDeviceCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
