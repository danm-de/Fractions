using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace Fractions {
    public static class FractionExtensions
    {

        /// <summary>
        /// Returns the square root of a fraction.
        /// </summary>
        public static Fraction Sqrt(this Fraction x) {
            //Babylonian Method of computing square roots

            if (x < 0) {
                throw new OverflowException("Cannot calculate square root from a negative number");
            }


            Fraction oldGuess;
            var newGuess = Fraction.Zero;
            var tolerance = new Fraction(BigInteger.One, new BigInteger(79000000000000000000000000000m));


            //Using Math.Sqrt to get a good starting guess
            var guessDouble = Math.Sqrt((double)x);
            if (double.IsInfinity(guessDouble)) {
                oldGuess = x / 2;
            } else {
                oldGuess = (Fraction)guessDouble;
            }


            while ((oldGuess - newGuess).Abs() > tolerance) {
                //Babylonian Method
                newGuess = (oldGuess + (x / oldGuess)) / 2;
                oldGuess = newGuess;
            }

            return newGuess;
        }






    }
}
