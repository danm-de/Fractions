using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Numerics;

namespace Fractions {
    public partial struct Fraction
    {
        /// <summary>
        /// Converts a string to a fraction. Example: "3/4" or "4.5" (the decimal separator character is depending on the system culture).
        /// If the number contains a decimal separator it will be parsed as <see cref="decimal"/>.
        /// </summary>
        /// <param name="fraction_string">A fraction or a (decimal) number. The numerator and denominator must be separated with a '/' (slash) character.</param>
        /// <returns>A fraction</returns>
        [Pure]
        public static Fraction FromString(string fraction_string) {
            return FromString(fraction_string, NumberStyles.Number, null);
        }

        /// <summary>
        /// Converts a string to a fraction. Example: "3/4" or "4.5" (the decimal separator character depends on <paramref name="format_provider"/>).
        /// If the number contains a decimal separator it will be parsed as <see cref="decimal"/>.
        /// </summary>
        /// <param name="fraction_string">A fraction or a (decimal) number. The numerator and denominator must be separated with a '/' (slash) character.</param>
        /// <param name="format_provider">Provides culture specific information that will be used to parse the <paramref name="fraction_string"/>.</param>
        /// <returns>Ein Bruch</returns>
        [Pure]
        public static Fraction FromString(string fraction_string, IFormatProvider format_provider) {
            return FromString(fraction_string, NumberStyles.Number, format_provider);
        }

        /// <summary>
        /// Converts a string to a fraction. Example: "3/4" or "4.5" (the decimal separator character depends on <paramref name="format_provider"/>).
        /// If the number contains a decimal separator it will be parsed as <see cref="decimal"/>.
        /// </summary>
        /// <param name="fraction_string">A fraction or a (decimal) number. The numerator and denominator must be separated with a '/' (slash) character.</param>
        /// <param name="number_styles">A bitwise combination of number styles that are allowed in <paramref name="fraction_string"/>.</param>
        /// <param name="format_provider">Provides culture specific information that will be used to parse the <paramref name="fraction_string"/>.</param>
        /// <returns>Ein Bruch</returns>
        [Pure]
        public static Fraction FromString(string fraction_string, NumberStyles number_styles,
            IFormatProvider format_provider) {
            if (fraction_string == null) {
                throw new ArgumentNullException(nameof(fraction_string));
            }

            Fraction fraction;
            if (!TryParse(fraction_string, number_styles, format_provider, out fraction)) {
                throw new FormatException(string.Format(Exceptions.CannotConvertToFraction, fraction_string));
            }

            return fraction;
        }

        /// <summary>
        /// Try to convert a string to a fraction. Example: "3/4" or "4.5" (the decimal separator character depends on the system's culture).
        /// If the number contains a decimal separator it will be parsed as <see cref="decimal"/>.
        /// </summary>
        /// <param name="fraction_string">A fraction or a (decimal) number. The numerator and denominator must be separated with a '/' (slash) character.</param>
        /// <param name="fraction">A <see cref="Fraction"/> if the method returns with <c>true</c>. Otherwise the value is invalid.</param>
        /// <returns>
        /// <para><c>true</c> if <paramref name="fraction_string"/> was well formed. The parsing result will be written to <paramref name="fraction"/>. </para>
        /// <para><c>false</c> if <paramref name="fraction_string"/> was invalid.</para></returns>
        [Pure]
        public static bool TryParse(string fraction_string, out Fraction fraction) {
            return TryParse(fraction_string, NumberStyles.Number, null, out fraction);
        }


