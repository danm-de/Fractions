using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using FluentAssertions;
using Fractions.Formatter;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.StringFormatters;

public abstract class DecimalNotationFormatterSpecs : Spec {
    protected static readonly DecimalNotationFormatter DecimalFormatter = DecimalNotationFormatter.Instance;

    protected static readonly CultureInfo AmericanCulture = CultureInfo.GetCultureInfo("en-US");
    protected static readonly CultureInfo NorwegianCulture = CultureInfo.GetCultureInfo("nb-NO");
    protected static readonly CultureInfo RussianCulture = CultureInfo.GetCultureInfo("ru-RU");

    protected static readonly IFormatProvider[] FormatProviders = [
        null,
        AmericanCulture,
        NorwegianCulture,
        RussianCulture
    ];

    protected static readonly Fraction[] TerminatingFractions = [
        0, 1, -1, 10, -10, 100, -100, 1000, -1000, 10000, -10000, 100000, -100000,
        0.1m, -0.1m, 0.2m, -0.2m, 0.5m, -0.5m, 1.2m, -1.2m, 1.5m, -1.5m, 1.95m, -1.95m, 2.5m, -2.5m,
        0.000015545665434654m, -0.000015545665434654m,
        0.00015545665434654m, -0.00015545665434654m,
        0.0015545665434654m, -0.0015545665434654m,
        0.015545665434654m, -0.015545665434654m,
        0.15545665434654m, -0.15545665434654m,
        1.5545665434654m, -1.5545665434654m,
        15.545665434654m, -15.545665434654m,
        155.45665434654m, -155.45665434654m,
        1554.5665434654m, -1554.5665434654m,
        15545.665434654m, -15545.665434654m,
        155456.65434654m, -155456.65434654m,
        1554566.5434654m, -1554566.5434654m,
        new Fraction(-10, -20, false), new Fraction(10, -20, false),
        // 128 in binary is 10000000, so its bit length is 8. 1400 is between 2^10 (1024) and 2^11 (2048), so its bit length is 11.
        new Fraction(128, 1400, false), new Fraction(-128, 1400, false)
    ];

    protected static readonly Fraction[] NonTerminatingFractions = [
        new Fraction(1, 3), new Fraction(-1, 3),
        new Fraction(2, 3), new Fraction(-2, 3),
        new Fraction(19999991, 3),
        new Fraction(-19999991, 3), // note: for all but the percent (P) format we could be using two more digits ('99')
        new Fraction(20000001, 3),
        new Fraction(-20000001, 3), // note: for all but the percent (P) format we could be using two more digits ('00')
        new Fraction(4, 3), new Fraction(-4, 3),
        new Fraction(5, 3), new Fraction(-5, 3),
        new Fraction(7, 3), new Fraction(-7, 3),
    ];

    /// <summary>
    /// <see cref="Fraction.PositiveInfinity"/>, <see cref="Fraction.NegativeInfinity"/> and <see cref="Fraction.NaN"/>
    /// </summary>
    protected static readonly Fraction[] SpecialFractions =
        [Fraction.PositiveInfinity, Fraction.NegativeInfinity, Fraction.NaN];
}

/// <summary>
///     The general ("G") format specifier converts a number to the more compact of either fixed-point or scientific
///     notation, depending on the type of the number and whether a precision specifier is present. The precision specifier
///     defines the maximum number of significant digits that can appear in the result string. If the precision specifier
///     is omitted or zero, the type of the number determines the default precision.
/// </summary>
[TestFixture]
public class When_formatting_a_fraction_using_the_general_format : DecimalNotationFormatterSpecs {
    private static readonly string[] GeneralFormats =
        ["G1", "G2", "G3", "G4", "G5", "G6", "g1", "g6"];

    public static IEnumerable<TestCaseData> FormatWithFiniteFractionCases =>
        from stringFormat in GeneralFormats
        from valueToTest in TerminatingFractions.Concat(NonTerminatingFractions)
        from cultureToTest in FormatProviders
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDecimal().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(FormatWithFiniteFractionCases))]
    public string The_general_format_should_match_decimal_ToString_if_the_fraction_is_finite(Fraction valueToTest,
        string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }
    
    public static IEnumerable<TestCaseData> GeneralFormatSupportHighPrecisionCases {
        get {
            var formatProvider = CultureInfo.InvariantCulture;
            var valueToTest = Fraction.FromString("123456789987654321.123456789987654321", AmericanCulture);

            yield return new TestCaseData(valueToTest, "G17", formatProvider)
                .Returns("1.2345678998765432E+17");
            yield return new TestCaseData(valueToTest, "G18", formatProvider)
                .Returns("123456789987654321");
            yield return new TestCaseData(valueToTest, "G19", formatProvider)
                .Returns("123456789987654321.1");
            yield return new TestCaseData(valueToTest, "G35", formatProvider)
                .Returns("123456789987654321.12345678998765432");
            yield return new TestCaseData(valueToTest, "G36", formatProvider)
                .Returns("123456789987654321.123456789987654321");
            yield return new TestCaseData(valueToTest, "G37", formatProvider)
                .Returns("123456789987654321.123456789987654321");
        }
    }

    [Test]
    [TestCaseSource(nameof(GeneralFormatSupportHighPrecisionCases))]
    public string The_general_format_support_high_precision(Fraction valueToTest, string format,
        IFormatProvider formatProvider) {
        return DecimalFormatter.Format(format, valueToTest, formatProvider);
    }

