using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializeFractionCollection
{
    public static class FractionCollectionSerializeExtension
    {
        internal static void SerializeFractionCollection(this List<Fraction> fractionListToSerialize , string fileName)
        {
            var fstream = File.Open(fileName, FileMode.Create);
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fstream, fractionListToSerialize);
            fstream.Close();
        }

        internal static List<Fraction> DeserializeFractionCollection(string fileName)
        {
            var fstream = File.Open(fileName, FileMode.Open);
            var binaryFormatter = new BinaryFormatter();
            var fractionListToSerialize = (List<Fraction>)binaryFormatter.Deserialize(fstream);
            fstream.Close();
            return fractionListToSerialize;
        }
    }
}
