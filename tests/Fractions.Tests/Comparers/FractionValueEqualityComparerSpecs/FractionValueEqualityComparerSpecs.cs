using System.Collections.Generic;
using NUnit.Framework;

namespace Fractions.Tests.Comparers.FractionValueEqualityComparerSpecs;

[TestFixture]
public class When_two_fractions_are_checked_for_equality_of_value {
    private readonly FractionComparer _sut = FractionComparer.ValueEquality;

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
            yield return new TestCaseData(new Fraction(2, 4, normalize: false),
                new Fraction(2, 4, normalize: false)).Returns(true);
            yield return new TestCaseData(new Fraction(2, -4, normalize: false),
                new Fraction(2, -4, normalize: false)).Returns(true);
            yield return new TestCaseData(new Fraction(2, -4, normalize: false),
                new Fraction(-2, 4, normalize: false)).Returns(true);
            yield return new TestCaseData(new Fraction(1, 2), new Fraction(2, 4, normalize: false)).Returns(true);
            yield return new TestCaseData(new Fraction(1, 2), new Fraction(-2, -4, normalize: false)).Returns(true);
            yield return new TestCaseData(new Fraction(-1, 2), new Fraction(-2, 4, normalize: false)).Returns(true);

            // double.NaN.Equals(double.NaN) == true
            yield return new TestCaseData(Fraction.NaN, Fraction.NaN).Returns(true);

