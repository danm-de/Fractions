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
            yield return new TestCaseData(Fraction.Zero, Fraction.Zero, Fraction.Zero);
            yield return new TestCaseData(new Fraction(1L, 5L), new Fraction(1L, 4L), new Fraction(9L, 20L));
            yield return new TestCaseData(new Fraction(1L, 5L), Fraction.Zero, new Fraction(1L, 5L));
            yield return new TestCaseData(Fraction.Zero, new Fraction(1L, 5L), new Fraction(1L, 5L));
            yield return new TestCaseData(new Fraction(1, long.MaxValue), new Fraction(1, long.MaxValue - 1),
                new Fraction(
                    BigInteger.Parse("18446744073709551613"),
                    BigInteger.Parse("85070591730234615838173535747377725442")
                ));

            // positive infinity
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.PositiveInfinity,
                Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(5, 0, false),
                Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.One, Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.Zero, Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.MinusOne, Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NegativeInfinity, Fraction.NaN);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(-5, 0, false), Fraction.NaN);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NaN, Fraction.NaN);

            // negative infinity
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NegativeInfinity,
                Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-5, 0, false),
                Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.One, Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.Zero, Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.MinusOne, Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.PositiveInfinity, Fraction.NaN);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(5, 0, false), Fraction.NaN);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NaN, Fraction.NaN);

            // NaN
            yield return new TestCaseData(Fraction.NaN, Fraction.NegativeInfinity, Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.One, Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.Zero, Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.MinusOne, Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.PositiveInfinity, Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.NaN, Fraction.NaN);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void It_should_return_the_expected_result(Fraction a, Fraction b, Fraction expected) {
        var result = a.Add(b);
        Assert.That(result, Is.EqualTo(expected).Using(StrictTestComparer.Instance));
    }
}
