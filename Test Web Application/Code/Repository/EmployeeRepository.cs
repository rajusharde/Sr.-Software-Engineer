using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Web_Application.Code.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Test_Web_Application.Code.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private TestDbContext context;
        private DbSet<Employee> employeeEntity;
        public EmployeeRepository(TestDbContext context)
        {
            this.context = context;
            employeeEntity = context.Set<Employee>();
        }


        public void SaveEmployee(Employee employee)
        {
            context.Entry(employee).State = EntityState.Added;
            context.SaveChanges();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeEntity.AsEnumerable();
        }

        public Employee GetEmployee(int id)
        {
            return employeeEntity.SingleOrDefault(s => s.EmployeeId == id);
        }
        public void DeleteEmployee(int id)
        {
            Employee employee = GetEmployee(id);
            employeeEntity.Remove(employee);
            context.SaveChanges();
        }
        public void UpdateEmployee(Employee employee)
        {
            context.SaveChanges();
        }

    }
}
