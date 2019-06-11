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
        [Required]
        [StringLength(100)]
        public string Naziv { get; set; }
        [Required]
        [StringLength(200)]
        public string Opis { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Required]
        public int BrojSlobodnihMjesta { get; set; }
        [Required]
        [StringLength(100)]
        public string Predavac { get; set; }
    }
}