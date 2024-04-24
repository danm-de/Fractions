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

        if (denominator2.IsZero) {  // a % infinity
            return this;
        }
        
        var gcd = BigInteger.GreatestCommonDivisor(denominator1, denominator2);
        if (gcd.IsOne) {
            return GetReducedFraction(
                (numerator1 * denominator2) % (numerator2 * denominator1),
                denominator1 * denominator2);
        }
        
        var thisMultiplier = denominator1 / gcd;
        var otherMultiplier = denominator2 / gcd;
        
        var leastCommonMultiple = thisMultiplier * denominator2;
        
        var a = numerator1 * otherMultiplier;
        var b = numerator2 * thisMultiplier;
        
        var remainder = a % b;
        
        return GetReducedFraction(remainder, leastCommonMultiple);
    }

    /// <summary>
    /// Adds the fraction's value with <paramref name="summand"/>.
    /// </summary>
    /// <param name="summand">Summand</param>
    /// <returns>The result as summation.</returns>
    public Fraction Add(Fraction summand) {
        var numerator1 = _numerator;
        if (numerator1.IsZero) {  // this is either NaN (NaN + b = NaN) or Zero (0 + b = b)
            return _denominator.IsZero && _state == FractionState.IsNormalized ? this : summand;
        }
        
        var numerator2 = summand._numerator;
        if (numerator2.IsZero) {  // summand is either NaN (a + NaN = NaN) or Zero (a + 0 = a)
            return summand._denominator.IsZero && _state == FractionState.IsNormalized ? summand : this;
        }

        // both fractions are non-zero numbers
        var denominator1 = _denominator;
        var denominator2 = summand._denominator;

        if (denominator1.IsZero) {
            // fraction1 is (+/-) Infinity
            if (!denominator2.IsZero) {
                return this; // Inf + b = Inf
            }
            
            // adding infinities
            return (numerator1.Sign + numerator2.Sign) switch {
                2 => _positiveInfinity,
                -2 => _negativeInfinity,
                _ => _nan
            };
        }

        if (denominator2.IsZero) { 
            return summand; // (+/-) Infinity
        }

        // both values are non-zero: normalizing the signs
        if (_state == FractionState.Unknown && denominator1.Sign == -1) {
            denominator1 = -denominator1;
            numerator1 = -numerator1;
        }
        
        if (summand._state == FractionState.Unknown && denominator2.Sign == -1) {
            denominator2 = -denominator2;
            numerator2 = -numerator2;
        }
        
        if (denominator1 == denominator2) {
            return ReduceSigned(numerator1 + numerator2, denominator1);
        }

        // note: using the GCD here is only useful for very large numbers, however the difference is significant
        var gcd = BigInteger.GreatestCommonDivisor(denominator1, denominator2);
        if(gcd.IsOne) {
            return ReduceSigned(
                numerator1 * denominator2 + numerator2 * denominator1,
                denominator1 * denominator2);
        }

        var thisMultiplier = denominator1 / gcd;
        var otherMultiplier = denominator2 / gcd;
        
        var calculatedNumerator = numerator1 * otherMultiplier + numerator2 * thisMultiplier;
        var leastCommonMultiple = thisMultiplier * denominator2;
        
        return ReduceSigned(calculatedNumerator, leastCommonMultiple);  
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
    public Fraction Negate() => new (-_numerator, _denominator, _state);

    /// <inheritdoc cref="Negate"/>>
    [Obsolete("The 'Invert' method is obsolete. Please use the the 'Negate' method or the negation operator '-value'.", error: false)]
    public Fraction Invert() => Negate();

    /// <summary>
    /// Multiply the fraction's value by <paramref name="factor"/>.
    /// </summary>
    /// <param name="factor">Factor</param>
    /// <returns>The result as product.</returns>
    public Fraction Multiply(Fraction factor) {
        // we want to skip the multiplications if we know the result is going to be 0/b or a/0
        var numerator1 = Numerator;
        var denominator1 = Denominator;
        switch (denominator1.Sign) {
            case 0: return new Fraction(numerator1.Sign * factor._numerator.Sign, BigInteger.Zero, FractionState.IsNormalized);
            case -1: {
                numerator1 = -numerator1;
                denominator1 = -denominator1;
                break;
            }
        }

        var numerator2 = factor.Numerator;
        var denominator2 = factor.Denominator;
        switch (denominator2.Sign) {
            case 0: return new Fraction(numerator1.Sign * numerator2.Sign, BigInteger.Zero, FractionState.IsNormalized);
            case -1: {
                numerator2 = -numerator2;
                denominator2 = -denominator2;
                break;
            }
        }
        
        if (numerator1.IsZero || numerator2.IsZero) {
            return Zero;
        }
        
        return ReduceSigned(
            numerator1 * numerator2,
            denominator1 * denominator2);
    }

    /// <summary>
    /// Divides the fraction's value by <paramref name="divisor"/>.
    /// </summary>
    /// <param name="divisor">Divisor</param>
    /// <returns>The result as quotient.</returns>
    public Fraction Divide(Fraction divisor) {
        // we want to skip the multiplications if we know the result is going to be 0/b or a/0
        var numerator2 = divisor.Numerator;
        var denominator2 = divisor.Denominator;

        if (denominator2.IsZero) { // dividing by NaN or Infinity produces NaN
            return _nan;
        }
        
        var numerator1 = Numerator;
        var denominator1 = Denominator;

        switch (denominator1.Sign) {
            case 0: return numerator1.Sign switch { // +/- Infinity divided by a number
                1 => numerator2.Sign * denominator2.Sign < 0 ? _negativeInfinity : _positiveInfinity,
                -1 => numerator2.Sign * denominator2.Sign < 0 ? _positiveInfinity : _negativeInfinity,
                _ => _nan // NaN divided by a number
            };
            case -1:{
                numerator1 = -numerator1;
                denominator1 = -denominator1;
                break;
            }
        }

        switch (numerator2.Sign) {
            case 0: return new Fraction(numerator1.Sign * denominator2.Sign, BigInteger.Zero, FractionState.IsNormalized);
            case -1: {
                numerator2 = -numerator2;
                denominator2 = -denominator2;
                break;
            }
        }

        if (numerator1.IsZero) {
            return Zero;
        }
        
        return ReduceSigned(
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
            numerator = -numerator;
            denominator = -denominator;
        }

        return ReduceSigned(numerator, denominator);
    }

    /// <summary>
    ///     Returns a fraction by reducing the numerator and denominator by their largest common divisor.
    /// </summary>
    /// <param name="numerator">The signed numerator</param>
    /// <param name="denominator">The denominator should be positive</param>
    /// <returns>A normalized fraction</returns>
    private static Fraction ReduceSigned(BigInteger numerator, BigInteger denominator) {
        var gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);

        return gcd.IsOne ?
            new Fraction(numerator, denominator, FractionState.IsNormalized) :
            new Fraction(numerator / gcd, denominator / gcd, FractionState.IsNormalized);
    }

    /// <summary>
    /// Returns a fraction raised to the specified power.
    /// </summary>
    /// <param name="base">base to be raised to a power</param>
    /// <param name="exponent">A number that specifies a power (exponent)</param>
    /// <returns>The fraction <paramref name="base"/> raised to the power <paramref name="exponent"/>.</returns>
    public static Fraction Pow(Fraction @base, int exponent) {
        // note: if the State is normalized, then it would remain normalized after exponentiation (2*2/3*3),
        // otherwise: it is better to reduce the fraction now (avoiding a larger allocation later on)
        Fraction fraction;
        switch (exponent) {
            case > 0:
                fraction = @base.Reduce();
                break;
            case < 0 when @base.IsZero:
                return PositiveInfinity;
            case < 0:
                exponent = -exponent;
                fraction = @base.Reciprocal().Reduce();
                break;
            default:
                return One;
        }

        return new Fraction(
            BigInteger.Pow(fraction.Numerator, exponent),
            BigInteger.Pow(fraction.Denominator, exponent),
            FractionState.IsNormalized);
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
            ? new Fraction(-fraction.Denominator, -fraction.Numerator, fraction.State)
            : new Fraction(fraction.Denominator, fraction.Numerator, fraction.State);
    }
}
