using System.ComponentModel.DataAnnotations;

namespace AlgebraSeminar.DTOs
{
    public class ZaposlenikZaLogin
    {
        [Required(ErrorMessage = "Korisničko ime je obavezno!")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Lozinka je obavezna!")]
        public string Lozinka { get; set; }
    }
}