#if NET
    [Test]
    public void The_default_precision_specifier_is_16_digits_after_the_decimal_point(
        [Values(null, "G", "G0", "g", "g0")] string format) {
        // Arrange
        var fraction = new Fraction(0.123456789987654321m);
        // Act
        var result = DecimalFormatter.Format(format, fraction, null);
        // Assert
        result.Should().Be(DecimalFormatter.Format("G16", fraction, null));
    }
#else
    [Test]
    public void The_default_precision_specifier_is_15_digits_after_the_decimal_point(
        [Values(null, "G", "G0", "g", "g0")] string format) {
        // Arrange
        var fraction = new Fraction(0.123456789987654321m);
        // Act
        var result = DecimalFormatter.Format(format, fraction, null);
        // Assert
        result.Should().Be(DecimalFormatter.Format("G15", fraction, null));
    }
#endif

}

/// <summary>
///     The fixed-point ("F") format specifier converts a number to a string of the form "-ddd.ddd…" where each "d"
///     indicates a digit (0-9). The string starts with a minus sign if the number is negative.
///     The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted, the
///     current NumberFormatInfo.NumberDecimalDigits property supplies the numeric precision.
/// </summary>
[TestFixture]
public class When_formatting_a_fraction_using_the_fixed_point_format : DecimalNotationFormatterSpecs {
    private static readonly string[] FixedPointFormats =
        ["F", "F0", "F1", "F2", "F3", "F4", "F5", "F6"];

    public static IEnumerable<TestCaseData> FixedPointFormatsToTest =>
        from stringFormat in FixedPointFormats
        from valueToTest in TerminatingFractions.Concat(NonTerminatingFractions)
        from cultureToTest in FormatProviders
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDecimal().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(FixedPointFormatsToTest))]
    public string The_fixed_point_format_should_match_decimal_ToString(Fraction valueToTest, string stringFormat,
        IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    public static IEnumerable<TestCaseData> FixedPointFormatSupportsHighPrecisionCases {
        get {
            var valueToTest = Fraction.FromString("123456789987654321.123456789987654321", AmericanCulture);
            var formatProvider = CultureInfo.InvariantCulture;

            yield return new TestCaseData(valueToTest, "F17", formatProvider)
                .Returns("123456789987654321.12345678998765432");
            yield return new TestCaseData(valueToTest, "F18", formatProvider)
                .Returns("123456789987654321.123456789987654321");
            yield return new TestCaseData(valueToTest, "F19", formatProvider)
                .Returns("123456789987654321.1234567899876543210");
        }
    }

    [Test]
    [TestCaseSource(nameof(FixedPointFormatSupportsHighPrecisionCases))]
    public string The_fixed_point_format_supports_high_precision(Fraction valueToTest, string format,
        IFormatProvider formatProvider) {
        return DecimalFormatter.Format(format, valueToTest, formatProvider);
    }
}

/// <summary>
///     The numeric ("N") format specifier converts a number to a string of the form "-d,ddd,ddd.ddd…", where "-" indicates
///     a negative number symbol if required, "d" indicates a digit (0-9), "," indicates a group separator, and "."
///     indicates a decimal point symbol. The precision specifier indicates the desired number of digits after the decimal
///     point. If the precision specifier is omitted, the number of decimal places is defined by the current
///     NumberFormatInfo.NumberDecimalDigits property.
/// </summary>
[TestFixture]
public class When_formatting_a_fraction_with_the_numeric_format : DecimalNotationFormatterSpecs {
    private static readonly string[] NumberFormats =
        ["N", "N0", "N1", "N2", "N3", "N4", "N5", "N6"];

    public static readonly int[] NumberNegativePatterns = [
        0, // (n)
        1, // -n
        2, // - n
        3, // n-
        4 // n -
    ];

