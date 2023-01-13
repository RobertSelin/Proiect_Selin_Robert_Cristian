namespace Proiect_Selin_Robert_Cristian.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<SportsFieldCategory> SportsFieldCategories { get; set; } 
        public IEnumerable<SportsField> SportsFields { get; set; }
    }
}
