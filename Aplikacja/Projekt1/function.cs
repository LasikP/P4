
using Microsoft.EntityFrameworkCore;


namespace Aplikacja
{
  
    internal class function
    {
       public static void showCars(BibliotekaDb db)
        {
            foreach (var k in db.Samochody.Include(i => i.Owner))
            {
                Console.WriteLine(k);
            }
        }

        public static void addCar(BibliotekaDb db)
        {
            foreach (var a in db.Wlasciciele)
            {
                Console.WriteLine(a.Id + ": " + a);
            }

            Console.WriteLine("Wprowadz id Właściciela:");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var owner = db.Wlasciciele.Find(id);

                if (owner != null)
                {
                    Console.WriteLine("Podaj Marke Auta:");
                    string marka = Console.ReadLine();

                    Console.WriteLine("Podaj Model Auta:");
                    string model = Console.ReadLine();
                    int rok = 0;

                    Console.WriteLine("Podaj rok wydania:");

                    if (int.TryParse(Console.ReadLine(), out rok))
                    {
                        Car k = new Car()
                        {
                            Marka = marka,
                            Model = model,
                            RokWydania = rok,
                            OwnerId = owner.Id
                        };

                        db.Samochody.Add(k);
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Rok musi być liczbą.");
                    }

                }
                else
                {
                    Console.WriteLine("Brak wlaściciela o podanym id.");
                }
            }
            else
            {
                Console.WriteLine("Wprowadzono błędną liczbę");
            }
        }

        public static void removeCar(BibliotekaDb db)
        {
            Console.WriteLine("Wprowadz id auta do usunięcia:");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var removed = db.Samochody.Find(id);

                if (removed != null)
                {
                    db.Samochody.Remove(removed);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Brak samochodu o podanym id.");
                }
            }
        }

        public static void findMarks(BibliotekaDb db)
        {
            Console.WriteLine("Wprowadź szukaną markę.");
            string fraza = Console.ReadLine();

            var cars = db.Samochody.Where(w => w.Marka.ToLower().Contains(fraza.ToLower())).Include(i => i.Owner);

            foreach (var k in cars)
            {
                Console.WriteLine(k);
            }
        }
        public static void findModel(BibliotekaDb db)
        {
            Console.WriteLine("Wprowadź szukany model.");
            string fraza = Console.ReadLine();

            var cars = db.Samochody.Where(w => w.Model.ToLower().Contains(fraza.ToLower())).Include(i => i.Owner);

            foreach (var k in cars)
            {
                Console.WriteLine(k);
            }
        }
        public static void showOwners(BibliotekaDb db)
        {
            foreach (var a in db.Wlasciciele)
            {
                Console.WriteLine(a.Id + ": " + a);
            }
        }

        public static void addOwners(BibliotekaDb db)
        {
            Console.WriteLine("Podaj imie wlaściciela:");
            string imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko właściciela:");
            string nazwisko = Console.ReadLine();

            Owner a = new Owner()
            {
                Imie = imie,
                Nazwisko = nazwisko
            };

            db.Wlasciciele.Add(a);
            db.SaveChanges();
        }

        public static void removeOwners(BibliotekaDb db)
        {
            Console.WriteLine("Wprowadz id właściciela do usunięcia:");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var removed = db.Wlasciciele.Find(id);

                if (removed != null)
                {
                    db.Wlasciciele.Remove(removed);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Brak właściciela o podanym id.");
                }
            }
        }

        public static void findOwners(BibliotekaDb db)
        {
            Console.WriteLine("Wprowadź szukane nazwisko.");
            string fraza = Console.ReadLine();

            var autorzy = db.Wlasciciele.Where(w => w.Nazwisko.ToLower().Contains(fraza.ToLower())).Include(i => i.Car);

            foreach (var a in autorzy)
            {
                Console.WriteLine(a);

                Console.WriteLine("Oto auta tego właściciela:");

                foreach (var k in a.Car)
                {
                    Console.WriteLine($"{k.Marka} {k.Model} wyprodukowana roku {k.RokWydania}");
                }
            }
        }


    }
}
