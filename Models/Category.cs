using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Selin_Robert_Cristian.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Categorie")]
        public string CategoryName { get; set; }

        public ICollection<SportsFieldCategory>? SportsFieldCategories { get; set; }
    }
}
