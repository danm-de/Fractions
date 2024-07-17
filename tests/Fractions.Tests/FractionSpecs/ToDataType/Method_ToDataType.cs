using System;
using System.Collections;
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

#if NET
    [Test]
    public void CreateChecked_should_return_NaN_or_throw_an_exception() {
        double.CreateChecked(Fraction.NaN).Should().Be(double.NaN);
        Complex.CreateChecked(Fraction.NaN).Should().Be(new Complex(double.NaN, 0));
        Invoking(() => decimal.CreateChecked(Fraction.NaN)).Should().Throw<DivideByZeroException>();
        float.CreateChecked(Fraction.NaN).Should().Be(float.NaN);
        Half.CreateChecked(Fraction.NaN).Should().Be(Half.NaN);
        Invoking(() => BigInteger.CreateChecked(Fraction.NaN)).Should().Throw<DivideByZeroException>();
        Invoking(() => Int128.CreateChecked(Fraction.NaN)).Should().Throw<DivideByZeroException>();
        Invoking(() => UInt128.CreateChecked(Fraction.NaN)).Should().Throw<DivideByZeroException>();
        Invoking(() => long.CreateChecked(Fraction.NaN)).Should().Throw<DivideByZeroException>();
        Invoking(() => ulong.CreateChecked(Fraction.NaN)).Should().Throw<DivideByZeroException>();
        Invoking(() => int.CreateChecked(Fraction.NaN)).Should().Throw<DivideByZeroException>();
        Invoking(() => int.CreateChecked(Fraction.NaN)).Should().Throw<DivideByZeroException>();
        Invoking(() => uint.CreateChecked(Fraction.NaN)).Should().Throw<DivideByZeroException>();
        Invoking(() => nint.CreateChecked(Fraction.NaN)).Should().Throw<DivideByZeroException>();
        Invoking(() => nint.CreateChecked(Fraction.NaN)).Should().Throw<DivideByZeroException>();
        Invoking(() => UIntPtr.CreateChecked(Fraction.NaN)).Should().Throw<DivideByZeroException>();
        Invoking(() => short.CreateChecked(Fraction.NaN)).Should().Throw<DivideByZeroException>();
        Invoking(() => ushort.CreateChecked(Fraction.NaN)).Should().Throw<DivideByZeroException>();
        Invoking(() => byte.CreateChecked(Fraction.NaN)).Should().Throw<DivideByZeroException>();
        Invoking(() => sbyte.CreateChecked(Fraction.NaN)).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void CreateSaturating_should_return_zero_or_NaN() {
        double.CreateSaturating(Fraction.NaN).Should().Be(double.NaN);
        Complex.CreateSaturating(Fraction.NaN).Should().Be(new Complex(double.NaN, 0));
        decimal.CreateSaturating(Fraction.NaN).Should().Be(decimal.Zero);
        float.CreateSaturating(Fraction.NaN).Should().Be(float.NaN);
        Half.CreateSaturating(Fraction.NaN).Should().Be(Half.NaN);
        BigInteger.CreateSaturating(Fraction.NaN).Should().Be(BigInteger.Zero);
        Int128.CreateSaturating(Fraction.NaN).Should().Be(Int128.Zero);
        UInt128.CreateSaturating(Fraction.NaN).Should().Be(UInt128.Zero);
        long.CreateSaturating(Fraction.NaN).Should().Be(0);
        ulong.CreateSaturating(Fraction.NaN).Should().Be(default);
        int.CreateSaturating(Fraction.NaN).Should().Be(default);
        uint.CreateSaturating(Fraction.NaN).Should().Be(default);
        nint.CreateSaturating(Fraction.NaN).Should().Be(nint.Zero);
        UIntPtr.CreateSaturating(Fraction.NaN).Should().Be(UIntPtr.Zero);
        short.CreateSaturating(Fraction.NaN).Should().Be(default);
        ushort.CreateSaturating(Fraction.NaN).Should().Be(default);
        byte.CreateSaturating(Fraction.NaN).Should().Be(default);
        sbyte.CreateSaturating(Fraction.NaN).Should().Be(default);
    }
#endif
}

[TestFixture]
public class When_converting_PositiveInfinity : Spec {
    [Test]
    public void ToDecimal_should_throw_a_DivideByZeroException() {
        Invoking(() => Fraction.PositiveInfinity.ToDecimal()).Should().Throw<DivideByZeroException>();
    }
    
