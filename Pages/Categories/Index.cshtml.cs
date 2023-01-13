using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Selin_Robert_Cristian.Data;
using Proiect_Selin_Robert_Cristian.Models;
using Proiect_Selin_Robert_Cristian.Models.ViewModels;

namespace Proiect_Selin_Robert_Cristian.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Selin_Robert_Cristian.Data.Proiect_Selin_Robert_CristianContext _context;

        public IndexModel(Proiect_Selin_Robert_Cristian.Data.Proiect_Selin_Robert_CristianContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int SportsFieldID { get; set; }  

        public async Task OnGetAsync(int? id, int? sportsFieldID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(i => i.SportsFieldCategories)
                .ThenInclude(c => c.SportsField)
                .ThenInclude(c => c.SportsFacility)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();

            //if (_context.Category != null)
            //{
            //    Category = await _context.Category.ToListAsync();
            //}

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories.Where(i => i.ID == id.Value).Single();
                CategoryData.SportsFieldCategories = category.SportsFieldCategories;
            }
        }
    }
}
