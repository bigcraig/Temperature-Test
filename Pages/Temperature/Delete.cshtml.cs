using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Temperature_Test.Data;
using Temperature_Test.Models;

namespace Temperature_Test.Pages.Temperature
{
    public class DeleteModel : PageModel
    {
        private readonly Temperature_Test.Data.Temperature_TestContext _context;

        public DeleteModel(Temperature_Test.Data.Temperature_TestContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TempMeasurement = await _context.TempMeasurement.FindAsync(id);

            if (TempMeasurement != null)
            {
                _context.TempMeasurement.Remove(TempMeasurement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
