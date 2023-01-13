using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Selin_Robert_Cristian.Data;
using Proiect_Selin_Robert_Cristian.Models;

namespace Proiect_Selin_Robert_Cristian.Pages.SportsFields
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : SportsFieldCategoriesPageModel
    {
        private readonly Proiect_Selin_Robert_Cristian.Data.Proiect_Selin_Robert_CristianContext _context;

        public CreateModel(Proiect_Selin_Robert_Cristian.Data.Proiect_Selin_Robert_CristianContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["SportsFacilityID"] = new SelectList(_context.Set<SportsFacility>(), "ID", "SportsFacilityName");

            var sportsField = new SportsField();

            sportsField.SportsFieldCategories = new List<SportsFieldCategory>();

            PopulateAssignedCategoryData(_context, sportsField);

            return Page();
        }

        [BindProperty]
        public SportsField SportsField { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            //if (!ModelState.IsValid)
            //  {
            //      return Page();
            //  }

            //  _context.SportsField.Add(SportsField);
            //  await _context.SaveChangesAsync();

            //  return RedirectToPage("./Index");

            //var newSportsField = new SportsField();

            var newSportsField =  SportsField;

            if (selectedCategories != null)
            {
                newSportsField.SportsFieldCategories = new List<SportsFieldCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new SportsFieldCategory
                    {
                        CategoryID = int.Parse(cat)
                    };

                    newSportsField.SportsFieldCategories.Add(catToAdd);
                }
            }

           // SportsField.SportsFieldCategories = newSportsField.SportsFieldCategories;
            _context.SportsField.Add(SportsField);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedCategoryData(_context, newSportsField);
            return Page();

        }
    }
}
