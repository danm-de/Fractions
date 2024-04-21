using System;
using System.Numerics;

namespace Fractions;

public readonly partial struct Fraction {
    /// <summary>
    /// Calculates the remainder of the division with the fraction's value and the supplied <paramref name="divisor"/> (% operator).
    /// </summary>
    /// <param name="divisor">Divisor</param>
    /// <returns>The remainder (left over)</returns>
    public Fraction Remainder(Fraction divisor) {
        var numerator1 = Numerator;
        var denominator1 = Denominator;
        var numerator2 = divisor.Numerator;
        var denominator2 = divisor.Denominator;
        
        if (numerator2.IsZero) { // 0/0 (NaN) or 0/1 (zero)
            return _nan;
        }

        if (numerator1.IsZero) { // 0/0 (NaN) or 0/1 (zero)
            return denominator1.IsZero ? _nan : _zero;
        }

        if (denominator1.IsZero) { // a/0 (infinity)
            return _nan;
        }

        var gcd = BigInteger.GreatestCommonDivisor(denominator1, denominator2);

        var thisMultiplier = BigInteger.Divide(denominator1, gcd);
        var otherMultiplier = BigInteger.Divide(denominator2, gcd);

        var leastCommonMultiple = BigInteger.Multiply(thisMultiplier, denominator2);

        var a = BigInteger.Multiply(numerator1, otherMultiplier);
        var b = BigInteger.Multiply(numerator2, thisMultiplier);

        var remainder = BigInteger.Remainder(a, b);

        return new Fraction(remainder, leastCommonMultiple);
    }

    /// <summary>
    /// Adds the fraction's value with <paramref name="summand"/>.
    /// </summary>
    /// <param name="summand">Summand</param>
    /// <returns>The result as summation.</returns>
    public Fraction Add(Fraction summand) {
        if (IsNaN || summand.IsNaN) {
            // NaN + a = NaN
            return _nan;
        }

        var numerator1 = Numerator;
        if (numerator1.IsZero) {
            // 0 + b = b
            return summand;
        }
        
        var numerator2 = summand.Numerator;
        if (numerator2.IsZero) {
            // a + 0 = a
            return this;
        }
        
        var denominator1 = Denominator;
        var denominator2 = summand.Denominator;
        
        if (denominator1 == denominator2) {
            return denominator1.IsZero  // adding infinities
                ? (numerator1.Sign + numerator2.Sign) switch {
                    2 => _positiveInfinity,
                    -2 => _negativeInfinity,
                    _ => _nan
                }
                : GetReducedFraction(BigInteger.Add(numerator1, numerator2), denominator1);
        }

        var gcd = BigInteger.GreatestCommonDivisor(denominator1, denominator2);

        var thisMultiplier = BigInteger.Divide(denominator1, gcd);
        var otherMultiplier = BigInteger.Divide(denominator2, gcd);

        var leastCommonMultiple = BigInteger.Multiply(thisMultiplier, denominator2);

        var calculatedNumerator = BigInteger.Add(
            BigInteger.Multiply(numerator1, otherMultiplier),
            BigInteger.Multiply(numerator2, thisMultiplier)
        );

        return GetReducedFraction(calculatedNumerator, leastCommonMultiple);
    }

    /// <summary>
    /// Subtracts the fraction's value (minuend) with <paramref name="subtrahend"/>.
    /// </summary>
    /// <param name="subtrahend">Subtrahend.</param>
    /// <returns>The result as difference.</returns>
    public Fraction Subtract(Fraction subtrahend) => Add(subtrahend.Negate());

    /// <summary>
    /// Negates the fraction. Has the same result as multiplying it by -1.
    /// </summary>
    /// <returns>The negated fraction.</returns>
    public Fraction Negate() => new (BigInteger.Negate(_numerator), _denominator, _state);

    /// <inheritdoc cref="Negate"/>>
    [Obsolete("The 'Invert' method is obsolete. Please use the the 'Negate' method or the negation operator '-value'.", error: false)]
    public Fraction Invert() => Negate();

    /// <summary>
    /// Multiply the fraction's value by <paramref name="factor"/>.
    /// </summary>
    /// <param name="factor">Factor</param>
    /// <returns>The result as product.</returns>
    public Fraction Multiply(Fraction factor) =>
        GetReducedFraction(
            Numerator * factor.Numerator,
            Denominator * factor.Denominator);

    /// <summary>
    /// Divides the fraction's value by <paramref name="divisor"/>.
    /// </summary>
    /// <param name="divisor">Divisor</param>
    /// <returns>The result as quotient.</returns>
    public Fraction Divide(Fraction divisor) {
        var numerator2 = divisor.Numerator;
        var denominator2 = divisor.Denominator;

        if (denominator2.IsZero) { // dividing by NaN or Infinity produces NaN
            return _nan;
        }
        
        var numerator1 = Numerator;
        var denominator1 = Denominator;
        
        if (denominator1.IsZero) { // NaN or Infinity divided by a number
            return numerator1.Sign switch { // +/- Infinity divided by a number
                1 => numerator2.Sign * denominator2.Sign < 0 ? _negativeInfinity : _positiveInfinity,
                -1 => numerator2.Sign * denominator2.Sign < 0 ? _positiveInfinity : _negativeInfinity,
                _ => _nan // NaN divided by a number
            };
        }

        // both values are normal
        // TODO see about using an internal overload
        return GetReducedFraction(
            numerator1 * denominator2,
            denominator1 * numerator2);
    }

    /// <summary>
    /// Returns this as reduced/simplified fraction. The fraction's sign will be normalized.
    /// </summary>
    /// <returns>A reduced and normalized fraction.</returns>
    public Fraction Reduce() =>
        _state == FractionState.IsNormalized
            ? this
            : GetReducedFraction(Numerator, Denominator);

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
        if (denominator.IsZero) {
            return numerator.Sign switch {
                1 => _positiveInfinity,
                -1 => _negativeInfinity,
                _ => _nan
            };
        }

        if (numerator.IsZero) {
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
    public static Fraction Pow(Fraction @base, int exponent) {
        return exponent < 0
            ? @base.IsZero ? PositiveInfinity : GetReducedFraction(BigInteger.Pow(@base.Denominator, -exponent), BigInteger.Pow(@base.Numerator, -exponent))
            : GetReducedFraction(BigInteger.Pow(@base.Numerator, exponent), BigInteger.Pow(@base.Denominator, exponent));
    }

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
    public static Fraction Reciprocal(Fraction fraction) {
        if (fraction.IsInfinity) {
            return Zero; // note: we could technically support "positive" and "negative" zeros as non-normalized fractions
        }

        return fraction is { State: FractionState.IsNormalized, Numerator.Sign: -1 }
            ? new Fraction(
                numerator: BigInteger.Negate(fraction.Denominator),
                denominator: BigInteger.Negate(fraction.Numerator),
                state: fraction.State)
            : new Fraction(
                numerator: fraction.Denominator,
                denominator: fraction.Numerator,
                state: fraction.State);
    }
}
