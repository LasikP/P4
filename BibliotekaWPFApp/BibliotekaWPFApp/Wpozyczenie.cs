using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWPFApp
{
    public class Wpozyczenie
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int BookId { get; set; }
        public int ClientId { get; set; }
        public bool Returned { get; set; }
        public DateTime ReturnDate { get; set; }

        public Ksiazka Book { get; set; }
        public Klient Client { get; set; }


        public Wpozyczenie(int bookId, int clientId)
        {
            BookId = bookId;
            ClientId = clientId;
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            string status = Returned ? "Zwrócono" : "Wypożyczono";
            return $"{Date}: {Book}, {Client} {status}";
        }
    }
}
