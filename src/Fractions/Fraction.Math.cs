using System;
using System.Numerics;
using Fractions.Properties;

namespace Fractions;

public readonly partial struct Fraction {
    /// <summary>
    /// Calculates the remainder of the division with the fraction's value and the supplied <paramref name="divisor"/> (% operator).
    /// </summary>
    /// <param name="divisor">Divisor</param>
    /// <returns>The remainder (left over)</returns>
    public Fraction Remainder(Fraction divisor) {
        if (divisor.IsZero) {
            throw new DivideByZeroException();
        }

        if (IsZero) {
            return _zero;
        }

        var gcd = BigInteger.GreatestCommonDivisor(_denominator, divisor.Denominator);

        var thisMultiplier = BigInteger.Divide(_denominator, gcd);
        var otherMultiplier = BigInteger.Divide(divisor.Denominator, gcd);

        var leastCommonMultiple = BigInteger.Multiply(thisMultiplier, divisor.Denominator);

        var a = BigInteger.Multiply(_numerator, otherMultiplier);
        var b = BigInteger.Multiply(divisor.Numerator, thisMultiplier);

        var remainder = BigInteger.Remainder(a, b);

        return new Fraction(remainder, leastCommonMultiple);
    }

    /// <summary>
    /// Adds the fraction's value with <paramref name="summand"/>.
    /// </summary>
    /// <param name="summand">Summand</param>
    /// <returns>The result as summation.</returns>
    public Fraction Add(Fraction summand) {
        if (_denominator == summand.Denominator) {
            return new Fraction(BigInteger.Add(_numerator, summand.Numerator), _denominator, true);
        }

        if (IsZero) {
            // 0 + b = b
            return summand;
        }

        if (summand.IsZero) {
            // a + 0 = a
            return this;
        }

        var gcd = BigInteger.GreatestCommonDivisor(_denominator, summand.Denominator);

        var thisMultiplier = BigInteger.Divide(_denominator, gcd);
        var otherMultiplier = BigInteger.Divide(summand.Denominator, gcd);

        var leastCommonMultiple = BigInteger.Multiply(thisMultiplier, summand.Denominator);

        var calculatedNumerator = BigInteger.Add(
            BigInteger.Multiply(_numerator, otherMultiplier),
            BigInteger.Multiply(summand.Numerator, thisMultiplier)
        );

        return new Fraction(calculatedNumerator, leastCommonMultiple, true);
    }

    /// <summary>
    /// Subtracts the fraction's value (minuend) with <paramref name="subtrahend"/>.
    /// </summary>
    /// <param name="subtrahend">Subtrahend.</param>
    /// <returns>The result as difference.</returns>
    public Fraction Subtract(Fraction subtrahend) => Add(subtrahend.Invert());

    /// <summary>
    /// Inverts the fraction. Has the same result as multiplying it by -1.
    /// </summary>
    /// <returns>The inverted fraction.</returns>
    public Fraction Invert() =>
        IsZero ? _zero : new Fraction(BigInteger.Negate(_numerator), _denominator, _state);

    /// <summary>
    /// Multiply the fraction's value by <paramref name="factor"/>.
    /// </summary>
    /// <param name="factor">Factor</param>
    /// <returns>The result as product.</returns>
    public Fraction Multiply(Fraction factor) =>
        new(
            _numerator * factor._numerator,
            _denominator * factor._denominator,
            true);

    /// <summary>
    /// Divides the fraction's value by <paramref name="divisor"/>.
    /// </summary>
    /// <param name="divisor">Divisor</param>
    /// <returns>The result as quotient.</returns>
    public Fraction Divide(Fraction divisor) =>
        divisor.IsZero
            ? throw new DivideByZeroException(string.Format(Resources.DivideByZero, this))
            : new Fraction(
                numerator: _numerator * divisor._denominator,
                denominator: _denominator * divisor._numerator,
                normalize: true);

    /// <summary>
    /// Returns this as reduced/simplified fraction. The fraction's sign will be normalized.
    /// </summary>
    /// <returns>A reduced and normalized fraction.</returns>
    public Fraction Reduce() =>
        _state == FractionState.IsNormalized
            ? this
            : GetReducedFraction(_numerator, _denominator);

    /// <summary>
    /// Gets the absolute value of a <see cref="Fraction"/> object.
    /// </summary>
    /// <returns>The absolute value.</returns>
    public Fraction Abs() => Abs(this);

    /// <summary>
    /// Gets the absolute value of a <see cref="Fraction"/> object.
    /// </summary>
    /// <param name="fraction">The fraction.</param>
    /// <returns>The absolute value.</returns>
    public static Fraction Abs(Fraction fraction) =>
        new(BigInteger.Abs(fraction.Numerator), BigInteger.Abs(fraction.Denominator), fraction.State);

    /// <summary>
    /// Returns a reduced and normalized fraction.
    /// </summary>
    /// <param name="numerator">Numerator</param>
    /// <param name="denominator">Denominator</param>
    /// <returns>A reduced and normalized fraction</returns>
    public static Fraction GetReducedFraction(BigInteger numerator, BigInteger denominator) {
        if (numerator.IsZero || denominator.IsZero) {
            return Zero;
        }

        if (denominator.Sign == -1) {
            // Denominator must not be negative after normalization
            numerator = BigInteger.Negate(numerator);
            denominator = BigInteger.Negate(denominator);
        }

        var gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);
        if (gcd is { IsOne: false, IsZero: false }) {
            return new Fraction(BigInteger.Divide(numerator, gcd), BigInteger.Divide(denominator, gcd),
                FractionState.IsNormalized);
        }

        return new Fraction(numerator, denominator, FractionState.IsNormalized);
    }

    /// <summary>
    /// Returns a fraction raised to the specified power.
    /// </summary>
    /// <param name="base">base to be raised to a power</param>
    /// <param name="exponent">A number that specifies a power (exponent)</param>
    /// <returns>The fraction <paramref name="base"/> raised to the power <paramref name="exponent"/>.</returns>
    public static Fraction Pow(Fraction @base, int exponent) =>
        exponent < 0
            ? Pow(new Fraction(@base._denominator, @base._numerator), -exponent)
            : new Fraction(BigInteger.Pow(@base._numerator, exponent), BigInteger.Pow(@base._denominator, exponent));

    /// <summary>
    /// Returns a fraction with the numerator and denominator exchanged.
    /// </summary>
    /// <returns>
    /// The fraction with the numerator and denominator exchanged.
    /// </returns>
    public Fraction Reciprocal() => Reciprocal(this);

    /// <summary>
    /// Returns a fraction with the numerator and denominator exchanged.
    /// </summary>
    /// <param name="fraction">The fraction.</param>
    /// <returns>
    /// The fraction with the numerator and denominator exchanged.
    /// </returns>
    public static Fraction Reciprocal(Fraction fraction) =>
        fraction is { State: FractionState.IsNormalized, Numerator.Sign: -1 }
            ? new Fraction(
                numerator: BigInteger.Negate(fraction.Denominator),
                denominator: BigInteger.Negate(fraction.Numerator),
                state: fraction.State)
            : new Fraction(
                numerator: fraction.Denominator,
                denominator: fraction.Numerator,
                state: fraction.State);

    /// <summary>
    ///     Rounds the given Fraction to the specified precision using the specified rounding strategy.
    /// </summary>
    /// <param name="fraction">The Fraction to be rounded.</param>
    /// <param name="decimals">The number of significant decimal places (precision) in the return value.</param>
    /// <param name="mode">One of the enumeration values that specifies which rounding strategy to use.</param>
    /// <returns>The number that <paramref name="fraction" /> is rounded to using the <paramref name="mode" /> rounding strategy and with a precision of <paramref name="decimals" />. If the precision of <paramref name="fraction" /> is less than <paramref name="decimals" />, <paramref name="fraction" /> is returned unchanged.</returns>
    public static Fraction Round(Fraction fraction, int decimals, MidpointRounding mode = MidpointRounding.ToEven) {
        if (decimals < 0) {
            throw new ArgumentOutOfRangeException(nameof(decimals));
        }
        
        if (fraction.IsZero || fraction.Denominator.IsOne) {
            return fraction;
        }

        var factor = BigInteger.Pow(TEN, decimals);
        var roundedNumerator = Round(fraction.Numerator * factor, fraction.Denominator, mode);
        return new Fraction(roundedNumerator, factor);
    }
    
    /// <summary>
    ///     Rounds the given Fraction to the specified precision using the specified rounding strategy.
    /// </summary>
    /// <param name="fraction">The Fraction to be rounded.</param>
    /// <param name="mode">One of the enumeration values that specifies which rounding strategy to use.</param>
    /// <returns>The number that <paramref name="fraction" /> is rounded to using the <paramref name="mode" /> rounding strategy.</returns>
    public static BigInteger Round(Fraction fraction, MidpointRounding mode = MidpointRounding.ToEven) {
        return Round(fraction.Numerator, fraction.Denominator, mode);
    }

    /// <summary>
    ///     Rounds the given Fraction to the specified precision using the specified rounding strategy.
    /// </summary>
    /// <param name="numerator">The numerator of the fraction to be rounded.</param>
    /// <param name="denominator">The denominator of the fraction to be rounded.</param>
    /// <param name="mode">One of the enumeration values that specifies which rounding strategy to use.</param>
    /// <returns>The number rounded to using the <paramref name="mode" /> rounding strategy.</returns>
    private static BigInteger Round(BigInteger numerator, BigInteger denominator, MidpointRounding mode = MidpointRounding.ToEven) {
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
                ? BigInteger.Divide(numerator + denominator / 2, denominator)
                : BigInteger.Divide(numerator - denominator / 2, denominator);
        }

        static BigInteger roundToEven(BigInteger numerator, BigInteger denominator) {
            var quotient = BigInteger.DivRem(numerator, denominator, out var remainder);
            var half = denominator / 2;
            if (numerator.Sign == denominator.Sign) {
                // For positive values or when both values are negative
                if (remainder > half || (remainder == half && !quotient.IsEven)) {
                    return quotient + 1;
                }
            } else {
                // For negative values
                remainder = -remainder;
                if (remainder > half || (remainder == half && !quotient.IsEven)) {
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
