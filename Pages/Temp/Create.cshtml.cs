using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Temperature_Test.Data;
using Temperature_Test.Models;

namespace Temperature_Test.Pages.Temp
{
    public class CreateModel : PageModel
    {
        private readonly Temperature_Test.Data.Temperature_TestContext _context;

        public CreateModel(Temperature_Test.Data.Temperature_TestContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TempMeasurement TempMeasurement { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TempMeasurement.Add(TempMeasurement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
