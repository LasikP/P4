using Microsoft.EntityFrameworkCore;


namespace Projekt1
{
    class Program
    {

        static void showBooks(BibliotekaDb db)
        {
            foreach (var k in db.Ksiazki.Include(i => i.Autor))
            {
                Console.WriteLine(k);
            }
        }

        static void addBook(BibliotekaDb db)
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

        static void removeBook(BibliotekaDb db)
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

        static void findBooks(BibliotekaDb db)
        {
            Console.WriteLine("Wprowadź szukaną frazę.");
            string fraza = Console.ReadLine();

            var ksiazki = db.Ksiazki.Where(w => w.Tytul.ToLower().Contains(fraza.ToLower())).Include(i => i.Autor);

            foreach (var k in ksiazki)
            {
                Console.WriteLine(k);
            }
        }

        static void showAutors(BibliotekaDb db)
        {
            foreach (var a in db.Autorzy)
            {
                Console.WriteLine(a.Id + ": " + a);
            }
        }

        static void addAutor(BibliotekaDb db)
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

        static void removeAutor(BibliotekaDb db)
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

        static void findAutors(BibliotekaDb db)
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

        static void Main(string[] args)
        {
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
                    switch (opt)
                    {
                        case 1:
                            showBooks(db);
                            break;
                        case 2:
                            addBook(db);
                            break;
                        case 3:
                            removeBook(db);
                            break;
                        case 4:
                            findBooks(db);
                            break;
                        case 5:
                            showAutors(db);
                            break;
                        case 6:
                            addAutor(db);
                            break;
                        case 7:
                            removeAutor(db);
                            break;
                        case 8:
                            findAutors(db);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Błędny numer opcji menu.");
                }
            }

        }
    }
}
