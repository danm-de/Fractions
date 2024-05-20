using System;
using System.Numerics;

namespace Fractions;

public readonly partial struct Fraction {
    private static readonly BigInteger MIN_DECIMAL = new(decimal.MinValue);
    private static readonly BigInteger MAX_DECIMAL = new(decimal.MaxValue);

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
        if (denominator.IsZero) {
            throw new DivideByZeroException();
        }

        if (denominator.IsOne) {
            return (decimal)numerator; // the possible overflow is unavoidable
        }

        if (numerator.IsZero) {
            return decimal.Zero;
        }

        if (numerator >= MIN_DECIMAL && numerator <= MAX_DECIMAL &&
            denominator >= MIN_DECIMAL && denominator <= MAX_DECIMAL) {
            return (decimal)numerator / (decimal)denominator;
        }

        // If the numerator or denominator is too large, we attempt to avoid the OverflowException by splitting the calculation.
        // However, the line below can still throw an OverflowException if the result of the division is outside the decimal range.
        var withoutDecimalPlaces = (decimal)BigInteger.DivRem(numerator, denominator, out var remainder);

        var lowPart = remainder * BigInteger.Pow(TEN, 28) / denominator;
        var decimalPlaces = (decimal)lowPart / (decimal)Math.Pow(10, 28);

        return withoutDecimalPlaces + decimalPlaces;
    }

    /// <summary>
    ///     Converts the fraction to a decimal value, preserving trailing zeros.
    /// </summary>
    /// <returns>
    ///     The fraction represented as a decimal, including trailing zeros. If the number exceeds decimal precision,
    ///     the extra decimals are lost due to rounding.
    /// </returns>
    /// <exception cref="DivideByZeroException">
    ///     Thrown when the denominator is zero - i.e. the value is NaN or Infinity.
    /// </exception>
    /// <exception cref="OverflowException">
    ///     Thrown when the number represented by this fraction is outside the decimal range, or if the numerator or
    ///     denominator
    ///     is too large for the division operation.
    /// </exception>
    /// <remarks>
    ///     Trailing zeros refer to any zeros that appear after the decimal point but do not affect the value of the decimal.
    ///     For example, the number 1.20 represented by the fraction 120/100 has one trailing zero.
    /// </remarks>
    public decimal ToDecimalWithTrailingZeros() {
        if (!_normalizationNotApplied) {
            return ToDecimal();
        }

        var numerator = Numerator;
        var denominator = Denominator;
        if (denominator.IsZero) {
            throw new DivideByZeroException();
        }

        if (denominator.IsOne) {
            return (decimal)Numerator; // the possible overflow is unavoidable
        }

        var extraZeroes = getNumberOfTrailingZeros(BigInteger.GreatestCommonDivisor(numerator, denominator));
        decimal exactResult;
        if (numerator >= MIN_DECIMAL && numerator <= MAX_DECIMAL &&
            denominator >= MIN_DECIMAL && denominator <= MAX_DECIMAL) {
            exactResult = (decimal)numerator / (decimal)denominator;
        } else {
            var withoutDecimalPlaces = (decimal)BigInteger.DivRem(numerator, denominator, out var remainder);
            // If the denominator is too large, we attempt to avoid the OverflowException by splitting the calculation.
            var lowPart = remainder * BigInteger.Pow(TEN, 28) / denominator;
            var decimalPlaces = (decimal)lowPart / (decimal)Math.Pow(10, 28);
            exactResult = withoutDecimalPlaces + decimalPlaces;
        }

        if (extraZeroes == 0) {
            return exactResult;
        }

        var extraDigits = (decimal)BigInteger.Pow(TEN, extraZeroes);
        var shiftedResult = exactResult * (1m / extraDigits) * extraDigits; // we shift the result to the right and then back to the left
        return exactResult != shiftedResult ? exactResult : shiftedResult; // unless the exactResult represents a non-terminating decimal, return the zero-padded result

        static int getNumberOfTrailingZeros(BigInteger number) {
            if (number.IsOne) {
                return 0;
            }

            var trailingZeroCount = 0;

            // Continue dividing the number by 10 until remainder is non-zero
            while (true) {
                number = BigInteger.DivRem(number, TEN, out var remainder);
                if (remainder != 0) {
                    break;
                }

                trailingZeroCount++;
            }

            return trailingZeroCount;
        }
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
        var denominator = Denominator;
        return denominator.IsOne ? (double)Numerator : (double)Numerator / (double)denominator;
    }
}
