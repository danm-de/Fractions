using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Negate;

[TestFixture]
// German: Wenn ein Bruch mit 0 als Zähler und 0 als Nenner negiert wird
public class When_negating_a_fraction_with_0_as_numerator_and_0_as_denominator : Spec {
    private Fraction _result;

    public override void Act() {
        _result = new Fraction(0, 0, false).Negate();
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
    public void The_fraction_should_be_NaN() {
        _result.IsNaN
            .Should().BeTrue();
    }
}

[TestFixture]
// German: Wenn ein Bruch mit 0 als Zähler und 1 als Nenner negiert wird
public class When_negating_a_fraction_with_0_as_numerator_and_1_as_denominator : Spec {
    private Fraction _result;

    public override void Act() {
        _result = new Fraction(0, 1, false).Negate();
    }

    [Test]
    // German: Der resultierende Bruch sollte 0 als Zähler haben
    public void The_resulting_fraction_should_have_0_as_numerator() {
        _result.Numerator.Should().Be(0);
    }

    [Test]
    // German: Der resultierende Bruch sollte 1 als Nenner haben
    public void The_resulting_fraction_should_have_1_as_denominator() {
        _result.Denominator.Should().Be(1);
    }

    [Test]
    // German: Der Bruch sollte 0 sein
    public void The_fraction_should_be_0() {
        _result.Should().Be(Fraction.Zero);
    }
}

[TestFixture]
// German: Wenn ein Bruch mit 0 als Zähler und -1 als Nenner negiert wird
public class When_negating_a_fraction_with_0_as_numerator_and_minus_1_as_denominator : Spec {
    private Fraction _result;

    public override void Act() {
        _result = new Fraction(0, -1, false).Negate();
    }

    [Test]
    // German: Der resultierende Bruch sollte 0 als Zähler haben
    public void The_resulting_fraction_should_have_0_as_numerator() {
        _result.Numerator.Should().Be(0);
    }

    [Test]
    // German: Der resultierende Bruch sollte 1 als Nenner haben
    public void The_resulting_fraction_should_have_minus_1_as_denominator() {
        _result.Denominator.Should().Be(-1);
    }

    [Test]
    // German: Der Bruch sollte 0 sein
    public void The_fraction_should_be_equivalent_to_zero() {
        _result.IsZero.Should().BeTrue();
        _result.Should().NotBe(Fraction.Zero);
        _result.State.Should().Be(FractionState.Unknown);
        _result.IsEquivalentTo(Fraction.Zero).Should().BeTrue();
    }
}

[TestFixture]
// German: Wenn ein Bruch mit 0 als Zähler und 4 als Nenner negiert wird
public class When_negating_a_fraction_with_0_as_numerator_and_4_as_denominator : Spec {
    private Fraction _result;

    public override void Act() {
        _result = new Fraction(0, 4, false).Negate();
    }

    [Test]
    // German: Der resultierende Bruch sollte 0 als Zähler haben
    public void The_resulting_fraction_should_have_0_as_numerator() {
        _result.Numerator.Should().Be(0);
    }

    [Test]
    // German: Der resultierende Bruch sollte 4 als Nenner haben
    public void The_resulting_fraction_should_have_4_as_denominator() {
        _result.Denominator
            .Should().Be(4);
    }

    [Test]
    // German: Der Bruch sollte 0 sein
    public void The_fraction_should_be_equivalent_to_zero() {
        _result.IsZero.Should().BeTrue();
        _result.Should().NotBe(Fraction.Zero);
        _result.State.Should().Be(FractionState.Unknown);
        _result.IsEquivalentTo(Fraction.Zero).Should().BeTrue();
    }
}

[TestFixture]
// German: Wenn ein Bruch mit 0 als Zähler und -4 als Nenner negiert wird
public class When_negating_a_fraction_with_0_as_numerator_and_minus_4_as_denominator : Spec {
    private Fraction _result;

    public override void Act() {
        _result = new Fraction(0, -4, false).Negate();
    }

    [Test]
    // German: Der resultierende Bruch sollte 0 als Zähler haben
    public void The_resulting_fraction_should_have_0_as_numerator() {
        _result.Numerator
            .Should().Be(0);
    }

    [Test]
    // German: Der resultierende Bruch sollte 4 als Nenner haben
    public void The_resulting_fraction_should_have_minus_4_as_denominator() {
        _result.Denominator.Should().Be(-4);
    }

    [Test]
    // German: Der Bruch sollte 0 sein
    public void The_fraction_should_be_0() {
        _result.IsZero.Should().BeTrue();
        _result.Should().NotBe(Fraction.Zero);
        _result.State.Should().Be(FractionState.Unknown);
        _result.IsEquivalentTo(Fraction.Zero).Should().BeTrue();
    }
}

[TestFixture]
// German: Wenn ein Bruch mit 1 als Zähler und 0 als Nenner negiert wird
public class When_negating_a_fraction_with_1_as_numerator_and_0_as_denominator : Spec {
    private Fraction _result;

