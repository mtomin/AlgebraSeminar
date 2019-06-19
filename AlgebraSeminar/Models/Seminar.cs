using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlgebraSeminar.Models
{
    public class Seminar
    {
        [Key]
        public int SeminarId { get; set; }
        [Required(ErrorMessage = "Naziv seminara je obavezan!")]
        [StringLength(100)]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Opis seminara je obavezan!")]
        [StringLength(200)]
        public string Opis { get; set; }
        [Required(ErrorMessage = "Datum održavanja seminara je obavezan!")]
        public DateTime Datum { get; set; }
        [Required(ErrorMessage = "Broj mjesta na seminaru je obavezan!")]
        [Display(Name = "Broj slobodnih mjesta")]
        public int BrojSlobodnihMjesta { get; set; }
        [Required(ErrorMessage = "Unos predavača je obavezan!")]
        [StringLength(100)]
        [Display(Name = "Predavač")]
        public string Predavac { get; set; }
    }
}