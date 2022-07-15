using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWPFApp
{
    public class Klient
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public List<Wpozyczenie> Wypozyczenia { get; set; }

        public Klient(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko}";
        }
    }
}
