using CA23120401;

internal class Program
{
    private static void Main()
    {
        List<OkosSzemuveg> szemuvegek = Beolvasas(@"..\..\..\src\okosszemuvegek.txt");

        Console.WriteLine("\n6. feladat:");
        OSZListaKiir(szemuvegek);

        //-----------------

        List<OkosSzemuveg> f07Lista = Feladat07(szemuvegek, 12, 2f);
        Console.WriteLine($"\n7. feladat: {f07Lista.Count} db, " +
            $"a feltételnek megfelelő szemüveg van");

        double atlagosUzemido = szemuvegek.Average(osz => osz.Uzemido);
        List<OkosSzemuveg> f08Lista = Feladat08(szemuvegek, atlagosUzemido);
        Console.WriteLine("\n8. feladat: átlagosnál nagyobb üzemidejű szemüvegek:");
        OSZListaKiir(f08Lista);
        Console.WriteLine($"Átlagos üzemidő: {atlagosUzemido:0.00} óra");
        Console.WriteLine($"Átlagos üzemidőt meghaladó készülékek száma: {f08Lista.Count} db");

        Console.WriteLine("\n10. feladat: 100GBnél kisebb szemüvegek:");
        List<(int ID, float meretCM)> f10Lista = Feladat10(szemuvegek, 100);
        foreach (var e in f10Lista) Console.WriteLine($"{e.ID}.: {e.meretCM:0.0} cm");

        Console.WriteLine("\n11. feladat: összes szenzortípus:");
        List<string> szenzorok = Feladat11(szemuvegek);
        foreach (var sz in szenzorok) Console.WriteLine($"- {sz}");

        Console.Write("\n12. feladat: ");
        List<OkosSzemuveg> f12Lista = Feladat12(szemuvegek, 1024);
        if (f12Lista.Count == 0)
        {
            Console.WriteLine("nincs legalább 1TB mértetű okosszemüveg");
        }
        else
        {
            Console.WriteLine("Legalább 1TB tárhellyel rendelkező szemüvegek:");
            OSZListaKiir(f12Lista);
        }

        Console.WriteLine("\n13. feladat:");
        Feladat13(szemuvegek, @"..\..\..\src\feladat13op.txt", 3);

    }

    private static void Feladat13(List<OkosSzemuveg> szemuvegLista, string file, int szenzorszam)
    {
        using StreamWriter sw = new(file);
        foreach (var osz in szemuvegLista)
        {
            if (osz.Szenzorok.Length >= szenzorszam) sw.WriteLine(osz);
        }
        Console.WriteLine($"{file} elkészült!");
    }

    private static List<OkosSzemuveg> Feladat12(List<OkosSzemuveg> szemuvegLista, int minMeret)
    {
        return szemuvegLista.Where(osz => osz.Tarhely >= minMeret).ToList();
    }

    private static List<string> Feladat11(List<OkosSzemuveg> szemuvegLista)
    {
        return szemuvegLista
            .SelectMany(osz => osz.Szenzorok)
            .Distinct()
            .OrderBy(sz => sz)
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