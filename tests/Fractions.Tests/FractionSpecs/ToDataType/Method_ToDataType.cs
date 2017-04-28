using System;
using System.Collections;
using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.ToDataType {
    [TestFixture]
    public class Wenn_ein_0_Bruch_in_ein_Decimal_konvertiert_wird : Spec {
        [Test]
        public void Soll_das_Ergebnis_0_sein() {
            Fraction.Zero.ToDecimal().Should().Be(0);
        }
    }

    [TestFixture]
    public class Wenn_ein_1viertel_in_ein_Decimal_konvertiert_wird : Spec {
        [Test]
        public void Soll_das_Ergebnis_0_25_sein() {
            (new Fraction(1, 4)).ToDecimal().Should().Be(0.25m);
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_sehr_groﬂen_Zahlen_in_Z‰hler_und_Nenner_in_ein_Decimal_konvertiert_wird : Spec {
        private Fraction _fraction;
        private decimal _result;

        public override void SetUp() {
            var drei_durch_9 = new Fraction(3, 9).ToDecimal();
            var sechs_durch_9 = new Fraction(6, 9).ToDecimal();
            _fraction = new Fraction(drei_durch_9) * new Fraction(sechs_durch_9);
        }

        public override void Act() {
            _result = _fraction.ToDecimal();
        }

        [Test]
        public void Soll_das_Resultat_dem_erwarteten_Ergebnis_entsprechen() {
            Math.Round(_result, 27).Should().Be(0.222222222222222222222222222m);
        }
    }

    [TestFixture]
    public class If_the_user_converts_a_fraction_to_BigInteger : Spec {
        private static IEnumerable TestCases {
            get {
                yield return new TestCaseData(new Fraction(0)).Returns(new BigInteger(0));
                yield return new TestCaseData(new Fraction(1)).Returns(new BigInteger(1));
                yield return new TestCaseData(new Fraction(-1)).Returns(new BigInteger(-1));
                yield return
                    new TestCaseData(new Fraction(new BigInteger(long.MaxValue), new BigInteger(1))).Returns(
                        new BigInteger(long.MaxValue));
            }
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public BigInteger Shall_the_result_be_correct(Fraction value) {
            return value.ToBigInteger();
        }
    }
}