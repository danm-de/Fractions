using System.Collections.Generic;
using NUnit.Framework;

namespace Fractions.Tests.Comparers.FractionStrictEqualityComparerSpecs;

[TestFixture]
public class When_two_fractions_are_checked_for_equality_of_value {
    private readonly FractionComparer _sut = FractionComparer.StrictEquality;

    private static IEnumerable<TestCaseData> NonNullTestCases {
        get {
            // positive
            yield return new TestCaseData(Fraction.Zero, Fraction.Zero).Returns(true);
            yield return new TestCaseData(Fraction.One, Fraction.One).Returns(true);
            yield return new TestCaseData(Fraction.Two, Fraction.Two).Returns(true);
            yield return new TestCaseData(Fraction.MinusOne, Fraction.MinusOne).Returns(true);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.PositiveInfinity).Returns(true);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NegativeInfinity).Returns(true);
            yield return new TestCaseData(new Fraction(1, 2), new Fraction(1, 2)).Returns(true);
            yield return new TestCaseData(new Fraction(1, 2), new Fraction(1, 2, normalize: false)).Returns(true);
            yield return new TestCaseData(new Fraction(1, 2, normalize: false), new Fraction(1, 2)).Returns(true);
            yield return new TestCaseData(new Fraction(2, 4, normalize: false),
                new Fraction(2, 4, normalize: false)).Returns(true);
            yield return new TestCaseData(new Fraction(2, -4, normalize: false),
                new Fraction(2, -4, normalize: false)).Returns(true);

            // double.NaN.Equals(double.NaN) == true
            yield return new TestCaseData(Fraction.NaN, Fraction.NaN).Returns(true);

            // negative
            yield return new TestCaseData(new Fraction(2, -4, normalize: false),
                new Fraction(-2, 4, normalize: false)).Returns(false);
            yield return new TestCaseData(new Fraction(1, 2), new Fraction(2, 4, normalize: false)).Returns(false);
            yield return new TestCaseData(new Fraction(1, 2), new Fraction(-2, -4, normalize: false)).Returns(false);
            yield return new TestCaseData(new Fraction(-1, 2), new Fraction(-2, 4, normalize: false)).Returns(false);
            yield return new TestCaseData(Fraction.Zero, Fraction.One).Returns(false);
            yield return new TestCaseData(Fraction.One, Fraction.Zero).Returns(false);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NegativeInfinity).Returns(false);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.PositiveInfinity).Returns(false);
            yield return new TestCaseData(Fraction.Zero, Fraction.NaN).Returns(false);
            yield return new TestCaseData(Fraction.NaN, Fraction.Zero).Returns(false);
        }
    }

    [Test, TestCaseSource(nameof(NonNullTestCases))]
    public bool Should_the_value_equality_test_be_as_expected(Fraction a, Fraction b) =>
        _sut.Equals(a, b);

    [Test, TestCaseSource(nameof(NonNullTestCases))]
    public bool Should_the_comparision_of_the_HashCodes_be_as_expected(Fraction a, Fraction b) =>
        _sut.GetHashCode(a) == _sut.GetHashCode(b);

    [Test, TestCaseSource(nameof(NonNullTestCases))]
    public bool Should_the_comparision_of_the_HashCodes_for_the_object_data_type_be_as_expected(object a, object b) =>
        _sut.GetHashCode(a) == _sut.GetHashCode(b);

    private static IEnumerable<TestCaseData> TestCasesWithNull {
        get {
            foreach (var testCase in NonNullTestCases) {
                yield return testCase;
            }

            yield return new TestCaseData(null, null).Returns(true);

            yield return new TestCaseData(Fraction.One, null).Returns(false);
            yield return new TestCaseData(null, Fraction.One).Returns(false);

            yield return new TestCaseData(Fraction.Zero, null).Returns(false);
            yield return new TestCaseData(null, Fraction.Zero).Returns(false);
        }
    }

    [Test, TestCaseSource(nameof(TestCasesWithNull))]
    public bool Should_the_value_equality_test_of_type_object_be_as_expected(object a, object b) =>
        _sut.Equals(a, b);
}

[TestFixture]
public class When_the_hash_codes_of_two_fractions_are_checked {
    private readonly FractionComparer _sut = FractionComparer.StrictEquality;

    private static IEnumerable<TestCaseData> TestCases {
        get {
            // positive
            yield return new TestCaseData(Fraction.Zero, Fraction.Zero).Returns(true);
            yield return new TestCaseData(Fraction.One, Fraction.One).Returns(true);
            yield return new TestCaseData(Fraction.Two, Fraction.Two).Returns(true);
            yield return new TestCaseData(Fraction.MinusOne, Fraction.MinusOne).Returns(true);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.PositiveInfinity).Returns(true);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NegativeInfinity).Returns(true);
            yield return new TestCaseData(new Fraction(1, 2), new Fraction(1, 2)).Returns(true);
            yield return new TestCaseData(new Fraction(2, 4, normalize: false),
                new Fraction(2, 4, normalize: false)).Returns(true);
            yield return new TestCaseData(new Fraction(2, -4, normalize: false),
                new Fraction(2, -4, normalize: false)).Returns(true);
            yield return new TestCaseData(Fraction.NaN, Fraction.NaN).Returns(true);

            // negative
            yield return new TestCaseData(new Fraction(2, -4, normalize: false),
                new Fraction(-2, 4, normalize: false)).Returns(false);
            yield return new TestCaseData(new Fraction(1, 2), new Fraction(2, 4, normalize: false)).Returns(false);
            yield return new TestCaseData(new Fraction(1, 2), new Fraction(-2, -4, normalize: false)).Returns(false);
            yield return new TestCaseData(new Fraction(-1, 2), new Fraction(-2, 4, normalize: false)).Returns(false);
            yield return new TestCaseData(new Fraction(5), new Fraction(6)).Returns(false);
            yield return new TestCaseData(new Fraction(100), new Fraction(10)).Returns(false);
            yield return new TestCaseData(new Fraction(int.MaxValue), new Fraction(int.MinValue + 1)).Returns(false);
            yield return new TestCaseData(new Fraction(double.MaxValue),
                new Fraction(double.MinValue + double.Epsilon)).Returns(false);

            yield return new TestCaseData(Fraction.Zero, Fraction.One).Returns(false);
            yield return new TestCaseData(Fraction.One, Fraction.Zero).Returns(false);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NegativeInfinity).Returns(false);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.PositiveInfinity).Returns(false);
        }
    }

    [Test, TestCaseSource(nameof(TestCases))]
    public bool Should_the_number_distribution_be_as_expected(Fraction a, Fraction b) =>
        _sut.GetHashCode(a) == _sut.GetHashCode(b);
}
