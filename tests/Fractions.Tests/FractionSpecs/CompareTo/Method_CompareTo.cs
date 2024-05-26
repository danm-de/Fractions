using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.CompareTo;

[TestFixture]
public class When_comparing_two_fractions : Spec {
    private static IEnumerable<TestCaseData> TestCases {
        get {
            // two positive numbers
            yield return new TestCaseData(new Fraction(5), new Fraction(4)).Returns(1);
            yield return new TestCaseData(new Fraction(4), new Fraction(5)).Returns(-1);
            yield return new TestCaseData(new Fraction(5), new Fraction(5)).Returns(0);
            yield return new TestCaseData(new Fraction(1, 5), new Fraction(1, 10)).Returns(1);
            yield return new TestCaseData(new Fraction(1, 10), new Fraction(10, 100, false)).Returns(0);
            yield return new TestCaseData(new Fraction(1, 10), new Fraction(-10, -100, false)).Returns(0);
            yield return new TestCaseData(new Fraction(-100, -1000, false), new Fraction(-10, -100, false)).Returns(0);
            yield return new TestCaseData(new Fraction(0.2m), new Fraction(-2, -10, false)).Returns(0);
            yield return new TestCaseData(new Fraction(-2, -10, false), new Fraction(0.2m)).Returns(0);

            yield return new TestCaseData(new Fraction(0.1m), new Fraction(-2, -10, false)).Returns(-1);
            yield return new TestCaseData(new Fraction(0.3m), new Fraction(-2, -10, false)).Returns(1);
            yield return new TestCaseData(new Fraction(-2, -10, false), new Fraction(0.1m)).Returns(1);
            yield return new TestCaseData(new Fraction(-2, -10, false), new Fraction(0.3m)).Returns(-1);
            // two negative numbers
            yield return new TestCaseData(new Fraction(-5), new Fraction(-4)).Returns(-1);
            yield return new TestCaseData(new Fraction(-4), new Fraction(-5)).Returns(1);
            yield return new TestCaseData(new Fraction(-5), new Fraction(-5)).Returns(0);
            yield return new TestCaseData(new Fraction(-1, 5), new Fraction(-1, 10)).Returns(-1);
            yield return new TestCaseData(new Fraction(-1, 10), new Fraction(10, -100, false)).Returns(0);
            yield return new TestCaseData(new Fraction(-1, 10), new Fraction(-10, 100, false)).Returns(0);
            yield return new TestCaseData(new Fraction(-100, 1000, false), new Fraction(10, -100, false)).Returns(0);
            // numbers with opposite signs
            yield return new TestCaseData(Fraction.One, Fraction.MinusOne).Returns(1);
            yield return new TestCaseData(Fraction.MinusOne, Fraction.One).Returns(-1);
            yield return new TestCaseData(new Fraction(1, 5), new Fraction(-1, 10)).Returns(1);
            yield return new TestCaseData(new Fraction(1, 10), new Fraction(-10, 100, false)).Returns(1);
            yield return new TestCaseData(new Fraction(-1, 10), new Fraction(1, 5)).Returns(-1);
            yield return new TestCaseData(new Fraction(-10, 100, false), new Fraction(1, 10)).Returns(-1);
            // zero with zero
            yield return new TestCaseData(Fraction.Zero, Fraction.Zero).Returns(0);
            yield return new TestCaseData(Fraction.Zero, new Fraction(BigInteger.Zero, 4)).Returns(0);
            yield return new TestCaseData(Fraction.Zero, new Fraction(BigInteger.Zero, -4)).Returns(0);
            // zero with positive numbers
            yield return new TestCaseData(Fraction.Zero, Fraction.One).Returns(-1);
            yield return new TestCaseData(Fraction.Zero, new Fraction(5, 4)).Returns(-1);
            yield return new TestCaseData(Fraction.Zero, new Fraction(4, 5)).Returns(-1);
            yield return new TestCaseData(Fraction.Zero, Fraction.PositiveInfinity).Returns(-1);
            yield return new TestCaseData(Fraction.Zero, new Fraction(5, 0, false)).Returns(-1);
            // zero with negative numbers
            yield return new TestCaseData(Fraction.Zero, Fraction.MinusOne).Returns(1);
            yield return new TestCaseData(Fraction.Zero, new Fraction(-5, 4)).Returns(1);
            yield return new TestCaseData(Fraction.Zero, new Fraction(-4, 5)).Returns(1);
            yield return new TestCaseData(Fraction.Zero, Fraction.NegativeInfinity).Returns(1);
            yield return new TestCaseData(Fraction.Zero, new Fraction(-5, 0, false)).Returns(1);
            // positive infinity with positive infinity
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.PositiveInfinity).Returns(0);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(5, 0, false)).Returns(0);
            // positive infinity with any other number
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(5, 4)).Returns(1);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.One).Returns(1);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(4, 5)).Returns(1);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.Zero).Returns(1);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.MinusOne).Returns(1);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(-5, 4)).Returns(1);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(-4, 5)).Returns(1);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NegativeInfinity).Returns(1);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(-5, 0, false)).Returns(1);
            // negative infinity with negative infinity
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NegativeInfinity).Returns(0);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-5, 0, false)).Returns(0);
            // negative infinity with any other number
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.PositiveInfinity).Returns(-1);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(5, 0, false)).Returns(-1);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(5, 4)).Returns(-1);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.One).Returns(-1);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(4, 5)).Returns(-1);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.Zero).Returns(-1);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.MinusOne).Returns(-1);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-5, 4)).Returns(-1);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-4, 5)).Returns(-1);
            // NaN with NaN
            yield return new TestCaseData(Fraction.NaN, Fraction.NaN).Returns(0);
            // NaN with any number
            yield return new TestCaseData(Fraction.NaN, Fraction.PositiveInfinity).Returns(-1);
            yield return new TestCaseData(Fraction.NaN, new Fraction(5, 4)).Returns(-1);
            yield return new TestCaseData(Fraction.NaN, Fraction.One).Returns(-1);
            yield return new TestCaseData(Fraction.NaN, new Fraction(4, 5)).Returns(-1);
            yield return new TestCaseData(Fraction.NaN, Fraction.Zero).Returns(-1);
            yield return new TestCaseData(Fraction.NaN, Fraction.MinusOne).Returns(-1);
            yield return new TestCaseData(Fraction.NaN, new Fraction(-5, 4)).Returns(-1);
            yield return new TestCaseData(Fraction.NaN, new Fraction(-4, 5)).Returns(-1);
            yield return new TestCaseData(Fraction.NaN, Fraction.NegativeInfinity).Returns(-1);
            // Any number with NaN
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NaN).Returns(1);
            yield return new TestCaseData(new Fraction(5, 4), Fraction.NaN).Returns(1);
            yield return new TestCaseData(Fraction.One, Fraction.NaN).Returns(1);
            yield return new TestCaseData(new Fraction(4, 5), Fraction.NaN).Returns(1);
            yield return new TestCaseData(Fraction.Zero, Fraction.NaN).Returns(1);
            yield return new TestCaseData(Fraction.MinusOne, Fraction.NaN).Returns(1);
            yield return new TestCaseData(new Fraction(-5, 4), Fraction.NaN).Returns(1);
            yield return new TestCaseData(new Fraction(-4, 5), Fraction.NaN).Returns(1);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NaN).Returns(1);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public int The_CompareTo_method_should_return_the_expected_result(Fraction a, Fraction b) {
        return a.CompareTo(b);
    }
}
