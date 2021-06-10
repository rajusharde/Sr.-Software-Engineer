using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Web_Application.Code.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Test_Web_Application.Code.Repository
{
    public class EmployeeSlotsRepository : IEmployeeSlotsRepository
    {
        private TestDbContext context;
        private DbSet<EmployeeSlots> employeeSlotsEntity;
        public EmployeeSlotsRepository(TestDbContext context)
        {
            this.context = context;
            employeeSlotsEntity = context.Set<EmployeeSlots>();
        }


        public void SaveEmployeeSlots(EmployeeSlots employeeSlots)
        {
            context.Entry(employeeSlots).State = EntityState.Added;
            context.SaveChanges();
        }

        public IEnumerable<EmployeeSlots> GetAllEmployeeSlotss()
        {
            return employeeSlotsEntity.AsEnumerable();
        }

        public EmployeeSlots GetEmployeeSlots(int id)
        {
            return employeeSlotsEntity.SingleOrDefault(s => s.EmployeeSlotId == id);
        }
        public IEnumerable<EmployeeSlots> GetEmployeeSlotsByTodayEmpId(int empId)
        {
            var v = employeeSlotsEntity.Where(i => i.EmployeeId1 == empId || i.EmployeeId2 == empId).ToList();
            return v.Where(i => i.MeetingDate == DateTime.Now.Date && i.MeetingFromTime <= DateTime.Now.TimeOfDay && i.MeetingToTime >= DateTime.Now.TimeOfDay);
        }
        public IEnumerable<EmployeeSlots> GetEmployeeSlotsByEmpId(int empId, DateTime dt)
        {
            var v = employeeSlotsEntity.Where(i => i.EmployeeId1 == empId || i.EmployeeId2 == empId).ToList();
            return v.Where(i => i.MeetingDate == dt);
        }
        public void DeleteEmployeeSlots(int id)
        {
            EmployeeSlots employeeSlots = GetEmployeeSlots(id);
            employeeSlotsEntity.Remove(employeeSlots);
            context.SaveChanges();
        }
        public void UpdateEmployeeSlots(EmployeeSlots employeeSlots)
        {
            context.SaveChanges();
        }

    }
}
