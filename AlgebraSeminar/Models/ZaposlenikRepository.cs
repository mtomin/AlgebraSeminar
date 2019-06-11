using AlgebraSeminar.Data;
using AlgebraSeminar.DTOs;
using System;
using System.Linq;
using System.Security.Cryptography;
using Unity.Attributes;

namespace AlgebraSeminar.Models
{
    public class ZaposlenikRepository : IZaposlenikRepository
    {
        [Dependency]
        public AlgebraDBContext DbContext { get; set; }
        public Zaposlenik DohvatiZaposlenika(int IdZaposlenik)
        {
            return DbContext.Zaposlenici.FirstOrDefault(z => z.IdZaposlenik == IdZaposlenik);
        }

        public void KreirajZaposlenika(Zaposlenik zaposlenik)
        {
            zaposlenik.LozinkaSalt = GenerateSalt();
            zaposlenik.Lozinka = HashPassword(zaposlenik.Lozinka, zaposlenik.LozinkaSalt);

            DbContext.Zaposlenici.Add(zaposlenik);
            DbContext.SaveChanges();
        }

        private string GenerateSalt()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[32]);
            return Convert.ToBase64String(salt);
        }

        private string HashPassword(string lozinka, string salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(lozinka, Convert.FromBase64String(salt), 5000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashedSaltedPassword = new byte[52];
            Array.Copy(Convert.FromBase64String(salt), 0, hashedSaltedPassword, 0, 32);
            Array.Copy(hash, 0, hashedSaltedPassword, 32, 20);
            return Convert.ToBase64String(hashedSaltedPassword);
        }

        public bool PrijavaUspjela(ZaposlenikZaLogin zaposlenik)
        {
            Zaposlenik userData = DbContext.Zaposlenici
                .FirstOrDefault(z => z.KorisnickoIme == zaposlenik.KorisnickoIme);

            if (userData == null)
            {
                return false;
            }

            byte[] salt = Convert.FromBase64String(userData.LozinkaSalt);
            var pkdbf2 = new Rfc2898DeriveBytes(zaposlenik.Lozinka, salt, 5000);
            byte[] hash = pkdbf2.GetBytes(20);
            byte[] passwordHash = new byte[52];

            Array.Copy(salt, 0, passwordHash, 0, 32);
            Array.Copy(hash, 0, passwordHash, 32, 20);

            if (Convert.ToBase64String(passwordHash) != userData.Lozinka)
            {
                return false;
            }
            return true;
        }
    }
}