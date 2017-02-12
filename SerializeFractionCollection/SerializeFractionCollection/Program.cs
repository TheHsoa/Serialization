using System;
using System.Collections.Generic;
using System.Linq;

namespace SerializeFractionCollection
{
    internal class Program
    {
        private const string FileName = "outfile";
        private static void Main()
        {
            var random = new Random(Guid.NewGuid().GetHashCode());

            var fractionList = new List<Fraction>();

            for (var i = 0; i < 10; i++)
            {
                fractionList.Add(new Fraction(random.Next(1, 10), random.Next(1, 100)));
            }

            var serializer = new FractionCollectionSerializer();

            serializer.SerializeFractionCollectionAndSaveToFile(fractionList, FileName);
            var deserializedFractionList = serializer.DeserializeFractionCollectionFromFile(FileName);

            var outString = string.Join(" ", fractionList.Except(deserializedFractionList).ToList());

            Console.WriteLine(outString == "" ? "All OK" : $"Object incorrect deserialized: \n {outString}");
            Console.ReadKey();
        }
    }
}
