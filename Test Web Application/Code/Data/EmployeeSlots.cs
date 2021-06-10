using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Web_Application.Code
{
    public class EmployeeSlots
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int EmployeeSlotId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "EmployeeId")]
        public int? EmployeeId1 { get; set; }
        [Required(ErrorMessage = "Select Employee is required")]
        public int? EmployeeId2 { get; set; }
        public DateTime? MeetingDate { get; set; }

        public TimeSpan? MeetingFromTime { get; set; }

        public TimeSpan? MeetingToTime { get; set; }

        public string Message { get; set; }

        public DateTime? CreatedOn { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual string Meeting_Date { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual string Meeting_FromTime { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual string Meeting_ToTime { get; set; } 
    }

}
