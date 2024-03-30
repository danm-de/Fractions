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
