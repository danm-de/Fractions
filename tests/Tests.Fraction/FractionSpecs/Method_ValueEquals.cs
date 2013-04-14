// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

using Fractions;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.Fractions.FractionSpecs
{
    [TestFixture]
    public class Wenn_zwei_Brüche_mit_identischen_Zähler_und_Nenner_verglichen_werden : Spec
    {
        private Fraction _fraction_a;
        private Fraction _fraction_b;

        public override void SetUp() {
            base.SetUp();

            _fraction_a = new Fraction(5, 6, true);
            _fraction_b = new Fraction(5, 6, true);
        }

        [Test]
        public void Sollen_diese_als_Wertgleich_erkannt_werden() {
            _fraction_a.IsEquivalentTo(_fraction_b)
                .Should().BeTrue();
        }
    }

    [TestFixture]
    public class Wenn_zwei_Brüche_mit_unterschiedlichen_Zähler_aber_identischen_Nenner_verglichen_werden : Spec
    {
        private Fraction _fraction_a;
        private Fraction _fraction_b;

        public override void SetUp() {
            base.SetUp();

            _fraction_a = new Fraction(4, 6, true);
            _fraction_b = new Fraction(5, 6, true);
        }

        [Test]
        public void Sollen_diese_als_nicht_Wertgleich_erkannt_werden() {
            _fraction_a.IsEquivalentTo(_fraction_b)
                .Should().BeFalse();
        }
    }

    [TestFixture]
    public class Wenn_zwei_Brüche_mit_identischen_Zähler_aber_unterschiedlichen_Nenner_verglichen_werden : Spec
    {
        private Fraction _fraction_a;
        private Fraction _fraction_b;

        public override void SetUp() {
            base.SetUp();

            _fraction_a = new Fraction(4, 6, true);
            _fraction_b = new Fraction(4, 7, true);
        }

        [Test]
        public void Sollen_diese_als_nicht_Wertgleich_erkannt_werden() {
            _fraction_a.IsEquivalentTo(_fraction_b)
                .Should().BeFalse();
        }
    }

    [TestFixture]
    public class Wenn_der_Bruch_2_4_mit_dem_Bruch_1_2_verglichen_wird : Spec
    {
        private Fraction _fraction_a;
        private Fraction _fraction_b;

        public override void SetUp() {
            base.SetUp();

            _fraction_a = new Fraction(2, 4, false);
            _fraction_b = new Fraction(1, 2, true);
        }


        [Test]
        public void Sollen_die_Brüche_als_nicht_strukturell_gleich_erkannt_werden() {
            _fraction_a.Equals(_fraction_b)
                .Should().BeFalse();
        }

        [Test]
        public void Sollen_die_Brüche_als_Wertgleich_erkannt_werden() {
            _fraction_a.IsEquivalentTo(_fraction_b)
                .Should().BeTrue();
        }
    }
}