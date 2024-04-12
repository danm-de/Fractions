﻿#nullable enable
using System;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace Fractions.Formatter;

/// <summary>
///     Provides functionality to format the value of a Fraction object into a decimal string representation following the
///     standard numeric formats, as implemented by the double type.
/// </summary>
/// <remarks>
///     This class implements the <see cref="ICustomFormatter" /> interface and provides custom formatting for objects of
///     type <see cref="Fraction" />.
///     It supports a variety of format specifiers, including general, fixed-point, standard numeric, scientific, and
///     significant digits after radix formats.
/// </remarks>
/// <example>
///     Here is an example of how to use the `DecimalFractionFormatter`:
///     <code>
/// Fraction fraction = new Fraction(1, 2);
/// ICustomFormatter formatter = DecimalFractionFormatter.Instance;
/// string formatted = formatter.Format("f", fraction, null);
/// Console.WriteLine(formatted);  // Outputs: "0.50"
/// </code>
/// </example>
/// <seealso cref="ICustomFormatter" />
/// <seealso cref="Fraction" />
public class DecimalFractionFormatter : ICustomFormatter {
    /// <summary>
    ///     <list type="bullet">
    ///         <item>
    ///             On .NET Framework and .NET Core up to .NET Core 2.0, the runtime selects the result with the greater least
    ///             significant digit (that is, using <see cref="MidpointRounding.AwayFromZero" />).
    ///         </item>
    ///         <item>
    ///             On .NET Core 2.1 and later, the runtime selects the result with an even least significant digit (that is,
    ///             using  <see cref="MidpointRounding.ToEven" />).
    ///         </item>
    ///     </list>
    /// </summary>
    private const MidpointRounding DefaultMidpointRoundingMode =
#if NETCOREAPP2_1_OR_GREATER
        MidpointRounding.ToEven;
#else
        MidpointRounding.AwayFromZero;
#endif
    
    /// <summary>
    ///     Gets the singleton instance of the DecimalFractionFormatter class.
    /// </summary>
    /// <value>
    ///     The singleton instance of the DecimalFractionFormatter class.
    /// </value>
    /// <remarks>
    ///     This instance can be used to format Fraction objects into decimal string representations.
    /// </remarks>
    public static readonly ICustomFormatter Instance = new DecimalFractionFormatter();

    private static readonly BigInteger Ten = new(10);

