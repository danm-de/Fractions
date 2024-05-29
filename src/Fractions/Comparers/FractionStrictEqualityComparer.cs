namespace Fractions;

/// <summary>
/// A comparator that checks the numerators and denominators of two fractions. The values ​​must be exactly the same.
/// </summary>
public sealed class FractionStrictEqualityComparer : FractionComparer {
    /// <inheritdoc />
    public override bool Equals(Fraction x, Fraction y) {
        return x.Numerator == y.Numerator && x.Denominator == y.Denominator;
    }

    /// <inheritdoc />
    public override int GetHashCode(Fraction obj) {
        unchecked {
            return (obj.Denominator.GetHashCode() * 397) ^ obj.Numerator.GetHashCode();
        }
    }
}
