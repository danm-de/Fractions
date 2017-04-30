using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Add {
    
    [TestFixture]
    public class If_the_user_adds_two_fractions : Spec {
        private static IEnumerable<TestCaseData> TestCases {
            get {
                yield return new TestCaseData(Fraction.Zero, Fraction.Zero).Returns(Fraction.Zero);
                yield return new TestCaseData(new Fraction(1L, 5L), new Fraction(1L, 4L)).Returns(new Fraction(9L, 20L));
                yield return new TestCaseData(new Fraction(1L, 5L), Fraction.Zero).Returns(new Fraction(1L, 5L));
                yield return new TestCaseData(Fraction.Zero, new Fraction(1L, 5L)).Returns(new Fraction(1L, 5L));
                yield return new TestCaseData(new Fraction(1, long.MaxValue), new Fraction(1, long.MaxValue - 1)).Returns(new Fraction(
                    BigInteger.Parse("18446744073709551613"),
                    BigInteger.Parse("85070591730234615838173535747377725442")
                    ));
            }
        }
        
        [Test,TestCaseSource(nameof(TestCases))]
        public Fraction Shall_it_return_the_expected_result(Fraction a, Fraction b) {
            return a.Add(b);
        }
    }
}
