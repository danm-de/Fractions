// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

using Fractions;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.Fractions.FractionSpecs.Method_FromInvert
{
    [TestFixture]
    public class Wenn_ein_Bruch_mit_0_als_Zähler_und_0_als_Nenner_negiert_wird : Spec
    {
        private Fraction _result;

        public override void Act() {
            _result = new Fraction(0, 0, false).Invert();
        }

        [Test]
        public void Soll_der_resultierende_Bruch_0_als_Zähler_haben() {
            _result.Numerator
                .Should().Be(0);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_0_als_Nenner_haben() {
            _result.Denominator
                .Should().Be(0);
        }

        [Test]
        public void Soll_der_Bruch_0_sein() {
            _result.IsZero
                .Should().BeTrue();
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_0_als_Zähler_und_4_als_Nenner_negiert_wird : Spec
    {
        private Fraction _result;

        public override void Act() {
            _result = new Fraction(0, 4, false).Invert();
        }

        [Test]
        public void Soll_der_resultierende_Bruch_0_als_Zähler_haben() {
            _result.Numerator
                .Should().Be(0);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_0_als_Nenner_haben() {
            _result.Denominator
                .Should().Be(0);
        }

        [Test]
        public void Soll_der_Bruch_0_sein() {
            _result.IsZero
                .Should().BeTrue();
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_minus_1_als_Zähler_und_1_als_Nenner_negiert_wird : Spec
    {
        private Fraction _result;

        public override void Act() {
            _result = new Fraction(-1, 1, false).Invert();
        }

        [Test]
        public void Soll_der_resultierende_Bruch_1_als_Zähler_haben() {
            _result.Numerator
                .Should().Be(1);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_1_als_Nenner_haben() {
            _result.Denominator
                .Should().Be(1);
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_1_als_Zähler_und_1_als_Nenner_negiert_wird : Spec
    {
        private Fraction _result;

        public override void Act() {
            _result = new Fraction(1, 1, false).Invert();
        }

        [Test]
        public void Soll_der_resultierende_Bruch_minus_1_als_Zähler_haben() {
            _result.Numerator
                .Should().Be(-1);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_1_als_Nenner_haben() {
            _result.Denominator
                .Should().Be(1);
        }
    }
}