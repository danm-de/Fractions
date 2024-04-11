using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Fractions;

/// <summary>
/// Extension methods for the <see cref="Fraction"/> data type
/// </summary>
public static class FractionExt {

    /// <summary>
    /// Returns the square root of <paramref name="x"/>.
    /// Use <paramref name="accuracy"/> to set the accuracy by specifying the number of digits after the decimal point of accuracy.
    /// Higher value of <paramref name="accuracy"/> means better accuracy but longer calculations time.
    /// </summary>
    /// <param name="x">Source value</param>
    /// <param name="accuracy">Number of digits after the decimal point of accuracy</param>
    public static Fraction Sqrt(this Fraction x, int accuracy = 30) {
        //Babylonian Method of computing square roots

        if (x < Fraction.Zero) {
            throw new OverflowException("Cannot calculate square root from a negative number");
        }

        if (accuracy <= 0) {
            throw new ArgumentOutOfRangeException(nameof(accuracy), accuracy, $"Accuracy of {accuracy} is not allowed! Have to be above 0.");
        }

        var newGuess = Fraction.Zero;
        var tolerance = new Fraction(BigInteger.One, BigInteger.Pow(new BigInteger(10), accuracy));

        //Using Math.Sqrt to get a good starting guess
        var guessDouble = Math.Sqrt((double)x);
        var oldGuess = double.IsInfinity(guessDouble)
            ? x / Fraction.Two
            : (Fraction)guessDouble;

        while ((oldGuess - newGuess).Abs() > tolerance) {
            //Babylonian Method
            newGuess = (oldGuess + (x / oldGuess)) / Fraction.Two;
            oldGuess = newGuess;
        }

        return newGuess;
    }

    /// <summary>
    ///     Raises a fraction to the power of another fraction.
    /// </summary>
    /// <param name="x">The base fraction.</param>
    /// <param name="power">The exponent fraction.</param>
    /// <param name="minAccuracy">The minimum accuracy for the result.</param>
    /// <returns>The result of raising the base fraction to the power of the exponent fraction.</returns>
    public static Fraction Pow(this Fraction x, Fraction power, Fraction minAccuracy)
    {
        var numeratorRaised = Fraction.Pow(x, (int)power.Numerator);
        return numeratorRaised.Root((int)power.Denominator, minAccuracy);
    }

    /// <summary>
    ///     Calculates the nth root of the given fraction with a specified minimum accuracy.
    /// </summary>
    /// <param name="number">The fraction for which to calculate the nth root.</param>
    /// <param name="n">The root to calculate. For example, if n is 2, the method calculates the square root.</param>
    /// <param name="minAccuracy">
    ///     The minimum accuracy of the result. The method continues to calculate the root until the
    ///     difference between two successive approximations is less than this value.
    /// </param>
    /// <returns>The nth root of the fraction, calculated to the specified minimum accuracy.</returns>
    public static Fraction Root(this Fraction number, int n, Fraction minAccuracy) {
        //Babylonian Method of computing the nth-square root

        if (number < Fraction.Zero) {
            throw new OverflowException("Cannot calculate square root from a negative number");
        }

        if (minAccuracy <= 0) {
            throw new ArgumentOutOfRangeException(nameof(minAccuracy), minAccuracy, $"Accuracy of {minAccuracy} is not allowed! Have to be above 0.");
        }

        var initialGuess = Math.Pow(number.ToDouble(), 1.0 / n);
        var x = initialGuess == 0.0 ? number : Fraction.FromDoubleRounded(initialGuess);
        Fraction xPrev;
        do {
            xPrev = x;
            x = ((n - 1) * x + number / Fraction.Pow(x, n - 1)) / n;
        } while ((x - xPrev).Abs() > minAccuracy);

        return x;
    }
}
