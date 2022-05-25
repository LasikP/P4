

namespace Projekt1
{
   class Ksiazka
    {
        public int Id { get; set; }
        public string Tytul { get; set; }
        public int RokWydania { get; set; }
        public int AutorId { get; set; }

        public Autor Autor { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Autor} - {Tytul} wyd. {RokWydania}";
        }
    }
}
