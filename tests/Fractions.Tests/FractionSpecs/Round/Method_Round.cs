using System;
using System.Collections;
using System.Linq;
using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Round;

[TestFixture]
public class When_rounding_a_decimal_fraction : Spec {
    
    private static readonly decimal[] DecimalValues = [
        0, 1, -1, 10, -10, 
        0.5m, -0.5m, 0.55m, -0.55m, 1.5m, -1.5m, 1.55m, -1.55m, 
        0.1m, -0.1m, 0.15m, -0.15m, 1.2m, -1.2m, 1.25m, -1.25m, 
        1.5545665434654m, -1.5545665434654m,
        15.545665434654m, -15.545665434654m,
        155.45665434654m, -155.45665434654m,
        1554.5665434654m, -1554.5665434654m,
        15545.665434654m, -15545.665434654m,
        155456.65434654m, -155456.65434654m
    ];
    
    private static readonly int[] DecimalPlaces = Enumerable.Range(0, 6).ToArray();

    private static readonly MidpointRounding[] RoundingModes = [
        MidpointRounding.ToEven,
        MidpointRounding.AwayFromZero,
#if NET
        MidpointRounding.ToZero,
        MidpointRounding.ToNegativeInfinity,
        MidpointRounding.ToPositiveInfinity
#endif
    ];

    private static IEnumerable RoundToBigIntegerTestCases =>
        from decimalValue in DecimalValues
        from midpointRounding in RoundingModes
        select new TestCaseData(new Fraction(decimalValue), midpointRounding)
            .Returns((BigInteger)decimal.Round(decimalValue, midpointRounding));


    [Test]
    [TestCaseSource(nameof(RoundToBigIntegerTestCases))]
    public BigInteger The_integral_result_should_be_correct_for_all_decimal_values(Fraction fraction, MidpointRounding roundingMode) {
        return Fraction.RoundToBigInteger(fraction, roundingMode);
    }

    private static IEnumerable RoundToFractionTestCases =>
        from decimalValue in DecimalValues
        from decimalPlaces in DecimalPlaces
        from midpointRounding in RoundingModes
        select new TestCaseData(new Fraction(decimalValue), decimalPlaces, midpointRounding)
            .Returns(new Fraction(decimal.Round(decimalValue, decimalPlaces, midpointRounding)));

    [Test]
    [TestCaseSource(nameof(RoundToFractionTestCases))]
    public Fraction The_fractional_result_should_be_correct_for_all_decimal_values(Fraction fraction, int decimalPlaces, MidpointRounding roundingMode) {
        return Fraction.Round(fraction, decimalPlaces, roundingMode);
    }
    
    [Test]
    public void The_fractional_result_should_be_correct_for_very_large_values() {
        var a = new BigInteger(123456789987654321);
        var b = new BigInteger(123456789987654321) * BigInteger.Pow(10, 18);
        var largeValue = a + b; // should represent the value 123456789987654321123456789987654321
        var middle = new Fraction(largeValue, BigInteger.Pow(10, 18)); // place the decimal point in the middle
        var valueToTest = middle / BigInteger.Pow(10, 17);

        var roundedValue = Fraction.Round(valueToTest, 36);

        roundedValue.Should().Be(valueToTest);
    }
}
