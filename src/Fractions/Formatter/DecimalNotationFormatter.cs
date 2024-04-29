#nullable enable
using System;
using System.Globalization;
using System.Numerics;
using System.Text;
using Fractions.Properties;

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
/// string formatted = formatter.Format("f", fraction, CultureInfo.InvariantCulture);
/// Console.WriteLine(formatted);  // Outputs: "0.50"
/// </code>
/// </example>
/// <seealso cref="ICustomFormatter" />
/// <seealso cref="Fraction" />
public class DecimalNotationFormatter : ICustomFormatter {
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
    ///     The default precision used for the general format specifier (G)
    /// </summary>
    public const int DefaultGeneralFormatPrecision =
#if NETCOREAPP2_0_OR_GREATER
        16;
#else
        15;
#endif

    /// <summary>
    ///     The default precision used for the exponential (scientific) format specifier (E)
    /// </summary>
    public const int DefaultScientificFormatPrecision = 6;

    /// <summary>
    ///     Gets the singleton instance of the DecimalFractionFormatter class.
    /// </summary>
    /// <value>
    ///     The singleton instance of the DecimalFractionFormatter class.
    /// </value>
    /// <remarks>
    ///     This instance can be used to format Fraction objects into decimal string representations.
    /// </remarks>
    public static ICustomFormatter Instance { get; } = new DecimalNotationFormatter();

    private static readonly BigInteger Ten = new(10);

