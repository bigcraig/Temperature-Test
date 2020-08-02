using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Temperature_Test.Data.Temperature_TestContext _context;

        public DetailsModel(Temperature_Test.Data.Temperature_TestContext context)
        {
            _context = context;
        }

        public TempMeasurement TempMeasurement { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TempMeasurement = await _context.TempMeasurement.FirstOrDefaultAsync(m => m.ID == id);

            if (TempMeasurement == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
