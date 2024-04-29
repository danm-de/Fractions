using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Add;

[TestFixture]
public class When_the_user_adds_two_fractions : Spec {
    private static IEnumerable<TestCaseData> TestCases {
        get {
            // rational numbers
            yield return new TestCaseData(Fraction.Zero, Fraction.Zero)
                .Returns(Fraction.Zero);
            yield return new TestCaseData(new Fraction(1L, 5L), new Fraction(1L, 4L))
                .Returns(new Fraction(9L, 20L));
            yield return new TestCaseData(new Fraction(1L, 5L), Fraction.Zero)
                .Returns(new Fraction(1L, 5L));
            yield return new TestCaseData(Fraction.Zero, new Fraction(1L, 5L))
                .Returns(new Fraction(1L, 5L));
            yield return new TestCaseData(new Fraction(1, long.MaxValue), new Fraction(1, long.MaxValue - 1))
                .Returns(new Fraction(
                    BigInteger.Parse("18446744073709551613"),
                    BigInteger.Parse("85070591730234615838173535747377725442")
                ));

            // positive infinity
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.PositiveInfinity)
                .Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(5, 0, false))
                .Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.One)
                .Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.Zero)
                .Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.MinusOne)
                .Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NegativeInfinity)
                .Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(-5, 0, false))
                .Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NaN)
                .Returns(Fraction.NaN);

            // negative infinity
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NegativeInfinity)
                .Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-5, 0, false))
                .Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.One)
                .Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.Zero)
                .Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.MinusOne)
                .Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.PositiveInfinity)
                .Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(5, 0, false))
                .Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NaN)
                .Returns(Fraction.NaN);

            // NaN
            yield return new TestCaseData(Fraction.NaN, Fraction.NegativeInfinity)
                .Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.One)
                .Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.Zero)
                .Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.MinusOne)
                .Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.PositiveInfinity)
                .Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.NaN)
                .Returns(Fraction.NaN);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public Fraction It_should_return_the_expected_result(Fraction a, Fraction b) => a.Add(b);
}
