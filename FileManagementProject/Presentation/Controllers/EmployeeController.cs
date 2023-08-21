using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Exceptions;
using FileManagementProject.Entities.Models;
using FileManagementProject.Entities.RequestFeatures;
using FileManagementProject.Presentation.ActionFilters;
using FileManagementProject.Repositories.Contracts;
using FileManagementProject.Repositories.EFCore;
using FileManagementProject.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FileManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [ApiExplorerSettings(GroupName = "v1")]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public EmployeeController(IServiceManager manager)
        {
            _manager = manager;
        }

        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        [HttpGet("/employees")]
        public async Task<IActionResult> GetAllEmployeeAsync([FromQuery] EmployeeParameters employeeParameters)
        {
               var pagedResult = await _manager
                .EmployeeService
                .GetAllEmployeesAsync(employeeParameters, false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

               return Ok(pagedResult.employees);
        }
        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        [HttpGet("/employee/{id:int}")]
        public async Task<IActionResult> GetOneEmployeeAsync([FromRoute(Name = "id")] int id)
        {
                var employees = await _manager
                    .EmployeeService
                    .GetOneEmployeeByIdAsync(id, false);


                return Ok(employees);

        }

        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        [HttpGet("/employee/{id:int}/department")]
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
        [HttpPost]
        [Route("~/api/employee/create/{id:int}")]
        public async Task<IActionResult> CreateOneEmployeeAsync([FromBody] EmployeeDtoForCreate employeeDto)
        {

                if (employeeDto is null)
                    return BadRequest(employeeDto);

            await _manager.EmployeeService.CreateOneEmployeeAsync(employeeDto);

            var employee = new Employee
            {
                EmployeeId = employeeDto.EmployeeId,
                EmployeeFirstName = employeeDto.EmployeeFirstName,
                EmployeeLastName = employeeDto.EmployeeLastName,
                EmployeeEmail = employeeDto.EmployeeEmail,
                EmployeePassword = employeeDto.EmployeePassword,
                EmployeeManagerId = employeeDto.EmployeeManagerId,
                DepartmentId = employeeDto.DepartmentId
            };

            return Ok(employee);

        }

        [ServiceFilter(typeof(LogFilterAttribute))]
        [HttpPut]
        [Route("~/api/employee/update/{id:int}")]
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
