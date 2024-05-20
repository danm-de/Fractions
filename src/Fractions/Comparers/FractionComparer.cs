using System;
using System.Collections;
using System.Collections.Generic;

namespace Fractions;

/// <summary>
/// Represents a <see cref="Fraction"/> comparison operation that uses specific rules.
/// </summary>
public abstract class FractionComparer :
    IEqualityComparer<Fraction>,
    IEqualityComparer {
    /// <inheritdoc cref="FractionValueEqualityComparer" path="/summary"/>>
    public static FractionComparer ValueEquality { get; } = new FractionValueEqualityComparer();

    /// <inheritdoc />
    public abstract bool Equals(Fraction x, Fraction y);

    /// <inheritdoc />
    public abstract int GetHashCode(Fraction obj);

    /// <inheritdoc cref="IEqualityComparer.Equals(object,object)"/>>
    public new bool Equals(object x, object y) {
        if (ReferenceEquals(x, y)) {
            return true;
        }

        if (x is null || y is null) {
            return false;
        }

        return (x is Fraction f1 && y is Fraction f2)
            ? Equals(f1, f2)
            : x.Equals(y);
    }

    /// <inheritdoc />
    bool IEqualityComparer.Equals(object x, object y) => Equals(x, y);

    /// <inheritdoc cref="IEqualityComparer.GetHashCode(object)"/>>
    public int GetHashCode(object obj) {
        if (obj is null) {
            throw new ArgumentNullException(nameof(obj));
        }

        return obj is Fraction f
            ? GetHashCode(f)
            : obj.GetHashCode();
    }

    /// <inheritdoc />
    int IEqualityComparer.GetHashCode(object obj) => GetHashCode(obj);
}
