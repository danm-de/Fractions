using System;
using System.Collections;
using System.Globalization;
using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.ToDataType;

[TestFixture]
// German: Wenn ein 0 Bruch in ein Decimal konvertiert wird
public class When_zero_fraction_is_converted_to_decimal : Spec {
    [Test]
    // German: Das Ergebnis soll 0 sein
    public void Result_should_be_zero() {
        Fraction.Zero.ToDecimal().Should().Be(0);
    }
}

[TestFixture]
// German: Wenn ein 1viertel in ein Decimal konvertiert wird
public class When_one_quarter_is_converted_to_decimal : Spec {
    [Test]
    // German: Das Ergebnis soll 0.25 sein
    public void Result_should_be_0_25() {
        new Fraction(1, 4).ToDecimal().Should().Be(0.25m);
    }
}

[TestFixture]
// German: Wenn ein Bruch mit long MaxValue von Fraction in int konvertiert wird
public class When_fraction_with_long_MaxValue_is_converted_to_int : Spec {
    [Test]
    // German: Das sollte eine OverflowException werfen
    public void Should_throw_an_OverflowException() {
        Invoking(() => new Fraction(long.MaxValue).ToInt32())
            .Should()
            .Throw<OverflowException>();
    }
}

[TestFixture]
public class When_fraction_with_non_decimal_denominator_is_converted_to_decimal : Spec {
    private Fraction _fraction;
    private decimal _result;

    public override void SetUp() {
        var threeNinths = new Fraction(3, 9).ToDecimal();
        var sixNinths = new Fraction(6, 9).ToDecimal();
        _fraction = new Fraction(threeNinths) * new Fraction(sixNinths);
    }

    public override void Act() {
        _result = _fraction.ToDecimal();
    }

    [Test]
    // German: Das Resultat soll dem erwarteten Ergebnis entsprechen
    public void Result_should_match_expected_value() {
        Math.Round(_result, 27).Should().Be(0.222222222222222222222222222m);
    }
}

[TestFixture]
// German: Wenn ein Bruch mit sehr großen Zahlen in Zähler und Nenner in ein Decimal konvertiert wird
public class When_fraction_with_large_numerator_and_denominator_is_converted_to_decimal : Spec {
    private Fraction _fraction;
    private decimal _result;

    public override void SetUp() {
        _fraction = new Fraction(new BigInteger(decimal.MaxValue) * -10, new BigInteger(decimal.MaxValue) * 20, false);
    }

    public override void Act() {
        _result = _fraction.ToDecimal();
    }

    [Test]
    public void Result_should_match_expected_value() {
        _result.Should().Be(-0.5m);
    }
}

