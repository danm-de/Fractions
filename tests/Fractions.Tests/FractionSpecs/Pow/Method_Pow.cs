using System.Collections;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Pow;

[TestFixture]
// German: Wenn an einem Bruch die Potenz angewendet wird
public class When_exponentiation_is_applied_to_a_fraction : Spec {
    private static IEnumerable TestCases {
        get {
            // positive infinity
            yield return new TestCaseData(Fraction.PositiveInfinity, 0).Returns(Fraction.One);
            yield return new TestCaseData(Fraction.PositiveInfinity, 1).Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, -1).Returns(Fraction.Zero);
            yield return new TestCaseData(Fraction.PositiveInfinity, 2).Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, -2).Returns(Fraction.Zero);
            yield return new TestCaseData(new Fraction(10, 0, false), 0).Returns(Fraction.One);
            yield return new TestCaseData(new Fraction(10, 0, false), 1).Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(new Fraction(10, 0, false), -1).Returns(Fraction.Zero);
            yield return new TestCaseData(new Fraction(10, 0, false), 2).Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(new Fraction(10, 0, false), -2).Returns(Fraction.Zero);
            // positive numbers
            yield return new TestCaseData(new Fraction(1, 3), 2)
                .Returns(new Fraction(1, 9));
            yield return new TestCaseData(new Fraction(3), -1)
                .Returns(new Fraction(1, 3));
            yield return new TestCaseData(new Fraction(3), 0)
                .Returns(new Fraction(1));
            yield return new TestCaseData(new Fraction(3), 2)
                .Returns(new Fraction(9));
            yield return new TestCaseData(new Fraction(3), 3)
                .Returns(new Fraction(27));
            yield return new TestCaseData(new Fraction(3), -2)
                .Returns(new Fraction(1, 9));
            yield return new TestCaseData(new Fraction(3, 3, false), 2)
                .Returns(new Fraction(9, 9, true));
            yield return new TestCaseData(new Fraction(3, 3, false), -2)
                .Returns(new Fraction(9, 9, true));
            // zero
            yield return new TestCaseData(Fraction.Zero, 0)
                .Returns(Fraction.One);
            yield return new TestCaseData(Fraction.Zero, 1)
                .Returns(Fraction.Zero);
            yield return new TestCaseData(Fraction.Zero, -1)
                .Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.Zero, 2)
                .Returns(Fraction.Zero);
            yield return new TestCaseData(new Fraction(0, 10, false), 0)
                .Returns(Fraction.One);
            yield return new TestCaseData(new Fraction(0, -10, false), 0)
                .Returns(Fraction.One);
            yield return new TestCaseData(new Fraction(0, 10, false), 1)
                .Returns(Fraction.Zero);
            yield return new TestCaseData(new Fraction(0, -10, false), -1)
                .Returns(Fraction.PositiveInfinity); // TODO?
            yield return new TestCaseData(new Fraction(0, 10, false), 2)
                .Returns(Fraction.Zero);
            yield return new TestCaseData(new Fraction(0, -10, false), -2)
                .Returns(Fraction.PositiveInfinity);
            // negative numbers
            yield return new TestCaseData(new Fraction(-1, 3), 2)
                .Returns(new Fraction(1, 9));
            yield return new TestCaseData(new Fraction(-3), -1)
                .Returns(new Fraction(-1, 3));
            yield return new TestCaseData(new Fraction(-3), 0)
                .Returns(new Fraction(1));
            yield return new TestCaseData(new Fraction(-3), 2)
                .Returns(new Fraction(9));
            yield return new TestCaseData(new Fraction(-3), 3)
                .Returns(new Fraction(-27));
            yield return new TestCaseData(new Fraction(-3), -2)
                .Returns(new Fraction(1, 9));
            yield return new TestCaseData(new Fraction(3, -3, false), 2)
                .Returns(new Fraction(9, 9, true));
            yield return new TestCaseData(new Fraction(3, -3, false), -2)
                .Returns(new Fraction(9, 9, true));
            // negative infinity
            yield return new TestCaseData(Fraction.NegativeInfinity, 0).Returns(Fraction.One);
            yield return new TestCaseData(Fraction.NegativeInfinity, 1).Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, -1).Returns(Fraction.Zero);
            yield return new TestCaseData(Fraction.NegativeInfinity, 2).Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, -2).Returns(Fraction.Zero);
            yield return new TestCaseData(new Fraction(-10, 0, false), 0).Returns(Fraction.One);
            yield return new TestCaseData(new Fraction(-10, 0, false), 1).Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(new Fraction(-10, 0, false), -1).Returns(Fraction.Zero);
            yield return new TestCaseData(new Fraction(-10, 0, false), 2).Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(new Fraction(-10, 0, false), -2).Returns(Fraction.Zero);
            yield return new TestCaseData(new Fraction(-10, 0, false), 3).Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(new Fraction(-10, 0, false), -3).Returns(Fraction.Zero);
            // NaN
            yield return new TestCaseData(Fraction.NaN, 0).Returns(Fraction.One);
            yield return new TestCaseData(Fraction.NaN, 1).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, -1).Returns(Fraction.NaN);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    // German: Das Ergebnis sollte korrekt sein
    public Fraction The_result_should_be_correct(Fraction fraction, int power) {
        return Fraction.Pow(fraction, power);
    }
}
