using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.ConvertTo;

[TestFixture]
// German: Wenn ein Bruch mit NULL verglichen wird
public class When_comparing_a_fraction_with_NULL : Spec {
    [Test]
    // German: Das Ergebnis sollte 1 sein
    public void The_result_should_be_1() {
        Fraction.One.CompareTo(null)
            .Should().Be(1);
    }
}

[TestFixture]
// German: Wenn 1 mit 2 verglichen wird
public class When_comparing_1_with_2 : Spec {
    [Test]
    // German: Das Ergebnis sollte kleiner 0 sein
    public void The_result_should_be_less_than_0() {
        Fraction.One.CompareTo(new Fraction(2))
            .Should().BeLessThan(0);
    }
}

[TestFixture]
// German: Wenn 1 mit minus 2 verglichen wird
public class When_comparing_1_with_minus_2 : Spec {
    [Test]
    // German: Das Ergebnis sollte größer 0 sein
    public void The_result_should_be_greater_than_0() {
        Fraction.One.CompareTo(new Fraction(-2))
            .Should().BeGreaterThan(0);
    }
}

[TestFixture]
// German: Wenn 1 mit 1 verglichen wird
public class When_comparing_1_with_1 : Spec {
    [Test]
    // German: Das Ergebnis sollte gleich 0 sein
    public void The_result_should_be_0() {
        Fraction.One.CompareTo(new Fraction(1, 1, false))
            .Should().Be(0);
    }
}

[TestFixture]
// German: Wenn 1 Viertel mit 2 Achtel verglichen wird
public class When_comparing_1_quarter_with_2_eighths : Spec {
    private Fraction _a;
    private Fraction _b;

    public override void SetUp() {
        _a = new Fraction(1, 4, false);
        _b = new Fraction(2, 8, false);
    }

    [Test]
    // German: Das Ergebnis sollte gleich 0 sein
    public void The_result_should_be_0() {
        _a.CompareTo(_b)
            .Should().Be(0);
    }

    [Test]
    // German: Diese sollten nicht als vollständig identisch erachtet werden
    public void These_should_not_be_considered_identical() {
        _a.Equals(_b)
            .Should().BeFalse();
    }

    [Test]
    // German: Diese sollten als Wertgleich bzw. äquivalent erachtet werden
    public void These_should_be_considered_equivalent() {
        _a.IsEquivalentTo(_b)
            .Should().BeTrue();
    }
}