    /// <summary>
    ///     Formats the value of the specified Fraction object as a string according to the provided format and
    ///     culture-specific format information.
    /// </summary>
    /// <param name="format">
    ///     A format string containing formatting specifications. If this is null or an empty string, the
    ///     general format specifier ('G') is used.
    /// </param>
    /// <param name="arg">The Fraction object to format.</param>
    /// <param name="formatProvider">
    ///     An object that supplies culture-specific formatting information. If this is null, the
    ///     current culture is used.
    /// </param>
    /// <returns>A string representation of the Fraction object as specified by format and formatProvider.</returns>
    /// <exception cref="FormatException">Thrown when arg is not a Fraction object.</exception>
    /// <remarks>
    ///     <list type="bullet">
    ///         <item>
    ///             The general ("G") format specifier converts a number to a string that is formatted as the most compact of
    ///             either fixed-point or scientific notation.
    ///         </item>
    ///         <item>
    ///             The scientific ("E") format specifier converts a number to a string of the form "-d.ddd…E+ddd" or
    ///             "-d.ddd…e+ddd", where each "d" indicates a digit (0-9). The string starts with a minus sign if the
    ///             number is negative.
    ///         </item>
    ///         <item>
    ///             The fixed-point ("F") format specifier converts a number to a string of the form "-ddd.ddd…" where each
    ///             "d"
    ///             indicates a digit (0-9). The string starts with a minus sign if the number is negative.
    ///         </item>
    ///         <item>
    ///             The standard numeric ("N") format specifier converts a number to a string of the form "-d,ddd,ddd.ddd…",
    ///             where "-" indicates a negative number symbol, "," indicates a group separator, and "d" indicates a digit
    ///             (0-9). The string starts with a minus sign if the number is negative.
    ///         </item>
    ///         <item>
    ///             The percent ("P") format specifier multiplies the number by 100 and converts it to a string that represents
    ///             a percentage.
    ///         </item>
    ///         <item>
    ///             The currency ("C") format specifier converts a number to a string that represents a currency amount.
    ///         </item>
    ///         <item>
    ///             The R format specifier... TODO?
    ///         </item>
    ///         <item>
    ///             The significant digits after radix ("S") format specifier converts a number to a string that preserves the
    ///             precision of the Fraction object with a variable number of digits after the radix point.
    ///         </item>
    ///     </list>
    /// </remarks>
    public string Format(string? format, object? arg, IFormatProvider? formatProvider) {
        if (arg is null) {
            return string.Empty;
        }

        if (arg is not Fraction fraction) {
            throw new FormatException(string.Format(Properties.Resources.TypeXnotSupported, arg.GetType()));
        }

        formatProvider ??= CultureInfo.CurrentCulture;
        var numberFormatInfo = (NumberFormatInfo)formatProvider.GetFormat(typeof(NumberFormatInfo))!;

        // any handling of the edge cases corresponding to numberFormatInfo.(NaNSymbol|PositiveInfinitySymbol|NegativeInfinitySymbol)
        // should happen here...

        if (format is null or "") {
            return FormatGeneral(fraction, "g", numberFormatInfo);
        }

        var formatCharacter = format[0];
        return formatCharacter switch {
            'g' or 'G' => FormatGeneral(fraction, format, numberFormatInfo),
            'f' or 'F' => FormatWithFixedPointFormat(fraction, format, numberFormatInfo),
            'n' or 'N' => FormatWithStandardNumericFormat(fraction, format, numberFormatInfo),
            'e' or 'E' => FormatWithScientificFormat(fraction, format, numberFormatInfo),
            'r' or 'R' => FormatGeneral(fraction, "G32", numberFormatInfo), // TODO see about replacing this with the "1/3" format
            // 'p' or 'P'  => fraction.ToDouble().ToString(format, formatProvider), // TODO see about implementing this 
            // 'c' or 'C'  => fraction.ToDouble().ToString(format, formatProvider), // TODO see about implementing this 
            's' or 'S' => FormatWithSignificantDigitsAfterRadix(fraction, format, numberFormatInfo),
            _ => fraction.ToDouble()
                .ToString(format, formatProvider) // (not implemented|custom formats) handed over to the double (possible loss of precision) 
        };
    }

    private static int GetPrecisionDigitsOrDefault(string format, int defaultValue) {
        return format.Length > 1 ? GetPrecisionDigits(format) : defaultValue;
    }

    private static int GetPrecisionDigits(string format) {
        if (!int.TryParse(format.Substring(1), out var nbDecimals) || nbDecimals < 0) {
            throw new FormatException($"The {format} format string is not supported.");
        }

        return nbDecimals;
    }

