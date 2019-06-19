using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlgebraSeminar.Models
{
    public class Predbiljezba
    {
        [Key]
        public int IdPredbiljezba { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Required(ErrorMessage = "Ime je obavezno!")]
        [StringLength(50)]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno!")]
        [StringLength(50)]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Adresa je obavezna!")]
        [StringLength(100)]
        public string Adresa { get; set; }
        [Required(ErrorMessage = "E-mail adresa je obavezna!")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Format e-mail adrese nije valjan!")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Broj telefona je obavezan!")]
        [StringLength(30)]
        [Display(Name = "Broj telefona")]
        public string Telefon { get; set; }
        [Required, ForeignKey("Seminar")]
        public int SeminarId { get; set; }
        public virtual Seminar Seminar { get; set; }
        public int Status { get; set; }
    }
}