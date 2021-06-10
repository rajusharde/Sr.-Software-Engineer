using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Web_Application.Code.IRepository;

namespace Test_Web_Application.Code.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private TestDbContext context;
        private DbSet<Department> departmentEntity;
        public DepartmentRepository(TestDbContext context)
        {
            this.context = context;
            departmentEntity = context.Set<Department>();
        }


        public void SaveDepartment(Department department)
        {
            context.Entry(department).State = EntityState.Added;
            context.SaveChanges();
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return departmentEntity.AsEnumerable();
        }

        public Department GetDepartment(int id)
        {
            return departmentEntity.SingleOrDefault(s => s.DepartmentId == id);
        }
        public void DeleteDepartment(int id)
        {
            Department department = GetDepartment(id);
            departmentEntity.Remove(department);
            context.SaveChanges();
        }
        public void UpdateDepartment(Department department)
        {
            context.SaveChanges();
        }

    }
}
