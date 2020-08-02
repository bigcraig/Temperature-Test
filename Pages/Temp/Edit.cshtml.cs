using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Temperature_Test.Data;
using Temperature_Test.Models;

namespace Temperature_Test.Pages.Temp
{
    public class EditModel : PageModel
    {
        private readonly Temperature_Test.Data.Temperature_TestContext _context;

        public EditModel(Temperature_Test.Data.Temperature_TestContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TempMeasurement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TempMeasurementExists(TempMeasurement.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TempMeasurementExists(int id)
        {
            return _context.TempMeasurement.Any(e => e.ID == id);
        }
    }
}