        /// <summary>
        /// Try to convert a string to a fraction. Example: "3/4" or "4.5" (the decimal separator character depends on <paramref name="format_provider"/>).
        /// If the number contains a decimal separator it will be parsed as <see cref="decimal"/>.
        /// </summary>
        /// <param name="fraction_string">A fraction or a (decimal) number. The numerator and denominator must be separated with a '/' (slash) character.</param>
        /// <param name="number_styles">A bitwise combination of number styles that are allowed in <paramref name="fraction_string"/>.</param>
        /// <param name="format_provider">Provides culture specific information that will be used to parse the <paramref name="fraction_string"/>.</param>
        /// <param name="fraction">A <see cref="Fraction"/> if the method returns with <c>true</c>. Otherwise the value is invalid.</param>
        /// <returns>
        /// <para><c>true</c> if <paramref name="fraction_string"/> was well formed. The parsing result will be written to <paramref name="fraction"/>. </para>
        /// <para><c>false</c> if <paramref name="fraction_string"/> was invalid.</para>
        /// </returns>
        [Pure]
        public static bool TryParse(string fraction_string, NumberStyles number_styles, IFormatProvider format_provider,
            out Fraction fraction) {
            if (fraction_string == null) {
                return CannotParse(out fraction);
            }

            var components = fraction_string.Split('/');
            if (components.Length == 1) {
                return TryParseSingleNumber(components[0], number_styles, format_provider, out fraction);
            }

            if (components.Length >= 2) {
                var numerator_string = components[0];
                var denominator_string = components[1];

                BigInteger numerator, denominator;
                var without_decimalpoint = number_styles & (~NumberStyles.AllowDecimalPoint);
                if (BigInteger.TryParse(numerator_string, without_decimalpoint, format_provider, out numerator) &&
                    BigInteger.TryParse(denominator_string, without_decimalpoint, format_provider, out denominator)) {

                    fraction = new Fraction(numerator, denominator);
                    return true;
                }
            }

            // Technically it should not be possible to reach this line of code..
            return CannotParse(out fraction);
        }

        /// <summary>
        /// Try to convert a single number to a fraction. Example 34 or 4.5 (depending on the supplied culture used in <paramref name="format_provider"/>)
        /// If the number contains a decimal separator it will be parsed as <see cref="decimal"/>.
        /// </summary>
        /// <param name="number">A (decimal) number</param>
        /// <param name="number_styles">A bitwise combination of number styles that are allowed in <paramref name="number"/>.</param>
        /// <param name="format_provider">Provides culture specific information that will be used to parse the <paramref name="number"/>.</param>
        /// <param name="fraction">A <see cref="Fraction"/> if the method returns with <c>true</c>. Otherwise the value is invalid.</param>
        /// <returns>
        /// <para><c>true</c> if <paramref name="number"/> was well formed. The parsing result will be written to <paramref name="fraction"/>. </para>
        /// <para><c>false</c> if <paramref name="number"/> was invalid.</para>
        /// </returns>
        private static bool TryParseSingleNumber(string number, NumberStyles number_styles,
            IFormatProvider format_provider, out Fraction fraction) {
            var number_format_info = NumberFormatInfo.GetInstance(format_provider);

            if (number.Contains(number_format_info.NumberDecimalSeparator)) {
                decimal decimal_number;
                if (decimal.TryParse(number, number_styles, format_provider, out decimal_number)) {
                    fraction = FromDecimal(decimal_number);
                    return true;
                }
            } else {
                BigInteger numerator;
                var without_decimalpoint = number_styles & (~NumberStyles.AllowDecimalPoint);
                if (BigInteger.TryParse(number, without_decimalpoint, format_provider, out numerator)) {
                    fraction = new Fraction(numerator);
                    return true;
                }
            }
            return CannotParse(out fraction);
        }

        /// <summary>
        /// Returns false. <paramref name="fraction"/> contains an invalid value.
        /// </summary>
        /// <param name="fraction">Returns <c>default()</c> of <see cref="Fraction"/></param>
        /// <returns><c>false</c></returns>
        [Pure]
        private static bool CannotParse(out Fraction fraction) {
            fraction = default(Fraction);
            return false;
        }

        /// <summary>
        /// Converts a floating point value to a fraction. The value will not be rounded therefore you will probably 
        /// get huge numbers as numerator und denominator. <see cref="double"/> values are not able to store simple rational
        /// numbers like 0.2 or 0.3 - so please don't be worried if the fraction looks weird. For more information visit 
        /// http://en.wikipedia.org/wiki/Floating_point
        /// </summary>
        /// <param name="value">A floating point value.</param>
        /// <returns>A fraction</returns>
        /// <exception cref="InvalidNumberException">If <paramref name="value"/> is NaN (not a number) or infinite.</exception>
        [Pure]
        public static Fraction FromDouble(double value) {
            if (double.IsNaN(value) || double.IsInfinity(value)) {
                throw new InvalidNumberException();
            }

            // No rounding here! It will convert the actual number that is stored as double! 
            // See http://www.mpdvc.de/artikel/FloatingPoint.htm

            const ulong SIGN_BIT = 0x8000000000000000;
            const ulong EXPONENT_BITS = 0x7FF0000000000000;
            const ulong MANTISSA = 0x000FFFFFFFFFFFFF;
            const ulong MANTISSA_DIVISOR = 0x0010000000000000;
            const ulong K = 1023;
            var one = BigInteger.One;

            // value = (-1 * sign)   *   (1 + 2^(-1) + 2^(-2) .. + 2^(-52))   *   2^(exponent-K)
            var value_bits = unchecked((ulong)BitConverter.DoubleToInt64Bits(value));

            if (value_bits == 0) {
                // See IEEE 754
                return Zero;
            }

            var is_negative = (value_bits & SIGN_BIT) == SIGN_BIT;
            var mantissa_bits = (value_bits & MANTISSA);

            // (exponent-K)
            var exponent = (int)(((value_bits & EXPONENT_BITS) >> 52) - K);

            // (1 + 2^(-1) + 2^(-2) .. + 2^(-52))
            var mantissa = new Fraction(mantissa_bits + MANTISSA_DIVISOR, MANTISSA_DIVISOR);

            // 2^exponent
            var factor = (exponent < 0)
                ? new Fraction(one, one << Math.Abs(exponent))
                : new Fraction(one << exponent);

            var result = mantissa * factor;

            return (is_negative)
                ? result.Invert()
                : result;
        }

