using System;
using System.Numerics;
using Fractions.Properties;

namespace Fractions;

public readonly partial struct Fraction {
    /// <summary>
    ///     Compares the calculated value with the supplied <paramref name="other" />.
    /// </summary>
    /// <param name="other">Fraction that shall be compared with.</param>
    /// <returns>
    ///     Less than 0 if <paramref name="other" /> is greater.
    ///     Zero (0) if both calculated values are equal.
    ///     Greater than zero (0) if <paramref name="other" /> less.
    /// </returns>
    /// <exception cref="ArgumentException">If <paramref name="other" /> is not of type <see cref="Fraction" />.</exception>
    public int CompareTo(object other) {
        if (other == null) {
            return 1;
        }

        if (other.GetType() != typeof(Fraction)) {
            throw new ArgumentException(
                string.Format(Resources.CompareToArgumentException, GetType(), other.GetType()), nameof(other));
        }

        return CompareTo((Fraction)other);
    }

    /// <summary>
    ///     Compares the calculated value with the supplied <paramref name="other" />.
    /// </summary>
    /// <param name="other">Fraction that shall be compared with.</param>
    /// <returns>
    ///     1 if <paramref name="other" /> is greater.
    ///     0 if both calculated values are equal.
    ///     -1 if <paramref name="other" /> less.
    /// </returns>
    /// <remarks>Comparing with <see cref="NaN" /> as the first argument always returns -1</remarks>
    public int CompareTo(Fraction other) {
        var numerator1 = Numerator;
        var denominator1 = Denominator;
        var numerator2 = other.Numerator;
        var denominator2 = other.Denominator;
        
        // normalize signs
        if (denominator1.Sign == -1) {
            numerator1 = -numerator1;
            denominator1 = -denominator1;
        }

        if (denominator2.Sign == -1) {
            numerator2 = -numerator2;
            denominator2 = -denominator2;
        }

        if (denominator1 == denominator2) {
            if (!denominator1.IsZero) {
                return numerator1.CompareTo(numerator2); // finite numbers: {-1/2} < {1/2}
            }

            if (numerator1.IsZero) {
                return numerator2.IsZero ? 0 : -1; // NaN and anything else
            }

            if (numerator2.IsZero) {
                return 1; // other is NaN
            }

            // comparing infinities
            return numerator1.Sign.CompareTo(numerator2.Sign);
        }

        if (denominator1.IsZero) {
            return numerator1.Sign switch {
                1 => 1, // PositiveInfinity -> 1
                _ => -1 // NaN or NegativeInfinity -> -1
            };
        }

        if (denominator2.IsZero) {
            return numerator2.Sign switch {
                1 => -1, // PositiveInfinity -> -1
                _ => 1 // NaN or NegativeInfinity -> 1
            };
        }

        var firstNumeratorSign = numerator1.Sign;
        var secondNumeratorSign = numerator2.Sign;

        if (firstNumeratorSign != secondNumeratorSign) {
            return firstNumeratorSign.CompareTo(secondNumeratorSign);
        }

        // both values are non-zero fractions with different denominators
        if (denominator1 < denominator2) {
            // reverse the comparison from x.CompareTo(y) to y.CompareTo(x)
            return firstNumeratorSign == 1
                ? -comparePositiveTerms(numerator2, denominator2, numerator1, denominator1)
                : -compareNegativeTerms(numerator2, denominator2, numerator1, denominator1);
        }

        return firstNumeratorSign == 1
            ? comparePositiveTerms(numerator1, denominator1, numerator2, denominator2)
            : compareNegativeTerms(numerator1, denominator1, numerator2, denominator2);

        static int comparePositiveTerms(BigInteger numerator1, BigInteger denominator1, BigInteger numerator2, BigInteger denominator2) {
            // From here [denominator1 > denominator2 > 0] applies

            // example: {10/10} and {1/1} or {10/100} and {1/10}
            if (numerator1 <= numerator2) {
                return -1; // expecting: 0 < numerator2 < numerator1
            }

            if (numerator2.IsOne) {
                if (denominator2.IsOne) {
                    // {n1/d1}.CompareTo({1/1})
                    return numerator1.CompareTo(denominator1);
                }

                // {n1/d1}.CompareTo({1/d2}) => {(n1*d2)/d1}.CompareTo(1) => (n1*d2).CompareTo(d1)
                return (numerator1 * denominator2).CompareTo(denominator1);
            }

            if (denominator2.IsOne) {
                // {n1/d1}.CompareTo({n2/1}) => (n1).CompareTo((n2*d1))
                return numerator1.CompareTo(numerator2 * denominator1);
            }

            /* Comparing the positive term ratios:
             * {9/7} / {4/3} = {(1 + 2/7) / (1 + 1/3)} = {27/28}
             *               => ((1).CompareTo(1)) == 0 and ((2/7).CompareTo(1/3)) == -1
             * Given that:
             * {a/b} / {c/d} = {a/b} * {d/c} = {(a*d)/(c*b)} = {a/c} * {d/b} = {a/c} / {b/d}
             * we can also write:
             * {9/4} / {7/3} = {(2 + 1/4) / (2 + 1/3)} = {27/28}
             *               => ((2).CompareTo(2)) == 0 and ((1/4).CompareTo(1/3)) == -1
             */

            var denominatorQuotient = BigInteger.DivRem(denominator1, denominator2, out var remainderDenominators);
            if (remainderDenominators.IsZero) {
                /* Example:
                 * {7/4} / {3/2}         =
                 * {7/3} / {4/2}         =
                 * {(2 + 1/3) / (2 + 0)} =
                 * {7/3} / 2             = {7/6}
                 *                       => (7).CompareTo(3*2) == 1
                 */
                return numerator1.CompareTo(numerator2 * denominatorQuotient);
            }

            var numeratorQuotient = BigInteger.DivRem(numerator1, numerator2, out var remainderNumerators);
            // if the fractions are equal: numeratorQuotient should be equal to denominatorQuotient
            var quotientComparison = numeratorQuotient.CompareTo(denominatorQuotient);
            if (quotientComparison != 0) {
                return quotientComparison;
            }

            // if the fractions are equal: {remainderNumerators / numerator2} should be equal to {remainderDenominators / denominator2}
            if (remainderNumerators.IsZero) {
                /* Example:
                 * {6/5} / {3/2}   =
                 * {6/3} / {5/2}   =
                 * {2 / (2 + 1/2)} =
                 * {2 / (3/2)}     = {4/3}
                 */
                return -1; // when both values are 0 the fractions are equal
            }

            return (remainderNumerators * denominator2).CompareTo(remainderDenominators * numerator2);
        }

        static int compareNegativeTerms(BigInteger numerator1, BigInteger denominator1, BigInteger numerator2, BigInteger denominator2) {
            // From here [denominator1 > denominator2 > 0] applies

            // example: {-10/10} and {-1/1} or {-10/100} and {-1/10}
            if (numerator1 >= numerator2) {
                return 1; // expecting: numerator1 < numerator2 < 0
            }

            if (numerator2 == BigInteger.MinusOne) {
                return denominator2.IsOne ? numerator1.CompareTo(-denominator1) : denominator1.CompareTo(numerator1 * -denominator2);
            }

            if (denominator2.IsOne) {
                return numerator1.CompareTo(numerator2 * denominator1);
            }

            /* Comparing the negative term ratios, example:
             * {-9/7} / {-4/3} = {(-1 + -2/7) / (-1 + -1/3)} = {27/28}
             *                 => ((-1).CompareTo(-1)) == 0 and ((-2/7).CompareTo(-1/3)) == 1
             * Given that:
             * {a/b} / {c/d} = {a/b} * {d/c} = {(a*d)/(c*b)} = {a/c} * {d/b} = {a/c} / {b/d}
             * we can also write:
             * {-9/4} / {-7/3} = {(-2 + -1/4) / (-2 - 1/3)} = {27/28}
             *                 => ((-2).CompareTo(-2)) == 0 and ((-1/4).CompareTo(-1/3)) == 1
             */
            var denominatorQuotient = BigInteger.DivRem(denominator1, denominator2, out var remainderDenominators);
            if (remainderDenominators.IsZero) {
                // {-7/4} / {-3/2} = {(2 + 1/3) / 2} = {(7/3)/2} = {7/6}
                return numerator1.CompareTo(numerator2 * denominatorQuotient);
            }

            var numeratorQuotient = BigInteger.DivRem(numerator1, numerator2, out var remainderNumerators);
            // if the fractions are equal: numeratorQuotient should be equal to denominatorQuotient
            var quotientComparison = numeratorQuotient.CompareTo(denominatorQuotient);
            if (quotientComparison != 0) {
                return -quotientComparison;
            }

            // if the fractions are equal: {remainderNumerators / numerator2} should be equal to {remainderDenominators / denominator2}
            if (remainderNumerators.IsZero) {
                return 1; // when both values are 0 the fractions are equal
            }

            return (remainderNumerators * denominator2).CompareTo(remainderDenominators * numerator2);
        }
    }
}
