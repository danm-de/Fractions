using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Sqrt;

[TestFixture]
public class If_the_Sqrt_function_is_called : Spec {
    [Test]
    public void The_square_root_of_1_should_be_1() {
        Fraction.One.Sqrt()
            .Should().Be(1);
    }

    [Test]
    public void The_square_root_of_minus_one_should_fail() {
        Action act = () => Fraction.MinusOne.Sqrt();
        act.Should().Throw<OverflowException>()
            .WithMessage("Cannot calculate square root from a negative number");
    }

    private static IEnumerable<TestCaseData> TestCases {
        get {
            yield return new TestCaseData(0.001);
            yield return new TestCaseData(5);
            yield return new TestCaseData(4.54854751);
            yield return new TestCaseData(9999999855487);
            yield return new TestCaseData(99999998554865557);
            yield return new TestCaseData(Math.PI);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void The_result_should_be_equal_to_Math_Sqrt(double value) {
        var expected = Math.Sqrt(value);
        var actual = Fraction.FromDouble(value).Sqrt();
        actual.ToDouble().Should().Be(expected);
    }
}
