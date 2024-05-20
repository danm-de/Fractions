using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.ValueEquals;

[TestFixture]
public class When_comparing_two_fractions {
    private static IEnumerable<TestCaseData> TestCases {
        get {
            // equal
            yield return new TestCaseData(Fraction.Zero, Fraction.Zero).Returns(true);
            yield return new TestCaseData(default(Fraction), Fraction.Zero)
                .SetName($"{nameof(Should_Equals_return_the_expected_result)}(default, Fraction.Zero)").Returns(true);
            yield return new TestCaseData(Fraction.Zero, default(Fraction))
                .SetName($"{nameof(Should_Equals_return_the_expected_result)}(Fraction.Zero, default)").Returns(true);
            yield return new TestCaseData(new Fraction(0), default(Fraction))
                .SetName($"{nameof(Should_Equals_return_the_expected_result)}(0, default)").Returns(true);
            yield return new TestCaseData(default(Fraction), new Fraction(0))
                .SetName($"{nameof(Should_Equals_return_the_expected_result)}(default, 1)").Returns(true);
            yield return new TestCaseData(Fraction.One, Fraction.One).Returns(true);
            yield return new TestCaseData(Fraction.MinusOne, Fraction.MinusOne).Returns(true);
            yield return new TestCaseData(Fraction.NaN, Fraction.NaN).Returns(true);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.PositiveInfinity).Returns(true);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NegativeInfinity).Returns(true);
            yield return new TestCaseData(new Fraction(0, 1, normalize: false), Fraction.Zero).Returns(true);

            // not equal
            yield return new TestCaseData(Fraction.One, Fraction.Zero).Returns(false);
            yield return new TestCaseData(Fraction.One, Fraction.NaN).Returns(false);
            // special -> not normalized fraction
            yield return new TestCaseData(new Fraction(0, 2, normalize: false), Fraction.Zero).Returns(false);
        }
    }

    [Test, TestCaseSource(nameof(TestCases))]
    public bool Should_Equals_return_the_expected_result(Fraction a, Fraction b) =>
        a.Equals(b);

    [Test, TestCaseSource(nameof(TestCases))]
    public bool Should_GetHashCode_return_the_expected_result(Fraction a, Fraction b) =>
        a.GetHashCode() == b.GetHashCode();
}

[TestFixture]
public class When_comparing_two_fractions_with_identical_numerator_and_denominator : Spec {
    private Fraction _fractionA;
    private Fraction _fractionB;

    public override void SetUp() {
        base.SetUp();
        _fractionA = new Fraction(5, 6, true);
        _fractionB = new Fraction(5, 6, true);
    }

    [Test]
    public void These_should_be_recognized_as_equal() {
        _fractionA.Equals(_fractionB)
            .Should().BeTrue();
    }
}

[TestFixture]
public class When_comparing_two_fractions_with_different_numerator_but_identical_denominator : Spec {
    private Fraction _fractionA;
    private Fraction _fractionB;

    public override void SetUp() {
        base.SetUp();
        _fractionA = new Fraction(4, 6, true);
        _fractionB = new Fraction(5, 6, true);
    }

    [Test]
    public void These_should_be_recognized_as_equal() {
        _fractionA.Equals(_fractionB)
            .Should().BeFalse();
    }
}

[TestFixture]
public class When_comparing_two_fractions_with_identical_numerator_but_different_denominator : Spec {
    private Fraction _fractionA;
    private Fraction _fractionB;

    public override void SetUp() {
        base.SetUp();
        _fractionA = new Fraction(4, 6, true);
        _fractionB = new Fraction(4, 7, true);
    }

    [Test]
    public void These_should_be_recognized_as_not_equivalent() {
        _fractionA.Equals(_fractionB)
            .Should().BeFalse();
    }
}

[TestFixture]
public class When_comparing_the_fraction_2_over_4_with_the_fraction_1_over_2 : Spec {
    private Fraction _fractionA;
    private Fraction _fractionB;

    public override void SetUp() {
        base.SetUp();
        _fractionA = new Fraction(2, 4, false);
        _fractionB = new Fraction(1, 2, true);
    }

    [Test]
    public void The_fractions_should_be_recognized_as_equal() {
        _fractionA.Equals(_fractionB)
            .Should().BeTrue();
    }
}

/// <summary>
///     See the section about comparing NaN
///     https://learn.microsoft.com/en-us/dotnet/api/system.double.nan?view=net-8.0#remarks
/// </summary>
/// <remarks>
/// <code>
///     NaN == NaN: False
///     NaN != NaN: True
///     NaN.Equals(NaN): True
/// </code>
/// </remarks>
[TestFixture]
public class When_comparing_NaN_with_NaN {
    [Test]
    [SuppressMessage("ReSharper", "EqualExpressionComparison")]
    public void Using_the_equality_operator_should_return_false() {
        (Fraction.NaN == Fraction.NaN).Should().BeFalse("Because this is the result of double.NaN == double.NaN");
    }

