using Microsoft.EntityFrameworkCore;

namespace AplKonsolowa
{
    class BazaDb : DbContext
    {
        public BazaDb()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BazaDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Samochod> Samochody { get; set; }
        public DbSet<Wlasciciel> Wlasciciele { get; set; }
    }
}
