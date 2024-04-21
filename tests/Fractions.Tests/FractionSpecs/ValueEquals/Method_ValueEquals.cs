using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.ValueEquals;

[TestFixture]
// German: Wenn zwei Brüche mit identischen Zähler und Nenner verglichen werden
public class When_comparing_two_fractions_with_identical_numerator_and_denominator : Spec {
    private Fraction _fractionA;
    private Fraction _fractionB;

    public override void SetUp() {
        base.SetUp();
        _fractionA = new Fraction(5, 6, true);
        _fractionB = new Fraction(5, 6, true);
    }

    [Test]
    // German: Diese sollten als wertgleich erkannt werden
    public void These_should_be_recognized_as_equivalent() {
        _fractionA.IsEquivalentTo(_fractionB)
            .Should().BeTrue();
    }
}

[TestFixture]
// German: Wenn zwei Brüche mit unterschiedlichen Zähler aber identischen Nenner verglichen werden
public class When_comparing_two_fractions_with_different_numerator_but_identical_denominator : Spec {
    private Fraction _fractionA;
    private Fraction _fractionB;

    public override void SetUp() {
        base.SetUp();
        _fractionA = new Fraction(4, 6, true);
        _fractionB = new Fraction(5, 6, true);
    }

    [Test]
    // German: Diese sollten als nicht wertgleich erkannt werden
    public void These_should_be_recognized_as_not_equivalent() {
        _fractionA.IsEquivalentTo(_fractionB)
            .Should().BeFalse();
    }
}

[TestFixture]
// German: Wenn zwei Brüche mit identischen Zähler aber unterschiedlichen Nenner verglichen werden
public class When_comparing_two_fractions_with_identical_numerator_but_different_denominator : Spec {
    private Fraction _fractionA;
    private Fraction _fractionB;

    public override void SetUp() {
        base.SetUp();
        _fractionA = new Fraction(4, 6, true);
        _fractionB = new Fraction(4, 7, true);
    }

    [Test]
    // German: Diese sollten als nicht wertgleich erkannt werden
    public void These_should_be_recognized_as_not_equivalent() {
        _fractionA.IsEquivalentTo(_fractionB)
            .Should().BeFalse();
    }
}

[TestFixture]
// German: Wenn der Bruch 2/4 mit dem Bruch 1/2 verglichen wird
public class When_comparing_the_fraction_2_over_4_with_the_fraction_1_over_2 : Spec {
    private Fraction _fractionA;
    private Fraction _fractionB;

    public override void SetUp() {
        base.SetUp();
        _fractionA = new Fraction(2, 4, false);
        _fractionB = new Fraction(1, 2, true);
    }

    [Test]
    // German: Die Brüche sollten als nicht strukturell gleich erkannt werden
    public void The_fractions_should_be_recognized_as_not_equal() {
        _fractionA.Equals(_fractionB)
            .Should().BeFalse();
    }

