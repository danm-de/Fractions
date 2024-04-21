using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Multiply;

[TestFixture]
// German: Wenn 0 mit 0 multipliziert wird
public class When_multiplying_0_by_0 : Spec {
    private Fraction _result;

    public override void Act() {
        _result = Fraction.Zero.Multiply(Fraction.Zero);
    }

    [Test]
    // German: Das Ergebnis sollte wieder 0 sein
    public void The_result_should_be_0_again() {
        _result.Should().Be(Fraction.Zero);
    }
}

[TestFixture]
// German: Wenn 1 mit 0 multipliziert wird
public class When_multiplying_1_by_0 : Spec {
    private Fraction _result1;
    private Fraction _result2;

    public override void Act() {
        _result1 = Fraction.One.Multiply(Fraction.Zero);
        _result2 = Fraction.Zero.Multiply(Fraction.One);
    }

    [Test]
    // German: Das Ergebnis sollte wieder 0 sein
    public void The_result_should_be_0_again() {
        _result1.Should().Be(Fraction.Zero);
    }

    [Test]
    // German: Die Operation sollte kommutativ sein
    public void The_operation_should_be_commutative() {
        _result1.Should().Be(_result2);
    }
}

[TestFixture]
// German: Wenn ein Fünftel mit ein Fünftel multipliziert wird
public class When_multiplying_one_fifth_by_one_fifth : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(1, 5);
        _b = new Fraction(1, 5);
    }

    public override void Act() {
        _result = _a.Multiply(_b);
    }

    [Test]
    // German: Das Ergebnis sollte ein Fünfundzwanzigstel sein
    public void The_result_should_be_one_twenty_fifth() {
        _result.Should().Be(new Fraction(1, 25));
    }
}

[TestFixture]
// German: Wenn 2 mit 2 Viertel multipliziert wird
public class When_multiplying_2_by_2_quarters : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result1;
    private Fraction _result2;

    public override void SetUp() {
        _a = new Fraction(2, 1, false);
        _b = new Fraction(2, 4, false);
    }

    public override void Act() {
        _result1 = _a.Multiply(_b);
        _result2 = _b.Multiply(_a);
    }

    [Test]
    // German: Das Ergebnis sollte 1 sein
    public void The_result_should_be_1() {
        _result1.Should().Be(Fraction.One);
    }

    [Test]
    // German: Die Operation sollte kommutativ sein
    public void The_operation_should_be_commutative() {
        _result1.Should().Be(_result2);
    }
}

[TestFixture]
// German: Wenn minus 2 mit 2 Viertel multipliziert wird
public class When_multiplying_minus_2_by_2_quarters : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result1;
    private Fraction _result2;

    public override void SetUp() {
        _a = new Fraction(-2, 1, false);
        _b = new Fraction(2, 4, false);
    }

    public override void Act() {
        _result1 = _a.Multiply(_b);
        _result2 = _b.Multiply(_a);
    }

    [Test]
    // German: Das Ergebnis sollte minus 1 sein
    public void The_result_should_be_minus_1() {
        _result1.Should().Be(Fraction.MinusOne);
    }

    [Test]
    // German: Die Operation sollte kommutativ sein
    public void The_operation_should_be_commutative() {
        _result1.Should().Be(_result2);
    }
}

[TestFixture]
public class When_multiplying_with_NaN {
    private static IEnumerable<TestCaseData> TestCases {
        get {
            // NaN with NaN
            yield return new TestCaseData(Fraction.NaN, Fraction.NaN).Returns(Fraction.NaN);
            // NaN with any number
            yield return new TestCaseData(Fraction.NaN, Fraction.PositiveInfinity).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(5, 4)).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(-5, -5, false)).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.One).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(4, 5)).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.Zero).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.MinusOne).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(-5, 4)).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(-4, 5)).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(5, -5, false)).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.NegativeInfinity).Returns(Fraction.NaN);
            // Any number with NaN
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(new Fraction(5, 4), Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.One, Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(new Fraction(4, 5), Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.Zero, Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.MinusOne, Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(new Fraction(-5, 4), Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(new Fraction(-4, 5), Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NaN).Returns(Fraction.NaN);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public Fraction The_result_is_always_NaN(Fraction a, Fraction b) {
        return a.Multiply(b);
    }
}

[TestFixture]
public class When_multiplying_with_infinity {
    private static IEnumerable<TestCaseData> TestCases {
        get {
            // positive infinity with positive infinity
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.PositiveInfinity).Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(5, 0, false)).Returns(Fraction.PositiveInfinity);
            // positive infinity with any other number
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(5, 4)).Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.One).Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(4, 5)).Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.Zero).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.MinusOne).Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(-5, 4)).Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(-4, 5)).Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NegativeInfinity).Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(-5, 0, false)).Returns(Fraction.NegativeInfinity);
            // negative infinity with negative infinity
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NegativeInfinity).Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-5, 0, false)).Returns(Fraction.PositiveInfinity);
            // negative infinity with any other number
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(5, 4)).Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.One).Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(4, 5)).Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.Zero).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.MinusOne).Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-5, 4)).Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-4, 5)).Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.PositiveInfinity).Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(5, 0, false)).Returns(Fraction.NegativeInfinity);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public Fraction The_result_is_always_NaN_or_Infinity(Fraction a, Fraction b) {
        return a.Multiply(b);
    }
}
