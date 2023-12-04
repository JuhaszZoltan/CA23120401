using CA23120401;

List<OkosSzemuveg> szemuvegek = new();

using StreamReader sr = new(@"..\..\..\src\okosszemuvegek.txt");
_ = sr.ReadLine();
while (!sr.EndOfStream) szemuvegek.Add(new(sr.ReadLine()));

foreach (var sz in szemuvegek) Console.WriteLine(sz + "\n");