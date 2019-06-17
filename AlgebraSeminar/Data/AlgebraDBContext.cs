using AlgebraSeminar.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AlgebraSeminar.Data
{
    public class AlgebraDBContext : DbContext
    {
        public AlgebraDBContext() : base("AlgebraDBContext")
        {
        }

        public DbSet<Predbiljezba> Predbiljezbe { get; set; }
        public DbSet<Seminar> Seminari { get; set; }
        public DbSet<Zaposlenik> Zaposlenici { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}