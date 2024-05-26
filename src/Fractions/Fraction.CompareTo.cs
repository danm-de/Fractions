using System;
using Fractions.Properties;

namespace Fractions;

public readonly partial struct Fraction
{
    /// <summary>
    /// Compares the calculated value with the supplied <paramref name="other"/>.
    /// </summary>
    /// <param name="other">Fraction that shall be compared with.</param>
    /// <returns>
    /// Less than 0 if <paramref name="other"/> is greater.
    /// Zero (0) if both calculated values are equal.
    /// Greater than zero (0) if <paramref name="other"/> less.</returns>
    /// <exception cref="ArgumentException">If <paramref name="other"/> is not of type <see cref="Fraction"/>.</exception>
    public int CompareTo(object other) {
        if (other == null) {
            return 1;
        }

        if (other.GetType() != typeof(Fraction)) {
            throw new ArgumentException(
                string.Format(Resources.CompareToArgumentException, GetType(), other.GetType()), nameof(other));
        }

        return CompareTo((Fraction)other);
    }

    /// <summary>
    ///     Compares the calculated value with the supplied <paramref name="other" />.
    /// </summary>
    /// <param name="other">Fraction that shall be compared with.</param>
    /// <returns>
    ///     1 if <paramref name="other" /> is greater.
    ///     0 if both calculated values are equal.
    ///     -1 if <paramref name="other" /> less.
    /// </returns>
    /// <remarks>Comparing with <see cref="NaN" /> as the first argument always returns -1</remarks>
    public int CompareTo(Fraction other) {
        var numerator1 = Numerator;
        var denominator1 = Denominator;
        var numerator2 = other.Numerator;
        var denominator2 = other.Denominator;

        // normalize signs
        numerator1 = denominator1.Sign == -1 ? -numerator1 : numerator1;
        denominator1 = denominator1.Sign == -1 ? -denominator1 : denominator1;
        numerator2 = denominator2.Sign == -1 ? -numerator2 : numerator2;
        denominator2 = denominator2.Sign == -1 ? -denominator2 : denominator2;

        if (numerator1.IsZero && denominator1.IsZero) {
            // this is NaN
            return (numerator2.IsZero && denominator2.IsZero) ? 0 : -1;
        }

        if (numerator2.IsZero && denominator2.IsZero) {
            // other is NaN
            return 1;
        }

        if (denominator1 == denominator2) { 
            return denominator1.IsZero ? 
                numerator1.Sign.CompareTo(numerator2.Sign) :  // both fractions represent infinities
                numerator1.CompareTo(numerator2); // any other two numbers (includes all integers)
        }

        if (numerator1.IsZero) {
            return other.IsPositive ? -1 : 1;
        }

        if (numerator2.IsZero) {
            return IsPositive ? 1 : -1;
        }

        if (denominator1.IsZero) {
            return numerator1.Sign; // PositiveInfinity -> 1, NegativeInfinity -> -1
        }

        if (denominator2.IsZero) {
            return numerator2.Sign; // PositiveInfinity -> -1, NegativeInfinity -> 1
        }

        // both values are non-zero fractions with different denominators  
        return MultiplyTerms(numerator1, denominator2).CompareTo(MultiplyTerms(numerator2, denominator1));
    }
}
