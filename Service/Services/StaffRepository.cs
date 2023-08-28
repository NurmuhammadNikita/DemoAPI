using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DataContext;
using Service.Dtos;
using Service.Inrerfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StaffRepository : IstaffRepository
    {


        private readonly AppDbContext dbContext;

        public StaffRepository(AppDbContext appDbContext)
        {
            this.dbContext = appDbContext;
        }

        public async Task AddEmployeesToStaffAsync(Guid staffId, List<Guid> employeeIds)
        {
            var staff = await dbContext.Staffs.Include(s=>s.EmployeeStaffs).FirstOrDefaultAsync(s => s.Id == staffId);

            if (staff is not null)
            {
                foreach (var i in employeeIds)
                {
                    var employee = await dbContext.Employees.
                        FirstOrDefaultAsync(e => e.Id == i);
                    if(employee is not null)
                    {
                        var emps = new EmployeeStaff()
                        {
                            EmployeeId = employee.Id,
                            StaffId = staffId,
                        };
                        await dbContext.EmployeesStaff.AddAsync(emps);
                    }
                    await dbContext.SaveChangesAsync();

                }
            }
        }

        public async Task CreateStaffAsync(CreateStaffDto createStaff)
        {
            var staff = new Staff
            {
                Id = Guid.NewGuid(),
                Name = createStaff.Name
            };

            await dbContext.Staffs.AddAsync(staff);

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteStaffAsync(Guid staffId)
        {
            var staff = await dbContext.Staffs.FirstOrDefaultAsync(s => s.Id == staffId);
            if (staff is not null)
            {
                dbContext.Staffs.Remove(staff);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<CreateEmployeeDto>> GetAllEmployeesByStaffIdAsync(Guid staffId)
        {
            var staff = (from s in dbContext.Staffs.Where(x => x.Id == staffId)
                         from ets in dbContext.EmployeesStaff.Where(x => x.StaffId == s.Id).DefaultIfEmpty()
                         from e in dbContext.Employees.Where(x => x.Id == ets.EmployeeId)

                         select new CreateEmployeeDto
                         {
                             FirstName = e.FirstName,
                             LastName = e.LastName,
                             Phone = e.Phone,
                             Email = e.Email
                         }).ToList();

           
            return staff;
        }

        public async Task<List<Staff>> GetAllStaffsAsync() =>
            await dbContext.Staffs.ToListAsync();


        public async Task<Staff> GetStaffByIdAsync(Guid staffId) =>
            await dbContext.Staffs.FirstOrDefaultAsync(s => s.Id == staffId);


        public async Task UpdateStaffAsync(Guid staffId, CreateStaffDto updateStaff)
        {
            var staff = await dbContext.Staffs.FirstOrDefaultAsync(s => s.Id == staffId);
            if (staff is not null)
            {
                staff.Name = updateStaff.Name;
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
