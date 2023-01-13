using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Selin_Robert_Cristian.Models
{
    public class SportsField
    {
        public int ID { get; set; }

        [Display(Name = "Nume Teren")]
        public string Field_Name { get; set; }

        [Display(Name = "Pret/Ora")]
        [Column(TypeName = "decimal(7, 2)")]
        public decimal Price_Per_Hour { get; set; }

        public int? SportsFacilityID { get; set; }

        [Display(Name = "Baza Sportiva")]
        public SportsFacility? SportsFacility { get; set; } //navigation property

        [Display(Name = "Suprafata")]
        public string Surface { get; set; }

        [Display(Name = "Categorie Teren de sport")]
        public ICollection<SportsFieldCategory>? SportsFieldCategories { get; set; }
    }
}
