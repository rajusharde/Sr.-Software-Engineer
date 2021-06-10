using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Web_Application.Code
{
    public class Department
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

    }
}
