using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Selin_Robert_Cristian.Data;
using Proiect_Selin_Robert_Cristian.Models;

namespace Proiect_Selin_Robert_Cristian.Pages.SportsFacilities
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Proiect_Selin_Robert_Cristian.Data.Proiect_Selin_Robert_CristianContext _context;

        public EditModel(Proiect_Selin_Robert_Cristian.Data.Proiect_Selin_Robert_CristianContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SportsFacility SportsFacility { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SportsFacility == null)
            {
                return NotFound();
            }

            var sportsfacility =  await _context.SportsFacility.FirstOrDefaultAsync(m => m.ID == id);
            if (sportsfacility == null)
            {
                return NotFound();
            }
            SportsFacility = sportsfacility;

            ViewData["CityID"] = new SelectList(_context.Set<City>(), "ID", "CityName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SportsFacility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportsFacilityExists(SportsFacility.ID))
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

        private bool SportsFacilityExists(int id)
        {
          return _context.SportsFacility.Any(e => e.ID == id);
        }
    }
}