[TestFixture]
public class When_user_converts_fraction_to_BigInteger : Spec {
    private static IEnumerable TestCases {
        get {
            yield return new TestCaseData(new Fraction(0)).Returns(new BigInteger(0));
            yield return new TestCaseData(new Fraction(1)).Returns(new BigInteger(1));
            yield return new TestCaseData(new Fraction(-1)).Returns(new BigInteger(-1));
            yield return
                new TestCaseData(new Fraction(new BigInteger(long.MaxValue), new BigInteger(1))).Returns(
                    new BigInteger(long.MaxValue));
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public BigInteger Result_should_be_correct(Fraction value) {
        return value.ToBigInteger();
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public BigInteger Result_should_be_correct_when_using_explicit_cast(Fraction value) {
        return (BigInteger)value;
    }
}

[TestFixture]
public class When_converting_NaN : Spec {
    [Test]
    public void ToDecimal_should_throw_a_DivideByZeroException() {
        Invoking(() => Fraction.NaN.ToDecimal()).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void ToInt32_should_throw_a_DivideByZeroException() {
        Invoking(() => Fraction.NaN.ToInt32()).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void ToInt64_should_throw_a_DivideByZeroException() {
        Invoking(() => Fraction.NaN.ToInt64()).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void ToUInt32_should_throw_a_DivideByZeroException() {
        Invoking(() => Fraction.NaN.ToUInt32()).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void ToUInt64_should_throw_a_DivideByZeroException() {
        Invoking(() => Fraction.NaN.ToUInt64()).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void ToBigInteger_should_throw_a_DivideByZeroException() {
        Invoking(() => Fraction.NaN.ToBigInteger()).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void ToDouble_should_return_NaN() {
        Fraction.NaN.ToDouble().Should().Be(double.NaN);
    }
}

[TestFixture]
public class When_converting_PositiveInfinity : Spec {
    [Test]
    public void ToDecimal_should_throw_a_DivideByZeroException() {
        Invoking(() => Fraction.PositiveInfinity.ToDecimal()).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void ToInt32_should_throw_a_DivideByZeroException() {
        Invoking(() => Fraction.PositiveInfinity.ToInt32()).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void ToInt64_should_throw_a_DivideByZeroException() {
        Invoking(() => Fraction.PositiveInfinity.ToInt64()).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void ToUInt32_should_throw_a_DivideByZeroException() {
        Invoking(() => Fraction.PositiveInfinity.ToUInt32()).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void ToUInt64_should_throw_a_DivideByZeroException() {
        Invoking(() => Fraction.PositiveInfinity.ToUInt64()).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void ToBigInteger_should_throw_a_DivideByZeroException() {
        Invoking(() => Fraction.PositiveInfinity.ToBigInteger()).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void ToDouble_should_return_PositiveInfinity() {
        Fraction.PositiveInfinity.ToDouble().Should().Be(double.PositiveInfinity);
    }
}

[TestFixture]
public class When_converting_NegativeInfinity : Spec {
    [Test]
    public void ToDecimal_should_throw_a_DivideByZeroException() {
        Invoking(() => Fraction.NegativeInfinity.ToDecimal()).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void ToInt32_should_throw_a_DivideByZeroException() {
        Invoking(() => Fraction.NegativeInfinity.ToInt32()).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void ToInt64_should_throw_a_DivideByZeroException() {
        Invoking(() => Fraction.NegativeInfinity.ToInt64()).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void ToUInt32_should_throw_a_DivideByZeroException() {
        Invoking(() => Fraction.NegativeInfinity.ToUInt32()).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void ToUInt64_should_throw_a_DivideByZeroException() {
        Invoking(() => Fraction.NegativeInfinity.ToUInt64()).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void ToBigInteger_should_throw_a_DivideByZeroException() {
        Invoking(() => Fraction.NegativeInfinity.ToBigInteger()).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void ToDouble_should_return_NegativeInfinity() {
        Fraction.NegativeInfinity.ToDouble().Should().Be(double.NegativeInfinity);
    }
}

[TestFixture]
public class When_converting_to_decimal_with_trailing_zeros : Spec {
    [Test]
    public void Zero_fraction_converts_with_exact_precision() {
        var fraction = new Fraction(0, 100, false);
        var decimalWithTrailingZeros = fraction.ToDecimalWithTrailingZeros();
        decimalWithTrailingZeros.ToString(CultureInfo.InvariantCulture).Should().Be("0.00");
    }

    [Test]
    public void Zero_fraction_with_negative_denominator_converts_with_exact_precision() {
        var fraction = new Fraction(0, -100, false);
        var decimalWithTrailingZeros = fraction.ToDecimalWithTrailingZeros();
        decimalWithTrailingZeros.ToString(CultureInfo.InvariantCulture).Should().Be("0.00");
    }

    [Test]
    public void Zero_fraction_without_trailing_zeros_converts_with_exact_precision() {
        var fraction = Fraction.Zero;
        var decimalWithTrailingZeros = fraction.ToDecimalWithTrailingZeros();
        decimalWithTrailingZeros.ToString(CultureInfo.InvariantCulture).Should().Be("0");
    }

    [Test]
    public void Positive_integer_fraction_converts_with_exact_precision() {
        var fraction = new Fraction(49500, 550, false);
        var decimalWithTrailingZeros = fraction.ToDecimalWithTrailingZeros();
        decimalWithTrailingZeros.ToString(CultureInfo.InvariantCulture).Should().Be("90.0");
    }

    [Test]
    public void Positive_decimal_fraction_converts_with_exact_precision() {
        var fraction = new Fraction(49500, 27500, false);
        var decimalWithTrailingZeros = fraction.ToDecimalWithTrailingZeros();
        decimalWithTrailingZeros.ToString(CultureInfo.InvariantCulture).Should().Be("1.800");
    }

    [Test]
    public void Positive_decimal_fraction_with_no_trailing_zeros_converts_with_exact_precision() {
        var fraction = new Fraction(18, 1000, false);
        var decimalWithTrailingZeros = fraction.ToDecimalWithTrailingZeros();
        decimalWithTrailingZeros.ToString(CultureInfo.InvariantCulture).Should().Be("0.018");
    }

    [Test]
    public void Positive_non_terminating_fraction_converts_without_extra_zeros() {
        var fraction = new Fraction(200, 90, false);
        var decimalWithTrailingZeros = fraction.ToDecimalWithTrailingZeros();
        decimalWithTrailingZeros.ToString(CultureInfo.InvariantCulture).Should().Be("2.2222222222222222222222222222");
    }

    [Test]
    public void Positive_fraction_outside_the_decimal_range_converts_with_exact_precision() {
        var fraction = new Fraction(new BigInteger(decimal.MaxValue) * 10, new BigInteger(decimal.MaxValue) * 20, false);
        var decimalWithTrailingZeros = fraction.ToDecimalWithTrailingZeros();
        decimalWithTrailingZeros.ToString(CultureInfo.InvariantCulture).Should().Be("0.50");
    }

    [Test]
    public void Negative_integer_fraction_converts_with_exact_precision() {
        var fraction = new Fraction(-49500, 550, false);
        var decimalWithTrailingZeros = fraction.ToDecimalWithTrailingZeros();
        decimalWithTrailingZeros.ToString(CultureInfo.InvariantCulture).Should().Be("-90.0");
    }

    [Test]
    public void Negative_decimal_fraction_converts_with_exact_precision() {
        var fraction = new Fraction(49500, -27500, false);
        var decimalWithTrailingZeros = fraction.ToDecimalWithTrailingZeros();
        decimalWithTrailingZeros.ToString(CultureInfo.InvariantCulture).Should().Be("-1.800");
    }

    [Test]
    public void Negative_decimal_fraction_with_no_trailing_zeros_converts_with_exact_precision() {
        var fraction = new Fraction(18, -1000, false);
        var decimalWithTrailingZeros = fraction.ToDecimalWithTrailingZeros();
        decimalWithTrailingZeros.ToString(CultureInfo.InvariantCulture).Should().Be("-0.018");
    }

    [Test]
    public void Negative_non_terminating_fraction_converts_without_extra_zeros() {
        var fraction = new Fraction(-200, 90, false);
        var decimalWithTrailingZeros = fraction.ToDecimalWithTrailingZeros();
        decimalWithTrailingZeros.ToString(CultureInfo.InvariantCulture).Should().Be("-2.2222222222222222222222222222");
    }

    [Test]
    public void Negative_fraction_outside_the_decimal_range_converts_with_exact_precision() {
        var fraction = new Fraction(new BigInteger(decimal.MaxValue) * -10, new BigInteger(decimal.MaxValue) * 20, false);
        var decimalWithTrailingZeros = fraction.ToDecimalWithTrailingZeros();
        decimalWithTrailingZeros.ToString(CultureInfo.InvariantCulture).Should().Be("-0.50");
    }
}
