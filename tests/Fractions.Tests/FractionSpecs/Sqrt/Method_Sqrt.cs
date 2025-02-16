using System;
using System.Collections.Generic;
using System.Globalization;
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
            yield return new TestCaseData(0);
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
        var actual = fraction.Sqrt(15);
        //Assert
        actual.ToDouble().Should().Be(expected);
    }

    [Test]
    [Ignore("The issue is with the casting to double (fix in #81)")]
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
    [Ignore("The issue is with the casting to double (fix in #81)")]
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

[TestFixture]
public class When_the_root_is_calculated_from_a_fraction_with_a_very_large_numerator_and_denominator : Spec
{
    private Fraction _sut;
    private Fraction _result;
    private Fraction _expected;

    public override void Arrange() {
        var largeNumber = BigInteger.Pow(10, 309);
        var numerator = 4 * largeNumber;
        var denominator = largeNumber;

        _expected = new Fraction(4).Sqrt();

        _sut = new Fraction(numerator, denominator, normalize: false);
    }

    public override void Act() =>
        _result = _sut.Sqrt();

    [Test]
    public void Should_it_return_the_expected_result() =>
        _result.Should().Be(_expected);
}

[TestFixture]
public class When_calculating_the_square_root_of_2_with_high_accuracy : Spec {
    // these are the first 100 decimal places (from http://www.numberworld.org/digits/Sqrt(2)/)
    private const string FirstOneHundredDecimals = "1.4142135623730950488016887242096980785696718753769480731766797379907324784621070388503875343276415727";
    private const int Accuracy = 100;

    private Fraction _result;
    private Fraction _expected;

    public override void Arrange() {
        _expected = Fraction.FromString(FirstOneHundredDecimals, CultureInfo.InvariantCulture);
    }

    public override void Act() {
        _result = Fraction.Two.Sqrt(Accuracy); // the value contains more than the specified accuracy
    }

    [Test]
    public void The_result_is_correct_with_the_specified_accuracy() {
        Fraction.Round(_result, Accuracy).Should().Be(_expected, "The minimum number of decimals is respected");
    }

    [Test]
    public void The_result_contains_additional_decimals() {
        _result.Should().NotBe(_expected, "It contains an excess of decimals (no guarantees for precision)");
    }

    [Test]
    public void The_result_should_be_reduced() {
        _result.State.Should().Be(FractionState.IsNormalized, "Started with a normalized state");
    }
}

[TestFixture]
public class When_calculating_the_square_root_of_a_non_reduced_fraction : Spec {
    private Fraction _fraction;
    private Fraction _result;
    private Fraction _expected;
    
    public override void Arrange() {
        _fraction = new Fraction(9, 1, false);
        _expected = new Fraction(18, 6);
    }
    
    public override void Act() {
        _result = _fraction.Sqrt(); 
    }
    
    [Test]
    public void The_result_should_be_correct() {
        _result.Should().Be(_expected);
    }
    
    [Test]
    public void The_result_should_be_non_reduced() {
        _result.State.Should().Be(FractionState.Unknown, "Started with a unknown state");
    }
}

