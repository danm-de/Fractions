using System;
using System.Numerics;
#if NET
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;
#endif

namespace Fractions;

public readonly partial struct Fraction {
    private static readonly BigInteger MIN_DECIMAL = new(decimal.MinValue);
    private static readonly BigInteger MAX_DECIMAL = new(decimal.MaxValue);
    private static readonly BigInteger MIN_DOUBLE = new(double.MinValue);
    private static readonly BigInteger MAX_DOUBLE = new(double.MaxValue);

    /// <summary>
    ///     Converts the fraction to a 32-bit signed integer.
    /// </summary>
    /// <returns>The result of the integer division of the numerator by the denominator.</returns>
    /// <exception cref="DivideByZeroException">Thrown when the denominator is zero - i.e. the value is NaN or Infinity.</exception>
    /// <exception cref="OverflowException">
    ///     Thrown when the result of the division is outside the range of a 32-bit signed integer.
    /// </exception>
    public int ToInt32() {
        return (int)ToBigInteger();
    }

    /// <summary>
    ///     Converts the fraction to a 64-bit signed integer.
    /// </summary>
    /// <returns>The result of the integer division of the numerator by the denominator.</returns>
    /// <exception cref="DivideByZeroException">Thrown when the denominator is zero - i.e. the value is NaN or Infinity.</exception>
    /// <exception cref="OverflowException">
    ///     Thrown when the result of the division is outside the range of a 64-bit signed integer.
    /// </exception>
    public long ToInt64() {
        return (long)ToBigInteger();
    }

    /// <summary>
    ///     Converts the fraction to a 32-bit unsigned integer.
    /// </summary>
    /// <returns>The result of the integer division of the numerator by the denominator.</returns>
    /// <exception cref="DivideByZeroException">Thrown when the denominator is zero - i.e. the value is NaN or Infinity.</exception>
    /// <exception cref="OverflowException">
    ///     Thrown when the result of the division is outside the range of a 32-bit unsigned integer.
    /// </exception>
    [CLSCompliant(false)]
    public uint ToUInt32() {
        return (uint)ToBigInteger();
    }

    /// <summary>
    ///     Converts the fraction to a 64-bit unsigned integer.
    /// </summary>
    /// <returns>The result of the integer division of the numerator by the denominator.</returns>
    /// <exception cref="DivideByZeroException">Thrown when the denominator is zero - i.e. the value is NaN or Infinity.</exception>
    /// <exception cref="OverflowException">
    ///     Thrown when the result of the division is outside the range of a 64-bit unsigned integer.
    /// </exception>
    [CLSCompliant(false)]
    public ulong ToUInt64() {
        return (ulong)ToBigInteger();
    }

    /// <summary>
    ///     Converts the fraction to a BigInteger.
    /// </summary>
    /// <returns>The result of the integer division of the numerator by the denominator.</returns>
    /// <exception cref="DivideByZeroException">Thrown when the denominator is zero - i.e. the value is NaN or Infinity.</exception>
    public BigInteger ToBigInteger() {
        var denominator = Denominator;
        return denominator.IsOne ? Numerator : Numerator / denominator;
    }

    /// <summary>
    ///     Converts the fraction to a decimal value.
    /// </summary>
    /// <returns>
    ///     The fraction represented as a decimal. If the number exceeds decimal precision, the extra decimals are lost
    ///     due to rounding.
    /// </returns>
    /// <exception cref="DivideByZeroException">Thrown when the denominator is zero - i.e. the value is NaN or Infinity.</exception>
    /// <exception cref="OverflowException">
    ///     Thrown when the number represented by this fraction is outside the decimal range.
    /// </exception>
    public decimal ToDecimal() {
        var numerator = Numerator;
        var denominator = Denominator;
        switch (denominator.Sign) {
            case 0: {
                throw new DivideByZeroException();
            }
            case -1: {
                numerator = -numerator;
                denominator = -denominator;
                break;
            }
        }

        if (numerator.IsZero) {
            return decimal.Zero;
        }

        if (denominator.IsOne) {
            return (decimal)numerator;
        }

        if (numerator > MAX_DECIMAL) {
            if (denominator > MAX_DECIMAL) {
                // both terms need to be rounded
                numerator = (numerator * MAX_DECIMAL / denominator);
                denominator = MAX_DECIMAL;
                if (numerator <= MAX_DECIMAL) {
                    // both terms are now within range
                    return (decimal)numerator / (decimal)denominator;
                }
            }

            var withoutDecimalPlaces = (decimal) BigInteger.DivRem(numerator, denominator, out var remainder);
            return remainder.IsZero ? withoutDecimalPlaces : withoutDecimalPlaces + (decimal)remainder / (decimal)denominator;
        }

        if (numerator < MIN_DECIMAL) {
            if (denominator > MAX_DECIMAL) {
                // both terms need to be rounded
                numerator = (numerator * MAX_DECIMAL / denominator);
                denominator = MAX_DECIMAL;
                if (numerator >= MIN_DECIMAL) {
                    // both terms are now within range
                    return (decimal)numerator / (decimal)denominator;
                }
            }

            var withoutDecimalPlaces = (decimal)BigInteger.DivRem(numerator, denominator, out var remainder);
            return remainder.IsZero ? withoutDecimalPlaces : withoutDecimalPlaces + (decimal)remainder / (decimal)denominator;
        }

        if (denominator > MAX_DECIMAL) {
            // since both terms are non-zero and the numerator is smaller (in magnitude) to the denominator
            // the resulting number would be in the range [-1,1] (exclusive)
            // we want to flip the operation: x = a/b -> 1/x = b/a
            var decimalPart = BigInteger.DivRem(denominator, numerator, out var remainder);
            if (decimalPart < MAX_DECIMAL || decimalPart > MAX_DECIMAL) {
                return decimal.Zero;
            }

            return remainder.IsZero ? 1m / (decimal)decimalPart : 1m / ((decimal)decimalPart + (decimal)remainder / (decimal)numerator);
        }

        return (decimal)numerator / (decimal)denominator;
    }

    /// <summary>
    ///     Converts the fraction to a decimal number. If the fraction cannot be represented as a decimal due to its
    ///     size, the method will return the closest possible decimal representation (either decimal.MaxValue or
    ///     decimal.MinValue).
    /// </summary>
    /// <returns>
    ///     The decimal representation of the fraction. If the fraction is too large to represent as a decimal, returns
    ///     decimal.MaxValue. If the fraction is too small to represent as a decimal, returns decimal.MinValue.
    /// </returns>
    /// <remarks>If the fraction is NaN (the numerator and the denominator are both zero), the method will return decimal.Zero.</remarks>
    public decimal ToDecimalSaturating() {
        var numerator = Numerator;
        var denominator = Denominator;
        switch (denominator.Sign) {
            case 0: {
                return numerator.Sign switch {
                    1 => decimal.MaxValue,
                    -1 => decimal.MinValue,
                    _ => decimal.Zero
                };
            }
            case -1: {
                numerator = -numerator;
                denominator = -denominator;
                break;
            }
        }

        if (numerator.IsZero) {
            return decimal.Zero;
        }

        if (denominator.IsOne) {
            if (numerator > MAX_DECIMAL) {
                return decimal.MaxValue;
            }

            if (numerator < MIN_DECIMAL) {
                return decimal.MinValue;
            }

            return (decimal)numerator;
        }

        if (numerator > MAX_DECIMAL) {
            if (denominator > MAX_DECIMAL) {
                // both terms need to be rounded
                numerator = numerator * MAX_DECIMAL / denominator;
                denominator = MAX_DECIMAL;
                if (numerator <= MAX_DECIMAL) {
                    // both terms are now within range
                    return (decimal)numerator / (decimal)denominator;
                }
            }

            var withoutDecimalPlaces = BigInteger.DivRem(numerator, denominator, out var remainder);
            if (withoutDecimalPlaces > MAX_DECIMAL) {
                return decimal.MaxValue;
            }

            return remainder.IsZero ? (decimal)withoutDecimalPlaces : (decimal)withoutDecimalPlaces + (decimal)remainder / (decimal)denominator;
        }

        if (numerator < MIN_DECIMAL) {
            if (denominator > MAX_DECIMAL) {
                // both terms need to be rounded
                numerator = numerator * MAX_DECIMAL / denominator;
                denominator = MAX_DECIMAL;
                if (numerator >= MIN_DECIMAL) {
                    // both terms are now within range
                    return (decimal)numerator / (decimal)denominator;
                }
            }

            var withoutDecimalPlaces = BigInteger.DivRem(numerator, denominator, out var remainder);
            if (withoutDecimalPlaces < MIN_DECIMAL) {
                return decimal.MinValue;
            }

            return remainder.IsZero ? (decimal)withoutDecimalPlaces : (decimal)withoutDecimalPlaces + (decimal)remainder / (decimal)denominator;
        }

        if (denominator > MAX_DECIMAL) {
            // since both terms are non-zero and the numerator is smaller (in magnitude) to the denominator
            // the resulting number would be in the range [-1,1] (exclusive)
            // we want to flip the operation: x = a/b -> 1/x = b/a
            var decimalPart = BigInteger.DivRem(denominator, numerator, out var remainder);
            if (decimalPart < MAX_DECIMAL || decimalPart > MAX_DECIMAL) {
                return decimal.Zero;
            }

            return remainder.IsZero ? 1m / (decimal)decimalPart : 1m / ((decimal)decimalPart + (decimal)remainder / (decimal)numerator);
        }

        return (decimal)numerator / (decimal)denominator;
    }
    
    /// <summary>
    ///     Converts the fraction to a double precision floating point number.
    /// </summary>
    /// <returns>
    ///     The fraction represented as a double. If the number exceeds the precision of a double, the extra decimals are
    ///     lost due to rounding.
    /// </returns>
    /// <remarks>
    ///     If the denominator is zero, the result is NaN for a zero numerator and positive or negative infinity for a non-zero
    ///     numerator.
    /// </remarks>
    public double ToDouble() {
        var numerator = Numerator;
        var denominator = Denominator;

        switch (denominator.Sign) {
            case 0: {
                return numerator.Sign switch {
                    1 => double.PositiveInfinity,
                    -1 => double.NegativeInfinity,
                    _ => double.NaN
                };
            }
            case -1: {
                numerator = -numerator;
                denominator = -denominator;
                break;
            }
        }

        if (numerator.IsZero) {
            return 0;
        }
        
        if (denominator.IsOne) {
            return (double)numerator;
        }

        var convertedNumerator = (double)numerator;
        if (double.IsPositiveInfinity(convertedNumerator)) {
            if (denominator > MAX_DOUBLE) {
                // both terms need to be rounded
                numerator = numerator * MAX_DOUBLE / denominator;
                denominator = MAX_DOUBLE;
                if (numerator <= MAX_DOUBLE) {
                    // both terms are now within range
                    return (double)numerator / (double)denominator;
                }
            }

            var withoutDecimalPlaces = (double)BigInteger.DivRem(numerator, denominator, out var remainder);
            if (double.IsPositiveInfinity(withoutDecimalPlaces)) {
                return double.PositiveInfinity;
            }

            return remainder.IsZero ? withoutDecimalPlaces : withoutDecimalPlaces + (double)remainder / (double)denominator;
        }

        if (double.IsNegativeInfinity(convertedNumerator)) {
            if (denominator > MAX_DOUBLE) {
                // both terms need to be rounded
                numerator = numerator * MAX_DOUBLE / denominator;
                denominator = MAX_DOUBLE;
                if (numerator >= MIN_DOUBLE) {
                    // both terms are now within range
                    return (double)numerator / (double)denominator;
                }
            }

            var withoutDecimalPlaces = (double)BigInteger.DivRem(numerator, denominator, out var remainder);
            if (double.IsNegativeInfinity(withoutDecimalPlaces)) {
                return double.NegativeInfinity;
            }

            return remainder.IsZero ? withoutDecimalPlaces : withoutDecimalPlaces + (double)remainder / (double)denominator;
        }
        
        var convertedDenominator = (double)denominator;
        if (double.IsPositiveInfinity(convertedDenominator)) {
            // since both terms are non-zero and the numerator is smaller (in magnitude) to the denominator
            // the resulting number would be in the range [-1,1] (exclusive)
            // we want to flip the operation: x = a/b -> 1/x = b/a
            var decimalPart = (double) BigInteger.DivRem(denominator, numerator, out var remainder);
            if (double.IsInfinity(decimalPart)) {
                return 0;
            }

            return remainder.IsZero ? 1 / decimalPart : 1 / (decimalPart + (double)remainder / (double)numerator);
        }
        
        return convertedNumerator / convertedDenominator;
    }

    
#if NET7_0_OR_GREATER
    /// <summary>
    ///     Converts the given Fraction to a Half precision floating point number.
    /// </summary>
    /// <param name="value">The Fraction to convert.</param>
    /// <returns>The converted Half precision floating point number.</returns>
    /// <exception cref="OverflowException">Thrown when the Fraction is too large to fit in a Half.</exception>
    public static explicit operator Half(Fraction value)
    {
        return (Half)value.ToDouble();
    }
    
    /// <summary>
    ///     Converts the given Fraction to a Complex floating point number.
    /// </summary>
    /// <param name="value">The Fraction to convert.</param>
    /// <returns>The converted Complex floating point number.</returns>
    public static explicit operator Complex(Fraction value)
    {
        return value.ToDouble();
    }

    /// <summary>
    ///     Converts the given Fraction to an Int128.
    /// </summary>
    /// <param name="value">The Fraction to convert.</param>
    /// <returns>The converted Int128.</returns>
    /// <exception cref="OverflowException">Thrown when the Fraction is too large to fit in an Int128.</exception>
    public static explicit operator Int128(Fraction value)
    {
        return (Int128)(BigInteger)value;
    }

    /// <summary>
    ///     Converts the given Fraction to an UInt128.
    /// </summary>
    /// <param name="value">The Fraction to convert.</param>
    /// <returns>The converted UInt128.</returns>
    /// <exception cref="OverflowException">Thrown when the Fraction is too large to fit in an UInt128.</exception>
    [CLSCompliant(false)]
    public static explicit operator UInt128(Fraction value)
    {
        return (UInt128)(BigInteger)value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool INumberBase<Fraction>.TryConvertToChecked<TOther>(Fraction value, [MaybeNullWhen(false)] out TOther result) {
        if (typeof(TOther) == typeof(decimal)) {
            var convertedValue = value.ToDecimal();
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(double)) {
            var convertedValue = value.ToDouble();
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(Complex)) {
            Complex convertedValue = value.ToDouble();
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(float)) {
            var convertedValue = (float)value.ToDouble();
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(Half)) {
            var convertedValue = (Half)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(BigInteger)) {
            var convertedValue = (BigInteger)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(Int128)) {
            var convertedValue = (Int128)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(UInt128)) {
            var convertedValue = (UInt128)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(long)) {
            var convertedValue = (long)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(ulong)) {
            var convertedValue = (ulong)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(int)) {
            var convertedValue = (int)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(uint)) {
            var convertedValue = (uint)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(nint)) {
            var convertedValue = (nint)(BigInteger)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(UIntPtr)) {
            var convertedValue = (UIntPtr)(BigInteger)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(short)) {
            var convertedValue = (short)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(ushort)) {
            var convertedValue = (ushort)(BigInteger)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(char)) {
            var convertedValue = (char)(BigInteger)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(byte)) {
            var convertedValue = (byte)(BigInteger)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(sbyte)) {
            var convertedValue = (sbyte)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        result = default;
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool INumberBase<Fraction>.TryConvertToSaturating<TOther>(Fraction value, [MaybeNullWhen(false)] out TOther result) {
        if (typeof(TOther) == typeof(decimal)) {
            var convertedValue = value.ToDecimalSaturating();
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(double)) {
            var convertedValue = value.ToDouble();
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(Complex)) {
            Complex convertedValue = value.ToDouble();
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(float)) {
            var convertedValue = (float)value.ToDouble();
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(Half)) {
            var convertedValue = (Half)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(BigInteger)) {
            if (IsFinite(value)) {
                result = (TOther)(object)(BigInteger)value;
            } else if (value.Numerator.IsZero) {
                result = default;
            } else {
                throw new OverflowException();
            }

            return true;
        }

        if (typeof(TOther) == typeof(Int128)) {
            return convertFromBigInteger<Int128>(value, out result);
        }

        if (typeof(TOther) == typeof(UInt128)) {
            return convertFromBigInteger<UInt128>(value, out result);
        }

        if (typeof(TOther) == typeof(long)) {
            return convertFromBigInteger<long>(value, out result);
        }

        if (typeof(TOther) == typeof(ulong)) {
            return convertFromBigInteger<ulong>(value, out result);
        }

        if (typeof(TOther) == typeof(int)) {
            return convertFromBigInteger<int>(value, out result);
        }

        if (typeof(TOther) == typeof(uint)) {
            return convertFromBigInteger<uint>(value, out result);
        }

        if (typeof(TOther) == typeof(nint)) {
            return convertFromBigInteger<nint>(value, out result);
        }

        if (typeof(TOther) == typeof(UIntPtr)) {
            return convertFromBigInteger<UIntPtr>(value, out result);
        }

        if (typeof(TOther) == typeof(short)) {
            return convertFromBigInteger<short>(value, out result);
        }

        if (typeof(TOther) == typeof(ushort)) {
            return convertFromBigInteger<ushort>(value, out result);
        }

        if (typeof(TOther) == typeof(char)) {
            return convertFromBigInteger<char>(value, out result);
        }

        if (typeof(TOther) == typeof(byte)) {
            return convertFromBigInteger<byte>(value, out result);
        }

        if (typeof(TOther) == typeof(sbyte)) {
            return convertFromBigInteger<sbyte>(value, out result);
        }

        result = default;
        return false;

        static bool convertFromBigInteger<TNumber>(Fraction value, out TOther convertedValue) where TNumber : IMinMaxValue<TNumber> {
            convertedValue = IsFinite(value)
                ? TOther.CreateSaturating((BigInteger)value)
                : value.Numerator.Sign switch {
                    1 => (TOther)(object)TNumber.MaxValue,
                    -1 => (TOther)(object)TNumber.MinValue,
                    _ => default
                };

            return true;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool INumberBase<Fraction>.TryConvertToTruncating<TOther>(Fraction value, [MaybeNullWhen(false)] out TOther result) {
        if (typeof(TOther) == typeof(decimal)) {
            var num = value.ToDecimalSaturating();
            result = (TOther)(object)num;
            return true;
        }

        if (typeof(TOther) == typeof(double)) {
            var num = value.ToDouble();
            result = (TOther)(object)num;
            return true;
        }

        if (typeof(TOther) == typeof(Complex)) {
            Complex num = value.ToDouble();
            result = (TOther)(object)num;
            return true;
        }

        if (typeof(TOther) == typeof(float)) {
            var num = (float)value.ToDouble();
            result = (TOther)(object)num;
            return true;
        }

        if (typeof(TOther) == typeof(Half)) {
            var half = (Half)value;
            result = (TOther)(object)half;
            return true;
        }

        if (typeof(TOther) == typeof(BigInteger)) {
            if (IsFinite(value)) {
                result = (TOther)(object)(BigInteger)value;
            } else if (value.Numerator.IsZero) {
                result = default;
            } else {
                throw new OverflowException();
            }

            return true;
        }

        if (typeof(TOther) == typeof(Int128)) {
            return convertFromBigInteger<Int128>(value, out result);
        }

        if (typeof(TOther) == typeof(UInt128)) {
            return convertFromBigInteger<UInt128>(value, out result);
        }

        if (typeof(TOther) == typeof(long)) {
            return convertFromBigInteger<long>(value, out result);
        }

        if (typeof(TOther) == typeof(ulong)) {
            return convertFromBigInteger<ulong>(value, out result);
        }

        if (typeof(TOther) == typeof(int)) {
            return convertFromBigInteger<int>(value, out result);
        }

        if (typeof(TOther) == typeof(uint)) {
            return convertFromBigInteger<uint>(value, out result);
        }

        if (typeof(TOther) == typeof(nint)) {
            return convertFromBigInteger<nint>(value, out result);
        }

        if (typeof(TOther) == typeof(UIntPtr)) {
            return convertFromBigInteger<UIntPtr>(value, out result);
        }

        if (typeof(TOther) == typeof(short)) {
            return convertFromBigInteger<short>(value, out result);
        }

        if (typeof(TOther) == typeof(ushort)) {
            return convertFromBigInteger<ushort>(value, out result);
        }

        if (typeof(TOther) == typeof(char)) {
            return convertFromBigInteger<char>(value, out result);
        }

        if (typeof(TOther) == typeof(byte)) {
            return convertFromBigInteger<byte>(value, out result);
        }

        if (typeof(TOther) == typeof(sbyte)) {
            return convertFromBigInteger<sbyte>(value, out result);
        }

        result = default;
        return false;

        static bool convertFromBigInteger<TNumber>(Fraction value, out TOther convertedValue) where TNumber : IMinMaxValue<TNumber> {
            convertedValue = IsFinite(value)
                ? TOther.CreateTruncating((BigInteger)value)
                : value.Numerator.Sign switch {
                    1 => (TOther)(object)TNumber.MaxValue,
                    -1 => (TOther)(object)TNumber.MinValue,
                    _ => default
                };

            return true;
        }
    }

#endif
}
