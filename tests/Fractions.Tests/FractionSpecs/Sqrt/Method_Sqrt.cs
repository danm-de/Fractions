using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

    [Test]
    public void The_square_root_of_NaN_should_return_NaN() {
        var result = Fraction.MinusOne.Sqrt();
        ((object)result).Should().Be(
            expected: Fraction.NaN,
            comparer: StrictTestComparer.Instance,
            because: "Cannot calculate square root from NaN");
    }

    [Test]
    public void The_square_root_of_positive_infinity_should_return_PositiveInfinity() {
        var result = Fraction.PositiveInfinity.Sqrt();
        ((object)result).Should().Be(
            expected: Fraction.PositiveInfinity,
            comparer: StrictTestComparer.Instance,
            because: "Positive infinity is squared is still infinite");
    }

    [Test]
    public void The_square_root_of_negative_infinity_should_return_NegativeInfinity() {
        var result = Fraction.NegativeInfinity.Sqrt();
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
            yield return new TestCaseData(1024);
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
        actual.ToDouble().Should().BeApproximately(expected, expected / Math.Pow(10, 15));
        actual.State.Should().Be(FractionState.IsNormalized);
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
        actual.State.Should().Be(FractionState.Unknown);
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
        actual.State.Should().Be(FractionState.Unknown);
    }

    [Test]
    public void ArgumentOutOfRangeException_is_thrown_when_the_accuracy_is_negative() {
        Assert.Throws<ArgumentOutOfRangeException>(() => Fraction.One.Sqrt(-1));
    }
    
    [TestCase(2, 1)]
    [TestCase(10, 1)]
    [TestCase(30, 20)]
    [TestCase(200, 300)]
    [TestCase(1234, 56789)]
    public void The_square_root_of_a_very_large_fraction_is_calculated_exactly(int numeratorScale, int denominatorScale)
    {
        var expectedValue = new Fraction(numeratorScale * new BigInteger(double.MaxValue), denominatorScale);
        var fraction = expectedValue * expectedValue;

        var actualValue = fraction.Sqrt(190); // double.MaxValue ~= 1.8e308 but the exact value is found early
            
        actualValue.Should().Be(expectedValue);
    }
    
    [TestCase(2, 1)]
    [TestCase(10, 1)]
    [TestCase(30, 20)]
    [TestCase(200, 300)]
    [TestCase(1234, 56789)]
    public void The_square_root_of_a_very_small_fraction_is_calculated_exactly(int numeratorScale, int denominatorScale)
    {
        var expectedValue = new Fraction(numeratorScale, denominatorScale * new BigInteger(double.MaxValue));
        var fraction = expectedValue * expectedValue;

        var actualValue = fraction.Sqrt(190); // double.MaxValue ~= 1.8e308 but the exact value is found early
            
        actualValue.Should().Be(expectedValue);
    }
    
    [TestCase(1UL)]
    [TestCase(20UL)]
    [TestCase(300000UL)]
    [TestCase(9007199254740993UL)]
    [TestCase((ulong)long.MaxValue)]
    [TestCase(ulong.MaxValue)]
    public void The_square_root_of_a_very_large_whole_number_is_calculated_with_the_specified_accuracy(ulong scale)
    {
        var expectedValue = scale * (BigInteger)double.MaxValue;
        Fraction squaredValue = BigInteger.Pow(expectedValue, 2);
        var expectedString = expectedValue.ToString("G");
        var maxDigits = expectedString.Length;

        for (var digits = 1; digits < maxDigits; digits++)
        {
            var result = squaredValue.Sqrt(digits);

            if (result == expectedValue)
            {
                break; // the extra digits happened to be correct (compounding probability)
            }
            
            var absoluteDifference = Fraction.Abs(expectedValue - result);
            absoluteDifference.Should().BeLessThan(expectedValue / BigInteger.Pow(10, digits), "The minimum accuracy is respected");
        }

        squaredValue.Sqrt(maxDigits).Should().Be(expectedValue);
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

    private Fraction _expected;
    private Fraction[] _results;

    public override void Arrange() {
        _expected = Fraction.FromString(FirstOneHundredDecimals, CultureInfo.InvariantCulture);
    }

    public override void Act() {
        _results = Enumerable.Range(1, Accuracy).Select(accuracy => Fraction.Two.Sqrt(accuracy)).ToArray();
    }

    private IEnumerable<(int accuracy, Fraction result)> Results() {
        return Enumerable.Range(1, Accuracy).Zip(_results, (accuracy, result) => (accuracy, result));
    }

    [Test]
    public void The_result_is_correct_with_the_specified_accuracy() {
        Results().Should().AllSatisfy(tuple => {
            var (accuracy, result) = tuple;
            var absoluteDifference = Fraction.Abs(_expected - result);
            absoluteDifference.Should().BeLessThan(_expected / BigInteger.Pow(10, accuracy), "The minimum accuracy is respected");
        });
    }

    [Test]
    public void The_result_contains_additional_decimals() {
        Results().Should().AllSatisfy(tuple => {
            var (accuracy, result) = tuple;
            // Sqrt(2, 1) ~= 14/10, Sqrt(2, 2) ~= 141/100.. Sqrt(2, n) = a/b with len(a) ~= n
            result.Numerator.ToString().Length.Should().BeInRange(accuracy, 1 + (int)(accuracy * 1.21), "It contains an excess (~20%) of decimals (no guarantees for precision)");
        });
    }

    [Test]
    public void The_result_should_be_reduced() {
        _results.Should().AllSatisfy(x => x.State.Should().Be(FractionState.IsNormalized, "Started with a normalized state"));
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
