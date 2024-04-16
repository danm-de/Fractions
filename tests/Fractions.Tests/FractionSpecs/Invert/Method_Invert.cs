using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Invert;

[TestFixture]
// German: Wenn ein Bruch mit 0 als Zähler und 0 als Nenner negiert wird
public class When_negating_a_fraction_with_0_as_numerator_and_0_as_denominator : Spec {
    private Fraction _result;

    public override void Act() {
        _result = new Fraction(0, 0, false).Invert();
    }

    [Test]
    // German: Der resultierende Bruch sollte 0 als Zähler haben
    public void The_resulting_fraction_should_have_0_as_numerator() {
        _result.Numerator
            .Should().Be(0);
    }

    [Test]
    // German: Der resultierende Bruch sollte 0 als Nenner haben
    public void The_resulting_fraction_should_have_0_as_denominator() {
        _result.Denominator
            .Should().Be(0);
    }

    [Test]
    // German: Der Bruch sollte 0 sein
    public void The_fraction_should_be_0() {
        _result.IsZero
            .Should().BeTrue();
    }
}

[TestFixture]
// German: Wenn ein Bruch mit 0 als Zähler und 4 als Nenner negiert wird
public class When_negating_a_fraction_with_0_as_numerator_and_4_as_denominator : Spec {
    private Fraction _result;

    public override void Act() {
        _result = new Fraction(0, 4, false).Invert();
    }

    [Test]
    // German: Der resultierende Bruch sollte 0 als Zähler haben
    public void The_resulting_fraction_should_have_0_as_numerator() {
        _result.Numerator
            .Should().Be(0);
    }

    [Test]
    // German: Der resultierende Bruch sollte 0 als Nenner haben
    public void The_resulting_fraction_should_have_0_as_denominator() {
        _result.Denominator
            .Should().Be(0);
    }

    [Test]
    // German: Der Bruch sollte 0 sein
    public void The_fraction_should_be_0() {
        _result.IsZero
            .Should().BeTrue();
    }
}

[TestFixture]
// German: Wenn ein Bruch mit minus 1 als Zähler und 1 als Nenner negiert wird
public class When_negating_a_fraction_with_minus_1_as_numerator_and_1_as_denominator : Spec {
    private Fraction _result;

    public override void Act() {
        _result = new Fraction(-1, 1, false).Invert();
    }

    [Test]
    // German: Der resultierende Bruch sollte 1 als Zähler haben
    public void The_resulting_fraction_should_have_1_as_numerator() {
        _result.Numerator
            .Should().Be(1);
    }

    [Test]
    // German: Der resultierende Bruch sollte 1 als Nenner haben
    public void The_resulting_fraction_should_have_1_as_denominator() {
        _result.Denominator
            .Should().Be(1);
    }
}

[TestFixture]
// German: Wenn ein Bruch mit 1 als Zähler und 1 als Nenner negiert wird
public class When_negating_a_fraction_with_1_as_numerator_and_1_as_denominator : Spec {
    private Fraction _result;

    public override void Act() {
        _result = new Fraction(1, 1, false).Invert();
    }

    [Test]
    // German: Der resultierende Bruch sollte minus 1 als Zähler haben
    public void The_resulting_fraction_should_have_minus_1_as_numerator() {
        _result.Numerator
            .Should().Be(-1);
    }

    [Test]
    // German: Der resultierende Bruch sollte 1 als Nenner haben
    public void The_resulting_fraction_should_have_1_as_denominator() {
        _result.Denominator
            .Should().Be(1);
    }
}

[TestFixture]
public class Negating_a_fraction_using_the_minus_operator : Spec {

    private static readonly Fraction[] FractionsToTest = [
        Fraction.MinusOne, Fraction.Zero, Fraction.One,
        -0.5m, 1.5m,
        new Fraction(0, 4, false)
    ];

    public static IEnumerable<TestCaseData> TestCases => FractionsToTest.Select(x => new TestCaseData(x).Returns(x.Invert()));

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public Fraction Is_the_same_as_calling_the_invert_method(Fraction fraction) => -fraction;
}
