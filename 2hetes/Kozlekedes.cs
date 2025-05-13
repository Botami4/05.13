using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2hetes
{
    internal class Kozlekedes
    {
        public string Nev { get; private set; }
        public string Utvonal { get; private set; }
        public int Ferohely { get; private set; }
        public int Jegy_ar { get; private set; }

        private List<Lakos> utasok = new List<Lakos>();

        public Kozlekedes(string nev, string utvonal, int ferohely, int jegy_ar)
        {
            if (ferohely <= 0) throw new ArgumentException("A férőhelynek pozitívnak kell lennie.");
            if (jegy_ar < 0) throw new ArgumentException("A jegyár nem lehet negatív.");

            Nev = nev;
            Utvonal = utvonal;
            Ferohely = ferohely;
            Jegy_ar = jegy_ar;
        }

        public void Felszallas(Lakos lakos)
        {
            if (utasok.Count >= Ferohely)
            {
                Console.WriteLine($"A(z) {Nev} megtelt, {lakos.Nev} nem tudott felszállni.");
                return;
            }

            if (lakos.Fizet(Jegy_ar))
            {
                utasok.Add(lakos);
                Console.WriteLine($"{lakos.Nev} felszállt a(z) {Nev} járműre.");
            }
            else
            {
                Console.WriteLine($"{lakos.Nev} nem tudta kifizetni a {Jegy_ar} Ft jegyárat.");
            }
        }

        public void Lepes()
        {
            if (utasok.Count == 0)
            {
                Console.WriteLine($"{Nev} nem indul el, mert nincsenek utasok.");
            }
            else
            {
                Console.WriteLine($"{Nev} elindult az útvonalon: {Utvonal} {utasok.Count} utassal.");
                utasok.Clear(); 
            }
        }
    }
}
