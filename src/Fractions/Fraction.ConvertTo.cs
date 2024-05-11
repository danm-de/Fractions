using System;
using System.Numerics;

namespace Fractions;

public readonly partial struct Fraction {
    private static readonly BigInteger MIN_DECIMAL = new(decimal.MinValue);
    private static readonly BigInteger MAX_DECIMAL = new(decimal.MaxValue);

    /// <summary>
    ///     Returns the fraction as signed 32bit integer.
    /// </summary>
    /// <returns>32bit signed integer</returns>
    public int ToInt32() {
        var denominator = Denominator;
        return denominator.IsOne ? (int)Numerator : (int)(Numerator / denominator);
    }

    /// <summary>
    ///     Returns the fraction as signed 64bit integer.
    /// </summary>
    /// <returns>64bit signed integer</returns>
    public long ToInt64() {
        var denominator = Denominator;
        return denominator.IsOne ? (long)Numerator : (long)(Numerator / denominator);
    }

    /// <summary>
    ///     Returns the fraction as unsigned 32bit integer.
    /// </summary>
    /// <returns>32bit unsigned integer</returns>
    [CLSCompliant(false)]
    public uint ToUInt32() {
        var denominator = Denominator;
        return denominator.IsOne ? (uint)Numerator : (uint)(Numerator / denominator);
    }

    /// <summary>
    ///     Returns the fraction as unsigned 64bit integer.
    /// </summary>
    /// <returns>64-Bit unsigned integer</returns>
    [CLSCompliant(false)]
    public ulong ToUInt64() {
        var denominator = Denominator;
        return denominator.IsOne ? (ulong)Numerator : (ulong)(Numerator / denominator);
    }

    /// <summary>
    ///     Returns the fraction as BigInteger.
    /// </summary>
    /// <returns>BigInteger</returns>
    public BigInteger ToBigInteger() {
        var denominator = Denominator;
        return denominator.IsOne ? Numerator : Numerator / denominator;
    }

    /// <summary>
    ///     Returns the fraction as (rounded!) decimal value.
    /// </summary>
    /// <returns>Decimal value</returns>
    public decimal ToDecimal() {
        var numerator = Numerator;
        var denominator = Denominator;
        if (denominator.IsZero) {
            throw new DivideByZeroException();
        }

        if (denominator.IsOne) {
            return (decimal)Numerator; // the possible overflow is unavoidable
        }

        if (numerator.IsZero) {
            return decimal.Zero;
        }

        if (numerator >= MIN_DECIMAL && numerator <= MAX_DECIMAL &&
            denominator >= MIN_DECIMAL && denominator <= MAX_DECIMAL) {
            return (decimal)numerator / (decimal)denominator;
        }

        // numerator or denominator is too big. Lets try to split the calculation..
        // Possible OverFlowException!
        var withoutDecimalPlaces = (decimal)(numerator / denominator);

        var remainder = numerator % denominator;
        var lowPart = remainder * BigInteger.Pow(TEN, 28) / denominator;
        var decimalPlaces = (decimal)lowPart / (decimal)Math.Pow(10, 28);

        return withoutDecimalPlaces + decimalPlaces;
    }

    /// <summary>
    ///     Returns the fraction as (rounded!) floating point value.
    /// </summary>
    /// <returns>A floating point value</returns>
    public double ToDouble() {
        var denominator = Denominator;
        return denominator.IsOne ? (double)Numerator : (double)Numerator / (double)denominator;
    }
}
