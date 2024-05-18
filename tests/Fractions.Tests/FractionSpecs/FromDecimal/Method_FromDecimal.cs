using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.FromDecimal;

[TestFixture]
public class When_a_fraction_is_created_with_a_0_decimal_number : Spec {
    private Fraction _fraction;

    public override void SetUp() {
        base.SetUp();
        _fraction = Fraction.FromDecimal(decimal.Zero);
    }

    [Test]
    public void The_value_should_then_be_0() {
        _fraction.Should().Be(Fraction.Zero);
    }
}

[TestFixture]
public class When_a_fraction_is_created_with_a_minus_1_decimal_number : Spec {
    private Fraction _fraction;

    public override void SetUp() {
        base.SetUp();
        _fraction = Fraction.FromDecimal(decimal.MinusOne);
    }

    [Test]
    public void The_value_should_then_be_minus_1() {
        _fraction.Should().Be(new Fraction(-1, 1));
    }
}

[TestFixture]
public class When_a_fraction_is_created_with_a_1_decimal_number : Spec {
    private Fraction _fraction;

    public override void SetUp() {
        base.SetUp();
        _fraction = Fraction.FromDecimal(decimal.One);
    }

    [Test]
    public void The_value_should_then_be_1() {
        _fraction.Should().Be(new Fraction(1, 1));
    }
}

[TestFixture]
public class When_a_fraction_is_created_with_a_1_point_345_decimal_number : Spec {
    private Fraction _fraction;

    public override void SetUp() {
        base.SetUp();
        _fraction = Fraction.FromDecimal(1.345m);
    }

    [Test]
    public void The_fraction_should_then_have_a_numerator_of_269() {
        _fraction.Numerator.Should().Be(new BigInteger(269));
    }

    [Test]
    public void The_fraction_should_then_have_a_denominator_of_200() {
        _fraction.Denominator.Should().Be(new BigInteger(200));
    }
}

[TestFixture]
public class When_a_fraction_is_created_with_decimal_MaxValue : Spec {
    private Fraction _fraction;

    public override void SetUp() {
        base.SetUp();
        _fraction = Fraction.FromDecimal(decimal.MaxValue);
    }

    [Test]
    public void The_fraction_should_then_have_a_numerator_of_decimal_MaxValue() {
        _fraction.Numerator.Should().Be(new BigInteger(decimal.MaxValue));
    }

    [Test]
    public void The_fraction_should_then_have_a_denominator_of_1() {
        _fraction.Denominator.Should().Be(new BigInteger(1));
    }
}

[TestFixture]
public class When_a_fraction_is_created_with_decimal_MinValue : Spec {
    private Fraction _fraction;

    public override void SetUp() {
        base.SetUp();
        _fraction = Fraction.FromDecimal(decimal.MinValue);
    }

    [Test]
    public void The_fraction_should_then_have_a_numerator_of_minus_decimal_MaxValue() {
        _fraction.Numerator.Should().Be(BigInteger.Negate(new BigInteger(decimal.MaxValue)));
    }

    [Test]
    public void The_fraction_should_then_have_a_denominator_of_1() {
        _fraction.Denominator.Should().Be(new BigInteger(1));
    }
}

[TestFixture]
public class When_a_fraction_is_created_with_1_third : Spec {
    private Fraction _fraction;

    public override void SetUp() {
        base.SetUp();
        _fraction = Fraction.FromDecimal(1.0m / 3.0m);
    }

    [Test]
    public void The_fraction_should_then_have_a_numerator_of_3333333333333333333333333333() {
        _fraction.Numerator.Should().Be(BigInteger.Parse("3333333333333333333333333333"));
    }

    [Test]
    public void The_fraction_should_then_have_a_denominator_of_10000000000000000000000000000() {
        _fraction.Denominator.Should().Be(BigInteger.Parse("10000000000000000000000000000"));
    }

