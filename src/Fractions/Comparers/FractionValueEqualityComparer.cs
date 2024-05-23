namespace Fractions;

/// <summary>
/// A comparator that checks two fractions for equality of value. It doesn't matter whether the numerator and denominator were reduced to the lowest common denominator.
/// </summary>
public sealed class FractionValueEqualityComparer : FractionComparer
{
    /// <inheritdoc />
    public override bool Equals(Fraction x, Fraction y) {
        var numerator1 = x.Numerator;
        var denominator1 = x.Denominator;
        var numerator2 = y.Numerator;
        var denominator2 = y.Denominator;

        if (denominator1 == denominator2) { 
            return denominator1.IsZero
                ? numerator1.Sign == numerator2.Sign // both fractions represent infinities
                : numerator1 == numerator2;
        }

        if (denominator1.IsZero || denominator2.IsZero) {
            // either x or y is NaN or infinity.
            return false;
        }

        if (numerator1.IsZero && numerator2.IsZero) {
            // both values are 0
            return true;
        }

        if (numerator1.IsZero || numerator2.IsZero) {
            // either x or y has the value 0
            return false;
        }

        // both values are non-zero fractions with different denominators  
        return Fraction.MultiplyTerms(numerator1, denominator2) == Fraction.MultiplyTerms(numerator2, denominator1);
    }

    /// <inheritdoc />
    public override int GetHashCode(Fraction obj) {
        var fraction = obj.Reduce();
        unchecked {
            return (fraction.Denominator.GetHashCode() * 397) ^ fraction.Numerator.GetHashCode();
        }
    }
}
