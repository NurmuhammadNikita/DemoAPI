using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DataContext;
using Service.Dtos;
using Service.Inrerfaces;
using Service.Services;

namespace DemoAPI.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IcompanyRepository companyRepository;

        public CompaniesController(IcompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        [HttpPost]
        //Create uchun

        public async Task<IActionResult> CreateCompany([FromForm]CreateCompanyDto createCompanyDto)
        {
            await companyRepository.CreateCompanyAsync(createCompanyDto);

            return Ok("Created"); 
        }




        [HttpGet("companyid")]
        public async Task<IActionResult> GetCompanyId (Guid companyId)
        {
            var company = await companyRepository.GetCompanyByIdAsync(companyId);
            return Ok(company);
        }




        [HttpGet]

        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await companyRepository.GetAllAsync();

            return Ok(companies);
        }




        [HttpPut("companyId")]
        public async Task<IActionResult> GetCompanyId( Guid companyId, [FromForm] CreateCompanyDto updateCompany)
        {
            await companyRepository.UpdateCompanyAsync(companyId,updateCompany);
            return Ok("Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCompany(Guid companyId)
        {
            await companyRepository.DeleteCompanyAsync(companyId);

            return Ok("Deleted");
        }
    }
}
