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

            var serializer = new FractionCollectionSerializer("outfile");

            serializer.SerializeFractionCollection(fractionList);
            var deserializedFractionList = serializer.DeserializeFractionCollection();

            Console.WriteLine(string.Join(" ", fractionList.Except(deserializedFractionList).ToList()));
            Console.ReadKey();
        }
    }
}
