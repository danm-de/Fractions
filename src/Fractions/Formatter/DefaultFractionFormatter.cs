using System;
using System.Globalization;
using System.Numerics;
using System.Text;
using Fractions.Properties;

namespace Fractions.Formatter;

internal class DefaultFractionFormatter : ICustomFormatter {
    public static ICustomFormatter Instance { get; } = new DefaultFractionFormatter();

    public string Format(string format, object arg, IFormatProvider formatProvider) {
        if (arg == null) {
            return string.Empty;
        }

        if (arg is not Fraction fraction) {
            throw new FormatException(string.Format(Resources.TypeXnotSupported, arg.GetType()));
        }

        formatProvider ??= CultureInfo.CurrentCulture;

        if (string.IsNullOrEmpty(format) || format == "G") {
            return FormatGeneral(fraction, formatProvider);
        }

        var sb = new StringBuilder(32);
        foreach (var character in format) {
            switch (character) {
                case 'G':
                    sb.Append(FormatGeneral(fraction, formatProvider));
                    break;
                case 'n':
                    sb.Append(fraction.Numerator.ToString(formatProvider));
                    break;
                case 'd':
                    sb.Append(fraction.Denominator.ToString(formatProvider));
                    break;
                case 'z':
                    sb.Append(FormatInteger(fraction, formatProvider));
                    break;
                case 'r':
                    sb.Append(FormatRemainder(fraction, formatProvider));
                    break;
                case 'm':
                    sb.Append(FormatMixed(fraction, formatProvider));
                    break;
                default:
                    sb.Append(character);
                    break;
            }
        }

        return sb.ToString();
    }

    private static string FormatMixed(Fraction fraction, IFormatProvider formatProvider) {
        var numerator = fraction.Numerator;
        var denominator = fraction.Denominator;
        if (BigInteger.Abs(numerator) < BigInteger.Abs(denominator) || denominator.IsZero) {
            return FormatGeneral(fraction, formatProvider);
        }

        var integer = numerator / denominator;
        var remainder = Fraction.Abs(fraction - integer);

        return remainder.IsZero
            ? integer.ToString(formatProvider)
            : string.Concat(
                integer.ToString(formatProvider),
                " ",
                FormatGeneral(remainder, formatProvider));
    }

    private static string FormatInteger(Fraction fraction, IFormatProvider formatProvider) {
        var numberFormatInfo = (NumberFormatInfo)formatProvider.GetFormat(typeof(NumberFormatInfo))
                               ?? CultureInfo.InvariantCulture.NumberFormat;

        if (fraction.IsNaN) {
            return numberFormatInfo.NaNSymbol;
        }

        if (fraction.IsPositiveInfinity) {
            return numberFormatInfo.PositiveInfinitySymbol;
        }

        if (fraction.IsNegativeInfinity) {
            return numberFormatInfo.NegativeInfinitySymbol;
        }

        return (fraction.Numerator / fraction.Denominator).ToString(formatProvider);
    }

    private static string FormatRemainder(Fraction fraction, IFormatProvider formatProvider) {
        if (fraction.Denominator.IsZero) {
            return string.Empty;
        }

        var isLessThanOne = BigInteger.Abs(fraction.Numerator) < BigInteger.Abs(fraction.Denominator);
        if (isLessThanOne) {
            return FormatGeneral(fraction, formatProvider);
        }

        var integer = fraction.Numerator / fraction.Denominator;
        var remainder = fraction - integer;
        return FormatGeneral(remainder, formatProvider);
    }

    private static string FormatGeneral(Fraction fraction, IFormatProvider formatProvider) {
        var numberFormatInfo = (NumberFormatInfo)formatProvider.GetFormat(typeof(NumberFormatInfo))
                               ?? CultureInfo.InvariantCulture.NumberFormat;

        if (fraction.State == FractionState.IsNormalized) {
            if (fraction.IsNaN) {
                return numberFormatInfo.NaNSymbol;
            }

            if (fraction.IsPositiveInfinity) {
                return numberFormatInfo.PositiveInfinitySymbol;
            }

            if (fraction.IsNegativeInfinity) {
                return numberFormatInfo.NegativeInfinitySymbol;
            }

            if (fraction.Denominator == BigInteger.One) {
                return fraction.Numerator.ToString(formatProvider);
            }
        }

        return string.Concat(
            fraction.Numerator.ToString(formatProvider),
            "/",
            fraction.Denominator.ToString(formatProvider));
    }
}
