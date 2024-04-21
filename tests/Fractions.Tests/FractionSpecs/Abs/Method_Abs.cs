using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Abs;

[TestFixture]
public class When_the_Abs_function_is_called : Spec {
    private static IEnumerable<TestCaseData> TestCases {
        get {
            yield return new TestCaseData(Fraction.Zero).Returns(Fraction.Zero);
            yield return new TestCaseData(Fraction.One).Returns(Fraction.One);
            yield return new TestCaseData(Fraction.MinusOne).Returns(Fraction.One);
            yield return new TestCaseData(new Fraction(-1, 3)).Returns(new Fraction(1, 3));
            yield return new TestCaseData(new Fraction(1, -3, false)).Returns(new Fraction(1, 3));
            yield return new TestCaseData(new Fraction(-1, -3, false)).Returns(new Fraction(1, 3));
            yield return new TestCaseData(Fraction.PositiveInfinity).Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity).Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(new Fraction(3, 0, false)).Returns(new Fraction(3, 0, false));
            yield return new TestCaseData(new Fraction(-3, 0, false)).Returns(new Fraction(3, 0, false));
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public Fraction The_returning_fraction_should_be_positive(Fraction fraction) {
        return fraction.Abs();
    }

    [Test]
    public void The_absolute_value_of_NaN_is_NaN() {
        Fraction.NaN.Abs().Should().Be(Fraction.NaN);
    }
}
