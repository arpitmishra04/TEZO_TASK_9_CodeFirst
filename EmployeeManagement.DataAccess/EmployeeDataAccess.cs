using System.Data;
using System.Data.SqlClient;
using System.Text;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Microsoft.EntityFrameworkCore;
using Nelibur.ObjectMapper;
namespace EmployeeManagement.DataAccess
{
    public class EmployeeDataAccess:IEmployeeDataAccess
    {

         public void Build() {
            TinyMapper.Bind<EmployeeEntity, EmployeeModel>(config =>
            {
                config.Ignore(x => x.EmployeeEntityId);
                config.Ignore(x => x.RoleEntityId);
                
            });

            TinyMapper.Bind<EmployeeModel, EmployeeEntity>();


        }
       
        public  List<EmployeeModel> GetAll()
        {
            Build();
            List<EmployeeEntity> employees = [];
            List<EmployeeModel> emps = [];
           

            using (var context=new ApplicationDbContext())
                {
                context.Database.EnsureCreated();

                employees=context.Employees.ToList();

            }
                 foreach(EmployeeEntity emp in employees)
            {
                emps.Add(TinyMapper.Map<EmployeeModel>(emp))    ;

            }   
               
                  return emps; 
            }



            
            
       

        public EmployeeModel GetOne(string employeeNumber)
        {

            Build();
            using (var context = new ApplicationDbContext())
            {
                context.Database.EnsureCreated();

                EmployeeEntity emp =context.Employees.FirstOrDefault(e => e.EmpNo == employeeNumber)!;
                EmployeeModel employee = TinyMapper.Map<EmployeeModel>(emp);

                return employee;

            }


        }


        

        public bool Update(EmployeeModel updatedEmployee,string empNo)
        {
            Build();
            using (var context = new ApplicationDbContext())
            {
                context.Database.EnsureCreated();

                var employeeToUpdate = context.Employees.FirstOrDefault(e => e.EmpNo == empNo);
                if (employeeToUpdate != null)
                {
                    TinyMapper.Map(updatedEmployee, employeeToUpdate);
                    context.Entry(employeeToUpdate).State = EntityState.Modified;
                    context.SaveChanges();
                   
                }

                return true;

            }

        }

        public bool Delete(string employeeNumber)
        {
            Build();
            using (var context = new ApplicationDbContext())
            {
                var employeeToDelete = context.Employees.FirstOrDefault(e => e.EmpNo == employeeNumber);
                context.Database.EnsureCreated();

                context.Remove<EmployeeEntity>(employeeToDelete!);
                context.SaveChanges();
                return true;

            }


            
        }
        public bool Set(EmployeeModel employee)
        {
            Build();
            using (var context = new ApplicationDbContext())
            {
                EmployeeEntity employeeEntity = TinyMapper.Map<EmployeeEntity>(employee); ;
                context.Employees.Add(employeeEntity);
                context.SaveChanges();

                return true;

            }

            
        }
    }
}
