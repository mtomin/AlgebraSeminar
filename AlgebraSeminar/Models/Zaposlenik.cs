using System.ComponentModel.DataAnnotations;

namespace AlgebraSeminar.Models
{
    public class Zaposlenik
    {
        [Key]
        public int IdZaposlenik { get; set; }
        [Required(ErrorMessage = "Ime zaposlenika je obavezno!")]
        [StringLength(50)]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime zaposlenika je obavezno!")]
        [StringLength(50)]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Korisničko ime je obavezno!")]
        [StringLength(20)]
        [Display(Name = "Korisničko ime")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Lozinka je obavezna!")]
        [StringLength(100)]
        public string Lozinka { get; set; }
        [Required]
        [StringLength(100)]
        public string LozinkaSalt { get; set; }
    }
}