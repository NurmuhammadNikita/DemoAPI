using Domain.Entities;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Inrerfaces
{
    public interface IcompanyRepository
    {
        public Task CreateCompanyAsync(CreateCompanyDto company);
        public Task<Company> GetCompanyByIdAsync(Guid companyId);
        public Task<List<Company>> GetAllAsync();
        public Task  UpdateCompanyAsync(Guid companyId, CreateCompanyDto companyDto);
        public Task DeleteCompanyAsync(Guid companyId);

    }
}
