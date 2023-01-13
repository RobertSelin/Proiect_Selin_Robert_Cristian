using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Selin_Robert_Cristian.Data;

namespace Proiect_Selin_Robert_Cristian.Models
{
    public class SportsFieldCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;   

        public void PopulateAssignedCategoryData(Proiect_Selin_Robert_CristianContext context, SportsField sportsField)
        {
            var allCategories = context.Category;

            var sportsFieldCategories = new HashSet<int>(sportsField.SportsFieldCategories.Select(c => c.CategoryID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();

            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = sportsFieldCategories.Contains(cat.ID)
                });
            }
        }

        public void UpdateSportsFieldCategories(Proiect_Selin_Robert_CristianContext context, string[] selectedCategories, SportsField sportsFieldToUpdate)
        {
            if (selectedCategories == null)
            {
                sportsFieldToUpdate.SportsFieldCategories = new List<SportsFieldCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>(sportsFieldToUpdate.SportsFieldCategories.Select(c => c.Category.ID));

            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        sportsFieldToUpdate.SportsFieldCategories.Add(
                        new SportsFieldCategory
                        {
                            SportsFieldID = sportsFieldToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        SportsFieldCategory courseToRemove = sportsFieldToUpdate.SportsFieldCategories.SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
