using System;
using System.Globalization;
using System.Numerics;
using System.Text;
using Fractions.Properties;

namespace Fractions.Formatter;

internal class DefaultFractionFormatter : ICustomFormatter {
    public static readonly ICustomFormatter Instance = new DefaultFractionFormatter();

    public string Format(string format, object arg, IFormatProvider formatProvider) {
        if (arg == null) {
            return string.Empty;
        }

        if (arg is not Fraction fraction) {
            throw new FormatException(string.Format(Resources.TypeXnotSupported, arg.GetType()));
        }

        if (string.IsNullOrEmpty(format) || format == "G") {
            return FormatGeneral(fraction);
        }

        var sb = new StringBuilder(32);
        foreach (var character in format) {
            switch (character) {
                case 'G':
                    sb.Append(FormatGeneral(fraction));
                    break;
                case 'n':
                    sb.Append(fraction.Numerator.ToString(CultureInfo.InvariantCulture));
                    break;
                case 'd':
                    sb.Append(fraction.Denominator.ToString(CultureInfo.InvariantCulture));
                    break;
                case 'z':
                    sb.Append(FormatInteger(fraction));
                    break;
                case 'r':
                    sb.Append(FormatRemainder(fraction));
                    break;
                case 'm':
                    sb.Append(FormatMixed(fraction));
                    break;
                default:
                    sb.Append(character);
                    break;
            }
        }

        return sb.ToString();
    }

    private static string FormatMixed(Fraction fraction) {
        var numerator = fraction.Numerator;
        var denominator = fraction.Denominator;
        if (BigInteger.Abs(numerator) < BigInteger.Abs(denominator) || denominator.IsZero) {
            return FormatGeneral(fraction);
        }

        var integer = numerator / denominator;
        var remainder = Fraction.Abs(fraction - integer);

        return remainder.IsZero
            ? integer.ToString(CultureInfo.InvariantCulture)
            : string.Concat(
                integer.ToString(CultureInfo.InvariantCulture),
                " ",
                FormatGeneral(remainder));
    }

    private static string FormatInteger(Fraction fraction) {
        // TODO check this (possible division by zero for NaN/Infinity):
        return (fraction.Numerator / fraction.Denominator).ToString(CultureInfo.InvariantCulture);
    }

    private static string FormatRemainder(Fraction fraction) {
        if (BigInteger.Abs(fraction.Numerator) < BigInteger.Abs(fraction.Denominator) || fraction.Denominator.IsZero) {
            return FormatGeneral(fraction);
        }

        var integer = fraction.Numerator / fraction.Denominator;
        var remainder = fraction - integer;
        return FormatGeneral(remainder);
    }

    private static string FormatGeneral(Fraction fraction) {
        if (fraction.State == FractionState.IsNormalized && fraction.Denominator == BigInteger.One) {
            return fraction.Numerator.ToString(CultureInfo.InvariantCulture);
        }

        return string.Concat(
            fraction.Numerator.ToString(CultureInfo.InvariantCulture),
            "/",
            fraction.Denominator.ToString(CultureInfo.InvariantCulture));
    }
}