    [Test]
    public void NumberFormat_with_invalid_NumberNegativePattern_ThrowsArgumentOutOfRangeException()
    {
        var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        var numberFormat = formatProvider.NumberFormat;
        Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.NumberNegativePattern = -1);
        Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.NumberNegativePattern = 5);
    }

    [Test]
    public void NumberFormat_with_invalid_NumberDecimalDigits_ThrowsArgumentOutOfRangeException()
    {
        var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        var numberFormat = formatProvider.NumberFormat;
        Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.NumberDecimalDigits = -1);
        Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.NumberDecimalDigits = 100);
    }

    public static IEnumerable<TestCaseData> NumberFormatsToTest =>
        from stringFormat in NumberFormats
        from valueToTest in TerminatingFractions.Concat(NonTerminatingFractions)
        from cultureToTest in FormatProviders
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDecimal().ToString(stringFormat, cultureToTest));

    public static IEnumerable<TestCaseData> NumberNegativePatternsToTest =>
        from stringFormat in NumberFormats
        from valueToTest in new Fraction[] { 0, -0.1m, -1, -1.23456789m }
        from cultureToTest in NumberNegativePatterns.Select(pattern => {
            var culture = (CultureInfo)AmericanCulture.Clone();
            culture.NumberFormat.NumberNegativePattern = pattern;
            return culture;
        })
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDecimal().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(NumberFormatsToTest))]
    public string The_number_format_should_match_decimal_ToString(Fraction valueToTest, string stringFormat,
        IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    [Test]
    [TestCaseSource(nameof(NumberNegativePatternsToTest))]
    public string The_numeric_format_should_respect_the_number_negative_patterns(Fraction valueToTest,
        string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    public static IEnumerable<TestCaseData> StandardNumberFormatSupportsHighPrecisionCases {
        get {
            var valueToTest = Fraction.FromString("123456789987654321.123456789987654321", AmericanCulture);
            var formatProvider = CultureInfo.InvariantCulture;

            yield return new TestCaseData(valueToTest, "N17", formatProvider)
                .Returns("123,456,789,987,654,321.12345678998765432");
            yield return new TestCaseData(valueToTest, "N18", formatProvider)
                .Returns("123,456,789,987,654,321.123456789987654321");
            yield return new TestCaseData(valueToTest, "N19", formatProvider)
                .Returns("123,456,789,987,654,321.1234567899876543210");
        }
    }

    [Test]
    [TestCaseSource(nameof(StandardNumberFormatSupportsHighPrecisionCases))]
    public string The_standard_number_format_supports_high_precision(Fraction valueToTest, string format,
        IFormatProvider formatProvider) {
        return DecimalFormatter.Format(format, valueToTest, formatProvider);
    }
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
[TestFixture]
public class When_formatting_a_fraction_with_the_exponential_format : DecimalNotationFormatterSpecs {
    private static readonly string[] ScientificFormats =
        ["E", "E0", "E1", "E2", "E3", "E4", "E5", "E6", "e1", "e6"];

    public static IEnumerable<TestCaseData> ScientificFormatsToTest =>
        from stringFormat in ScientificFormats
        from valueToTest in TerminatingFractions.Concat(NonTerminatingFractions)
        from cultureToTest in FormatProviders
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDecimal().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(ScientificFormatsToTest))]
    public string The_scientific_format_should_match_decimal_ToString(Fraction valueToTest, string stringFormat,
        IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    public static IEnumerable<TestCaseData> ScientificFormatSupportsHighPrecisionCases {
        get {
            var valueToTest = Fraction.FromString("123456789987654321.123456789987654321", AmericanCulture);
            var formatProvider = CultureInfo.InvariantCulture;

            yield return new TestCaseData(valueToTest, "E16", formatProvider)
                .Returns("1.2345678998765432E+017");
            yield return new TestCaseData(valueToTest, "E17", formatProvider)
                .Returns("1.23456789987654321E+017");
            yield return new TestCaseData(valueToTest, "E18", formatProvider)
                .Returns("1.234567899876543211E+017");
            yield return new TestCaseData(valueToTest, "E34", formatProvider)
                .Returns("1.2345678998765432112345678998765432E+017");
            yield return new TestCaseData(valueToTest, "E35", formatProvider)
                .Returns("1.23456789987654321123456789987654321E+017");
            yield return new TestCaseData(valueToTest, "E36", formatProvider)
                .Returns("1.234567899876543211234567899876543210E+017");
        }
    }

    [Test]
    [TestCaseSource(nameof(ScientificFormatSupportsHighPrecisionCases))]
    public string The_scientific_format_supports_high_precision(Fraction valueToTest, string format,
        IFormatProvider formatProvider) {
        return DecimalFormatter.Format(format, valueToTest, formatProvider);
    }

    [Test]
    public void The_default_precision_specifier_is_6_digits_after_the_decimal_point() {
        // Arrange
        var fraction = new Fraction(1.111111m);
        // Act
        var result = DecimalFormatter.Format("e", fraction, null);
        // Assert
        result.Should().Be(DecimalFormatter.Format("e6", fraction, null));
    }
}

/// <summary>
///     The "C" (or currency) format specifier converts a number to a string that represents a currency amount. The
///     precision specifier indicates the desired number of decimal places in the result string. If the precision specifier
///     is omitted, the default precision is defined by the NumberFormatInfo.CurrencyDecimalDigits property.
///     If the value to be formatted has more than the specified or default number of decimal places, the fractional value
///     is rounded in the result string. If the value to the right of the number of specified decimal places is 5 or
///     greater, the last digit in the result string is rounded away from zero.
/// </summary>
[TestFixture]
public class When_formatting_a_fraction_with_the_currency_format : DecimalNotationFormatterSpecs {
    private static readonly string[] CurrencyFormats =
        ["C", "C0", "C1", "C2", "C3", "C4", "C5", "C6"];

    public static readonly int[] CurrencyPositivePatterns = [
        00, // $n
        01, // n$
        02, // $ n
        03 // n $
    ];

    public static readonly int[] CurrencyNegativePatterns = [
        00, // ($n)
        01, // -$n
        02, // $-n
        03, // $n-
        04, // (n$)
        05, // -n$
        06, // n-$
        07, // n$-
        08, // -n $
        09, // -$ n
        10, // n $-
        11, // $ n-
        12, // $ -n
        13, // n- $
        14, // ($ n)
        15, // (n $)
#if NET
        16, // $- n
#endif
    ];

    [Test]
    public void CurrencyPositivePattern_WithInvalidValue_ThrowsArgumentOutOfRangeException() {
        var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        var numberFormat = formatProvider.NumberFormat;
        Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.CurrencyPositivePattern = -1);
        Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.CurrencyPositivePattern = 4);
    }

    [Test]
    public void CurrencyNegativePattern_WithInvalidValue_ThrowsArgumentOutOfRangeException() {
        var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        var numberFormat = formatProvider.NumberFormat;
        Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.CurrencyNegativePattern = -1);
