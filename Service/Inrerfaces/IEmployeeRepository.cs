using Domain.Entities;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Inrerfaces
{
    public interface IEmployeeRepository
    {
        public Task CreateEmployeeAsync(CreateEmployeeDto employee);
        public Task<Employee> GetEmployeeByIdAsync(Guid employeeId);
        public Task<List<Employee>> GetAllAsync();
        public Task UpdateEmployeeAsync(Guid employeeId, CreateEmployeeDto employeeDto);
        public Task DeleteEmployeeAsync(Guid employeeId);
    }
}
