using System;

namespace SerializeFractionCollection
{
    [Serializable]
    internal class Fraction
    {
        public long Numerator { get; }
        public long Denominator { get; }

        public Fraction(long numerator, long denominator)
        {
            if (denominator == 0) throw new DivideByZeroException("Denominator can't be zero");

            Numerator = numerator;
            Denominator = denominator;
        }

        public override string ToString()
        {
            return string.Join("/", Numerator, Denominator);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var runtimeType = GetType();
            var left = obj.GetType();

            if (left != runtimeType)
            {
                return false;
            }

            var fraction = (Fraction) obj;

            return Equals(fraction);
        }

        protected bool Equals(Fraction other)
        {
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Numerator.GetHashCode()*397) ^ Denominator.GetHashCode();
            }
        }
    }
}
