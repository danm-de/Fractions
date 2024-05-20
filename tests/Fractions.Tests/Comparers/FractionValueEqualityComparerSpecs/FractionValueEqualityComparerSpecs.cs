using System.Collections.Generic;
using NUnit.Framework;

namespace Fractions.Tests.Comparers.FractionValueEqualityComparerSpecs;

[TestFixture]
public class When_two_fractions_are_checked_for_equality_of_value {
    private readonly FractionComparer _sut = FractionComparer.ValueEquality;

    private static IEnumerable<TestCaseData> FractionTypeTestCases {
        get {
            yield return new TestCaseData(Fraction.Zero, Fraction.Zero).Returns(true);
            yield return new TestCaseData(Fraction.One, Fraction.One).Returns(true);
            yield return new TestCaseData(Fraction.Two, Fraction.Two).Returns(true);
            yield return new TestCaseData(Fraction.MinusOne, Fraction.MinusOne).Returns(true);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.PositiveInfinity).Returns(true);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NegativeInfinity).Returns(true);
            yield return new TestCaseData(new Fraction(1, 2), new Fraction(1, 2)).Returns(true);
            yield return new TestCaseData(new Fraction(2, 4, normalize: false), new Fraction(2, 4, normalize: false)).Returns(true);
            yield return new TestCaseData(new Fraction(2, -4, normalize: false), new Fraction(2, -4, normalize: false)).Returns(true);
            yield return new TestCaseData(new Fraction(2, -4, normalize: false), new Fraction(-2, 4, normalize: false)).Returns(true);
            yield return new TestCaseData(new Fraction(1, 2), new Fraction(2, 4, normalize: false)).Returns(true);
            yield return new TestCaseData(new Fraction(1, 2), new Fraction(-2, -4, normalize: false)).Returns(true);
            yield return new TestCaseData(new Fraction(-1, 2), new Fraction(-2, 4, normalize: false)).Returns(true);

            yield return new TestCaseData(Fraction.Zero, Fraction.One).Returns(false);
            yield return new TestCaseData(Fraction.One, Fraction.Zero).Returns(false);
            yield return new TestCaseData(Fraction.NaN, Fraction.NaN).Returns(false);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NegativeInfinity).Returns(false);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.PositiveInfinity).Returns(false);

        }
    }

    [Test, TestCaseSource(nameof(FractionTypeTestCases))]
    public bool Should_the_value_equality_test_be_as_expected(Fraction a, Fraction b) =>
        _sut.Equals(a, b);

    [Test, TestCaseSource(nameof(FractionTypeTestCases))]
    public bool Should_the_comparision_of_the_HashCodes_be_as_expected(Fraction a, Fraction b) {
        if (a.IsNaN || b.IsNaN) {
            return false; // special case (NaN values are not considered equal)
        }

        return _sut.GetHashCode(a) == _sut.GetHashCode(b);
    }

    private static IEnumerable<TestCaseData> ObjectTypeTestCases {
        get {
            foreach (var testCase in FractionTypeTestCases) {
                yield return testCase;
            }

            yield return new TestCaseData(null, null).Returns(true);

            yield return new TestCaseData(Fraction.One, null).Returns(false);
            yield return new TestCaseData(null, Fraction.One).Returns(false);

            yield return new TestCaseData(Fraction.Zero, null).Returns(false);
            yield return new TestCaseData(null, Fraction.Zero).Returns(false);
        }
    }

    [Test, TestCaseSource(nameof(ObjectTypeTestCases))]
    public bool Should_the_value_equality_test_of_type_object_be_as_expected(object a, object b) =>
        _sut.Equals(a, b);

    [Test, TestCaseSource(nameof(FractionTypeTestCases))]
    public bool Should_the_comparision_of_the_HashCodes_for_the_object_data_type_be_as_expected(object a, object b) {
        if (a is Fraction f1 && b is Fraction f2 && (f1.IsNaN || f2.IsNaN)) {
            return false; // special case (NaN values are not considered equal)
        }

        // fake hash code if a or b is null.
        return _sut.GetHashCode(a) == _sut.GetHashCode(b);
    }
}

[TestFixture]
public class When_the_hash_codes_of_two_fractions_are_checked {
    private readonly FractionComparer _sut = FractionComparer.ValueEquality;

    private static IEnumerable<TestCaseData> TestCases {
        get {
            yield return new TestCaseData(Fraction.Zero, Fraction.Zero).Returns(0);
            yield return new TestCaseData(Fraction.One, Fraction.One).Returns(0);
            yield return new TestCaseData(Fraction.Two, Fraction.Two).Returns(0);
            yield return new TestCaseData(Fraction.MinusOne, Fraction.MinusOne).Returns(0);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.PositiveInfinity).Returns(0);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NegativeInfinity).Returns(0);
            yield return new TestCaseData(new Fraction(1, 2), new Fraction(1, 2)).Returns(0);
            yield return new TestCaseData(new Fraction(2, 4, normalize: false), new Fraction(2, 4, normalize: false)).Returns(0);
            yield return new TestCaseData(new Fraction(2, -4, normalize: false), new Fraction(2, -4, normalize: false)).Returns(0);
            yield return new TestCaseData(new Fraction(2, -4, normalize: false), new Fraction(-2, 4, normalize: false)).Returns(0);
            yield return new TestCaseData(new Fraction(1, 2), new Fraction(2, 4, normalize: false)).Returns(0);
            yield return new TestCaseData(new Fraction(1, 2), new Fraction(-2, -4, normalize: false)).Returns(0);
            yield return new TestCaseData(new Fraction(-1, 2), new Fraction(-2, 4, normalize: false)).Returns(0);
            yield return new TestCaseData(Fraction.NaN, Fraction.NaN).Returns(0);

            yield return new TestCaseData(new Fraction(5), new Fraction(6)).Returns(-1);
            yield return new TestCaseData(new Fraction(100), new Fraction(10)).Returns(1);
            yield return new TestCaseData(new Fraction(int.MaxValue), new Fraction(int.MinValue + 1)).Returns(1);
            yield return new TestCaseData(new Fraction(double.MaxValue), new Fraction(double.MinValue + double.Epsilon)).Returns(1);

            yield return new TestCaseData(Fraction.Zero, Fraction.One).Returns(1);
            yield return new TestCaseData(Fraction.One, Fraction.Zero).Returns(-1);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NegativeInfinity).Returns(1);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.PositiveInfinity).Returns(-1);
        }
    }

    [Test,TestCaseSource(nameof(TestCases))]
    public int Should_the_number_distribution_be_as_expected(Fraction a, Fraction b) =>
        _sut.GetHashCode(a).CompareTo(_sut.GetHashCode(b));
}
