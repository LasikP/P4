using Microsoft.EntityFrameworkCore;

namespace Aplikacja

{
    class BibliotekaDb : DbContext
    {
        public BibliotekaDb()
        {
            Database.EnsureCreated();
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Samochody;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Car> Samochody { get; set; }
        public DbSet<Owner> Wlasciciele { get; set; }
    }
}
