using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FluentAssertions;
using Fractions.Formatter;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.StringFormatters;

public abstract class DecimalNotationFormatterSpecs : Spec {
    protected static readonly DecimalNotationFormatter DecimalFormatter = new();

    protected static readonly CultureInfo AmericanCulture = CultureInfo.GetCultureInfo("en-US");
    protected static readonly CultureInfo NorwegianCulture = CultureInfo.GetCultureInfo("nb-NO");
    protected static readonly CultureInfo RussianCulture = CultureInfo.GetCultureInfo("ru-RU");
    protected static readonly IFormatProvider[] FormatProviders = [null, AmericanCulture, NorwegianCulture, RussianCulture];

    protected static readonly Fraction[] TerminatingFractions = [
        0, 1, -1, 10, -10, 100, -100, 1000, -1000, 10000, -10000, 100000, -100000,
        0.1m, -0.1m, 0.2m, -0.2m, 0.5m, -0.5m, 1.2m, -1.2m, 1.5m, -1.5m, 2.5m, -2.5m,
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
        1554566.5434654m, -1554566.5434654m
    ];
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
        ["G", "G0", "G1", "G2", "G3", "G4", "G5", "G6", "g", "g0", "g1", "g2", "g3", "g4", "g5", "g6"];

    public static IEnumerable<TestCaseData> GeneralFormatsToTest =>
        from stringFormat in GeneralFormats
        from valueToTest in TerminatingFractions
        from cultureToTest in FormatProviders
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDouble().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(GeneralFormatsToTest))]
    public string The_general_format_should_match_double_ToString(Fraction valueToTest, string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    public static IEnumerable<TestCaseData> GeneralFormatSupportHighPrecisionCases {
        get {
            var formatProvider = CultureInfo.InvariantCulture;
            var valueToTest = Fraction.FromString("123456789987654321.123456789987654321");
            yield return new TestCaseData(valueToTest, "G17", formatProvider).Returns("1.2345678998765432E+17");
            yield return new TestCaseData(valueToTest, "G18", formatProvider).Returns("123456789987654321");
            yield return new TestCaseData(valueToTest, "G19", formatProvider).Returns("123456789987654321.1");
            yield return new TestCaseData(valueToTest, "G35", formatProvider).Returns("123456789987654321.12345678998765432");
            yield return new TestCaseData(valueToTest, "G36", formatProvider).Returns("123456789987654321.123456789987654321");
            yield return new TestCaseData(valueToTest, "G37", formatProvider).Returns("123456789987654321.123456789987654321");
        }
    }

    [Test]
    [TestCaseSource(nameof(GeneralFormatSupportHighPrecisionCases))]
    public string The_general_format_support_high_precision(Fraction valueToTest, string format, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(format, valueToTest, formatProvider);
    }
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
        ["F", "F0", "F1", "F2", "F3", "F4", "F5", "F6", "f", "f0", "f1", "f2", "f3", "f4", "f5", "f6"];

    public static IEnumerable<TestCaseData> FixedPointFormatsToTest =>
        from stringFormat in FixedPointFormats
        from valueToTest in TerminatingFractions
        from cultureToTest in FormatProviders
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDouble().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(FixedPointFormatsToTest))]
    public string The_fixed_point_format_should_match_double_ToString(Fraction valueToTest, string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    public static IEnumerable<TestCaseData> FixedPointFormatSupportsHighPrecisionCases {
        get {
            var valueToTest = Fraction.FromString("123456789987654321.123456789987654321");
            var formatProvider = CultureInfo.InvariantCulture;
            yield return new TestCaseData(valueToTest, "F17", formatProvider).Returns("123456789987654321.12345678998765432");
            yield return new TestCaseData(valueToTest, "F18", formatProvider).Returns("123456789987654321.123456789987654321");
            yield return new TestCaseData(valueToTest, "F19", formatProvider).Returns("123456789987654321.1234567899876543210");
        }
    }

    [Test]
    [TestCaseSource(nameof(FixedPointFormatSupportsHighPrecisionCases))]
    public string The_fixed_point_format_supports_high_precision(Fraction valueToTest, string format, IFormatProvider formatProvider) {
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
        ["N", "N0", "N1", "N2", "N3", "N4", "N5", "N6", "n", "n0", "n1", "n2", "n3", "n4", "n5", "n6"];

    public static readonly int[] NumberNegativePatterns = [
        0, // (n)
        1, // -n
        2, // - n
        3, // n-
        4 // n -
    ];

    public static IEnumerable<TestCaseData> NumberFormatsToTest =>
        from stringFormat in NumberFormats
        from valueToTest in TerminatingFractions
        from cultureToTest in FormatProviders
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDouble().ToString(stringFormat, cultureToTest));

    public static IEnumerable<TestCaseData> NumberNegativePatternsToTest =>
        from stringFormat in NumberFormats
        from valueToTest in new Fraction[] { 0, -0.1m, -1, -1.23456789m }
        from cultureToTest in NumberNegativePatterns.Select(pattern => {
            var culture = (CultureInfo)AmericanCulture.Clone();
            culture.NumberFormat.NumberNegativePattern = pattern;
            return culture;
        })
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDouble().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(NumberFormatsToTest))]
    public string The_number_format_should_match_double_ToString(Fraction valueToTest, string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    [Test]
    [TestCaseSource(nameof(NumberNegativePatternsToTest))]
    public string The_numeric_format_should_respect_the_number_negative_patterns(Fraction valueToTest, string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    public static IEnumerable<TestCaseData> StandardNumberFormatSupportsHighPrecisionCases {
        get {
            var valueToTest = Fraction.FromString("123456789987654321.123456789987654321");
            var formatProvider = CultureInfo.InvariantCulture;
            yield return new TestCaseData(valueToTest, "N17", formatProvider).Returns("123,456,789,987,654,321.12345678998765432");
            yield return new TestCaseData(valueToTest, "N18", formatProvider).Returns("123,456,789,987,654,321.123456789987654321");
            yield return new TestCaseData(valueToTest, "N19", formatProvider).Returns("123,456,789,987,654,321.1234567899876543210");
        }
    }

    [Test]
    [TestCaseSource(nameof(StandardNumberFormatSupportsHighPrecisionCases))]
    public string The_standard_number_format_supports_high_precision(Fraction valueToTest, string format, IFormatProvider formatProvider) {
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
        ["E", "E0", "E1", "E2", "E3", "E4", "E5", "E6", "e", "e0", "e1", "e2", "e3", "e4", "e5", "e6"];

    public static IEnumerable<TestCaseData> ScientificFormatsToTest =>
        from stringFormat in ScientificFormats
        from valueToTest in TerminatingFractions
        from cultureToTest in FormatProviders
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDouble().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(ScientificFormatsToTest))]
    public string The_scientific_format_should_match_double_ToString(Fraction valueToTest, string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    public static IEnumerable<TestCaseData> ScientificFormatSupportsHighPrecisionCases {
        get {
            var valueToTest = Fraction.FromString("123456789987654321.123456789987654321");
            var formatProvider = CultureInfo.InvariantCulture;
            yield return new TestCaseData(valueToTest, "E16", formatProvider).Returns("1.2345678998765432E+017");
            yield return new TestCaseData(valueToTest, "E17", formatProvider).Returns("1.23456789987654321E+017");
            yield return new TestCaseData(valueToTest, "E18", formatProvider).Returns("1.234567899876543211E+017");
            yield return new TestCaseData(valueToTest, "E34", formatProvider).Returns("1.2345678998765432112345678998765432E+017");
            yield return new TestCaseData(valueToTest, "E35", formatProvider).Returns("1.23456789987654321123456789987654321E+017");
            yield return new TestCaseData(valueToTest, "E36", formatProvider).Returns("1.234567899876543211234567899876543210E+017");
        }
    }

    [Test]
    [TestCaseSource(nameof(ScientificFormatSupportsHighPrecisionCases))]
    public string The_scientific_format_supports_high_precision(Fraction valueToTest, string format, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(format, valueToTest, formatProvider);
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
        ["C", "C0", "C1", "C2", "C3", "C4", "C5", "C6", "c", "c0", "c1", "c2", "c3", "c4", "c5", "c6"];

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

    public static IEnumerable<TestCaseData> CurrencyFormatsToTest =>
        from stringFormat in CurrencyFormats
        from valueToTest in TerminatingFractions
        from cultureToTest in FormatProviders
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDouble().ToString(stringFormat, cultureToTest));

    public static IEnumerable<TestCaseData> CurrencyPositivePatternsToTest =>
        from stringFormat in CurrencyFormats
        from valueToTest in new Fraction[] { 0, 0.1m, 1, 1.2345789m }
        from cultureToTest in CurrencyPositivePatterns.Select(pattern => {
            var culture = (CultureInfo)AmericanCulture.Clone();
            culture.NumberFormat.CurrencyPositivePattern = pattern;
            return culture;
        })
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDouble().ToString(stringFormat, cultureToTest));

    public static IEnumerable<TestCaseData> CurrencyNegativePatternsToTest =>
        from stringFormat in CurrencyFormats
        from valueToTest in new Fraction[] { 0, -0.1m, -1, -1.23456789m }
        from cultureToTest in CurrencyNegativePatterns.Select(pattern => {
            var culture = (CultureInfo)AmericanCulture.Clone();
            culture.NumberFormat.CurrencyNegativePattern = pattern;
            return culture;
        })
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDouble().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(CurrencyFormatsToTest))]
    public string The_currency_format_should_match_double_ToString(Fraction valueToTest, string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    [Test]
    [TestCaseSource(nameof(CurrencyPositivePatternsToTest))]
    public string The_currency_format_should_respect_the_currency_positive_patterns(Fraction valueToTest, string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    [Test]
    [TestCaseSource(nameof(CurrencyNegativePatternsToTest))]
    public string The_currency_format_should_respect_the_currency_negative_patterns(Fraction valueToTest, string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    public static IEnumerable<TestCaseData> CurrencyFormatSupportsHighPrecisionCases {
        get {
            var valueToTest = Fraction.FromString("123456789987654321.123456789987654321");
            var formatProvider = AmericanCulture;
            yield return new TestCaseData(valueToTest, "C17", formatProvider).Returns("$123,456,789,987,654,321.12345678998765432");
            yield return new TestCaseData(valueToTest, "C18", formatProvider).Returns("$123,456,789,987,654,321.123456789987654321");
            yield return new TestCaseData(valueToTest, "C19", formatProvider).Returns("$123,456,789,987,654,321.1234567899876543210");
        }
    }

    [Test]
    [TestCaseSource(nameof(CurrencyFormatSupportsHighPrecisionCases))]
    public string The_currency_format_supports_high_precision(Fraction valueToTest, string format, IFormatProvider formatProvider) {
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
        ["P", "P0", "P1", "P2", "P3", "P4", "P5", "P6", "p", "p0", "p1", "p2", "p3", "p4", "p5", "p6"];

    public static IEnumerable<TestCaseData> PercentFormatsToTest =>
        from stringFormat in PercentFormats
        from valueToTest in TerminatingFractions
        from cultureToTest in FormatProviders
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDouble().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(PercentFormatsToTest))]
    public string The_percentage_format_should_match_double_ToString(Fraction valueToTest, string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    public static readonly int[] PercentPositivePatterns = [
        00, // n %
        01, // n%
        02, // %n
        03 // % n
    ];

    public static IEnumerable<TestCaseData> PercentPositivePatternsToTest =>
        from stringFormat in PercentFormats
        from valueToTest in new Fraction[] { 0, 0.1m, 1, 1.2345789m }
        from cultureToTest in PercentPositivePatterns.Select(pattern => {
            var culture = (CultureInfo)AmericanCulture.Clone();
            culture.NumberFormat.PercentPositivePattern = pattern;
            return culture;
        })
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDouble().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(PercentPositivePatternsToTest))]
    public string The_percent_format_should_respect_the_percent_positive_patterns(Fraction valueToTest, string stringFormat, IFormatProvider formatProvider) {
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

    public static IEnumerable<TestCaseData> PercentNegativePatternsToTest =>
        from stringFormat in PercentFormats
        from valueToTest in new Fraction[] { 0, -0.1m, -1, -1.23456789m }
        from cultureToTest in PercentNegativePatterns.Select(pattern => {
            var culture = (CultureInfo)AmericanCulture.Clone();
            culture.NumberFormat.PercentNegativePattern = pattern;
            return culture;
        })
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDouble().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(PercentNegativePatternsToTest))]
    public string The_percent_format_should_respect_the_percent_negative_patterns(Fraction valueToTest, string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    public static IEnumerable<TestCaseData> PercentFormatSupportsHighPrecisionCases {
        get {
            var valueToTest = Fraction.FromString("123456789987654321.123456789987654321");
            var formatProvider = CultureInfo.InvariantCulture;
            yield return new TestCaseData(valueToTest, "P15", formatProvider).Returns("12,345,678,998,765,432,112.345678998765432 %");
            yield return new TestCaseData(valueToTest, "P16", formatProvider).Returns("12,345,678,998,765,432,112.3456789987654321 %");
            yield return new TestCaseData(valueToTest, "P17", formatProvider).Returns("12,345,678,998,765,432,112.34567899876543210 %");
        }
    }

    [Test]
    [TestCaseSource(nameof(PercentFormatSupportsHighPrecisionCases))]
    public string The_percent_format_supports_high_precision(Fraction valueToTest, string format, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(format, valueToTest, formatProvider);
    }
}

