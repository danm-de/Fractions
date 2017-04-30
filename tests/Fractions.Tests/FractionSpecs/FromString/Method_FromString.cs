using System;
using System.Globalization;
using FluentAssertions;
using Fractions.Tests.FractionSpecs.ValueEquals;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.FromString {
    [TestFixture]
    public class Wenn_versucht_wird_aus_einem_Leerstring_ein_Bruch_zu_erzeugen : Spec {
        [Test]
        public void Soll_dies_nicht_funktionieren([Values("", " ")] string invalidString) {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Invoking(() => Fraction.FromString(invalidString))
                .ShouldThrow<FormatException>();
        }
    }

    [TestFixture]
    public class Wenn_aus_999999999999999999999_ein_Bruch_zu_erzeugt_wird : Spec {
        private Fraction _result;

        public override void Act() {
            _result = Fraction.FromString("999999999999999999999");
        }

        [Test]
        public void Soll_der_Zähler_des_Bruches_999999999999999999999_sein() {
            _result.Numerator.ToString()
                .Should().Be("999999999999999999999");
        }

        [Test]
        public void Soll_der_Nenner_des_Bruches_1_sein() {
            _result.Denominator
                .Should().Be(1);
        }
    }

    [TestFixture]
    [Culture("de-DE")]
    public class Wenn_aus_minus_999999999999999999999_ein_Bruch_zu_erzeugt_wird : Spec {
        private Fraction _result;

        public override void Act() {
            _result = Fraction.FromString("-999999999999999999999");
        }

        [Test]
        public void Soll_der_Zähler_des_Bruches_minus_999999999999999999999_sein() {
            _result.Numerator.ToString()
                .Should().Be("-999999999999999999999");
        }

        [Test]
        public void Soll_der_Nenner_des_Bruches_1_sein() {
            _result.Denominator
                .Should().Be(1);
        }
    }

    [TestFixture]
    public class Wenn_aus_3_Komma_5_mit_deutscher_Kultur_ein_Bruch_erzeugt_wird : Spec {
        [Test]
        public void Soll_das_Ergebnis_7_durch_2_sein(
            [Values("3,5", " 3,5", "3,5 ", "+3,5", " +3,5", "+3,5 ")] string value) {
            Fraction.FromString(value, new CultureInfo("de-DE"))
                .Should().Be(new Fraction(7, 2));
        }
    }

    [TestFixture]
    [Culture("de-DE")]
    public class Wenn_aus_3_Komma_5_ohne_explizite_Angabe_der_Kultur_ein_Bruch_erzeugt_wird : Spec {
        [Test]
        public void Soll_das_Ergebnis_7_durch_2_sein(
            [Values("3,5", " 3,5", "3,5 ", "+3,5", " +3,5", "+3,5 ")] string value) {
            Fraction.FromString(value)
                .Should().Be(new Fraction(7, 2));
        }
    }

    [TestFixture]
    public class Wenn_aus_minus_3_Komma_5_mit_deutscher_Kultur_ein_Bruch_erzeugt_wird : Spec {
        [Test]
        public void Soll_das_Ergebnis_minus_7_durch_2_sein([Values("-3,5", " -3,5", "-3,5 ")] string value) {
            Fraction.FromString(value, new CultureInfo("de-DE"))
                .Should().Be(new Fraction(-7, 2));
        }
    }

    [TestFixture]
    public class Wenn_aus_3_Punkt_5_mit_US_amerikanischer_Kultur_ein_Bruch_erzeugt_wird : Spec {
        private Fraction _result;

        public override void Act() {
            _result = Fraction.FromString("3.5", new CultureInfo("en-US"));
        }

        [Test]
        public void Soll_das_Ergebnis_7_durch_2_sein() {
            _result.Should().Be(new Fraction(7, 2));
        }
    }

    [TestFixture]
    public class Wenn_aus_der_Zeichenkette_1_Slash_5_ein_Bruch_erzeugt_wird : Spec {
        [Test]
        public void Soll_das_Ergebnis_1_durch_5_sein([Values("1/5", "-1/-5", "+1/5", "+1/+5", "+1/+5")] string value) {
            Fraction.FromString(value)
                .Should().Be(new Fraction(1, 5));
        }
    }

    [TestFixture]
    public class Wenn_aus_der_Zeichenkette_minus_1_Slash_5_ein_Bruch_erzeugt_wird : Spec {
        [Test]
        public void Soll_das_Ergebnis_minus_1_durch_5_sein([Values("-1/5", "1/-5")] string value) {
            Fraction.FromString(value)
                .Should().Be(new Fraction(-1, 5));
        }
    }

    [TestFixture]
    public class Wenn_aus_der_Zeichenkette_64_Slash_40_mit_beliebigen_Leerzeichen_ein_Bruch_erzeugt_wird : Spec {
        [Test]
        public void Soll_das_Ergebnis_64_durch_40_sein(
            [Values("64/40 ", " 64/40", "64/ 40", "64 /40", "64 / 40")] string value) {
            Fraction.FromString(value)
                .Should().Be(new Fraction(8, 5));
        }
    }

    [TestFixture]
    public class Wenn_aus_der_Zeichenkette_minus_64_Slash_40_mit_beliebigen_Leerzeichen_ein_Bruch_erzeugt_wird : Spec {
        [Test]
        public void Soll_das_Ergebnis_64_durch_40_sein(
            [Values("-64/40", " -64/40", "-64/ 40", "64 /-40", "64 / -40")] string value) {
            Fraction.FromString(value)
                .Should().Be(new Fraction(-8, 5));
        }
    }

    [TestFixture]
    public class Wenn_aus_der_Zeichenkette_minus_64_Slash_40_durch_explizite_Umwandlung_ein_Bruch_erzeugt_wird : Spec {
        private Fraction _result;

        public override void Act() {
            _result = (Fraction) "-64/40";
        }

        [Test]
        public void Soll_das_Ergebnis_korrekt_sein() {
            _result.Should().Be(new Fraction(-64, 40));
        }
    }
}