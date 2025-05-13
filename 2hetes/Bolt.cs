using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2hetes
{
    internal class Bolt
    {
        public string Nev { get; private set; }

        private Dictionary<string, Tuple<Termek, int>> termekKeszlet = new();

        public Bolt(string nev)
        {
            if (string.IsNullOrWhiteSpace(nev))
                throw new ArgumentException("A bolt neve nem lehet üres.");

            Nev = nev;
        }

        public void HozzaadTermek(Termek termek, int darab)
        {
            if (termek == null)
                throw new ArgumentNullException(nameof(termek));
            if (darab <= 0)
                throw new ArgumentException("Legalább 1 darabot hozzá kell hozzáadni");

            if (termekKeszlet.ContainsKey(termek.Nev))
            {
                var aktualis = termekKeszlet[termek.Nev];
                termekKeszlet[termek.Nev] = Tuple.Create(aktualis.Item1, aktualis.Item2 + darab);
            }
            else
            {
                termekKeszlet[termek.Nev] = Tuple.Create(termek, darab);
            }

            Console.WriteLine($" {darab} db {termek.Nev} hozzáadva  {Nev} boltba");
        }

        public class Termek
        {
            public string Nev { get; set; }
            public int Ar { get; set; }

            public Termek(string nev, int ar)
            {
                if (string.IsNullOrWhiteSpace(nev))
                    throw new ArgumentException("A termék neve nem lehet üres.");
                if (ar <= 0)
                    throw new ArgumentException("A termék ára nagyobb kell legyen, mint 0.");

                Nev = nev;
                Ar = ar;
            }

            public override string ToString()
            {
                return $"{Nev} - {Ar} Ft";
            }
        }

        public void ListazTermekek()
        {
            Console.WriteLine($" {Nev} kínálata:");
            if (termekKeszlet.Count == 0)
            {
                Console.WriteLine("nincs elérhető termék");
                return;
            }

            foreach (var (nev, tuple) in termekKeszlet)
            {
                Console.WriteLine($" - {tuple.Item1} ({tuple.Item2} db)");
            }
        }

        public void Vasarlas(Lakos vevo, string termekNev)
        {
            if (!termekKeszlet.ContainsKey(termekNev))
            {
                Console.WriteLine($" {Nev} boltban nincs ilyen termék: {termekNev}");
                return;
            }

            var (termek, darab) = termekKeszlet[termekNev];
            if (darab <= 0)
            {
                Console.WriteLine($" {termekNev} elfogyott a {Nev} boltban.");
                return;
            }

            if (vevo.Fizet(termek.Ar))
            {
                Console.WriteLine($" {vevo.Nev} megvásárolta: {termekNev} ({termek.Ar} Ft)");

                if (darab == 1)
                {
                    termekKeszlet.Remove(termekNev);
                }
                else
                {
                    termekKeszlet[termekNev] = Tuple.Create(termek, darab - 1);
                }
            }
            else
            {
                Console.WriteLine($" {vevo.Nev} nem tudta megvenni: {termekNev} – nincs elég pénze.");
            }
        }
    }
}