    [Test]
    [SuppressMessage("ReSharper", "EqualExpressionComparison")]
    public void Using_the_non_equality_operator_should_return_true() {
        (Fraction.NaN != Fraction.NaN).Should().BeTrue("Because this is the result of double.NaN != double.NaN");
    }

    [Test]
    public void Using_Equals_should_return_true() {
        Fraction.NaN.Equals(Fraction.NaN).Should().BeTrue("Because double.NaN.Equals(double.NaN) is true");
    }
}

[TestFixture]
public class When_comparing_NaN_with_another_Fraction() {
    private static readonly Fraction[] FractionsToTest = [
        Fraction.MinusOne, Fraction.Zero, Fraction.One,
        0.5m, -0.5m, 1.5m, -1.5m,
        new Fraction(0, 4, false), // zero
        new Fraction(0, -4, false), // zero
        new Fraction(4, 2, false),
        new Fraction(4, -2, false),
        Fraction.PositiveInfinity, Fraction.NegativeInfinity,
        new Fraction(4, 0, false), // +inf
        new Fraction(-4, 0, false), // -inf
    ];

    public static IEnumerable<TestCaseData> TestCases => FractionsToTest.Select(x => new TestCaseData(x));

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void Using_the_equality_operator_should_return_false(Fraction fraction) {
        (Fraction.NaN == fraction).Should().BeFalse();
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void Using_Equals_should_return_false(Fraction fraction) {
        Fraction.NaN.Equals(fraction).Should().BeFalse();
    }
}

[TestFixture]
public class When_comparing_PositiveInfinity_with_PositiveInfinity {
    [Test]
    [SuppressMessage("ReSharper", "EqualExpressionComparison")]
    public void Using_the_equality_operator_should_return_true() {
        (Fraction.PositiveInfinity == Fraction.PositiveInfinity).Should()
            .BeTrue("Because this is the result of double.PositiveInfinity == double.PositiveInfinity");
    }

    [Test]
    [SuppressMessage("ReSharper", "EqualExpressionComparison")]
    public void Using_the_non_equality_operator_should_return_false() {
        (Fraction.PositiveInfinity != Fraction.PositiveInfinity).Should()
            .BeFalse("Because this is the result of double.PositiveInfinity != double.PositiveInfinity");
    }

    [Test]
    public void Using_Equals_should_return_true() {
        Fraction.PositiveInfinity.Equals(Fraction.PositiveInfinity).Should()
            .BeTrue("Because double.PositiveInfinity.Equals(double.PositiveInfinity) is true");
    }
}

[TestFixture]
public class When_comparing_PositiveInfinity_with_a_4_over_0 {
    private static readonly Fraction NonReducedInfinity = new(4, BigInteger.Zero, false);

    [Test]
    [SuppressMessage("ReSharper", "EqualExpressionComparison")]
    public void Using_the_equality_operator_should_return_false() {
        (Fraction.PositiveInfinity == NonReducedInfinity).Should()
            .BeFalse("Because this is the result of a/b == (a*c)/(b*c)");
        (NonReducedInfinity == Fraction.PositiveInfinity).Should()
            .BeFalse("Because this is the result of (a*c)/(b*c) == a/b");
    }

    [Test]
    [SuppressMessage("ReSharper", "EqualExpressionComparison")]
    public void Using_the_non_equality_operator_should_return_true() {
        (Fraction.PositiveInfinity != NonReducedInfinity).Should()
            .BeTrue("Because this is the result of a/b != (a*c)/(b*c)");
        (NonReducedInfinity != Fraction.PositiveInfinity).Should()
            .BeTrue("Because this is the result of (a*c)/(b*c) != a/b");
    }

    [Test]
    public void Using_Equals_should_return_true() {
        Fraction.PositiveInfinity.Equals(NonReducedInfinity).Should().BeTrue("Because 3/0 reduces to 1/0");
        NonReducedInfinity.Equals(Fraction.PositiveInfinity).Should().BeTrue("Because 3/0 reduces to 1/0");
    }
}

[TestFixture]
public class When_comparing_PositiveInfinity_with_another_Fraction() {
    private static readonly Fraction[] UnEqualFractionsToTest = [
        Fraction.MinusOne, Fraction.Zero, Fraction.One,
        0.5m, -0.5m, 1.5m, -1.5m,
        new Fraction(0, 4, false), // zero
        new Fraction(0, -4, false), // zero
        new Fraction(4, 2, false),
        new Fraction(4, -2, false),
        Fraction.NaN, Fraction.NegativeInfinity,
        new Fraction(-4, 0, false), // -inf
    ];

    public static IEnumerable<TestCaseData> UnequalFractionCases =>
        UnEqualFractionsToTest.Select(x => new TestCaseData(x));

    [Test]
    [TestCaseSource(nameof(UnequalFractionCases))]
    public void Using_the_equality_operator_should_return_false(Fraction fraction) {
        (Fraction.PositiveInfinity == fraction).Should().BeFalse();
        (fraction == Fraction.PositiveInfinity).Should().BeFalse();
    }

