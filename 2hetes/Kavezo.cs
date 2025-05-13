using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2hetes
{
    internal class Kavezo
    {
        public string Nev { get; private set; }
        private List<EtelItal> menu = new List<EtelItal>();
        private List<Lakos> vendegek = new List<Lakos>();

        public Kavezo(string nev)
        {
            Nev = nev;
        }

        public void HozzaadEtelItal(EtelItal tetel)
        {
            menu.Add(tetel);
        }

        public void Belepes(Lakos lakos)
        {
            vendegek.Add(lakos);
            Console.WriteLine($"{lakos.Nev} belépett a(z) {Nev} kávézóba.");
        }

        public void Rendel(Lakos lakos, string tetelNev)
        {
            if (lakos == null)
            {
                Console.WriteLine("A lakos nem lehet null.");
                return;
            }

            if (string.IsNullOrWhiteSpace(tetelNev))
            {
                Console.WriteLine("A tétel neve nem lehet üres.");
                return;
            }

            EtelItal tetel = menu.Find(t => t.Nev == tetelNev);

            if (tetel == null)
            {
                Console.WriteLine($"Nincs ilyen tétel: {tetelNev}");
                return;
            }

            if (lakos.Fizet(tetel.Ar))
            {
                Console.WriteLine($"{lakos.Nev} megrendelte: {tetel.Nev} ({tetel.Ar} Ft)");
                tetel.Fogyaszt();
            }
            else
            {
                Console.WriteLine($"{lakos.Nev} nem tudta kifizetni a {tetelNev} árát ({tetel.Ar} Ft).");
            }
        }
    }
}
