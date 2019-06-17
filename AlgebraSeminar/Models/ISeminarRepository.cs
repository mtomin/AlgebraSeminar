using System.Collections.Generic;

namespace AlgebraSeminar.Models
{
    public interface ISeminarRepository
    {
        List<Seminar> GetAllSeminars();
        List<Seminar> GetUnfilledSeminars(string query=null);
        Seminar GetSeminar(int seminarId);
        void DodajSeminar(Seminar seminar);
        void UrediSeminar(Seminar seminar);
        void ObrisiSeminar(int seminarId);
    }
}
