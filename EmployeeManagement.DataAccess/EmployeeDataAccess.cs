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

         
       
        public  List<EmployeeEntity> GetAll()
        {
          
            List<EmployeeEntity> employees = [];
            
            using (var context=new ApplicationDbContext())
                {
                context.Database.EnsureCreated();

                employees=context.Employees.ToList();

            }
              
               
                  return employees; 
            }



            
            
       

        public EmployeeEntity GetOne(string employeeNumber)
        {

           
            using (var context = new ApplicationDbContext())
            {
                context.Database.EnsureCreated();

                EmployeeEntity emp = context.Employees.FirstOrDefault(e => e.EmpNo == employeeNumber)!;


                return emp;


            }


        }


        

        public bool Update(EmployeeEntity updatedEmployee)
        {
            
            using (var context = new ApplicationDbContext())
            {
                context.Database.EnsureCreated();


                if (updatedEmployee != null)
                {

                    context.Entry(updatedEmployee).State = EntityState.Modified;
                    context.SaveChanges();

                }

                return true;

            }

        }

        public bool Delete(string employeeNumber)
        {
            
            using (var context = new ApplicationDbContext())
            {
                var employeeToDelete = context.Employees.FirstOrDefault(e => e.EmpNo == employeeNumber);
                context.Database.EnsureCreated();

                if (employeeToDelete != null)
                {
                    context.Remove(employeeToDelete!);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }



            }


            
        }
        public bool Set(EmployeeEntity employee)
        {
           
            using (var context = new ApplicationDbContext())
            {
                context.Employees.Add(employee);
                context.SaveChanges();

                return true;

            }

            
        }
    }
}
