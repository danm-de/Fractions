using System;
using System.Numerics;

namespace Fractions.Serialization;

/// <summary>
/// A helper to serialize and deserialize the <see cref="Fraction"/> data type
/// </summary>
public static class FractionSerialization {
    /// <summary>
    /// Get the components of the fractional data type.
    /// </summary>
    /// <param name="value">The fraction of interest.</param>
    /// <returns>A tuple containing components</returns>
    [CLSCompliant(false)]
    public static (bool NormalizationNotApplied, BigInteger Numerator, BigInteger Denominator) GetComponents(
        ref Fraction value) =>
        (value.State == FractionState.Unknown, value.Numerator, value.Denominator);

    /// <summary>
    /// Get the components of the fractional data type.
    /// </summary>
    /// <param name="value">The fraction of interest.</param>
    /// <returns>A tuple containing components</returns>
    public static (bool NormalizationNotApplied, BigInteger Numerator, BigInteger Denominator) GetComponents(
        Fraction value) =>
        (value.State == FractionState.Unknown, value.Numerator, value.Denominator);

    /// <summary>
    ///     Initializes a new instance of the Fraction struct with the specified numerator and denominator.
    /// </summary>
    /// <param name="normalizationNotApplied">Indicates whether the fraction is not normalized.</param>
    /// <param name="numerator">The numerator of the fraction.</param>
    /// <param name="denominator">The denominator of the fraction.</param>
    /// <returns>A fraction instance</returns>
    [CLSCompliant(false)]
    public static Fraction CreateFromComponents(
        ref bool normalizationNotApplied,
        ref BigInteger numerator,
        ref BigInteger denominator) =>
        new(ref normalizationNotApplied, ref numerator, ref denominator);

    /// <summary>
    ///     Initializes a new instance of the Fraction struct with the specified numerator and denominator.
    /// </summary>
    /// <param name="normalizationNotApplied">Indicates whether the fraction is not normalized.</param>
    /// <param name="numerator">The numerator of the fraction.</param>
    /// <param name="denominator">The denominator of the fraction.</param>
    /// <returns>A fraction instance</returns>
    public static Fraction CreateFromComponents(
        bool normalizationNotApplied,
        BigInteger numerator,
        BigInteger denominator) =>
        new(ref normalizationNotApplied, ref numerator, ref denominator);
}
