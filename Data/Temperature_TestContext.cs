using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Temperature_Test.Models;

namespace Temperature_Test.Data
{
    public class Temperature_TestContext : DbContext
    {
        public Temperature_TestContext (DbContextOptions<Temperature_TestContext> options)
            : base(options)
        {
        }

        public DbSet<Temperature_Test.Models.Employee> Employee { get; set; }

        public DbSet<Temperature_Test.Models.TempMeasurement> TempMeasurement { get; set; }

        public DbSet<Temperature_Test.Models.Company> Company { get; set; }
    }
}
