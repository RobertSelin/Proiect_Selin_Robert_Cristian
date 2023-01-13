namespace Proiect_Selin_Robert_Cristian.Models
{
    public class SportsFieldData
    {
        public IEnumerable<SportsField> SportsFields { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<SportsFieldCategory> SportsFieldCategories { get; set; } 
    }
}
