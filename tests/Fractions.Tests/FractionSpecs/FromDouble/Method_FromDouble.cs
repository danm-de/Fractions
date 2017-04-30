using System;
using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;


// ReSharper disable ReturnValueOfPureMethodIsNotUsed

namespace Fractions.Tests.FractionSpecs.FromDouble {
    [TestFixture]
    public class Wenn_ein_Bruch_anhand_einer_NaN_double_Zahl_erzeugt_wird : Spec {
        private Exception _exception;

        public override void SetUp() {
            base.SetUp();
            _exception = Catch.Exception(() => Fraction.FromDouble(double.NaN));
        }

        [Test]
        public void Soll_dies_eine_NotANumberException_auslösen() {
            _exception.Should().BeOfType<InvalidNumberException>();
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_anhand_einer_positiv_unendlichen_double_Zahl_erzeugt_wird : Spec {
        private Exception _exception;

        public override void SetUp() {
            base.SetUp();
            _exception = Catch.Exception(() => Fraction.FromDouble(double.PositiveInfinity));
        }

        [Test]
        public void Soll_dies_eine_NotANumberException_auslösen() {
            _exception.Should().BeOfType<InvalidNumberException>();
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_anhand_einer_negativ_unendlichen_double_Zahl_erzeugt_wird : Spec {
        private Exception _exception;

        public override void SetUp() {
            base.SetUp();
            _exception = Catch.Exception(() => Fraction.FromDouble(double.NegativeInfinity));
        }

        [Test]
        public void Soll_dies_eine_NotANumberException_auslösen() {
            _exception.Should().BeOfType<InvalidNumberException>();
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_einer_0_double_Zahl_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void SetUp() {
            base.SetUp();
            _fraction = Fraction.FromDouble(0.0);
        }

        [Test]
        public void Soll_der_Wert_danach_0_sein() {
            _fraction.Should().Be(Fraction.Zero);
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_einer_minus_1_double_Zahl_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void SetUp() {
            base.SetUp();
            _fraction = Fraction.FromDouble(-1.0);
        }

        [Test]
        public void Soll_der_Wert_danach_minus_1_sein() {
            _fraction.Should().Be(new Fraction(-1, 1));
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_einer_1_double_Zahl_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void SetUp() {
            base.SetUp();
            _fraction = Fraction.FromDouble(1);
        }

        [Test]
        public void Soll_der_Wert_danach_1_sein() {
            _fraction.Should().Be(new Fraction(1, 1));
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_einer_1_Komma_345_double_Zahl_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void SetUp() {
            base.SetUp();
            _fraction = Fraction.FromDouble(1.345);
        }

        [Test]
        public void Soll_der_auf_15_Nachkommastellen_gerundete_Wert_der_Zahl_entsprechen() {
            var rounded = Math.Round(_fraction.ToDouble(), 15, MidpointRounding.ToEven);
            rounded.Should().Be(1.345);
        }

    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_einer_0_Komma_3125_double_Zahl_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void SetUp() {
            base.SetUp();
            _fraction = Fraction.FromDouble(0.3125);
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Zähler_von_5_haben() {
            _fraction.Numerator.Should().Be(new BigInteger(5));
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Nenner_von_16_haben() {
            _fraction.Denominator.Should().Be(new BigInteger(16));
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_einer_minus_0_Komma_3125_double_Zahl_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void SetUp() {
            base.SetUp();
            _fraction = Fraction.FromDouble(-0.3125);
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Zähler_von_minus_5_haben() {
            _fraction.Numerator.Should().Be(new BigInteger(-5));
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Nenner_von_16_haben() {
            _fraction.Denominator.Should().Be(new BigInteger(16));
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_double_MaxValue_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void SetUp() {
            base.SetUp();
            _fraction = Fraction.FromDouble(double.MaxValue);
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Zähler_von_double_MaxValue_haben() {
            _fraction.Numerator.Should().Be(new BigInteger(double.MaxValue));
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Nenner_von_1_haben() {
            _fraction.Denominator.Should().Be(new BigInteger(1));
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_double_MinValue_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void SetUp() {
            base.SetUp();
            _fraction = Fraction.FromDouble(double.MinValue);
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Zähler_von_minus_double_MaxValue_haben() {
            _fraction.Numerator.Should().Be(BigInteger.Negate(new BigInteger(double.MaxValue)));
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Nenner_von_1_haben() {
            _fraction.Denominator.Should().Be(new BigInteger(1));
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_PI_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void SetUp() {
            base.SetUp();
            _fraction = Fraction.FromDouble(Math.PI);
        }

        [Test]
        public void Soll_der_Bruch_zurück_in_Double_umgewandelt_mit_PI_gleich_sein() {
            _fraction.ToDouble().Should().Be(Math.PI);
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_von_0_komma_1_ohne_Rundung_erzeugt_wird : Spec
    {
        private Fraction _fraction;
        public override void SetUp() {
            base.SetUp();
            _fraction = Fraction.FromDouble(0.1);
            Console.WriteLine(_fraction.ToString());
        }

        [Test]
        public void Soll_das_Ergebnis_3602879701896397_durch_36028797018963968_sein() {
            _fraction.Should().Be(new Fraction(3602879701896397L, 36028797018963968L));
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_von_0_komma_1_mit_Rundung_erzeugt_wird : Spec
    {
        private Fraction _fraction;
        public override void SetUp() {
            base.SetUp();
            _fraction = Fraction.FromDoubleRounded(0.1);
            Console.WriteLine(_fraction.ToString());
        }

        [Test]
        public void Soll_das_Ergebnis_1_durch_10_sein() {
            _fraction.Should().Be(new Fraction(1, 10));
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_1_Drittel_erzeugt_wird : Spec {
        private Fraction _fraction;
        private const double ONE_THIRD = 1.0 / 3.0;

        public override void SetUp() {
            base.SetUp();
            _fraction = Fraction.FromDouble(ONE_THIRD);
        }

        [Test]
        public void Soll_der_auf_15_Nachkommastellen_gerundete_Wert_der_Zahl_entsprechen() {
            var rounded = Math.Round(_fraction.ToDouble(), 15, MidpointRounding.ToEven);
            rounded.Should().Be(0.333333333333333);
        }
    }
}