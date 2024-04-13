using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FluentAssertions;
using Fractions.Formatter;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.StringFormatters;

[TestFixture]
public class When_formatting_a_fraction: Spec {
    private const string AmericanCultureName = "en-US";
    private const string RussianCultureName = "ru-RU";
    private const string NorwegianCultureName = "nb-NO";

    /// <summary>
    ///     The general ("G") format specifier converts a number to the more compact of either fixed-point or scientific
    ///     notation, depending on the type of the number and whether a precision specifier is present. The precision specifier
    ///     defines the maximum number of significant digits that can appear in the result string. If the precision specifier
    ///     is omitted or zero, the type of the number determines the default precision.
    /// </summary>
    private static readonly string[] GeneralFormats =
        ["G", "G0", "G1", "G2", "G3", "G4", "G5", "G6", "g", "g0", "g1", "g2", "g3", "g4", "g5", "g6"];

    /// <summary>
    ///     The fixed-point ("F") format specifier converts a number to a string of the form "-ddd.ddd…" where each "d"
    ///     indicates a digit (0-9). The string starts with a minus sign if the number is negative.
    ///     The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted, the
    ///     current NumberFormatInfo.NumberDecimalDigits property supplies the numeric precision.
    /// </summary>
    private static readonly string[] FixedPointFormats =
        ["F", "F0", "F1", "F2", "F3", "F4", "F5", "F6", "f", "f0", "f1", "f2", "f3", "f4", "f5", "f6"];

    /// <summary>
    ///     The numeric ("N") format specifier converts a number to a string of the form "-d,ddd,ddd.ddd…", where "-" indicates
    ///     a negative number symbol if required, "d" indicates a digit (0-9), "," indicates a group separator, and "."
    ///     indicates a decimal point symbol. The precision specifier indicates the desired number of digits after the decimal
    ///     point. If the precision specifier is omitted, the number of decimal places is defined by the current
    ///     NumberFormatInfo.NumberDecimalDigits property.
    /// </summary>
    private static readonly string[] NumberFormats =
        ["N", "N0", "N1", "N2", "N3", "N4", "N5", "N6", "n", "n0", "n1", "n2", "n3", "n4", "n5", "n6"];

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
    private static readonly string[] ScientificFormats =
        ["E", "E0", "E1", "E2", "E3", "E4", "E5", "E6", "e", "e0", "e1", "e2", "e3", "e4", "e5", "e6"];

    /// <summary>
    ///     The "C" (or currency) format specifier converts a number to a string that represents a currency amount. The
    ///     precision specifier indicates the desired number of decimal places in the result string. If the precision specifier
    ///     is omitted, the default precision is defined by the NumberFormatInfo.CurrencyDecimalDigits property.
    ///     If the value to be formatted has more than the specified or default number of decimal places, the fractional value
    ///     is rounded in the result string. If the value to the right of the number of specified decimal places is 5 or
    ///     greater, the last digit in the result string is rounded away from zero.
    /// </summary>
    private static readonly string[] CurrencyFormats =
        ["C", "C0", "C1", "C2", "C3", "C4", "C5", "C6", "c", "c0", "c1", "c2", "c3", "c4", "c5", "c6"];

    /// <summary>
    ///     The percent ("P") format specifier multiplies a number by 100 and converts it to a string that represents a
    ///     percentage. The precision specifier indicates the desired number of decimal places. If the precision specifier is
    ///     omitted, the default numeric precision supplied by the current PercentDecimalDigits property is used.
    /// </summary>
    private static readonly string[] PercentageFormats =
        ["P", "P0", "P1", "P2", "P3", "P4", "P5", "P6", "p", "p0", "p1", "p2", "p3", "p4", "p5", "p6"];

    private static readonly IFormatProvider AmericanCulture = CultureInfo.GetCultureInfo(AmericanCultureName);
    private static readonly IFormatProvider NorwegianCulture = CultureInfo.GetCultureInfo(NorwegianCultureName);
    private static readonly IFormatProvider RussianCulture = CultureInfo.GetCultureInfo(RussianCultureName);

    private static readonly IFormatProvider[] FormatProviders = [AmericanCulture, NorwegianCulture, RussianCulture];

