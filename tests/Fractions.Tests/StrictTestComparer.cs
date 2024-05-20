using System;
using System.Collections;
using System.Collections.Generic;

namespace Fractions.Tests;

/// <summary>
/// An equality comparer that checks if two <see cref="Fraction"/> values are exactly the same.
/// </summary>
internal sealed class StrictTestComparer : IEqualityComparer<Fraction>, IEqualityComparer {
    public static IEqualityComparer<Fraction> Instance { get; } = new StrictTestComparer();

    public bool Equals(Fraction x, Fraction y) =>
        x.Numerator == y.Numerator &&
        x.Denominator == y.Denominator &&
        x.State == y.State;

    public int GetHashCode(Fraction obj) {
        unchecked {
            return (((obj.Denominator.GetHashCode() * 397) ^ obj.Numerator.GetHashCode()) * 397) ^
                   obj.State.GetHashCode();
        }
    }

    bool IEqualityComparer.Equals(object x, object y) => Equals(x, y);

    public new bool Equals(object x, object y) {
        if (ReferenceEquals(x, y)) {
            return true;
        }

        if (x is null || y is null) {
            return false;
        }

        return x is Fraction a &&
               y is Fraction b &&
               Equals(a, b);
    }

    public int GetHashCode(object obj) {
        if (obj is null) {
            throw new ArgumentNullException(nameof(obj));
        }

        return obj is Fraction fraction
            ? GetHashCode(fraction)
            : obj.GetHashCode();
    }
}
