using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.CompareTo {
    [TestFixture]
    public class When_comparing_to_fractions : Spec {
        private static IEnumerable<TestCaseData> TestCases {
            get {
                yield return new TestCaseData(new Fraction(5), new Fraction(4)).Returns(1);
                yield return new TestCaseData(new Fraction(4), new Fraction(5)).Returns(-1);
                yield return new TestCaseData(new Fraction(5), new Fraction(5)).Returns(0);
                yield return new TestCaseData(Fraction.Zero, Fraction.Zero).Returns(0);
                yield return new TestCaseData(new Fraction(1,5), new Fraction(1,10)).Returns(1);
                yield return new TestCaseData(new Fraction(0), new Fraction(131)).Returns(-1);
                yield return new TestCaseData(new Fraction(-1), new Fraction(-1)).Returns(0);
                yield return new TestCaseData(new Fraction(-1), new Fraction(0)).Returns(-1);
                yield return new TestCaseData(new Fraction(0), new Fraction(-1)).Returns(1);
            }
        }

        [Test,TestCaseSource(nameof(TestCases))]
        public int Shall_the_method_CompareTo_return_the_expected_result(Fraction a, Fraction b) {
            return a.CompareTo(b);
        }
    }
 }