using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Interfaces
{
    public interface IEmployeeDataAccess
    {
        public List<EmployeeEntity> GetAll();
        public EmployeeEntity GetOne(string employeeNumber);
        public bool Update(EmployeeEntity updatedEmployee);
        public bool Delete(string employeeNumber);
        public bool Set(EmployeeEntity employee);

    }
}
