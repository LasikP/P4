using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWPFApp
{
    public class Ksiazka
    {
        public Ksiazka(string title, string author, int categoryId)
        {
            Title = title;
            Author = author;
            CategoryId = categoryId;

        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }

        public Kategoria Category { get; set; }
        public List<Wpozyczenie> Borrows { get; set; }


        public override string ToString()
        {
            return $"{Author} {Title} - {Category}"; 
        }
    }
}
