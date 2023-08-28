using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Inrerfaces;
using Service.Services;

namespace DemoAPI.Controllers
{
    [Route("api/staff")]
    [ApiController]

    public class StaffsController : ControllerBase
    {
        private readonly IstaffRepository staffRepository;

        public StaffsController(IstaffRepository staffRepository)
        {
            this.staffRepository = staffRepository;
        }

        [HttpGet]

        public async Task<ActionResult> GetAll() => Ok(await staffRepository.GetAllStaffsAsync());

        [HttpPost]
        public async Task<ActionResult> CreateStaff([FromForm] CreateStaffDto createStaffDto) 
        {
            await staffRepository.CreateStaffAsync(createStaffDto);

            return Ok("Created");
        }

        [HttpPost("staffId")]
        public async Task<ActionResult> AddEmplyeesToStaff(Guid staffId, [FromForm] List<Guid> employeesIds)
        {
            await staffRepository.AddEmployeesToStaffAsync(staffId, employeesIds);

            return Ok("Created");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteCompany(Guid staffId)
        {
            await staffRepository.DeleteStaffAsync(staffId);

            return Ok("Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> GetStaffId(Guid staffId, [FromForm] CreateStaffDto updateStaff)
        {
            await staffRepository.UpdateStaffAsync(staffId, updateStaff);

            return Ok(staffId);
        }

        [HttpGet("StaffId")]
        public async Task<IActionResult> GetemployeeId(Guid staffId)
        {
            var staff = await staffRepository.GetStaffByIdAsync(staffId);

            return Ok(staff);
        }
        [HttpGet("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployeesByStaffIdAsync(Guid staffId)
        {
            var emp = await staffRepository.GetAllEmployeesByStaffIdAsync(staffId);
            return Ok(emp);
        }
    }      
        
}

        
