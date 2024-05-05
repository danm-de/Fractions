using System;
using System.Globalization;
using System.Numerics;
using Fractions.Extensions;
using Fractions.Properties;

namespace Fractions;

public readonly partial struct Fraction {
    /// <summary>
    /// Converts a string to a fraction. Example: "3/4" or "4.5" (the decimal separator character is depending on the system culture).
    /// If the number contains a decimal separator it will be parsed as <see cref="decimal"/>.
    /// </summary>
    /// <param name="fractionString">A fraction or a (decimal) number. The numerator and denominator must be separated with a '/' (slash) character.</param>
    /// <returns>A normalized <see cref="Fraction"/></returns>
    public static Fraction FromString(string fractionString) =>
        FromString(fractionString, NumberStyles.Number, null);

    /// <summary>
    /// Converts a string to a fraction. Example: "3/4" or "4.5" (the decimal separator character depends on <paramref name="formatProvider"/>).
    /// If the number contains a decimal separator it will be parsed as <see cref="decimal"/>.
    /// </summary>
    /// <param name="fractionString">A fraction or a (decimal) number. The numerator and denominator must be separated with a '/' (slash) character.</param>
    /// <param name="formatProvider">Provides culture specific information that will be used to parse the <paramref name="fractionString"/>.</param>
    /// <returns>A normalized <see cref="Fraction"/></returns>
    public static Fraction FromString(string fractionString, IFormatProvider formatProvider) =>
        FromString(fractionString, NumberStyles.Number, formatProvider);

    /// <summary>
    /// Converts a string to a fraction. Example: "3/4" or "4.5" (the decimal separator character depends on <paramref name="formatProvider"/>).
    /// If the number contains a decimal separator it will be parsed as <see cref="decimal"/>.
    /// </summary>
    /// <param name="fractionString">A fraction or a (decimal) number. The numerator and denominator must be separated with a '/' (slash) character.</param>
    /// <param name="numberStyles">A bitwise combination of number styles that are allowed in <paramref name="fractionString"/>.</param>
    /// <param name="formatProvider">Provides culture specific information that will be used to parse the <paramref name="fractionString"/>.</param>
    /// <returns>A normalized <see cref="Fraction"/></returns>
    public static Fraction FromString(string fractionString, NumberStyles numberStyles,
        IFormatProvider formatProvider) {
        if (fractionString == null) {
            throw new ArgumentNullException(nameof(fractionString));
        }

        if (!TryParse(fractionString, numberStyles, formatProvider, true, out var fraction)) {
            throw new FormatException(string.Format(Resources.CannotConvertToFraction, fractionString));
        }

        return fraction;
    }

    /// <summary>
    /// Try to convert a string to a fraction. Example: "3/4" or "4.5" (the decimal separator character depends on the system's culture).
    /// If the number contains a decimal separator it will be parsed as <see cref="decimal"/>.
    /// </summary>
    /// <param name="value">A fraction or a (decimal) number. The numerator and denominator must be separated with a '/' (slash) character.</param>
    /// <param name="fraction">A normalized <see cref="Fraction"/> if the method returns with <c>true</c>. Otherwise, the value is invalid.</param>
    /// <returns>
    /// <para><c>true</c> if <paramref name="value"/> was well-formed. The parsing result will be written to <paramref name="fraction"/>. </para>
    /// <para><c>false</c> if <paramref name="value"/> was invalid.</para></returns>
    public static bool TryParse(string value, out Fraction fraction) =>
        TryParse(value, NumberStyles.Number, null, true, out fraction);

    /// <summary>
    /// Try to convert a string to a fraction. Example: "3/4" or "4.5" (the decimal separator character depends on <paramref name="formatProvider"/>).
    /// If the number contains a decimal separator it will be parsed as <see cref="decimal"/>.
    /// </summary>
    /// <param name="value">A fraction or a (decimal) number. The numerator and denominator must be separated with a '/' (slash) character.</param>
    /// <param name="numberStyles">A bitwise combination of number styles that are allowed in <paramref name="value"/>.</param>
    /// <param name="formatProvider">Provides culture specific information that will be used to parse the <paramref name="value"/>.</param>
    /// <param name="fraction">A normalized <see cref="Fraction"/> if the method returns with <c>true</c>. Otherwise, the value is invalid.</param>
    /// <returns>
    /// <para><c>true</c> if <paramref name="value"/> was well-formed. The parsing result will be written to <paramref name="fraction"/>. </para>
    /// <para><c>false</c> if <paramref name="value"/> was invalid.</para>
    /// </returns>
    public static bool TryParse(string value, NumberStyles numberStyles, IFormatProvider formatProvider,
        out Fraction fraction) =>
        TryParse(value, numberStyles, formatProvider, true, out fraction);

#if NET
    /// <summary>
    /// Try to convert a ReadOnlySpan of type char to a fraction. Example: "3/4" or "4.5" (the decimal separator character depends on <paramref name="formatProvider"/>).
    /// If the number contains a decimal separator it will be parsed as <see cref="decimal"/>.
    /// </summary>
    /// <param name="fractionString">A fraction or a (decimal) number. The numerator and denominator must be separated with a '/' (slash) character.</param>
    /// <param name="numberStyles">A bitwise combination of number styles that are allowed in <paramref name="fractionString"/>.</param>
    /// <param name="formatProvider">Provides culture specific information that will be used to parse the <paramref name="fractionString"/>.</param>
    /// <param name="normalize">If <c>true</c> the parsed fraction will be reduced.</param>
    /// <param name="fraction">A <see cref="Fraction"/> if the method returns with <c>true</c>. Otherwise, the value is invalid.</param>
    /// <returns>
    /// <para><c>true</c> if <paramref name="fractionString"/> was well-formed. The parsing result will be written to <paramref name="fraction"/>. </para>
    /// <para><c>false</c> if <paramref name="fractionString"/> was invalid.</para>
    /// </returns>
    public static bool TryParse(ReadOnlySpan<char> fractionString, NumberStyles numberStyles, IFormatProvider formatProvider,
        bool normalize, out Fraction fraction) {
        if (fractionString.IsEmpty) {
            return CannotParse(out fraction);
        }

        if (fractionString.Length == 1) {
            if (!BigInteger.TryParse(fractionString, numberStyles, formatProvider, out var singleDigit)) {
                return CannotParse(out fraction);
            }

            fraction = new Fraction(singleDigit);
            return true;
        }
        
        var ranges = new Span<Range>(new Range[2]);
        var nbRangesFilled = fractionString.Split(ranges, '/');

        if (nbRangesFilled == 2) {
            var numeratorValue = fractionString[ranges[0]];
            var denominatorValue = fractionString[ranges[1]];

            var withoutDecimalPoint = numberStyles & ~NumberStyles.AllowDecimalPoint;
            if (!BigInteger.TryParse(
                    value: numeratorValue,
                    style: withoutDecimalPoint,
                    provider: formatProvider,
                    result: out var numerator)
                || !BigInteger.TryParse(
                    value: denominatorValue,
                    style: withoutDecimalPoint,
                    provider: formatProvider,
                    result: out var denominator)) {
                return CannotParse(out fraction);
            }

            fraction = new Fraction(numerator, denominator, normalize);
            return true;
        }

        // parsing a number using to the selected NumberStyles: e.g. " $ 12345.1234321e-4- " should result in -1.23451234321 with NumberStyles.Any
        var numberFormatInfo = NumberFormatInfo.GetInstance(formatProvider);
        // check for any of the special symbols (these cannot be combined with anything else)
        if (fractionString.SequenceEqual(numberFormatInfo.NaNSymbol.AsSpan())) {
            fraction = NaN;
            return true;
        }
        
        if (fractionString.SequenceEqual(numberFormatInfo.PositiveInfinitySymbol.AsSpan())) {
            fraction = PositiveInfinity;
            return true;
        }
        
        if (fractionString.SequenceEqual(numberFormatInfo.NegativeInfinitySymbol.AsSpan())) {
            fraction = NegativeInfinity;
            return true;
        }

        var currencyAllowed = (numberStyles & NumberStyles.AllowCurrencySymbol) != 0;
        var currencyDetected = false; // there "special" rules regarding the white-spaces after a leading currency symbol is detected
        ReadOnlySpan<char> currencySymbol;
        if (currencyAllowed) {
            currencySymbol = numberFormatInfo.CurrencySymbol.AsSpan();
            if (currencySymbol.IsEmpty) {
                currencyAllowed = false;
                numberStyles &= ~NumberStyles.AllowCurrencySymbol; // no currency symbol available
            }
        } else {
            currencySymbol = [];
        }

        ReadOnlySpan<char> decimalSeparator; // note: decimal.TryParse relies on the CurrencySymbol (when currency is detected)
        var decimalsAllowed = (numberStyles & NumberStyles.AllowDecimalPoint) != 0;
        if (decimalsAllowed) {
            decimalSeparator = numberFormatInfo.NumberDecimalSeparator.AsSpan();
            if (decimalSeparator.IsEmpty) {
                decimalsAllowed = false;
                numberStyles &= ~NumberStyles.AllowDecimalPoint; // no decimal separator available
            }
        } else {
            decimalSeparator = [];
        }
        
        var startIndex = 0;
        var endIndex = fractionString.Length;
        var isNegative = false;

        // examine the leading characters
        do {
            var character = fractionString[startIndex];
            if (char.IsDigit(character)) {
                break;
            }

            if (char.IsWhiteSpace(character)) {
                if ((numberStyles & NumberStyles.AllowLeadingWhite) == 0) {
                    return CannotParse(out fraction);
                }

                startIndex++;
                continue;
            }

            if (character == '(') {
                if ((numberStyles & NumberStyles.AllowParentheses) == 0) {
                    return CannotParse(out fraction); // not allowed
                }

                if (startIndex == endIndex - 1) {
                    return CannotParse(out fraction); // not enough characters
                }
                
                startIndex++; // consume the current character
                isNegative = true; // the closing parenthesis will be validated in the backwards iteration

                if (currencyDetected) {
                    // any number of white-spaces are allowed following a leading currency symbol (but no other signs)
                    numberStyles &= ~(NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowHexSpecifier);
                }
                else if (currencyAllowed && startsWith(fractionString, currencySymbol, startIndex)) {
                    // there can be no more currency symbols but there could be more white-spaces (we skip and continue) 
                    currencyDetected = true;
                    startIndex += currencySymbol.Length;
                    numberStyles &= ~(NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowHexSpecifier);
                } else {
                    // if next character is a white space the format should be rejected
                    numberStyles &= ~(NumberStyles.AllowLeadingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowHexSpecifier);
                    break;
                }

                continue;
            }

            if ((numberStyles & NumberStyles.AllowLeadingSign) != 0) {
                if (numberFormatInfo.NegativeSign.AsSpan() is { IsEmpty: false } negativeSign && startsWith(fractionString, negativeSign, startIndex)) {
                    isNegative = true;
                    startIndex += negativeSign.Length;
                    if (currencyDetected) {
                        // any number of white-spaces are allowed following a leading currency symbol (but no other signs)
                        numberStyles &= ~(NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowHexSpecifier);
                    }
                    else if (currencyAllowed && startsWith(fractionString, currencySymbol, startIndex)) {
                        // there can be no more currency symbols but there could be more white-spaces (we skip and continue) 
                        currencyDetected = true;
                        startIndex += currencySymbol.Length;
                        numberStyles &= ~(NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowHexSpecifier);
                    } else {
                        // if next character is a white space the format should be rejected
                        numberStyles &= ~(NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowLeadingWhite | NumberStyles.AllowHexSpecifier);
                        break;
                    }
                    
                    continue;
                }

                if (numberFormatInfo.PositiveSign.AsSpan() is { IsEmpty: false } positiveSign && startsWith(fractionString, positiveSign, startIndex)) {
                    isNegative = false;
                    startIndex += positiveSign.Length;
                    if (currencyDetected) {
                        // any number of white-spaces are allowed following a leading currency symbol (but no other signs)
                        numberStyles &= ~(NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowHexSpecifier);
                    }
                    else if (currencyAllowed && startsWith(fractionString, currencySymbol, startIndex)) {
                        // there can be no more currency symbols but there could be more white-spaces (we skip and continue) 
                        currencyDetected = true;
                        startIndex += currencySymbol.Length;
                        numberStyles &= ~(NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowHexSpecifier);
                    } else {
                        // if next character is a white space the format should be rejected
                        numberStyles &= ~(NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowLeadingWhite | NumberStyles.AllowHexSpecifier);
                        break;
                    }
                    
                    continue;
                }
            }

            if (currencyAllowed && !currencyDetected && startsWith(fractionString, currencySymbol, startIndex)) {
                // there can be no more currency symbols but there could be more white-spaces (we skip and continue)
                currencyDetected = true;
                numberStyles &= ~NumberStyles.AllowCurrencySymbol;
                startIndex += currencySymbol.Length;
                continue;
            }

            if (decimalsAllowed && startsWith(fractionString, decimalSeparator, startIndex)) {
                break; // decimal string with no leading zeros
            }

            // this is either an expected hex string or an invalid format
            return (numberStyles & NumberStyles.AllowHexSpecifier) != 0
                ? TryParseInteger(fractionString[startIndex..endIndex], numberStyles & ~NumberStyles.AllowTrailingSign, formatProvider, isNegative, out fraction)
                : CannotParse(out fraction); // unexpected character
        } while (startIndex < endIndex);

        if (startIndex >= endIndex) {
            return CannotParse(out fraction);
        }

        if (isNegative) {
            numberStyles &= ~(NumberStyles.AllowLeadingWhite | NumberStyles.AllowLeadingSign);
        } else {
            numberStyles &= ~(NumberStyles.AllowLeadingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowParentheses);
        }

        // examine the trailing characters
        do {
            var character = fractionString[endIndex - 1];
            if (char.IsDigit(character)) {
                break;
            }

            if (char.IsWhiteSpace(character)) {
                if ((numberStyles & NumberStyles.AllowTrailingWhite) == 0) {
                    return CannotParse(out fraction);
                }

                endIndex--;
                continue;
            }

            if (character == ')') {
                if ((numberStyles & NumberStyles.AllowParentheses) == 0) {
                    return CannotParse(out fraction); // not allowed
                }

                numberStyles &= ~(NumberStyles.AllowParentheses | NumberStyles.AllowCurrencySymbol);
                endIndex--;
                continue;
            }

            if ((numberStyles & NumberStyles.AllowTrailingSign) != 0) {
                if (numberFormatInfo.NegativeSign.AsSpan() is { IsEmpty: false } negativeSign && endsWith(fractionString, negativeSign, endIndex)) {
                    isNegative = true;
                    numberStyles &= ~(NumberStyles.AllowTrailingSign | NumberStyles.AllowHexSpecifier);
                    endIndex -= negativeSign.Length;
                    continue;
                }

                if (numberFormatInfo.PositiveSign.AsSpan() is { IsEmpty: false } positiveSign && endsWith(fractionString, positiveSign, endIndex)) {
                    isNegative = false;
                    numberStyles &= ~(NumberStyles.AllowTrailingSign | NumberStyles.AllowHexSpecifier);
                    endIndex -= positiveSign.Length;
                    continue;
                }
            }

            if (currencyAllowed && !currencyDetected && endsWith(fractionString, currencySymbol, endIndex)) {
                // there can be no more currency symbols but there could be more white-spaces (we skip and continue)
                currencyDetected = true;
                numberStyles &= ~NumberStyles.AllowCurrencySymbol;
                endIndex -= currencySymbol.Length;
                continue;
            }

            if (decimalsAllowed && endsWith(fractionString, decimalSeparator, endIndex)) {
                break;
            }

            // this is either an expected hex string or an invalid format
            return (numberStyles & NumberStyles.AllowHexSpecifier) != 0
                ? TryParseInteger(fractionString[startIndex..endIndex], numberStyles & ~NumberStyles.AllowTrailingSign, formatProvider, isNegative, out fraction)
                : CannotParse(out fraction); // unexpected character
        } while (startIndex < endIndex);

        if (startIndex >= endIndex) {
            return CannotParse(out fraction); // not enough characters
        }

        if (isNegative && (numberStyles & NumberStyles.AllowParentheses) != 0) {
            return CannotParse(out fraction); // failed to find a closing parentheses
        }

        numberStyles &= ~(NumberStyles.AllowTrailingWhite | NumberStyles.AllowTrailingSign | NumberStyles.AllowCurrencySymbol);
        // at this point fractionString[startIndex, endIndex] should correspond to the number without the sign (or the format is invalid)
        var unsignedValue = fractionString[startIndex..endIndex];

        if (unsignedValue.Length == 1) {
            // this can only be a single digit (integer)
            return TryParseInteger(unsignedValue, numberStyles, formatProvider, isNegative, out fraction);
        }

        if ((numberStyles & NumberStyles.AllowExponent) != 0) {
            return TryParseWithExponent(unsignedValue, numberStyles, numberFormatInfo, isNegative, out fraction);
        }

        return decimalsAllowed
            ? TryParseDecimalNumber(unsignedValue, numberStyles, numberFormatInfo, isNegative, out fraction)
            : TryParseInteger(unsignedValue, numberStyles, formatProvider, isNegative, out fraction);

        static bool startsWith(ReadOnlySpan<char> fractionString, ReadOnlySpan<char> testString, int startIndex) {
            return fractionString.Slice(startIndex, testString.Length).SequenceEqual(testString);
        }
        
        static bool endsWith(ReadOnlySpan<char> fractionString, ReadOnlySpan<char> testString, int endIndex) {
            return fractionString.Slice(endIndex - testString.Length, testString.Length).SequenceEqual(testString);
        }
    }

    private static bool TryParseWithExponent(ReadOnlySpan<char> value, NumberStyles parseNumberStyles, NumberFormatInfo numberFormatInfo, bool isNegative,
        out Fraction fraction) {
        // 1. try to find the exponent character (extracting the left and right sides)
        parseNumberStyles &= ~NumberStyles.AllowExponent;
        var ranges = new Span<Range>(new Range[2]);
        var nbRangesFilled = value.SplitAny(ranges, ['e', 'E']);

        if (nbRangesFilled != 2) {
            // no exponent found
            return (parseNumberStyles & NumberStyles.AllowDecimalPoint) != 0
                ? TryParseDecimalNumber(value, parseNumberStyles, numberFormatInfo, isNegative, out fraction)
                : TryParseInteger(value, parseNumberStyles, numberFormatInfo, isNegative, out fraction);
        }

        // 2. try to parse the exponent (w.r.t. the scientific notation format)
        var exponentSpan = value[ranges[1]];
        if (!int.TryParse(exponentSpan, NumberStyles.AllowLeadingSign | NumberStyles.Integer, numberFormatInfo, out var exponent)) {
            return CannotParse(out fraction);
        }

        // 3. try to parse the coefficient (w.r.t. the decimal separator allowance)
        var coefficientSpan = value[ranges[0]];
        if (coefficientSpan.IsEmpty) {
            return CannotParse(out fraction); // nothing in the coefficient
        }

        if (coefficientSpan.Length == 1 || (parseNumberStyles & NumberStyles.AllowDecimalPoint) == 0) {
            if (!TryParseInteger(coefficientSpan, parseNumberStyles, numberFormatInfo, isNegative, out fraction)) {
                return false;
            }
        } else {
            if (!TryParseDecimalNumber(coefficientSpan, parseNumberStyles, numberFormatInfo, isNegative, out fraction)) {
                return false;
            }
        }

        // 4. multiply the coefficient by 10 to the power of the exponent
        fraction *= Pow(TEN, exponent);
        return true;
    }

    private static bool TryParseDecimalNumber(ReadOnlySpan<char> value, NumberStyles parseNumberStyles, NumberFormatInfo numberFormatInfo, bool isNegative,
        out Fraction fraction) {
        // 1. try to find the decimal separator (extracting the left and right sides)
        var ranges = new Span<Range>(new Range[2]);
        var nbRangesFilled = value.Split(ranges, numberFormatInfo.NumberDecimalSeparator);
        
        if (nbRangesFilled != 2) {
            return TryParseInteger(value, parseNumberStyles, numberFormatInfo, isNegative, out fraction);
        }
        
        var integerSpan = value[ranges[0]];
        var fractionalSpan = value[ranges[1]];

        // 2. validate the format of the string after the radix
        if (integerSpan.IsEmpty && fractionalSpan.IsEmpty) {
            // after excluding the sign, the input was reduced to just the decimal separator (with nothing on either sides)
            return CannotParse(out fraction);
        }

        if (fractionalSpan.IsEmpty) {
            // after excluding the sign, the input was reduced to just an integer part (e.g. "1 234.")
            return TryParseInteger(integerSpan, parseNumberStyles, numberFormatInfo, isNegative, out fraction);
        }

        if ((parseNumberStyles & NumberStyles.AllowThousands) != 0) {
            if (fractionalSpan.Contains(numberFormatInfo.NumberGroupSeparator.AsSpan(), StringComparison.Ordinal)) {
                return CannotParse(out fraction);  // number group separator detected in the fractional part (e.g. "1.2 34")
            }
        }

        // 3. extract the value of the string corresponding to the number without the decimal separator: "0.123 " should return "0123"
        var integerString = string.Concat(integerSpan, fractionalSpan);
        if (!BigInteger.TryParse(integerString, parseNumberStyles, numberFormatInfo, out var numerator)) {
            return CannotParse(out fraction);
        }

        if (numerator.IsZero) {
            fraction = Zero;
            return true;
        }

        if (isNegative) {
            numerator = -numerator;
        }
        
        var nbDecimals = fractionalSpan.Length;
        if (nbDecimals == 0) {
            fraction = new Fraction(numerator);
            return true;
        }
        
        // 4. construct the fractional part using the corresponding decimal power for the denominator
        var denominator = BigInteger.Pow(TEN, nbDecimals);
        fraction = ReduceSigned(numerator, denominator);
        return true;
    }

    private static bool TryParseInteger(ReadOnlySpan<char> value, NumberStyles parseNumberStyles, IFormatProvider formatProvider, bool isNegative, out Fraction fraction) {
        if (!BigInteger.TryParse(value, parseNumberStyles, formatProvider, out var bigInteger)) {
            return CannotParse(out fraction);
        }

        fraction = new Fraction(isNegative ? -bigInteger: bigInteger);
        return true;
    }
    #else
    /// <summary>
    /// Try to convert a string to a fraction. Example: "3/4" or "4.5" (the decimal separator character depends on <paramref name="formatProvider"/>).
    /// If the number contains a decimal separator it will be parsed as <see cref="decimal"/>.
    /// </summary>
    /// <param name="fractionString">A fraction or a (decimal) number. The numerator and denominator must be separated with a '/' (slash) character.</param>
    /// <param name="numberStyles">A bitwise combination of number styles that are allowed in <paramref name="fractionString"/>.</param>
    /// <param name="formatProvider">Provides culture specific information that will be used to parse the <paramref name="fractionString"/>.</param>
    /// <param name="normalize">If <c>true</c> the parsed fraction will be reduced.</param>
    /// <param name="fraction">A <see cref="Fraction"/> if the method returns with <c>true</c>. Otherwise, the value is invalid.</param>
    /// <returns>
    /// <para><c>true</c> if <paramref name="fractionString"/> was well-formed. The parsing result will be written to <paramref name="fraction"/>. </para>
    /// <para><c>false</c> if <paramref name="fractionString"/> was invalid.</para>
    /// </returns>
    public static bool TryParse(string fractionString, NumberStyles numberStyles, IFormatProvider formatProvider, bool normalize, out Fraction fraction) {
        if (string.IsNullOrWhiteSpace(fractionString)) {
            return CannotParse(out fraction);
        }

        if (fractionString.Length == 1) {
            if (!BigInteger.TryParse(fractionString, numberStyles, formatProvider, out var singleDigit)) {
                return CannotParse(out fraction);
            }

            fraction = new Fraction(singleDigit);
            return true;
        }

        var components = fractionString.Split('/');

        if (components.Length >= 2) {
            var numeratorString = components[0];
            var denominatorString = components[1];

            var withoutDecimalPoint = numberStyles & ~NumberStyles.AllowDecimalPoint;
            if (!BigInteger.TryParse(
                    numeratorString,
                    withoutDecimalPoint,
                    formatProvider,
                    out var numerator)
                || !BigInteger.TryParse(
                    denominatorString,
                    withoutDecimalPoint,
                    formatProvider,
                    out var denominator)) {
                return CannotParse(out fraction);
            }

            fraction = new Fraction(numerator, denominator, normalize);
            return true;
        }

        // parsing a number using to the selected NumberStyles: e.g. " $ 12345.1234321e-4- " should result in -1.23451234321 with NumberStyles.Any
        var numberFormatInfo = NumberFormatInfo.GetInstance(formatProvider);
        // check for any of the special symbols (these cannot be combined with anything else)
        if (fractionString == numberFormatInfo.NaNSymbol) {
            fraction = NaN;
            return true;
        }

        if (fractionString == numberFormatInfo.PositiveInfinitySymbol) {
            fraction = PositiveInfinity;
            return true;
        }

        if (fractionString == numberFormatInfo.NegativeInfinitySymbol) {
            fraction = NegativeInfinity;
            return true;
        }

        var currencyAllowed = (numberStyles & NumberStyles.AllowCurrencySymbol) != 0;
        var currencyDetected = false; // there "special" rules regarding the white-spaces after a leading currency symbol is detected
        var currencySymbol = numberFormatInfo.CurrencySymbol;
        if (currencyAllowed && string.IsNullOrEmpty(currencySymbol)) {
            numberStyles &= ~NumberStyles.AllowCurrencySymbol; // no currency symbol available
            currencyAllowed = false;
        }

        var decimalSeparator = numberFormatInfo.NumberDecimalSeparator; // note: decimal.TryParse relies on the CurrencySymbol (when currency is detected)
        var decimalsAllowed = (numberStyles & NumberStyles.AllowDecimalPoint) != 0;
        if (decimalsAllowed && string.IsNullOrEmpty(decimalSeparator)) {
            numberStyles &= ~NumberStyles.AllowDecimalPoint; // no decimal separator available
            decimalsAllowed = false;
        }

        var startIndex = 0;
        var endIndex = fractionString.Length;
        var isNegative = false;

        // examine the leading characters
        do {
            var character = fractionString[startIndex];
            if (char.IsDigit(character)) {
                break;
            }

            if (char.IsWhiteSpace(character)) {
                if ((numberStyles & NumberStyles.AllowLeadingWhite) == 0) {
                    return CannotParse(out fraction);
                }

                startIndex++;
                continue;
            }

            if (character == '(') {
                if ((numberStyles & NumberStyles.AllowParentheses) == 0) {
                    return CannotParse(out fraction); // not allowed
                }

                if (startIndex == endIndex - 1) {
                    return CannotParse(out fraction); // not enough characters
                }
                
                startIndex++; // consume the current character
                isNegative = true; // the closing parenthesis will be validated in the backwards iteration

                if (currencyDetected) {
                    // any number of white-spaces are allowed following a leading currency symbol (but no other signs)
                    numberStyles &= ~(NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowHexSpecifier);
                }
                else if (currencyAllowed && startsWith(fractionString, currencySymbol, startIndex)) {
                    // there can be no more currency symbols but there could be more white-spaces (we skip and continue) 
                    currencyDetected = true;
                    startIndex += currencySymbol.Length;
                    numberStyles &= ~(NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowHexSpecifier);
                } else {
                    // if next character is a white space the format should be rejected
                    numberStyles &= ~(NumberStyles.AllowLeadingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowHexSpecifier);
                    break;
                }

                continue;
            }

            if ((numberStyles & NumberStyles.AllowLeadingSign) != 0) {
                if (numberFormatInfo.NegativeSign is { Length: > 0 } negativeSign && startsWith(fractionString, negativeSign, startIndex)) {
                    isNegative = true;
                    startIndex += negativeSign.Length;
                    if (currencyDetected) {
                        // any number of white-spaces are allowed following a leading currency symbol (but no other signs)
                        numberStyles &= ~(NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowHexSpecifier);
                    }
                    else if (currencyAllowed && startsWith(fractionString, currencySymbol, startIndex)) {
                        // there can be no more currency symbols but there could be more white-spaces (we skip and continue) 
                        currencyDetected = true;
                        startIndex += currencySymbol.Length;
                        numberStyles &= ~(NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowHexSpecifier);
                    } else {
                        // if next character is a white space the format should be rejected
                        numberStyles &= ~(NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowLeadingWhite | NumberStyles.AllowHexSpecifier);
                        break;
                    }
                    
                    continue;
                }

                if (numberFormatInfo.PositiveSign is { Length: > 0 } positiveSign && startsWith(fractionString, positiveSign, startIndex)) {
                    isNegative = false;
                    startIndex += positiveSign.Length;
                    if (currencyDetected) {
                        // any number of white-spaces are allowed following a leading currency symbol (but no other signs)
                        numberStyles &= ~(NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowHexSpecifier);
                    }
                    else if (currencyAllowed && startsWith(fractionString, currencySymbol, startIndex)) {
                        // there can be no more currency symbols but there could be more white-spaces (we skip and continue) 
                        currencyDetected = true;
                        startIndex += currencySymbol.Length;
                        numberStyles &= ~(NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowHexSpecifier);
                    } else {
                        // if next character is a white space the format should be rejected
                        numberStyles &= ~(NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowLeadingWhite | NumberStyles.AllowHexSpecifier);
                        break;
                    }

                    continue;
                }
            }

            if (currencyAllowed && !currencyDetected && startsWith(fractionString, currencySymbol, startIndex)) {
                // there can be no more currency symbols but there could be more white-spaces (we skip and continue)
                currencyDetected = true;
                numberStyles &= ~NumberStyles.AllowCurrencySymbol;
                startIndex += currencySymbol.Length;
                continue;
            }

            if (decimalsAllowed && startsWith(fractionString, decimalSeparator, startIndex)) {
                break; // decimal string with no leading zeros
            }

            // this is either an expected hex string or an invalid format
            return (numberStyles & NumberStyles.AllowHexSpecifier) != 0
                ? TryParseInteger(fractionString, numberStyles & ~NumberStyles.AllowTrailingSign, formatProvider, startIndex, endIndex, isNegative, out fraction)
                : CannotParse(out fraction); // unexpected character
        } while (startIndex < endIndex);

        if (startIndex >= endIndex) {
            return CannotParse(out fraction);
        }

        if (isNegative) {
            numberStyles &= ~(NumberStyles.AllowLeadingWhite | NumberStyles.AllowLeadingSign);
        } else {
            numberStyles &= ~(NumberStyles.AllowLeadingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowParentheses);
        }

        // examine the trailing characters
        do {
            var character = fractionString[endIndex - 1];
            if (char.IsDigit(character)) {
                break;
            }

            if (char.IsWhiteSpace(character)) {
                if ((numberStyles & NumberStyles.AllowTrailingWhite) == 0) {
                    return CannotParse(out fraction);
                }

                endIndex--;
                continue;
            }

            if (character == ')') {
                if ((numberStyles & NumberStyles.AllowParentheses) == 0) {
                    return CannotParse(out fraction); // not allowed
                }

                numberStyles &= ~(NumberStyles.AllowParentheses | NumberStyles.AllowCurrencySymbol);
                endIndex--;
                continue;
            }

            if ((numberStyles & NumberStyles.AllowTrailingSign) != 0) {
                if (numberFormatInfo.NegativeSign is { Length: > 0 } negativeSign && endsWith(fractionString, negativeSign, endIndex)) {
                    isNegative = true;
                    numberStyles &= ~(NumberStyles.AllowTrailingSign | NumberStyles.AllowHexSpecifier);
                    endIndex -= negativeSign.Length;
                    continue;
                }

                if (numberFormatInfo.PositiveSign is { Length: > 0 } positiveSign && endsWith(fractionString, positiveSign, endIndex)) {
                    isNegative = false;
                    numberStyles &= ~(NumberStyles.AllowTrailingSign | NumberStyles.AllowHexSpecifier);
                    endIndex -= positiveSign.Length;
                    continue;
                }
            }

            if (currencyAllowed && !currencyDetected && endsWith(fractionString, currencySymbol, endIndex)) {
                // there can be no more currency symbols but there could be more white-spaces (we skip and continue)
                currencyDetected = true;
                numberStyles &= ~NumberStyles.AllowCurrencySymbol;
                endIndex -= currencySymbol.Length;
                continue;
            }

            if (decimalsAllowed && endsWith(fractionString, decimalSeparator, endIndex)) {
                break;
            }

            // this is either an expected hex string or an invalid format
            return (numberStyles & NumberStyles.AllowHexSpecifier) != 0
                ? TryParseInteger(fractionString, numberStyles & ~NumberStyles.AllowTrailingSign, formatProvider, startIndex, endIndex, isNegative, out fraction)
                : CannotParse(out fraction); // unexpected character
        } while (startIndex < endIndex);

        if (startIndex >= endIndex) {
            return CannotParse(out fraction); // not enough characters
        }

        if (isNegative && (numberStyles & NumberStyles.AllowParentheses) != 0) {
            return CannotParse(out fraction); // failed to find a closing parentheses
        }

        numberStyles &= ~(NumberStyles.AllowTrailingWhite | NumberStyles.AllowTrailingSign | NumberStyles.AllowCurrencySymbol);
        // at this point fractionString[startIndex, endIndex] should correspond to the number without the sign (or the format is invalid)

        if (startIndex == endIndex - 1) {
            // this can only be a single digit (integer)
            return TryParseInteger(fractionString, numberStyles, formatProvider, startIndex, endIndex, isNegative, out fraction);
        }

        if ((numberStyles & NumberStyles.AllowExponent) != 0) {
            return TryParseWithExponent(fractionString, numberStyles, numberFormatInfo, startIndex, endIndex, isNegative, out fraction);
        }

        return decimalsAllowed
            ? TryParseDecimalNumber(fractionString, numberStyles, numberFormatInfo, startIndex, endIndex, isNegative, out fraction)
            : TryParseInteger(fractionString, numberStyles, formatProvider, startIndex, endIndex, isNegative, out fraction);

        static bool startsWith(string fractionString, string testString, int startIndex) {
            if (fractionString.Length - startIndex < testString.Length) {
                return false;
            }

            for (var i = 0; i < testString.Length; i++) {
                if (fractionString[i + startIndex] != testString[i]) {
                    return false;
                }
            }

            return true;
        }

        static bool endsWith(string fractionString, string testString, int endIndex) {
            return startsWith(fractionString, testString, endIndex - testString.Length);
        }
    }

    private static bool TryParseWithExponent(string valueString, NumberStyles parseNumberStyles, NumberFormatInfo numberFormatInfo,
        int startIndex, int endIndex, bool isNegative, out Fraction fraction) {
        // 1. try to find the exponent character index
        parseNumberStyles &= ~NumberStyles.AllowExponent;
        var exponentIndex = valueString.IndexOfAny(['e', 'E'], startIndex + 1, endIndex - startIndex - 1);
        if (exponentIndex == -1) {
            // no exponent found
            return (parseNumberStyles & NumberStyles.AllowDecimalPoint) != 0
                ? TryParseDecimalNumber(valueString, parseNumberStyles, numberFormatInfo, startIndex, endIndex, isNegative, out fraction)
                : TryParseInteger(valueString, parseNumberStyles, numberFormatInfo, startIndex, endIndex, isNegative, out fraction);
        }

        if (startIndex == exponentIndex) {
            return CannotParse(out fraction); // no characters on the left of the exponent symbol
        }

        // 2. try to parse the exponent (w.r.t. the scientific notation format)
        var exponentString = valueString.Substring(exponentIndex + 1, endIndex - exponentIndex - 1);
        if (!int.TryParse(exponentString, NumberStyles.AllowLeadingSign | NumberStyles.Integer, numberFormatInfo, out var exponent)) {
            return CannotParse(out fraction);
        }
        
        // 3. try to parse the coefficient (w.r.t. the decimal separator allowance)
        if (startIndex == endIndex - 1 || (parseNumberStyles & NumberStyles.AllowDecimalPoint) == 0) {
            if (!TryParseInteger(valueString, parseNumberStyles, numberFormatInfo, startIndex, exponentIndex, isNegative, out fraction)) {
                return false;
            }
        } else {
            if (!TryParseDecimalNumber(valueString, parseNumberStyles, numberFormatInfo, startIndex, exponentIndex, isNegative, out fraction)) {
                return false;
            }
        }
        
        // 4. multiply the coefficient by 10 to the power of the exponent
        fraction *= Pow(TEN, exponent);
        return true;
    }

    private static bool TryParseDecimalNumber(string valueString, NumberStyles parseNumberStyles, NumberFormatInfo numberFormatInfo,
        int startIndex, int endIndex, bool isNegative, out Fraction fraction) {
        // 1. find the position of the decimal separator (if any)
        var decimalSeparatorIndex = valueString.IndexOf(numberFormatInfo.NumberDecimalSeparator, startIndex, endIndex - startIndex, StringComparison.Ordinal);
        if (decimalSeparatorIndex == -1) {
            return TryParseInteger(valueString, parseNumberStyles, numberFormatInfo, startIndex, endIndex, isNegative, out fraction);
        }

        // 2. validate the format of the string after the radix
        var decimalSeparatorLength = numberFormatInfo.NumberDecimalSeparator.Length;
        if (startIndex + decimalSeparatorLength == endIndex) {
            // after excluding the sign, the input was reduced to just the decimal separator (with nothing on either sides)
            return CannotParse(out fraction);
        }

        if ((parseNumberStyles & NumberStyles.AllowThousands) != 0) {
            if (valueString.IndexOf(numberFormatInfo.NumberGroupSeparator, decimalSeparatorIndex + decimalSeparatorLength, StringComparison.Ordinal) != -1) {
                return CannotParse(out fraction);
            }
        }

        // 3. extract the value of the string corresponding to the number without the decimal separator: " 0.123 " should return "0123"
        var integerString = string.Concat(
            valueString.Substring(startIndex, decimalSeparatorIndex - startIndex),
            valueString.Substring(decimalSeparatorIndex + decimalSeparatorLength, endIndex - decimalSeparatorIndex - decimalSeparatorLength));

        if (!BigInteger.TryParse(integerString, parseNumberStyles, numberFormatInfo, out var numerator)) {
            return CannotParse(out fraction);
        }

        if (numerator.IsZero) {
            fraction = Zero;
            return true;
        }

        var nbDecimals = endIndex - decimalSeparatorIndex - decimalSeparatorLength;
        if (nbDecimals == 0) {
            fraction = new Fraction(isNegative ? -numerator : numerator);
            return true;
        }

        // 4. construct the fractional part using the corresponding decimal power for the denominator
        var denominator = BigInteger.Pow(TEN, nbDecimals);
        fraction = ReduceSigned(isNegative ? -numerator : numerator, denominator);
        return true;
    }
    
    private static bool TryParseInteger(string valueString, NumberStyles parseNumberStyles, IFormatProvider formatProvider,
        int startIndex, int endIndex, bool isNegative, out Fraction fraction) {
        if (!BigInteger.TryParse(valueString.Substring(startIndex, endIndex - startIndex), parseNumberStyles, formatProvider, out var bigInteger)) {
            return CannotParse(out fraction);
        }

        fraction = new Fraction(isNegative ? -bigInteger : bigInteger);
        return true;
    }
    #endif
    
    /// <summary>
    /// Returns false. <paramref name="fraction"/> contains an invalid value.
    /// </summary>
    /// <param name="fraction">Returns <c>default()</c> of <see cref="Fraction"/></param>
    /// <returns><c>false</c></returns>
    private static bool CannotParse(out Fraction fraction) {
        fraction = default;
        return false;
    }

    /// <summary>
    ///     Converts a floating point value to a fraction. Due to the fact that no rounding is applied to the input, values
    ///     such as 0.2 or 0.3, which do not have an exact representation as a <see cref="double" />, would result in
    ///     very large values in the numerator and denominator.
    /// </summary>
    /// <param name="value">A floating point value.</param>
    /// <returns>A fraction corresponding to the binary floating-point representation of the value</returns>
    /// <exception cref="InvalidNumberException">If <paramref name="value" /> is NaN (not a number) or infinite.</exception>
    /// <remarks>
    ///     The <see cref="double"/> data type in C# uses a binary floating-point representation, which can't accurately represent all
    ///     decimal fractions. When you convert a <see cref="double"/> to a <see cref="Fraction"/> using this method, the resulting fraction is an
    ///     exact representation of the <see cref="double"/> value, not the decimal number that the <see cref="double"/> is intended to approximate.
    ///     This is why you can end up with large numerators and denominators.
    ///     <code>
    /// var value = Fraction.FromDouble(0.1);
    /// Console.WriteLine(value);  // Outputs "3602879701896397/36028797018963968"
    /// </code>
    ///     The output fraction is an exact representation of the <see cref="double"/> value 0.1, which is actually slightly more than 0.1
    ///     due to the limitations of binary floating-point representation.
    /// <para>
    ///     Additionally, as the <see cref="double"/> value approaches the limits of its precision,
    ///     `Fraction.FromDouble(value).ToDouble() == value` might not hold true. This is because the numerator and denominator
    ///     of the <see cref="Fraction"/> are both very large numbers. When these numbers are converted to <see cref="double"/> for the division
    ///     operation in the <see cref="ToDouble"/> method, they can exceed the precision limit of the <see cref="double"/> type, resulting in
    ///     a loss of precision.
    /// </para>
    ///     <code>
    /// var value = Fraction.FromDouble(double.Epsilon);
    /// Console.WriteLine(value.ToDouble() == double.Epsilon);  // Outputs "False"
    /// </code>
    ///     For more information, visit the
    ///     <see href="https://github.com/danm-de/Fractions?tab=readme-ov-file#creation-from-double-without-rounding">
    ///         official GitHub repository
    ///         page.
    ///     </see>
    /// </remarks>
    public static Fraction FromDouble(double value) {
        // No rounding here! It will convert the actual number that is stored as double! 
        // See https://csharpindepth.com/Articles/FloatingPoint
        const ulong SIGN_BIT = 0x8000000000000000;
        const ulong EXPONENT_BITS = 0x7FF0000000000000;
        const ulong MANTISSA = 0x000FFFFFFFFFFFFF;
        const ulong MANTISSA_DIVISOR = 0x0010000000000000;
        const ulong K = 1023;

        // value = (-1 * sign)   *   (1 + 2^(-1) + 2^(-2) .. + 2^(-52))   *   2^(exponent-K)
        var valueBits = unchecked((ulong)BitConverter.DoubleToInt64Bits(value));

        if (valueBits == 0) {
            // See IEEE 754
            return Zero;
        }

        var isNegative = (valueBits & SIGN_BIT) == SIGN_BIT;
        var mantissaBits = valueBits & MANTISSA;

        // (exponent-K)
        var exponentBits = (valueBits & EXPONENT_BITS);

        if (exponentBits == EXPONENT_BITS) {
            // NaN or Infinity
            if (mantissaBits != 0) {
                return NaN;
            }

            // Infinity
            return isNegative
                ? NegativeInfinity
                : PositiveInfinity;
        }

        var exponent = (int)((exponentBits >> 52) - K);

        // TODO test without normalization
        // (1 + 2^(-1) + 2^(-2) .. + 2^(-52))
        var mantissa = new Fraction(mantissaBits + MANTISSA_DIVISOR, MANTISSA_DIVISOR);

        var factorSign = isNegative ? BigInteger.MinusOne : BigInteger.One;
        // 2^exponent
        var factor = exponent < 0
            ? new Fraction(factorSign, BigInteger.One << -exponent)
            : new Fraction(factorSign << exponent);

        return mantissa * factor;
    }

    /// <summary>
    ///     Converts a floating point value to a fraction by rounding to the nearest rational number.
    ///     This method is designed to avoid large numbers in the numerator and denominator.
    /// </summary>
    /// <param name="value">A floating point value.</param>
    /// <returns>
    ///     A fraction that approximates the input value, rounded to the nearest rational number. If converted back to
    ///     double, it would produce the same value.
    /// </returns>
    /// <exception cref="InvalidNumberException">If <paramref name="value" /> is NaN (not a number) or infinite.</exception>
    /// <remarks>
    ///     This method is the fastest among the three methods for converting a double to a fraction. However, it shouldn't be
    ///     used for strict comparisons with other fractions due to the heuristic approach it uses.
    ///     This approach is not guaranteed to produce the exact rational representation of the input. This is demonstrated in
    ///     the following example:
    ///     <code>
    ///     var doubleValue = 1055.05585262;
    ///     var roundedValue = Fraction.FromDoubleRounded(doubleValue);      // returns {4085925351/3872710} which is 1055.0558526199999483565771772222
    ///     var literalValue = Fraction.FromDoubleRounded(doubleValue, 15);  // returns {52752792631/50000000} which is 1055.05585262 exactly
    ///     Console.WriteLine(roundedValue.CompareTo(literalValue); // Outputs "-1" which stands for "smaller than"
    ///     Console.WriteLine(roundedValue.ToDouble() == doubleValue); // Outputs "true" as the actual difference is smaller than the precision of the doubles
    ///     </code>
    ///     For more information, visit the
    ///     <see href="https://github.com/danm-de/Fractions?tab=readme-ov-file#creation-from-double-with-maximum-number-of-significant-digits">
    ///         official GitHub repository
    ///         page.
    ///     </see>
    /// </remarks>
    public static Fraction FromDoubleRounded(double value) {
        if (double.IsPositiveInfinity(value)) {
            return PositiveInfinity;
        }

        if (double.IsNegativeInfinity(value)) {
            return NegativeInfinity;
        }

        if (double.IsNaN(value)) {
            return NaN;
        }

        if (value == 0d) {
            return Zero;
        }

        // Inspired from Syed Mehroz Alam <smehrozalam@yahoo.com> http://www.geocities.ws/smehrozalam/source/fractioncs.txt
        // .. who got it from http://ebookbrowse.com/confrac-pdf-d13212190 
        // or ftp://89.25.159.69/knm/ksiazki/reszta/homepage.smc.edu.kennedy_john/CONFRAC.pdf
        var sign = Math.Sign(value);
        var absoluteValue = Math.Abs(value);

        var numerator = new BigInteger(absoluteValue);
        var denominator = 1.0;
        var remainingDigits = absoluteValue;
        var previousDenominator = 0.0;
        var breakCounter = 0;

        while (MathExt.RemainingDigitsAfterTheDecimalPoint(remainingDigits)
               && Math.Abs(absoluteValue - (double)numerator / denominator) > double.Epsilon) {
            remainingDigits = 1.0 / (remainingDigits - Math.Floor(remainingDigits));

            var tmp = denominator;

            denominator = Math.Floor(remainingDigits) * denominator + previousDenominator;
            numerator = new BigInteger(absoluteValue * denominator + 0.5);

            previousDenominator = tmp;

            // See http://www.ozgrid.com/forum/archive/index.php/t-22530.html
            if (++breakCounter > 594) {
                break;
            }
        }

        return ReduceSigned(
            sign < 0 ? -numerator : numerator,
            new BigInteger(denominator));
    }


    /// <summary>
    ///     Converts a floating point value to a Fraction by rounding to the nearest rational number with a specified number of
    ///     significant digits.
    ///     <para>
    ///         This method is designed to avoid large numbers in the numerator and denominator while also making the resulting
    ///         <see cref="Fraction" /> safe to
    ///         use in comparison operations with other fractions.
    ///     </para>
    /// </summary>
    /// <param name="value">The floating point value to convert.</param>
    /// <param name="significantDigits">The maximum number of significant digits to consider when rounding the value.</param>
    /// <returns>A Fraction representing the rounded floating point value.</returns>
    /// <remarks>
    ///     The double data type stores its values as 64-bit floating point numbers in accordance with the <see href="https://en.wikipedia.org/wiki/IEEE_754">IEC 60559:1989 (IEEE
    ///     754)</see> standard for binary <see href="https://en.wikipedia.org/wiki/Floating-point_arithmetic">floating-point arithmetic</see>.
    ///     However, the double data type cannot precisely store some binary fractions. For instance, 1/10, which is accurately
    ///     represented by .1 as a decimal fraction, is represented by .0001100110011... as a binary fraction, with the pattern
    ///     0011 repeating indefinitely.
    ///     In such cases, the floating-point value provides an approximate representation of the number.
    ///     <para>
    ///         This method can be used to avoid large numbers in the numerator and denominator while also making it safe to
    ///         use in comparison operations with other fractions.
    ///         <code>
    /// Fraction value = Fraction.FromDoubleRounded(0.1, 15); // returns {1/10}, which is exactly 0.1 
    /// </code>
    ///     </para>
    ///     <para>
    ///         If you care only about minimizing the size of the numerator/denominator, and do not expect to use the
    ///         fraction in any strict comparison operations, then creating an approximated fraction using the
    ///         <see cref="FromDoubleRounded(double)" /> overload should offer much better performance.
    ///     </para>
    ///     For more information, visit the
    ///     <see
    ///         href="https://github.com/danm-de/Fractions?tab=readme-ov-file#creation-from-double-with-rounding-to-a-close-approximation">
    ///         official GitHub repository
    ///         page.
    ///     </see>
    /// </remarks>
    public static Fraction FromDoubleRounded(double value, int significantDigits) {
        switch (value) {
            case 0d:
                return Zero;
            case double.NaN:
                return NaN;
            case double.PositiveInfinity:
                return PositiveInfinity;
            case double.NegativeInfinity:
                return NegativeInfinity;
        }

        // Determine the number of decimal places to keep
        var magnitude = Math.Floor(Math.Log10(Math.Abs(value)));
        if (magnitude > significantDigits) {
            var digitsToKeep = new BigInteger(value / Math.Pow(10, magnitude - significantDigits));
            return digitsToKeep * BigInteger.Pow(TEN, (int)magnitude - significantDigits);
        }

        // "decimal" values
        var truncatedValue = Math.Truncate(value);
        var integerPart = new BigInteger(truncatedValue);

        var decimalPlaces = Math.Min(-(int)magnitude + significantDigits - 1, 308);
        var scaleFactor = Math.Pow(10, decimalPlaces);
        // Get the fractional part
        var fractionalPartDouble = Math.Round((value - truncatedValue) * scaleFactor);
        if (fractionalPartDouble == 0) // rounded to integer
        {
            return new Fraction(integerPart);
        }

        var denominator = BigInteger.Pow(TEN, decimalPlaces);
        var numerator = integerPart * denominator + new BigInteger(fractionalPartDouble);
        return ReduceSigned(numerator, denominator);
    }


    /// <summary>
    /// Converts a decimal value in a fraction. The value will not be rounded.
    /// </summary>
    /// <param name="value">A decimal value.</param>
    /// <returns>A fraction.</returns>
    public static Fraction FromDecimal(decimal value) {
        switch (value) {
            case decimal.Zero:
                return Zero;
            case decimal.One:
                return One;
            case decimal.MinusOne:
                return MinusOne;
        }

        var bits = decimal.GetBits(value);
        var low = BitConverter.GetBytes(bits[0]);
        var middle = BitConverter.GetBytes(bits[1]);
        var high = BitConverter.GetBytes(bits[2]);
        var scale = BitConverter.GetBytes(bits[3]);

        var exp = scale[2];
        var positiveSign = (scale[3] & 0x80) == 0;

        // value = 0x00,high,middle,low / 10^exp
        var numerator = new BigInteger([
            low[0], low[1], low[2], low[3],
            middle[0], middle[1], middle[2], middle[3],
            high[0], high[1], high[2], high[3],
            0x00
        ]);
        var denominator = BigInteger.Pow(TEN, exp);

        return ReduceSigned(positiveSign ? numerator : -numerator, denominator);
    }
}
