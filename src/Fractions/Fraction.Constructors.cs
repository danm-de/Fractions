using System;
using System.Numerics;

namespace Fractions;

public readonly partial struct Fraction {
    /// <summary>
    ///     Initializes a new instance of the Fraction struct with the specified numerator and denominator.
    /// </summary>
    /// <param name="normalizationNotApplied">Indicates whether the fraction is not normalized.</param>
    /// <param name="numerator">The numerator of the fraction.</param>
    /// <param name="denominator">The denominator of the fraction.</param>
    internal Fraction(bool normalizationNotApplied, BigInteger numerator, BigInteger denominator) {
        Numerator = numerator;
        _denominator = denominator;
        _normalizationNotApplied = normalizationNotApplied;
    }

    /// <summary>
    ///     Initializes a new instance of the Fraction struct with the specified numerator and denominator.
    /// </summary>
    /// <param name="normalizationNotApplied">Indicates whether the fraction is not normalized.</param>
    /// <param name="numerator">The numerator of the fraction.</param>
    /// <param name="denominator">The denominator of the fraction.</param>
    internal Fraction(ref bool normalizationNotApplied, ref BigInteger numerator, ref BigInteger denominator) {
        Numerator = numerator;
        _denominator = denominator;
        _normalizationNotApplied = normalizationNotApplied;
    }

    /// <summary>
    /// Creates a normalized (reduced/simplified) fraction using <paramref name="numerator"/> and <paramref name="denominator"/>.
    /// </summary>
    /// <param name="numerator">Numerator</param>
    /// <param name="denominator">Denominator</param>
    public Fraction(BigInteger numerator, BigInteger denominator) {
        this = GetReducedFraction(numerator, denominator);
    }

    /// <summary>
    /// Creates a normalized (reduced/simplified) or non-normalized fraction using <paramref name="numerator"/> and <paramref name="denominator"/>.
    /// </summary>
    /// <param name="numerator">Numerator</param>
    /// <param name="denominator">Denominator</param>
    /// <param name="normalize">If <c>true</c> the fraction will be created as reduced/simplified fraction. 
    /// This is recommended, especially if your applications requires that the results of the equality methods <see cref="object.Equals(object)"/> 
    /// and <see cref="IComparable.CompareTo"/> are always the same. (1/2 != 2/4)</param>
    public Fraction(BigInteger numerator, BigInteger denominator, bool normalize) {
        if (normalize) {
            this = GetReducedFraction(numerator, denominator);
        } else {
            Numerator = numerator;
            _denominator = denominator;
            _normalizationNotApplied = true;
        }
    }

    /// <summary>
    /// Creates a normalized fraction using a signed 32bit integer.
    /// </summary>
    /// <param name="numerator">integer value that will be used for the numerator. The denominator will be 1.</param>
    public Fraction(int numerator) {
        Numerator = new BigInteger(numerator);
        _denominator = BigInteger.One;
    }

    /// <summary>
    /// Creates a normalized fraction using a signed 64bit integer.
    /// </summary>
    /// <param name="numerator">integer value that will be used for the numerator. The denominator will be 1.</param>
    public Fraction(long numerator) {
        Numerator = new BigInteger(numerator);
        _denominator = BigInteger.One;
    }

    /// <summary>
    /// Creates a normalized fraction using a unsigned 32bit integer.
    /// </summary>
    /// <param name="numerator">integer value that will be used for the numerator. The denominator will be 1.</param>
    [CLSCompliant(false)]
    public Fraction(uint numerator) {
        Numerator = new BigInteger(numerator);
        _denominator = BigInteger.One;
    }


    /// <summary>
    /// Creates a normalized fraction using a unsigned 64bit integer.
    /// </summary>
    /// <param name="numerator">integer value that will be used for the numerator. The denominator will be 1.</param>
    [CLSCompliant(false)]
    public Fraction(ulong numerator) {
        Numerator = new BigInteger(numerator);
        _denominator = BigInteger.One;
    }

    /// <summary>
    /// Creates a normalized fraction using a big integer.
    /// </summary>
    /// <param name="numerator">big integer value that will be used for the numerator. The denominator will be 1.</param>
    public Fraction(BigInteger numerator) {
        Numerator = numerator;
        _denominator = BigInteger.One;
    }

    /// <summary>
    ///     Creates a <see cref="Fraction"/> by converting a floating point value. Due to the fact that no rounding is applied to the input, values
    ///     such as 0.2 or 0.3, which do not have an exact representation as a <see cref="double" />, would result in
    ///     very large values in the numerator and denominator.
    /// </summary>
    /// <param name="value">A floating point value.</param>
    /// <returns>A fraction corresponding to the binary floating-point representation of the value</returns>
    /// <remarks>
    ///     The <see cref="double"/> data type in C# uses a binary floating-point representation, which can't accurately represent all
    ///     decimal fractions. When you convert a <see cref="double"/> to a <see cref="Fraction"/> using this method, the resulting fraction is an
    ///     exact representation of the <see cref="double"/> value, not the decimal number that the <see cref="double"/> is intended to approximate.
    ///     This is why you can end up with large numerators and denominators.
    ///     <code>
    /// var value = Fraction.FromDouble(0.1);
    /// Console.WriteLine(value);  // Outputs "3602879701896397/36028797018963968"
    /// </code>
    ///     The output fraction is an exact representation of the <see cref="double"/> value 0.1, which is actually slightly more than 0.1
    ///     due to the limitations of binary floating-point representation.
    /// <para>
    ///     Additionally, as the <see cref="double"/> value approaches the limits of its precision,
    ///     `Fraction.FromDouble(value).ToDouble() == value` might not hold true. This is because the numerator and denominator
    ///     of the <see cref="Fraction"/> are both very large numbers. When these numbers are converted to <see cref="double"/> for the division
    ///     operation in the <see cref="ToDouble"/> method, they can exceed the precision limit of the <see cref="double"/> type, resulting in
    ///     a loss of precision.
    /// </para>
    ///     <code>
    /// var value = Fraction.FromDouble(double.Epsilon);
    /// Console.WriteLine(value.ToDouble() == double.Epsilon);  // Outputs "False"
    /// </code>
    ///     For more information, visit the
    ///     <see href="https://github.com/danm-de/Fractions?tab=readme-ov-file#creation-from-double-without-rounding">
    ///         official GitHub repository
    ///         page.
    ///     </see>
    /// </remarks>
    public Fraction(double value) => this = FromDouble(value);

    /// <summary>
    /// Creates a normalized fraction using a 128bit decimal value (decimal).
    /// </summary>
    /// <param name="value">Floating point value.</param>
    public Fraction(decimal value) => this = FromDecimal(value);
}
