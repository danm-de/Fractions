// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

using System;
using Fractions;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.Fractions.FractionSpecs.Method_Add {
    [TestFixture]
    public class Wenn_zwei_Brüche_die_den_Zahlenwert_0_entsprechen_addiert_werden_dann : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = Fraction.Zero;
            _b = Fraction.Zero;
        }

        public override void Arrange() {
            _result = _a.Add(_b);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_ebenfalls_0_sein() {
            _result.IsZero
                .Should()
                .BeTrue();
        }
    }

    [TestFixture]
    public class Wenn_ein_Fünftel_und_ein_Viertel_addiert_werden_dann : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(1L, 5L);
            _b = new Fraction(1L, 4L);
        }

        public override void Act() {
            _result = _a.Add(_b);
        }

        [Test]
        public void Soll_das_Ergebnis_9_Zwanzigstel_sein() {
            _result.Numerator
                .Should()
                .Be(9);

            _result.Denominator
                .Should()
                .Be(20);
        }
    }

    [TestFixture]
    public class Wenn_ein_Fünftel_und_0_addiert_werden_dann : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(1L, 5L);
            _b = Fraction.Zero;
        }

        public override void Act() {
            _result = _a.Add(_b);
        }

        [Test]
        public void Soll_das_Ergebnis_1_Fünftel_sein() {
            _result.Numerator
                .Should()
                .Be(1);

            _result.Denominator
                .Should()
                .Be(5);
        }
    }

    [TestFixture]
    public class Wenn_0_und_ein_Fünftel_addiert_werden_dann : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = Fraction.Zero;
            _b = new Fraction(1L, 5L);
        }

        public override void Act() {
            _result = _a.Add(_b);
        }

        [Test]
        public void Soll_das_Ergebnis_1_Fünftel_sein() {
            _result.Numerator
                .Should()
                .Be(1);

            _result.Denominator
                .Should()
                .Be(5);
        }
    }

    [TestFixture]
    public class Wenn_ein_1_durch_Int64_MaxValue_mit_1_durch_In64_MaxValueMinus1_addiert_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(1, Int64.MaxValue, true);
            _b = new Fraction(1, Int64.MaxValue - 1, true);
        }

        public override void Act() {

            _result = _a.Add(_b);
        }

        [Test]
        public void Soll_der_Denominator_nicht_3074457345618258602_sein() {
            _result.Denominator.Should().NotBe(3074457345618258602);
        }
    }
}
