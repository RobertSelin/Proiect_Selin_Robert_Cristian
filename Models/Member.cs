using System.ComponentModel.DataAnnotations;

namespace Proiect_Selin_Robert_Cristian.Models
{
    public class Member
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau Ana-Maria)")]
        [StringLength(30, MinimumLength = 2)]
        [Display(Name = "Nume")]
        public string? FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 2)]
        [Display(Name = "Prenume")]
        public string? LastName { get; set; }

        [StringLength(70)]
        [Display(Name = "Adresa")]
        public string? Adress { get; set; }

        public string Email { get; set; }

        [RegularExpression(@"^\(?([0]{1})?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123' ")]
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        [Display(Name = "Nume Complet")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public ICollection<Booking>? Bookings { get; set; }
    }

}
