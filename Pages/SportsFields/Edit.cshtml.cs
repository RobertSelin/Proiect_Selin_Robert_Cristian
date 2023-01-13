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

namespace Proiect_Selin_Robert_Cristian.Pages.SportsFields
{
    [Authorize(Roles = "Admin")]
    public class EditModel : SportsFieldCategoriesPageModel
    {
        private readonly Proiect_Selin_Robert_Cristian.Data.Proiect_Selin_Robert_CristianContext _context;

        public EditModel(Proiect_Selin_Robert_Cristian.Data.Proiect_Selin_Robert_CristianContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SportsField SportsField { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SportsField == null)
            {
                return NotFound();
            }

            //var sportsfield =  await _context.SportsField.FirstOrDefaultAsync(m => m.ID == id);

            SportsField = await _context.SportsField
                .Include(b => b.SportsFacility)
                .Include(b => b.SportsFieldCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (SportsField == null)
            {
                return NotFound();
            }
            // SportsField = sportsfield;

            PopulateAssignedCategoryData(_context, SportsField);

            ViewData["SportsFacilityID"] = new SelectList(_context.Set<SportsFacility>(), "ID", "SportsFacilityName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Attach(SportsField).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!SportsFieldExists(SportsField.ID))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return RedirectToPage("./Index");

            if (id == null)
            {
                return NotFound();
            }

            var sportsFieldToUpdate = await _context.SportsField
                .Include(i => i.SportsFacility)
                .Include(i => i.SportsFieldCategories).ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (sportsFieldToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<SportsField>(sportsFieldToUpdate, "SportsField", i => i.Field_Name, i => i.Price_Per_Hour, i => i.SportsFacilityID, i => i.Surface))
            {
                UpdateSportsFieldCategories(_context, selectedCategories, sportsFieldToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateSportsFieldCategories(_context, selectedCategories, sportsFieldToUpdate);
            PopulateAssignedCategoryData(_context, sportsFieldToUpdate);
            return Page();

        }

        private bool SportsFieldExists(int id)
        {
          return _context.SportsField.Any(e => e.ID == id);
        }
    }
}
