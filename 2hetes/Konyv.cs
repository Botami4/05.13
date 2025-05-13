using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2hetes
{
    using System;
    using System.Collections.Generic;

    public class Konyv
    {
        public string Cim { get; private set; }
        public string Szerzo { get; private set; }
        public int Oldalszam { get; private set; }
        public int Ertek { get; private set; } 
        public int Peldanyszam { get; set; }

        public Konyv(string cim, string szerzo, int oldalszam, int ertek, int peldanyszam)
        {
            Cim = cim;
            Szerzo = szerzo;
            Oldalszam = oldalszam;
            Ertek = ertek;
            Peldanyszam = peldanyszam;
        }
    }

    public class Konyvtar
    {
        private List<Konyv> konyvek = new List<Konyv>();
        private List<Lakos> latogatok = new List<Lakos>();
        private int Max;

        public Konyvtar(int kapacitas)
        {
            Max = kapacitas;
        }

        public void HozzaadKonyv(Konyv konyv)
        {
            konyvek.Add(konyv);
            Console.WriteLine($"Hozzáadva: {konyv.Cim} ({konyv.Peldanyszam} db)");
        }

        public void Belep(Lakos lakos)
        {
            if (latogatok.Count < Max)
            {
                latogatok.Add(lakos);
                Console.WriteLine($"{lakos.Nev} belépett a könyvtárba.");
            }
            else
            {
                Console.WriteLine("A könyvtár megtelt.");
            }
        }

        public void Kolcsonoz(Lakos lakos, string keresettCim)
        {
            foreach (var konyv in konyvek)
            {
                if (konyv.Cim == keresettCim)
                {
                    if (konyv.Peldanyszam > 0)
                    {
                        konyv.Peldanyszam--;
                        Console.WriteLine($"{lakos.Nev} kikölcsönözte: {konyv.Cim}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Nincs elérhető példány ebből a könyvből.");
                        return;
                    }
                }
            }
            Console.WriteLine("A könyv nem található.");
        }

        public void Visszahoz(Konyv visszahozott)
        {
            foreach (var konyv in konyvek)
            {
                if (konyv.Cim == visszahozott.Cim)
                {
                    konyv.Peldanyszam++;
                    Console.WriteLine($"{konyv.Cim} visszahozva.");
                    return;
                }
            }
            Console.WriteLine("Ez a könyv nem tartozik ide.");
        }
    }

    public class Lakos
    {
        public string Nev { get; private set; }
        public int Eletkor { get; private set; }
        public string Lakcim { get; private set; }
        public int Penz { get; private set; }

        public Lakos(string nev, int eletkor, string lakcim, int penz)
        {
            Nev = nev;
            Eletkor = eletkor;
            Lakcim = lakcim;
            Penz = penz;
        }

        public bool Fizet(int osszeg)
        {
            if (osszeg <= 0) return false;
            if (Penz >= osszeg)
            {
                Penz -= osszeg;
                return true;
            }
            return false;
        }
    }

}