    /// <summary>
    ///     Handles the standard decimal formats "Fx"
    ///     <list type="bullet">
    ///         <item>
    ///             The fixed-point ("F") format specifier converts a number to a string of the form "-ddd.ddd…" where each "d"
    ///             indicates a digit (0-9). The string starts with a minus sign if the number is negative.
    ///         </item>
    ///     </list>
    /// </summary>
    /// <remarks>
    ///     The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted, the
    ///     current NumberFormatInfo.NumberDecimalDigits property supplies the numeric precision.
    /// </remarks>
    private static string FormatWithFixedPointFormat(Fraction fraction, string format, NumberFormatInfo formatProvider) {
        if (fraction.Numerator == BigInteger.Zero) {
            return 0d.ToString(format, formatProvider);
        }

        if (fraction.Denominator.IsOne) {
            return fraction.Numerator.ToString(format, formatProvider)!;
        }

        var maxNbDecimalsAfterRadix = GetPrecisionDigitsOrDefault(format, formatProvider.NumberDecimalDigits);

        var sb = new StringBuilder(12 + maxNbDecimalsAfterRadix);

#if NETCOREAPP2_1_OR_GREATER
        if (fraction.IsNegative)
        {
            sb.Append(formatProvider.NegativeSign);
            fraction = fraction.Abs();
        }
        
        if (maxNbDecimalsAfterRadix == 0)
        {
            return sb.Append(Round(fraction.Numerator, fraction.Denominator).ToString(format, formatProvider)).ToString();
        }

        var roundedFraction = Round(fraction, maxNbDecimalsAfterRadix);
        if (roundedFraction.Numerator.IsZero || roundedFraction.Denominator.IsOne)
        {
            return sb.Append(roundedFraction.Numerator.ToString(format, formatProvider)!).ToString();
        }
        
        return AppendDecimals(sb, roundedFraction, formatProvider, maxNbDecimalsAfterRadix).ToString();
#else
        // On .NET Framework and .NET Core up to .NET Core 2.0 the string format does not append the '-' sign when a value is rounded to 0.
        if (maxNbDecimalsAfterRadix == 0) {
            return sb.Append(Round(fraction.Numerator, fraction.Denominator).ToString(format, formatProvider)!).ToString();
        }

        var roundedFraction = Round(fraction, maxNbDecimalsAfterRadix);
        if (roundedFraction.IsNegative) {
            sb.Append(formatProvider.NegativeSign);
            roundedFraction = roundedFraction.Abs();
        }

        if (roundedFraction.Numerator.IsZero || roundedFraction.Denominator.IsOne) {
            return sb.Append(roundedFraction.Numerator.ToString(format, formatProvider)!).ToString();
        }

        return AppendDecimals(sb, roundedFraction, formatProvider, maxNbDecimalsAfterRadix).ToString();
#endif
    }

    /// <summary>
    ///     Handles the standard decimal formats: "Fx" and "Nx"
    ///     <list type="bullet">
    ///         <item>
    ///             The fixed-point ("F") format specifier converts a number to a string of the form "-ddd.ddd…" where each "d"
    ///             indicates a digit (0-9). The string starts with a minus sign if the number is negative.
    ///         </item>
    ///         <item>
    ///             The numeric ("N") format specifier converts a number to a string of the form "-d,ddd,ddd.ddd…", where "-"
    ///             indicates
    ///             a negative number symbol if required, "d" indicates a digit (0-9), "," indicates a group separator, and "."
    ///             indicates a decimal point symbol.
    ///         </item>
    ///     </list>
    /// </summary>
    /// <remarks>
    ///     The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted, the
    ///     current NumberFormatInfo.NumberDecimalDigits property supplies the numeric precision.
    /// </remarks>
    private static string FormatWithStandardNumericFormat(Fraction fraction, string format, NumberFormatInfo formatProvider) {
        if (formatProvider.NumberNegativePattern != 1 && formatProvider.NumberNegativePattern != 2) {
            // TODO see about implementing the other patterns if necessary
            // https://learn.microsoft.com/en-us/dotnet/api/system.globalization.numberformatinfo.numbernegativepattern?view=netframework-4.8
            throw new NotSupportedException($"The selected NumberNegativePattern currently not supported by the {nameof(DecimalFractionFormatter)}.");
        }

        if (fraction.Numerator == BigInteger.Zero) {
            return 0d.ToString(format, formatProvider);
        }

        if (fraction.Denominator.IsOne) {
            return fraction.Numerator.ToString(format, formatProvider)!;
        }

        var maxNbDecimals = GetPrecisionDigitsOrDefault(format, formatProvider.NumberDecimalDigits);

        var sb = new StringBuilder(3 + maxNbDecimals);

#if NETCOREAPP2_1_OR_GREATER
        if (fraction.IsNegative)
        {
            sb.Append(formatProvider.NegativeSign);
            if (formatProvider.NumberNegativePattern == 2)
            {
                sb.Append(' ');
            }

            fraction = fraction.Abs();
        }

        if (maxNbDecimals == 0)
        {
            return sb.Append(Round(fraction.Numerator, fraction.Denominator).ToString(format, formatProvider)!).ToString();
        }

        var roundedFraction = Round(fraction, maxNbDecimals);
        if (roundedFraction.Numerator.IsZero || roundedFraction.Denominator.IsOne)
        {
            return sb.Append(roundedFraction.Numerator.ToString(format, formatProvider)!).ToString();
        }

        return AppendDecimals(sb, roundedFraction, formatProvider, maxNbDecimals, "N0").ToString();
#else
        // On .NET Framework and .NET Core up to .NET Core 2.0 the string format does not append the '-' sign when a value is rounded to 0.
        if (maxNbDecimals == 0) {
            return sb.Append(Round(fraction.Numerator, fraction.Denominator).ToString(format, formatProvider)!).ToString();
        }

        var roundedFraction = Round(fraction, maxNbDecimals);
        if (roundedFraction.IsNegative) {
            sb.Append(formatProvider.NegativeSign);
            if (formatProvider.NumberNegativePattern == 2) {
                sb.Append(' ');
            }

            roundedFraction = roundedFraction.Abs();
        }

        if (roundedFraction.Numerator.IsZero || roundedFraction.Denominator.IsOne) {
            return sb.Append(roundedFraction.Numerator.ToString(format, formatProvider)!).ToString();
        }

        return AppendDecimals(sb, roundedFraction, formatProvider, maxNbDecimals, "N0").ToString();
#endif
    }

