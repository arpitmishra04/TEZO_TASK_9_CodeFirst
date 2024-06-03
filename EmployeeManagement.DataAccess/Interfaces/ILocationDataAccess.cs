using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Interfaces
{
    public interface ILocationDataAccess
    {
        public List<LocationEntity> GetAll();
        public bool Set(LocationEntity locationList);
    }
}
