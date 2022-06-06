

namespace Aplikacja
{
    class Owner
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public ICollection<Car> Car { get; set; }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko}";
        }
    }
}
