using System;
using System.Numerics;

namespace Fractions;

public readonly partial struct Fraction {
    /// <summary>
    /// Returns the fraction as signed 32bit integer.
    /// </summary>
    /// <returns>32bit signed integer</returns>
    public int ToInt32() => IsZero ? 0 : (int)(Numerator / Denominator);

    /// <summary>
    /// Returns the fraction as signed 64bit integer.
    /// </summary>
    /// <returns>64bit signed integer</returns>
    public long ToInt64() => IsZero ? 0 : (long)(Numerator / Denominator);

    /// <summary>
    /// Returns the fraction as unsigned 32bit integer.
    /// </summary>
    /// <returns>32bit unsigned integer</returns>
    [CLSCompliant(false)]
    public uint ToUInt32() => IsZero ? 0 : (uint)(Numerator / Denominator);

    /// <summary>
    /// Returns the fraction as unsigned 64bit integer.
    /// </summary>
    /// <returns>64-Bit unsigned integer</returns>
    [CLSCompliant(false)]
    public ulong ToUInt64() => IsZero ? 0 : (ulong)(Numerator / Denominator);

    /// <summary>
    /// Returns the fraction as BigInteger.
    /// </summary>
    /// <returns>BigInteger</returns>
    public BigInteger ToBigInteger() => IsZero ? BigInteger.Zero : Numerator / Denominator;

    /// <summary>
    /// Returns the fraction as (rounded!) decimal value.
    /// </summary>
    /// <returns>Decimal value</returns>
    public decimal ToDecimal() {
        if (IsZero) {
            return decimal.Zero;
        }

        if (_numerator >= MIN_DECIMAL && _numerator <= MAX_DECIMAL && _denominator >= MIN_DECIMAL &&
            _denominator <= MAX_DECIMAL) {
            return (decimal)_numerator / (decimal)_denominator;
        }

        // numerator or denominator is too big. Lets try to split the calculation..
        // Possible OverFlowException!
        var withoutDecimalPlaces = (decimal)(_numerator / _denominator);

        var remainder = _numerator % _denominator;
        var lowPart = remainder * BigInteger.Pow(TEN, 28) / _denominator;
        var decimalPlaces = (decimal)lowPart / (decimal)Math.Pow(10, 28);

        return withoutDecimalPlaces + decimalPlaces;
    }

    /// <summary>
    /// Returns the fraction as (rounded!) floating point value.
    /// </summary>
    /// <returns>A floating point value</returns>
    public double ToDouble() => IsZero ? 0 : (double)Numerator / (double)Denominator;
}
