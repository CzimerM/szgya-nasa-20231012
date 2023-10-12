using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace szgya_nasa_20231012
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Keres> keresek = new List<Keres>();

            using StreamReader sr = new StreamReader("../../../src/NASAlog.txt", Encoding.UTF8);
            while(!sr.EndOfStream)
            {
                keresek.Add(new Keres(sr.ReadLine()));
            }

            Console.WriteLine($"5.feladat: Kérések száma: {keresek.Count}");

            Console.WriteLine($"6.feladat: Válaszok összes mérete: {keresek.Sum(k => k.ValaszMeret)} byte");

            Console.WriteLine($"8.feladat: Domain-es kérések: {(float)keresek.Count(k => k.Domain) / (float) keresek.Count * 100:0.00}%");

            Console.WriteLine($"9.feladat: Statisztika:");
            var f9stat = keresek
                .GroupBy(k => k.AllapotKod)
                .ToDictionary(k => k.Key, v => v.Count());

            foreach (var kod in f9stat)
            {
                Console.WriteLine($"\t{kod.Key}: {kod.Value} db");
            }

        }
    }
}