    [Test]
    public void The_fraction_should_have_the_value_0_33333333333333() {
        _fraction.ToDecimal().Should().Be(1.0m / 3.0m);
    }
}

[TestFixture]
public class When_a_fraction_is_created_with_decimal_test_numbers : Spec {
    private static IEnumerable<TestCaseData> TestCaseSource {
        get {
            yield return new TestCaseData(10000000000000000000000000000.0m);
            yield return new TestCaseData(100000000000000.0m);
            yield return new TestCaseData(100000000000000.00000000000000m);
            yield return new TestCaseData(123456789.0m);
            yield return new TestCaseData(0.123456789m);
            yield return new TestCaseData(0.000000000123456789m);
            yield return new TestCaseData(4294967295.0m);
            yield return new TestCaseData(18446744073709551615.0m);
            yield return new TestCaseData(7.9228162514264337593543950335m);
            yield return new TestCaseData(7.05m);
            yield return new TestCaseData(7.050m);
            yield return new TestCaseData(70.05m);
            yield return new TestCaseData(70.050m);
            yield return new TestCaseData(50.0m);
            yield return new TestCaseData(0.50m);
            yield return new TestCaseData(-10000000000000000000000000000.0m);
            yield return new TestCaseData(-100000000000000.0m);
            yield return new TestCaseData(-100000000000000.00000000000000m);
            yield return new TestCaseData(-123456789.0m);
            yield return new TestCaseData(-0.123456789m);
            yield return new TestCaseData(-0.000000000123456789m);
            yield return new TestCaseData(-4294967295.0m);
            yield return new TestCaseData(-18446744073709551615.0m);
            yield return new TestCaseData(-7.9228162514264337593543950335m);
            yield return new TestCaseData(-7.05m);
            yield return new TestCaseData(-7.050m);
            yield return new TestCaseData(-70.05m);
            yield return new TestCaseData(-70.050m);
            yield return new TestCaseData(-50.0m);
            yield return new TestCaseData(-0.50m);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCaseSource))]
    public void The_fraction_should_have_the_same_value_after_being_converted_back_to_decimal(decimal value) {
        var fraction = Fraction.FromDecimal(value);
        fraction.ToDecimal().Should().Be(value);
    }

    [Test]
    [TestCaseSource(nameof(TestCaseSource))]
    public void The_unreduced_fraction_preserves_the_decimal_precision(decimal value) {
        var fraction = Fraction.FromDecimal(value, reduceTerms:false);
        fraction.ToDecimalWithTrailingZeros().ToString(CultureInfo.InvariantCulture)
            .Should().Be(value.ToString(CultureInfo.InvariantCulture));
    }
}


[TestFixture]
public class When_a_fraction_is_created_with_decimal_without_reduction : Spec {
    private static IEnumerable<TestCaseData> TestCaseSource {
        get {
            // positive cases
            yield return new TestCaseData(1.0m)
                .Returns(new Fraction(10, 10, false));
            yield return new TestCaseData(1.00m)
                .Returns(new Fraction(100, 100, false));
            yield return new TestCaseData(10.0m)
                .Returns(new Fraction(100, 10, false));
            // zero
            yield return new TestCaseData(decimal.Zero)
                .Returns(new Fraction(0, 1, false));
            yield return new TestCaseData(0.0m)
                .Returns(new Fraction(0, 10, false));
            // negative cases
            yield return new TestCaseData(-1.0m)
                .Returns(new Fraction(-10, 10, false));
            yield return new TestCaseData(-1.00m)
                .Returns(new Fraction(-100, 100, false));
            yield return new TestCaseData(-10.0m)
                .Returns(new Fraction(- 100,10, false));
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCaseSource))]
    public Fraction The_fraction_should_maintain_the_initial_precision(decimal value) {
        var fraction = Fraction.FromDecimal(value, reduceTerms:false);
        fraction.ToDecimal().Should().Be(value);
        return fraction;
    }
}
