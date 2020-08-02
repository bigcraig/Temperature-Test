using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Temperature_Test.Data;
using Temperature_Test.Models;

namespace Temperature_Test.Pages.Temperature
{
    public class CreateModel : PageModel
    {
        private readonly Temperature_Test.Data.Temperature_TestContext _context;

        public CreateModel(Temperature_Test.Data.Temperature_TestContext context)
        {
            _context = context;
        }
        
        public SelectList EmployeeNameList { get; set; }
        [BindProperty]
        public string SelectedEmployeeName { get; set; }
        public void CreateEmployeeNameList()
        {
             EmployeeNameList = new SelectList(_context.Employee.Select(x => new SelectListItem
                {Text = x.FirstName + " " + x.LastName, Value = x.EmployeeID.ToString()}).ToList(),"Value","Text");

        }

        public void CreateEmployeeList2(Temperature_TestContext _context)
        {
            var employees = from e in _context.Employee
            orderby e.LastName
            select e;
            EmployeeNameList = new SelectList(employees, "EmployeeID", "LastName");
    }



        public IActionResult OnGet()
        {   CreateEmployeeNameList();
          //  CreateEmployeeList2(_context);
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
           TempMeasurement.EmployeeID = Int32.Parse(SelectedEmployeeName);
            _context.TempMeasurement.Add(TempMeasurement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
