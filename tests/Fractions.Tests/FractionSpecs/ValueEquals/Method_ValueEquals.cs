using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.ValueEquals;

[TestFixture]
// German: Wenn zwei Brüche mit identischen Zähler und Nenner verglichen werden
public class When_comparing_two_fractions_with_identical_numerator_and_denominator : Spec {
    private Fraction _fractionA;
    private Fraction _fractionB;

    public override void SetUp() {
        base.SetUp();
        _fractionA = new Fraction(5, 6, true);
        _fractionB = new Fraction(5, 6, true);
    }

    [Test]
    // German: Diese sollten als wertgleich erkannt werden
    public void These_should_be_recognized_as_equivalent() {
        _fractionA.IsEquivalentTo(_fractionB)
            .Should().BeTrue();
    }
}

[TestFixture]
// German: Wenn zwei Brüche mit unterschiedlichen Zähler aber identischen Nenner verglichen werden
public class When_comparing_two_fractions_with_different_numerator_but_identical_denominator : Spec {
    private Fraction _fractionA;
    private Fraction _fractionB;

    public override void SetUp() {
        base.SetUp();
        _fractionA = new Fraction(4, 6, true);
        _fractionB = new Fraction(5, 6, true);
    }

    [Test]
    // German: Diese sollten als nicht wertgleich erkannt werden
    public void These_should_be_recognized_as_not_equivalent() {
        _fractionA.IsEquivalentTo(_fractionB)
            .Should().BeFalse();
    }
}

[TestFixture]
// German: Wenn zwei Brüche mit identischen Zähler aber unterschiedlichen Nenner verglichen werden
public class When_comparing_two_fractions_with_identical_numerator_but_different_denominator : Spec {
    private Fraction _fractionA;
    private Fraction _fractionB;

    public override void SetUp() {
        base.SetUp();
        _fractionA = new Fraction(4, 6, true);
        _fractionB = new Fraction(4, 7, true);
    }

    [Test]
    // German: Diese sollten als nicht wertgleich erkannt werden
    public void These_should_be_recognized_as_not_equivalent() {
        _fractionA.IsEquivalentTo(_fractionB)
            .Should().BeFalse();
    }
}

[TestFixture]
// German: Wenn der Bruch 2/4 mit dem Bruch 1/2 verglichen wird
public class When_comparing_the_fraction_2_over_4_with_the_fraction_1_over_2 : Spec {
    private Fraction _fractionA;
    private Fraction _fractionB;

    public override void SetUp() {
        base.SetUp();
        _fractionA = new Fraction(2, 4, false);
        _fractionB = new Fraction(1, 2, true);
    }

    [Test]
    // German: Die Brüche sollten als nicht strukturell gleich erkannt werden
    public void The_fractions_should_be_recognized_as_not_equal() {
        _fractionA.Equals(_fractionB)
            .Should().BeFalse();
    }

    [Test]
    // German: Die Brüche sollten als wertgleich erkannt werden
    public void The_fractions_should_be_recognized_as_equivalent() {
        _fractionA.IsEquivalentTo(_fractionB)
            .Should().BeTrue();
    }
}