#if NET
        Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.CurrencyNegativePattern = 17);
#else
        Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.CurrencyNegativePattern = 16);
#endif
    }

    public static IEnumerable<TestCaseData> CurrencyFormatsToTest =>
        from stringFormat in CurrencyFormats
        from valueToTest in TerminatingFractions.Concat(NonTerminatingFractions)
        from cultureToTest in FormatProviders
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDecimal().ToString(stringFormat, cultureToTest));

    public static IEnumerable<TestCaseData> CurrencyPositivePatternsToTest =>
        from stringFormat in CurrencyFormats
        from valueToTest in new Fraction[] { 0, 0.1m, 1, 1.2345789m }
        from cultureToTest in CurrencyPositivePatterns.Select(pattern => {
            var culture = (CultureInfo)AmericanCulture.Clone();
            culture.NumberFormat.CurrencyPositivePattern = pattern;
            return culture;
        })
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDecimal().ToString(stringFormat, cultureToTest));

    public static IEnumerable<TestCaseData> CurrencyNegativePatternsToTest =>
        from stringFormat in CurrencyFormats
        from valueToTest in new Fraction[] { 0, -0.1m, -1, -1.23456789m }
        from cultureToTest in CurrencyNegativePatterns.Select(pattern => {
            var culture = (CultureInfo)AmericanCulture.Clone();
            culture.NumberFormat.CurrencyNegativePattern = pattern;
            return culture;
        })
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDecimal().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(CurrencyFormatsToTest))]
    public string The_currency_format_should_match_decimal_ToString(Fraction valueToTest, string stringFormat,
        IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    [Test]
    [TestCaseSource(nameof(CurrencyPositivePatternsToTest))]
    public string The_currency_format_should_respect_the_currency_positive_patterns(Fraction valueToTest,
        string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    [Test]
    [TestCaseSource(nameof(CurrencyNegativePatternsToTest))]
    public string The_currency_format_should_respect_the_currency_negative_patterns(Fraction valueToTest,
        string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    public static IEnumerable<TestCaseData> CurrencyFormatSupportsHighPrecisionCases {
        get {
            var valueToTest = Fraction.FromString("123456789987654321.123456789987654321", AmericanCulture);
            var formatProvider = AmericanCulture;

            yield return new TestCaseData(valueToTest, "C17", formatProvider)
                .Returns("$123,456,789,987,654,321.12345678998765432");
            yield return new TestCaseData(valueToTest, "C18", formatProvider)
                .Returns("$123,456,789,987,654,321.123456789987654321");
            yield return new TestCaseData(valueToTest, "C19", formatProvider)
                .Returns("$123,456,789,987,654,321.1234567899876543210");
        }
    }

    [Test]
    [TestCaseSource(nameof(CurrencyFormatSupportsHighPrecisionCases))]
    public string The_currency_format_supports_high_precision(Fraction valueToTest, string format,
        IFormatProvider formatProvider) {
        return DecimalFormatter.Format(format, valueToTest, formatProvider);
    }
}

/// <summary>
///     The percent ("P") format specifier multiplies a number by 100 and converts it to a string that represents a
///     percentage. The precision specifier indicates the desired number of decimal places. If the precision specifier is
///     omitted, the default numeric precision supplied by the current PercentDecimalDigits property is used.
/// </summary>
[TestFixture]
public class When_formatting_a_fraction_with_the_percent_format : DecimalNotationFormatterSpecs {
    private static readonly string[] PercentFormats =
        ["P", "P0", "P1", "P2", "P3", "P4", "P5", "P6"];

    public static IEnumerable<TestCaseData> PercentFormatsToTest =>
        from stringFormat in PercentFormats
        from valueToTest in TerminatingFractions.Concat(NonTerminatingFractions)
        from cultureToTest in FormatProviders
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDecimal().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(PercentFormatsToTest))]
    public string The_percentage_format_should_match_decimal_ToString(Fraction valueToTest, string stringFormat,
        IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    public static readonly int[] PercentPositivePatterns = [
        00, // n %
        01, // n%
        02, // %n
        03 // % n
    ];

    [Test]
    public void PercentPositivePattern_with_invalid_value_ThrowsArgumentOutOfRangeException()
    {
        var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        var numberFormat = formatProvider.NumberFormat;
        Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.PercentPositivePattern = -1);
        Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.PercentPositivePattern = 4);
    }

    public static IEnumerable<TestCaseData> PercentPositivePatternsToTest =>
        from stringFormat in PercentFormats
        from valueToTest in new Fraction[] { 0, 0.1m, 1, 1.2345789m }
        from cultureToTest in PercentPositivePatterns.Select(pattern => {
            var culture = (CultureInfo)AmericanCulture.Clone();
            culture.NumberFormat.PercentPositivePattern = pattern;
            return culture;
        })
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDecimal().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(PercentPositivePatternsToTest))]
    public string The_percent_format_should_respect_the_percent_positive_patterns(Fraction valueToTest,
        string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }


    public static readonly int[] PercentNegativePatterns = [
        00, // -n %
        01, // -n%
        02, // -%n
        03, // %-n
        04, // n- %
        05, // n-%
        06, // %n-
        07, // n %-
        08, // -% n
        09, // %- n
        10, // n %- 
        11 // % n-
    ];

    [Test]
    public void PercentNegativePattern_with_invalid_value_ThrowsArgumentOutOfRangeException()
    {
        var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        var numberFormat = formatProvider.NumberFormat;
        Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.PercentNegativePattern = -1);
        Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.PercentNegativePattern = 12);
    }

    public static IEnumerable<TestCaseData> PercentNegativePatternsToTest =>
        from stringFormat in PercentFormats
        from valueToTest in new Fraction[] { 0, -0.1m, -1, -1.23456789m }
        from cultureToTest in PercentNegativePatterns.Select(pattern => {
            var culture = (CultureInfo)AmericanCulture.Clone();
            culture.NumberFormat.PercentNegativePattern = pattern;
            return culture;
        })
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDecimal().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(PercentNegativePatternsToTest))]
    public string The_percent_format_should_respect_the_percent_negative_patterns(Fraction valueToTest,
        string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    public static IEnumerable<TestCaseData> PercentFormatSupportsHighPrecisionCases {
        get {
            var valueToTest = Fraction.FromString("123456789987654321.123456789987654321", AmericanCulture);
            var formatProvider = CultureInfo.InvariantCulture;

            yield return new TestCaseData(valueToTest, "P15", formatProvider)
                .Returns("12,345,678,998,765,432,112.345678998765432 %");
            yield return new TestCaseData(valueToTest, "P16", formatProvider)
                .Returns("12,345,678,998,765,432,112.3456789987654321 %");
            yield return new TestCaseData(valueToTest, "P17", formatProvider)
                .Returns("12,345,678,998,765,432,112.34567899876543210 %");
        }
    }

    [Test]
    [TestCaseSource(nameof(PercentFormatSupportsHighPrecisionCases))]
    public string The_percent_format_supports_high_precision(Fraction valueToTest, string format,
        IFormatProvider formatProvider) {
        return DecimalFormatter.Format(format, valueToTest, formatProvider);
    }
}

