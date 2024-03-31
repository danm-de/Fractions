using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Constructores;

[TestFixture]
public class If_the_user_creates_a_fraction_with_constructor_parameters : Spec {
    private Fraction _fraction;

    public override void Act() {
        _fraction = new Fraction();
    }

    [Test]
    public void Resulting_fraction_should_have_0_as_numerator() {
        _fraction.Numerator
            .Should()
            .Be(0);
    }

    [Test]
    public void Resulting_fraction_should_have_0_as_denominator() {
        _fraction.Denominator
            .Should()
            .Be(0);
    }

    [Test]
    public void Resulting_fraction_should_be_zero() {
        _fraction.IsZero
            .Should()
            .BeTrue();
    }
}

[TestFixture]
public class If_the_user_creates_a_fraction_using_0L_as_numerator_and_0L_as_denominator : Spec {
    private Fraction _fraction;

    public override void Act() {
        _fraction = new Fraction(0L, 0L, false);
    }

    [Test]
    public void Resulting_fraction_should_be_zero() {
        _fraction.IsZero
            .Should()
            .BeTrue();
    }
}

[TestFixture]
public class If_the_user_creates_a_non_normalized_fraction_using_0L_as_numerator_and_1L_as_denominator : Spec {
    private Fraction _fraction;

    public override void Act() {
        _fraction = new Fraction(0L, 1L, false);
    }

    [Test]
    public void Resulting_fraction_should_have_0_as_numerator() {
        _fraction.Numerator
            .Should()
            .Be(0);
    }

    [Test]
    public void Resulting_fraction_should_have_1_as_denominator() {
        _fraction.Denominator
            .Should()
            .Be(1);
    }
}

[TestFixture]
public class If_the_user_creates_a_normalized_fraction_using_0L_as_numerator_and_1L_as_denominator : Spec {
    private Fraction _fraction;

    public override void Act() {
        _fraction = new Fraction(0L, 0L, true);
    }

    [Test]
    public void Resulting_fraction_should_be_zero() {
        _fraction.IsZero
            .Should()
            .BeTrue();
    }
}

[TestFixture]
public class If_the_user_creates_a_normalized_fraction_using_4L_as_numerator_and_4L_as_denominator : Spec {
    private Fraction _fraction;

    public override void Act() {
        _fraction = new Fraction(4L, 4L, true);
    }

    [Test]
    public void Resulting_fraction_should_have_1_as_numerator() {
        _fraction.Numerator
            .Should()
            .Be(1);
    }

    [Test]
    public void Resulting_fraction_should_have_1_as_denominator() {
        _fraction.Denominator
            .Should()
            .Be(1);
    }
}

[TestFixture]
// German: Wenn ein Bruch mit 4L als Zähler und 12L als Nenner normalisiert erzeugt wird dann
public class When_fraction_is_created_normalized_with_4L_as_numerator_and_12L_as_denominator : Spec {
    private Fraction _fraction;

    public override void Act() {
        _fraction = new Fraction(4L, 12L, true);
    }

    [Test]
    // German: Soll der resultierende Bruch im Zähler 1L haben
    public void Resulting_fraction_should_have_1L_in_numerator() {
        _fraction.Numerator
            .Should()
            .Be(1L);
    }

    [Test]
    // German: Soll der resultierende Bruch im Nenner 3L haben
    public void Resulting_fraction_should_have_3L_in_denominator() {
        _fraction.Denominator
            .Should()
            .Be(3L);
    }
}

[TestFixture]
// German: Wenn ein Bruch mit 12L als Zähler und 4L als Nenner normalisiert erzeugt wird dann
public class When_fraction_is_created_normalized_with_12L_as_numerator_and_4L_as_denominator : Spec {
    private Fraction _fraction;

    public override void Act() {
        _fraction = new Fraction(12L, 4L, true);
    }

    [Test]
    // German: Soll der resultierende Bruch im Zähler 3L haben
    public void Resulting_fraction_should_have_3L_in_numerator() {
        _fraction.Numerator
            .Should()
            .Be(3L);
    }

    [Test]
    // German: Soll der resultierende Bruch im Nenner 1L haben
    public void Resulting_fraction_should_have_1L_in_denominator() {
        _fraction.Denominator
            .Should()
            .Be(1L);
    }
}

[TestFixture]
// German: Wenn ein Bruch mit 0L als Zähler und 4L als Nenner normalisiert erzeugt wird dann
public class When_fraction_is_created_normalized_with_0L_as_numerator_and_4L_as_denominator : Spec {
    private Fraction _fraction;

    public override void Act() {
        _fraction = new Fraction(0L, 4L, true);
    }

    [Test]
    // German: Soll der resultierende Bruch im Zähler 0L haben
    public void Resulting_fraction_should_have_0L_in_numerator() {
        _fraction.Numerator
            .Should()
            .Be(0L);
    }

    [Test]
    // German: Soll der resultierende Bruch im Nenner 0L haben
    public void Resulting_fraction_should_have_0L_in_denominator() {
        _fraction.Denominator
            .Should()
            .Be(0L);
    }
}