    /// <summary>
    ///     Exponential format specifier (E)
    ///     The exponential ("E") format specifier converts a number to a string of the form "-d.ddd…E+ddd" or "-d.ddd…e+ddd",
    ///     where each "d" indicates a digit (0-9). The string starts with a minus sign if the number is negative. Exactly one
    ///     digit always precedes the decimal point.
    ///     The precision specifier indicates the desired number of digits after the decimal point. If the precision specifier
    ///     is omitted, a default of six digits after the decimal point is used.
    ///     The case of the format specifier indicates whether to prefix the exponent with an "E" or an "e". The exponent
    ///     always consists of a plus or minus sign and a minimum of three digits. The exponent is padded with zeros to meet
    ///     this minimum, if required.
    /// </summary>
    private static string FormatWithScientificFormat(Fraction fraction, string format, NumberFormatInfo formatProvider) {
        if (fraction.Numerator == BigInteger.Zero) {
            return 0d.ToString(format, formatProvider);
        }

        if (fraction.Denominator.IsOne) {
            return fraction.Numerator.ToString(format, formatProvider)!;
        }

        var maxNbDecimals = GetPrecisionDigitsOrDefault(format, 6);
        var sb = new StringBuilder(6 + maxNbDecimals);

        if (fraction.IsNegative) {
            sb.Append(formatProvider.NegativeSign);
            fraction = fraction.Abs();
        }

        var exponent = GetExponentPower(fraction, out var exponentTerm);
        var mantissa = exponent switch {
            0 => Round(fraction, maxNbDecimals),
            > 0 => Round(fraction / exponentTerm, maxNbDecimals),
            _ => Round(fraction * exponentTerm, maxNbDecimals)
        };

        if (mantissa.Denominator.IsOne) {
            sb.Append(mantissa.Numerator.ToString($"F{maxNbDecimals}", formatProvider));
        } else {
            AppendDecimals(sb, mantissa, formatProvider, maxNbDecimals);
        }

        return withAppendedExponent(sb, exponent, formatProvider, format[0]);

        static string withAppendedExponent(StringBuilder sb, int exponent, NumberFormatInfo numberFormat, char exponentSymbol) {
            return exponent >= 0
                ? sb.Append(exponentSymbol).Append(numberFormat.PositiveSign).Append(exponent.ToString("D3", numberFormat)).ToString()
                : sb.Append(exponentSymbol).Append(exponent.ToString("D3", numberFormat)).ToString();
        }
    }

