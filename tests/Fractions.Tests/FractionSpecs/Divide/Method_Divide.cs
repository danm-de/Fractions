

// ReSharper disable ReturnValueOfPureMethodIsNotUsed

using System;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Divide {
    [TestFixture]
    public class Wenn_0_mit_0_dividiert_wird : Spec {
        private Exception _exception;

        public override void Act() {
            _exception = Catch.Exception(() => Fraction.Zero.Divide(Fraction.Zero));

        }

        [Test]
        public void Soll_dies_eine_DivideByZeroException_auslösen() {
            _exception.Should().BeOfType<DivideByZeroException>();
        }
    }

    [TestFixture]
    public class Wenn_1_mit_0_dividiert_wird : Spec {
        private Exception _exception;

        public override void Act() {
            _exception = Catch.Exception(() => Fraction.One.Divide(Fraction.Zero));
        }

        [Test]
        public void Soll_dies_eine_DivideByZeroException_auslösen() {
            _exception.Should().BeOfType<DivideByZeroException>();
        }
    }

    [TestFixture]
    public class Wenn_minus_1_mit_0_dividiert_wird : Spec {
        private Exception _exception;

        public override void Act() {
            _exception = Catch.Exception(() => Fraction.MinusOne.Divide(Fraction.Zero));
        }

        [Test]
        public void Soll_dies_eine_DivideByZeroException_auslösen() {
            _exception.Should().BeOfType<DivideByZeroException>();
        }
    }

    [TestFixture]
    public class Wenn_ein_Fünftel_mit_ein_Fünftel_dividiert_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(1, 5);
            _b = new Fraction(1, 5);
        }

        public override void Act() {
            _result = _a.Divide(_b);
        }

        [Test]
        public void Soll_das_Ergebnis_1_sein() {
            _result.Should().Be(new Fraction(1, 1));
        }
    }

    [TestFixture]
    public class Wenn_2_mit_2_Viertel_dividiert_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(2, 1, false);
            _b = new Fraction(2, 4, false);
        }

        public override void Act() {
            _result = _a.Divide(_b);
        }

        [Test]
        public void Soll_das_Ergebnis_4_sein() {
            _result.Should().Be(new Fraction(4, 1));
        }
    }

    [TestFixture]
    public class Wenn_minus_2_mit_2_Viertel_dividiert_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(-2, 1, false);
            _b = new Fraction(2, 4, false);
        }

        public override void Act() {
            _result = _a.Divide(_b);
        }

        [Test]
        public void Soll_das_Ergebnis_minus_4_sein() {
            _result.Should().Be(new Fraction(-4, 1));
        }
    }

    [TestFixture]
    public class Wenn_0_Achtel_durch_4_dividiert_werden : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(0, 8, false);
            _b = new Fraction(4, 1, true);
        }

        public override void Act() {
            _result = _a.Divide(_b);
        }

        [Test]
        public void Soll_das_Ergebnis_0_sein() {
            _result.Should().Be(Fraction.Zero);
        }
    }

    [TestFixture]
    public class Wenn_0_durch_4_dividiert_werden : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(0, 0, false);
            _b = new Fraction(4, 1, true);
        }

        public override void Act() {
            _result = _a.Divide(_b);
        }

        [Test]
        public void Soll_das_Ergebnis_0_sein() {
            _result.Should().Be(Fraction.Zero);
        }
    }
}