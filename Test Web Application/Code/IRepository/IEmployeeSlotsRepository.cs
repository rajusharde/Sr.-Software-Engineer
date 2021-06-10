using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Web_Application.Code.IRepository 
{
    public interface IEmployeeSlotsRepository 
    {
        void SaveEmployeeSlots(EmployeeSlots employeeSlots);
        IEnumerable<EmployeeSlots> GetAllEmployeeSlotss();
        EmployeeSlots GetEmployeeSlots(int id);
        IEnumerable<EmployeeSlots> GetEmployeeSlotsByEmpId(int empId, DateTime dt);
        IEnumerable<EmployeeSlots> GetEmployeeSlotsByTodayEmpId(int empId); 
        void DeleteEmployeeSlots(int id);
        void UpdateEmployeeSlots(EmployeeSlots employeeSlots);
    }
}
