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
                    switch (opt)
                    {
                        case 1:
                            A.showBooks(db);
                            break;
                        case 2:
                             A.addBook(db);
                            break;
                        case 3:
                             A.removeBook(db);
                            break;
                        case 4:
                             A.findBooks(db);
                            break;
                        case 5:
                             A.showAutors(db);
                            break;
                        case 6:
                             A.addAutor(db);
                            break;
                        case 7:
                             A.removeAutor(db);
                            break;
                        case 8:
                             A.findAutors(db);
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

                