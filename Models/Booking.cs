using System.ComponentModel.DataAnnotations;

namespace Proiect_Selin_Robert_Cristian.Models
{
    public class Booking
    {
        public int ID { get; set; }

        [Display(Name = "Membru")]
        public int? MemberID { get; set; }

        public Member? Member { get; set; }

        [Display(Name = "Teren de sport")]
        public int? SportsFieldID { get; set; }

        public SportsField? SportsField { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data si ora check in")]
        public DateTime CheckInDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data si ora check out")]
        public DateTime CheckOutDate { get; set; }
    }
}
