using EmployeeManagement.Model;
using System.Text.RegularExpressions;
using EmployeeManagement.DataAccess;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.DataAccess.Entities;
using Nelibur.ObjectMapper;
namespace EmployeeManagement.Core.Services
{
    public class EmployeeService:IEmployeeService
    {
        private IEmployeeDataAccess employeeDataAccess;
        public EmployeeService(IEmployeeDataAccess _employeeDataAccess) {
            this.employeeDataAccess = _employeeDataAccess;
        }
        
        private List<EmployeeModel> ?employeeList;


        public void Build()
        {
            TinyMapper.Bind<EmployeeEntity, EmployeeModel>(config =>
            {
                config.Ignore(x => x.EmployeeEntityId);
                config.Ignore(x => x.RoleEntityId);

            });

            TinyMapper.Bind<EmployeeModel, EmployeeEntity>();


        }
        public bool Add(EmployeeModel employee)
        {

            Build();
            EmployeeEntity employeeEntity = TinyMapper.Map<EmployeeEntity>(employee);
            return employeeDataAccess.Set(employeeEntity);
        }
            

        public bool Delete(string employeeNumber)
        {
            return employeeDataAccess.Delete(employeeNumber);
        }

        public bool Edit(EmployeeModel updatedEmployee,string emp)
        {
            Build();
            EmployeeEntity employeeToUpdate = employeeDataAccess.GetOne(emp);
            if (employeeToUpdate != null)
            {
                TinyMapper.Map(updatedEmployee, employeeToUpdate);
                return employeeDataAccess.Update(employeeToUpdate);
            }
            else
            {
                return false;
            }
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public List<EmployeeModel> ViewAll()
        {
            Build();
            List<EmployeeEntity>employees= employeeDataAccess.GetAll();
            List<EmployeeModel> emps = [];
            foreach (EmployeeEntity emp in employees)
            {
                emps.Add(TinyMapper.Map<EmployeeModel>(emp));

            }
            return emps;
        }

        public EmployeeModel ViewOne(string employeeNumber)
        {
            Build();
            EmployeeEntity emp = employeeDataAccess.GetOne(employeeNumber);

            EmployeeModel employee = new EmployeeModel { EmpNo = "", FirstName = "", LastName = "", DateOfBirth = "", Email = "", MobileNumber = "", JobTitle = "", Department = "", JoiningDate = "", LocationId = -1, Manager = "", Project = "" };
            TinyMapper.Map(emp, employee);
            return employee;
        }


    }
}