    [Test]
    public void ToDecimalSaturating_should_return_MaxValue() {
        Fraction.PositiveInfinity.ToDecimalSaturating().Should().Be(decimal.MaxValue);
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

#if NET
    [Test]
    public void CreateChecked_should_return_PositiveInfinity_or_throw_a_DivideByZeroException() {
        double.CreateChecked(Fraction.PositiveInfinity).Should().Be(double.PositiveInfinity);
        Complex.CreateChecked(Fraction.PositiveInfinity).Should().Be(new Complex(double.PositiveInfinity, 0));
        Invoking(() => decimal.CreateChecked(Fraction.PositiveInfinity)).Should().Throw<DivideByZeroException>();
        float.CreateChecked(Fraction.PositiveInfinity).Should().Be(float.PositiveInfinity);
        Half.CreateChecked(Fraction.PositiveInfinity).Should().Be(Half.PositiveInfinity);
        Invoking(() => BigInteger.CreateChecked(Fraction.PositiveInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => Int128.CreateChecked(Fraction.PositiveInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => UInt128.CreateChecked(Fraction.PositiveInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => long.CreateChecked(Fraction.PositiveInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => ulong.CreateChecked(Fraction.PositiveInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => int.CreateChecked(Fraction.PositiveInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => int.CreateChecked(Fraction.PositiveInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => uint.CreateChecked(Fraction.PositiveInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => nint.CreateChecked(Fraction.PositiveInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => nint.CreateChecked(Fraction.PositiveInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => UIntPtr.CreateChecked(Fraction.PositiveInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => short.CreateChecked(Fraction.PositiveInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => ushort.CreateChecked(Fraction.PositiveInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => byte.CreateChecked(Fraction.PositiveInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => sbyte.CreateChecked(Fraction.PositiveInfinity)).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void ToBigInteger_with_saturation_should_throw_OverflowException() {
        Invoking(() => BigInteger.CreateSaturating(Fraction.PositiveInfinity)).Should().Throw<OverflowException>();
    }

    [Test]
    public void CreateSaturating_should_return_MaxValue_or_PositiveInfinity() {
        double.CreateSaturating(Fraction.PositiveInfinity).Should().Be(double.PositiveInfinity);
        Complex.CreateSaturating(Fraction.PositiveInfinity).Should().Be(new Complex(double.PositiveInfinity, 0));
        decimal.CreateSaturating(Fraction.PositiveInfinity).Should().Be(decimal.MaxValue);
        float.CreateSaturating(Fraction.PositiveInfinity).Should().Be(float.PositiveInfinity);
        Half.CreateSaturating(Fraction.PositiveInfinity).Should().Be(Half.PositiveInfinity);
        Int128.CreateSaturating(Fraction.PositiveInfinity).Should().Be(Int128.MaxValue);
        UInt128.CreateSaturating(Fraction.PositiveInfinity).Should().Be(UInt128.MaxValue);
        long.CreateSaturating(Fraction.PositiveInfinity).Should().Be(long.MaxValue);
        ulong.CreateSaturating(Fraction.PositiveInfinity).Should().Be(ulong.MaxValue);
        int.CreateSaturating(Fraction.PositiveInfinity).Should().Be(int.MaxValue);
        uint.CreateSaturating(Fraction.PositiveInfinity).Should().Be(uint.MaxValue);
        nint.CreateSaturating(Fraction.PositiveInfinity).Should().Be(nint.MaxValue);
        UIntPtr.CreateSaturating(Fraction.PositiveInfinity).Should().Be(UIntPtr.MaxValue);
        short.CreateSaturating(Fraction.PositiveInfinity).Should().Be(short.MaxValue);
        ushort.CreateSaturating(Fraction.PositiveInfinity).Should().Be(ushort.MaxValue);
        byte.CreateSaturating(Fraction.PositiveInfinity).Should().Be(byte.MaxValue);
        sbyte.CreateSaturating(Fraction.PositiveInfinity).Should().Be(sbyte.MaxValue);
    }

    [Test]
    public void CreateTruncating_should_return_MaxValue_or_PositiveInfinity() {
        double.CreateTruncating(Fraction.PositiveInfinity).Should().Be(double.PositiveInfinity);
        Complex.CreateTruncating(Fraction.PositiveInfinity).Should().Be(new Complex(double.PositiveInfinity, 0));
        decimal.CreateTruncating(Fraction.PositiveInfinity).Should().Be(decimal.MaxValue);
        float.CreateTruncating(Fraction.PositiveInfinity).Should().Be(float.PositiveInfinity);
        Half.CreateTruncating(Fraction.PositiveInfinity).Should().Be(Half.PositiveInfinity);
        Int128.CreateTruncating(Fraction.PositiveInfinity).Should().Be(Int128.MaxValue);
        UInt128.CreateTruncating(Fraction.PositiveInfinity).Should().Be(UInt128.MaxValue);
        long.CreateTruncating(Fraction.PositiveInfinity).Should().Be(long.MaxValue);
        ulong.CreateTruncating(Fraction.PositiveInfinity).Should().Be(ulong.MaxValue);
        int.CreateTruncating(Fraction.PositiveInfinity).Should().Be(int.MaxValue);
        uint.CreateTruncating(Fraction.PositiveInfinity).Should().Be(uint.MaxValue);
        nint.CreateTruncating(Fraction.PositiveInfinity).Should().Be(nint.MaxValue);
        UIntPtr.CreateTruncating(Fraction.PositiveInfinity).Should().Be(UIntPtr.MaxValue);
        short.CreateTruncating(Fraction.PositiveInfinity).Should().Be(short.MaxValue);
        ushort.CreateTruncating(Fraction.PositiveInfinity).Should().Be(ushort.MaxValue);
        byte.CreateTruncating(Fraction.PositiveInfinity).Should().Be(byte.MaxValue);
        sbyte.CreateTruncating(Fraction.PositiveInfinity).Should().Be(sbyte.MaxValue);
    }

#endif
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
    
#if NET
    [Test]
    public void CreateChecked_should_return_NegativeInfinity_or_throw_a_DivideByZeroException() {
        double.CreateChecked(Fraction.NegativeInfinity).Should().Be(double.NegativeInfinity);
        Complex.CreateChecked(Fraction.NegativeInfinity).Should().Be(new Complex(double.NegativeInfinity, 0));
        Invoking(() => decimal.CreateChecked(Fraction.NegativeInfinity)).Should().Throw<DivideByZeroException>();
        float.CreateChecked(Fraction.NegativeInfinity).Should().Be(float.NegativeInfinity);
        Half.CreateChecked(Fraction.NegativeInfinity).Should().Be(Half.NegativeInfinity);
        Invoking(() => BigInteger.CreateChecked(Fraction.NegativeInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => Int128.CreateChecked(Fraction.NegativeInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => UInt128.CreateChecked(Fraction.NegativeInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => long.CreateChecked(Fraction.NegativeInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => ulong.CreateChecked(Fraction.NegativeInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => int.CreateChecked(Fraction.NegativeInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => int.CreateChecked(Fraction.NegativeInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => uint.CreateChecked(Fraction.NegativeInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => nint.CreateChecked(Fraction.NegativeInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => nint.CreateChecked(Fraction.NegativeInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => UIntPtr.CreateChecked(Fraction.NegativeInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => short.CreateChecked(Fraction.NegativeInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => ushort.CreateChecked(Fraction.NegativeInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => byte.CreateChecked(Fraction.NegativeInfinity)).Should().Throw<DivideByZeroException>();
        Invoking(() => sbyte.CreateChecked(Fraction.NegativeInfinity)).Should().Throw<DivideByZeroException>();
    }

    [Test]
    public void CreateSaturating_BigInteger_should_throw_OverflowException() {
        Invoking(() => BigInteger.CreateSaturating(Fraction.NegativeInfinity)).Should().Throw<OverflowException>();
    }

    [Test]
    public void CreateSaturating_should_return_MinValue_or_NegativeInfinity() {
        double.CreateSaturating(Fraction.NegativeInfinity).Should().Be(double.NegativeInfinity);
        Complex.CreateSaturating(Fraction.NegativeInfinity).Should().Be(new Complex(double.NegativeInfinity, 0));
        decimal.CreateSaturating(Fraction.NegativeInfinity).Should().Be(decimal.MinValue);
        float.CreateSaturating(Fraction.NegativeInfinity).Should().Be(float.NegativeInfinity);
        Half.CreateSaturating(Fraction.NegativeInfinity).Should().Be(Half.NegativeInfinity);
        Int128.CreateSaturating(Fraction.NegativeInfinity).Should().Be(Int128.MinValue);
        UInt128.CreateSaturating(Fraction.NegativeInfinity).Should().Be(UInt128.MinValue);
        long.CreateSaturating(Fraction.NegativeInfinity).Should().Be(long.MinValue);
        ulong.CreateSaturating(Fraction.NegativeInfinity).Should().Be(ulong.MinValue);
        int.CreateSaturating(Fraction.NegativeInfinity).Should().Be(int.MinValue);
        uint.CreateSaturating(Fraction.NegativeInfinity).Should().Be(uint.MinValue);
        nint.CreateSaturating(Fraction.NegativeInfinity).Should().Be(nint.MinValue);
        UIntPtr.CreateSaturating(Fraction.NegativeInfinity).Should().Be(UIntPtr.MinValue);
        short.CreateSaturating(Fraction.NegativeInfinity).Should().Be(short.MinValue);
        ushort.CreateSaturating(Fraction.NegativeInfinity).Should().Be(ushort.MinValue);
        byte.CreateSaturating(Fraction.NegativeInfinity).Should().Be(byte.MinValue);
        sbyte.CreateSaturating(Fraction.NegativeInfinity).Should().Be(sbyte.MinValue);
    }

    [Test]
    public void CreateTruncating_BigInteger_should_throw_OverflowException() {
        Invoking(() => BigInteger.CreateTruncating(Fraction.NegativeInfinity)).Should().Throw<OverflowException>();
    }

    [Test]
    public void CreateTruncating_should_return_MinValue_or_NegativeInfinity() {
        double.CreateTruncating(Fraction.NegativeInfinity).Should().Be(double.NegativeInfinity);
        Complex.CreateTruncating(Fraction.NegativeInfinity).Should().Be(new Complex(double.NegativeInfinity, 0));
        decimal.CreateTruncating(Fraction.NegativeInfinity).Should().Be(decimal.MinValue);
        float.CreateTruncating(Fraction.NegativeInfinity).Should().Be(float.NegativeInfinity);
        Half.CreateTruncating(Fraction.NegativeInfinity).Should().Be(Half.NegativeInfinity);
        Int128.CreateTruncating(Fraction.NegativeInfinity).Should().Be(Int128.MinValue);
        UInt128.CreateTruncating(Fraction.NegativeInfinity).Should().Be(UInt128.MinValue);
        long.CreateTruncating(Fraction.NegativeInfinity).Should().Be(long.MinValue);
        ulong.CreateTruncating(Fraction.NegativeInfinity).Should().Be(ulong.MinValue);
        int.CreateTruncating(Fraction.NegativeInfinity).Should().Be(int.MinValue);
        uint.CreateTruncating(Fraction.NegativeInfinity).Should().Be(uint.MinValue);
        nint.CreateTruncating(Fraction.NegativeInfinity).Should().Be(nint.MinValue);
        UIntPtr.CreateTruncating(Fraction.NegativeInfinity).Should().Be(UIntPtr.MinValue);
        short.CreateTruncating(Fraction.NegativeInfinity).Should().Be(short.MinValue);
        ushort.CreateTruncating(Fraction.NegativeInfinity).Should().Be(ushort.MinValue);
        byte.CreateTruncating(Fraction.NegativeInfinity).Should().Be(byte.MinValue);
        sbyte.CreateTruncating(Fraction.NegativeInfinity).Should().Be(sbyte.MinValue);
    }

#endif
}

[TestFixture]
public class When_fraction_is_converted_to_double : Spec {
    private static IEnumerable TestCases {
        get {
            var largeNumber = BigInteger.Pow(10, 309); // larger than double.MaxValue
            // zero cases
            yield return new TestCaseData(Fraction.Zero).Returns(0.0);
            yield return new TestCaseData(new Fraction(0, 10, false)).Returns(0.0);
            yield return new TestCaseData(new Fraction(0, -10, false)).Returns(0.0);
            yield return new TestCaseData(new Fraction(0, largeNumber, false)).Returns(0.0);
            yield return new TestCaseData(new Fraction(0, -largeNumber, false)).Returns(0.0);
            // positive cases
            yield return new TestCaseData(new Fraction(2)).Returns(2.0);
            yield return new TestCaseData(new Fraction(-2, -1, false)).Returns(2.0);
            yield return new TestCaseData(new Fraction(1, 2, false)).Returns(0.5);
            yield return new TestCaseData(new Fraction(-1, -2, false)).Returns(0.5);
            yield return new TestCaseData(new Fraction(1, 3, false)).Returns(1.0 / 3.0);
            yield return new TestCaseData(new Fraction(-1, -3, false)).Returns(1.0 / 3.0);
            yield return new TestCaseData(new Fraction(largeNumber, BigInteger.One, false)).Returns(double.PositiveInfinity);
            yield return new TestCaseData(new Fraction(-largeNumber, BigInteger.MinusOne, false)).Returns(double.PositiveInfinity);
            yield return new TestCaseData(new Fraction(largeNumber, largeNumber, false)).Returns(1.0);
            yield return new TestCaseData(new Fraction(-largeNumber, -largeNumber, false)).Returns(1.0);
            yield return new TestCaseData(new Fraction(2 * largeNumber, largeNumber, false)).Returns(2.0);
            yield return new TestCaseData(new Fraction(-2 * largeNumber, -largeNumber, false)).Returns(2.0);
            yield return new TestCaseData(new Fraction(largeNumber, 2 * largeNumber, false)).Returns(0.5);
            yield return new TestCaseData(new Fraction(-largeNumber, -2 * largeNumber, false)).Returns(0.5);
            yield return new TestCaseData(new Fraction(2 * largeNumber, 3 * largeNumber, false)).Returns(2.0 / 3.0);
            yield return new TestCaseData(new Fraction(-3 * largeNumber, -2 * largeNumber, false)).Returns(3.0 / 2.0);
            // negative cases
            yield return new TestCaseData(new Fraction(-2)).Returns(-2.0);
            yield return new TestCaseData(new Fraction(2, -1, false)).Returns(-2.0);
            yield return new TestCaseData(new Fraction(-1, 2, false)).Returns(-0.5);
            yield return new TestCaseData(new Fraction(1, -2, false)).Returns(-0.5);
            yield return new TestCaseData(new Fraction(-1, 3, false)).Returns(-1.0 / 3.0);
            yield return new TestCaseData(new Fraction(1, -3, false)).Returns(-1.0 / 3.0);
            yield return new TestCaseData(new Fraction(largeNumber, BigInteger.MinusOne, false)).Returns(double.NegativeInfinity);
            yield return new TestCaseData(new Fraction(-largeNumber, BigInteger.One, false)).Returns(double.NegativeInfinity);
            yield return new TestCaseData(new Fraction(-largeNumber, largeNumber, false)).Returns(-1.0);
            yield return new TestCaseData(new Fraction(largeNumber, -largeNumber, false)).Returns(-1.0);
            yield return new TestCaseData(new Fraction(-2 * largeNumber, largeNumber, false)).Returns(-2.0);
            yield return new TestCaseData(new Fraction(2 * largeNumber, -largeNumber, false)).Returns(-2.0);
            yield return new TestCaseData(new Fraction(-largeNumber, 2 * largeNumber, false)).Returns(-0.5);
            yield return new TestCaseData(new Fraction(largeNumber, -2 * largeNumber, false)).Returns(-0.5);
            yield return new TestCaseData(new Fraction(-2 * largeNumber, 3 * largeNumber, false)).Returns(-2.0 / 3.0);
            yield return new TestCaseData(new Fraction(3 * largeNumber, -2 * largeNumber, false)).Returns(-3.0 / 2.0);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public double Result_should_match_expected_value(Fraction fraction) {
        return fraction.ToDouble();
    }
}

[TestFixture]
public class When_fraction_is_converted_to_decimal : Spec {
    private static IEnumerable TestCases {
        get {
            var largeNumber = 2 * new BigInteger(decimal.MaxValue);
            // zero cases
            yield return new TestCaseData(Fraction.Zero).Returns(0.0);
            yield return new TestCaseData(new Fraction(0, 10, false)).Returns(0.0m);
            yield return new TestCaseData(new Fraction(0, -10, false)).Returns(0.0m);
            yield return new TestCaseData(new Fraction(0, largeNumber, false)).Returns(0.0m);
            yield return new TestCaseData(new Fraction(0, -largeNumber, false)).Returns(0.0m);
            // positive cases
            yield return new TestCaseData(new Fraction(2)).Returns(2.0);
            yield return new TestCaseData(new Fraction(-2, -1, false)).Returns(2.0m);
            yield return new TestCaseData(new Fraction(1, 2, false)).Returns(0.5m);
            yield return new TestCaseData(new Fraction(-1, -2, false)).Returns(0.5m);
            yield return new TestCaseData(new Fraction(1, 3, false)).Returns(1.0m / 3.0m);
            yield return new TestCaseData(new Fraction(-1, -3, false)).Returns(1.0m / 3.0m);
            yield return new TestCaseData(new Fraction(largeNumber, largeNumber, false)).Returns(1.0m);
            yield return new TestCaseData(new Fraction(-largeNumber, -largeNumber, false)).Returns(1.0m);
            yield return new TestCaseData(new Fraction(2 * largeNumber, largeNumber, false)).Returns(2.0m);
            yield return new TestCaseData(new Fraction(-2 * largeNumber, -largeNumber, false)).Returns(2.0m);
            yield return new TestCaseData(new Fraction(largeNumber, 2 * largeNumber, false)).Returns(0.5m);
            yield return new TestCaseData(new Fraction(-largeNumber, -2 * largeNumber, false)).Returns(0.5m);
            yield return new TestCaseData(new Fraction(3 * largeNumber, 2 * largeNumber, false)).Returns(1.5m);
            yield return new TestCaseData(new Fraction(-3 * largeNumber, -2 * largeNumber, false)).Returns(1.5m);
            yield return new TestCaseData(new Fraction(2 * largeNumber, 3 * largeNumber, false)).Returns(2.0m / 3.0m);
            yield return new TestCaseData(new Fraction(-3 * largeNumber, -2 * largeNumber, false)).Returns(3.0m / 2.0m);
            yield return new TestCaseData(Fraction.FromDecimal(decimal.MaxValue)).Returns(decimal.MaxValue);
            yield return new TestCaseData(Fraction.FromDecimal(decimal.MaxValue, false)).Returns(decimal.MaxValue);
            yield return new TestCaseData(new Fraction(BigInteger.One, largeNumber, false)).Returns(0.0m);
            yield return new TestCaseData(new Fraction(BigInteger.MinusOne, -largeNumber, false)).Returns(0.0m);
            yield return new TestCaseData(new Fraction(largeNumber,  largeNumber * largeNumber, false)).Returns(0.0m);
            yield return new TestCaseData(new Fraction(-largeNumber, -(largeNumber * largeNumber), false)).Returns(0.0m);
            // negative cases
            yield return new TestCaseData(new Fraction(-2)).Returns(-2.0m);
            yield return new TestCaseData(new Fraction(2, -1, false)).Returns(-2.0m);
            yield return new TestCaseData(new Fraction(-1, 2, false)).Returns(-0.5m);
            yield return new TestCaseData(new Fraction(1, -2, false)).Returns(-0.5m);
            yield return new TestCaseData(new Fraction(-1, 3, false)).Returns(-1.0m / 3.0m);
            yield return new TestCaseData(new Fraction(1, -3, false)).Returns(-1.0m / 3.0m);
            yield return new TestCaseData(new Fraction(-largeNumber, largeNumber, false)).Returns(-1.0m);
            yield return new TestCaseData(new Fraction(largeNumber, -largeNumber, false)).Returns(-1.0m);
            yield return new TestCaseData(new Fraction(-2 * largeNumber, largeNumber, false)).Returns(-2.0m);
            yield return new TestCaseData(new Fraction(2 * largeNumber, -largeNumber, false)).Returns(-2.0m);
            yield return new TestCaseData(new Fraction(-largeNumber, 2 * largeNumber, false)).Returns(-0.5m);
            yield return new TestCaseData(new Fraction(largeNumber, -2 * largeNumber, false)).Returns(-0.5m);
            yield return new TestCaseData(new Fraction(-3 * largeNumber, 2 * largeNumber, false)).Returns(-1.5m);
            yield return new TestCaseData(new Fraction(3 * largeNumber, -2 * largeNumber, false)).Returns(-1.5m);
            yield return new TestCaseData(new Fraction(-2 * largeNumber, 3 * largeNumber, false)).Returns(-2.0m / 3.0m);
            yield return new TestCaseData(new Fraction(3 * largeNumber, -2 * largeNumber, false)).Returns(-3.0m / 2.0m);
            yield return new TestCaseData(Fraction.FromDecimal(decimal.MinValue)).Returns(decimal.MinValue);
            yield return new TestCaseData(Fraction.FromDecimal(decimal.MinValue, false)).Returns(decimal.MinValue);
            yield return new TestCaseData(new Fraction(BigInteger.MinusOne, largeNumber, false)).Returns(0.0m);
            yield return new TestCaseData(new Fraction(BigInteger.One, -largeNumber, false)).Returns(0.0m);
            yield return new TestCaseData(new Fraction(-largeNumber,  largeNumber * largeNumber, false)).Returns(0.0m);
            yield return new TestCaseData(new Fraction(largeNumber, -(largeNumber * largeNumber), false)).Returns(0.0m);
        }
    }
    
    [Test]
    [TestCaseSource(nameof(TestCases))]
    public decimal Result_should_match_expected_value(Fraction fraction) {
        return fraction.ToDecimal();
    }
    
    [Test]
    public void An_OverflowException_is_thrown_when_result_is_greater_than_MaxValue() {
        Invoking(() => (2 * new Fraction(decimal.MaxValue)).ToDecimal())
            .Should()
            .Throw<OverflowException>();
    }
    
    [Test]
    public void An_OverflowException_is_thrown_when_result_is_smaller_than_MinValue() {
        Invoking(() => (2 * new Fraction(decimal.MinValue)).ToDecimal())
            .Should()
            .Throw<OverflowException>();
    }
}

[TestFixture]
public class When_fraction_is_converted_to_decimal_with_saturation : Spec {
    private static IEnumerable TestCases {
        get {
            var largeNumber = 2 * new BigInteger(decimal.MaxValue);
            // zero cases
            yield return new TestCaseData(Fraction.Zero).Returns(0.0);
            yield return new TestCaseData(new Fraction(0, 10, false)).Returns(0.0m);
            yield return new TestCaseData(new Fraction(0, -10, false)).Returns(0.0m);
            yield return new TestCaseData(new Fraction(0, largeNumber, false)).Returns(0.0m);
            yield return new TestCaseData(new Fraction(0, -largeNumber, false)).Returns(0.0m);
            // positive cases
            yield return new TestCaseData(new Fraction(2)).Returns(2.0);
            yield return new TestCaseData(new Fraction(-2, -1, false)).Returns(2.0m);
            yield return new TestCaseData(new Fraction(1, 2, false)).Returns(0.5m);
            yield return new TestCaseData(new Fraction(-1, -2, false)).Returns(0.5m);
            yield return new TestCaseData(new Fraction(1, 3, false)).Returns(1.0m / 3.0m);
            yield return new TestCaseData(new Fraction(-1, -3, false)).Returns(1.0m / 3.0m);
            yield return new TestCaseData(new Fraction(largeNumber, largeNumber, false)).Returns(1.0m);
            yield return new TestCaseData(new Fraction(-largeNumber, -largeNumber, false)).Returns(1.0m);
            yield return new TestCaseData(new Fraction(2 * largeNumber, largeNumber, false)).Returns(2.0m);
            yield return new TestCaseData(new Fraction(-2 * largeNumber, -largeNumber, false)).Returns(2.0m);
            yield return new TestCaseData(new Fraction(largeNumber, 2 * largeNumber, false)).Returns(0.5m);
            yield return new TestCaseData(new Fraction(-largeNumber, -2 * largeNumber, false)).Returns(0.5m);
            yield return new TestCaseData(new Fraction(3 * largeNumber, 2 * largeNumber, false)).Returns(1.5m);
            yield return new TestCaseData(new Fraction(-3 * largeNumber, -2 * largeNumber, false)).Returns(1.5m);
            yield return new TestCaseData(new Fraction(2 * largeNumber, 3 * largeNumber, false)).Returns(2.0m / 3.0m);
            yield return new TestCaseData(new Fraction(-3 * largeNumber, -2 * largeNumber, false)).Returns(3.0m / 2.0m);
            yield return new TestCaseData(Fraction.FromDecimal(decimal.MaxValue)).Returns(decimal.MaxValue);
            yield return new TestCaseData(Fraction.FromDecimal(decimal.MaxValue, false)).Returns(decimal.MaxValue);
            yield return new TestCaseData(new Fraction(largeNumber, BigInteger.One, false)).Returns(decimal.MaxValue);
            yield return new TestCaseData(new Fraction(largeNumber * largeNumber, largeNumber, false)).Returns(decimal.MaxValue);
            yield return new TestCaseData(new Fraction(BigInteger.One, largeNumber, false)).Returns(0.0m);
            yield return new TestCaseData(new Fraction(BigInteger.MinusOne, -largeNumber, false)).Returns(0.0m);
            yield return new TestCaseData(new Fraction(largeNumber,  largeNumber * largeNumber, false)).Returns(0.0m);
            yield return new TestCaseData(new Fraction(-largeNumber, -(largeNumber * largeNumber), false)).Returns(0.0m);
            // negative cases
            yield return new TestCaseData(new Fraction(-2)).Returns(-2.0m);
            yield return new TestCaseData(new Fraction(2, -1, false)).Returns(-2.0m);
            yield return new TestCaseData(new Fraction(-1, 2, false)).Returns(-0.5m);
            yield return new TestCaseData(new Fraction(1, -2, false)).Returns(-0.5m);
            yield return new TestCaseData(new Fraction(-1, 3, false)).Returns(-1.0m / 3.0m);
            yield return new TestCaseData(new Fraction(1, -3, false)).Returns(-1.0m / 3.0m);
            yield return new TestCaseData(new Fraction(-largeNumber, largeNumber, false)).Returns(-1.0m);
            yield return new TestCaseData(new Fraction(largeNumber, -largeNumber, false)).Returns(-1.0m);
            yield return new TestCaseData(new Fraction(-2 * largeNumber, largeNumber, false)).Returns(-2.0m);
            yield return new TestCaseData(new Fraction(2 * largeNumber, -largeNumber, false)).Returns(-2.0m);
            yield return new TestCaseData(new Fraction(-largeNumber, 2 * largeNumber, false)).Returns(-0.5m);
            yield return new TestCaseData(new Fraction(largeNumber, -2 * largeNumber, false)).Returns(-0.5m);
            yield return new TestCaseData(new Fraction(-3 * largeNumber, 2 * largeNumber, false)).Returns(-1.5m);
            yield return new TestCaseData(new Fraction(3 * largeNumber, -2 * largeNumber, false)).Returns(-1.5m);
            yield return new TestCaseData(new Fraction(-2 * largeNumber, 3 * largeNumber, false)).Returns(-2.0m / 3.0m);
            yield return new TestCaseData(new Fraction(3 * largeNumber, -2 * largeNumber, false)).Returns(-3.0m / 2.0m);
            yield return new TestCaseData(Fraction.FromDecimal(decimal.MinValue)).Returns(decimal.MinValue);
            yield return new TestCaseData(Fraction.FromDecimal(decimal.MinValue, false)).Returns(decimal.MinValue);
            yield return new TestCaseData(new Fraction(-largeNumber, BigInteger.One, false)).Returns(decimal.MinValue);
            yield return new TestCaseData(new Fraction(largeNumber * largeNumber, -largeNumber, false)).Returns(decimal.MinValue);
            yield return new TestCaseData(new Fraction(BigInteger.MinusOne, largeNumber, false)).Returns(0.0m);
            yield return new TestCaseData(new Fraction(BigInteger.One, -largeNumber, false)).Returns(0.0m);
            yield return new TestCaseData(new Fraction(-largeNumber,  largeNumber * largeNumber, false)).Returns(0.0m);
            yield return new TestCaseData(new Fraction(largeNumber, -(largeNumber * largeNumber), false)).Returns(0.0m);
        }
    }
    
    [Test]
    [TestCaseSource(nameof(TestCases))]
    public decimal Result_should_match_expected_value(Fraction fraction) {
        return fraction.ToDecimalSaturating();
    }
}

#if NET
[TestFixture]
public class When_a_finite_positive_fraction_is_converted_to_a_number : Spec {
    [Test]
    public void CreateChecked_should_return_the_expected_value() {
        var fraction = new Fraction(3, 2);

        double.CreateChecked(fraction).Should().Be(1.5);
        Complex.CreateChecked(fraction).Should().Be(new Complex(1.5, 0));
        decimal.CreateChecked(fraction).Should().Be(1.5m);
        float.CreateChecked(fraction).Should().Be(1.5f);
        Half.CreateChecked(fraction).Should().Be((Half)1.5);
        Int128.CreateChecked(fraction).Should().Be(1);
        UInt128.CreateChecked(fraction).Should().Be(1);
        long.CreateChecked(fraction).Should().Be(1);
        ulong.CreateChecked(fraction).Should().Be(1);
        int.CreateChecked(fraction).Should().Be(1);
        uint.CreateChecked(fraction).Should().Be(1);
        nint.CreateChecked(fraction).Should().Be(1);
        UIntPtr.CreateChecked(fraction).Should().Be(1);
        short.CreateChecked(fraction).Should().Be(1);
        ushort.CreateChecked(fraction).Should().Be(1);
        byte.CreateChecked(fraction).Should().Be(1);
        sbyte.CreateChecked(fraction).Should().Be(1);
    }

    [Test]
    public void CreateSaturating_should_return_the_expected_value() {
        var fraction = new Fraction(3, 2);

        double.CreateSaturating(fraction).Should().Be(1.5);
        Complex.CreateSaturating(fraction).Should().Be(new Complex(1.5, 0));
        decimal.CreateSaturating(fraction).Should().Be(1.5m);
        float.CreateSaturating(fraction).Should().Be(1.5f);
        Half.CreateSaturating(fraction).Should().Be((Half)1.5);
        Int128.CreateSaturating(fraction).Should().Be(1);
        UInt128.CreateSaturating(fraction).Should().Be(1);
        long.CreateSaturating(fraction).Should().Be(1);
        ulong.CreateSaturating(fraction).Should().Be(1);
        int.CreateSaturating(fraction).Should().Be(1);
        uint.CreateSaturating(fraction).Should().Be(1);
        nint.CreateSaturating(fraction).Should().Be(1);
        UIntPtr.CreateSaturating(fraction).Should().Be(1);
        short.CreateSaturating(fraction).Should().Be(1);
        ushort.CreateSaturating(fraction).Should().Be(1);
        byte.CreateTruncating(fraction).Should().Be(1);
        sbyte.CreateSaturating(fraction).Should().Be(1);
    }

    [Test]
    public void CreateTruncating_should_return_the_expected_value() {
        var fraction = new Fraction(3, 2);

        double.CreateTruncating(fraction).Should().Be(1.5);
        Complex.CreateTruncating(fraction).Should().Be(new Complex(1.5, 0));
        decimal.CreateTruncating(fraction).Should().Be(1.5m);
        float.CreateTruncating(fraction).Should().Be(1.5f);
        Half.CreateTruncating(fraction).Should().Be((Half)1.5);
        Int128.CreateTruncating(fraction).Should().Be(1);
        UInt128.CreateTruncating(fraction).Should().Be(1);
        long.CreateTruncating(fraction).Should().Be(1);
        ulong.CreateTruncating(fraction).Should().Be(1);
        int.CreateTruncating(fraction).Should().Be(1);
        uint.CreateTruncating(fraction).Should().Be(1);
        nint.CreateTruncating(fraction).Should().Be(1);
        UIntPtr.CreateTruncating(fraction).Should().Be(1);
        short.CreateTruncating(fraction).Should().Be(1);
        ushort.CreateTruncating(fraction).Should().Be(1);
        byte.CreateTruncating(fraction).Should().Be(1);
        sbyte.CreateTruncating(fraction).Should().Be(1);
    }
}

[TestFixture]
public class When_a_finite_negative_fraction_is_converted_to_a_number : Spec {
    [Test]
    public void CreateChecked_should_return_the_expected_value() {
        var fraction = new Fraction(-3, 2);

        double.CreateChecked(fraction).Should().Be(-1.5);
        Complex.CreateChecked(fraction).Should().Be(new Complex(-1.5, 0));
        decimal.CreateChecked(fraction).Should().Be(-1.5m);
        float.CreateChecked(fraction).Should().Be(-1.5f);
        Half.CreateChecked(fraction).Should().Be((Half)(-1.5));
        Int128.CreateChecked(fraction).Should().Be(-1);
        Invoking(() => UInt128.CreateChecked(fraction)).Should().Throw<OverflowException>();
        long.CreateChecked(fraction).Should().Be(-1);
        Invoking(() => ulong.CreateChecked(fraction)).Should().Throw<OverflowException>();
        int.CreateChecked(fraction).Should().Be(-1);
        Invoking(() => uint.CreateChecked(fraction)).Should().Throw<OverflowException>();
        nint.CreateChecked(fraction).Should().Be(-1);
        Invoking(() => UIntPtr.CreateChecked(fraction)).Should().Throw<OverflowException>();
        short.CreateChecked(fraction).Should().Be(-1);
        Invoking(() => ushort.CreateChecked(fraction)).Should().Throw<OverflowException>();
        Invoking(() => byte.CreateChecked(fraction)).Should().Throw<OverflowException>();
        sbyte.CreateChecked(fraction).Should().Be(-1);
    }

    [Test]
    public void CreateSaturating_should_return_the_expected_value() {
        var fraction = new Fraction(-3, 2);

        double.CreateSaturating(fraction).Should().Be(-1.5);
        Complex.CreateSaturating(fraction).Should().Be(new Complex(-1.5, 0));
        decimal.CreateSaturating(fraction).Should().Be(-1.5m);
        float.CreateSaturating(fraction).Should().Be(-1.5f);
        Half.CreateSaturating(fraction).Should().Be((Half)(-1.5));
        Int128.CreateSaturating(fraction).Should().Be(-1);
        UInt128.CreateSaturating(fraction).Should().Be(0);
        long.CreateSaturating(fraction).Should().Be(-1);
        ulong.CreateSaturating(fraction).Should().Be(0);
        int.CreateSaturating(fraction).Should().Be(-1);
        uint.CreateSaturating(fraction).Should().Be(0);
        nint.CreateSaturating(fraction).Should().Be(-1);
        UIntPtr.CreateSaturating(fraction).Should().Be(0);
        short.CreateSaturating(fraction).Should().Be(-1);
        ushort.CreateSaturating(fraction).Should().Be(0);
        byte.CreateSaturating(fraction).Should().Be(0);
        sbyte.CreateSaturating(fraction).Should().Be(-1);
    }

    [Test]
    public void CreateTruncating_should_return_the_expected_value() {
        var fraction = new Fraction(-3, 2);

        double.CreateTruncating(fraction).Should().Be(-1.5);
        Complex.CreateTruncating(fraction).Should().Be(new Complex(-1.5, 0));
        decimal.CreateTruncating(fraction).Should().Be(-1.5m);
        float.CreateTruncating(fraction).Should().Be(-1.5f);
        Half.CreateTruncating(fraction).Should().Be((Half)(-1.5));
        Int128.CreateTruncating(fraction).Should().Be(-1);
        UInt128.CreateTruncating(fraction).Should().Be(new UInt128(18446744073709551615, 18446744073709551615));
        long.CreateTruncating(fraction).Should().Be(-1);
        ulong.CreateTruncating(fraction).Should().Be(18446744073709551615UL);
        int.CreateTruncating(fraction).Should().Be(-1);
        uint.CreateTruncating(fraction).Should().Be(4294967295u);
        nint.CreateTruncating(fraction).Should().Be(-1);
        UIntPtr.CreateTruncating(fraction).Should().Be(new UIntPtr(18446744073709551615));
        short.CreateTruncating(fraction).Should().Be(-1);
        ushort.CreateTruncating(fraction).Should().Be(65535);
        byte.CreateTruncating(fraction).Should().Be(255);
        sbyte.CreateTruncating(fraction).Should().Be(-1);
    }
}
#endif
