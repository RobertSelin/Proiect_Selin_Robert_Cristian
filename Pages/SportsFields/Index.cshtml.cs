using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Selin_Robert_Cristian.Data;
using Proiect_Selin_Robert_Cristian.Models;

namespace Proiect_Selin_Robert_Cristian.Pages.SportsFields
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Selin_Robert_Cristian.Data.Proiect_Selin_Robert_CristianContext _context;

        public IndexModel(Proiect_Selin_Robert_Cristian.Data.Proiect_Selin_Robert_CristianContext context)
        {
            _context = context;
        }

        public IList<SportsField> SportsField { get;set; } = default!;
        public SportsFieldData SportsFieldD { get; set; }   
        public int SportsFieldID { get; set; }
        public int CategoryID { get; set; }

        public string SportsFieldSort { get; set; }
        public string SportsFacilitySort { get; set; }  

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            SportsFieldD = new SportsFieldData();

            SportsFieldSort = String.IsNullOrEmpty(sortOrder) ? "sportsField_desc" : "";
            SportsFacilitySort = String.IsNullOrEmpty(sortOrder) ? "sportsFacility_desc" : "";

            CurrentFilter = searchString;

            SportsFieldD.SportsFields = await _context.SportsField
                .Include(b => b.SportsFacility)
                .Include(b => b.SportsFieldCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Field_Name)
                .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                SportsFieldD.SportsFields = SportsFieldD.SportsFields.Where(s => s.SportsFacility.SportsFacilityName.Contains(searchString) || s.Field_Name.Contains(searchString));
            }

            if (id != null)
            {
                SportsFieldID = id.Value;
                SportsField sportsField = SportsFieldD.SportsFields.Where(i => i.ID == id.Value).Single();
                SportsFieldD.Categories = sportsField.SportsFieldCategories.Select(s => s.Category);

            }

            //if (_context.SportsField != null)
            //{
            //    SportsField = await _context.SportsField
            //        .Include(b=>b.SportsFacility)
            //        .ToListAsync();
            //}

            switch(sortOrder)
            {
                case "sportsField_desc":
                    SportsFieldD.SportsFields = SportsFieldD.SportsFields.OrderByDescending(s => s.Field_Name);
                    break;

                case "sportsFacility_desc":
                    SportsFieldD.SportsFields = SportsFieldD.SportsFields.OrderByDescending(s => s.SportsFacility.SportsFacilityName);
                    break;

            }
        }
    }
}
