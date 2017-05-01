using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.ValueEquals {
    [TestFixture]
    public class Wenn_zwei_Brüche_mit_identischen_Zähler_und_Nenner_verglichen_werden : Spec {
        private Fraction _fractionA;
        private Fraction _fractionB;

        public override void SetUp() {
            base.SetUp();

            _fractionA = new Fraction(5, 6, true);
            _fractionB = new Fraction(5, 6, true);
        }

        [Test]
        public void Sollen_diese_als_Wertgleich_erkannt_werden() {
            _fractionA.IsEquivalentTo(_fractionB)
                .Should().BeTrue();
        }
    }

    [TestFixture]
    public class Wenn_zwei_Brüche_mit_unterschiedlichen_Zähler_aber_identischen_Nenner_verglichen_werden : Spec {
        private Fraction _fractionA;
        private Fraction _fractionB;

        public override void SetUp() {
            base.SetUp();

            _fractionA = new Fraction(4, 6, true);
            _fractionB = new Fraction(5, 6, true);
        }

        [Test]
        public void Sollen_diese_als_nicht_Wertgleich_erkannt_werden() {
            _fractionA.IsEquivalentTo(_fractionB)
                .Should().BeFalse();
        }
    }

    [TestFixture]
    public class Wenn_zwei_Brüche_mit_identischen_Zähler_aber_unterschiedlichen_Nenner_verglichen_werden : Spec {
        private Fraction _fractionA;
        private Fraction _fractionB;

        public override void SetUp() {
            base.SetUp();

            _fractionA = new Fraction(4, 6, true);
            _fractionB = new Fraction(4, 7, true);
        }

        [Test]
        public void Sollen_diese_als_nicht_Wertgleich_erkannt_werden() {
            _fractionA.IsEquivalentTo(_fractionB)
                .Should().BeFalse();
        }
    }

    [TestFixture]
    public class Wenn_der_Bruch_2_4_mit_dem_Bruch_1_2_verglichen_wird : Spec {
        private Fraction _fractionA;
        private Fraction _fractionB;

        public override void SetUp() {
            base.SetUp();

            _fractionA = new Fraction(2, 4, false);
            _fractionB = new Fraction(1, 2, true);
        }


        [Test]
        public void Sollen_die_Brüche_als_nicht_strukturell_gleich_erkannt_werden() {
            _fractionA.Equals(_fractionB)
                .Should().BeFalse();
        }

        [Test]
        public void Sollen_die_Brüche_als_Wertgleich_erkannt_werden() {
            _fractionA.IsEquivalentTo(_fractionB)
                .Should().BeTrue();
        }
    }
}