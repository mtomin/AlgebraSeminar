using System.Collections.Generic;

namespace AlgebraSeminar.Models
{
    public interface IPredbiljezbaRepository
    {
        List<Predbiljezba> GetPredbiljezbe();
        void UpisiPredbiljezbu(Predbiljezba predbiljezba);
        Predbiljezba GetPredbiljezba(int idPredbiljezba);
        void UrediPredbiljezbu(Predbiljezba predbiljezba, out bool status);
    }
}
