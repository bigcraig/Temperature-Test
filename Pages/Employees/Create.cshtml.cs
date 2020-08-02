 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Temperature_Test.Data;
using Temperature_Test.Models;

namespace Temperature_Test.Pages.Employees
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
           PopulateCompanies(_context);

            return Page();
        }
        // ncw property to receive list of company names
        public SelectList CompanySelectList;
        public SelectListItem craig;
        [BindProperty]
        public string SelectedCompanyName { set; get; }
        private void PopulateCompanies(Temperature_TestContext _context)
        {
            var companies = from c in _context.Company
                orderby c.Name
                select c;
            CompanySelectList = new SelectList(companies, "Name", "Name");
        }

        [BindProperty]
        public Employee Employee { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Models.Company selectedCompany =
                _context.Company.FirstOrDefault(c => c.Name == SelectedCompanyName);
            Employee.CompanyID = selectedCompany.CompanyID;
            _context.Employee.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
