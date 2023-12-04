using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA23120401
{
    internal class OkosSzemuveg
    {
        public int ID { get; set; }
        public float Meret { get; set; }
        public float MeretCMben => Meret * 3.54f; 
        public float Teljesitmeny { get; set; }
        public int Felbontas { get; set; }
        public string[] Szenzorok { get; set; }
        public int Tarhely { get; set; }
        public int Uzemido { get; set; }

        public override string ToString() =>
                $"ID: {ID}.\n" +
                $"Kijelző méret: {Meret} col\n" +
                $"Processor teljesítmény: {Teljesitmeny} Ghz\n" +
                $"Kamera felbontás: {Felbontas} MP\n" +
                $"Szenzorok: {string.Join(", ", Szenzorok)}\n" +
                $"Merevlemez mérete: " +
                $"{(Tarhely % 1024 != 0 ? $"{Tarhely} GB" : $"{Tarhely / 1024} TB")}\n" +
                $"Üzemidő egy töltéssel: {Uzemido} óra";

        public OkosSzemuveg(string sor)
        {
            var v = sor.Split(';');
            ID = int.Parse(v[0].TrimEnd('.'));
            Meret = float.Parse(v[1]);
            Teljesitmeny = float.Parse(v[2]);
            Felbontas = int.Parse(v[3]);
            Szenzorok = v[4].Split(',');
            int tarhelySzam = int.Parse(v[5].Split(' ')[0]);
            Tarhely = v[5].EndsWith("GB")
                ? tarhelySzam : tarhelySzam * 1024;
            Uzemido = int.Parse(v[6]);
        }

    }
}