    /// <summary>
    ///     The general ("G") format specifier converts a number to the more compact of either fixed-point or scientific
    ///     notation, depending on the type of the number and whether a precision specifier is present. The precision specifier
    ///     defines the maximum number of significant digits that can appear in the result string. If the precision specifier
    ///     is omitted or zero, the type of the number determines the default precision.
    /// </summary>
    private static string FormatGeneral(Fraction fraction, string format, NumberFormatInfo formatProvider) {
        if (fraction.Numerator == BigInteger.Zero) {
            return 0d.ToString(format, formatProvider);
        }

        var maxNbDecimals = GetPrecisionDigitsOrDefault(format, 19);
        if (maxNbDecimals == 0) {
            maxNbDecimals = 19;
        }

        var sb = new StringBuilder(3 + maxNbDecimals);

        if (fraction.IsNegative) {
            sb.Append(formatProvider.NegativeSign);
            fraction = fraction.Abs();
        }

        var exponent = GetExponentPower(fraction, out var exponentTerm);

        if (exponent == maxNbDecimals - 1) {
            // integral result: both 123400 (1.234e5) and 123400.01 (1.234001e+005) result in "123400" with the "G6" format
            return sb.Append(Round(fraction.Numerator, fraction.Denominator)).ToString();
        }

        if (exponent > maxNbDecimals - 1) {
            // we are required to shorten down a number of the form 123400 (1.234E+05)
            var mantissa = Round(fraction / exponentTerm, maxNbDecimals - 1);
            AppendSignificantDecimals(sb, mantissa, formatProvider, maxNbDecimals - 1);
            return AppendExponentWithSignificantDigits(sb, exponent, formatProvider, format[0] is 'g' ? 'e' : 'E').ToString();
        }

        switch (exponent) {
            case >= 0: // the required number of significant digits is less than the specified limit: e.g. 123.45 with the "G20"
                return AppendSignificantDecimals(sb, fraction, formatProvider, maxNbDecimals - exponent - 1).ToString();
            case <= -5: // the largest value would have the form: 1.23e-5 (0.000123)
                var mantissa = Round(fraction * exponentTerm, maxNbDecimals - 1);
                AppendSignificantDecimals(sb, mantissa, formatProvider, maxNbDecimals - 1);
                return AppendExponentWithSignificantDigits(sb, exponent, formatProvider, format[0] is 'g' ? 'e' : 'E').ToString();
            default:
                // the smallest value would have the form: 1.23e-4 (0.00123)
                var roundedDecimal = Round(fraction, maxNbDecimals - exponent - 1);
                return AppendSignificantDecimals(sb, roundedDecimal, formatProvider, maxNbDecimals - exponent - 1).ToString();
        }
    }

    /// <summary>
    ///     Formats the given fraction with a specified number of significant digits after the radix point.
    /// </summary>
    /// <param name="fraction">The fraction to format.</param>
    /// <param name="format">
    ///     The format string to use. The format string should specify the maximum number of digits after the
    ///     radix point.
    /// </param>
    /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
    /// <returns>
    ///     A string representation of the fraction, formatted with the specified number of significant digits after the
    ///     radix point.
    /// </returns>
    /// <remarks>
    ///     The method formats the fraction based on the absolute value of the fraction:
    ///     <list type="bullet">
    ///         <item>
    ///             For values greater than 1e5 (e.g., 1230000), the fraction is formatted as a number with an exponent (e.g.,
    ///             1.23e6).
    ///         </item>
    ///         <item>
    ///             For values less than or equal to 1e-4 (e.g., 0.000123), the fraction is formatted as a number with an
    ///             exponent (e.g., 1.23e-4).
    ///         </item>
    ///         <item>
    ///             For values between 1e-3 and 1e5 (e.g., 0.00123 to 123000), the fraction is formatted as a decimal number.
    ///         </item>
    ///     </list>
    /// </remarks>
    private static string FormatWithSignificantDigitsAfterRadix(Fraction fraction, string format, NumberFormatInfo formatProvider) {
        if (fraction.Numerator == BigInteger.Zero) {
            return 0d.ToString(formatProvider);
        }

        const string quotientFormat = "N0";
        var maxDigitsAfterRadix = GetPrecisionDigitsOrDefault(format, 2);

        var sb = new StringBuilder(3 + maxDigitsAfterRadix);

        if (fraction.IsNegative) {
            sb.Append(formatProvider.NegativeSign);
            fraction = fraction.Abs();
        }

        var exponent = GetExponentPower(fraction, out var exponentTerm);
        Fraction mantissa;
        switch (exponent) {
            case > 5: // the smallest value would have the form: 1.23e6 (1230000)
                mantissa = Round(fraction / exponentTerm, maxDigitsAfterRadix);
                AppendSignificantDecimals(sb, mantissa, formatProvider, maxDigitsAfterRadix, quotientFormat);
                return AppendExponentWithSignificantDigits(sb, exponent, formatProvider, format[0] is 's' ? 'e' : 'E').ToString();
            case <= -4: // the largest value would have the form: 1.23e-4 (0.000123)
                mantissa = Round(fraction * exponentTerm, maxDigitsAfterRadix);
                AppendSignificantDecimals(sb, mantissa, formatProvider, maxDigitsAfterRadix, quotientFormat);
                return AppendExponentWithSignificantDigits(sb, exponent, formatProvider, format[0] is 's' ? 'e' : 'E').ToString();
            case < 0: // the smallest value would have the form: 1.23e-3 (0.00123)
                var leadingZeroes = -exponent;
                maxDigitsAfterRadix += leadingZeroes - 1;
                mantissa = Round(fraction, maxDigitsAfterRadix);
                return AppendSignificantDecimals(sb, mantissa, formatProvider, maxDigitsAfterRadix, quotientFormat).ToString();
            default: // the largest value would have the form: 1.23e5 (123000)
                mantissa = Round(fraction, maxDigitsAfterRadix);
                return AppendSignificantDecimals(sb, mantissa, formatProvider, maxDigitsAfterRadix, quotientFormat).ToString();
        }
    }


