using System;
using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.FromDoubleRounded;

[TestFixture]
// German: Wenn ein Bruch anhand einer NaN double Zahl erzeugt wird
public class When_a_fraction_is_created_based_on_a_NaN_double : Spec {
    private Exception _exception;

    public override void SetUp() {
        _exception = Catch.Exception(() => Fraction.FromDoubleRounded(double.NaN));
    }

    [Test]
    // German: Soll dies eine InvalidNumberException auslösen
    public void This_should_trigger_an_InvalidNumberException() {
        _exception.Should().BeOfType<InvalidNumberException>();
    }
}

[TestFixture]
// German: Wenn ein Bruch anhand einer positiv unendlichen double Zahl erzeugt wird
public class When_a_fraction_is_created_based_on_a_positive_infinite_double : Spec {
    private Exception _exception;

    public override void SetUp() {
        _exception = Catch.Exception(() => Fraction.FromDoubleRounded(double.PositiveInfinity));
    }

    [Test]
    // German: Soll dies eine InvalidNumberException auslösen
    public void This_should_trigger_an_InvalidNumberException() {
        _exception.Should().BeOfType<InvalidNumberException>();
    }
}

[TestFixture]
// German: Wenn ein Bruch anhand einer negativ unendlichen double Zahl erzeugt wird
public class When_a_fraction_is_created_based_on_a_negative_infinite_double : Spec {
    private Exception _exception;

    public override void SetUp() {
        _exception = Catch.Exception(() => Fraction.FromDoubleRounded(double.NegativeInfinity));
    }

    [Test]
    // German: Soll dies eine InvalidNumberException auslösen
    public void This_should_trigger_an_InvalidNumberException() {
        _exception.Should().BeOfType<InvalidNumberException>();
    }
}

[TestFixture]
// German: Wenn ein Bruch mit einer 0 double Zahl erzeugt wird
public class When_a_fraction_is_created_with_a_0_double : Spec {
    private Fraction _fraction;

    public override void SetUp() {
        _fraction = Fraction.FromDoubleRounded(0);
    }

    [Test]
    // German: Soll der Wert danach 0 sein
    public void The_value_should_then_be_0() {
        _fraction.Should().Be(Fraction.Zero);
    }
}

[TestFixture]
// German: Wenn ein Bruch mit einer minus 1 double Zahl erzeugt wird
public class When_a_fraction_is_created_with_a_minus_1_double : Spec {
    private Fraction _fraction;

    public override void SetUp() {
        _fraction = Fraction.FromDoubleRounded(-1);
    }

    [Test]
    // German: Soll der Wert danach minus 1 sein
    public void The_value_should_then_be_minus_1() {
        _fraction.Should().Be(new Fraction(-1, 1));
    }
}

[TestFixture]
// German: Wenn ein Bruch mit einer 1 double Zahl erzeugt wird
public class When_a_fraction_is_created_with_a_1_double : Spec {
    private Fraction _fraction;

    public override void SetUp() {
        _fraction = Fraction.FromDoubleRounded(1);
    }

    [Test]
    // German: Soll der Wert danach 1 sein
    public void The_value_should_then_be_1() {
        _fraction.Should().Be(new Fraction(1, 1));
    }
}

[TestFixture]
// German: Wenn ein Bruch mit einer 1 Komma 345 double Zahl erzeugt wird
public class When_a_fraction_is_created_with_a_1_point_345_double : Spec {
    private Fraction _fraction;

    public override void SetUp() {
        _fraction = Fraction.FromDoubleRounded(1.345);
    }

    [Test]
    // German: Soll der Bruch danach einen Zähler von 269 haben
    public void The_fraction_should_then_have_a_numerator_of_269() {
        _fraction.Numerator.Should().Be(new BigInteger(269));
    }

    [Test]
    // German: Soll der Bruch danach einen Nenner von 200 haben
    public void The_fraction_should_then_have_a_denominator_of_200() {
        _fraction.Denominator.Should().Be(new BigInteger(200));
    }
}

[TestFixture]
// German: Wenn ein Bruch mit double MaxValue erzeugt wird
public class When_a_fraction_is_created_with_double_MaxValue : Spec {
    private Fraction _fraction;

    public override void SetUp() {
        _fraction = Fraction.FromDoubleRounded(double.MaxValue);
    }

    [Test]
    // German: Soll der Bruch danach einen Zähler von double MaxValue haben
    public void The_fraction_should_then_have_a_numerator_of_double_MaxValue() {
        _fraction.Numerator.Should().Be(new BigInteger(double.MaxValue));
    }

    [Test]
    // German: Soll der Bruch danach einen Nenner von 1 haben
    public void The_fraction_should_then_have_a_denominator_of_1() {
        _fraction.Denominator.Should().Be(new BigInteger(1));
    }
}

[TestFixture]
// German: Wenn ein Bruch mit double MinValue erzeugt wird
public class When_a_fraction_is_created_with_double_MinValue : Spec {
    private Fraction _fraction;

    public override void SetUp() {
        _fraction = Fraction.FromDoubleRounded(double.MinValue);
    }

    [Test]
    // German: Soll der Bruch danach einen Zähler von minus double MaxValue haben
    public void The_fraction_should_then_have_a_numerator_of_minus_double_MaxValue() {
        _fraction.Numerator.Should().Be(BigInteger.Negate(new BigInteger(double.MaxValue)));
    }

    [Test]
    // German: Soll der Bruch danach einen Nenner von 1 haben
    public void The_fraction_should_then_have_a_denominator_of_1() {
        _fraction.Denominator.Should().Be(new BigInteger(1));
    }
}

[TestFixture]
// German: Wenn ein Bruch mit PI erzeugt wird
public class When_a_fraction_is_created_with_PI : Spec {
    private Fraction _fraction;

    public override void SetUp() {
        _fraction = Fraction.FromDoubleRounded(Math.PI);
    }

    [Test]
    // German: Soll der Bruch danach einen Zähler von 245850922 haben
    public void The_fraction_should_then_have_a_numerator_of_245850922() {
        _fraction.Numerator.Should().Be(245850922);
    }

    [Test]
    // German: Soll der Bruch danach einen Nenner von 78256779 haben
    public void The_fraction_should_then_have_a_denominator_of_78256779() {
        _fraction.Denominator.Should().Be(78256779);
    }
}

[TestFixture]
// German: Wenn ein Bruch mit 1 Drittel erzeugt wird
public class When_a_fraction_is_created_with_1_third : Spec {
    private Fraction _fraction;

    public override void SetUp() {
        _fraction = Fraction.FromDoubleRounded(1.0 / 3.0);
    }

    [Test]
    // German: Soll der Bruch danach einen Zähler von 1 haben
    public void The_fraction_should_then_have_a_numerator_of_1() {
        _fraction.Numerator.Should().Be(1);
    }

    [Test]
    // German: Soll der Bruch danach einen Nenner von 3 haben
    public void The_fraction_should_then_have_a_denominator_of_3() {
        _fraction.Denominator.Should().Be(3);
    }
}