    [Test]
    // German: Die Brüche sollten als wertgleich erkannt werden
    public void The_fractions_should_be_recognized_as_equivalent() {
        _fractionA.IsEquivalentTo(_fractionB)
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
    
    [Test]
    public void Using_IsEquivalent_should_return_true() {
        Fraction.NaN.IsEquivalentTo(Fraction.NaN).Should().BeTrue("Because Fraction.NaN.Equals(Fraction.NaN) is true");
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
    
    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void Using_IsEquivalent_should_return_false(Fraction fraction) {
        Fraction.NaN.IsEquivalentTo(fraction).Should().BeFalse();
    }
}

[TestFixture]
public class When_comparing_PositiveInfinity_with_PositiveInfinity {

    [Test]
    [SuppressMessage("ReSharper", "EqualExpressionComparison")]
    public void Using_the_equality_operator_should_return_true() {
        (Fraction.PositiveInfinity == Fraction.PositiveInfinity).Should().BeTrue("Because this is the result of double.PositiveInfinity == double.PositiveInfinity");
    }
    
    [Test]
    [SuppressMessage("ReSharper", "EqualExpressionComparison")]
    public void Using_the_non_equality_operator_should_return_false() {
        (Fraction.PositiveInfinity != Fraction.PositiveInfinity).Should().BeFalse("Because this is the result of double.PositiveInfinity != double.PositiveInfinity");
    }
    
    [Test]
    public void Using_Equals_should_return_true() {
        Fraction.PositiveInfinity.Equals(Fraction.PositiveInfinity).Should().BeTrue("Because double.PositiveInfinity.Equals(double.PositiveInfinity) is true");
    }
    
    [Test]
    public void Using_IsEquivalent_should_return_true() {
        Fraction.PositiveInfinity.IsEquivalentTo(Fraction.PositiveInfinity).Should().BeTrue("Because Fraction.PositiveInfinity.Equals(Fraction.PositiveInfinity) is true");
    }
}

[TestFixture]
public class When_comparing_PositiveInfinity_with_a_4_over_0 {
    
    private static readonly Fraction NonReducedInfinity = new(4, BigInteger.Zero, false);
    
    [Test]
    [SuppressMessage("ReSharper", "EqualExpressionComparison")]
    public void Using_the_equality_operator_should_return_false() {
        (Fraction.PositiveInfinity == NonReducedInfinity).Should().BeFalse("Because this is the result of a/b == (a*c)/(b*c)");
        (NonReducedInfinity == Fraction.PositiveInfinity).Should().BeFalse("Because this is the result of (a*c)/(b*c) == a/b");
    }
    
    [Test]
    [SuppressMessage("ReSharper", "EqualExpressionComparison")]
    public void Using_the_non_equality_operator_should_return_true() {
        (Fraction.PositiveInfinity != NonReducedInfinity).Should().BeTrue("Because this is the result of a/b != (a*c)/(b*c)");
        (NonReducedInfinity != Fraction.PositiveInfinity).Should().BeTrue("Because this is the result of (a*c)/(b*c) != a/b");
    }
    
    [Test]
    public void Using_Equals_should_return_false() {
        Fraction.PositiveInfinity.Equals(NonReducedInfinity).Should().BeFalse("Because this is the result of (a/b).Equals((a*c, b*c))");
        NonReducedInfinity.Equals(Fraction.PositiveInfinity).Should().BeFalse("Because this is the result of ((a*c, b*c)).Equals(a/b)");
    }
    
    [Test]
    public void Using_IsEquivalent_should_return_true() {
        Fraction.PositiveInfinity.IsEquivalentTo(NonReducedInfinity).Should().BeTrue("Because 3/0 reduces to 1/0");
        NonReducedInfinity.IsEquivalentTo(Fraction.PositiveInfinity).Should().BeTrue("Because 3/0 reduces to 1/0");
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
    
    public static IEnumerable<TestCaseData> UnequalFractionCases => UnEqualFractionsToTest.Select(x => new TestCaseData(x));

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
    
    [Test]
    [TestCaseSource(nameof(UnequalFractionCases))]
    public void Comparing_NaN_with_NaN_using_IsEquivalent_should_return_false(Fraction fraction) {
        Fraction.PositiveInfinity.IsEquivalentTo(fraction).Should().BeFalse();
        fraction.IsEquivalentTo(Fraction.PositiveInfinity).Should().BeFalse();
    }
}

[TestFixture]
public class When_comparing_NegativeInfinity_with_NegativeInfinity {

    [Test]
    [SuppressMessage("ReSharper", "EqualExpressionComparison")]
    public void Using_the_equality_operator_should_return_true() {
        (Fraction.NegativeInfinity == Fraction.NegativeInfinity).Should().BeTrue("Because this is the result of double.NegativeInfinity == double.NegativeInfinity");
    }
    
    [Test]
    [SuppressMessage("ReSharper", "EqualExpressionComparison")]
    public void Using_the_non_equality_operator_should_return_false() {
        (Fraction.NegativeInfinity != Fraction.NegativeInfinity).Should().BeFalse("Because this is the result of double.NegativeInfinity != double.NegativeInfinity");
    }
    
    [Test]
    public void Using_Equals_should_return_true() {
        Fraction.NegativeInfinity.Equals(Fraction.NegativeInfinity).Should().BeTrue("Because double.NegativeInfinity.Equals(double.NegativeInfinity) is true");
    }
    
    [Test]
    public void Using_IsEquivalent_should_return_true() {
        Fraction.NegativeInfinity.IsEquivalentTo(Fraction.NegativeInfinity).Should().BeTrue("Because Fraction.NegativeInfinity.Equals(Fraction.NegativeInfinity) is true");
    }
}

[TestFixture]
public class When_comparing_NegativeInfinity_with_a_minus_4_over_0 {
    
    private static readonly Fraction NonReducedInfinity = new(-4, BigInteger.Zero, false);
    
    [Test]
    [SuppressMessage("ReSharper", "EqualExpressionComparison")]
    public void Using_the_equality_operator_should_return_false() {
        (Fraction.NegativeInfinity == NonReducedInfinity).Should().BeFalse("Because this is the result of a/b == (a*c)/(b*c)");
        (NonReducedInfinity == Fraction.NegativeInfinity).Should().BeFalse("Because this is the result of (a*c)/(b*c) == a/b");
    }
    
    [Test]
    [SuppressMessage("ReSharper", "EqualExpressionComparison")]
    public void Using_the_non_equality_operator_should_return_true() {
        (Fraction.NegativeInfinity != NonReducedInfinity).Should().BeTrue("Because this is the result of a/b != (a*c)/(b*c)");
        (NonReducedInfinity != Fraction.NegativeInfinity).Should().BeTrue("Because this is the result of (a*c)/(b*c) != a/b");
    }
    
    [Test]
    public void Using_Equals_should_return_false() {
        Fraction.NegativeInfinity.Equals(NonReducedInfinity).Should().BeFalse("Because this is the result of (a/b).Equals((a*c, b*c))");
        NonReducedInfinity.Equals(Fraction.NegativeInfinity).Should().BeFalse("Because this is the result of ((a*c, b*c)).Equals(a/b)");
    }
    
    [Test]
    public void Using_IsEquivalent_should_return_true() {
        Fraction.NegativeInfinity.IsEquivalentTo(NonReducedInfinity).Should().BeTrue("Because -3/0 reduces to -1/0");
        NonReducedInfinity.IsEquivalentTo(Fraction.NegativeInfinity).Should().BeTrue("Because -3/0 reduces to -1/0");
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
    
    public static IEnumerable<TestCaseData> UnequalFractionCases => UnEqualFractionsToTest.Select(x => new TestCaseData(x));

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
    public void Comparing_NaN_with_NaN_using_IsEquivalent_should_return_false(Fraction fraction) {
        Fraction.NegativeInfinity.IsEquivalentTo(fraction).Should().BeFalse();
        fraction.IsEquivalentTo(Fraction.NegativeInfinity).Should().BeFalse();
    }
}
