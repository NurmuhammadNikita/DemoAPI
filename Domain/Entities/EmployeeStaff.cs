using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmployeeStaff
    {
        [Key]
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid StaffId { get; set; }

        public Employee Employee { get; set; }
        public Staff Staff { get; set; }
    }
}
