using System;
using System.Collections.Generic;


namespace AplKonsolowa
{
    internal class Wlasciciel
    {
        public int Id   { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }    
        public string Pesel { get; set; }
       
        
        public ICollection<Samochod> Samochody { get; set; }
        public override string ToString()
        {
            return $"{Imie} {Nazwisko} {Pesel}";
        }
    }
   

}
