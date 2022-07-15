using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWPFApp
{
    public class WypozyczenieElement
    {
        public int Id { get; set; }
        public string Book { get; set; }
        public string Client { get; set; }
        public string Status { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public WypozyczenieElement(int id, string book, string client, bool returned, DateTime borrowDate, DateTime returnDate)
        {
            Id = id;
            Book = book;
            Client = client;
            Status = returned ? "Zwrócono" : "Wypożyczono";
            BorrowDate = borrowDate;
            ReturnDate = returnDate;
        }
    }
}
