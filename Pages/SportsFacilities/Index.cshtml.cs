using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Selin_Robert_Cristian.Data;
using Proiect_Selin_Robert_Cristian.Migrations;
using Proiect_Selin_Robert_Cristian.Models;
using Proiect_Selin_Robert_Cristian.Models.ViewModels;
using SportsFacility = Proiect_Selin_Robert_Cristian.Models.SportsFacility;

namespace Proiect_Selin_Robert_Cristian.Pages.SportsFacilities
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Selin_Robert_Cristian.Data.Proiect_Selin_Robert_CristianContext _context;

        public IndexModel(Proiect_Selin_Robert_Cristian.Data.Proiect_Selin_Robert_CristianContext context)
        {
            _context = context;
        }

        public IList<SportsFacility> SportsFacility { get;set; } = default!;

        public SportsFacilityIndexData SportsFacilityData { get; set; }
        public int SportsFacilityID { get; set; }
        public int SportsFieldID { get; set; }

        public async Task OnGetAsync(int? id, int? sportsFieldID)
        {
            SportsFacilityData = new SportsFacilityIndexData();
            SportsFacilityData.SportsFacilities = await _context.SportsFacility
                .Include(i => i.City)
                .Include(i => i.SportsFields)
                .OrderBy(i => i.SportsFacilityName)
                .ToListAsync();


            //if (_context.SportsFacility != null)
            //{
            //    SportsFacility = await _context.SportsFacility
            //        .Include(b => b.City)
            //        .ToListAsync();
            //}

            if (id != null)
            {
                SportsFacilityID = id.Value;
                SportsFacility sportsFacility = SportsFacilityData.SportsFacilities.Where(i => i.ID == id.Value).Single();
                SportsFacilityData.SportsFields = sportsFacility.SportsFields;
            }
        }
    }
}
