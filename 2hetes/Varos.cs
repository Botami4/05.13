using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2hetes
{
    internal class Varos
    {
        public string Nev { get; private set; }
        private List<Lakos> lakosok = new List<Lakos>();

        private Konyvtar konyvtar;
        private Kozlekedes jarmu;
        private Posta posta;
        private Kavezo kavezo;
        private Kozlekedes plaza;

        public Varos(string nev)
        {
            Nev = nev;
        }

        public void HozzaadLakos(Lakos lakos)
        {
            lakosok.Add(lakos);
            Console.WriteLine($" {lakos.Nev} beköltözött {Nev} városába.");
        }

        public void SzolgaltatasInditasa()
        {
            konyvtar = new Konyvtar(10); 
            konyvtar.HozzaadKonyv(new Konyv("A Pál utcai fiúk", "Molnár Ferenc", 200, 1500, 3));
            konyvtar.HozzaadKonyv(new Konyv("Egri csillagok", "Gárdonyi Géza", 400, 1800, 2));

            jarmu = new Kozlekedes("Busz 1", "Belváros → Központ", 10, 300);

            posta = new Posta();

            kavezo = new Kavezo("Barista Café");
            kavezo.HozzaadEtelItal(new EtelItal("Espresso", 500, "ital", 80, true));
            kavezo.HozzaadEtelItal(new EtelItal("Süti", 700, "étel", 0, true));

            plaza = new BevasarloKozpont("MegaPlaza");
            plaza.UjBolt("TechBolt");
            plaza.UjBolt("Könyvesbolt");
        }

        public void VarosStatusza()
        {
            Console.WriteLine($"\n🌆 {Nev} jelenlegi lakói:");
            foreach (var l in lakosok)
            {
                Console.WriteLine($" - {l.Nev}, {l.Penz} Ft");
            }
        }

        public void NapFutasa()
        {
            foreach (var lakos in lakosok)
            {
                jarmu.Felszallas(lakos);
            }

            foreach (var lakos in lakosok)
            {
                konyvtar.Belep(lakos);
                konyvtar.Kolcsonoz(lakos, "Egri csillagok");
            }

            foreach (var lakos in lakosok)
            {
                kavezo.Belepes(lakos);
                kavezo.Rendel(lakos, "Espresso");
                kavezo.Rendel(lakos, "Süti");
            }

            var csomag = new Csomag("Városháza", lakosok[0].Nev, 1.5, 1500);
            posta.SorbanAllas(csomag);
            posta.Kuldes();
            posta.Szallitas();
            posta.Atvetel();

            Console.WriteLine("\n🛍️ Este: pláza");
            foreach (var lakos in lakosok)
            {
                plaza.Belep(lakos);
                plaza.Kolt(lakos, 1000);
            }

            VarosStatusza();
        }
    }
}
