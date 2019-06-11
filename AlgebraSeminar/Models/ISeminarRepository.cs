using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraSeminar.Models
{
    public interface ISeminarRepository
    {
        List<Seminar> GetAllSeminars();
        List<Seminar> GetUnfilledSeminars(string query=null);
        Seminar GetSeminar(int seminarId);
    }
}
