using Proiect_Selin_Robert_Cristian.Models;

namespace Proiect_Selin_Robert_Cristian.Models.ViewModels
{
    public class SportsFacilityIndexData
    {
        public IEnumerable<SportsFacility> SportsFacilities { get; set; }
        public IEnumerable<SportsField> SportsFields { get; set; }  
    }
}
