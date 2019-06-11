using AlgebraSeminar.Data;
using System.Collections.Generic;
using System.Linq;
using Unity.Attributes;

namespace AlgebraSeminar.Models
{
    public class PredbiljezbaRepository : IPredbiljezbaRepository
    {
        [Dependency]
        public AlgebraDBContext DbContext { get; set; }

        public Predbiljezba GetPredbiljezba(int idPredbiljezba)
        {
            Predbiljezba predbiljezba = DbContext.Predbiljezbe
                .FirstOrDefault(p => p.IdPredbiljezba == idPredbiljezba);
            return predbiljezba;
        }

        public List<Predbiljezba> GetPredbiljezbe()
        {
            List<Predbiljezba> predbiljezbe = DbContext.Predbiljezbe.ToList();
            return predbiljezbe;
        }

        public void UpisiPredbiljezbu(Predbiljezba predbiljezba)
        {
            DbContext.Predbiljezbe.Add(predbiljezba);
            DbContext.SaveChanges();
        }
        public void UrediPredbiljezbu(Predbiljezba novaPredbiljezba, out bool uredbaUspjesna)
        {
            var predbiljezbaToUpdate = DbContext.Predbiljezbe
                .First(p => p.IdPredbiljezba == novaPredbiljezba.IdPredbiljezba);

            uredbaUspjesna = true;

            //if seminar was changed
            if (predbiljezbaToUpdate.SeminarId != novaPredbiljezba.SeminarId)
            {
                var seminarNovePredbiljezbe = DbContext.Seminari.First(s => s.SeminarId == novaPredbiljezba.SeminarId);
                var seminarStarePredbiljezbe = DbContext.Seminari.First(s => s.SeminarId == predbiljezbaToUpdate.SeminarId);

                if (novaPredbiljezba.Status==2)
                {
                    if (seminarNovePredbiljezbe.BrojSlobodnihMjesta == 0)
                    {
                        uredbaUspjesna = false;
                    }  
                }
                if (uredbaUspjesna)
                {
                    if (predbiljezbaToUpdate.Status==2)
                    {
                        seminarStarePredbiljezbe.BrojSlobodnihMjesta++;
                    }
                    if (novaPredbiljezba.Status==2)
                    {
                        seminarNovePredbiljezbe.BrojSlobodnihMjesta--;
                    }

                    DbContext.Entry(predbiljezbaToUpdate).CurrentValues.SetValues(novaPredbiljezba);
                    DbContext.SaveChanges();
                }
            }

            //if seminar was NOT changed
            else
            {
                var seminarToUpdate = DbContext.Seminari.First(s => s.SeminarId == novaPredbiljezba.SeminarId);

                if (predbiljezbaToUpdate.Status <= 1 && novaPredbiljezba.Status == 2)
                {
                    if (seminarToUpdate.BrojSlobodnihMjesta > 0)
                    {
                        seminarToUpdate.BrojSlobodnihMjesta--;
                    }
                    else
                    {
                        uredbaUspjesna = false;
                    }
                }
                else if (predbiljezbaToUpdate.Status == 2 && novaPredbiljezba.Status == 1)
                {
                    seminarToUpdate.BrojSlobodnihMjesta++;
                }

                if (uredbaUspjesna)
                {
                    DbContext.Entry(predbiljezbaToUpdate).CurrentValues.SetValues(novaPredbiljezba);
                    DbContext.SaveChanges();
                }
            }
        }
    }
}