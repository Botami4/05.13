using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2hetes
{
    internal class BevasarloKozpont
    {
        public string Nev { get; private set; }
        private List<string> boltok = new List<string>();
        private List<Lakos> latogatok = new List<Lakos>();

        public BevasarloKozpont(string nev)
        {
            Nev = nev;
        }

        public void UjBolt(string boltNeve)
        {
            if (!string.IsNullOrWhiteSpace(boltNeve) && !boltok.Contains(boltNeve))
            {
                boltok.Add(boltNeve);
                Console.WriteLine($"Bolt hozzáadva: {boltNeve}");
            }
            else
            {
                Console.WriteLine($"Hiba: érvénytelen vagy már létező bolt neve: {boltNeve}");
            }
        }

        public void Belep(Lakos lakos)
        {
            if (lakos != null && !latogatok.Contains(lakos))
            {
                latogatok.Add(lakos);
                Console.WriteLine($"{lakos.Nev} belépett a bevásárlóközpontba.");
            }
            else
            {
                Console.WriteLine($"Hiba: érvénytelen vagy már bent lévő látogató: {lakos?.Nev}");
            }
        }

        public void Kolt(Lakos lakos, Bolt techBolt, int osszeg)
        {
            if (lakos == null || techBolt == null)
            {
                Console.WriteLine("Hiba: érvénytelen lakos vagy bolt.");
                return;
            }

            if (latogatok.Contains(lakos))
            {
                if (osszeg > 0 && lakos.Fizet(osszeg))
                {
                    Console.WriteLine($"{lakos.Nev} vásárolt {osszeg} értékben a(z) {techBolt.Nev} boltban.");
                }
                else
                {
                    Console.WriteLine($"{lakos.Nev} nem tud vásárolni, nincs elég pénze ({osszeg} Ft) vagy az összeg érvénytelen.");
                }
            }
            else
            {
                Console.WriteLine($"{lakos.Nev} nincs a bevásárlóközpontban.");
            }
        }

        public void ListazBoltok()
        {
            Console.WriteLine($"{Nev} boltjai:");
            if (boltok.Count > 0)
            {
                foreach (var bolt in boltok)
                {
                    Console.WriteLine($"{bolt}");
                }
            }
            else
            {
                Console.WriteLine("Nincsenek boltok a bevásárlóközpontban.");
            }
        }
    }
}
