using Microsoft.EntityFrameworkCore;
using Projekt1;




BibliotekaDb db = new BibliotekaDb();

int opt = 1;

while (opt > 0 && opt < 9)
{
    Console.WriteLine("================== BIBLIOTEKA ==================");
    Console.WriteLine("1. Wyświetl książki.");
    Console.WriteLine("2. Dodaj książkę.");
    Console.WriteLine("3. Usuń książkę.");
    Console.WriteLine("4. Wyszukaj książki.");
    Console.WriteLine("5. Wyświetl autorów.");
    Console.WriteLine("6. Dodaj autora.");
    Console.WriteLine("7. Usuń autora.");
    Console.WriteLine("8. Wyszukaj autorów.");
    Console.WriteLine("9. Zakończ.");
    Console.WriteLine("================================================");

    if (int.TryParse(Console.ReadLine(), out opt))
    {
        if (opt == 1)
        {
            foreach (var k in db.Ksiazki.Include(i => i.Autor))
            {
                Console.WriteLine(k);
            }
        }
        else if (opt == 2)
        {
            foreach (var a in db.Autorzy)
            {
                Console.WriteLine(a.Id + ": " + a);
            }

            Console.WriteLine("Wprowadz id autora:");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var autor = db.Autorzy.Find(id);

                if (autor != null)
                {
                    Console.WriteLine("Podaj tytuł:");
                    string tytul = Console.ReadLine();
                    int rok = 0;

                    Console.WriteLine("Podaj rok wydania:");
                    if (int.TryParse(Console.ReadLine(), out rok))
                    {
                        Ksiazka k = new Ksiazka()
                        {
                            Tytul = tytul,
                            RokWydania = rok,
                            AutorId = autor.Id
                        };

                        db.Ksiazki.Add(k);
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Rok musi być liczbą.");
                    }

                }
                else
                {
                    Console.WriteLine("Brak autora o podanym id.");
                }
            }
            else
            {
                Console.WriteLine("Wprowadzono błędną liczbę");
            }
        }
        else if (opt == 3)
        {
            Console.WriteLine("Wprowadz id książki do usunięcia:");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var removed = db.Ksiazki.Find(id);

                if (removed != null)
                {
                    db.Ksiazki.Remove(removed);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Brak książki o podanym id.");
                }
            }
        }
        else if (opt == 4)
        {
            Console.WriteLine("Wprowadź szukaną frazę.");
            string fraza = Console.ReadLine();

            var ksiazki = db.Ksiazki.Where(w => w.Tytul.ToLower().Contains(fraza.ToLower())).Include(i => i.Autor);

            foreach (var k in ksiazki)
            {
                Console.WriteLine(k);
            }
        }
        else if (opt == 5)
        {
            foreach (var a in db.Autorzy)
            {
                Console.WriteLine(a.Id + ": " + a);
            }
        }
        else if (opt == 6)
        {
            Console.WriteLine("Podaj imie autora:");
            string imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko autora:");
            string nazwisko = Console.ReadLine();

            Autor a = new Autor()
            {
                Imie = imie,
                Nazwisko = nazwisko
            };

            db.Autorzy.Add(a);
            db.SaveChanges();

        }
        else if (opt == 7)
        {
            Console.WriteLine("Wprowadz id autora do usunięcia:");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var removed = db.Autorzy.Find(id);

                if (removed != null)
                {
                    db.Autorzy.Remove(removed);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Brak autora o podanym id.");
                }
            }
        }
        else if (opt == 8)
        {
            Console.WriteLine("Wprowadź szukane nazwisko.");
            string fraza = Console.ReadLine();

            var autorzy = db.Autorzy.Where(w => w.Nazwisko.ToLower().Contains(fraza.ToLower())).Include(i => i.Ksiazki);

            foreach (var a in autorzy)
            {
                Console.WriteLine(a);

                Console.WriteLine("Książki tego autora:");

                foreach (var k in a.Ksiazki)
                {
                    Console.WriteLine($"{k.Tytul} wyd. {k.RokWydania}");
                }
            }
        }
    }
    else
    {
        Console.WriteLine("Błędny numer opcji menu.");
    }
}