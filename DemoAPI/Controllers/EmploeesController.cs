using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DataContext;
using Service.Dtos;
using Service.Inrerfaces;
using Service.Services;


namespace DemoAPI.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmploeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;


        public EmploeesController( IEmployeeRepository employeeRepository )
        {
            this.employeeRepository = employeeRepository;
        }


        [HttpPost]

        public async Task <IActionResult> CreateEmployee([FromForm] CreateEmployeeDto createEmployeeDto)
        {
            await employeeRepository.CreateEmployeeAsync(createEmployeeDto);

            return Ok("Created");
        }


        [HttpGet("EmployeeId")]
        public async Task<IActionResult> GetemployeeId(Guid employeeId)
        {
            var employee = await employeeRepository.GetEmployeeByIdAsync(employeeId);

            return Ok(employee);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var employee = await employeeRepository.GetAllAsync();

            return Ok(employee);
        }




        [HttpPut("EmployeeId")]

        public async Task<IActionResult> GetEmployeeId (Guid employeeId, [FromForm] CreateEmployeeDto updateEmployee)
        {
            await employeeRepository.UpdateEmployeeAsync(employeeId, updateEmployee);

            return Ok(employeeId);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCompany(Guid employeeId)
        {
            await employeeRepository.DeleteEmployeeAsync(employeeId);

            return Ok("Deleted");
        }




    }
}
