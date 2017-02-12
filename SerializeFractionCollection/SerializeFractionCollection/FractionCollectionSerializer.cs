using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializeFractionCollection
{
    internal class FractionCollectionSerializer
    {
        private readonly BinaryFormatter _binaryFormatter = new BinaryFormatter();

        internal void SerializeFractionCollectionAndSaveToFile(List<Fraction> fractionList, string outFileName)
        {
            try
            {
                using (var fileStream = File.Create(outFileName))
                {
                    _binaryFormatter.Serialize(fileStream, fractionList);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Something went wrong:\n{e}");
            }
        }

        internal List<Fraction> DeserializeFractionCollectionFromFile(string inFileName)
        {
            var fractionListToSerialize = new List<Fraction>();
            try
            {
                using (var fileStream = File.OpenRead(inFileName))

                {
                    fractionListToSerialize = (List<Fraction>)_binaryFormatter.Deserialize(fileStream);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Something went wrong:\n{e}");
            }

            return fractionListToSerialize;
        }
    }
}
