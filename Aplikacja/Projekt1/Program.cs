using Aplikacja;









BibliotekaDb db = new BibliotekaDb();

            int opt = 1;

            while (opt > 0 && opt < 10)
            {
                Console.WriteLine("===============================================");
                Console.WriteLine("1. Wyświetl auta.");
                Console.WriteLine("2. Dodaj auto.");
                Console.WriteLine("3. Usuń auto.");
                Console.WriteLine("4. Wyszukaj marke auta.");
                Console.WriteLine("5. Wyszukaj model auta.");
                Console.WriteLine("6. Wyświetl właścicieli.");
                Console.WriteLine("7. Dodaj właściciela.");
                Console.WriteLine("8. Usuń właściciela.");
                Console.WriteLine("9. Wyszukaj właścicieli.");
                Console.WriteLine("10. Zakończ.");
                Console.WriteLine("================================================");

                if (int.TryParse(Console.ReadLine(), out opt))
                {
                    switch (opt)
                    {
                        case 1:
                            function.showCars(db);
                            break;
                        case 2:
                            function.addCar(db);
                            break;
                        case 3:
                function.removeCar(db);
                            break;
                        case 4:
                function.findMarks(db);
                            break;
                        case 5:
                function.findModel(db);
                            break;
                        case 6:
                function.showOwners(db);
                            break;
                        case 7:
                function.addOwners(db);
                            break;
                        case 8:
                function.removeOwners(db);
                            break;
                        case 9:
                function.findOwners(db);
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

        
    

