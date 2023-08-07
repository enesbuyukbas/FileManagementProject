using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Exceptions;
using FileManagementProject.Entities.Models;
using FileManagementProject.Presentation.ActionFilters;
using FileManagementProject.Repositories.Contracts;
using FileManagementProject.Repositories.EFCore;
using FileManagementProject.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FileManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public EmployeeController(IServiceManager manager)
        {
            _manager = manager;
        }

        [ServiceFilter(typeof(LogFilterAttribute))]
        [HttpGet("/employees")]
        public async Task<IActionResult> GetAllEmployeeAsync()
        {
               var employees = await _manager.EmployeeService.GetAllEmployeesAsync(false);
               return Ok(employees);
        }

        [ServiceFilter(typeof(LogFilterAttribute))]
        [HttpGet("/employee{id:int}")]
        public async Task<IActionResult> GetOneEmployeeAsync([FromRoute(Name = "id")] int id)
        {
                var employees = await _manager
                    .EmployeeService
                    .GetOneEmployeeByIdAsync(id, false);


                return Ok(employees);

        }


        [ServiceFilter(typeof(LogFilterAttribute))]
        [HttpGet("employee/{id:int}/department")]
        public IActionResult GetEmployeeWithDepartmentName([FromRoute(Name = "id")] int id)
        {

            var employee = _manager.EmployeeService.GetOneEmployeeWithDepartment(id, false);


            var employeeDto = new EmployeeDto
            {
                EmployeeId = employee.EmployeeId,
                EmployeeFirstName = employee.EmployeeFirstName,
                EmployeeLastName = employee.EmployeeLastName,
                DepartmentName = employee.Department?.DepartmentName // Çalışanın bağlı olduğu Departmanın adını alır
            };
            return Ok(employeeDto);


        }

        [ServiceFilter(typeof(LogFilterAttribute))]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneEmployeeAsync([FromBody] Employee employee)
        {

                if (employee is null)
                    return BadRequest(employee);

                await _manager.EmployeeService.CreateOneEmployeeAsync(employee);

                return Ok();

        }

        [ServiceFilter(typeof(LogFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute(Name = "id")] int id, [FromBody] EmployeeDtoForUpdate employeeDto)
        {

                if(employeeDto is null)
                    return BadRequest(employeeDto);

                await _manager.EmployeeService.UpdateOneEmployeeAsync(id, employeeDto, true);
                return NoContent();


        }

        [ServiceFilter(typeof(LogFilterAttribute))]
        [HttpDelete]
        [Route("~/api/employee/delete/{id:int}")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute(Name = "id")] int id)
        {


                await _manager.EmployeeService.DeleteOneEmployeeAsync(id, false);


                return Ok();


        }
    }
}
