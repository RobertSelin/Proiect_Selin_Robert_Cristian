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

namespace Proiect_Selin_Robert_Cristian.Pages.SportsFields
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
      public SportsField SportsField { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SportsField == null)
            {
                return NotFound();
            }

            var sportsfield = await _context.SportsField
                .Include(b => b.SportsFacility)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (sportsfield == null)
            {
                return NotFound();
            }
            else 
            {
                SportsField = sportsfield;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SportsField == null)
            {
                return NotFound();
            }
            var sportsfield = await _context.SportsField.FindAsync(id);

            if (sportsfield != null)
            {
                SportsField = sportsfield;
                _context.SportsField.Remove(SportsField);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
