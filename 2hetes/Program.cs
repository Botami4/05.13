using _2hetes;

class Program
{
    static void Main()
    {
        var lakos1 = new Lakos("Dóra", 28, "Fő tér 1", 5000);

        var plaza = new BevasarloKozpont("MegaPlaza");

        var techBolt = new Bolt("TechBolt");

        var jatekBolt = new Bolt("JátékVilág");

        plaza.UjBolt(techBolt.Nev);
        plaza.UjBolt(jatekBolt.Nev);

        plaza.Belep(lakos1);

        plaza.Kolt(lakos1, techBolt, 0);
        plaza.Kolt(lakos1, jatekBolt, 0);

        plaza.ListazBoltok();
        techBolt.ListazTermekek();
    }
}
