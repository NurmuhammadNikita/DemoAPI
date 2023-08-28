using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Service.DataContext;
using Service.Dtos;
using Service.Inrerfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CompanyRepository : IcompanyRepository
    {
        private readonly AppDbContext dbContext;

        public CompanyRepository(AppDbContext appDbContext)
        {
            this.dbContext = appDbContext;
        }
        public async Task CreateCompanyAsync(CreateCompanyDto company)
        {
            var companycreate = new Company()
            {
                Address = company.Address,
                Email = company.Email,
                Name = company.Name,
                Phone = company.Phone,
                Id = Guid.NewGuid()

            };

            await dbContext.Companies.AddAsync(companycreate);
            await dbContext.SaveChangesAsync();
        }


        public async Task<List<Company>> GetAllAsync()
        {
           var results = await dbContext.Companies.ToListAsync();
            return results;
        }

        public async Task<Company> GetCompanyByIdAsync(Guid companyId)
        {
           var company = await dbContext.Companies.FirstOrDefaultAsync(c=> c.Id == companyId);
            return company;
        }
        public async Task DeleteCompanyAsync(Guid companyId)
        {
            var result = await dbContext.Companies.FirstOrDefaultAsync(c => c.Id == companyId);

            dbContext.Companies.Remove(result);
            dbContext.SaveChanges();
            
        }

        public async Task UpdateCompanyAsync(Guid companyId, CreateCompanyDto updateCompany)
        {
            var company = await dbContext.Companies.FirstOrDefaultAsync(c=>c.Id==companyId);
            company.Name = updateCompany.Name;
            company.Address = updateCompany.Address;
            company.Phone = updateCompany.Phone;
            company.Email = updateCompany.Email;
             
           /* dbContext.Companies.Update(company);
            dbContext.SaveChanges();*/

            /*if(company is not null)
            {
                dbContext.Companies.Update(updateCompany.Adapt<Company>());
            }*/
            dbContext.Companies.Update(company);

            dbContext.SaveChanges();
        }
           
    }

      
}

