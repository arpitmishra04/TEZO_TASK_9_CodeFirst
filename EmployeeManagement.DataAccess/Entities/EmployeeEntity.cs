using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Entities
{
    public class EmployeeEntity
    {
        public int EmployeeEntityId { get; set; }
        public required string EmpNo { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string DateOfBirth { get; set; }
        public required string Email { get; set; }
        public required string MobileNumber { get; set; }
        public required string JoiningDate { get; set; }
        public required int LocationId { get; set; }
        public required int RoleEntityId { get; set; }
        public required string JobTitle { get; set; }
        public required string Department { get; set; }
        public required string Manager { get; set; }
        public required string Project { get; set; }
    }
}
