using Microsoft.EntityFrameworkCore;

namespace AplKonsolowa
{
    internal class F
    {
        public static void DodajW(BazaDb db)
        {
            Console.WriteLine("Podaj Imie wlaściciela:");
            string imie = Console.ReadLine();
            Console.WriteLine("Podaj Nazwisko właściciela:");
            string nazwisko = Console.ReadLine();
            Console.WriteLine("Podaj Pesel właściciela:");
            string pesel = Console.ReadLine();

            Wlasciciel a = new Wlasciciel()
            {
                Imie = imie,
                Nazwisko = nazwisko,
                Pesel = pesel
            };

            db.Wlasciciele.Add(a);
            db.SaveChanges();
        }
        public static void UsunW(BazaDb db)
        {
            Console.WriteLine("Wprowadz id Właściciela do usunięcia:");

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

        public static void ZnajdzWpN(BazaDb db)
        {
            Console.WriteLine("Wprowadź szukane Nazwisko.");
            string fraza = Console.ReadLine();

            var wlas = db.Wlasciciele.Where(w => w.Nazwisko.ToLower().Contains(fraza.ToLower())).Include(i => i.Samochody);

            foreach (var a in wlas)
            {
                Console.WriteLine(a);
            }

        }
        public static void ZnajdzWpP(BazaDb db)
        {
            Console.WriteLine("Wprowadź szukany Pesel.");
            string fraza = Console.ReadLine();

            var wlas = db.Wlasciciele.Where(w => w.Pesel.ToLower().Contains(fraza.ToLower())).Include(i => i.Samochody);

            foreach (var a in wlas)
            {
                Console.WriteLine(a);
            }

        }



        public static void ZnajdzWpNiS(BazaDb db)
        {
            Console.WriteLine("Wprowadź szukane Nazwisko.");
            string fraza = Console.ReadLine();

            var wlas = db.Wlasciciele.Where(w => w.Nazwisko.ToLower().Contains(fraza.ToLower())).Include(i => i.Samochody);

            foreach (var a in wlas)
            {
                Console.WriteLine(a);

                Console.WriteLine("Oto auta tego właściciela:");

                foreach (var k in a.Samochody)
                {
                    Console.WriteLine($"{k.Marka} {k.Model} wyprodukowane roku {k.RokProdukcji} cena samochodu {k.Cena}");
                }
            }

        }
        public static void PokazW(BazaDb db)
        {
            foreach (var a in db.Wlasciciele)
            {
                Console.WriteLine(a.Id + ": " + a);
            }
        }

        public static void DodajS(BazaDb db)
        {
            foreach (var a in db.Wlasciciele)
            {
                Console.WriteLine(a.Id + ": " + a);
            }

            Console.WriteLine("Wprowadz id Właściciela:");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var wlas = db.Wlasciciele.Find(id);

                if (wlas != null)
                {
                    Console.WriteLine("Podaj Marke Samochodu:");
                    string marka = Console.ReadLine();

                    Console.WriteLine("Podaj Model Samochodu:");
                    string model = Console.ReadLine();
                    Console.WriteLine("Podaj Cene Samochodu");
                    string cena = Console.ReadLine();

                   ;
                    Console.WriteLine("Podaj Rok produkcji:");
                    int rok = 1;

                    if (int.TryParse(Console.ReadLine(), out rok))
                    {

                        Samochod k = new Samochod()
                        {
                            Marka = marka,
                            Model = model,
                            RokProdukcji = rok,
                            Cena = cena,
                            WlascicielId = wlas.Id
                            

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


        public static void UsunS(BazaDb db)
        {
            Console.WriteLine("Wprowadz id Samochodu do usunięcia:");

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

        public static void ZnajdzMS(BazaDb db)
        {
            Console.WriteLine("Wprowadź szukaną markę samochodu.");
            string fraza = Console.ReadLine();

            var sam = db.Samochody.Where(w => w.Marka.ToLower().Contains(fraza.ToLower())).Include(i => i.Wlasciciele);

            foreach (var k in sam)
            {
                Console.WriteLine(k);
            }
        }
        public static void ZnajdzMoS(BazaDb db)
        {
            Console.WriteLine("Wprowadź szukany model samochodu.");
            string fraza = Console.ReadLine();

            var sam = db.Samochody.Where(w => w.Model.ToLower().Contains(fraza.ToLower())).Include(i => i.Wlasciciele);

             foreach (var k in sam)
                
                    {
                        Console.WriteLine(k);
                    }
                
           

        }
        public static void ZnajdzCene(BazaDb db)
        {
            Console.WriteLine("Wyszukaj Samochodu po cenie.");
            string fraza = Console.ReadLine();

            var sam = db.Samochody.Where(w => w.Cena.ToLower().Contains(fraza.ToLower())).Include(i => i.Wlasciciele);

            foreach (var k in sam)
            {
                Console.WriteLine(k);
            }


        }

        public static void PokazS(BazaDb db)
        {
            foreach (var k in db.Samochody.Include(i => i.Wlasciciele))
            {
                Console.WriteLine(k);
            }
        }


    }

}