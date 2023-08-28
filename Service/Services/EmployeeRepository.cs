using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DataContext;
using Service.Dtos;
using Service.Inrerfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly AppDbContext dbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.dbContext = appDbContext;
        }

        public async Task CreateEmployeeAsync(CreateEmployeeDto employee)
        {
            var createEmployee = new Employee
            {
                CompanyId = employee.CompanyId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Phone = employee.Phone,
            };
            await dbContext.Employees.AddAsync(createEmployee);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(Guid employeeId)
        {
            var result = await dbContext.Employees.FirstOrDefaultAsync(c => c.Id == employeeId); 

            dbContext.Employees.Remove(result);
            dbContext.SaveChanges();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            var results = await dbContext.Employees.ToListAsync();
            return results;
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid employeeId)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(c => c.Id == employeeId); 
            return employee;
        }

        public async Task UpdateEmployeeAsync(Guid employeeId, CreateEmployeeDto employeeDto)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(c => c.Id == employeeId); 
            employee.FirstName = employeeDto.FirstName;
            employee.LastName = employeeDto.LastName;
            employee.Email = employeeDto.Email;
            employee.Phone = employeeDto.Phone;
            employee.CompanyId = employeeDto.CompanyId;


            /*if(company is not null)
            {
                dbContext.Companies.Update(updateCompany.Adapt<Company>());
            }*/
            dbContext.Employees.Update(employee);

            dbContext.SaveChanges();
        }
    }
}