/// <summary>
///     The significant digits after radix ("S") format specifier converts a number to a string that preserves the
///     precision of the Fraction object with a variable number of digits after the radix point.
/// </summary>
[TestFixture]
public class When_formatting_a_fraction_with_the_significant_digits_after_the_radix_format : DecimalNotationFormatterSpecs {
    public static IEnumerable<TestCaseData> SpecialFormatSupportsHighPrecisionCases {
        get {
            var valueToTest = Fraction.FromString("123456789987654321.123456789987654321");
            var formatProvider = CultureInfo.InvariantCulture;
            yield return new TestCaseData(valueToTest, "S16", formatProvider).Returns("1.2345678998765432E+17");
            yield return new TestCaseData(valueToTest, "S17", formatProvider).Returns("1.23456789987654321E+17");
            yield return new TestCaseData(valueToTest, "S18", formatProvider).Returns("1.234567899876543211E+17");
            yield return new TestCaseData(valueToTest, "S19", formatProvider).Returns("1.2345678998765432112E+17");
            yield return new TestCaseData(valueToTest, "S34", formatProvider).Returns("1.2345678998765432112345678998765432E+17");
            yield return new TestCaseData(valueToTest, "S35", formatProvider).Returns("1.23456789987654321123456789987654321E+17");
            yield return new TestCaseData(valueToTest, "S36", formatProvider).Returns("1.23456789987654321123456789987654321E+17");
        }
    }

    [Test]
    [TestCaseSource(nameof(SpecialFormatSupportsHighPrecisionCases))]
    public string The_special_format_support_high_precision(Fraction valueToTest, string format, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(format, valueToTest, formatProvider);
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
