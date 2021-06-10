using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace Test_Web_Application.Code.IRepository
{
    public interface IDepartmentRepository 
    {
        void SaveDepartment(Department department);
        IEnumerable<Department> GetAllDepartments();
        Department GetDepartment(int id);
        void DeleteDepartment(int id);
        void UpdateDepartment(Department department);
    }
}
