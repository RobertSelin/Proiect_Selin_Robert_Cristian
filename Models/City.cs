using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Selin_Robert_Cristian.Models
{
    public class City
    {
        public int ID { get; set; }

        [Display(Name = "Oras")]
        public string CityName { get; set; }    

        public ICollection<SportsFacility>? SportsFacilities { get; set; }   //navigation property

    }
}
