using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Web_Application.Code
{
    public class Designation
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int DesignationId { get; set; }

        public string DesignationName { get; set; }

    }
}
