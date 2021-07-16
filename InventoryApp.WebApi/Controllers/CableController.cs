using InventoryApp.Application.Cables.Commands.CreateCable;
using InventoryApp.Application.Cables.Commands.DeleteCable;
using InventoryApp.Application.Cables.Commands.UpdateCable;
using InventoryApp.Application.Cables.Queries.GetAvailableCablesList;
using InventoryApp.Application.Cables.Queries.GetCableDetails;
using InventoryApp.Application.Cables.Queries.GetCablesList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventoryApp.WebApi.Controllers
{
    public class CableController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetCablesListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailable()
        {
            var query = new GetAvailableCablesListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetCableDetailsQuery { Id = id };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCableCommand command)
        {
            var cableId = await Mediator.Send(command);

            return Ok(cableId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCableCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCableCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
