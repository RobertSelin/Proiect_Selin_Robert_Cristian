namespace Proiect_Selin_Robert_Cristian.Models
{
    public class SportsFieldCategory
    {
        public int ID { get; set; } 

        public int SportsFieldID { get; set; }

        public SportsField SportsField { get; set; }    

        public int CategoryID { get; set; }

        public Category Category { get; set; }  
    }
}
