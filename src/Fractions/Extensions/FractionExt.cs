using System;
using System.Numerics;
using Fractions.Properties;

// ReSharper disable once CheckNamespace
namespace Fractions;

/// <summary>
/// Extension methods for the <see cref="Fraction"/> data type
/// </summary>
public static class FractionExt {
    /// <summary>
    ///     Returns the square root of <paramref name="x" />.
    ///     Use <paramref name="accuracy" /> to set the accuracy by specifying the number of digits after the decimal point of
    ///     accuracy.
    ///     Higher value of <paramref name="accuracy" /> means better accuracy but longer calculations time.
    /// </summary>
    /// <param name="x">Source value</param>
    /// <param name="accuracy">Number of digits after the decimal point of accuracy</param>
    /// <returns>The square root of the given fraction</returns>
    /// <remarks>
    ///     The resulting fraction will have at least, but likely a lot more, digits than the specified accuracy.
    ///     If the result is used in further arithmetic operations, it is strongly recommended that the fraction is first
    ///     rounded to the specified accuracy.
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="accuracy" /> is less than or equal to zero</exception>
    public static Fraction Sqrt(this Fraction x, int accuracy = 30) {
        //Babylonian Method of computing square roots

        if (accuracy <= 0) {
            throw new ArgumentOutOfRangeException(
                paramName: nameof(accuracy),
                actualValue: accuracy,
                message: string.Format(Resources.AccuracyIsLessThanOrEqualToZero, accuracy));
        }

        if (x.IsNaN || x.IsNegative) {
            return Fraction.NaN;
        }
        
        if (x.Numerator.IsZero || x.Denominator.IsZero) // (x.IsZero || x.IsInfinity)
        {
            return x;
        }

        var tolerance = new Fraction(BigInteger.One, BigInteger.Pow(new BigInteger(10), accuracy));

        //Using Math.Sqrt to get a good starting guess
        var guessDouble = Math.Sqrt((double)x);
        var oldGuess = double.IsInfinity(guessDouble) || double.IsNaN(guessDouble)
            ? x / Fraction.Two
            : (Fraction)guessDouble;

        Fraction newGuess;
        do {
            //Babylonian Method
            newGuess = (oldGuess + (x / oldGuess)) / Fraction.Two;
            oldGuess = newGuess;
        } while ((oldGuess - newGuess).Abs() > tolerance);

        return newGuess;
    }
}
