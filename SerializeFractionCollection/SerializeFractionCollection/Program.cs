using System;
using System.Collections.Generic;
using System.Linq;

namespace SerializeFractionCollection
{
    internal class Program
    {
        private static void Main()
        {
            var random = new Random(Guid.NewGuid().GetHashCode());

            var fractionList = new List<Fraction>();

            for (var i = 0; i < 10; i++)
            {
                fractionList.Add(new Fraction(random.Next(1, 10), random.Next(1, 100)));
            }

            fractionList.SerializeFractionCollection("outfile");
            var deserializedFractionList = FractionCollectionSerializeExtension.DeserializeFractionCollection("outfile");

            Console.WriteLine(string.Join(" ", fractionList.Except(deserializedFractionList).ToList()));
            Console.ReadKey();
        }
    }
}
