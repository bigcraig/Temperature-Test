using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Temperature_Test.Models
{
    public class TempMeasurement
    {
       
        public decimal Temperature { get; set; }
        public int ID { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
 
        public DateTime MeasureDate { get; set; }
        public Boolean OfficeToday { get; set; }
        public Boolean OfficeTomorrow { get; set; }
    }
}
