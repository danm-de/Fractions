using System.Collections;
using Fractions;
using NUnit.Framework;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Tests.Fractions.FractionSpecs.Method_Pow
{
    [TestFixture]
    public class Wenn_an_einem_Bruch_die_Potenz_angewendet_wird : Spec
    {
        private static IEnumerable TestCases {
            get {
                yield return new TestCaseData(new Fraction(1, 3), 2)
                       .Returns(new Fraction(1, 9));

                yield return new TestCaseData(new Fraction(3), -1)
                       .Returns(new Fraction(1, 3));

                yield return new TestCaseData(new Fraction(3), 0)
                       .Returns(new Fraction(1));

                yield return new TestCaseData(new Fraction(0), 0)
                       .Returns(new Fraction(1));

                yield return new TestCaseData(new Fraction(3), 2)
                       .Returns(new Fraction(9));

                yield return new TestCaseData(new Fraction(3), 3)
                       .Returns(new Fraction(27));

                yield return new TestCaseData(new Fraction(3), -2)
                       .Returns(new Fraction(1, 9));

            }
        }

        [Test, TestCaseSource("TestCases")]
        public Fraction Soll_das_Ergebnis_korrekt_sein(Fraction bruch, int potenz) {
            return Fraction.Pow(bruch, potenz);
        }
    }
}