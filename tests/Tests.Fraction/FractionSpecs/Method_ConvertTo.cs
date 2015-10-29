// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

using Fractions;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.Fractions.FractionSpecs.Method_ConvertTo {
    [TestFixture]
    public class Wenn_ein_Bruch_mit_NULL_verglichen_wird : Spec {
        [Test]
        public void Soll_das_Ergebnis_1_sein() {
            Fraction.One.CompareTo(null)
                .Should().Be(1);
        }
    }

    [TestFixture]
    public class Wenn_1_mit_2_verglichen_wird : Spec {
        [Test]
        public void Soll_das_Ergebnis_kleiner_0_sein() {
            Fraction.One.CompareTo(new Fraction(2))
                .Should().BeLessThan(0);
        }
    }

    [TestFixture]
    public class Wenn_1_mit_minus_2_verglichen_wird : Spec {
        [Test]
        public void Soll_das_Ergebnis_größer_0_sein() {
            Fraction.One.CompareTo(new Fraction(-2))
                .Should().BeGreaterThan(0);
        }
    }

    [TestFixture]
    public class Wenn_1_mit_1_verglichen_wird : Spec {
        [Test]
        public void Soll_das_Ergebnis_gleich_0_sein() {
            Fraction.One.CompareTo(new Fraction(1, 1, false))
                .Should().Be(0);
        }
    }

    [TestFixture]
    public class Wenn_1_Viertel_mit_2_Achtel_verglichen_wird : Spec {
        private Fraction _a;
        private Fraction _b;

        public override void SetUp() {
            _a = new Fraction(1, 4, false);
            _b = new Fraction(2, 8, false);
        }

        [Test]
        public void Soll_das_Ergebnis_gleich_0_sein() {
            _a.CompareTo(_b)
                .Should().Be(0);
        }

        [Test]
        public void Sollen_diese_nicht_als_vollständig_identisch_erachtet_werden() {
            _a.Equals(_b)
                .Should().BeFalse();
        }

        [Test]
        public void Sollen_diese_als_Wertgleich_bzw_äquivalent_erachtet_werden() {
            _a.IsEquivalentTo(_b)
                .Should().BeTrue();
        }
    }
}