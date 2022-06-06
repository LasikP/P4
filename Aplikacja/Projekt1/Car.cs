

namespace Aplikacja
{
    class Car
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int RokWydania { get; set; }
        public int OwnerId { get; set; }

        public Owner Owner { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Owner} - {Marka} {Model} wyd. {RokWydania}";
        }
    }
}