    private static StringBuilder AppendDecimals(StringBuilder sb, Fraction fraction, NumberFormatInfo formatProvider, int nbDecimals,
        string quotientFormat = "F0",
        MidpointRounding roundingMode = DefaultMidpointRoundingMode) {
        var quotient = BigInteger.DivRem(fraction.Numerator, fraction.Denominator, out var remainder);

        sb.Append(quotient.ToString(quotientFormat, formatProvider)).Append(formatProvider.NumberDecimalSeparator);

        remainder = BigInteger.Abs(remainder);

        var decimalsAdded = 0;
        while (!remainder.IsZero && decimalsAdded++ < nbDecimals - 1) {
            quotient = BigInteger.DivRem(remainder * Ten, fraction.Denominator, out remainder);
            sb.Append(quotient.ToString(formatProvider));
        }

        if (remainder.IsZero) {
            sb.Append('0', nbDecimals - decimalsAdded);
        } else {
            quotient = Round(remainder * Ten, fraction.Denominator, roundingMode);
            sb.Append(quotient.ToString(formatProvider));
        }

        return sb;
    }

    private static StringBuilder AppendSignificantDecimals(StringBuilder sb, Fraction mantissa, NumberFormatInfo formatProvider, int maxNbDecimals,
        string quotientFormat = "F0") {
        var quotient = BigInteger.DivRem(mantissa.Numerator, mantissa.Denominator, out var remainder);

        sb.Append(quotient.ToString(quotientFormat, formatProvider));

        if (remainder.IsZero) {
            return sb;
        }

        sb.Append(formatProvider.NumberDecimalSeparator);

        var nbDecimals = 0;
        while (nbDecimals++ < maxNbDecimals - 1) {
            quotient = BigInteger.DivRem(remainder * Ten, mantissa.Denominator, out remainder);
            sb.Append(quotient.ToString(formatProvider));
            if (remainder == BigInteger.Zero) {
                return sb;
            }
        }

        quotient = Round(remainder * Ten, mantissa.Denominator);
        sb.Append(quotient.ToString(formatProvider));
        return sb;
    }

    private static StringBuilder AppendExponentWithSignificantDigits(StringBuilder sb, int exponent, NumberFormatInfo formatProvider, char exponentSymbol) {
        return exponent switch {
            <= -1000 => sb.Append(exponentSymbol).Append(exponent.ToString(formatProvider)),
            <= 0 => sb.Append(exponentSymbol).Append(exponent.ToString("D2", formatProvider)),
            < 100 => sb.Append(exponentSymbol).Append(formatProvider.PositiveSign).Append(exponent.ToString("D2", formatProvider)),
            < 1000 => sb.Append(exponentSymbol).Append(formatProvider.PositiveSign).Append(exponent.ToString("D3", formatProvider)),
            _ => sb.Append(exponentSymbol).Append(formatProvider.PositiveSign).Append(exponent.ToString(formatProvider))
        };
    }

