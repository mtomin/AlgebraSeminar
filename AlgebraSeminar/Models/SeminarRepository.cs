using AlgebraSeminar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity.Attributes;

namespace AlgebraSeminar.Models
{
    public class SeminarRepository : ISeminarRepository
    {
        [Dependency]
        public AlgebraDBContext DbContext { get; set; }
        public List<Seminar> GetAllSeminars()
        {
            List<Seminar> seminari = DbContext.Seminari.ToList();
            return seminari;
        }

        public Seminar GetSeminar(int seminarId)
        {
            return DbContext.Seminari.FirstOrDefault(x => x.SeminarId == seminarId);
        }

        public List<Seminar> GetUnfilledSeminars(string query)
        {
            query = (query ?? "").ToLower();
            return DbContext.Seminari.Where(s => s.BrojSlobodnihMjesta > 0 && s.Naziv.ToLower().Contains(query)).ToList();
        }
    }
}