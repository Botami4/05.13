using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2hetes
{
    internal class EtelItal
    {
        public string Nev { get; private set; }
        public int Ar { get; private set; }
        public string Tipus { get; private set; }
        public int Kaloria { get; private set; }
        public bool Koffein { get; private set; }  
    
    public EtelItal(string nev, int ar, string tipus, int kaloria, bool koffein)
        {
            if (ar < 0) throw new ArgumentException("Az ár ne legyen negatív");
            if (kaloria < 0) throw new ArgumentException("A kalória ne legyen negatív");
            Nev = nev;
            Ar = ar;
            Tipus = tipus;
            Kaloria = kaloria;
            Koffein = koffein;
        }
        public void Fogyaszt()
        {
            Console.WriteLine($"{Nev} elfogyasztva. ({Kaloria} kcal, {Koffein} mg koffein)");
        }
    }
}
