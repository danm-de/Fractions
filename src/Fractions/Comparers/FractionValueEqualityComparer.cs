namespace Fractions;

/// <summary>
/// A comparator that checks two fractions for equality of value. It doesn't matter whether the numerator and denominator were reduced to the lowest common denominator.
/// </summary>
public class FractionValueEqualityComparer : FractionComparer
{
    /// <inheritdoc />
    public override bool Equals(Fraction x, Fraction y) {
        if (x.IsNaN || y.IsNaN) {
            return false; // special case (NaN values are not considered equal)
        }

        // normalize (if needed)
        var a = x.Reduce(); 
        var b = y.Reduce();

        // test for value equality
        return a.Numerator == b.Numerator && a.Denominator == b.Denominator;
    }

    /// <inheritdoc />
    public override int GetHashCode(Fraction obj) {
        var fraction = obj.Reduce();
        unchecked {
            return (fraction.Denominator.GetHashCode() * 397) ^ fraction.Numerator.GetHashCode();
        }
    }
}