/// <summary>
///     The significant digits after radix ("S") format specifier converts a number to a string that preserves the
///     precision of the Fraction object with a variable number of digits after the radix point.
/// </summary>
[TestFixture]
public class
    When_formatting_a_fraction_with_the_significant_digits_after_the_radix_format : DecimalNotationFormatterSpecs {
    /// <summary>
    ///     Values with exponent in the interval [-3 ≤ e ≤ 5] are formatted using the decimal point notation (no extra digits).
    /// </summary>
    public static IEnumerable<TestCaseData> NormalValueCases {
        get {
            var culture = CultureInfo.InvariantCulture;
            foreach (var format in new[] { "S2", "s2" }) {
                // no exponent: no difference
                // from -1000000 to -1
                yield return new TestCaseData(new Fraction(-999999.99m), format, culture).Returns("-999,999.99");
                yield return new TestCaseData(new Fraction(-111000), format, culture).Returns("-111,000");
                yield return new TestCaseData(new Fraction(-11000), format, culture).Returns("-11,000");
                yield return new TestCaseData(new Fraction(-1000), format, culture).Returns("-1,000");
                yield return new TestCaseData(new Fraction(-999.99m), format, culture).Returns("-999.99");
                yield return new TestCaseData(new Fraction(-1.1m), format, culture).Returns("-1.1");
                yield return new TestCaseData(Fraction.MinusOne, format, culture).Returns("-1");

                // from -1 to 0
                yield return new TestCaseData(new Fraction(-0.1), format, culture).Returns("-0.1");
                yield return new TestCaseData(new Fraction(-0.01), format, culture).Returns("-0.01");
                yield return new TestCaseData(new Fraction(-0.001), format, culture).Returns("-0.001");

                // from 0 to 1
                yield return new TestCaseData(Fraction.Zero, format, culture).Returns("0");
                yield return new TestCaseData(new Fraction(0.001), format, culture).Returns("0.001");
                yield return new TestCaseData(new Fraction(0.01), format, culture).Returns("0.01");
                yield return new TestCaseData(new Fraction(0.1), format, culture).Returns("0.1");

                // from 1 to 1000000
                yield return new TestCaseData(Fraction.One, format, culture).Returns("1");
                yield return new TestCaseData(new Fraction(1.1m), format, culture).Returns("1.1");
                yield return new TestCaseData(new Fraction(999.99m), format, culture).Returns("999.99");
                yield return new TestCaseData(new Fraction(1000), format, culture).Returns("1,000");
                yield return new TestCaseData(new Fraction(11000), format, culture).Returns("11,000");
                yield return new TestCaseData(new Fraction(111000), format, culture).Returns("111,000");
                yield return new TestCaseData(new Fraction(999999.99m), format, culture).Returns("999,999.99");
                yield return new TestCaseData(Fraction.FromDecimal(999999.99m, false), format, culture).Returns("999,999.99");
            }

            // the provided culture is respected
            foreach (var format in new[] { "S2", "s2" }) {
                // no exponent: no difference
                yield return new TestCaseData(new Fraction(999999.99m), format, RussianCulture).Returns("999 999,99");
                yield return new TestCaseData(new Fraction(-999999.99m), format, RussianCulture).Returns("-999 999,99");
            }
        }
    }

    [Test]
    [TestCaseSource(nameof(NormalValueCases))]
    public string Normal_values_are_formatted_in_decimal_point_notation(Fraction fraction, string stringFormat,
        IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, fraction, formatProvider);
    }

    /// <summary>
    ///     Values with exponent in the interval [-inf ≤ e ≤ -4] are formatted in scientific notation.
    /// </summary>
    public static IEnumerable<TestCaseData> SmallAbsoluteValueCases {
        get {
            var culture = CultureInfo.InvariantCulture;
            // uppercase letter
            yield return new TestCaseData(new Fraction(1.99e-4m), "S2", culture).Returns("1.99E-04");
            yield return new TestCaseData(new Fraction(-1.99e-4m), "S2", culture).Returns("-1.99E-04");
            yield return new TestCaseData(new Fraction(0.0000111m), "S2", culture).Returns("1.11E-05");
            yield return new TestCaseData(new Fraction(-0.0000111m), "S2", culture).Returns("-1.11E-05");
            yield return new TestCaseData(new Fraction(1.23e-120), "S2", culture).Returns("1.23E-120");
            yield return new TestCaseData(new Fraction(-1.23e-120), "S2", culture).Returns("-1.23E-120");
            // lowercase letter
            yield return new TestCaseData(new Fraction(1.99e-4m), "s2", culture).Returns("1.99e-04");
            yield return new TestCaseData(new Fraction(-1.99e-4m), "s2", culture).Returns("-1.99e-04");
            yield return new TestCaseData(new Fraction(0.0000111m), "s2", culture).Returns("1.11e-05");
            yield return new TestCaseData(new Fraction(-0.0000111m), "s2", culture).Returns("-1.11e-05");
            yield return new TestCaseData(new Fraction(1.23e-120), "s2", culture).Returns("1.23e-120");
            yield return new TestCaseData(new Fraction(-1.23e-120), "s2", culture).Returns("-1.23e-120");
        }
    }

    [Test]
    [TestCaseSource(nameof(SmallAbsoluteValueCases))]
    public string Values_with_small_absolute_values_are_formatted_in_scientific_notation(Fraction fraction,
        string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, fraction, formatProvider);
    }

    /// <summary>
    ///     Any value in the interval [1e+06 ≤ x ≤ +inf] is formatted in scientific notation.
    /// </summary>
    public static IEnumerable<TestCaseData> LargePositiveValueCases {
        get {
            var culture = CultureInfo.InvariantCulture;
            // from 1E+6 to +inf (uppercase)
            yield return new TestCaseData(new Fraction(1000000), "S2", culture).Returns("1E+06");
            yield return new TestCaseData(new Fraction(11100000), "S2", culture).Returns("1.11E+07");
            yield return new TestCaseData(new Fraction(double.MaxValue), "S2", culture).Returns("1.8E+308");
            // from 1e+6 to +inf (lowercase)
            yield return new TestCaseData(new Fraction(1000000), "s2", culture).Returns("1e+06");
            yield return new TestCaseData(new Fraction(11100000), "s2", culture).Returns("1.11e+07");
            yield return new TestCaseData(new Fraction(double.MaxValue), "s2", culture).Returns("1.8e+308");
        }
    }

    [Test]
    [TestCaseSource(nameof(LargePositiveValueCases))]
    public string Large_positive_values_are_formatted_in_scientific_notation(Fraction fraction, string stringFormat,
        IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, fraction, formatProvider);
    }

    /// <summary>
    ///     Any value in the interval [-inf ≤ x ≤ 1e-04] is formatted in scientific notation.
    /// </summary>
    public static IEnumerable<TestCaseData> LargeNegativeValueCases {
        get {
            var culture = CultureInfo.InvariantCulture;
            // from -inf up to -1E+6 (uppercase)
            yield return new TestCaseData(new Fraction(double.MinValue), "S2", culture).Returns("-1.8E+308");
            yield return new TestCaseData(new Fraction(-11100000), "S2", culture).Returns("-1.11E+07");
            yield return new TestCaseData(new Fraction(-1000000), "S2", culture).Returns("-1E+06");
            // from -inf up to -1e+6 (lowercase)
            yield return new TestCaseData(new Fraction(double.MinValue), "s2", culture).Returns("-1.8e+308");
            yield return new TestCaseData(new Fraction(-11100000), "s2", culture).Returns("-1.11e+07");
            yield return new TestCaseData(new Fraction(-1000000), "s2", culture).Returns("-1e+06");
        }
    }

    [Test]
    [TestCaseSource(nameof(LargeNegativeValueCases))]
    public string Large_negative_values_are_formatted_in_scientific_notation(Fraction fraction, string stringFormat,
        IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, fraction, formatProvider);
    }

    [Test]
    public void Very_large_positive_values_are_formatted_in_scientific_notation()
    {
        var value = new Fraction(1234 * BigInteger.Pow(10, 1000));

        var actualValue = DecimalFormatter.Format("s", value, CultureInfo.InvariantCulture);
                
        actualValue.Should().Be("1.23e+1003");
    }

    [Test]
    public void Very_small_positive_values_are_formatted_in_scientific_notation()
    {
        var value = new Fraction(1234, BigInteger.Pow(10, 1004), false);
        
        var actualValue = DecimalFormatter.Format("s", value, CultureInfo.InvariantCulture);

        actualValue.Should().Be("1.23e-1001");
    }
    
    public static IEnumerable<TestCaseData> RoundingErrorsWithSignificantDigitsAfterRadixFormattingCases {
        get {
            var culture = CultureInfo.InvariantCulture;
            yield return new TestCaseData(new Fraction(0.819999999999m), "s2", culture).Returns("0.82");
            yield return new TestCaseData(new Fraction(0.819999999999m), "s4", culture).Returns("0.82");
            yield return new TestCaseData(new Fraction(0.00299999999m), "s2", culture).Returns("0.003");
            yield return new TestCaseData(new Fraction(0.00299999999m), "s4", culture).Returns("0.003");
            yield return new TestCaseData(new Fraction(0.0003000001m), "s2", culture).Returns("3e-04");
            yield return new TestCaseData(new Fraction(0.0003000001m), "s4", culture).Returns("3e-04");
        }
    }

    [Test]
    [TestCaseSource(nameof(RoundingErrorsWithSignificantDigitsAfterRadixFormattingCases))]
    public string Values_are_rounded_according_to_the_specified_number_of_significant_digits_after_the_radix(
        Fraction fraction, string format, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(format, fraction, formatProvider);
    }

    [Test]
    public void The_default_precision_specifier_is_2_significant_digits_after_the_radix() {
        // Arrange
        var fraction = new Fraction(1.111111m);
        // Act
        var result = DecimalFormatter.Format("s", fraction, null);
        // Assert
        result.Should().Be(DecimalFormatter.Format("s2", fraction, null));
    }

    public static IEnumerable<TestCaseData> SpecialFormatSupportsHighPrecisionCases {
        get {
            var valueToTest = Fraction.FromString("123456789987654321.123456789987654321", AmericanCulture);
            var formatProvider = CultureInfo.InvariantCulture;

            yield return new TestCaseData(valueToTest, "S16", formatProvider)
                .Returns("1.2345678998765432E+17");
            yield return new TestCaseData(valueToTest, "S17", formatProvider)
                .Returns("1.23456789987654321E+17");
            yield return new TestCaseData(valueToTest, "S18", formatProvider)
                .Returns("1.234567899876543211E+17");
            yield return new TestCaseData(valueToTest, "S19", formatProvider)
                .Returns("1.2345678998765432112E+17");
            yield return new TestCaseData(valueToTest, "S34", formatProvider)
                .Returns("1.2345678998765432112345678998765432E+17");
            yield return new TestCaseData(valueToTest, "S35", formatProvider)
                .Returns("1.23456789987654321123456789987654321E+17");
            yield return new TestCaseData(valueToTest, "S36", formatProvider)
                .Returns("1.23456789987654321123456789987654321E+17");
        }
    }

    [Test]
    [TestCaseSource(nameof(SpecialFormatSupportsHighPrecisionCases))]
    public string The_special_format_support_high_precision(Fraction valueToTest, string format,
        IFormatProvider formatProvider) {
        return DecimalFormatter.Format(format, valueToTest, formatProvider);
    }
}

