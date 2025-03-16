using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using FluentAssertions;
using NUnit.Framework;

namespace Fractions.Tests.FractionSpecs.TryParse;

[TestFixture]
public class When_trying_to_parse_a_fraction {
    private static IEnumerable<TestCaseData> InvariantTestCases {
        get {
            yield return new TestCaseData("1/5", new Fraction(1, 5));
            yield return new TestCaseData("-1/-5", new Fraction(1, 5));
            yield return new TestCaseData("+1/5", new Fraction(1, 5));
            yield return new TestCaseData("+1/+5", new Fraction(1, 5));
            yield return new TestCaseData("1/+5", new Fraction(1, 5));

            yield return new TestCaseData("123456789987654321.123456789987654321",
                new Fraction(
                    numerator: BigInteger.Parse("123456789987654321123456789987654321"),
                    denominator: BigInteger.Pow(10, 18))
            );

            yield return new TestCaseData("-123456789987654321.123456789987654321",
                new Fraction(
                    numerator: BigInteger.Parse("-123456789987654321123456789987654321"),
                    denominator: BigInteger.Pow(10, 18))
            );

            yield return new TestCaseData("-1.23456789987654321E-24",
                new Fraction(
                    numerator: new BigInteger(-123456789987654321),
                    denominator: BigInteger.Pow(10, 17 + 24)));
            yield return new TestCaseData("0/1", Fraction.Zero);
            yield return new TestCaseData("0/+10", Fraction.Zero);
            yield return new TestCaseData("0/-10", Fraction.Zero);
            yield return new TestCaseData("0/0", Fraction.NaN);
            yield return new TestCaseData("1/0", Fraction.PositiveInfinity);
            yield return new TestCaseData("+10/0", Fraction.PositiveInfinity);
            yield return new TestCaseData("-1/0", Fraction.NegativeInfinity);
            yield return new TestCaseData("-10/0", Fraction.NegativeInfinity);
            yield return new TestCaseData(CultureInfo.InvariantCulture.NumberFormat.NaNSymbol, Fraction.NaN);
            yield return new TestCaseData(CultureInfo.InvariantCulture.NumberFormat.PositiveInfinitySymbol,
                Fraction.PositiveInfinity);
            yield return new TestCaseData(CultureInfo.InvariantCulture.NumberFormat.NegativeInfinitySymbol,
                Fraction.NegativeInfinity);
        }
    }

    private static CultureInfo _usEnglish = CultureInfo.GetCultureInfo("en-US");

    [Test, TestCaseSource(nameof(InvariantTestCases))]
    public void The_result_should_be_as_expected_when_using_Invariant_culture(string value, Fraction expected) {
        var success = Fraction.TryParse(
            value: value,
            numberStyles: NumberStyles.Number | NumberStyles.AllowExponent,
            formatProvider: CultureInfo.InvariantCulture,
            normalize: true,
            fraction: out var result);

        success.Should().BeTrue();
        Assert.That(result, Is.EqualTo(expected).Using(StrictTestComparer.Instance));
    }

    private static IEnumerable<TestCaseData> UsEnglishTestCases {
        get {
            yield return new TestCaseData("1/5", new Fraction(1, 5));
            yield return new TestCaseData("-1/-5", new Fraction(1, 5));
            yield return new TestCaseData("+1/5", new Fraction(1, 5));
            yield return new TestCaseData("+1/+5", new Fraction(1, 5));
            yield return new TestCaseData("1/+5", new Fraction(1, 5));

            yield return new TestCaseData("123456789987654321.123456789987654321",
                new Fraction(
                    numerator: BigInteger.Parse("123456789987654321123456789987654321"),
                    denominator: BigInteger.Pow(10, 18))
            );

            yield return new TestCaseData("-123456789987654321.123456789987654321",
                new Fraction(
                    numerator: BigInteger.Parse("-123456789987654321123456789987654321"),
                    denominator: BigInteger.Pow(10, 18))
            );

            yield return new TestCaseData("-1.23456789987654321E-24",
                new Fraction(
                    numerator: new BigInteger(-123456789987654321),
                    denominator: BigInteger.Pow(10, 17 + 24)));
            yield return new TestCaseData("0/1", Fraction.Zero);
            yield return new TestCaseData("0/+10", Fraction.Zero);
            yield return new TestCaseData("0/-10", Fraction.Zero);
            yield return new TestCaseData("0/0", Fraction.NaN);
            yield return new TestCaseData("1/0", Fraction.PositiveInfinity);
            yield return new TestCaseData("+10/0", Fraction.PositiveInfinity);
            yield return new TestCaseData("-1/0", Fraction.NegativeInfinity);
            yield return new TestCaseData("-10/0", Fraction.NegativeInfinity);
            yield return new TestCaseData(_usEnglish.NumberFormat.NaNSymbol, Fraction.NaN);
            yield return new TestCaseData(_usEnglish.NumberFormat.PositiveInfinitySymbol,
                Fraction.PositiveInfinity);
            yield return new TestCaseData(_usEnglish.NumberFormat.NegativeInfinitySymbol,
                Fraction.NegativeInfinity);
        }
    }

    [Test, TestCaseSource(nameof(UsEnglishTestCases))]
    public void The_result_should_be_as_expected_when_using_US_English_culture(string value, Fraction expected) {
        var success = Fraction.TryParse(
            value: value,
            numberStyles: NumberStyles.Number | NumberStyles.AllowExponent,
            formatProvider: _usEnglish,
            normalize: true,
            fraction: out var result);

        success.Should().BeTrue();
        Assert.That(result, Is.EqualTo(expected).Using(StrictTestComparer.Instance));
    }

    // TODO see about testing the non-normalized parsing variant (see tests in Method_FromString)

    [Test]
    public void TryParse_with_valid_string_for_current_culture_should_return_the_expected_result() {
        var valueToParse = 123.45.ToString("G", CultureInfo.CurrentCulture);
        var expectedValue = new Fraction(12345, 100);

        var success = Fraction.TryParse(valueToParse, out var result);

        success.Should().BeTrue();
        result.Should().Be(expectedValue);
    }

#if NET

    [Test]
    public void TryParse_ReadOnlySpan_with_valid_string_should_return_the_expected_value() {
        var valueToParse = "123.45".AsSpan();
        var expectedValue = new Fraction(12345, 100);

        var success = Fraction.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out var result);

        success.Should().BeTrue();
        result.Should().Be(expectedValue);
    }
#endif
}

[TestFixture]
public class When_trying_to_parse_an_invalid_fraction {

    private static IEnumerable<TestCaseData> TestCases {
        get {
            yield return new TestCaseData("FOOBAR");
            yield return new TestCaseData(string.Empty);
            yield return new TestCaseData(" ");
            yield return new TestCaseData(default(string));
            yield return new TestCaseData("abc123");
            yield return new TestCaseData("1x/2");
            yield return new TestCaseData("1/2x");
        }
    }

    [Test, TestCaseSource(nameof(TestCases))]
    public void The_result_should_be_FALSE(string value) =>
        Fraction.TryParse(value, out _).Should().BeFalse();

#if NET
    [Test]
    public void The_result_with_ReadOnlySpan_should_be_false() {
        Fraction.TryParse("12 345".AsSpan(), NumberStyles.Any, CultureInfo.GetCultureInfo("de-DE"), out _).Should().BeFalse();
    }

#endif
}