[TestFixture]
// German: Wenn ein Bruch mit int 0 als Zähler erzeugt wird
public class When_fraction_is_created_with_int_0_as_numerator : Spec {
    private Fraction _fraction;

    public override void Act() {
        _fraction = new Fraction(0);
    }

    [Test]
    // German: Soll der resultierende Bruch 0 als Nenner haben
    public void Resulting_fraction_should_have_0_as_denominator() {
        _fraction.Denominator.Should().Be(0);
    }

    [Test]
    // German: Soll der resultierende Bruch 0 als Zähler haben
    public void Resulting_fraction_should_have_0_as_numerator() {
        _fraction.Numerator.Should().Be(0);
    }
}

[TestFixture]
// German: Wenn ein Bruch mit uint 0 als Zähler erzeugt wird
public class When_fraction_is_created_with_uint_0_as_numerator : Spec {
    private Fraction _fraction;

    public override void Act() {
        _fraction = new Fraction((uint)0);
    }

    [Test]
    // German: Soll der resultierende Bruch 0 als Nenner haben
    public void Resulting_fraction_should_have_0_as_denominator() {
        _fraction.Denominator.Should().Be(0);
    }

    [Test]
    // German: Soll der resultierende Bruch 0 als Zähler haben
    public void Resulting_fraction_should_have_0_as_numerator() {
        _fraction.Numerator.Should().Be(0);
    }
}

[TestFixture]
// German: Wenn ein Bruch mit long 0 als Zähler erzeugt wird
public class When_fraction_is_created_with_long_0_as_numerator : Spec {
    private Fraction _fraction;

    public override void Act() {
        _fraction = new Fraction((long)0);
    }

    [Test]
    // German: Soll der resultierende Bruch 0 als Nenner haben
    public void Resulting_fraction_should_have_0_as_denominator() {
        _fraction.Denominator.Should().Be(0);
    }

    [Test]
    // German: Soll der resultierende Bruch 0 als Zähler haben
    public void Resulting_fraction_should_have_0_as_numerator() {
        _fraction.Numerator.Should().Be(0);
    }
}

[TestFixture]
// German: Wenn ein Bruch mit ulong 0 als Zähler erzeugt wird
public class When_fraction_is_created_with_ulong_0_as_numerator : Spec {
    private Fraction _fraction;

    public override void Act() {
        _fraction = new Fraction((ulong)0);
    }

    [Test]
    // German: Soll der resultierende Bruch 0 als Nenner haben
    public void Resulting_fraction_should_have_0_as_denominator() {
        _fraction.Denominator.Should().Be(0);
    }

    [Test]
    // German: Soll der resultierende Bruch 0 als Zähler haben
    public void Resulting_fraction_should_have_0_as_numerator() {
        _fraction.Numerator.Should().Be(0);
    }
}

[TestFixture]
// German: Wenn ein Bruch mit double 0 als Zähler erzeugt wird
public class When_fraction_is_created_with_double_0_as_numerator : Spec {
    private Fraction _fraction;

    public override void Act() {
        _fraction = new Fraction((double)0);
    }

    [Test]
    // German: Soll der resultierende Bruch 0 als Nenner haben
    public void Resulting_fraction_should_have_0_as_denominator() {
        _fraction.Denominator.Should().Be(0);
    }

    [Test]
    // German: Soll der resultierende Bruch 0 als Zähler haben
    public void Resulting_fraction_should_have_0_as_numerator() {
        _fraction.Numerator.Should().Be(0);
    }
}

[TestFixture]
// German: Wenn ein Bruch mit decimal 0 als Zähler erzeugt wird
public class When_fraction_is_created_with_decimal_0_as_numerator : Spec {
    private Fraction _fraction;

    public override void Act() {
        _fraction = new Fraction((decimal)0);
    }

    [Test]
    // German: Soll der resultierende Bruch 0 als Nenner haben
    public void Resulting_fraction_should_have_0_as_denominator() {
        _fraction.Denominator.Should().Be(0);
    }

    [Test]
    // German: Soll der resultierende Bruch 0 als Zähler haben
    public void Resulting_fraction_should_have_0_as_numerator() {
        _fraction.Numerator.Should().Be(0);
    }
}

[TestFixture]
// German: Wenn ein Bruch mit BigInteger 0 als Zähler erzeugt wird
public class When_Fraction_Is_Created_With_BigInteger0_As_Numerator : Spec {
    private Fraction _fraction;

    public override void Act() {
        _fraction = new Fraction((BigInteger)0);
    }

    [Test]
    // German: Soll der resultierende Bruch 0 als Nenner haben
    public void Resulting_Fraction_Should_Have_0_As_Denominator() {
        _fraction.Denominator.Should().Be(0);
    }

    [Test]
    // German: Soll der resultierende Bruch 0 als Zähler haben
    public void Resulting_Fraction_Should_Have_0_As_Numerator() {
        _fraction.Numerator.Should().Be(0);
    }
}
