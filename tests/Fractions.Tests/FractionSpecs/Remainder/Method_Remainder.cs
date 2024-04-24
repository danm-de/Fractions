using System.Collections.Generic;
using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Remainder;

[TestFixture]
// German: Wenn 1 Mod 3 errechnet wird
public class When_calculating_1_mod_3 : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(1);
        _b = new Fraction(3);
    }

    public override void Act() {
        _result = _a.Remainder(_b);
    }

    [Test]
    // German: Soll 1 als Ergebnis zurückgeliefert werden
    public void Should_return_1_as_the_result() {
        _result.Should().Be(new Fraction(1));
    }
}

[TestFixture]
// German: Wenn 0 Mod 3 errechnet wird
public class When_calculating_0_mod_3 : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(0);
        _b = new Fraction(3);
    }

    public override void Act() {
        _result = _a.Remainder(_b);
    }

    [Test]
    // German: Soll 0 als Ergebnis zurückgeliefert werden
    public void Should_return_0_as_the_result() {
        _result.Should().Be(new Fraction(0));
    }
}

[TestFixture]
// German: Wenn 4 Mod 3 errechnet wird
public class When_calculating_4_mod_3 : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(4);
        _b = new Fraction(3);
    }

    public override void Act() {
        _result = _a.Remainder(_b);
    }

    [Test]
    // German: Soll 1 als Ergebnis zurückgeliefert werden
    public void Should_return_1_as_the_result() {
        _result.Should().Be(new Fraction(1));
    }
}

[TestFixture]
// German: Wenn 5 Mod 3 errechnet wird
public class When_calculating_5_mod_3 : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(5);
        _b = new Fraction(3);
    }

    public override void Act() {
        _result = _a.Remainder(_b);
    }

    [Test]
    // German: Soll 2 als Ergebnis zurückgeliefert werden
    public void Should_return_2_as_the_result() {
        _result.Should().Be(new Fraction(2));
    }
}

[TestFixture]
// German: Wenn minus5 Mod 3 errechnet wird
public class When_calculating_minus5_mod_3 : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(-5);
        _b = new Fraction(3);
    }

    public override void Act() {
        _result = _a.Remainder(_b);
    }

    [Test]
    // German: Soll minus2 als Ergebnis zurückgeliefert werden
    public void Should_return_minus2_as_the_result() {
        _result.Should().Be(new Fraction(-2));
    }
}

[TestFixture]
// German: Wenn minus5 Mod minus3 errechnet wird
public class When_calculating_minus5_mod_minus3 : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(-5);
        _b = new Fraction(-3);
    }

    public override void Act() {
        _result = _a.Remainder(_b);
    }

    [Test]
    // German: Soll minus2 als Ergebnis zurückgeliefert werden
    public void Should_return_minus2_as_the_result() {
        _result.Should().Be(new Fraction(-2));
    }
}

[TestFixture]
// German: Wenn 5 Mod minus3 errechnet wird
public class When_calculating_5_mod_minus3 : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(5);
        _b = new Fraction(-3);
    }

    public override void Act() {
        _result = _a.Remainder(_b);
    }

    [Test]
    // German: Soll 2 als Ergebnis zurückgeliefert werden
    public void Should_return_2_as_the_result() {
        _result.Should().Be(new Fraction(2));
    }
}

[TestFixture]
// German: Wenn 6 Mod 3 errechnet wird
public class When_calculating_6_mod_3 : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(6);
        _b = new Fraction(3);
    }

    public override void Act() {
        _result = _a.Remainder(_b);
    }

    [Test]
    // German: Soll 0 als Ergebnis zurückgeliefert werden
    public void Should_return_0_as_the_result() {
        _result.Should().Be(new Fraction(0));
    }
}

[TestFixture]
// German: Wenn 6 Mod 0 errechnet wird
public class When_calculating_6_mod_0 : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(6);
        _b = new Fraction(0);
    }

    public override void Act() {
        _result = _a.Remainder(_b);
    }

    [Test]
    public void Should_return_NaN_as_the_result() {
        _result.Should().Be(Fraction.NaN);
    }
}

[TestFixture]
// German: Wenn 2,5 Mod 0,5 errechnet wird
public class When_calculating_2_point_5_mod_0_point_5 : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(5, 2);
        _b = new Fraction(1, 2);
    }

    public override void Act() {
        _result = _a.Remainder(_b);
    }

    [Test]
    // German: Soll 0 als Ergebnis zurückgeliefert werden
    public void Should_return_0_as_the_result() {
        _result.Should().Be(new Fraction(0));
    }
}

[TestFixture]
// German: Wenn 2,3 Mod 0,5 errechnet wird
public class When_calculating_2_point_3_mod_0_point_5 : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(23, 10);
        _b = new Fraction(1, 2);
    }

    public override void Act() {
        _result = _a.Remainder(_b);
    }

    [Test]
    // German: Soll 0,3 als Ergebnis zurückgeliefert werden
    public void Should_return_0_point_3_as_the_result() {
        _result.Should().Be(new Fraction(3, 10));
    }
}

