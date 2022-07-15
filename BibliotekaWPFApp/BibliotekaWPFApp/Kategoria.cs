using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWPFApp
{
    public class Kategoria
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Ksiazka> Books { get; set; }

        public Kategoria(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