            // negative
            yield return new TestCaseData(Fraction.Zero, Fraction.One).Returns(false);
            yield return new TestCaseData(Fraction.One, Fraction.Zero).Returns(false);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NegativeInfinity).Returns(false);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.PositiveInfinity).Returns(false);
            yield return new TestCaseData(Fraction.Zero, Fraction.NaN).Returns(false);
            yield return new TestCaseData(Fraction.NaN, Fraction.Zero).Returns(false);

            // Any number with NaN
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NaN).Returns(false);
            yield return new TestCaseData(new Fraction(5, 4), Fraction.NaN).Returns(false);
            yield return new TestCaseData(Fraction.One, Fraction.NaN).Returns(false);
            yield return new TestCaseData(new Fraction(4, 5), Fraction.NaN).Returns(false);
            yield return new TestCaseData(Fraction.Zero, Fraction.NaN).Returns(false);
            yield return new TestCaseData(Fraction.MinusOne, Fraction.NaN).Returns(false);
            yield return new TestCaseData(new Fraction(-5, 4), Fraction.NaN).Returns(false);
            yield return new TestCaseData(new Fraction(-4, 5), Fraction.NaN).Returns(false);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NaN).Returns(false);
            // Any number with PositiveInfinity
            yield return new TestCaseData(Fraction.One, Fraction.PositiveInfinity).Returns(false);
            yield return new TestCaseData(Fraction.MinusOne, Fraction.PositiveInfinity).Returns(false);
            yield return new TestCaseData(new Fraction(42, 66, false), Fraction.PositiveInfinity).Returns(false);
            yield return new TestCaseData(new Fraction(-42, 66, false), Fraction.PositiveInfinity).Returns(false);
            yield return new TestCaseData(new Fraction(42, -66, false), Fraction.PositiveInfinity).Returns(false);
            yield return new TestCaseData(new Fraction(-42, -66, false), Fraction.PositiveInfinity).Returns(false);
            // Any number with NegativeInfinity
            yield return new TestCaseData(Fraction.One, Fraction.NegativeInfinity).Returns(false);
            yield return new TestCaseData(Fraction.MinusOne, Fraction.NegativeInfinity).Returns(false);
            yield return new TestCaseData(new Fraction(42, 66, false), Fraction.NegativeInfinity).Returns(false);
            yield return new TestCaseData(new Fraction(-42, 66, false), Fraction.NegativeInfinity).Returns(false);
            yield return new TestCaseData(new Fraction(42, -66, false), Fraction.NegativeInfinity).Returns(false);
            yield return new TestCaseData(new Fraction(-42, -66, false), Fraction.NegativeInfinity).Returns(false);
        }
    }

    [Test, TestCaseSource(nameof(NonNullTestCases))]
    public bool Should_the_value_equality_test_be_as_expected(Fraction a, Fraction b) =>
        _sut.Equals(a, b);

    private static IEnumerable<TestCaseData> DifferentSignsTestCases {
        get {
            #region {positive/positive} and {positive/negative}

            // {1/1} != {1/-10}
            yield return new TestCaseData(new Fraction(1, 1, false), new Fraction(1, -10, false)).Returns(false);
            // {1/10} != {1/-1}
            yield return new TestCaseData(new Fraction(1, 10, false), new Fraction(1, -1, false)).Returns(false);

            #endregion

            #region {positive/positive} and {negative/positive}

            // {1/1} != {-1/10}
            yield return new TestCaseData(new Fraction(1, 1, false), new Fraction(-1, 10, false)).Returns(false);
            // {1/10} != {-1/1}
            yield return new TestCaseData(new Fraction(1, 10, false), new Fraction(-1, 1, false)).Returns(false);

            #endregion

            #region {positive/negative} and {positive/positive}

            // {1/-1} != {1/10}
            yield return new TestCaseData(new Fraction(1, -1, false), new Fraction(1, 10, false)).Returns(false);
            // {1/-10} != {1/1}
            yield return new TestCaseData(new Fraction(1, -10, false), new Fraction(1, 1, false)).Returns(false);

            #endregion

            #region {negative/positive} and {positive/positive}

            // {-1/1} != {1/10}
            yield return new TestCaseData(new Fraction(-1, 1, false), new Fraction(1, 10, false)).Returns(false);
            // {-1/10} != {1/1}
            yield return new TestCaseData(new Fraction(-1, 10, false), new Fraction(1, 1, false)).Returns(false);

            #endregion

            #region {negative/negative} and {negative/positive}

            // {-1/-1} != {-1/10}
            yield return new TestCaseData(new Fraction(-1, -1, false), new Fraction(-1, 10, false)).Returns(false);
            // {-1/-10} != {-1/1}
            yield return new TestCaseData(new Fraction(-1, -10, false), new Fraction(-1, 1, false)).Returns(false);

            #endregion

            #region {negative/negative} and {positive/negative}

            // {-1/-1} != {1/-10}
            yield return new TestCaseData(new Fraction(-1, -1, false), new Fraction(1, -10, false)).Returns(false);
            // {-1/-10} != {1/-1}
            yield return new TestCaseData(new Fraction(-1, -10, false), new Fraction(1, -1, false)).Returns(false);

            #endregion

            #region {negative/positive} and {negative/negative}

            // {-1/1} != {-1/-10}
            yield return new TestCaseData(new Fraction(-1, 1, false), new Fraction(-1, -10, false)).Returns(false);
            // {-1/10} != {-1/-1}
            yield return new TestCaseData(new Fraction(-1, 10, false), new Fraction(-1, -1, false)).Returns(false);

            #endregion

            #region {positive/negative} and {negative/negative}

            // {1/-1} != {-1/-10}
            yield return new TestCaseData(new Fraction(1, -1, false), new Fraction(-1, -10, false)).Returns(false);
            // {1/-10} != {-1/-1}
            yield return new TestCaseData(new Fraction(1, -10, false), new Fraction(-1, -1, false)).Returns(false);

            #endregion
        }
    }

    [Test, TestCaseSource(nameof(DifferentSignsTestCases))]
    public bool Fractions_with_different_signs_should_not_be_equal(Fraction a, Fraction b) =>
        _sut.Equals(a, b);

    private static IEnumerable<TestCaseData> DifferentFractionsTestCases {
        get {
            #region {positive/positive} and {positive/positive}

            // {1/2} < {2/2}
            yield return new TestCaseData(new Fraction(1, 2, false), new Fraction(2, 2, false)).Returns(false);
            // {11/10} > {1/1}
            yield return new TestCaseData(new Fraction(11, 10, false), new Fraction(1, 1, false)).Returns(false);
            // {10/10} > {1/2}
            yield return new TestCaseData(new Fraction(10, 10, false), new Fraction(1, 2, false)).Returns(false);
            // {10/10} < {2/1}
            yield return new TestCaseData(new Fraction(10, 10, false), new Fraction(2, 1, false)).Returns(false);
            // {1/10} < {1/1}
            yield return new TestCaseData(new Fraction(1, 10, false), new Fraction(1, 1, false)).Returns(false);
            // {10/100} < {2/10}
            yield return new TestCaseData(new Fraction(10, 100, false), new Fraction(2, 10, false)).Returns(false);
            // {7/4} > {3/2}
            yield return new TestCaseData(new Fraction(7, 4, false), new Fraction(3, 2, false)).Returns(false);
            // {6/5} < {3/2}
            yield return new TestCaseData(new Fraction(6, 5, false), new Fraction(3, 2, false)).Returns(false);

            #endregion

            #region {negative/negative} and {negative/negative}

            // {-1/-2} < {-2/-2}
            yield return new TestCaseData(new Fraction(-1, -2, false), new Fraction(-2, -2, false)).Returns(false);
            // {-1/-2} < {-10/-10}
            yield return new TestCaseData(new Fraction(-1, -2, false), new Fraction(-10, -10, false)).Returns(false);
            // {-1/-1} < {-11/-10}
            yield return new TestCaseData(new Fraction(-1, -1, false), new Fraction(-11, -10, false)).Returns(false);
            // {-10/-10} < {-2/-1}
            yield return new TestCaseData(new Fraction(-10, -10, false), new Fraction(-2, -1, false)).Returns(false);
            // {-1/-10} < {-1/-1}
            yield return new TestCaseData(new Fraction(-1, -10, false), new Fraction(-1, -1, false)).Returns(false);
            // {-10/-100} < {-2/-10}
            yield return new TestCaseData(new Fraction(-10, -100, false), new Fraction(-2, -10, false)).Returns(false);
            // {-7/-4} > {-3/-2}
            yield return new TestCaseData(new Fraction(-7, -4, false), new Fraction(-3, -2, false)).Returns(false);
            // {-6/-5} < {-3/-2}
            yield return new TestCaseData(new Fraction(-6, -5, false), new Fraction(-3, -2, false)).Returns(false);

            #endregion

            #region {positive/positive} and {negative/negative}

            // {1/2} < {-2/-2}
            yield return new TestCaseData(new Fraction(1, 2, false), new Fraction(-2, -2, false)).Returns(false);
            // {1/10} < {-11/-100}
            yield return new TestCaseData(new Fraction(1, 10, false), new Fraction(-11, -100, false)).Returns(false);
            // {1/1} > {-2/-10}
            yield return new TestCaseData(new Fraction(1, 1, false), new Fraction(-2, -10, false)).Returns(false);
            // {1/1} > {-1/-2}
            yield return new TestCaseData(new Fraction(1, 1, false), new Fraction(-1, -2, false)).Returns(false);
            // {2/1} > {-1/-2}
            yield return new TestCaseData(new Fraction(2, 1, false), new Fraction(-1, -2, false)).Returns(false);
            // {10/10} < {-2/-1} 
            yield return new TestCaseData(new Fraction(10, 10, false), new Fraction(-2, -1, false)).Returns(false);
            // {1/10} < {-1/-1}
            yield return new TestCaseData(new Fraction(1, 10, false), new Fraction(-1, -1, false)).Returns(false);
            // {10/100} < {-2/-10}
            yield return new TestCaseData(new Fraction(10, 100, false), new Fraction(-2, -10, false)).Returns(false);
            // {7/4} > {-3/-2}
            yield return new TestCaseData(new Fraction(7, 4, false), new Fraction(-3, -2, false)).Returns(false);
            // {6/5} < {-3/-2}
            yield return new TestCaseData(new Fraction(6, 5, false), new Fraction(-3, -2, false)).Returns(false);

            #endregion

            #region {negative/negative} and {positive/positive}

            // {-1/-2} < {2/2}
            yield return new TestCaseData(new Fraction(-1, -2, false), new Fraction(2, 2, false)).Returns(false);
            // {-10/-10} < {2/1} 
            yield return new TestCaseData(new Fraction(-10, -10, false), new Fraction(2, 1, false)).Returns(false);
            // {-1/-10} < {1/1}
            yield return new TestCaseData(new Fraction(-1, -10, false), new Fraction(1, 1, false)).Returns(false);
            // {-10/-100} < {2/10}
            yield return new TestCaseData(new Fraction(-10, -100, false), new Fraction(2, 10, false)).Returns(false);
            // {-7/-4} > {3/2}
            yield return new TestCaseData(new Fraction(-7, -4, false), new Fraction(3, 2, false)).Returns(false);
            // {-6/-5} < {3/2}
            yield return new TestCaseData(new Fraction(-6, -5, false), new Fraction(3, 2, false)).Returns(false);

            #endregion

            #region {positive/negative} and {positive/negative}

            // {1/-2} > {2/-2}
            yield return new TestCaseData(new Fraction(1, -2, false), new Fraction(2, -2, false)).Returns(false);
            // {1/-10} > {11/-100}
            yield return new TestCaseData(new Fraction(1, -10, false), new Fraction(11, -100, false)).Returns(false);
            // {10/-10} > {2/-1} 
            yield return new TestCaseData(new Fraction(10, -10, false), new Fraction(2, -1, false)).Returns(false);
            // {1/-10} > {1/-1}
            yield return new TestCaseData(new Fraction(1, -10, false), new Fraction(1, -1, false)).Returns(false);
            // {10/-100} > {2/-10}
            yield return new TestCaseData(new Fraction(10, -100, false), new Fraction(2, -10, false)).Returns(false);
            // {7/-4} < {3/-2}
            yield return new TestCaseData(new Fraction(7, -4, false), new Fraction(3, -2, false)).Returns(false);
            // {6/-5} > {3/-2}
            yield return new TestCaseData(new Fraction(6, -5, false), new Fraction(3, -2, false)).Returns(false);

            #endregion

            #region {positive/negative} and {negative/positive}

            // {1/-2} > {-2/2}
            yield return new TestCaseData(new Fraction(1, -2, false), new Fraction(-2, 2, false)).Returns(false);
            // {10/-10} > {-2/1} 
            yield return new TestCaseData(new Fraction(10, -10, false), new Fraction(-2, 1, false)).Returns(false);
            // {1/-10} > {-1/1}
            yield return new TestCaseData(new Fraction(1, -10, false), new Fraction(-1, 1, false)).Returns(false);
            // {10/-100} > {-2/10}
            yield return new TestCaseData(new Fraction(10, -100, false), new Fraction(-2, 10, false)).Returns(false);
            // {7/-4} > {-3/2}
            yield return new TestCaseData(new Fraction(7, -4, false), new Fraction(-3, 2, false)).Returns(false);
            // {6/-5} > {-3/2}
            yield return new TestCaseData(new Fraction(6, -5, false), new Fraction(-3, 2, false)).Returns(false);

            #endregion

            #region {negative/positive} and {positive/negative}

            // {-1/2} > {2/-2}
            yield return new TestCaseData(new Fraction(-1, 2, false), new Fraction(2, -2, false)).Returns(false);
            // {-1/1} > {2/-1} 
            yield return new TestCaseData(new Fraction(-1, 1, false), new Fraction(2, -1, false)).Returns(false);
            // {-1/2} > {2/-1} 
            yield return new TestCaseData(new Fraction(-1, 2, false), new Fraction(2, -1, false)).Returns(false);
            // {-2/1} > {3/-1} 
            yield return new TestCaseData(new Fraction(-2, 1, false), new Fraction(3, -1, false)).Returns(false);
            // {-11/10} < {1/-1} 
            yield return new TestCaseData(new Fraction(-11, 10, false), new Fraction(1, -1, false)).Returns(false);
            // {-10/10} > {2/-1} 
            yield return new TestCaseData(new Fraction(-10, 10, false), new Fraction(2, -1, false)).Returns(false);
            // {-1/10} > {1/-1}
            yield return new TestCaseData(new Fraction(-1, 10, false), new Fraction(1, -1, false)).Returns(false);
            // {-10/100} > {2/-10}
            yield return new TestCaseData(new Fraction(-10, 100, false), new Fraction(2, -10, false)).Returns(false);
            // {-7/4} > {3/-2}
            yield return new TestCaseData(new Fraction(-7, 4, false), new Fraction(3, -2, false)).Returns(false);
            // {-6/5} > {3/-2}
            yield return new TestCaseData(new Fraction(-6, 5, false), new Fraction(3, -2, false)).Returns(false);

            #endregion

            #region {negative/positive} and {negative/positive}

            // {-1/2} > {-2/2}
            yield return new TestCaseData(new Fraction(-1, 2, false), new Fraction(-2, 2, false)).Returns(false);
            // {-11/10} < {-1/1} 
            yield return new TestCaseData(new Fraction(-11, 10, false), new Fraction(-1, 1, false)).Returns(false);
            // {-10/10} < {-1/2} 
            yield return new TestCaseData(new Fraction(-10, 10, false), new Fraction(-1, 2, false)).Returns(false);
            // {-10/10} > {-2/1} 
            yield return new TestCaseData(new Fraction(-10, 10, false), new Fraction(-2, 1, false)).Returns(false);
            // {-1/10} > {-1/1}
            yield return new TestCaseData(new Fraction(-1, 10, false), new Fraction(-1, 1, false)).Returns(false);
            // {-10/100} > {-2/10}
            yield return new TestCaseData(new Fraction(-10, 100, false), new Fraction(-2, 10, false)).Returns(false);
            // {-7/4} > {-3/2}
            yield return new TestCaseData(new Fraction(-7, 4, false), new Fraction(-3, 2, false)).Returns(false);
            // {-6/5} > {-3/2}
            yield return new TestCaseData(new Fraction(-6, 5, false), new Fraction(-3, 2, false)).Returns(false);

            #endregion
        }
    }

    [Test, TestCaseSource(nameof(DifferentFractionsTestCases))]
    public bool Different_Fractions_with_same_signs_should_not_be_equal(Fraction a, Fraction b) => _sut.Equals(a, b);

    private static IEnumerable<TestCaseData> EquivalentFractionsTestCases {
        get {
            #region {positive/positive} and {positive/positive}

            // {10/10} == {1/1}
            yield return new TestCaseData(new Fraction(10, 10, false), new Fraction(1, 1, false)).Returns(true);
            // {10/100} == {1/10}
            yield return new TestCaseData(new Fraction(10, 100, false), new Fraction(1, 10, false)).Returns(true);

            #endregion

            #region {negative/negative} and {negative/negative}

            // {-10/-10} == {-1/-1}
            yield return new TestCaseData(new Fraction(-10, -10, false), new Fraction(-1, -1, false)).Returns(true);
            // {-10/-100} == {-1/-10}
            yield return new TestCaseData(new Fraction(-10, -100, false), new Fraction(-1, -10, false)).Returns(true);

            #endregion

            #region {positive/positive} and {negative/negative}

            // {10/10} == {-1/-1} 
            yield return new TestCaseData(new Fraction(10, 10, false), new Fraction(-1, -1, false)).Returns(true);
            // {1/10} == {-10/-100}
            yield return new TestCaseData(new Fraction(1, 10, false), new Fraction(-10, -100, false)).Returns(true);
            // {10/100} == {-1/-10}
            yield return new TestCaseData(new Fraction(10, 100, false), new Fraction(-1, -10, false)).Returns(true);

            #endregion

            #region {negative/negative} and {positive/positive}

            // {-10/-10} == {1/1} 
            yield return new TestCaseData(new Fraction(-10, -10, false), new Fraction(1, 1, false)).Returns(true);
            // {-1/-10} == {10/100}
            yield return new TestCaseData(new Fraction(-1, -10, false), new Fraction(10, 100, false)).Returns(true);

            #endregion

            #region {positive/negative} and {positive/negative}

            // {10/-10} == {1/-1} 
            yield return new TestCaseData(new Fraction(10, -10, false), new Fraction(1, -1, false)).Returns(true);
            // {1/-10} == {10/-100}
            yield return new TestCaseData(new Fraction(1, -10, false), new Fraction(10, -100, false)).Returns(true);

            #endregion

            #region {positive/negative} and {negative/positive}

            // {10/-10} == {-1/1} 
            yield return new TestCaseData(new Fraction(10, -10, false), new Fraction(-1, 1, false)).Returns(true);
            // {1/-10} == {-10/100}
            yield return new TestCaseData(new Fraction(1, -10, false), new Fraction(-10, 100, false)).Returns(true);

            #endregion

            #region {negative/positive} and {positive/negative}

            // {-10/10} == {1/-1} 
            yield return new TestCaseData(new Fraction(-10, 10, false), new Fraction(1, -1, false)).Returns(true);
            // {-1/10} and {10/-100}
            yield return new TestCaseData(new Fraction(-1, 10, false), new Fraction(10, -100, false)).Returns(true);
            // {-10/100} == {1/-10}
            yield return new TestCaseData(new Fraction(-10, 100, false), new Fraction(1, -10, false)).Returns(true);

            #endregion

            #region {negative/positive} and {negative/positive}

            // {-10/10} == {-1/1} 
            yield return new TestCaseData(new Fraction(-10, 10, false), new Fraction(-1, 1, false)).Returns(true);
            // {-10/100} == {-1/10}
            yield return new TestCaseData(new Fraction(-10, 100, false), new Fraction(-1, 10, false)).Returns(true);

            #endregion
        }
    }

    [Test, TestCaseSource(nameof(EquivalentFractionsTestCases))]
    public bool Equivalent_Fractions_should_be_equal(Fraction a, Fraction b) => _sut.Equals(a, b);

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
    private readonly FractionComparer _sut = FractionComparer.ValueEquality;

    private static IEnumerable<TestCaseData> TestCases {
        get {
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
            yield return new TestCaseData(new Fraction(2, -4, normalize: false),
                new Fraction(-2, 4, normalize: false)).Returns(true);
            yield return new TestCaseData(new Fraction(1, 2), new Fraction(2, 4, normalize: false)).Returns(true);
            yield return new TestCaseData(new Fraction(1, 2), new Fraction(-2, -4, normalize: false)).Returns(true);
            yield return new TestCaseData(new Fraction(-1, 2), new Fraction(-2, 4, normalize: false)).Returns(true);
            yield return new TestCaseData(Fraction.NaN, Fraction.NaN).Returns(true);

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
