using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2hetes
{
    internal class Posta
    {
        private List<Csomag> csomagok = new List<Csomag>();

        public void SorbanAllas(Csomag csomag)
        {
            csomagok.Add(csomag);
            Console.WriteLine($"A csomag sorba téve: {csomag.Kiiratas()}");
        }

        public void Kuldes()
        {
            foreach (var csomag in csomagok)
            {
                if (csomag.Allapot == "Várakozik")
                {
                    csomag.Feladas();
                }
            }
        }

        public void Szallitas()
        {
            foreach (var csomag in csomagok)
            {
                if (csomag.Allapot == "Feladva")
                {
                    csomag.Szallitas();
                }
            }
        }

        public void Atvetel()
        {
            foreach (var csomag in csomagok)
            {
                if (csomag.Allapot == "Szállítás alatt")
                {
                    csomag.Kiszallitas();
                }
            }
        }

        public void Listaz()
        {
            Console.WriteLine("Posta állapot");
            foreach (var cs in csomagok)
            {
                Console.WriteLine(cs.Kiiratas());
            }
        }
    }
}
