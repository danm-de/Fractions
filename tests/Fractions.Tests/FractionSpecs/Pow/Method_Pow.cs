using System;
using System.Collections;
using FluentAssertions;
using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Pow;

[TestFixture]
// German: Wenn an einem Bruch die Potenz angewendet wird
public class When_exponentiation_is_applied_to_a_fraction : Spec {
    private static IEnumerable TestCases {
        get {
            yield return new TestCaseData(new Fraction(1, 3), 2)
                .Returns(new Fraction(1, 9));
            yield return new TestCaseData(new Fraction(3), -1)
                .Returns(new Fraction(1, 3));
            yield return new TestCaseData(new Fraction(3), 0)
                .Returns(new Fraction(1));
            yield return new TestCaseData(new Fraction(0), 0)
                .Returns(new Fraction(1));
            yield return new TestCaseData(new Fraction(3), 2)
                .Returns(new Fraction(9));
            yield return new TestCaseData(new Fraction(3), 3)
                .Returns(new Fraction(27));
            yield return new TestCaseData(new Fraction(3), -2)
                .Returns(new Fraction(1, 9));
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    // German: Das Ergebnis sollte korrekt sein
    public Fraction The_result_should_be_correct(Fraction fraction, int power) {
        return Fraction.Pow(fraction, power);
    }
}

[TestFixture]
public class When_the_Pow_function_is_called_with_a_fractional_exponent : Spec {
    
    [Test]
    public void The_square_root_of_1_should_be_1() {
        Fraction.One.Root(2, new Fraction(BigInteger.One, 100))
            .Should().Be(1);
    }

    [Test]
    public void The_square_root_of_minus_one_should_fail() {
        Action act = () => Fraction.MinusOne.Root(2, new Fraction(BigInteger.One, 100));
        act.Should().Throw<OverflowException>()
            .WithMessage("Cannot calculate square root from a negative number");
    }

    [Test]
    public void The_square_root_of_minus_one_should_fail_with_negative_accuracy() {
        Action act = () => Fraction.One.Root(2, new Fraction(BigInteger.MinusOne, 100));
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    private static IEnumerable<TestCaseData> TestCases {
        get {
            yield return new TestCaseData(0.001, 2);
            yield return new TestCaseData(5, 0.5);
            yield return new TestCaseData(4.54854751, 2.25);
            yield return new TestCaseData(9999999855487, -2.5);
            yield return new TestCaseData(99999998554865557, -3);
            yield return new TestCaseData(Math.PI, 3);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void The_result_should_be_equal_to_Math_Sqrt(double value, double exponent) {
        var expected = Math.Pow(value, exponent);
        
        var maxDifference = new Fraction(BigInteger.One, BigInteger.Pow(new BigInteger(10), 10));
        var actual = Fraction.FromDouble(value).Pow(Fraction.FromDoubleRounded(exponent), maxDifference);
        
        actual.ToDouble().Should().BeApproximately(expected, maxDifference.ToDouble());
    }
}
