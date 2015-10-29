using Fractions;
using FluentAssertions;
using NUnit.Framework;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Tests.Fractions.FractionSpecs.Method_Subtract {
    [TestFixture]
    public class Wenn_2_Fünftel_mit_1_Fünftel_subtrahiert_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(2, 5);
            _b = new Fraction(1, 5);
        }

        public override void Act() {
            _result = _a.Subtract(_b);
        }

        [Test]
        public void Soll_der_Zähler_im_Ergebnis_1_sein() {
            _result.Numerator.Should().Be(1);
        }

        [Test]
        public void Soll_der_Nenner_im_Ergebnis_5_sein() {
            _result.Denominator.Should().Be(5);
        }
    }

    [TestFixture]
    public class Wenn_1_Fünftel_mit_2_Fünftel_subtrahiert_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(1, 5);
            _b = new Fraction(2, 5);
        }

        public override void Act() {
            _result = _a.Subtract(_b);
        }

        [Test]
        public void Soll_der_Zähler_im_Ergebnis_minus_1_sein() {
            _result.Numerator.Should().Be(-1);
        }

        [Test]
        public void Soll_der_Nenner_im_Ergebnis_5_sein() {
            _result.Denominator.Should().Be(5);
        }
    }

    [TestFixture]
    public class Wenn_1_Fünftel_mit_1_Fünftel_subtrahiert_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(1, 5);
            _b = new Fraction(1, 5);
        }

        public override void Act() {
            _result = _a.Subtract(_b);
        }

        [Test]
        public void Soll_der_Zähler_im_Ergebnis_0_sein() {
            _result.Numerator.Should().Be(0);
        }

        [Test]
        public void Soll_der_Nenner_im_Ergebnis_0_sein() {
            _result.Denominator.Should().Be(0);
        }

        [Test]
        public void Soll_der_Wert_des_Bruches_als_Null_erkannt_werden() {
            _result.IsZero.Should().BeTrue();
        }
    }
}