    public override void Act() {
        _result = new Fraction(1, 0, false).Negate();
    }

    [Test]
    // German: Der resultierende Bruch sollte -1 als Zähler haben
    public void The_resulting_fraction_should_have_minus_1_as_numerator() {
        _result.Numerator.Should().Be(-1);
    }

    [Test]
    // German: Der resultierende Bruch sollte 0 als Nenner haben
    public void The_resulting_fraction_should_have_0_as_denominator() {
        _result.Denominator.Should().Be(0);
    }

    [Test]
    public void The_fraction_should_be_NegativeInfinity() {
        _result.Should().Be(Fraction.NegativeInfinity);
    }
}

[TestFixture]
// German: Wenn ein Bruch mit -1 als Zähler und -0 als Nenner negiert wird
public class When_negating_a_fraction_with_minus_1_as_numerator_and_0_as_denominator : Spec {
    private Fraction _result;

    public override void Act() {
        _result = new Fraction(-1, 0, false).Negate();
    }

    [Test]
    // German: Der resultierende Bruch sollte 1 als Zähler haben
    public void The_resulting_fraction_should_have_1_as_numerator() {
        _result.Numerator.Should().Be(1);
    }

    [Test]
    // German: Der resultierende Bruch sollte 0 als Nenner haben
    public void The_resulting_fraction_should_have_0_as_denominator() {
        _result.Denominator.Should().Be(0);
    }

    [Test]
    // German: Der Bruch sollte 0 sein
    public void The_fraction_should_be_PositiveInfinity() {
        _result.Should().Be(Fraction.PositiveInfinity);
    }
}

[TestFixture]
// German: Wenn ein Bruch mit 4 als Zähler und 0 als Nenner negiert wird
public class When_negating_a_fraction_with_4_as_numerator_and_0_as_denominator : Spec {
    private Fraction _result;

    public override void Act() {
        _result = new Fraction(4, 0, false).Negate();
    }

    [Test]
    // German: Der resultierende Bruch sollte -4 als Zähler haben
    public void The_resulting_fraction_should_have_minus_4_as_numerator() {
        _result.Numerator.Should().Be(-4);
    }

    [Test]
    // German: Der resultierende Bruch sollte 0 als Nenner haben
    public void The_resulting_fraction_should_have_0_as_denominator() {
        _result.Denominator.IsZero.Should().BeTrue();
    }

    [Test]
    public void The_fraction_should_be_0() {
        _result.IsNegativeInfinity.Should().BeTrue();
        _result.Should().NotBe(Fraction.NegativeInfinity);
        _result.State.Should().Be(FractionState.Unknown);
        _result.IsEquivalentTo(Fraction.NegativeInfinity).Should().BeTrue();
    }
}

[TestFixture]
// German: Wenn ein Bruch mit -4 als Zähler und 0 als Nenner negiert wird
public class When_negating_a_fraction_with_minus_4_as_numerator_and_0_as_denominator : Spec {
    private Fraction _result;

    public override void Act() {
        _result = new Fraction(-4, 0, false).Negate();
    }

    [Test]
    // German: Der resultierende Bruch sollte 4 als Zähler haben
    public void The_resulting_fraction_should_have_4_as_numerator() {
        _result.Numerator.Should().Be(4);
    }

    [Test]
    // German: Der resultierende Bruch sollte 0 als Nenner haben
    public void The_resulting_fraction_should_have_minus_4_as_denominator() {
        _result.Denominator.IsZero.Should().BeTrue();
    }

    [Test]
    public void The_fraction_should_be_0() {
        _result.IsPositiveInfinity.Should().BeTrue();
        _result.Should().NotBe(Fraction.PositiveInfinity);
        _result.State.Should().Be(FractionState.Unknown);
        _result.IsEquivalentTo(Fraction.PositiveInfinity).Should().BeTrue();
    }
}

[TestFixture]
// German: Wenn ein Bruch mit minus 1 als Zähler und 1 als Nenner negiert wird
public class When_negating_a_fraction_with_minus_1_as_numerator_and_1_as_denominator : Spec {
    private Fraction _result;

    public override void Act() {
        _result = new Fraction(-1, 1, false).Negate();
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
        _result = new Fraction(1, 1, false).Negate();
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
        new Fraction(0, 4, false),
        Fraction.PositiveInfinity, Fraction.NegativeInfinity, Fraction.NaN, 
    ];

    public static IEnumerable<TestCaseData> TestCases => FractionsToTest.Select(x => new TestCaseData(x).Returns(x.Negate()));

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public Fraction Is_the_same_as_calling_the_negate_method(Fraction fraction) => -fraction;
}
