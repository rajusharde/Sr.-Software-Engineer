using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Web_Application.Code.IRepository 
{
    public interface IEmployeeRepository
    {
        void SaveEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        void DeleteEmployee(int id);
        void UpdateEmployee(Employee employee);
    }
}
