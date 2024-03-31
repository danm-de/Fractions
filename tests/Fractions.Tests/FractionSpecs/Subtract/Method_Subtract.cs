using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Subtract;

[TestFixture]
// German: Wenn 2 Fünftel mit 1 Fünftel subtrahiert wird
public class When_subtracting_2_fifths_by_1_fifth : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(2, 5);
        _b = new Fraction(1, 5);
    }

    public override void Act() {
        _result = _a.Subtract(_b);
    }

    [Test]
    // German: Soll der Zähler im Ergebnis 1 sein
    public void The_numerator_in_the_result_should_be_1() {
        _result.Numerator.Should().Be(1);
    }

    [Test]
    // German: Soll der Nenner im Ergebnis 5 sein
    public void The_denominator_in_the_result_should_be_5() {
        _result.Denominator.Should().Be(5);
    }
}

[TestFixture]
// German: Wenn 1 Fünftel mit 2 Fünftel subtrahiert wird
public class When_subtracting_1_fifth_by_2_fifths : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(1, 5);
        _b = new Fraction(2, 5);
    }

    public override void Act() {
        _result = _a.Subtract(_b);
    }

    [Test]
    // German: Soll der Zähler im Ergebnis minus 1 sein
    public void The_numerator_in_the_result_should_be_minus_1() {
        _result.Numerator.Should().Be(-1);
    }

    [Test]
    // German: Soll der Nenner im Ergebnis 5 sein
    public void The_denominator_in_the_result_should_be_5() {
        _result.Denominator.Should().Be(5);
    }
}

[TestFixture]
// German: Wenn 1 Fünftel mit 1 Fünftel subtrahiert wird
public class When_subtracting_1_fifth_by_1_fifth : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(1, 5);
        _b = new Fraction(1, 5);
    }

    public override void Act() {
        _result = _a.Subtract(_b);
    }

    [Test]
    // German: Soll der Zähler im Ergebnis 0 sein
    public void The_numerator_in_the_result_should_be_0() {
        _result.Numerator.Should().Be(0);
    }

    [Test]
    // German: Soll der Nenner im Ergebnis 0 sein
    public void The_denominator_in_the_result_should_be_0() {
        _result.Denominator.Should().Be(0);
    }

    [Test]
    // German: Soll der Wert des Bruches als Null erkannt werden
    public void The_value_of_the_fraction_should_be_recognized_as_zero() {
        _result.IsZero.Should().BeTrue();
    }
}