    /// <summary>
    ///     Formats the value of the specified Fraction object as a string using the specified format.
    /// </summary>
    /// <param name="format">A standard or custom numeric format string.</param>
    /// <param name="value">The Fraction object to be formatted.</param>
    /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
    /// <returns>
    ///     The string representation of the value of the Fraction object as specified by the format and formatProvider
    ///     parameters.
    /// </returns>
    /// <remarks>
    ///     This method supports the following format strings:
    ///     <list type="bullet">
    ///         <item>
    ///             <description>
    ///                 <see
    ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-general-g-format-specifier">
    ///                     'G'
    ///                     or 'g'
    ///                 </see>
    ///                 : General format. Example: 400/3 formatted with 'G2' gives "1.3E+02".
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <see
    ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-fixed-point-f-format-specifier">
    ///                     'F'
    ///                     or 'f'
    ///                 </see>
    ///                 : Fixed-point format. Example: 12345/10 formatted with 'F2' gives "1234.50".
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <see
    ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-number-n-format-specifier">
    ///                     'N'
    ///                     or 'n'
    ///                 </see>
    ///                 : Standard Numeric format. Example: 1234567/1000 formatted with 'N2' gives "1,234.57".
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <see
    ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-exponential-e-format-specifier">
    ///                     'E'
    ///                     or 'e'
    ///                 </see>
    ///                 : Scientific format. Example: 1234567/1000 formatted with 'E2' gives "1.23E+003".
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <see
    ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-percent-p-format-specifier">
    ///                     'P'
    ///                     or 'p'
    ///                 </see>
    ///                 : Percent format. Example: 2/3 formatted with 'P2' gives "66.67 %".
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <see
    ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-currency-c-format-specifier">
    ///                     'C'
    ///                     or 'c'
    ///                 </see>
    ///                 : Currency format. Example: 1234567/1000 formatted with 'C2' gives "$1,234.57".
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <see
    ///                     href="https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#RFormatString">
    ///                     'R'
    ///                     or 'r'
    ///                 </see>
    ///                 : Round-trip format. Example: 1234567/1000 formatted with 'R' gives "1234.567".
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <see
    ///                     href="https://github.com/danm-de/Fractions?tab=readme-ov-file#significant-digits-after-radix-format">
    ///                     'S'
    ///                     or 's'
    ///                 </see>
    ///                 : Significant Digits After Radix format. Example: 400/3 formatted with 'S2' gives
    ///                 "133.33".
    ///             </description>
    ///         </item>
    ///     </list>
    ///     Note: The 'R' format and custom formats do not support precision specifiers and are handed over to the `double`
    ///     type for formatting, which may result in a loss of precision.
    ///     For more information about the formatter, see the
    ///     <see href="https://github.com/danm-de/Fractions?tab=readme-ov-file#decimalnotationformatter">
    ///         DecimalNotationFormatter
    ///         section
    ///     </see>
    ///     in the GitHub README.
    /// </remarks>
    public string Format(string? format, object? value, IFormatProvider? formatProvider) {
        if (value is null) {
            return string.Empty;
        }

        if (value is not Fraction fraction) {
            throw new FormatException(string.Format(Resources.TypeXnotSupported, value.GetType()));
        }

        formatProvider ??= CultureInfo.CurrentCulture;
        var numberFormatInfo = (NumberFormatInfo)formatProvider.GetFormat(typeof(NumberFormatInfo))!;

        if (fraction.IsPositiveInfinity) {
            return numberFormatInfo.PositiveInfinitySymbol;
        }

        if (fraction.IsNegativeInfinity) {
            return numberFormatInfo.NegativeInfinitySymbol;
        }

        if (fraction.IsNaN) {
            return numberFormatInfo.NaNSymbol;
        }

        if (string.IsNullOrEmpty(format)) {
            return FormatGeneral(fraction, "G", numberFormatInfo);
        }

        var formatCharacter = format![0];
        return formatCharacter switch {
            'G' or 'g' => FormatGeneral(fraction, format, numberFormatInfo),
            'F' or 'f' => FormatWithFixedPointFormat(fraction, format, numberFormatInfo),
            'N' or 'n' => FormatWithStandardNumericFormat(fraction, format, numberFormatInfo),
            'E' or 'e' => FormatWithScientificFormat(fraction, format, numberFormatInfo),
            'P' or 'p' => FormatWithPercentFormat(fraction, format, numberFormatInfo),
            'C' or 'c' => FormatWithCurrencyFormat(fraction, format, numberFormatInfo),
            'S' or 's' => FormatWithSignificantDigitsAfterRadix(fraction, format, numberFormatInfo),
            _ => // 'R', 'r' and the custom formats are handed over to the double (possible loss of precision) 
                fraction.ToDouble().ToString(format, formatProvider)
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
    ///     The fixed-point ("F") format specifier converts a number to a string of the form "-ddd.ddd…" where each "d"
    ///     indicates a digit (0-9). The string starts with a minus sign if the number is negative.
    /// </summary>
    /// <remarks>
    ///     The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted, the
    ///     current <see cref="NumberFormatInfo.NumberDecimalDigits" /> property supplies the numeric precision.
    /// </remarks>
    private static string FormatWithFixedPointFormat(Fraction fraction, string format,
        NumberFormatInfo formatProvider) {
        if (fraction.Numerator == BigInteger.Zero) {
            return 0d.ToString(format, formatProvider);
        }

        if (fraction.Denominator.IsOne) {
            return fraction.Numerator.ToString(format, formatProvider)!;
        }

        var maxNbDecimalsAfterRadix = GetPrecisionDigitsOrDefault(format, formatProvider.NumberDecimalDigits);

        var sb = new StringBuilder(12 + maxNbDecimalsAfterRadix);

#if NETCOREAPP2_1_OR_GREATER
        if (fraction.IsNegative) {
            sb.Append(formatProvider.NegativeSign);
            fraction = fraction.Abs();
        }

        if (maxNbDecimalsAfterRadix == 0) {
            return sb.Append(Round(fraction.Numerator, fraction.Denominator).ToString(format, formatProvider)).ToString();
        }

        var roundedFraction = Round(fraction, maxNbDecimalsAfterRadix);
        if (roundedFraction.Numerator.IsZero || roundedFraction.Denominator.IsOne) {
            return sb.Append(roundedFraction.Numerator.ToString(format, formatProvider)!).ToString();
        }

        return AppendDecimals(sb, roundedFraction, formatProvider, maxNbDecimalsAfterRadix).ToString();
#else
        // On .NET Framework and .NET Core up to .NET Core 2.0 the string format does not append the '-' sign when a value is rounded to 0.
        if (maxNbDecimalsAfterRadix == 0) {
            return sb.Append(Round(fraction.Numerator, fraction.Denominator).ToString(format, formatProvider)!)
                .ToString();
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
    ///     The numeric ("N") format specifier converts a number to a string of the form "-d,ddd,ddd.ddd…", where "-"
    ///     indicates
    ///     a negative number symbol if required, "d" indicates a digit (0-9), "," indicates a group separator, and "."
    ///     indicates a decimal point symbol.
    /// </summary>
    /// <remarks>
    ///     The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted, the
    ///     current <see cref="NumberFormatInfo.NumberDecimalDigits" /> property supplies the numeric precision.
    /// </remarks>
    private static string FormatWithStandardNumericFormat(Fraction fraction, string format,
        NumberFormatInfo formatProvider) {
        if (fraction.Numerator == BigInteger.Zero) {
            return 0d.ToString(format, formatProvider);
        }

        if (fraction.Denominator.IsOne) {
            return fraction.Numerator.ToString(format, formatProvider)!;
        }

        var maxNbDecimals = GetPrecisionDigitsOrDefault(format, formatProvider.NumberDecimalDigits);

        var sb = new StringBuilder(3 + maxNbDecimals);

        var isPositive = fraction.IsPositive;
        if (!isPositive) {
            fraction = fraction.Abs();
        }

        if (maxNbDecimals == 0) {
            var roundedValue = Round(fraction.Numerator, fraction.Denominator);
#if NETSTANDARD
            if (roundedValue.IsZero) {
                return 0d.ToString(format, formatProvider);
            }
#endif
            sb.Append(roundedValue.ToString(format, formatProvider)!);
        } else {
            var roundedFraction = Round(fraction, maxNbDecimals);
            if (roundedFraction.Numerator.IsZero || roundedFraction.Denominator.IsOne) {
#if NETSTANDARD
                if (roundedFraction.Numerator.IsZero) {
                    return 0d.ToString(format, formatProvider);
                }
#endif
                sb.Append(roundedFraction.Numerator.ToString(format, formatProvider)!);
            } else {
                AppendDecimals(sb, roundedFraction, formatProvider, maxNbDecimals, "N0");
            }
        }

        return isPositive
            ? sb.ToString()
            : withNegativeSign(sb, formatProvider.NegativeSign, formatProvider.NumberNegativePattern);

        static string withNegativeSign(StringBuilder sb, string negativeSignSymbol, int pattern) {
            return pattern switch {
                0 => // (n)
                    sb.Insert(0, '(').Append(')').ToString(),
                1 => // -n
                    sb.Insert(0, negativeSignSymbol).ToString(),
                2 => // - n
                    sb.Insert(0, negativeSignSymbol + ' ').ToString(),
                3 => // n-
                    sb.Append(negativeSignSymbol).ToString(),
                4 => // n -
                    sb.Append(' ').Append(negativeSignSymbol).ToString(),
                _ => throw new ArgumentOutOfRangeException(nameof(pattern))
            };
        }
    }

    /// <summary>
    ///     The percent ("P") format specifier multiplies a number by 100 and converts it to a string that represents a
    ///     percentage.
    /// </summary>
    /// <remarks>
    ///     The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted,
    ///     the default numeric precision supplied by the current <see cref="NumberFormatInfo.PercentDecimalDigits" /> property
    ///     is used.
    /// </remarks>
    private static string FormatWithPercentFormat(Fraction fraction, string format, NumberFormatInfo formatProvider) {
        if (fraction.Numerator == BigInteger.Zero) {
            return 0.ToString(format, formatProvider);
        }

        if (fraction.Denominator.IsOne) {
            return fraction.Numerator.ToString(format, formatProvider)!;
        }

        var maxNbDecimals = GetPrecisionDigitsOrDefault(format, formatProvider.PercentDecimalDigits);

        var sb = new StringBuilder(4 + maxNbDecimals);

        var percentFormatInfo = new NumberFormatInfo {
            NumberDecimalSeparator = formatProvider.PercentDecimalSeparator,
            NumberGroupSeparator = formatProvider.PercentGroupSeparator,
            NumberGroupSizes = formatProvider.PercentGroupSizes,
            NativeDigits = formatProvider.NativeDigits,
            DigitSubstitution = formatProvider.DigitSubstitution
        };

        if (maxNbDecimals == 0) {
            var roundedValue = Round(100 * fraction.Numerator, fraction.Denominator);
#if NETSTANDARD
            if (roundedValue.IsZero) {
                return 0.ToString(format, formatProvider);
            }
#endif
            var percentFormatString = 'N' + maxNbDecimals.ToString();
            if (fraction.IsPositive) {
                sb.Append(roundedValue.ToString(percentFormatString, percentFormatInfo));
                return withPositiveSign(sb, formatProvider.PercentSymbol, formatProvider.PercentPositivePattern);
            }

            sb.Append((-roundedValue).ToString(percentFormatString, percentFormatInfo));
            return withNegativeSign(sb, formatProvider.PercentSymbol, formatProvider.NegativeSign,
                formatProvider.PercentNegativePattern);
        }

        var isPositive = fraction.IsPositive;

        if (fraction.IsPositive) {
            fraction *= 100;
        } else {
            fraction *= -100;
        }

        var roundedFraction = Round(fraction, maxNbDecimals);
        if (roundedFraction.Numerator.IsZero || roundedFraction.Denominator.IsOne) {
#if NETSTANDARD
            if (roundedFraction.Numerator.IsZero) {
                return 0.ToString(format, formatProvider);
            }
#endif
            var percentFormatString = 'N' + maxNbDecimals.ToString();
            sb.Append(roundedFraction.Numerator.ToString(percentFormatString, percentFormatInfo)!);
        } else {
            AppendDecimals(sb, roundedFraction, percentFormatInfo, maxNbDecimals, "N0");
        }

        return isPositive
            ? withPositiveSign(sb, formatProvider.PercentSymbol, formatProvider.PercentPositivePattern)
            : withNegativeSign(sb, formatProvider.PercentSymbol, formatProvider.NegativeSign,
                formatProvider.PercentNegativePattern);

        static string withPositiveSign(StringBuilder sb, string percentSymbol, int pattern) {
            return pattern switch {
                0 => // n %
                    sb.Append(' ').Append(percentSymbol).ToString(),
                1 => // n%
                    sb.Append(percentSymbol).ToString(),
                2 => // %n
                    sb.Insert(0, percentSymbol).ToString(),
                3 => // % n
                    sb.Insert(0, percentSymbol + ' ').ToString(),
                _ => throw new ArgumentOutOfRangeException(nameof(pattern))
            };
        }

        static string withNegativeSign(StringBuilder sb, string percentSymbol, string negativeSignSymbol, int pattern) {
            return pattern switch {
                0 => // -n %
                    sb.Insert(0, negativeSignSymbol).Append(' ').Append(percentSymbol).ToString(),
                1 => // -n%
                    sb.Insert(0, negativeSignSymbol).Append(percentSymbol).ToString(),
                2 => // -%n
                    sb.Insert(0, negativeSignSymbol + percentSymbol).ToString(),
                3 => // %-n
                    sb.Insert(0, percentSymbol + negativeSignSymbol).ToString(),
                4 => // %n-
                    sb.Insert(0, percentSymbol).Append(negativeSignSymbol).ToString(),
                5 => // n-%
                    sb.Append(negativeSignSymbol).Append(percentSymbol).ToString(),
                6 => // n%-
                    sb.Append(percentSymbol).Append(negativeSignSymbol).ToString(),
                7 => // -% n
                    sb.Insert(0, negativeSignSymbol + percentSymbol + ' ').ToString(),
                8 => // n %-
                    sb.Append(' ').Append(percentSymbol).Append(negativeSignSymbol).ToString(),
                9 => // % n-
                    sb.Insert(0, percentSymbol + ' ').Append(negativeSignSymbol).ToString(),
                10 => // % -n
                    sb.Insert(0, percentSymbol + ' ').Insert(2, negativeSignSymbol).ToString(),
                11 => // n- %
                    sb.Append(negativeSignSymbol).Append(' ').Append(percentSymbol).ToString(),
                _ => throw new ArgumentOutOfRangeException(nameof(pattern))
            };
        }
    }


    /// <summary>
    ///     The "C" (or currency) format specifier converts a number to a string that represents a currency amount. The
    ///     precision specifier indicates the desired number of decimal places in the result string. If the precision specifier
    ///     is omitted, the default precision is defined by the <see cref="NumberFormatInfo.CurrencyDecimalDigits" /> property.
    /// </summary>
    /// <remarks>
    ///     If the value to be formatted has more than the specified or default number of decimal places, the fractional
    ///     value is rounded in the result string. If the value to the right of the number of specified decimal places is 5 or
    ///     greater, the last digit in the result string is rounded away from zero.
    /// </remarks>
    private static string FormatWithCurrencyFormat(Fraction fraction, string format, NumberFormatInfo formatProvider) {
        if (fraction.Numerator == BigInteger.Zero) {
            return 0.ToString(format, formatProvider);
        }

        if (fraction.Denominator.IsOne) {
            return fraction.Numerator.ToString(format, formatProvider)!;
        }

        var maxNbDecimals = GetPrecisionDigitsOrDefault(format, formatProvider.CurrencyDecimalDigits);

        var sb = new StringBuilder(4 + maxNbDecimals);

        var currencyFormatInfo = new NumberFormatInfo {
            NumberDecimalSeparator = formatProvider.CurrencyDecimalSeparator,
            NumberGroupSeparator = formatProvider.CurrencyGroupSeparator,
            NumberGroupSizes = formatProvider.CurrencyGroupSizes,
            NativeDigits = formatProvider.NativeDigits,
            DigitSubstitution = formatProvider.DigitSubstitution
        };

        if (maxNbDecimals == 0) {
            var roundedValue = Round(fraction.Numerator, fraction.Denominator);
#if NETSTANDARD
            if (roundedValue.IsZero) {
                return 0.ToString(format, formatProvider);
            }
#endif
            var currencyFormatString = 'N' + maxNbDecimals.ToString();
            if (fraction.IsPositive) {
                sb.Append(roundedValue.ToString(currencyFormatString, currencyFormatInfo));
                return withPositiveSign(sb, formatProvider.CurrencySymbol, formatProvider.CurrencyPositivePattern);
            }

            sb.Append((-roundedValue).ToString(currencyFormatString, currencyFormatInfo));
            return withNegativeSign(sb, formatProvider.CurrencySymbol, formatProvider.NegativeSign,
                formatProvider.CurrencyNegativePattern);
        }

        var isPositive = fraction.IsPositive;

        if (!fraction.IsPositive) {
            fraction = fraction.Abs();
        }

        var roundedFraction = Round(fraction, maxNbDecimals);
        if (roundedFraction.Numerator.IsZero || roundedFraction.Denominator.IsOne) {
#if NETSTANDARD
            if (roundedFraction.Numerator.IsZero) {
                return 0.ToString(format, formatProvider);
            }
#endif
            var currencyFormatString = 'N' + maxNbDecimals.ToString();
            sb.Append(roundedFraction.Numerator.ToString(currencyFormatString, currencyFormatInfo)!);
        } else {
            AppendDecimals(sb, roundedFraction, currencyFormatInfo, maxNbDecimals, "N0");
        }

        return isPositive
            ? withPositiveSign(sb, formatProvider.CurrencySymbol, formatProvider.CurrencyPositivePattern)
            : withNegativeSign(sb, formatProvider.CurrencySymbol, formatProvider.NegativeSign,
                formatProvider.CurrencyNegativePattern);

        static string withPositiveSign(StringBuilder sb, string currencySymbol, int pattern) {
            return pattern switch {
                0 => // $n
                    sb.Insert(0, currencySymbol).ToString(),
                1 => // n$
                    sb.Append(currencySymbol).ToString(),
                2 => // $ n
                    sb.Insert(0, currencySymbol + ' ').ToString(),
                3 => // n $
                    sb.Append(' ').Append(currencySymbol).ToString(),
                _ => throw new ArgumentOutOfRangeException(nameof(pattern))
            };
        }

        static string withNegativeSign(StringBuilder sb, string currencySymbol, string negativeSignSymbol,
            int pattern) {
            return pattern switch {
                0 => // ($n)
                    sb.Insert(0, '(').Insert(1, currencySymbol).Append(')').ToString(),
                1 => // -$n
                    sb.Insert(0, negativeSignSymbol + currencySymbol).ToString(),
                2 => // $-n
                    sb.Insert(0, currencySymbol + negativeSignSymbol).ToString(),
                3 => // $n-
                    sb.Insert(0, currencySymbol).Append(negativeSignSymbol).ToString(),
                4 => // (n$)
                    sb.Insert(0, '(').Append(currencySymbol).Append(')').ToString(),
                5 => // -n$
                    sb.Insert(0, negativeSignSymbol).Append(currencySymbol).ToString(),
                6 => // n-$
                    sb.Append(negativeSignSymbol).Append(currencySymbol).ToString(),
                7 => // n$-
                    sb.Append(currencySymbol).Append(negativeSignSymbol).ToString(),
                8 => // -n $
                    sb.Insert(0, negativeSignSymbol).Append(' ').Append(currencySymbol).ToString(),
                9 => // -$ n
                    sb.Insert(0, negativeSignSymbol + currencySymbol + ' ').ToString(),
                10 => // n $-
                    sb.Append(' ').Append(currencySymbol).Append(negativeSignSymbol).ToString(),
                11 => // $ n-
                    sb.Insert(0, currencySymbol + ' ').Append(negativeSignSymbol).ToString(),
                12 => // $ -n
                    sb.Insert(0, currencySymbol + ' ' + negativeSignSymbol).ToString(),
                13 => // n- $
                    sb.Append(negativeSignSymbol).Append(' ').Append(currencySymbol).ToString(),
                14 => // ($ n)
                    sb.Insert(0, '(').Insert(1, currencySymbol + ' ').Append(')').ToString(),
                15 => // (n $)
                    sb.Insert(0, '(').Append(' ').Append(currencySymbol).Append(')').ToString(),
                16 => // $- n
                    sb.Insert(0, currencySymbol + negativeSignSymbol + ' ').ToString(),
                _ => throw new ArgumentOutOfRangeException(nameof(pattern))
            };
        }
    }

    /// <summary>
    ///     Exponential format specifier (E)
    ///     The exponential ("E") format specifier converts a number to a string of the form "-d.ddd…E+ddd" or "-d.ddd…e+ddd",
    ///     where each "d" indicates a digit (0-9). The string starts with a minus sign if the number is negative. Exactly one
    ///     digit always precedes the decimal point.
    /// </summary>
    /// <remarks>
    ///     The precision specifier indicates the desired number of digits after the decimal point. If the precision specifier
    ///     is omitted, a default of six digits after the decimal point is used.
    ///     The case of the format specifier indicates whether to prefix the exponent with an "E" or an "e". The exponent
    ///     always consists of a plus or minus sign and a minimum of three digits. The exponent is padded with zeros to meet
    ///     this minimum, if required.
    /// </remarks>
    private static string FormatWithScientificFormat(Fraction fraction, string format,
        NumberFormatInfo formatProvider) {
        if (fraction.Numerator == BigInteger.Zero) {
            return 0d.ToString(format, formatProvider);
        }

        if (fraction.Denominator.IsOne) {
            return fraction.Numerator.ToString(format, formatProvider)!;
        }

        var maxNbDecimals = GetPrecisionDigitsOrDefault(format, DefaultScientificFormatPrecision);
        var sb = new StringBuilder(DefaultScientificFormatPrecision + maxNbDecimals);

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

        static string withAppendedExponent(StringBuilder sb, int exponent, NumberFormatInfo numberFormat,
            char exponentSymbol) {
            return exponent >= 0
                ? sb.Append(exponentSymbol).Append(numberFormat.PositiveSign)
                    .Append(exponent.ToString("D3", numberFormat)).ToString()
                : sb.Append(exponentSymbol).Append(exponent.ToString("D3", numberFormat)).ToString();
        }
    }

    /// <summary>
    ///     The general ("G") format specifier converts a number to the more compact of either fixed-point or scientific
    ///     notation, depending on the type of the number and whether a precision specifier is present.
    /// </summary>
    /// <remarks>
    ///     The precision specifier
    ///     defines the maximum number of significant digits that can appear in the result string. If the precision specifier
    ///     is omitted or zero, the type of the number determines the default precision.
    /// </remarks>
    private static string FormatGeneral(Fraction fraction, string format, NumberFormatInfo formatProvider) {
        if (fraction.Numerator == BigInteger.Zero) {
            return 0d.ToString(format, formatProvider);
        }

        int maxNbDecimals;
        if (format.Length == 1 || (maxNbDecimals = GetPrecisionDigits(format)) == 0) {
            maxNbDecimals = DefaultGeneralFormatPrecision;
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
            return AppendExponentWithSignificantDigits(sb, exponent, formatProvider, format[0] is 'g' ? 'e' : 'E')
                .ToString();
        }

        switch (exponent) {
            case >= 0:
                // the required number of significant digits is less than the specified limit: e.g. 123.45 with the "G20"
                return AppendSignificantDecimals(sb, fraction, formatProvider, maxNbDecimals - exponent - 1).ToString();
            case <= -5:
                // the largest value would have the form: 1.23e-5 (0.000123)
                var mantissa = Round(fraction * exponentTerm, maxNbDecimals - 1);
                AppendSignificantDecimals(sb, mantissa, formatProvider, maxNbDecimals - 1);
                return AppendExponentWithSignificantDigits(sb, exponent, formatProvider, format[0] is 'g' ? 'e' : 'E')
                    .ToString();
            default:
                // the smallest value would have the form: 1.23e-4 (0.00123)
                var roundedDecimal = Round(fraction, maxNbDecimals - exponent - 1);
                return AppendSignificantDecimals(sb, roundedDecimal, formatProvider, maxNbDecimals - exponent - 1)
                    .ToString();
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
    private static string FormatWithSignificantDigitsAfterRadix(Fraction fraction, string format,
        NumberFormatInfo formatProvider) {
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
            case > 5:
                // the smallest value would have the form: 1.23e6 (1230000)
                mantissa = Round(fraction / exponentTerm, maxDigitsAfterRadix);
                AppendSignificantDecimals(sb, mantissa, formatProvider, maxDigitsAfterRadix, quotientFormat);
                return AppendExponentWithSignificantDigits(sb, exponent, formatProvider, format[0] is 's' ? 'e' : 'E')
                    .ToString();
            case <= -4:
                // the largest value would have the form: 1.23e-4 (0.000123)
                mantissa = Round(fraction * exponentTerm, maxDigitsAfterRadix);
                AppendSignificantDecimals(sb, mantissa, formatProvider, maxDigitsAfterRadix, quotientFormat);
                return AppendExponentWithSignificantDigits(sb, exponent, formatProvider, format[0] is 's' ? 'e' : 'E')
                    .ToString();
            case < 0:
                // the smallest value would have the form: 1.23e-3 (0.00123)
                var leadingZeroes = -exponent;
                maxDigitsAfterRadix += leadingZeroes - 1;
                mantissa = Round(fraction, maxDigitsAfterRadix);
                return AppendSignificantDecimals(sb, mantissa, formatProvider, maxDigitsAfterRadix, quotientFormat)
                    .ToString();
            default:
                // the largest value would have the form: 1.23e5 (123000)
                mantissa = Round(fraction, maxDigitsAfterRadix);
                return AppendSignificantDecimals(sb, mantissa, formatProvider, maxDigitsAfterRadix, quotientFormat)
                    .ToString();
        }
    }


    private static StringBuilder AppendDecimals(StringBuilder sb, Fraction fraction, NumberFormatInfo formatProvider,
        int nbDecimals, string quotientFormat = "F0",
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

    private static StringBuilder AppendSignificantDecimals(StringBuilder sb, Fraction mantissa,
        NumberFormatInfo formatProvider, int maxNbDecimals,
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

    private static StringBuilder AppendExponentWithSignificantDigits(StringBuilder sb, int exponent,
        NumberFormatInfo formatProvider, char exponentSymbol) {
        return exponent switch {
            <= -1000 => sb.Append(exponentSymbol).Append(exponent.ToString(formatProvider)),
            <= 0 => sb.Append(exponentSymbol).Append(exponent.ToString("D2", formatProvider)),
            < 100 => sb.Append(exponentSymbol).Append(formatProvider.PositiveSign)
                .Append(exponent.ToString("D2", formatProvider)),
            < 1000 => sb.Append(exponentSymbol).Append(formatProvider.PositiveSign)
                .Append(exponent.ToString("D3", formatProvider)),
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
    private static Fraction Round(Fraction x, int nbDigits,
        MidpointRounding midpointRounding = DefaultMidpointRoundingMode) {
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
    private static BigInteger Round(BigInteger numerator, BigInteger denominator,
        MidpointRounding midpointRounding = DefaultMidpointRoundingMode) {
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
    private static int CountDigits(BigInteger value, out BigInteger powerOfTen) {
        var numBits = value.GetBitLength();
        var base10Digits = (int)(numBits * Log10Of2);
        powerOfTen = BigInteger.Pow(Ten, base10Digits);

        if (value < powerOfTen) {
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
