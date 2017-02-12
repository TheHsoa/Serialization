using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializeFractionCollection
{
    internal class FractionCollectionSerializer
    {
        private readonly FileStream _fileStream;

        public FractionCollectionSerializer(string fileName)
        {
            _fileStream = File.Open(fileName, FileMode.Create);
        }

        internal void SerializeFractionCollection(List<Fraction> fractionListToSerialize)
        {
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(_fileStream, fractionListToSerialize);
            _fileStream.Close();
        }

        internal List<Fraction> DeserializeFractionCollection()
        {
            var binaryFormatter = new BinaryFormatter();
            var fractionListToSerialize = (List<Fraction>)binaryFormatter.Deserialize(_fileStream);
            _fileStream.Close();

            return fractionListToSerialize;
        }
    }
}
