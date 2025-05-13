using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2hetes
{
    internal class Csomag
    {


    
        public string Felado { get; private set; }
        public string Cimzett { get; private set; }
        public double Suly { get; private set; }  
        public int Ar { get; private set; }       
        public string Allapot { get; private set; } 

        public Csomag(string felado, string cimzett, double suly, int ar)
        {
            if (suly <= 0) throw new ArgumentException("A súly legyen pozitív");
            if (ar < 0) throw new ArgumentException("Az ár ne legyen negatív");

            Felado = felado;
            Cimzett = cimzett;
            Suly = suly;
            Ar = ar;
            Allapot = "Feladásra vár";
        }

        public void Feladas()
        {
            if (Allapot != "Feladásra várakozik")
            {
                Console.WriteLine("Ez a csomag már fel lett adva.");
                return;
            }

            Allapot = "Feladva";
            Console.WriteLine($"Csomag feladva: {Felado} -> {Cimzett}");
        }

        public void Szallitas()
        {
            if (Allapot != "Feladva")
            {
                Console.WriteLine("Elősször add fel a csomagot");
                return;
            }

            Allapot = "Szállítás alatt";
            Console.WriteLine("Csomag szállítás alatt");
        }

        public void Kiszallitas()
        {
            if (Allapot != "Szállítás alatt")
            {
                Console.WriteLine("A csomag szállításra vár");
                return;
            }

            Allapot = "Kézbesítve";
            Console.WriteLine($"Csomag kézbesítve {Cimzett} számára");
        }
        public string Kiiratas()
        {
            return $"{Felado} → {Cimzett}, {Suly}kg, {Ar} Ft, Állapot: {Allapot}";
        }
    }

}

