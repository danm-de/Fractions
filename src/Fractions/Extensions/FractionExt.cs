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
    ///     Calculates the square root of a given Fraction.
    /// </summary>
    /// <param name="x">The Fraction for which to calculate the square root.</param>
    /// <param name="accuracy">The number of significant digits of accuracy for the square root calculation. Default is 30.</param>
    /// <returns>A new Fraction that is the square root of the input Fraction.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the accuracy is less than or equal to zero.</exception>
    /// <remarks>
    ///     The implementation is based on the work by
    ///     <see href="https://github.com/SunsetQuest/NewtonPlus-Fast-BigInteger-and-BigFloat-Square-Root">SunsetQuest</see>.
    ///     <para>
    ///         It uses the Babylonian method of computing square roots, making sure that the relative difference with the true
    ///         value is smaller than 1/10^accuracy.
    ///     </para>
    ///     <para>
    ///         Note: the resulting value is not rounded and may contain additional digits (up to 20%), which have a relatively
    ///         high likelihood of being correct, however no strong guarantees can be made.
    ///     </para>
    /// </remarks>
    public static Fraction Sqrt(this Fraction x, int accuracy = 30) {
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

        if (x.Numerator == x.Denominator) {
            return Fraction.One;
        }

        // BigInteger square root implementation based on https://github.com/SunsetQuest/NewtonPlus-Fast-BigInteger-and-BigFloat-Square-Root
        return sqrtWithPrecision(x.Reduce(), accuracy * 4, x.State == FractionState.IsNormalized);

        static Fraction sqrtWithPrecision(Fraction fraction, int precisionBits, bool reduceTerms) {
            // BigFloatingPoint square root implementation based on https://github.com/SunsetQuest/NewtonPlus-Fast-BigInteger-and-BigFloat-Square-Root/blob/master/BigFloatingPointSquareRoot.cs
            var (numerator, numeratorShift) = sqrtWithShift(fraction.Numerator, precisionBits);
            var (denominator, denominatorShift) = sqrtWithShift(fraction.Denominator, precisionBits);
            var shift = numeratorShift - denominatorShift;
            switch (shift) {
                case < 0:
                    denominator >>= shift;
                    break;
                case > 0:
                    numerator >>= -shift;
                    break;
            }

            return new Fraction(numerator, denominator, reduceTerms);
        }

        static (BigInteger val, int shift) sqrtWithShift(BigInteger x, int precisionBits) {
            if (x.IsOne) {
                return (x, 0);
            }
            
            if (x < 144838757784765629) // 1.448e17 = ~1<<57
            {
                var longX = (ulong)x;
                var vInt = (uint)Math.Sqrt(longX);
                if (vInt * vInt == longX) {
                    return (vInt, 0);
                }
            }
#if NET
            var totalLen = (int)x.GetBitLength();
#else
            var totalLen = (int)BigInteger.Log(x, 2);
#endif
            
            var needToShiftInputBy = 2 * precisionBits - totalLen - (totalLen & 1);
            var val = sqrtBigInt(x << needToShiftInputBy);
            var retShift = (totalLen + (totalLen > 0 ? 1 : 0)) / 2 - precisionBits;
            return (val, retShift);
        }

        static BigInteger sqrtBigInt(BigInteger x) {
            // BigInteger square root implementation based on https://github.com/SunsetQuest/NewtonPlus-Fast-BigInteger-and-BigFloat-Square-Root/blob/master/BigIntegerSquareRoot.cs
            if (x < 144838757784765629) // 1.448e17 = ~1<<57
            {
                var vInt = (uint)Math.Sqrt((ulong)x);
                return vInt;
            }

            var xAsDub = (double)x;
            if (xAsDub < 8.5e37) //   8.5e37 is V<sup>2</sup>long.max * long.max
            {
                var vInt = (ulong)Math.Sqrt(xAsDub);
                BigInteger v = (vInt + (ulong)(x / vInt)) >> 1;
                return v;
            }

            if (xAsDub < 4.3322e127) {
                var v = (BigInteger)Math.Sqrt(xAsDub);
                v = (v + x / v) >> 1;
                if (xAsDub > 2e63) {
                    v = (v + x / v) >> 1;
                }

                return v;
            }

#if NET
            var xLen = (int)x.GetBitLength();
#else
            var xLen = (int)BigInteger.Log(x, 2) + 1;
#endif
            var wantedPrecision = (xLen + 1) / 2;
            var xLenMod = xLen + (xLen & 1) + 1;

            //////// Do the first Sqrt on hardware ////////
            var tempX = (long)(x >> (xLenMod - 63));
            var tempSqrt1 = Math.Sqrt(tempX);
            var valLong = (ulong)BitConverter.DoubleToInt64Bits(tempSqrt1) & 0x1fffffffffffffL;
            if (valLong == 0) {
                valLong = 1UL << 53;
            }

            ////////  Classic Newton Iterations ////////
            var val = ((BigInteger)valLong << 52) + (x >> (xLenMod - 3 * 53)) / valLong;

            val = (val << (106 - 1)) + (x >> (xLenMod - 3 * 106)) / val;
            val = (val << (212 - 1)) + (x >> (xLenMod - 3 * 212)) / val;
            var size = 424;
            
            if (xAsDub > 4e254) // 1 << 845
            {
#if NET
                var numOfNewtonSteps = BitOperations.Log2((uint)(wantedPrecision / size)) + 2;
#else
                var numOfNewtonSteps = (int)Math.Log((uint)(wantedPrecision / size), 2) + 2;
#endif

                //////  Apply Starting Size  ////////
                var startingSize = (wantedPrecision >> numOfNewtonSteps) + 2;
                var needToShiftBy = size - startingSize;
                val >>= needToShiftBy;
                size = startingSize;
                do {
                    ////////  Newton Plus Iterations  ////////
                    var shiftX = xLenMod - 3 * size;
                    var valSqrd = (val * val) << (size - 1);
                    var valSU = (x >> shiftX) - valSqrd;
                    val = (val << size) + valSU / val;
                    size <<= 1;
                } while (size < wantedPrecision);
            }
            
            ////////  Shrink result to wanted Precision  ////////
            val >>= size - wantedPrecision;
            
            return val;
        }
    }
}
