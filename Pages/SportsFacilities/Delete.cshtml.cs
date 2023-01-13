using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Selin_Robert_Cristian.Data;
using Proiect_Selin_Robert_Cristian.Models;

namespace Proiect_Selin_Robert_Cristian.Pages.SportsFacilities
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Selin_Robert_Cristian.Data.Proiect_Selin_Robert_CristianContext _context;

        public DeleteModel(Proiect_Selin_Robert_Cristian.Data.Proiect_Selin_Robert_CristianContext context)
        {
            _context = context;
        }

        [BindProperty]
      public SportsFacility SportsFacility { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SportsFacility == null)
            {
                return NotFound();
            }

            var sportsfacility = await _context.SportsFacility
                .Include(b => b.City)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (sportsfacility == null)
            {
                return NotFound();
            }
            else 
            {
                SportsFacility = sportsfacility;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SportsFacility == null)
            {
                return NotFound();
            }
            var sportsfacility = await _context.SportsFacility.FindAsync(id);

            if (sportsfacility != null)
            {
                SportsFacility = sportsfacility;
                _context.SportsFacility.Remove(SportsFacility);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
