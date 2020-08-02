using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temperature_Test.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string  Name { get; set; }
        public List<Employee> Employees { get; set; }

    }
}