    private static readonly Fraction[] TerminatingFractions = [
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

    private static readonly DecimalNotationFormatter DecimalFormatter = new();

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

    public static IEnumerable<TestCaseData> NumberFormatsToTest =>
        from stringFormat in NumberFormats
        from valueToTest in TerminatingFractions
        from cultureToTest in FormatProviders
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDouble().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(NumberFormatsToTest))]
    public string The_number_format_should_match_double_ToString(Fraction valueToTest, string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

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

    public static IEnumerable<TestCaseData> CurrencyFormatsToTest =>
        from stringFormat in CurrencyFormats
        from valueToTest in TerminatingFractions
        from cultureToTest in FormatProviders
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDouble().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(CurrencyFormatsToTest))]
    public string The_currency_format_should_match_double_ToString(Fraction valueToTest, string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    public static IEnumerable<TestCaseData> PercentageFormatsToTest =>
        from stringFormat in PercentageFormats
        from valueToTest in TerminatingFractions
        from cultureToTest in FormatProviders
        select new TestCaseData(valueToTest, stringFormat, cultureToTest)
            .Returns(valueToTest.ToDouble().ToString(stringFormat, cultureToTest));

    [Test]
    [TestCaseSource(nameof(PercentageFormatsToTest))]
    public string The_percentage_format_should_match_double_ToString(Fraction valueToTest, string stringFormat, IFormatProvider formatProvider) {
        return DecimalFormatter.Format(stringFormat, valueToTest, formatProvider);
    }

    [Test]
    public static void The_fixed_point_format_supports_high_precision() {
        // Arrange
        var valueToTest = Fraction.FromString("123456789987654321.123456789987654321");
        var formatProvider = CultureInfo.InvariantCulture;

        // Assert
        DecimalFormatter.Format("F17", valueToTest, formatProvider).Should().Be("123456789987654321.12345678998765432");
        DecimalFormatter.Format("F18", valueToTest, formatProvider).Should().Be("123456789987654321.123456789987654321");
        DecimalFormatter.Format("F19", valueToTest, formatProvider).Should().Be("123456789987654321.1234567899876543210");
    }

    [Test]
    public static void The_standard_number_format_supports_high_precision() {
        // Arrange
        var valueToTest = Fraction.FromString("123456789987654321.123456789987654321");
        var formatProvider = CultureInfo.InvariantCulture;

        // Assert
        DecimalFormatter.Format("N17", valueToTest, formatProvider).Should().Be("123,456,789,987,654,321.12345678998765432");
        DecimalFormatter.Format("N18", valueToTest, formatProvider).Should().Be("123,456,789,987,654,321.123456789987654321");
        DecimalFormatter.Format("N19", valueToTest, formatProvider).Should().Be("123,456,789,987,654,321.1234567899876543210");
    }

    [Test]
    public static void The_percentage_format_supports_high_precision() {
        // Arrange
        var valueToTest = Fraction.FromString("123456789987654321.123456789987654321");
        var formatProvider = CultureInfo.InvariantCulture;

        // Assert
        DecimalFormatter.Format("P15", valueToTest, formatProvider).Should().Be("12,345,678,998,765,432,112.345678998765432 %");
        DecimalFormatter.Format("P16", valueToTest, formatProvider).Should().Be("12,345,678,998,765,432,112.3456789987654321 %");
        DecimalFormatter.Format("P17", valueToTest, formatProvider).Should().Be("12,345,678,998,765,432,112.34567899876543210 %");
    }

    [Test]
    public static void The_scientific_format_supports_high_precision() {
        // Arrange
        var valueToTest = Fraction.FromString("123456789987654321.123456789987654321");
        var formatProvider = CultureInfo.InvariantCulture;

        // Assert
        DecimalFormatter.Format("E16", valueToTest, formatProvider).Should().Be("1.2345678998765432E+017");
        DecimalFormatter.Format("E17", valueToTest, formatProvider).Should().Be("1.23456789987654321E+017");
        DecimalFormatter.Format("E18", valueToTest, formatProvider).Should().Be("1.234567899876543211E+017");
        DecimalFormatter.Format("E34", valueToTest, formatProvider).Should().Be("1.2345678998765432112345678998765432E+017");
        DecimalFormatter.Format("E35", valueToTest, formatProvider).Should().Be("1.23456789987654321123456789987654321E+017");
        DecimalFormatter.Format("E36", valueToTest, formatProvider).Should().Be("1.234567899876543211234567899876543210E+017");
    }

    [Test]
    public static void The_general_format_support_high_precision() {
        // Arrange
        var valueToTest = Fraction.FromString("123456789987654321.123456789987654321");
        var formatProvider = CultureInfo.InvariantCulture;

        // Assert
        DecimalFormatter.Format("G17", valueToTest, formatProvider).Should().Be("1.2345678998765432E+17");
        DecimalFormatter.Format("G18", valueToTest, formatProvider).Should().Be("123456789987654321");
        DecimalFormatter.Format("G19", valueToTest, formatProvider).Should().Be("123456789987654321.1");
        DecimalFormatter.Format("G35", valueToTest, formatProvider).Should().Be("123456789987654321.12345678998765432");
        DecimalFormatter.Format("G36", valueToTest, formatProvider).Should().Be("123456789987654321.123456789987654321");
        DecimalFormatter.Format("G37", valueToTest, formatProvider).Should().Be("123456789987654321.123456789987654321");
    }
    
    [Test]
    public static void The_special_format_support_high_precision() {
        // Arrange
        var valueToTest = Fraction.FromString("123456789987654321.123456789987654321");
        var formatProvider = CultureInfo.InvariantCulture;

        // Assert
        DecimalFormatter.Format("S16", valueToTest, formatProvider).Should().Be("1.2345678998765432E+17");
        DecimalFormatter.Format("S17", valueToTest, formatProvider).Should().Be("1.23456789987654321E+17");
        DecimalFormatter.Format("S18", valueToTest, formatProvider).Should().Be("1.234567899876543211E+17");
        DecimalFormatter.Format("S19", valueToTest, formatProvider).Should().Be("1.2345678998765432112E+17");
        DecimalFormatter.Format("S34", valueToTest, formatProvider).Should().Be("1.2345678998765432112345678998765432E+17");
        DecimalFormatter.Format("S35", valueToTest, formatProvider).Should().Be("1.23456789987654321123456789987654321E+17");
        DecimalFormatter.Format("S36", valueToTest, formatProvider).Should().Be("1.23456789987654321123456789987654321E+17");
    }
}

[TestFixture]
public class When_attempting_to_format_null : Spec {
    
    [Test]
    public void A_FormatException_should_be_thrown() {
        DecimalNotationFormatter.Instance.Format(null, null, null).Should().BeEmpty();
    }
}

[TestFixture]
public class When_attempting_to_format_with_something_that_is_not_a_fraction : Spec {
    
    [Test]
    public void A_FormatException_should_be_thrown() {
        Invoking(() => DecimalNotationFormatter.Instance.Format(null, "not a fraction", null))
            .Should()
            .Throw<FormatException>();
    }
}
