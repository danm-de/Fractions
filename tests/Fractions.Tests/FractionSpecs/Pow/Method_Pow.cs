using System.Collections;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Pow;

[TestFixture]
// German: Wenn an einem Bruch die Potenz angewendet wird
public class When_exponentiation_is_applied_to_a_fraction : Spec {
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

    [Test]
    [TestCaseSource(nameof(TestCases))]
    // German: Das Ergebnis sollte korrekt sein
    public Fraction The_result_should_be_correct(Fraction fraction, int power) {
        return Fraction.Pow(fraction, power);
    }
}
