using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2hetes
{
    public enum TermekTipus
    {
        Egyeb,
        Elektronika,
        Ruhazat,
        Etel,
        Ital,
        Jatek,
        Konyv
    }
    internal class Termék
    {
        private string nev;
        private int ar;

        public string Nev
        {
            get => nev;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A termék neve nem lehet üres.");
                nev = value.Trim();
            }
        }

        public int Ar
        {
            get => ar;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("A termék ára nem lehet negatív.");
                ar = value;
            }
        }

        public TermekTipus Tipus { get; private set; }

        public void Termek(string nev, int ar, TermekTipus tipus = TermekTipus.Egyeb)
        {
            Nev = nev;
            Ar = ar;
            Tipus = tipus;
        }

        public override string ToString()
        {
            return $"{Nev} ({Tipus}) - {Ar} Ft";
        }
    }
}
