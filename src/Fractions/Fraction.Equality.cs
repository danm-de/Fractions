using System;

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
    ///     <para>Performs an exact comparison with <paramref name="other" /> using numerator and denominator.</para>
    ///     <para>Warning: 1/2 is NOT equal to 2/4! -1/2 is NOT equal to 1/-2!</para>
    ///     <para>
    ///         If you want to test the calculated values for equality use <see cref="CompareTo(Fraction)" /> or
    ///         <see cref="IsEquivalentTo" />
    ///     </para>
    /// </summary>
    /// <param name="other">The fraction to compare with.</param>
    /// <returns>
    ///     <c>true</c> if numerator and denominator of both fractions are equal, and neither of them is
    ///     <see cref="NaN" />.
    /// </returns>
    public bool Equals(Fraction other) {
        return FractionComparer.ValueEquality.Equals(this, other);
    }

    /// <summary>
    ///     <para>Performs an exact comparison with <paramref name="other" /> using numerator and denominator.</para>
    ///     <para>Warning: 1/2 is NOT equal to 2/4! -1/2 is NOT equal to 1/-2!</para>
    ///     <para>
    ///         If you want to test the calculated values for equality use <see cref="CompareTo(Fraction)" /> or
    ///         <see cref="IsEquivalentTo" />
    ///     </para>
    /// </summary>
    /// <param name="other">The fraction to compare with.</param>
    /// <returns>
    ///     <c>true</c> if <paramref name="other" /> is type of <see cref="Fraction" /> and numerator and denominator of
    ///     both are equal, and neither of them is <see cref="NaN" />.
    /// </returns>
    public override bool Equals(object other) {
        return other is Fraction fraction && Equals(fraction);
    }

    /// <summary>
    ///     Returns the hash code.
    /// </summary>
    /// <returns>
    ///     A 32bit integer with sign. It has been constructed using the <see cref="Numerator" /> and the
    ///     <see cref="Denominator" />.
    /// </returns>
    /// <filterpriority>2</filterpriority>
    public override int GetHashCode() {
        return FractionComparer.ValueEquality.GetHashCode(this);
    }
}
