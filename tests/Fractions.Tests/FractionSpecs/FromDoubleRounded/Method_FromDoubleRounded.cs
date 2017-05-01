using System;
using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.FromDoubleRounded {

    [TestFixture]
    public class Wenn_ein_Bruch_anhand_einer_NaN_double_Zahl_erzeugt_wird : Spec {
        private Exception _exception;

        public override void SetUp() {
            _exception = Catch.Exception(() => Fraction.FromDoubleRounded(double.NaN));
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
            _exception = Catch.Exception(() => Fraction.FromDoubleRounded(double.PositiveInfinity));
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
            _exception = Catch.Exception(() => Fraction.FromDoubleRounded(double.NegativeInfinity));
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
            _fraction = Fraction.FromDoubleRounded(0);
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
            _fraction = Fraction.FromDoubleRounded(-1);
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
            _fraction = Fraction.FromDoubleRounded(1);
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
            _fraction = Fraction.FromDoubleRounded(1.345);
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Zähler_von_269_haben() {
            _fraction.Numerator.Should().Be(new BigInteger(269));
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Nenner_von_200_haben() {
            _fraction.Denominator.Should().Be(new BigInteger(200));
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_double_MaxValue_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void SetUp() {
            _fraction = Fraction.FromDoubleRounded(double.MaxValue);
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
            _fraction = Fraction.FromDoubleRounded(double.MinValue);
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
            _fraction = Fraction.FromDoubleRounded(Math.PI);
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Zähler_von_245850922_haben() {
            _fraction.Numerator.Should().Be(245850922);
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Nenner_von_78256779_haben() {
            _fraction.Denominator.Should().Be(78256779);
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_1_Drittel_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void SetUp() {
            _fraction = Fraction.FromDoubleRounded(1.0 / 3.0);
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Zähler_von_1_haben() {
            _fraction.Numerator.Should().Be(1);
        }

        [Test]
        public void Soll_der_Bruch_danach_einen_Nenner_von_3_haben() {
            _fraction.Denominator.Should().Be(3);
        }
    }
}