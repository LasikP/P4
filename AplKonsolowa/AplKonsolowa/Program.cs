using AplKonsolowa;
using Microsoft.EntityFrameworkCore;

BazaDb db = new BazaDb();


int x;


Console.WriteLine("================== Baza Danych Właścicile i Samochody ==================");
Console.WriteLine("1. Dodaj Właściciela.");
Console.WriteLine("2. Usuń Właściciciela.");
Console.WriteLine("3. Znajdż Właściciela po nazwisku.");
Console.WriteLine("4. Znajdż Właściciela po pesulu.");
Console.WriteLine("5. Znajdż Właściciela i jego Samochody po nazwisku.");
Console.WriteLine("6. Pokaż wszystkich Właśćicieli.");
Console.WriteLine("7. Dodaj Samochód.");
Console.WriteLine("8. Usuń Samochód.");
Console.WriteLine("9. Znajdż Samochód po marce.");
Console.WriteLine("10. Znajdż Samochód po modelu.");
Console.WriteLine("11. Znajdż Samochó po cenie.");
Console.WriteLine("12. Pokaż wszystkie Samochody.");
Console.WriteLine("13. Zakończ Program.");
Console.WriteLine("========================================================================");
do
{
    
    bool result = int.TryParse(Console.ReadLine(), out x);
    {
       
 
        switch (x)
        {
            case 1:
                F.DodajW(db);
                break;
            case 2:
                F.UsunW(db);
                break;
            case 3:
                F.ZnajdzWpN(db);
                break;
            case 4:
                F.ZnajdzWpP(db);
                break;
            case 5:
                F.ZnajdzWpNiS(db);
                break;
            case 6:
                F.PokazW(db);
                break;
            case 7:
                F.DodajS(db);
                break;
            case 8:
                F.UsunS(db);
                break;
            case 9:
                F.ZnajdzMS(db);
                break;
            case 10:
                F.ZnajdzMoS(db);
                break;
            case 11:
                F.ZnajdzCene(db);
                break;
            case 12:
                F.PokazS(db);
                break;
            default:
                if (x == 13)
                {
                    Console.WriteLine("Program zostanie zamknięty");
                }
                else
                {
                    Console.WriteLine("Wybierz opcje od 1 do 13");
                }
                break;
        }
    }
} while (x != 13);