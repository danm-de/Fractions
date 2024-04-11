using System;
using System.Collections.Generic;
using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Sqrt;

[TestFixture]
public class When_the_Root_function_is_called : Spec {
    
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
            yield return new TestCaseData(5, 3);
            yield return new TestCaseData(4.54854751, 2);
            yield return new TestCaseData(9999999855487, 4);
            yield return new TestCaseData(99999998554865557, 2);
            yield return new TestCaseData(Math.PI, 3);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void The_result_should_be_equal_to_Math_Sqrt(double value, int rootNumber) {
        var expected = Math.Pow(value, 1.0 / rootNumber);
        
        var maxDifference = new Fraction(BigInteger.One, BigInteger.Pow(new BigInteger(10), 10));
        var actual = Fraction.FromDouble(value).Root(rootNumber, maxDifference);
        
        actual.ToDouble().Should().BeApproximately(expected, maxDifference.ToDouble());
    }
}
