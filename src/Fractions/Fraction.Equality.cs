using System;
using System.Numerics;

namespace Fractions;

public readonly partial struct Fraction {
    /// <summary>
    ///     Tests if the calculated value of this fraction equals to the calculated value of <paramref name="other" />.
    ///     It does not matter if either of them is not normalized. Both values will be reduced (normalized) before performing
    ///     the <see cref="object.Equals(object)" /> test.
    /// </summary>
    /// <param name="other">The fraction to compare with.</param>
    /// <returns><c>true</c> if both values are equivalent. (e.g. 2/4 is equivalent to 1/2. But 2/4 is not equivalent to -1/2)</returns>
    [Obsolete("As of version 8.0.0, the equality of values is checked when Fraction.Equals(..) is called. Please use the .Equals(..) method.",
        error: false)]
    public bool IsEquivalentTo(Fraction other) {
        return Equals(other);
    }

    /// <summary>
    /// Compares whether the value of two fractions is the same
    /// </summary>
    /// <param name="other">The fraction to compare with.</param>
    /// <returns>Is <c>true</c> if both fractions have the same value. Otherwise <c>false</c>.</returns>
    public bool Equals(Fraction other) {
        return FractionComparer.ValueEquality.Equals(this, other);
    }

    /// <inheritdoc cref="Equals(Fraction)"/>
    public override bool Equals(object other) {
        return other is Fraction fraction && Equals(fraction);
    }

    /// <summary>Returns the hash code.</summary>
    /// <returns><inheritdoc cref="BigInteger.GetHashCode()"/></returns>
    public override int GetHashCode() {
        return FractionComparer.ValueEquality.GetHashCode(this);
    }
}
