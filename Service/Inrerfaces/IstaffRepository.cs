using Domain.Entities;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Service.Inrerfaces
{
    public interface IstaffRepository
    {
        public Task CreateStaffAsync(CreateStaffDto createStaff);
        public Task <Staff> GetStaffByIdAsync(Guid staffId);
        public Task DeleteStaffAsync(Guid staffId);
        public Task UpdateStaffAsync(Guid staffId, CreateStaffDto updateStaff);

        public Task <List<Staff>> GetAllStaffsAsync();
        public Task <List<CreateEmployeeDto>> GetAllEmployeesByStaffIdAsync(Guid staffId);
        public Task AddEmployeesToStaffAsync(Guid staffId, List<Guid> employeeIds);



        /*  Ustoz yozgan kod
         * public Task CreateStaffAsync(CreateStaffDto createStaff);
        public Task<Staff> GetStaffByIdAsync(Guid staffId);
        public Task DeleteStaffAsync(Guid staffId);
        public Task UpdateStaffAsync(Guid staffId, CreateStaffDto updateStaff);
        public Task<List<Staff>> GetAllStaffsAsync();
        public Task<List<Employee>> GetAllEmployeesByStaffIdAsync(Guid staffId);
        public Task AddEmployeesToStaffAsync(Guid staffId,  List<Guid> employeeIds);*/
    }
}
