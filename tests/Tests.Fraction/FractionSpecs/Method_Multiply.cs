using Fractions;
using FluentAssertions;
using NUnit.Framework;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Tests.Fractions.FractionSpecs.Method_Multiply {
    [TestFixture]
    public class Wenn_0_mit_0_multipliziert_wird : Spec {
        private Fraction _result;

        public override void Act() {
            _result = Fraction.Zero.Multiply(Fraction.Zero);
        }

        [Test]
        public void Soll_das_Ergebnis_wieder_0_sein() {
            _result.Should().Be(Fraction.Zero);
        }
    }

    [TestFixture]
    public class Wenn_1_mit_0_multipliziert_wird : Spec {
        private Fraction _result1;
        private Fraction _result2;

        public override void Act() {
            _result1 = Fraction.One.Multiply(Fraction.Zero);
            _result2 = Fraction.Zero.Multiply(Fraction.One);
        }

        [Test]
        public void Soll_das_Ergebnis_wieder_0_sein() {
            _result1.Should().Be(Fraction.Zero);
        }

        [Test]
        public void Soll_die_Operation_kommutativ_sein() {
            _result1.Should().Be(_result2);
        }
    }

    [TestFixture]
    public class Wenn_ein_Fünftel_mit_ein_Fünftel_multipliziert_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(1, 5);
            _b = new Fraction(1, 5);
        }

        public override void Act() {
            _result = _a.Multiply(_b);
        }

        [Test]
        public void Soll_das_Ergebnis_ein_Fünfundzwanzigstel_sein() {
            _result.Should().Be(new Fraction(1, 25));
        }
    }

    [TestFixture]
    public class Wenn_2_mit_2_Viertel_multipliziert_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result1;
        private Fraction _result2;

        public override void SetUp() {
            _a = new Fraction(2, 1, false);
            _b = new Fraction(2, 4, false);
        }

        public override void Act() {
            _result1 = _a.Multiply(_b);
            _result2 = _b.Multiply(_a);
        }

        [Test]
        public void Soll_das_Ergebnis_1_sein() {
            _result1.Should().Be(Fraction.One);
        }

        [Test]
        public void Soll_die_Operation_kommutativ_sein() {
            _result1.Should().Be(_result2);
        }
    }

    [TestFixture]
    public class Wenn_minus_2_mit_2_Viertel_multipliziert_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result1;
        private Fraction _result2;

        public override void SetUp() {
            _a = new Fraction(-2, 1, false);
            _b = new Fraction(2, 4, false);
        }

        public override void Act() {
            _result1 = _a.Multiply(_b);
            _result2 = _b.Multiply(_a);
        }

        [Test]
        public void Soll_das_Ergebnis_minus_1_sein() {
            _result1.Should().Be(Fraction.MinusOne);
        }

        [Test]
        public void Soll_die_Operation_kommutativ_sein() {
            _result1.Should().Be(_result2);
        }
    }
}