using AlgebraSeminar.Data;
using System.Collections.Generic;
using System.Linq;
using Unity.Attributes;

namespace AlgebraSeminar.Models
{
    public class SeminarRepository : ISeminarRepository
    {
        [Dependency]
        public AlgebraDBContext DbContext { get; set; }
        public List<Seminar> GetAllSeminars(string query)
        {
            query = (query ?? "").ToLower();
            List<Seminar> seminari = DbContext.Seminari.Where(s => s.Naziv.ToLower().Contains(query)).ToList();
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

        public void DodajSeminar(Seminar seminar)
        {
            DbContext.Seminari.Add(seminar);
            DbContext.SaveChanges();
        }

        public void UrediSeminar(Seminar seminar)
        {
            var seminarToUpdate = DbContext.Seminari.Single(s => s.SeminarId == seminar.SeminarId);
            DbContext.Entry(seminarToUpdate).CurrentValues.SetValues(seminar);
            DbContext.SaveChanges();
        }

        public void ObrisiSeminar(int seminarId)
        {
            var seminarToDelete = DbContext.Seminari.Single(s => s.SeminarId == seminarId);
            if (seminarToDelete != null)
            {
                DbContext.Seminari.Remove(seminarToDelete);
                DbContext.SaveChanges();
            }
        }
    }
}