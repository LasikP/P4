

namespace AplKonsolowa
{
    internal class Samochod
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Cena { get; set; }
        public int RokProdukcji { get; set; }
        public int WlascicielId { get; set; }
        public Wlasciciel Wlasciciele { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Wlasciciele} - {Marka} {Model} wyd. {RokProdukcji} Cena.{Cena}";
        }
    }
}
