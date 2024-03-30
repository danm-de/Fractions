using System;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Divide;

[TestFixture]
// German: Wenn 0 mit 0 dividiert wird
public class When_dividing_0_by_0 : Spec {
    private Exception _exception;

    public override void Act() {
        _exception = Catch.Exception(() => Fraction.Zero.Divide(Fraction.Zero));
    }

    [Test]
    // German: Dies sollte eine DivideByZeroException auslösen
    public void This_should_trigger_a_DivideByZeroException() {
        _exception.Should().BeOfType<DivideByZeroException>();
    }
}

[TestFixture]
// German: Wenn 1 mit 0 dividiert wird
public class When_dividing_1_by_0 : Spec {
    private Exception _exception;

    public override void Act() {
        _exception = Catch.Exception(() => Fraction.One.Divide(Fraction.Zero));
    }

    [Test]
    // German: Dies sollte eine DivideByZeroException auslösen
    public void This_should_trigger_a_DivideByZeroException() {
        _exception.Should().BeOfType<DivideByZeroException>();
    }
}

[TestFixture]
// German: Wenn minus 1 mit 0 dividiert wird
public class When_dividing_minus_1_by_0 : Spec {
    private Exception _exception;

    public override void Act() {
        _exception = Catch.Exception(() => Fraction.MinusOne.Divide(Fraction.Zero));
    }

    [Test]
    // German: Dies sollte eine DivideByZeroException auslösen
    public void This_should_trigger_a_DivideByZeroException() {
        _exception.Should().BeOfType<DivideByZeroException>();
    }
}

[TestFixture]
// German: Wenn ein Fünftel mit ein Fünftel dividiert wird
public class When_dividing_one_fifth_by_one_fifth : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(1, 5);
        _b = new Fraction(1, 5);
    }

    public override void Act() {
        _result = _a.Divide(_b);
    }

    [Test]
    // German: Das Ergebnis sollte 1 sein
    public void The_result_should_be_1() {
        _result.Should().Be(new Fraction(1, 1));
    }
}

[TestFixture]
// German: Wenn 2 mit 2 Viertel dividiert wird
public class When_dividing_2_by_2_quarters : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(2, 1, false);
        _b = new Fraction(2, 4, false);
    }

    public override void Act() {
        _result = _a.Divide(_b);
    }

    [Test]
    // German: Das Ergebnis sollte 4 sein
    public void The_result_should_be_4() {
        _result.Should().Be(new Fraction(4, 1));
    }
}

[TestFixture]
// German: Wenn minus 2 mit 2 Viertel dividiert wird
public class When_dividing_minus_2_by_2_quarters : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(-2, 1, false);
        _b = new Fraction(2, 4, false);
    }

    public override void Act() {
        _result = _a.Divide(_b);
    }

    [Test]
    // German: Das Ergebnis sollte minus 4 sein
    public void The_result_should_be_minus_4() {
        _result.Should().Be(new Fraction(-4, 1));
    }
}

[TestFixture]
// German: Wenn 0 Achtel durch 4 dividiert werden
public class When_dividing_0_eighths_by_4 : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(0, 8, false);
        _b = new Fraction(4, 1, true);
    }

    public override void Act() {
        _result = _a.Divide(_b);
    }

    [Test]
    // German: Das Ergebnis sollte 0 sein
    public void The_result_should_be_0() {
        _result.Should().Be(Fraction.Zero);
    }
}

[TestFixture]
// German: Wenn 0 durch 4 dividiert werden
public class When_dividing_0_by_4 : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(0, 0, false);
        _b = new Fraction(4, 1, true);
    }

    public override void Act() {
        _result = _a.Divide(_b);
    }

    [Test]
    // German: Das Ergebnis sollte 0 sein
    public void The_result_should_be_0() {
        _result.Should().Be(Fraction.Zero);
    }
}
