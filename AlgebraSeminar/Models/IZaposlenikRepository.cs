﻿using AlgebraSeminar.DTOs;

namespace AlgebraSeminar.Models
{
    public interface IZaposlenikRepository
    {
        void KreirajZaposlenika(Zaposlenik zaposlenik);
        Zaposlenik DohvatiZaposlenika(int IdZaposlenik);
        Zaposlenik PrijavljeniZaposlenik(ZaposlenikZaLogin zaposlenik);
    }
}
