using System.Collections.Generic;
using Fractions;
using NUnit.Framework;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Tests.Fractions.FractionSpecs.Method_Abs {
    [TestFixture]
    public class If_the_Abs_function_is_called : Spec {
        private static IEnumerable<TestCaseData> TestCases {
            get {
                yield return new TestCaseData(Fraction.Zero).Returns(Fraction.Zero);
                yield return new TestCaseData(Fraction.One).Returns(Fraction.One);
                yield return new TestCaseData(Fraction.MinusOne).Returns(Fraction.One);
                yield return new TestCaseData(new Fraction(-1, 3)).Returns(new Fraction(1, 3));
                yield return new TestCaseData(new Fraction(-1, 3)).Returns(new Fraction(1, 3));
                yield return new TestCaseData(new Fraction(1, -3, false)).Returns(new Fraction(1, 3, false));
                yield return new TestCaseData(new Fraction(-1, -3, false)).Returns(new Fraction(1, 3, false));
            }
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public Fraction Shall_the_returning_fraction_be_positive(Fraction fraction) {
            return fraction.Abs();
        }
    }
}