using InventoryApp.Application.Devices.Commands.CheckinDevice;
using InventoryApp.Application.Devices.Commands.CheckoutDevice;
using InventoryApp.Application.Devices.Commands.CreateDevice;
using InventoryApp.Application.Devices.Commands.DeleteDevice;
using InventoryApp.Application.Devices.Commands.UpdateDevice;
using InventoryApp.Application.Devices.Queries.GetAvailableDevicesList;
using InventoryApp.Application.Devices.Queries.GetDeviceDetails;
using InventoryApp.Application.Devices.Queries.GetDevicesList;
using InventoryApp.Application.Devices.Queries.GetDeviceTypesList;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailable()
        {
            var query = new GetAvailableDevicesListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetDeviceTypes()
        {
            var query = new GetDeviceTypeListQuery();
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDeviceCommand command)
        {
            var deviceId = await Mediator.Send(command);

            return Ok(deviceId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDeviceCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteDeviceCommand { Id = id };
            await Mediator.Send(command);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("checkin")]
        public async Task<IActionResult> CheckinDevice([FromBody] CheckinDeviceCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("checkout")]
        public async Task<IActionResult> CheckoutDevice([FromBody] CheckoutDeviceCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
