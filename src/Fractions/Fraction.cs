using System;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.InteropServices;
using Fractions.TypeConverters;

namespace Fractions;

/// <summary>
/// A mathematical fraction. A rational number written as a/b (a is the numerator and b the denominator). 
/// The data type is not capable to store NaN (not a number) or infinite.
/// </summary>
[TypeConverter(typeof(FractionTypeConverter))]
[StructLayout(LayoutKind.Sequential)]
public readonly partial struct Fraction : IEquatable<Fraction>, IComparable, IComparable<Fraction>, IFormattable {
    private static readonly BigInteger MIN_DECIMAL = new(decimal.MinValue);
    private static readonly BigInteger MAX_DECIMAL = new(decimal.MaxValue);
    private static readonly BigInteger TEN = new (10);
    private static readonly Fraction _nan = new(BigInteger.Zero, BigInteger.Zero, FractionState.IsNormalized);
    private static readonly Fraction _positiveInfinity = new(BigInteger.One, BigInteger.Zero, FractionState.IsNormalized);
    private static readonly Fraction _negativeInfinity = new(BigInteger.MinusOne, BigInteger.Zero, FractionState.IsNormalized);
    private static readonly Fraction _zero = new (BigInteger.Zero, BigInteger.One, FractionState.IsNormalized);
    private static readonly Fraction _one = new(BigInteger.One, BigInteger.One, FractionState.IsNormalized);
    private static readonly Fraction _minusOne = new(BigInteger.MinusOne, BigInteger.One, FractionState.IsNormalized);
    private static readonly Fraction _two = new(new BigInteger(2), BigInteger.One, FractionState.IsNormalized);

    private readonly BigInteger _denominator;
    private readonly BigInteger _numerator;
    private readonly FractionState _state;

    /// <summary>
    /// The numerator.
    /// </summary>
    public BigInteger Numerator => _numerator;

    /// <summary>
    /// The denominator
    /// </summary>
    public BigInteger Denominator => _denominator.IsZero && _numerator.IsZero && _state != FractionState.IsNormalized ? BigInteger.One : _denominator;


    /// <summary>
    /// <c>true</c> if the fraction represents a valid number or <c>false</c> otherwise.
    /// </summary>
    public bool IsNaN => _denominator.IsZero && _numerator.IsZero && _state == FractionState.IsNormalized;
    
    /// <summary>
    /// <c>true</c> if the fraction evaluates to positive or negative infinity or <c>false</c> otherwise.
    /// </summary>
    public bool IsInfinity => _denominator.IsZero && !_numerator.IsZero;
    
    /// <summary>
    /// <c>true</c> if the fraction evaluates to positive infinity or <c>false</c> otherwise.
    /// </summary>
    public bool IsPositiveInfinity => _denominator.IsZero && _numerator.Sign == 1;
    
    /// <summary>
    /// <c>true</c> if the fraction evaluates to negative infinity or <c>false</c> otherwise.
    /// </summary>
    public bool IsNegativeInfinity => _denominator.IsZero && _numerator.Sign == -1;

    /// <summary>
    ///     <c>true</c> if the value is greater than zero or <c>false</c> otherwise.
    /// </summary>
    public bool IsPositive => _numerator.Sign switch {
        0 => false,
        1 => _denominator.Sign >= 0,
        _ => _denominator.Sign < 0
    };

    /// <summary>
    /// <c>true</c> if the value is lesser than zero or <c>false</c> otherwise.
    /// </summary>
    public bool IsNegative => _numerator.Sign switch {
        0 => false,
        -1 => _denominator.Sign >= 0,
        _ => _denominator.Sign < 0
    };

    /// <summary>
    /// <c>true</c> if the fraction represents the value 0 or <c>false</c> otherwise.
    /// </summary>
    public bool IsZero => _numerator.IsZero && !IsNaN;

    /// <summary>
    /// The fraction's state.
    /// </summary>
    public FractionState State => _state;

    /// <summary>
    /// A fraction representing the positive infinity.
    /// </summary>
    public static Fraction PositiveInfinity => _positiveInfinity;

    /// <summary>
    /// A fraction representing the negative infinity.
    /// </summary>
    public static Fraction NegativeInfinity => _negativeInfinity;
    
    /// <summary>
    /// A fraction representing the result of dividing zero by zero.
    /// </summary>
    public static Fraction NaN => _nan;

    /// <summary>
    /// A fraction with the reduced/simplified value of 0.
    /// </summary>
    public static Fraction Zero => _zero;

    /// <summary>
    /// A fraction with the reduced/simplified value of 1.
    /// </summary>
    public static Fraction One => _one;

    /// <summary>
    /// A fraction with the reduced/simplified value of 2.
    /// </summary>
    public static Fraction Two => _two;

    /// <summary>
    /// A fraction with the reduced/simplified value of -1.
    /// </summary>
    public static Fraction MinusOne => _minusOne;
}
