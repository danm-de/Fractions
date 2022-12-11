using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;

namespace Fractions.Tests.FractionSpecs.Number;

[TestFixture]
public class If_the_user_parses_string_to_fraction {
    private static readonly CultureInfo De = CultureInfo.GetCultureInfo("de-DE");

    private static IEnumerable<TestCaseData> TestCases {
        get
        {
            yield return new TestCaseData("1")
                .Returns(new Fraction(1,1));
            yield return new TestCaseData("1/2")
                .Returns(new Fraction(1,2));
            yield return new TestCaseData("+1/2")
                .Returns(new Fraction(1,2));
            yield return new TestCaseData("+1/+2")
                .Returns(new Fraction(1,2));
            yield return new TestCaseData("1/+2")
                .Returns(new Fraction(1,2));
            yield return new TestCaseData("-1/2")
                .Returns(new Fraction(-1,2));
            yield return new TestCaseData("1/-2")
                .Returns(new Fraction(-1,2));
            yield return new TestCaseData("3,5")
                .Returns(new Fraction(7,2));
            yield return new TestCaseData("+3,5")
                .Returns(new Fraction(7,2));
            yield return new TestCaseData("-3,5")
                .Returns(new Fraction(-7,2));
        }
    }

    [Test,TestCaseSource(nameof(TestCases))]
    public Fraction Should_it_return_the_expected_result_when_using_Parse_with_DE_culture(string value) =>
        Fraction.Parse(value, De);

    [Test,TestCaseSource(nameof(TestCases))]
    public Fraction Should_it_return_the_expected_result_when_using_Parse_with_NumberStyles_and_DE_culture(string value) =>
        Fraction.Parse(value, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, De);

    [Test,TestCaseSource(nameof(TestCases))]
    public Fraction Should_it_return_the_expected_result_when_using_Parse_with_ReadOnlySpan_and_DE_culture(string value) =>
        Fraction.Parse(value.AsSpan(), De);

    [Test,TestCaseSource(nameof(TestCases))]
    public Fraction Should_it_return_the_expected_result_when_using_Parse_with_ReadOnlySpan_NumberStyles_and_DE_culture(string value) =>
        Fraction.Parse(value.AsSpan(), NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, De);
}
