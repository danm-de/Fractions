using System;
using System.Numerics;

namespace Fractions;

public partial struct Fraction {
    /// <summary>
    /// Rounds the given Fraction to the specified precision using <see cref="MidpointRounding.ToEven"/> rounding strategy.
    /// </summary>
    /// <param name="fraction">The Fraction to be rounded.</param>
    /// <param name="decimals">The number of significant decimal places (precision) in the return value.</param>
    /// <returns>The number that <paramref name="fraction" /> is rounded to using the <see cref="MidpointRounding.ToEven"/> rounding strategy and with a precision of <paramref name="decimals" />. If the precision of <paramref name="fraction" /> is less than <paramref name="decimals" />, <paramref name="fraction" /> is returned unchanged.</returns>
    /// <exception cref="ArgumentOutOfRangeException">If <paramref name="decimals"/> is less than 0</exception>
    public static Fraction Round(Fraction fraction, int decimals) =>
        Round(fraction, decimals, MidpointRounding.ToEven);

    /// <summary>
    /// Rounds the given Fraction to the specified precision using the specified rounding strategy.
    /// </summary>
    /// <param name="fraction">The Fraction to be rounded.</param>
    /// <param name="decimals">The number of significant decimal places (precision) in the return value.</param>
    /// <param name="mode">Specifies the strategy that mathematical rounding methods should use to round a number.</param>
    /// <returns>The number that <paramref name="fraction" /> is rounded to using the <paramref name="mode" /> rounding strategy and with a precision of <paramref name="decimals" />. If the precision of <paramref name="fraction" /> is less than <paramref name="decimals" />, <paramref name="fraction" /> is returned unchanged.</returns>
    /// <exception cref="ArgumentOutOfRangeException">If <paramref name="decimals"/> is less than 0</exception>
    public static Fraction Round(Fraction fraction, int decimals, MidpointRounding mode) {
#if NET
        ArgumentOutOfRangeException.ThrowIfNegative(decimals);
#else
        if (decimals < 0) {
            throw new ArgumentOutOfRangeException(nameof(decimals));
        }
#endif

        if (fraction.Denominator.IsOne || fraction.Denominator.IsZero) {
            return fraction;
        }

        var factor = BigInteger.Pow(TEN, decimals);
        var roundedNumerator = RoundToBigInteger(fraction.Numerator * factor, fraction.Denominator, mode);
        return new Fraction(roundedNumerator, factor);
    }

    /// <summary>
    /// Rounds the given Fraction to the specified precision using <see cref="MidpointRounding.ToEven"/> rounding strategy.
    /// </summary>
    /// <param name="fraction">The Fraction to be rounded.</param>
    /// <returns>The number as <see cref="BigInteger"/> that <paramref name="fraction" /> is rounded to using the <see cref="MidpointRounding.ToEven"/> rounding strategy.</returns>
    public static BigInteger RoundToBigInteger(Fraction fraction) =>
        RoundToBigInteger(fraction, MidpointRounding.ToEven);

    /// <summary>
    /// Rounds the given Fraction to the specified precision using the specified rounding strategy.
    /// </summary>
    /// <param name="fraction">The Fraction to be rounded.</param>
    /// <param name="mode">Specifies the strategy that mathematical rounding methods should use to round a number.</param>
    /// <returns>The number as <see cref="BigInteger"/> that <paramref name="fraction" /> is rounded to using the <paramref name="mode" /> rounding strategy.</returns>
    public static BigInteger RoundToBigInteger(Fraction fraction, MidpointRounding mode) =>
        RoundToBigInteger(fraction.Numerator, fraction.Denominator, mode);

    /// <summary>
    /// Rounds the given Fraction to the specified precision using the specified rounding strategy.
    /// </summary>
    /// <param name="numerator">The numerator of the fraction to be rounded.</param>
    /// <param name="denominator">The denominator of the fraction to be rounded.</param>
    /// <param name="mode">Specifies the strategy that mathematical rounding methods should use to round a number.</param>
    /// <returns>The number rounded to using the <paramref name="mode" /> rounding strategy.</returns>
    private static BigInteger RoundToBigInteger(BigInteger numerator, BigInteger denominator, MidpointRounding mode) {
        if (denominator.IsZero) {
            throw new DivideByZeroException();
        }
        
        if (numerator.IsZero || denominator.IsOne) {
            return numerator;
        }

        return mode switch {
            MidpointRounding.AwayFromZero => roundAwayFromZero(numerator, denominator),
            MidpointRounding.ToEven => roundToEven(numerator, denominator),
#if NET
            MidpointRounding.ToZero => BigInteger.Divide(numerator, denominator),
            MidpointRounding.ToPositiveInfinity => roundToPositiveInfinity(numerator, denominator),
            MidpointRounding.ToNegativeInfinity => roundToNegativeInfinity(numerator, denominator),
#endif
            _ => throw new ArgumentOutOfRangeException(nameof(mode))
        };

        static BigInteger roundAwayFromZero(BigInteger numerator, BigInteger denominator) {
            return numerator.Sign == denominator.Sign
                ? BigInteger.Divide(numerator + (denominator / 2), denominator)
                : BigInteger.Divide(numerator - (denominator / 2), denominator);
        }

        static BigInteger roundToEven(BigInteger numerator, BigInteger denominator) {
            var quotient = BigInteger.DivRem(numerator, denominator, out var remainder);
            if (numerator.Sign == denominator.Sign) {
                // For positive values or when both values are negative
                var midpoint = 2 * remainder;
                if (midpoint > denominator || (midpoint == denominator && !quotient.IsEven)) {
                    return quotient + 1;
                }
            } else {
                // For negative values
                remainder = -remainder;
                var midpoint = 2 * remainder;
                if (midpoint > denominator || (midpoint == denominator && !quotient.IsEven)) {
                    return quotient - 1;
                }
            }

            return quotient;
        }
#if NET
        static BigInteger roundToPositiveInfinity(BigInteger numerator, BigInteger denominator) {
            var quotient = BigInteger.DivRem(numerator, denominator, out var remainder);
            return remainder.Sign == 1 ? quotient + 1 : quotient;
        }

        static BigInteger roundToNegativeInfinity(BigInteger numerator, BigInteger denominator) {
            var quotient = BigInteger.DivRem(numerator, denominator, out var remainder);
            return remainder.Sign == -1 ? quotient - 1 : quotient;
        }
#endif
    }
}
