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

        public override bool Equals(object otherObject)
        {
            if (otherObject == null)
            {
                return false;
            }

            if (ReferenceEquals(this, otherObject))
            {
                return true;
            }

            return otherObject.GetType() == GetType() && Equals(otherObject as Fraction);
        }

        protected bool Equals(Fraction otherFraction)
        {
            return Numerator == otherFraction.Numerator && Denominator == otherFraction.Denominator;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Numerator.GetHashCode() * 397) ^ Denominator.GetHashCode();
            }
        }
    }
}
