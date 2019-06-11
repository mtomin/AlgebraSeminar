using System.ComponentModel.DataAnnotations;

namespace AlgebraSeminar.DTOs
{
    public class ZaposlenikZaLogin
    {
        [Required]
        public string KorisnickoIme { get; set; }
        [Required]
        public string Lozinka { get; set; }
    }
}