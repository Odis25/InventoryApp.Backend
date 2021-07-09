using InventoryApp.Application.Employees.Commands.CreateEmployee;
using InventoryApp.Application.Employees.Commands.DeleteEmployee;
using InventoryApp.Application.Employees.Commands.UpdateEmployee;
using InventoryApp.Application.Employees.Queries.GetEmployeeDetails;
using InventoryApp.Application.Employees.Queries.GetEmployeesList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventoryApp.WebApi.Controllers
{
    public class EmployeeController: ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetEmployeesListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetEmployeeDetailsQuery { Id = id };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand command)
        {
            var employeeId = await Mediator.Send(command);

            return Ok(employeeId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteEmployeeCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
