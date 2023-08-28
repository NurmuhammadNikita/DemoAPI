﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<EmployeeStaff> EmployeeStaffs { get; set; }


    }
}
