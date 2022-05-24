using Microsoft.EntityFrameworkCore;

namespace Projekt1
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
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Biblioteka2;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Ksiazka> Ksiazki { get; set; }
        public DbSet<Autor> Autorzy { get; set; }
    }
}
