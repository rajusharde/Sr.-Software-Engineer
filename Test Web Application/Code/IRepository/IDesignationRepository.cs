using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace Test_Web_Application.Code.IRepository
{
    public interface IDesignationRepository
    {
        void SaveDesignation(Designation designation);
        IEnumerable<Designation> GetAllDesignations();
        Designation GetDesignation(int id);
        void DeleteDesignation(int id);
        void UpdateDesignation(Designation designation);
    }
}
 