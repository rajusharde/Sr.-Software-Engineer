using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Web_Application.Code
{
    public class Employee
    {
       [System.ComponentModel.DataAnnotations.Key]
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string EmployeeCode { get; set; }

        public int DesignationId { get; set; }

        public int DepartmentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual  List<EmployeeSlots> employeeSlots { get; set; }

    }
}
