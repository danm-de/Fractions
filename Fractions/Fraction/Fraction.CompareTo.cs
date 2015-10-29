using System;
using System.Diagnostics.Contracts;
using System.Numerics;

namespace Fractions {
    public partial struct Fraction
    {
        /// <summary>
        /// Compares the calculated value with the supplied <paramref name="other"/>.
        /// </summary>
        /// <param name="other">Fraction that shall be compared with.</param>
        /// <returns>
        /// Less than 0 if <paramref name="other"/> is greater.
        /// Zero (0) if both calculated values are equal.
        /// Greater then zero (0) if <paramref name="other"/> less.</returns>
        /// <exception cref="ArgumentException">If <paramref name="other"/> is not of type <see cref="Fraction"/>.</exception>
        [Pure]
        public int CompareTo(object other) {
            if (other == null) {
                return 1;
            }

            if (other.GetType() != typeof(Fraction)) {
                throw new ArgumentException(
                    string.Format(Exceptions.CompareToArgumentException, GetType(), other.GetType()), nameof(other));
            }

            return CompareTo((Fraction)other);
        }

        /// <summary>
        /// Compares the calculated value with the supplied <paramref name="other"/>.
        /// </summary>
        /// <param name="other">Fraction that shall be compared with.</param>
        /// <returns>
        /// Less than 0 if <paramref name="other"/> is greater.
        /// Zero (0) if both calculated values are equal.
        /// Greater then zero (0) if <paramref name="other"/> less.</returns>
        [Pure]
        public int CompareTo(Fraction other) {
            if (_denominator == other._denominator) {
                return _numerator.CompareTo(other._numerator);
            }

            if (IsZero != other.IsZero) {
                if (IsZero) {
                    return other.IsPositive ? -1 : 1;
                }
                return IsPositive ? 1 : -1;
            }

            var gcd = BigInteger.GreatestCommonDivisor(_denominator, other._denominator);

            var this_multiplier = BigInteger.Divide(_denominator, gcd);
            var other_multiplier = BigInteger.Divide(other._denominator, gcd);

            var a = BigInteger.Multiply(_numerator, other_multiplier);
            var b = BigInteger.Multiply(other._numerator, this_multiplier);

            return a.CompareTo(b);
        }
    }
}