/// <summary>
///     The round-trip ("R") format specifier attempts to ensure that a numeric value that is converted to a string is
///     parsed back into the same numeric value.This format is supported only for the Half, Single, Double, and BigInteger
///     types.
/// </summary>
/// <remarks>
///     Although you can include a precision specifier, it is ignored. Round trips are given precedence over precision
///     when using this specifier. The result string is affected by the formatting information of the current
///     NumberFormatInfo object.
/// </remarks>
[TestFixture]
public class When_formatting_a_fraction_using_the_round_tripping_format : DecimalNotationFormatterSpecs {
    private static readonly string[] RoundTrippingFormats = ["R", "r"];

    public static IEnumerable<TestCaseData> GeneralFormatsToTest =>
        from stringFormat in RoundTrippingFormats
        from valueToTest in TerminatingFractions.Concat(NonTerminatingFractions)
        from cultureToTest in FormatProviders
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDouble().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(GeneralFormatsToTest))]
    public string The_round_tripping_format_should_match_double_ToString(Fraction valueToTest, string stringFormat,
        IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }
}

/// <summary>
///     Custom numeric format strings such as "%#0.00" and "#0.0#;(#0.0#)" are supported using ToDouble().ToString(...)
///     (with possible loss of precision)
/// </summary>
[TestFixture]
public class When_formatting_a_fraction_using_a_custom_format : DecimalNotationFormatterSpecs {
    public static IEnumerable<TestCaseData> TestCases {
        get {
            var culture = CultureInfo.InvariantCulture;
            var oneHalf = new Fraction(1, 2);
            yield return new TestCaseData("000", oneHalf, culture).Returns("001");
            yield return new TestCaseData("0.00", oneHalf, culture).Returns("0.50");
            yield return new TestCaseData("#####", oneHalf, culture).Returns("1");
            yield return new TestCaseData("#.##", oneHalf, culture).Returns(".5");
            yield return new TestCaseData("##,#", oneHalf, culture).Returns("1");
            yield return new TestCaseData("#,#,,", oneHalf, culture).Returns("");
            yield return new TestCaseData("%#0.00", oneHalf, culture).Returns("%50.00");
            yield return new TestCaseData("##.0 %", oneHalf, culture).Returns("50.0 %");
            yield return new TestCaseData("#0.00‰", oneHalf, culture).Returns("500.00‰");
            yield return new TestCaseData("#0.0e0", oneHalf, culture).Returns("50.0e-2");
            yield return new TestCaseData("0.0##e+00", oneHalf, culture).Returns("5.0e-01");
            yield return new TestCaseData("0.0e+00", oneHalf, culture).Returns("5.0e-01");
            yield return new TestCaseData(@"\###00\#", oneHalf, culture).Returns("#01#");
            yield return new TestCaseData("#0.0#;(#0.0#);-\0-", oneHalf.Negate(), culture).Returns("(0.5)");
            yield return new TestCaseData("#0.0#;(#0.0#)", Fraction.Zero, culture).Returns("0.0");
            yield return new TestCaseData("Test: 0.00", new Fraction(12.345), culture).Returns("Test: 12.35");
            yield return new TestCaseData("Pest: 0.00", new Fraction(12.345), culture).Returns("Pest: 12.35");
            yield return new TestCaseData("Fest: 0.00", new Fraction(12.345), culture).Returns("Fest: 12.35");
            yield return new TestCaseData("Number: 0.00", oneHalf, culture).Returns("Number: 0.50");
            yield return new TestCaseData("Some: 0.00", oneHalf, culture).Returns("Some: 0.50");
            yield return new TestCaseData("Cans: 0.00", oneHalf, culture).Returns("Cans: 0.50");
            yield return new TestCaseData("Eons: 0.00", oneHalf, culture).Returns("Eons: 0.50");
            yield return new TestCaseData("Guess: 0.00", oneHalf, culture).Returns("Guess: 0.50");
            yield return new TestCaseData("Guess: 0.00", Fraction.PositiveInfinity, culture).Returns(culture.NumberFormat.PositiveInfinitySymbol);
            yield return new TestCaseData("Guess: 0.00", Fraction.NegativeInfinity, culture).Returns(culture.NumberFormat.NegativeInfinitySymbol);
            yield return new TestCaseData("Guess: 0.00", Fraction.NaN, culture).Returns(culture.NumberFormat.NaNSymbol);
            yield return new TestCaseData("0.## items", oneHalf, culture).Returns("0.5 items");
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public string
        The_result_matches_ToDouble_ToString(string format, Fraction fraction, IFormatProvider formatProvider) {
        var result = DecimalFormatter.Format(format, fraction, formatProvider);
        result.Should().Be(fraction.ToDouble().ToString(format, formatProvider)); // just double-checking
        return result;
    }
}

[TestFixture]
public class When_no_format_is_specified : DecimalNotationFormatterSpecs {
    [Test]
    public void The_result_should_be_formatted_using_the_generic_format() {
        // Arrange
        var fraction = new Fraction(-123456789.987);
        // Act
        var result = DecimalFormatter.Format(null, fraction, CultureInfo.CurrentCulture);
        // Assert
        result.Should().Be(DecimalFormatter.Format("G", fraction, CultureInfo.CurrentCulture));
    }
}

[TestFixture]
public class When_no_culture_is_specified : DecimalNotationFormatterSpecs {
    [Test]
    public void The_result_should_be_formatted_using_the_current_culture() {
        // Arrange
        var fraction = new Fraction(-123456789.987);
        // Act
        var result = DecimalFormatter.Format(null, fraction, null);
        // Assert
        result.Should().Be(DecimalFormatter.Format(null, fraction, CultureInfo.CurrentCulture));
    }
}

[TestFixture]
public class When_formatting_NaN_or_Infinity : DecimalNotationFormatterSpecs {
    public static IEnumerable<TestCaseData> FormatWithSpecialFractionCases =>
        from valueToTest in SpecialFractions
        from cultureToTest in FormatProviders
        select new TestCaseData(valueToTest, cultureToTest)
            .Returns(valueToTest.ToDouble().ToString(cultureToTest));

    [Test]
    [TestCaseSource(nameof(FormatWithSpecialFractionCases))]
    public string The_result_should_be_the_corresponding_symbol(
        Fraction valueToTest, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(null, valueToTest, formatProvider);
    }
}

[TestFixture]
public class When_attempting_to_format_null : DecimalNotationFormatterSpecs {
    [Test]
    public void The_result_should_be_an_empty_string() {
        DecimalFormatter.Format(null, null, null).Should().BeEmpty();
    }
}

[TestFixture]
public class When_attempting_to_format_with_something_that_is_not_a_fraction : DecimalNotationFormatterSpecs {
    [Test]
    public void A_FormatException_should_be_thrown() {
        Invoking(() => DecimalFormatter.Format(null, "not a fraction", null))
            .Should()
            .Throw<FormatException>();
    }
}