    [Test]
    [TestCaseSource(nameof(UnequalFractionCases))]
    public void Using_the_non_equality_operator_should_return_true(Fraction fraction) {
        (Fraction.PositiveInfinity != fraction).Should().BeTrue();
        (fraction != Fraction.PositiveInfinity).Should().BeTrue();
    }

    [Test]
    [TestCaseSource(nameof(UnequalFractionCases))]
    public void Using_Equals_should_return_false(Fraction fraction) {
        Fraction.PositiveInfinity.Equals(fraction).Should().BeFalse();
        fraction.Equals(Fraction.PositiveInfinity).Should().BeFalse();
    }
}

[TestFixture]
public class When_comparing_NegativeInfinity_with_NegativeInfinity {
    [Test]
    [SuppressMessage("ReSharper", "EqualExpressionComparison")]
    public void Using_the_equality_operator_should_return_true() {
        (Fraction.NegativeInfinity == Fraction.NegativeInfinity).Should()
            .BeTrue("Because this is the result of double.NegativeInfinity == double.NegativeInfinity");
    }

    [Test]
    [SuppressMessage("ReSharper", "EqualExpressionComparison")]
    public void Using_the_non_equality_operator_should_return_false() {
        (Fraction.NegativeInfinity != Fraction.NegativeInfinity).Should()
            .BeFalse("Because this is the result of double.NegativeInfinity != double.NegativeInfinity");
    }

    [Test]
    public void Using_Equals_should_return_true() {
        Fraction.NegativeInfinity.Equals(Fraction.NegativeInfinity).Should()
            .BeTrue("Because double.NegativeInfinity.Equals(double.NegativeInfinity) is true");
    }
}

[TestFixture]
public class When_comparing_NegativeInfinity_with_a_minus_4_over_0 {
    private static readonly Fraction NonReducedInfinity = new(-4, BigInteger.Zero, false);

    [Test]
    [SuppressMessage("ReSharper", "EqualExpressionComparison")]
    public void Using_the_equality_operator_should_return_false() {
        (Fraction.NegativeInfinity == NonReducedInfinity).Should()
            .BeFalse("Because this is the result of a/b == (a*c)/(b*c)");
        (NonReducedInfinity == Fraction.NegativeInfinity).Should()
            .BeFalse("Because this is the result of (a*c)/(b*c) == a/b");
    }

    [Test]
    [SuppressMessage("ReSharper", "EqualExpressionComparison")]
    public void Using_the_non_equality_operator_should_return_true() {
        (Fraction.NegativeInfinity != NonReducedInfinity).Should()
            .BeTrue("Because this is the result of a/b != (a*c)/(b*c)");
        (NonReducedInfinity != Fraction.NegativeInfinity).Should()
            .BeTrue("Because this is the result of (a*c)/(b*c) != a/b");
    }

    [Test]
    public void Using_Equals_should_return_true() {
        Fraction.NegativeInfinity.Equals(NonReducedInfinity).Should().BeTrue("Because -3/0 reduces to -1/0");
        NonReducedInfinity.Equals(Fraction.NegativeInfinity).Should().BeTrue("Because -3/0 reduces to -1/0");
    }
}

[TestFixture]
public class When_comparing_NegativeInfinity_with_another_Fraction() {
    private static readonly Fraction[] UnEqualFractionsToTest = [
        Fraction.MinusOne, Fraction.Zero, Fraction.One,
        0.5m, -0.5m, 1.5m, -1.5m,
        new Fraction(0, 4, false), // zero
        new Fraction(0, -4, false), // zero
        new Fraction(4, 2, false),
        new Fraction(4, -2, false),
        Fraction.NaN, Fraction.PositiveInfinity,
        new Fraction(4, 0, false), // -inf
    ];

    public static IEnumerable<TestCaseData> UnequalFractionCases =>
        UnEqualFractionsToTest.Select(x => new TestCaseData(x));

    [Test]
    [TestCaseSource(nameof(UnequalFractionCases))]
    public void Using_the_equality_operator_should_return_false(Fraction fraction) {
        (Fraction.NegativeInfinity == fraction).Should().BeFalse();
        (fraction == Fraction.NegativeInfinity).Should().BeFalse();
    }

    [Test]
    [TestCaseSource(nameof(UnequalFractionCases))]
    public void Using_the_non_equality_operator_should_return_true(Fraction fraction) {
        (Fraction.NegativeInfinity != fraction).Should().BeTrue();
        (fraction != Fraction.NegativeInfinity).Should().BeTrue();
    }

    [Test]
    [TestCaseSource(nameof(UnequalFractionCases))]
    public void Using_Equals_should_return_false(Fraction fraction) {
        Fraction.NegativeInfinity.Equals(fraction).Should().BeFalse();
        fraction.Equals(Fraction.NegativeInfinity).Should().BeFalse();
    }

    [Test]
    [TestCaseSource(nameof(UnequalFractionCases))]
    public void Comparing_NaN_with_NaN_using_Equals_should_return_false(Fraction fraction) {
        Fraction.NegativeInfinity.Equals(fraction).Should().BeFalse();
        fraction.Equals(Fraction.NegativeInfinity).Should().BeFalse();
    }
}
