using System.Collections.Generic;
using NUnit.Framework;

namespace Fractions.Tests.FractionSpecs.Operators;

[TestFixture]
public class If_the_user_compares_two_fractions_and_one_of_them_is_NaN {

    #region GreaterOrEqual
    private static IEnumerable<TestCaseData> GreaterOrEqualTestCases {
        get {
            yield return new TestCaseData(Fraction.NaN, Fraction.NaN).Returns(false);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NaN).Returns(false);
            yield return new TestCaseData(Fraction.NaN, Fraction.NegativeInfinity).Returns(false);
        }
    }

    [Test, TestCaseSource(nameof(GreaterOrEqualTestCases))]
    public bool Should_the_greater_or_equal_comparison_return_the_expected_result_DOUBLE(Fraction a, Fraction b) =>
        (double)a >= (double)b;

    [Test, TestCaseSource(nameof(GreaterOrEqualTestCases))]
    public bool Should_the_greater_or_equal_comparison_return_the_expected_result(Fraction a, Fraction b) =>
        a >= b;
    #endregion

    #region Greater
    private static IEnumerable<TestCaseData> GreaterTestCases {
        get {
            yield return new TestCaseData(Fraction.NaN, Fraction.NaN).Returns(false);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NaN).Returns(false);
            yield return new TestCaseData(Fraction.NaN, Fraction.NegativeInfinity).Returns(false);
        }
    }

    [Test, TestCaseSource(nameof(GreaterTestCases))]
    public bool Should_the_greater_comparison_return_the_expected_result_DOUBLE(Fraction a, Fraction b) =>
        (double)a > (double)b;

    [Test, TestCaseSource(nameof(GreaterTestCases))]
    public bool Should_the_greater_comparison_return_the_expected_result(Fraction a, Fraction b) =>
        a > b;
    #endregion

    #region LowerOrEqual
    private static IEnumerable<TestCaseData> LowerOrEqualTestCases {
        get {
            yield return new TestCaseData(Fraction.NaN, Fraction.NaN).Returns(false);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NaN).Returns(false);
            yield return new TestCaseData(Fraction.NaN, Fraction.NegativeInfinity).Returns(false);
        }
    }

    [Test, TestCaseSource(nameof(LowerOrEqualTestCases))]
    public bool Should_the_lower_or_equal_comparison_return_the_expected_result_DOUBLE(Fraction a, Fraction b) =>
        (double)a <= (double)b;

    [Test, TestCaseSource(nameof(LowerOrEqualTestCases))]
    public bool Should_the_lower_or_equal_comparison_return_the_expected_result(Fraction a, Fraction b) =>
        a <= b;
    #endregion

    #region Lower
    private static IEnumerable<TestCaseData> LowerTestCases {
        get {
            yield return new TestCaseData(Fraction.NaN, Fraction.NaN).Returns(false);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NaN).Returns(false);
            yield return new TestCaseData(Fraction.NaN, Fraction.NegativeInfinity).Returns(false);
        }
    }

    [Test, TestCaseSource(nameof(LowerTestCases))]
    public bool Should_the_lower_comparison_return_the_expected_result_DOUBLE(Fraction a, Fraction b) =>
        (double)a < (double)b;

    [Test, TestCaseSource(nameof(LowerTestCases))]
    public bool Should_the_lower_comparison_return_the_expected_result(Fraction a, Fraction b) =>
        a < b;
    #endregion
}