    #region Rounding functions (with the default-per-framework rounding mode)

    /// <summary>
    ///     Rounds the given Fraction to a specified number of digits using a specified rounding strategy.
    /// </summary>
    /// <param name="x">The Fraction to be rounded.</param>
    /// <param name="nbDigits">The number of decimal places in the return value.</param>
    /// <param name="midpointRounding">
    ///     One of the enumeration values that specifies which rounding strategy to use. If not
    ///     provided, the default rounding strategy is used. The default rounding strategy is determined by the target
    ///     framework's default string rounding mode.
    /// </param>
    /// <returns>
    ///     A new Fraction that is the nearest number to 'x' with the specified number of digits, rounded as specified by
    ///     'midpointRounding'.
    /// </returns>
    private static Fraction Round(Fraction x, int nbDigits, MidpointRounding midpointRounding = DefaultMidpointRoundingMode) {
        return Fraction.Round(x, nbDigits, midpointRounding);
    }

    /// <summary>
    ///     Rounds the given Fraction to the specified precision using the specified rounding strategy.
    /// </summary>
    /// <param name="numerator">The numerator of the fraction to be rounded.</param>
    /// <param name="denominator">The denominator of the fraction to be rounded.</param>
    /// <param name="midpointRounding">
    ///     One of the enumeration values that specifies which rounding strategy to use. If not
    ///     provided, the default rounding strategy is used. The default rounding strategy is determined by the target
    ///     framework's default string rounding mode.
    /// </param>
    /// <returns>The number rounded to using the <paramref name="midpointRounding" /> rounding strategy.</returns>
    private static BigInteger Round(BigInteger numerator, BigInteger denominator, MidpointRounding midpointRounding = DefaultMidpointRoundingMode) {
        return Fraction.RoundToBigInteger(new Fraction(numerator, denominator, false), midpointRounding);
    }

    #endregion

    /// <summary>
    ///     Calculates the exponent power for the given fraction.
    /// </summary>
    /// <param name="fraction">The fraction for which to calculate the exponent power. The fraction must be positive.</param>
    /// <param name="powerOfTen">
    ///     Output parameter that returns the power of ten that corresponds to the calculated exponent
    ///     power.
    /// </param>
    /// <returns>The exponent power for the given fraction.</returns>
    private static int GetExponentPower(Fraction fraction, out BigInteger powerOfTen) {
        if (fraction.Numerator > fraction.Denominator) {
            var nbDigits = CountDigits(fraction.Numerator / fraction.Denominator, out powerOfTen);
            if (fraction.Numerator * powerOfTen < Ten * fraction.Denominator) {
                return nbDigits;
            }

            powerOfTen /= Ten;
            return nbDigits - 1;
        } else {
            var nbDigits = CountDigits(fraction.Denominator / fraction.Numerator, out powerOfTen);
            if (fraction.Numerator * powerOfTen < Ten * fraction.Denominator) {
                return -nbDigits;
            }

            powerOfTen /= Ten;
            return -nbDigits + 1;
        }
    }

#if NET5_0_OR_GREATER
    private static readonly double Log10Of2 = Math.Log10(2);
    private static int CountDigits(BigInteger value, out BigInteger powerOfTen)
    {
        var numBits = value.GetBitLength();
        var base10Digits = (int)(numBits * Log10Of2);
        powerOfTen = BigInteger.Pow(Ten, base10Digits);

        if (value < powerOfTen)
        {
            return base10Digits;
        }

        powerOfTen *= Ten;
        return base10Digits + 1;
    }
#else
    private static int CountDigits(BigInteger value, out BigInteger powerOfTen) {
        var base10Digits = (int)Math.Ceiling(BigInteger.Log10(value));
        powerOfTen = BigInteger.Pow(Ten, base10Digits);

        if (value < powerOfTen) {
            return base10Digits;
        }

        powerOfTen *= Ten;
        return base10Digits + 1;
    }
#endif
}
