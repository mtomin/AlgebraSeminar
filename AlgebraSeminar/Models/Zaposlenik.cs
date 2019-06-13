using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlgebraSeminar.Models
{
    public class Zaposlenik
    {
        [Key]
        public int IdZaposlenik { get; set; }
        [Required]
        [StringLength(50)]
        public string Ime { get; set; }
        [Required]
        [StringLength(50)]
        public string Prezime { get; set; }
        [Required]
        [StringLength(20)]
        public string KorisnickoIme { get; set; }
        [Required]
        [StringLength(100)]
        public string Lozinka { get; set; }
        [Required]
        [StringLength(100)]
        public string LozinkaSalt { get; set; }
    }
}