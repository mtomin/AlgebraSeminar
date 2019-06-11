using AlgebraSeminar.Models;
using System.Collections.Generic;

namespace AlgebraSeminar.DTOs
{
    public class PredbiljezbaZaEdit
    {
        public Predbiljezba Predbiljezba { get; set; }
        public List<Seminar> Seminari { get; set; }
        public string Message { get; set; }
    }
}