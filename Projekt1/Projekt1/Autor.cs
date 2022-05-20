

namespace Projekt1
{
    class Autor
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public ICollection<Ksiazka> Ksiazki { get; set; }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko}";
        }
    }
}
