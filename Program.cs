using CA23120401;

internal class Program
{
    private static void Main(string[] args)
    {
        List<OkosSzemuveg> szemuvegek = Beolvasas(@"..\..\..\src\okosszemuvegek.txt");
        OSZListaKiir(szemuvegek);

        //-----------------

        List<OkosSzemuveg> f07Lista = Feladat07(szemuvegek, 12, 2f);
        Console.WriteLine($"\n7. feladat: {f07Lista.Count} db, " +
            $"a feltételnek megfelelő szemüveg van");

        double atlagosUzemido = szemuvegek.Average(osz => osz.Uzemido);
        List<OkosSzemuveg> f08Lista = Feladat08(szemuvegek, atlagosUzemido);
        Console.WriteLine("8. feladat:");
        OSZListaKiir(f08Lista);
        Console.WriteLine($"Átlagos üzemidő: {atlagosUzemido:0.00} óra");
        Console.WriteLine($"Átlagos üzemidőt meghaladó készülékek száma: {f08Lista.Count} db");

        Console.WriteLine("10. feladat:");
        List<(int ID, float meretCM)> f10Lista = Feladat10(szemuvegek, 100);
        foreach (var e in f10Lista) Console.WriteLine($"{e.ID}.: {e.meretCM:0.0} cm");

        List<string> szenzorok = Feladat11(szemuvegek);

    }

    private static List<string> Feladat11(List<OkosSzemuveg> szemuvegLista)
    {
        //!!nincs kész!!
        return szemuvegLista
            .SelectMany(osz => osz.Szenzorok)
            .Distinct()
            .ToList();
    }

    private static List<(int ID, float meretCM)> Feladat10(List<OkosSzemuveg> szemuvegLista, int tarhelyFelsoHatar)
    {
        return szemuvegLista
            .Where(osz => osz.Tarhely < tarhelyFelsoHatar)
            .Select(osz => (osz.ID, osz.MeretCMben))
            .ToList();
    }

    private static List<OkosSzemuveg> Feladat08(List<OkosSzemuveg> szemuvegLista, double atlagosUzemido)
    {
        return szemuvegLista.Where(osz => osz.Uzemido > atlagosUzemido).ToList();
    }

    private static List<OkosSzemuveg> Feladat07(List<OkosSzemuveg> szemuvegLista, int felbontas, float teljesitmeny)
    {
        return szemuvegLista
            .Where(osz => osz.Felbontas >= felbontas && osz.Teljesitmeny == teljesitmeny)
            .ToList();
    }

    private static List<OkosSzemuveg> Beolvasas(string file)
    {
        List<OkosSzemuveg> szemuvegLista = new();
        using StreamReader sr = new(file);
        _ = sr.ReadLine();
        while (!sr.EndOfStream) szemuvegLista.Add(new(sr.ReadLine()));
        return szemuvegLista;
    }
    private static void OSZListaKiir(List<OkosSzemuveg> szemuvegLista)
    {
        foreach (var sz in szemuvegLista) Console.WriteLine(sz + "\n");
    }
}