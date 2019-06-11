using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlgebraSeminar.Models
{
    public class Predbiljezba
    {
        [Key]
        public int IdPredbiljezba { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Required]
        [StringLength(50)]
        public string Ime { get; set; }
        [Required]
        [StringLength(50)]
        public string Prezime { get; set; }
        [Required]
        [StringLength(100)]
        public string Adresa { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(30)]
        public string Telefon { get; set; }
        [Required, ForeignKey("Seminar")]
        public int SeminarId { get; set; }
        public virtual Seminar Seminar { get; set; }
        public int Status { get; set; }
    }
}