[TestFixture]
// German: Wenn 131 Mod 320 errechnet wird
public class When_calculating_131_mod_320 : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = 131;
        _b = 320;
    }

    public override void Act() {
        _result = _a % _b;
    }

    [Test]
    // German: Soll 131 als Ergebnis zurückgeliefert werden
    public void Should_return_131_as_the_result() {
        _result.Should().Be(new Fraction(131));
    }
}

[TestFixture]
// German: Wenn 60 Mod 100 errechnet wird
public class When_calculating_60_mod_100 : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = 60;
        _b = 100;
    }

    public override void Act() {
        _result = _a % _b;
    }

    [Test]
    // German: Soll 60 als Ergebnis zurückgeliefert werden
    public void Should_return_60_as_the_result() {
        _result.Should().Be(new Fraction(60));
    }
}

[TestFixture]
public class When_calculating_the_remainder_of_Zero : Spec{
    
    public static IEnumerable<TestCaseData> TestCases {
        get {
            yield return new TestCaseData(Fraction.Zero, Fraction.Zero).Returns(Fraction.NaN);
            yield return new TestCaseData(default(Fraction), Fraction.One).Returns(Fraction.Zero);
            yield return new TestCaseData(Fraction.Zero, new Fraction(4)).Returns(Fraction.Zero);
            yield return new TestCaseData(new Fraction(BigInteger.Zero, 10, false), Fraction.One).Returns(Fraction.Zero);
            yield return new TestCaseData(new Fraction(BigInteger.Zero, -10, false), Fraction.Two).Returns(Fraction.Zero);
            yield return new TestCaseData(Fraction.Zero, Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.Zero, Fraction.PositiveInfinity).Returns(Fraction.Zero);
            yield return new TestCaseData(Fraction.Zero, Fraction.NegativeInfinity).Returns(Fraction.Zero);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public Fraction The_result_should_be_Zero_or_NaN(Fraction fraction, Fraction divisor) {
        return fraction.Remainder(divisor);
    }
}

[TestFixture]
public class When_calculating_the_remainder_of_NaN : Spec{
    
    public static IEnumerable<TestCaseData> TestCases {
        get {
            yield return new TestCaseData(Fraction.NaN, Fraction.Zero).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(4)).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(-4)).Returns(Fraction.NaN);
            yield return new TestCaseData(new Fraction(10, BigInteger.Zero, false), Fraction.One).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.PositiveInfinity).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.NegativeInfinity).Returns(Fraction.NaN);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public Fraction The_result_should_be_NaN(Fraction fraction, Fraction divisor) {
        return fraction.Remainder(divisor);
    }
}

[TestFixture]
public class When_calculating_the_remainder_of_Infinity : Spec{
    
    public static IEnumerable<TestCaseData> TestCases {
        get {
            // positive infinity
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.Zero).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(4)).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(-4)).Returns(Fraction.NaN);
            yield return new TestCaseData(new Fraction(10, BigInteger.Zero, false), Fraction.One).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.PositiveInfinity).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NegativeInfinity).Returns(Fraction.NaN);
            // negative infinity
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.Zero).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(4)).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-4)).Returns(Fraction.NaN);
            yield return new TestCaseData(new Fraction(-10, BigInteger.Zero, false), Fraction.Two).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.PositiveInfinity).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NegativeInfinity).Returns(Fraction.NaN);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public Fraction The_result_should_be_NaN(Fraction fraction, Fraction divisor) {
        return fraction.Remainder(divisor);
    }
}


[TestFixture]
public class When_calculating_the_remainder_of_a_finite_number_with_Infinity : Spec{
    
    public static IEnumerable<TestCaseData> TestCases {
        get {
            // positive infinity
            yield return new TestCaseData(Fraction.Zero, Fraction.PositiveInfinity).Returns(Fraction.Zero);
            yield return new TestCaseData(new Fraction(4), Fraction.PositiveInfinity).Returns(new Fraction(4));
            yield return new TestCaseData(new Fraction(-4), Fraction.PositiveInfinity).Returns(new Fraction(-4));
            yield return new TestCaseData(Fraction.Two, new Fraction(10, BigInteger.Zero, false)).Returns(Fraction.Two);
            // negative infinity
            yield return new TestCaseData(Fraction.Zero, Fraction.NegativeInfinity).Returns(Fraction.Zero);
            yield return new TestCaseData(new Fraction(4), Fraction.NegativeInfinity).Returns(new Fraction(4));
            yield return new TestCaseData(new Fraction(-4), Fraction.NegativeInfinity).Returns(new Fraction(-4));
            yield return new TestCaseData(Fraction.Two, new Fraction(-10, BigInteger.Zero, false)).Returns(Fraction.Two);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public Fraction The_result_should_be_the_same_number(Fraction fraction, Fraction divisor) {
        return fraction.Remainder(divisor);
    }
}