        /// <summary>
        /// Converts a floating point value to a fraction. The value will be rounded if possible.
        /// </summary>
        /// <param name="value">A floating point value.</param>
        /// <returns>A fraction</returns>
        /// <exception cref="InvalidNumberException">If <paramref name="value"/> is NaN (not a number) or infinite.</exception>
        [Pure]
        public static Fraction FromDoubleRounded(double value) {
            if (double.IsNaN(value) || double.IsInfinity(value)) {
                throw new InvalidNumberException();
            }

            // Null?
            if (Math.Abs(value - 0.0) < double.Epsilon) {
                return Zero;
            }

            // Inspired from Syed Mehroz Alam <smehrozalam@yahoo.com> http://www.geocities.ws/smehrozalam/source/fractioncs.txt
            // .. who got it from http://ebookbrowse.com/confrac-pdf-d13212190 
            // or ftp://89.25.159.69/knm/ksiazki/reszta/homepage.smc.edu.kennedy_john/CONFRAC.pdf
            var sign = Math.Sign(value);
            var absolute_value = Math.Abs(value);

            var numerator = new BigInteger(absolute_value);
            var denominator = 1.0;
            var remaining_digits = absolute_value;
            var previous_denominator = 0.0;
            var break_counter = 0;

            while (MathMethods.RemainingDigitsAfterTheDecimalPoint(remaining_digits)
                && Math.Abs(absolute_value - ((double)numerator / denominator)) > double.Epsilon) {

                remaining_digits = 1.0 / (remaining_digits - Math.Floor(remaining_digits));

                var tmp = denominator;

                denominator = (Math.Floor(remaining_digits) * denominator) + previous_denominator;
                numerator = new BigInteger(absolute_value * denominator + 0.5);

                previous_denominator = tmp;

                // See http://www.ozgrid.com/forum/archive/index.php/t-22530.html
                if (++break_counter > 594) {
                    break;
                }
            }

            return new Fraction(
                (sign < 0) ? BigInteger.Negate(numerator) : numerator,
                new BigInteger(denominator),
                true);
        }

        /// <summary>
        /// Converts a decimal value in a fraction. The value will not be rounded.
        /// </summary>
        /// <param name="value">A decimal value.</param>
        /// <returns>A fraction.</returns>
        [Pure]
        public static Fraction FromDecimal(decimal value) {
            if (value == decimal.Zero) {
                return _zero;
            }

            if (value == decimal.One) {
                return _one;
            }

            if (value == decimal.MinusOne) {
                return _minus_one;
            }

            var bits = decimal.GetBits(value);
            var low = BitConverter.GetBytes(bits[0]);
            var middle = BitConverter.GetBytes(bits[1]);
            var high = BitConverter.GetBytes(bits[2]);
            var scale = BitConverter.GetBytes(bits[3]);


            var exp = scale[2];
            bool positive_sign = (scale[3] & 0x80) == 0;

            // value = 0x00,high,middle,low / 10^exp
            var numerator = new BigInteger(new byte[] {
                low[0], low[1], low[2], low[3],
                middle[0], middle[1], middle[2], middle[3],
                high[0], high[1], high[2], high[3],
                0x00
            });
            var denominator = BigInteger.Pow(10, exp);

            return positive_sign
                ? new Fraction(numerator, denominator, true)
                : new Fraction(BigInteger.Negate(numerator), denominator, true);
        }
    }
}