﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Temperature_Test.Data;
using Temperature_Test.Models;

namespace Temperature_Test.Pages.Temp
{
    public class IndexModel : PageModel
    {
        private readonly Temperature_Test.Data.Temperature_TestContext _context;

        public IndexModel(Temperature_Test.Data.Temperature_TestContext context)
        {
            _context = context;
        }

        public IList<TempMeasurement> TempMeasurement { get;set; }

        public async Task OnGetAsync()
        {
            TempMeasurement = await _context.TempMeasurement.ToListAsync();
        }
    }
}
