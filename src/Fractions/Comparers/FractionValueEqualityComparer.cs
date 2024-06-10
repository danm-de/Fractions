using System.Numerics;

namespace Fractions;

/// <summary>
///     A comparator that checks two fractions for equality of value. It doesn't matter whether the numerator and
///     denominator were reduced to the lowest common denominator.
/// </summary>
public sealed class FractionValueEqualityComparer : FractionComparer {
    /// <inheritdoc />
    public override bool Equals(Fraction x, Fraction y) {
        var numerator1 = x.Numerator;
        var denominator1 = x.Denominator;
        var numerator2 = y.Numerator;
        var denominator2 = y.Denominator;

        if (denominator1.Sign == -1) {
            numerator1 = -numerator1;
            denominator1 = -denominator1;
        }

        if (denominator2.Sign == -1) {
            numerator2 = -numerator2;
            denominator2 = -denominator2;
        }

        if (denominator1 == denominator2) {
            return denominator1.IsZero
                ? numerator1.Sign == numerator2.Sign // both fractions represent infinities
                : numerator1 == numerator2;
        }

        if (denominator1.IsZero || denominator2.IsZero) {
            // either x or y is NaN or infinity.
            return false;
        }

        if (numerator1.IsZero) {
            // both values should be 0 
            return numerator2.IsZero;
        }

        if (numerator2.IsZero) {
            // both values should be 0 
            return false;
        }

        var firstNumeratorSign = numerator1.Sign;
        var secondNumeratorSign = numerator2.Sign;
        if (firstNumeratorSign != secondNumeratorSign) {
            return false; // different signs
        }

        // both values are non-zero fractions with different denominators
        if (denominator1 < denominator2) {
            // reverse the comparison from x == y to y == x
            (numerator1, numerator2) = (numerator2, numerator1);
            (denominator1, denominator2) = (denominator2, denominator1);
        }

        // [denominator1 > denominator2 > 0]
        if (firstNumeratorSign == 1) {
            // example: {10/10} and {1/1} or {10/100} and {1/10}
            if (numerator1 <= numerator2) {
                return false; // expecting: 0 < numerator2 < numerator1
            }

            if (numerator2.IsOne) {
                return denominator2.IsOne ? numerator1 == denominator1 : numerator1 * denominator2 == denominator1;
            }
        } else {
            // example: {-10/10} and {-1/1} or {-10/100} and {-1/10}
            if (numerator1 >= numerator2) {
                return false; // expecting: numerator1 < numerator2 < 0
            }

            if (numerator2 == BigInteger.MinusOne) {
                return denominator2.IsOne ? numerator1 == -denominator1 : numerator1 * -denominator2 == denominator1;
            }
        }

        if (denominator2.IsOne) {
            return numerator1 == numerator2 * denominator1;
        }

        var numeratorQuotient = BigInteger.DivRem(numerator1, numerator2, out var remainderNumerators);
        var denominatorQuotient = BigInteger.DivRem(denominator1, denominator2, out var remainderDenominators);
        // if the fractions are equal: numeratorQuotient should be equal to denominatorQuotient
        if (numeratorQuotient != denominatorQuotient) {
            return false;
        }

        // if the fractions are equal: {remainderNumerators / numerator2} should be equal to {remainderDenominators / denominator2}
        if (remainderDenominators.IsZero) {
            return remainderNumerators.IsZero; // both values should be 0 
        }

        if (remainderNumerators.IsZero) {
            return false; // both values should be 0 
        }

        return remainderNumerators * denominator2 == remainderDenominators * numerator2;
    }

    /// <inheritdoc />
    public override int GetHashCode(Fraction obj) {
        var fraction = obj.Reduce();
        unchecked {
            return (fraction.Denominator.GetHashCode() * 397) ^ fraction.Numerator.GetHashCode();
        }
    }
}
