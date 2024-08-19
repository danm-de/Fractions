using System;
using System.Collections.Generic;
using System.Numerics;
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
    public void The_square_root_of_minus_one_should_return_NaN() {
        var result = Fraction.MinusOne.Sqrt();
        ((object)result).Should().Be(
            expected: Fraction.NaN,
            comparer: StrictTestComparer.Instance,
            because: "Cannot calculate square root from a negative number");
    }

    private static IEnumerable<TestCaseData> TestCases {
        get {
            yield return new TestCaseData(0.001);
            yield return new TestCaseData(5);
            yield return new TestCaseData(4.54854751);
            yield return new TestCaseData(9999999855487);
            yield return new TestCaseData(99999998554865557);
            yield return new TestCaseData(Math.PI);
            yield return new TestCaseData(double.PositiveInfinity);
            yield return new TestCaseData(double.NegativeInfinity);
            yield return new TestCaseData(double.NaN);
            yield return new TestCaseData(-1.0);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void The_result_should_be_equal_to_Math_Sqrt(double value) {
        // Arrange
        var expected = Math.Sqrt(value);
        var fraction = Fraction.FromDouble(value);
        // Act
        var actual = fraction.Sqrt();
        //Assert
        actual.ToDouble().Should().Be(expected);
    }

    [Test]
    public void The_square_root_of_a_fraction_with_large_terms_is_calculated_correctly() {
        // Arrange (4/1)
        var largeNumber = BigInteger.Pow(10, 309);
        var fraction = new Fraction(4 * largeNumber, largeNumber, false); 
        // Act
        var actual = fraction.Sqrt();
        //Assert
        actual.Should().Be(2);
    }

    [Test]
    public void The_square_root_of_a_fraction_with_large_terms_is_calculated_correctly_when_smaller_than_1() {
        // Arrange (1/4)
        var largeNumber = BigInteger.Pow(10, 309);
        var fraction = new Fraction(largeNumber, 4 * largeNumber, false); // 1/4
        // Act
        var actual = fraction.Sqrt();
        //Assert
        actual.Should().Be(0.5m);
    }
}
