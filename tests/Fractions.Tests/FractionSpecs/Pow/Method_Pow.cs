using System.Collections;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Pow;

[TestFixture]
public class When_exponentiation_is_applied_to_a_fraction : Spec {
    private static IEnumerable TestCases {
        get {
            // positive infinity
            yield return new TestCaseData(Fraction.PositiveInfinity, 0, Fraction.One);
            yield return new TestCaseData(Fraction.PositiveInfinity, 1, Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, -1, Fraction.Zero);
            yield return new TestCaseData(Fraction.PositiveInfinity, 2, Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, -2, Fraction.Zero);
            yield return new TestCaseData(new Fraction(10, 0, false), 0, Fraction.One);
            yield return new TestCaseData(new Fraction(10, 0, false), 1, Fraction.PositiveInfinity);
            yield return new TestCaseData(new Fraction(10, 0, false), -1, Fraction.Zero);
            yield return new TestCaseData(new Fraction(10, 0, false), 2, Fraction.PositiveInfinity);
            yield return new TestCaseData(new Fraction(10, 0, false), -2, Fraction.Zero);
            // positive numbers
            yield return new TestCaseData(new Fraction(1, 3), 2, new Fraction(1, 9));
            yield return new TestCaseData(new Fraction(3), -1, new Fraction(1, 3));
            yield return new TestCaseData(new Fraction(3), 0, new Fraction(1));
            yield return new TestCaseData(new Fraction(3), 2, new Fraction(9));
            yield return new TestCaseData(new Fraction(3), 3, new Fraction(27));
            yield return new TestCaseData(new Fraction(3), -2, new Fraction(1, 9));
            yield return new TestCaseData(new Fraction(3, 3, false), 2, new Fraction(9, 9, true));
            yield return new TestCaseData(new Fraction(3, 3, false), -2, new Fraction(9, 9, true));
            yield return new TestCaseData(Fraction.FromDecimal(1.0000m, false), 2, Fraction.FromDecimal(1m));
            yield return new TestCaseData(Fraction.FromDecimal(0.1000m, false), 2, Fraction.FromDecimal(0.01m));
            yield return new TestCaseData(Fraction.FromDecimal(1.0000m, false), -2, Fraction.FromDecimal(1m));
            yield return new TestCaseData(Fraction.FromDecimal(0.1000m, false), -2, Fraction.FromDecimal(100m));
            // zero
            yield return new TestCaseData(Fraction.Zero, 0, Fraction.One);
            yield return new TestCaseData(Fraction.Zero, 1, Fraction.Zero);
            yield return new TestCaseData(Fraction.Zero, -1, Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.Zero, 2, Fraction.Zero);
            yield return new TestCaseData(new Fraction(0, 10, false), 0, Fraction.One);
            yield return new TestCaseData(new Fraction(0, -10, false), 0, Fraction.One);
            yield return new TestCaseData(new Fraction(0, 10, false), 1, Fraction.Zero);
            yield return new TestCaseData(new Fraction(0, -10, false), -1, Fraction.PositiveInfinity); // TODO?
            yield return new TestCaseData(new Fraction(0, 10, false), 2, Fraction.Zero);
            yield return new TestCaseData(new Fraction(0, -10, false), -2, Fraction.PositiveInfinity);
            // negative numbers
            yield return new TestCaseData(new Fraction(-1, 3), 2, new Fraction(1, 9));
            yield return new TestCaseData(new Fraction(-3), -1, new Fraction(-1, 3));
            yield return new TestCaseData(new Fraction(-3), 0, new Fraction(1));
            yield return new TestCaseData(new Fraction(-3), 2, new Fraction(9));
            yield return new TestCaseData(new Fraction(-3), 3, new Fraction(-27));
            yield return new TestCaseData(new Fraction(-3), -2, new Fraction(1, 9));
            yield return new TestCaseData(new Fraction(3, -3, false), 2, new Fraction(9, 9, true));
            yield return new TestCaseData(new Fraction(3, -3, false), -2, new Fraction(9, 9, true));
            // negative infinity
            yield return new TestCaseData(Fraction.NegativeInfinity, 0, Fraction.One);
            yield return new TestCaseData(Fraction.NegativeInfinity, 1, Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, -1, Fraction.Zero);
            yield return new TestCaseData(Fraction.NegativeInfinity, 2, Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, -2, Fraction.Zero);
            yield return new TestCaseData(new Fraction(-10, 0, false), 0, Fraction.One);
            yield return new TestCaseData(new Fraction(-10, 0, false), 1, Fraction.NegativeInfinity);
            yield return new TestCaseData(new Fraction(-10, 0, false), -1, Fraction.Zero);
            yield return new TestCaseData(new Fraction(-10, 0, false), 2, Fraction.PositiveInfinity);
            yield return new TestCaseData(new Fraction(-10, 0, false), -2, Fraction.Zero);
            yield return new TestCaseData(new Fraction(-10, 0, false), 3, Fraction.NegativeInfinity);
            yield return new TestCaseData(new Fraction(-10, 0, false), -3, Fraction.Zero);
            // NaN
            yield return new TestCaseData(Fraction.NaN, 0, Fraction.One);
            yield return new TestCaseData(Fraction.NaN, 1, Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, -1, Fraction.NaN);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void The_result_should_be_correct(Fraction fraction, int power, Fraction expected) {
        var result = Fraction.Pow(fraction, power);
        Assert.That(result, Is.EqualTo(expected).Using(StrictTestComparer.Instance));
    }
}
