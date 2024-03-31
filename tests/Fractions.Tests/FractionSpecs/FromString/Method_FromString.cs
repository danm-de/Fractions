using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.FromString;

[TestFixture]
// German: Wenn versucht wird, aus einem Leerstring einen Bruch zu erzeugen
public class When_trying_to_create_a_fraction_from_an_empty_string : Spec {
    [Test]
    // German: Dies sollte nicht funktionieren
    public void This_should_not_work([Values("", " ")] string invalidString) {
        // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
        Invoking(() => Fraction.FromString(invalidString))
            .Should()
            .Throw<FormatException>();
    }
}

[TestFixture]
// German: Wenn aus 999999999999999999999 ein Bruch erzeugt wird
public class When_creating_a_fraction_from_999999999999999999999 : Spec {
    private Fraction _result;

    public override void Act() {
        _result = Fraction.FromString("999999999999999999999");
    }

    [Test]
    // German: Der Zähler des Bruches sollte 999999999999999999999 sein
    public void The_numerator_of_the_fraction_should_be_999999999999999999999() {
        _result.Numerator.ToString()
            .Should().Be("999999999999999999999");
    }

    [Test]
    // German: Der Nenner des Bruches sollte 1 sein
    public void The_denominator_of_the_fraction_should_be_1() {
        _result.Denominator
            .Should().Be(1);
    }
}

[TestFixture]
[Culture("de-DE")]
// German: Wenn aus minus 999999999999999999999 mit deutscher Kultur ein Bruch erzeugt wird
public class When_creating_a_fraction_from_minus_999999999999999999999_with_German_culture : Spec {
    private Fraction _result;

    public override void Act() {
        _result = Fraction.FromString("-999999999999999999999");
    }

    [Test]
    // German: Der Zähler des Bruches sollte minus 999999999999999999999 sein
    public void The_numerator_of_the_fraction_should_be_minus_999999999999999999999() {
        _result.Numerator.ToString()
            .Should().Be("-999999999999999999999");
    }

    [Test]
    // German: Der Nenner des Bruches sollte 1 sein
    public void The_denominator_of_the_fraction_should_be_1() {
        _result.Denominator
            .Should().Be(1);
    }
}

[TestFixture]
// German: Wenn aus 3,5 mit deutscher Kultur ein Bruch erzeugt wird
public class When_creating_a_fraction_from_3_5_with_German_culture : Spec {
    [Test]
    // German: Das Ergebnis sollte 7 durch 2 sein
    public void The_result_should_be_7_over_2(
        [Values("3,5", " 3,5", "3,5 ", "+3,5", " +3,5", "+3,5 ")]
        string value) {
        Fraction.FromString(value, new CultureInfo("de-DE"))
            .Should().Be(new Fraction(7, 2));
    }
}

[TestFixture]
[Culture("de-DE")]
// German: Wenn aus 3,5 ohne explizite Angabe der Kultur ein Bruch erzeugt wird
public class When_creating_a_fraction_from_3_5_without_explicit_culture_specification : Spec {
    [Test]
    // German: Das Ergebnis sollte 7 durch 2 sein
    public void The_result_should_be_7_over_2(
        [Values("3,5", " 3,5", "3,5 ", "+3,5", " +3,5", "+3,5 ")]
        string value) {
        Fraction.FromString(value)
            .Should().Be(new Fraction(7, 2));
    }
}

[TestFixture]
// German: Wenn aus minus 3,5 mit deutscher Kultur ein Bruch erzeugt wird
public class When_creating_a_fraction_from_minus_3_5_with_German_culture : Spec {
    [Test]
    // German: Das Ergebnis sollte minus 7 durch 2 sein
    public void The_result_should_be_minus_7_over_2([Values("-3,5", " -3,5", "-3,5 ")] string value) {
        Fraction.FromString(value, new CultureInfo("de-DE"))
            .Should().Be(new Fraction(-7, 2));
    }
}

[TestFixture]
// German: Wenn aus 3.5 mit US-amerikanischer Kultur ein Bruch erzeugt wird
public class When_creating_a_fraction_from_3_5_with_American_culture : Spec {
    private Fraction _result;

    public override void Act() {
        _result = Fraction.FromString("3.5", new CultureInfo("en-US"));
    }

    [Test]
    // German: Das Ergebnis sollte 7 durch 2 sein
    public void The_result_should_be_7_over_2() {
        _result.Should().Be(new Fraction(7, 2));
    }
}

[TestFixture]
// German: Wenn aus der Zeichenkette 1/5 ein Bruch erzeugt wird
public class When_creating_a_fraction_from_the_string_1_over_5 : Spec {
    [Test]
    // German: Das Ergebnis sollte 1 durch 5 sein
    public void The_result_should_be_1_over_5([Values("1/5", "-1/-5", "+1/5", "+1/+5", "1/+5")] string value) {
        Fraction.FromString(value)
            .Should().Be(new Fraction(1, 5));
    }
}

[TestFixture]
// German: Wenn aus der Zeichenkette minus 1/5 ein Bruch erzeugt wird
public class When_creating_a_fraction_from_the_string_minus_1_over_5 : Spec {
    [Test]
    // German: Das Ergebnis sollte minus 1 durch 5 sein
    public void The_result_should_be_minus_1_over_5([Values("-1/5", "1/-5")] string value) {
        Fraction.FromString(value)
            .Should().Be(new Fraction(-1, 5));
    }
}

[TestFixture]
// German: Wenn aus der Zeichenkette 64/40 mit beliebigen Leerzeichen ein Bruch erzeugt wird
public class When_creating_a_fraction_from_the_string_64_over_40_with_any_spaces : Spec {
    [Test]
    // German: Das Ergebnis sollte 64 durch 40 sein
    public void The_result_should_be_64_over_40(
        [Values("64/40 ", " 64/40", "64/ 40", "64 /40", "64 / 40")]
        string value) {
        Fraction.FromString(value)
            .Should().Be(new Fraction(8, 5));
    }
}

[TestFixture]
// German: Wenn aus der Zeichenkette minus 64/40 mit beliebigen Leerzeichen ein Bruch erzeugt wird
public class When_creating_a_fraction_from_the_string_minus_64_over_40_with_any_spaces : Spec {
    [Test]
    // German: Das Ergebnis sollte 64 durch 40 sein
    public void The_result_should_be_64_over_40(
        [Values("-64/40", " -64/40", "-64/ 40", "64 /-40", "64 / -40")]
        string value) {
        Fraction.FromString(value)
            .Should().Be(new Fraction(-8, 5));
    }
}

[TestFixture]
// German: Wenn aus der Zeichenkette minus 64/40 durch explizite Umwandlung ein Bruch erzeugt wird
public class When_creating_a_fraction_from_the_string_minus_64_over_40_by_explicit_conversion : Spec {
    private Fraction _result;

    public override void Act() {
        _result = (Fraction)"-64/40";
    }

    [Test]
    // German: Das Ergebnis sollte korrekt sein
    public void The_result_should_be_correct() {
        _result.Should().Be(new Fraction(-64, 40));
    }
}
