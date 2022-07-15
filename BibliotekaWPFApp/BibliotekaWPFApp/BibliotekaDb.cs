using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWPFApp
{
    public class BibliotekaDb : DbContext
    {
        public BibliotekaDb()
        {
            Database.EnsureCreated();

            if(!Categories.Any())
            {
                Categories.Add(new Kategoria("Powieści"));
                Categories.Add(new Kategoria("Historyczne"));
                Categories.Add(new Kategoria("Popularnonaukowe"));
                this.SaveChanges();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BibliotekaBaza;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Ksiazka> Books { get; set; }
        public DbSet<Klient> Clients { get; set; }
        public DbSet<Kategoria> Categories { get; set; }
        public DbSet<Wpozyczenie> Borrows { get; set; }
    }
}
