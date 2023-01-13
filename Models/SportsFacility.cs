using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Selin_Robert_Cristian.Models
{
    public class SportsFacility
    {
        public int ID  { get; set; }

        [Display(Name = "Nume Baza")]
        public string SportsFacilityName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        [Display(Name = "Adresa")]
        public string Adress { get; set; }  

        public ICollection<SportsField>? SportsFields { get; set; } // navigation property

        public int? CityID { get; set; }    

        public City? City { get; set; } // navigation property
    }
}
