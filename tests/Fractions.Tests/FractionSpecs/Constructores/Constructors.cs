using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Constructores;

public abstract class FractionConstructorSpec : Spec {
    protected Fraction ResultingFraction { get; private set; }

    public override void Act() {
        ResultingFraction = CreateFraction();
    }

    protected abstract Fraction CreateFraction();
}

[TestFixture]
public static class Constructing_NaN {
    /// <summary>
    ///     Represents a set of tests for constructing NaN (Not a Number) fractions.
    /// </summary>
    /// <remarks>
    ///     The tests in this class verify the following invariants of a NaN fraction:
    ///     <list type="bullet">
    ///         <item>
    ///             <description>Numerator is zero</description>
    ///         </item>
    ///         <item>
    ///             <description>Denominator is zero</description>
    ///         </item>
    ///         <item>
    ///             <description>State is IsNormalized</description>
    ///         </item>
    ///         <item>
    ///             <description>IsNan is true</description>
    ///         </item>
    ///         <item>
    ///             <description>IsZero is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsPositive is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsNegative is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsInfinity is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsPositiveInfinity is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsNegativeInfinity is false</description>
    ///         </item>
    ///     </list>
    /// </remarks>
    public abstract class Result : FractionConstructorSpec {
        [Test]
        public void Numerator_should_be_zero() {
            ResultingFraction.Numerator.IsZero.Should().BeTrue();
        }

        [Test]
        public void Denominator_should_be_zero() {
            ResultingFraction.Denominator.IsZero.Should().BeTrue();
        }

        [Test]
        public void State_should_be_IsNormalized() {
            ResultingFraction.Denominator.IsZero.Should().BeTrue();
        }

        [Test]
        public void IsNan_should_be_true() {
            ResultingFraction.IsNaN.Should().BeTrue();
        }

        [Test]
        public void IsZero_should_be_false() {
            ResultingFraction.IsZero.Should().BeFalse();
        }

        [Test]
        public void IsPositive_should_be_false() {
            ResultingFraction.IsPositive.Should().BeFalse();
        }

        [Test]
        public void IsNegative_should_be_false() {
            ResultingFraction.IsNegative.Should().BeFalse();
        }

        [Test]
        public void IsInfinity_should_be_false() {
            ResultingFraction.IsInfinity.Should().BeFalse();
        }

        [Test]
        public void IsPositiveInfinity_should_be_false() {
            ResultingFraction.IsPositiveInfinity.Should().BeFalse();
        }

        [Test]
        public void IsNegativeInfinity_should_be_false() {
            ResultingFraction.IsNegativeInfinity.Should().BeFalse();
        }
    }

    [TestFixture]
    public class Using_the_Fraction_NaN_constant : Result {
        protected override Fraction CreateFraction() {
            return Fraction.NaN;
        }
    }

    [TestFixture]
    public class Using_0_as_numerator_and_0_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(BigInteger.Zero, BigInteger.Zero);
        }
    }

    [TestFixture]
    public class Using_0_as_numerator_and_0_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(BigInteger.Zero, BigInteger.Zero, true);
        }
    }

    [TestFixture]
    public class Using_0_as_numerator_and_0_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(BigInteger.Zero, BigInteger.Zero, false);
        }
    }
}

[TestFixture]
public static class Constructing_Zero {
    /// <summary>
    ///     Represents a set of tests for constructing Zero fractions.
    /// </summary>
    /// <remarks>
    ///     The tests in this class verify the following invariants of a Zero fraction:
    ///     <list type="bullet">
    ///         <item>
    ///             <description>Numerator is zero</description>
    ///         </item>
    ///         <item>
    ///             <description>Denominator is non-zero</description>
    ///         </item>
    ///         <item>
    ///             <description>IsZero is true</description>
    ///         </item>
    ///         <item>
    ///             <description>IsPositive is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsNegative is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsNan is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsInfinity is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsPositiveInfinity is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsNegativeInfinity is false</description>
    ///         </item>
    ///     </list>
    /// </remarks>
    public abstract class Result : FractionConstructorSpec {
        [Test]
        public void Numerator_should_be_zero() {
            ResultingFraction.Numerator.IsZero.Should().BeTrue();
        }

        [Test]
        public void Denominator_should_be_non_zero() {
            ResultingFraction.Denominator.IsZero.Should().BeFalse("0/0 represents NaN");
            (ResultingFraction.State == FractionState.IsNormalized).Should().Imply(ResultingFraction.Denominator.IsOne, "0/n should be reduced to 0/1");
        }

        [Test]
        public void IsZero_should_be_true() {
            ResultingFraction.IsZero.Should().BeTrue();
        }

        [Test]
        public void IsPositive_should_be_false() {
            ResultingFraction.IsPositive.Should().BeFalse();
        }

        [Test]
        public void IsNegative_should_be_false() {
            ResultingFraction.IsNegative.Should().BeFalse();
        }

        [Test]
        public void IsNan_should_be_false() {
            ResultingFraction.IsNaN.Should().BeFalse();
        }

        [Test]
        public void IsInfinity_should_be_false() {
            ResultingFraction.IsInfinity.Should().BeFalse();
        }

        [Test]
        public void IsPositiveInfinity_should_be_false() {
            ResultingFraction.IsPositiveInfinity.Should().BeFalse();
        }

        [Test]
        public void IsNegativeInfinity_should_be_false() {
            ResultingFraction.IsNegativeInfinity.Should().BeFalse();
        }
    }

    [TestFixture]
    public class Using_the_Zero_constant : Result {
        protected override Fraction CreateFraction() {
            return Fraction.Zero;
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    public class Using_the_default_constructor : Result {
        protected override Fraction CreateFraction() {
            return default;
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            // note: alternatively we could have the Fraction._denominator be a Nullable<BigInteger> which would allow us to check for it in the State property
            ResultingFraction.State.Should().Be(FractionState.Unknown, "We aren't going through any constructor");
        }
    }

    [TestFixture]
    public class Using_0_as_numerator_and_1_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(0, 1);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    public class Using_0_as_numerator_and_1_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(0, 1, true);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    public class Using_0_as_numerator_and_1_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(0, 1, false);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.Should().Be(1, "Because this is what we specified");
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }

    [TestFixture]
    public class Using_0_as_numerator_and_minus_1_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(0, -1, true);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    public class Using_0_as_numerator_and_minus_1_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(0, -1, false);
        }

        [Test]
        public void The_resulting_Denominator_should_be_minus_1() {
            ResultingFraction.Denominator.Should().Be(-1);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }

    [TestFixture]
    public class Using_0_as_numerator_and_4_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(0, 4);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    public class Using_0_as_numerator_and_4_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(0, 4, true);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    public class Using_0_as_numerator_and_4_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(0, 4, false);
        }

        [Test]
        public void The_resulting_Denominator_should_be_4() {
            ResultingFraction.Denominator.Should().Be(4);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }

    [TestFixture]
    public class Using_0_as_numerator_and_minus_4_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(0, -4);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    public class Using_0_as_numerator_and_minus_4_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(0, -4, true);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    public class Using_0_as_numerator_and_minus_4_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(0, -4, false);
        }

        [Test]
        public void The_resulting_Denominator_should_be_minus_4() {
            ResultingFraction.Denominator.Should().Be(-4);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }

    [TestFixture]
    // German: Wenn ein Bruch mit int 0 als Zähler erzeugt wird
    public class Using_int_0_as_numerator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(0);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    // German: Wenn ein Bruch mit uint 0 als Zähler erzeugt wird
    public class Using_uint_0_as_numerator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction((uint)0);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    // German: Wenn ein Bruch mit long 0 als Zähler erzeugt wird
    public class Using_long_0_as_numerator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction((long)0);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    // German: Wenn ein Bruch mit ulong 0 als Zähler erzeugt wird
    public class Using_ulong_0_as_numerator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction((ulong)0);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    // German: Wenn ein Bruch mit double 0 als Zähler erzeugt wird
    public class Using_double_0_as_numerator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction((double)0);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    // German: Wenn ein Bruch mit decimal 0 als Zähler erzeugt wird
    public class Using_decimal_0_as_numerator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction((decimal)0);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    // German: Wenn ein Bruch mit BigInteger 0 als Zähler erzeugt wird
    public class Using_BigInteger_0_as_numerator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(BigInteger.Zero);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
}

[TestFixture]
public static class Constructing_PositiveInfinity {
    /// <summary>
    ///     Represents a set of tests for constructing Positive Infinity fractions.
    /// </summary>
    /// <remarks>
    ///     The tests in this class verify the following invariants of a Positive Infinity fraction:
    ///     <list type="bullet">
    ///         <item>
    ///             <description>Numerator is positive</description>
    ///         </item>
    ///         <item>
    ///             <description>Denominator is zero</description>
    ///         </item>
    ///         <item>
    ///             <description>IsZero is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsPositive is true</description>
    ///         </item>
    ///         <item>
    ///             <description>IsNegative is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsNan is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsInfinity is true</description>
    ///         </item>
    ///         <item>
    ///             <description>IsPositiveInfinity is true</description>
    ///         </item>
    ///         <item>
    ///             <description>IsNegativeInfinity is false</description>
    ///         </item>
    ///     </list>
    /// </remarks>
    public abstract class Result : FractionConstructorSpec {
        [Test]
        public void Numerator_should_be_positive() {
            ResultingFraction.Numerator.Should().BeGreaterThan(BigInteger.Zero);
            (ResultingFraction.State == FractionState.IsNormalized).Should().Imply(ResultingFraction.Numerator.IsOne, "n/1 should be reduced to 1/0");
        }

        [Test]
        public void Denominator_should_be_zero() {
            ResultingFraction.Denominator.IsZero.Should().BeTrue();
        }

        [Test]
        public void IsZero_should_be_false() {
            ResultingFraction.IsZero.Should().BeFalse();
        }

        [Test]
        public void IsPositive_should_be_True() {
            ResultingFraction.IsPositive.Should().BeTrue();
        }

        [Test]
        public void IsNegative_should_be_false() {
            ResultingFraction.IsNegative.Should().BeFalse();
        }

        [Test]
        public void IsNan_should_be_false() {
            ResultingFraction.IsNaN.Should().BeFalse();
        }

        [Test]
        public void IsInfinity_should_be_true() {
            ResultingFraction.IsInfinity.Should().BeTrue();
        }

        [Test]
        public void IsPositiveInfinity_should_be_true() {
            ResultingFraction.IsPositiveInfinity.Should().BeTrue();
        }

        [Test]
        public void IsNegativeInfinity_should_be_false() {
            ResultingFraction.IsNegativeInfinity.Should().BeFalse();
        }
    }
    
    [TestFixture]
    public class Using_1_as_numerator_and_0_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(BigInteger.One, BigInteger.Zero);
        }

        [Test]
        public void The_resulting_Numerator_should_be_1() {
            ResultingFraction.Numerator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_1_as_numerator_and_0_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(BigInteger.One, BigInteger.Zero, true);
        }

        [Test]
        public void The_resulting_Numerator_should_be_1() {
            ResultingFraction.Numerator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_1_as_numerator_and_0_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(1, BigInteger.Zero, false);
        }

        [Test]
        public void The_resulting_Numerator_should_be_1() {
            ResultingFraction.Numerator.Should().Be(1);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }
    
    [TestFixture]
    public class Using_4_as_numerator_and_0_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(4, BigInteger.Zero);
        }

        [Test]
        public void The_resulting_Numerator_should_be_1() {
            ResultingFraction.Numerator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_4_as_numerator_and_0_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(4, BigInteger.Zero, true);
        }

        [Test]
        public void The_resulting_Numerator_should_be_1() {
            ResultingFraction.Numerator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_4_as_numerator_and_0_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(4, BigInteger.Zero, false);
        }

        [Test]
        public void The_resulting_Numerator_should_be_4() {
            ResultingFraction.Numerator.Should().Be(4);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }
}

[TestFixture]
public static class Constructing_NegativeInfinity {
    /// <summary>
    ///     Represents a set of tests for constructing Negative Infinity fractions.
    /// </summary>
    /// <remarks>
    ///     The tests in this class verify the following invariants of a Negative Infinity fraction:
    ///     <list type="bullet">
    ///         <item>
    ///             <description>Numerator is negative</description>
    ///         </item>
    ///         <item>
    ///             <description>Denominator is zero</description>
    ///         </item>
    ///         <item>
    ///             <description>IsZero is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsPositive is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsNegative is true</description>
    ///         </item>
    ///         <item>
    ///             <description>IsNan is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsInfinity is true</description>
    ///         </item>
    ///         <item>
    ///             <description>IsPositiveInfinity is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsNegativeInfinity is true</description>
    ///         </item>
    ///     </list>
    /// </remarks>
    public abstract class Result : FractionConstructorSpec {
        [Test]
        public void Numerator_should_be_negative() {
            ResultingFraction.Numerator.Should().BeLessThan(BigInteger.Zero);
            (ResultingFraction.State == FractionState.IsNormalized).Should().Imply(ResultingFraction.Numerator == BigInteger.MinusOne, "-n/1 should be reduced to -1/0");
        }

        [Test]
        public void Denominator_should_be_zero() {
            ResultingFraction.Denominator.IsZero.Should().BeTrue();
        }

        [Test]
        public void IsZero_should_be_false() {
            ResultingFraction.IsZero.Should().BeFalse();
        }

        [Test]
        public void IsPositive_should_be_false() {
            ResultingFraction.IsPositive.Should().BeFalse();
        }

        [Test]
        public void IsNegative_should_be_true() {
            ResultingFraction.IsNegative.Should().BeTrue();
        }

        [Test]
        public void IsNan_should_be_false() {
            ResultingFraction.IsNaN.Should().BeFalse();
        }

        [Test]
        public void IsInfinity_should_be_true() {
            ResultingFraction.IsInfinity.Should().BeTrue();
        }

        [Test]
        public void IsPositiveInfinity_should_be_false() {
            ResultingFraction.IsPositiveInfinity.Should().BeFalse();
        }

        [Test]
        public void IsNegativeInfinity_should_be_true() {
            ResultingFraction.IsNegativeInfinity.Should().BeTrue();
        }
    }
    
    [TestFixture]
    public class Using_minus_1_as_numerator_and_0_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(BigInteger.MinusOne, BigInteger.Zero);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_1() {
            ResultingFraction.Numerator.Should().Be(BigInteger.MinusOne);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_1_as_numerator_and_0_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(BigInteger.MinusOne, BigInteger.Zero, true);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_1() {
            ResultingFraction.Numerator.Should().Be(BigInteger.MinusOne);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_1_as_numerator_and_0_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-1, BigInteger.Zero, false);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_1() {
            ResultingFraction.Numerator.Should().Be(-1);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }
    
    [TestFixture]
    public class Using_minus_4_as_numerator_and_0_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-4, BigInteger.Zero);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_1() {
            ResultingFraction.Numerator.Should().Be(BigInteger.MinusOne);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_4_as_numerator_and_0_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-4, BigInteger.Zero, true);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_1() {
            ResultingFraction.Numerator.Should().Be(BigInteger.MinusOne);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_4_as_numerator_and_0_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-4, BigInteger.Zero, false);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_4() {
            ResultingFraction.Numerator.Should().Be(-4);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }
}

[TestFixture]
public static class Constructing_a_Finite_Positive_Fraction {
    /// <summary>
    ///     Represents a set of tests for constructing Finite Positive fractions.
    /// </summary>
    /// <remarks>
    ///     The tests in this class verify the following invariants of a Finite Positive fraction:
    ///     <list type="bullet">
    ///         <item>
    ///             <description>Numerator is non-zero</description>
    ///         </item>
    ///         <item>
    ///             <description>Denominator is non-zero</description>
    ///         </item>
    ///         <item>
    ///             <description>IsZero is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsPositive is true</description>
    ///         </item>
    ///         <item>
    ///             <description>IsNegative is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsNan is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsInfinity is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsPositiveInfinity is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsNegativeInfinity is false</description>
    ///         </item>
    ///     </list>
    /// </remarks>
    public abstract class Result : FractionConstructorSpec {
        [Test]
        public void Numerator_should_be_non_zero() {
            ResultingFraction.Numerator.IsZero.Should().BeFalse();
        }

        [Test]
        public void Denominator_should_be_non_zero() {
            ResultingFraction.Denominator.IsZero.Should().BeFalse();
            (ResultingFraction.State == FractionState.IsNormalized).Should().Imply(ResultingFraction.Denominator.Sign == 1, "a/-b should be reduced to -a/b");
        }

        [Test]
        public void Numerator_and_Denominator_should_have_the_same_signs() {
            ResultingFraction.Numerator.Sign.Should().Be(ResultingFraction.Denominator.Sign);
        }

        [Test]
        public void IsZero_should_be_false() {
            ResultingFraction.IsZero.Should().BeFalse();
        }

        [Test]
        public void IsNan_should_be_false() {
            ResultingFraction.IsNaN.Should().BeFalse();
        }

        [Test]
        public void IsInfinity_should_be_false() {
            ResultingFraction.IsInfinity.Should().BeFalse();
        }

        [Test]
        public void IsPositiveInfinity_should_be_false() {
            ResultingFraction.IsPositiveInfinity.Should().BeFalse();
        }

        [Test]
        public void IsNegativeInfinity_should_be_false() {
            ResultingFraction.IsNegativeInfinity.Should().BeFalse();
        }
    }

    [TestFixture]
    public class Using_2_as_numerator_and_3_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(2, 3);
        }

        [Test]
        public void The_resulting_Numerator_should_be_2() {
            ResultingFraction.Numerator.Should().Be(2);
        }

        [Test]
        public void The_resulting_Denominator_should_be_3() {
            ResultingFraction.Denominator.Should().Be(3);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_2_as_numerator_and_3_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(2, 3, true);
        }

        [Test]
        public void The_resulting_Numerator_should_be_2() {
            ResultingFraction.Numerator.Should().Be(2);
        }

        [Test]
        public void The_resulting_Denominator_should_be_3() {
            ResultingFraction.Denominator.Should().Be(3);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_2_as_numerator_and_3_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(2, 3, false);
        }

        [Test]
        public void The_resulting_Numerator_should_be_2() {
            ResultingFraction.Numerator.Should().Be(2);
        }

        [Test]
        public void The_resulting_Denominator_should_be_3() {
            ResultingFraction.Denominator.Should().Be(3);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }

    [TestFixture]
    public class Using_minus_2_as_numerator_and_minus_3_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-2, -3);
        }

        [Test]
        public void The_resulting_Numerator_should_be_2() {
            ResultingFraction.Numerator.Should().Be(2);
        }

        [Test]
        public void The_resulting_Denominator_should_be_3() {
            ResultingFraction.Denominator.Should().Be(3);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_2_as_numerator_and_minus_3_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-2, -3, true);
        }

        [Test]
        public void The_resulting_Numerator_should_be_2() {
            ResultingFraction.Numerator.Should().Be(2);
        }

        [Test]
        public void The_resulting_Denominator_should_be_3() {
            ResultingFraction.Denominator.Should().Be(3);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_2_as_numerator_and_minus_3_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-2, -3, false);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_2() {
            ResultingFraction.Numerator.Should().Be(-2);
        }

        [Test]
        public void The_resulting_Denominator_should_be_minus_3() {
            ResultingFraction.Denominator.Should().Be(-3);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }

    [TestFixture]
    public class Using_4_as_numerator_and_4_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(4, 4);
        }

        [Test]
        public void The_resulting_Numerator_should_be_1() {
            ResultingFraction.Numerator.Should().Be(1);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.Should().Be(1);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_4_as_numerator_and_4_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(4, 4, true);
        }

        [Test]
        public void The_resulting_Numerator_should_be_1() {
            ResultingFraction.Numerator.Should().Be(1);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.Should().Be(1);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_4_as_numerator_and_4_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(4, 4, false);
        }

        [Test]
        public void The_resulting_Numerator_should_be_4() {
            ResultingFraction.Numerator.Should().Be(4);
        }

        [Test]
        public void The_resulting_Denominator_should_be_4() {
            ResultingFraction.Denominator.Should().Be(4);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }

    [TestFixture]
    public class Using_minus_4_as_numerator_and_minus_4_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-4, -4);
        }

        [Test]
        public void The_resulting_Numerator_should_be_1() {
            ResultingFraction.Numerator.Should().Be(1);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.Should().Be(1);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_4_as_numerator_and_minus_4_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-4, -4, true);
        }

        [Test]
        public void The_resulting_Numerator_should_be_1() {
            ResultingFraction.Numerator.Should().Be(1);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.Should().Be(1);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_4_as_numerator_and_minus_4_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-4, -4, false);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_4() {
            ResultingFraction.Numerator.Should().Be(-4);
        }

        [Test]
        public void The_resulting_Denominator_should_be_minus_4() {
            ResultingFraction.Denominator.Should().Be(-4);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }

    [TestFixture]
    public class Using_4_as_numerator_and_12_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(4, 12);
        }

        [Test]
        // German: Soll der resultierende Bruch im Zähler 1 haben
        public void The_resulting_Numerator_should_be_1() {
            ResultingFraction.Numerator.Should().Be(1);
        }

        [Test]
        // German: Soll der resultierende Bruch im Nenner 3 haben
        public void The_resulting_Denominator_should_be_3() {
            ResultingFraction.Denominator.Should().Be(3);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    // German: Wenn ein Bruch mit 4 als Zähler und 12 als Nenner normalisiert erzeugt wird dann
    public class Using_4_as_numerator_and_12_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(4, 12, true);
        }

        [Test]
        // German: Soll der resultierende Bruch im Zähler 1 haben
        public void The_resulting_Numerator_should_be_1() {
            ResultingFraction.Numerator.Should().Be(1);
        }

        [Test]
        // German: Soll der resultierende Bruch im Nenner 3 haben
        public void The_resulting_Denominator_should_be_3() {
            ResultingFraction.Denominator.Should().Be(3);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_4_as_numerator_and_12_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(4, 12, false);
        }

        [Test]
        // German: Soll der resultierende Bruch im Zähler 4 haben
        public void The_resulting_Numerator_should_be_4() {
            ResultingFraction.Numerator.Should().Be(4);
        }

        [Test]
        // German: Soll der resultierende Bruch im Nenner 12 haben
        public void The_resulting_Denominator_should_be_12() {
            ResultingFraction.Denominator.Should().Be(12);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }

    [TestFixture]
    public class Using_minus_4_as_numerator_and_minus_12_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-4, -12);
        }

        [Test]
        // German: Soll der resultierende Bruch im Zähler 1 haben
        public void The_resulting_Numerator_should_be_1() {
            ResultingFraction.Numerator.Should().Be(1);
        }

        [Test]
        // German: Soll der resultierende Bruch im Nenner 3 haben
        public void The_resulting_Denominator_should_be_3() {
            ResultingFraction.Denominator.Should().Be(3);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_4_as_numerator_and_minus_12_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-4, -12, true);
        }

        [Test]
        // German: Soll der resultierende Bruch im Zähler 1 haben
        public void The_resulting_Numerator_should_be_1() {
            ResultingFraction.Numerator.Should().Be(1);
        }

        [Test]
        // German: Soll der resultierende Bruch im Nenner 3 haben
        public void The_resulting_Denominator_should_be_3() {
            ResultingFraction.Denominator.Should().Be(3);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_4_as_numerator_and_minus_12_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-4, -12, false);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_4() {
            ResultingFraction.Numerator.Should().Be(-4);
        }

        [Test]
        public void The_resulting_Denominator_should_be_minus_12() {
            ResultingFraction.Denominator.Should().Be(-12);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }

    [TestFixture]
    public class Using_12_as_numerator_and_4_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(12, 4);
        }
        
        [Test]
        // German: Soll der resultierende Bruch im Zähler 3 haben
        public void The_resulting_Numerator_should_be_3() {
            ResultingFraction.Numerator.Should().Be(3);
        }

        [Test]
        // German: Soll der resultierende Bruch im Nenner 1 haben
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.Should().Be(1);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    // German: Wenn ein Bruch mit 12 als Zähler und 4 als Nenner normalisiert erzeugt wird dann
    public class Using_12_as_numerator_and_4_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(12, 4, true);
        }
        
        [Test]
        // German: Soll der resultierende Bruch im Zähler 3 haben
        public void The_resulting_Numerator_should_be_3() {
            ResultingFraction.Numerator.Should().Be(3);
        }

        [Test]
        // German: Soll der resultierende Bruch im Nenner 1 haben
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.Should().Be(1);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    // German: Wenn ein Bruch mit 12 als Zähler und 4 als Nenner normalisiert erzeugt wird dann
    public class Using_12_as_numerator_and_4_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(12, 4, false);
        }
        
        [Test]
        // German: Soll der resultierende Bruch im Zähler 12 haben
        public void The_resulting_Numerator_should_be_12() {
            ResultingFraction.Numerator.Should().Be(12);
        }

        [Test]
        // German: Soll der resultierende Bruch im Nenner 4 haben
        public void The_resulting_Denominator_should_be_4() {
            ResultingFraction.Denominator.Should().Be(4);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }
    
    [TestFixture]
    public class Using_minus_12_as_numerator_and_minus_4_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-12, -4);
        }
        
        [Test]
        // German: Soll der resultierende Bruch im Zähler 3 haben
        public void The_resulting_Numerator_should_be_3() {
            ResultingFraction.Numerator.Should().Be(3);
        }

        [Test]
        // German: Soll der resultierende Bruch im Nenner 1 haben
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.Should().Be(1);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_12_as_numerator_and_minus_4_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-12, -4, true);
        }
        
        [Test]
        // German: Soll der resultierende Bruch im Zähler 3 haben
        public void The_resulting_Numerator_should_be_3() {
            ResultingFraction.Numerator.Should().Be(3);
        }

        [Test]
        // German: Soll der resultierende Bruch im Nenner 1 haben
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.Should().Be(1);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_12_as_numerator_and_minus_4_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-12, -4, false);
        }
        
        [Test]
        public void The_resulting_Numerator_should_be_minus_12() {
            ResultingFraction.Numerator.Should().Be(-12);
        }

        [Test]
        public void The_resulting_Denominator_should_be_minus_4() {
            ResultingFraction.Denominator.Should().Be(-4);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }
    
    [TestFixture]
    // German: Wenn ein Bruch mit int 4 als Zähler erzeugt wird
    public class Using_int_4_as_numerator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(4);
        }

        [Test]
        public void The_resulting_Denominator_should_be_4() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    // German: Wenn ein Bruch mit uint 4 als Zähler erzeugt wird
    public class Using_uint_4_as_numerator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction((uint)4);
        }

        [Test]
        public void The_resulting_Denominator_should_be_4() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    // German: Wenn ein Bruch mit long 4 als Zähler erzeugt wird
    public class Using_long_4_as_numerator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction((long)4);
        }

        [Test]
        public void The_resulting_Denominator_should_be_4() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    // German: Wenn ein Bruch mit ulong 4 als Zähler erzeugt wird
    public class Using_ulong_4_as_numerator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction((ulong)4);
        }

        [Test]
        public void The_resulting_Denominator_should_be_4() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    // German: Wenn ein Bruch mit double 4 als Zähler erzeugt wird
    public class Using_double_4_as_numerator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction((double)4);
        }

        [Test]
        public void The_resulting_Denominator_should_be_4() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    // German: Wenn ein Bruch mit decimal 4 als Zähler erzeugt wird
    public class Using_decimal_4_as_numerator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction((decimal)4);
        }

        [Test]
        public void The_resulting_Denominator_should_be_4() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    // German: Wenn ein Bruch mit BigInteger 4 als Zähler erzeugt wird
    public class Using_BigInteger_4_as_numerator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(new BigInteger(4));
        }

        [Test]
        public void The_resulting_Denominator_should_be_4() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
}

[TestFixture]
public static class Constructing_a_Finite_Negative_Fraction {
    /// <summary>
    ///     Represents a set of tests for constructing Finite Negative fractions.
    /// </summary>
    /// <remarks>
    ///     The tests in this class verify the following invariants of a Finite Negative fraction:
    ///     <list type="bullet">
    ///         <item>
    ///             <description>Numerator is non-zero</description>
    ///         </item>
    ///         <item>
    ///             <description>Denominator is non-zero</description>
    ///         </item>
    ///         <item>
    ///             <description>IsZero is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsPositive is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsNegative is true</description>
    ///         </item>
    ///         <item>
    ///             <description>IsNan is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsInfinity is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsPositiveInfinity is false</description>
    ///         </item>
    ///         <item>
    ///             <description>IsNegativeInfinity is false</description>
    ///         </item>
    ///     </list>
    /// </remarks>
    public abstract class Result : FractionConstructorSpec {
        [Test]
        public void Numerator_should_be_non_zero() {
            ResultingFraction.Numerator.IsZero.Should().BeFalse();
        }

        [Test]
        public void Denominator_should_be_non_zero() {
            ResultingFraction.Denominator.IsZero.Should().BeFalse();
            (ResultingFraction.State == FractionState.IsNormalized).Should().Imply(ResultingFraction.Denominator.Sign == 1, "a/-b should be reduced to -a/b");
        }

        [Test]
        public void Numerator_and_Denominator_should_have_the_opposite_signs() {
            ResultingFraction.Numerator.Sign.Should().Be(-ResultingFraction.Denominator.Sign);
        }

        [Test]
        public void IsZero_should_be_false() {
            ResultingFraction.IsZero.Should().BeFalse();
        }

        [Test]
        public void IsNan_should_be_false() {
            ResultingFraction.IsNaN.Should().BeFalse();
        }

        [Test]
        public void IsInfinity_should_be_false() {
            ResultingFraction.IsInfinity.Should().BeFalse();
        }

        [Test]
        public void IsPositiveInfinity_should_be_false() {
            ResultingFraction.IsPositiveInfinity.Should().BeFalse();
        }

        [Test]
        public void IsNegativeInfinity_should_be_false() {
            ResultingFraction.IsNegativeInfinity.Should().BeFalse();
        }
    }
    
    [TestFixture]
    public class Using_minus_2_as_numerator_and_3_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-2, 3);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_2() {
            ResultingFraction.Numerator.Should().Be(-2);
        }

        [Test]
        public void The_resulting_Denominator_should_be_3() {
            ResultingFraction.Denominator.Should().Be(3);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_2_as_numerator_and_3_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-2, 3, true);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_2() {
            ResultingFraction.Numerator.Should().Be(-2);
        }

        [Test]
        public void The_resulting_Denominator_should_be_3() {
            ResultingFraction.Denominator.Should().Be(3);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_2_as_numerator_and_3_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-2, 3, false);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_2() {
            ResultingFraction.Numerator.Should().Be(-2);
        }

        [Test]
        public void The_resulting_Denominator_should_be_3() {
            ResultingFraction.Denominator.Should().Be(3);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }

    [TestFixture]
    public class Using_2_as_numerator_and_minus_3_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(2, -3);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_2() {
            ResultingFraction.Numerator.Should().Be(-2);
        }

        [Test]
        public void The_resulting_Denominator_should_be_3() {
            ResultingFraction.Denominator.Should().Be(3);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_2_as_numerator_and_minus_3_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(2, -3, true);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_2() {
            ResultingFraction.Numerator.Should().Be(-2);
        }

        [Test]
        public void The_resulting_Denominator_should_be_3() {
            ResultingFraction.Denominator.Should().Be(3);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_2_as_numerator_and_minus_3_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(2, -3, false);
        }

        [Test]
        public void The_resulting_Numerator_should_be_2() {
            ResultingFraction.Numerator.Should().Be(2);
        }

        [Test]
        public void The_resulting_Denominator_should_be_minus_3() {
            ResultingFraction.Denominator.Should().Be(-3);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }

    [TestFixture]
    public class Using_minus_4_as_numerator_and_4_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-4, 4);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_1() {
            ResultingFraction.Numerator.Should().Be(-1);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.Should().Be(1);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_4_as_numerator_and_4_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-4, 4, true);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_1() {
            ResultingFraction.Numerator.Should().Be(-1);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.Should().Be(1);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_4_as_numerator_and_4_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-4, 4, false);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_4() {
            ResultingFraction.Numerator.Should().Be(-4);
        }

        [Test]
        public void The_resulting_Denominator_should_be_4() {
            ResultingFraction.Denominator.Should().Be(4);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }

    [TestFixture]
    public class Using_4_as_numerator_and_minus_4_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(4, -4);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_1() {
            ResultingFraction.Numerator.Should().Be(-1);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.Should().Be(1);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_4_as_numerator_and_minus_4_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(4, -4, true);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_1() {
            ResultingFraction.Numerator.Should().Be(-1);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.Should().Be(1);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_4_as_numerator_and_minus_4_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(4, -4, false);
        }

        [Test]
        public void The_resulting_Numerator_should_be_4() {
            ResultingFraction.Numerator.Should().Be(4);
        }

        [Test]
        public void The_resulting_Denominator_should_be_minus_4() {
            ResultingFraction.Denominator.Should().Be(-4);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }

    [TestFixture]
    public class Using_minus_4_as_numerator_and_12_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-4, 12);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_1() {
            ResultingFraction.Numerator.Should().Be(-1);
        }

        [Test]
        public void The_resulting_Denominator_should_be_3() {
            ResultingFraction.Denominator.Should().Be(3);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_4_as_numerator_and_12_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-4, 12, true);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_1() {
            ResultingFraction.Numerator.Should().Be(-1);
        }

        [Test]
        public void The_resulting_Denominator_should_be_3() {
            ResultingFraction.Denominator.Should().Be(3);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_4_as_numerator_and_12_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-4, 12, false);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_4() {
            ResultingFraction.Numerator.Should().Be(-4);
        }

        [Test]
        public void The_resulting_Denominator_should_be_12() {
            ResultingFraction.Denominator.Should().Be(12);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }

    [TestFixture]
    public class Using_4_as_numerator_and_minus_12_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(4, -12);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_1() {
            ResultingFraction.Numerator.Should().Be(-1);
        }

        [Test]
        public void The_resulting_Denominator_should_be_3() {
            ResultingFraction.Denominator.Should().Be(3);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_4_as_numerator_and_minus_12_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(4, -12, true);
        }

        [Test]
        public void The_resulting_Numerator_should_be_minus_1() {
            ResultingFraction.Numerator.Should().Be(-1);
        }

        [Test]
        public void The_resulting_Denominator_should_be_3() {
            ResultingFraction.Denominator.Should().Be(3);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_4_as_numerator_and_minus_12_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(4, -12, false);
        }

        [Test]
        public void The_resulting_Numerator_should_be_4() {
            ResultingFraction.Numerator.Should().Be(4);
        }

        [Test]
        public void The_resulting_Denominator_should_be_minus_12() {
            ResultingFraction.Denominator.Should().Be(-12);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }

    [TestFixture]
    public class Using_minus_12_as_numerator_and_4_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-12, 4);
        }
        
        [Test]
        public void The_resulting_Numerator_should_be_minus_3() {
            ResultingFraction.Numerator.Should().Be(-3);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.Should().Be(1);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_12_as_numerator_and_4_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-12, 4, true);
        }
        
        [Test]
        public void The_resulting_Numerator_should_be_minus_3() {
            ResultingFraction.Numerator.Should().Be(-3);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.Should().Be(1);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_minus_12_as_numerator_and_4_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-12, 4, false);
        }
        
        [Test]
        public void The_resulting_Numerator_should_be_minus_12() {
            ResultingFraction.Numerator.Should().Be(-12);
        }

        [Test]
        // German: Soll der resultierende Bruch im Nenner 4 haben
        public void The_resulting_Denominator_should_be_4() {
            ResultingFraction.Denominator.Should().Be(4);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }
    
    [TestFixture]
    public class Using_12_as_numerator_and_minus_4_as_denominator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(12, -4);
        }
        
        [Test]
        public void The_resulting_Numerator_should_be_minus_3() {
            ResultingFraction.Numerator.Should().Be(-3);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.Should().Be(1);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_12_as_numerator_and_minus_4_as_denominator_with_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(12, -4, true);
        }
        
        [Test]
        public void The_resulting_Numerator_should_be_minus_3() {
            ResultingFraction.Numerator.Should().Be(-3);
        }

        [Test]
        public void The_resulting_Denominator_should_be_1() {
            ResultingFraction.Denominator.Should().Be(1);
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_12_as_numerator_and_minus_4_as_denominator_without_normalization : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(12, -4, false);
        }
        
        [Test]
        public void The_resulting_Numerator_should_be_12() {
            ResultingFraction.Numerator.Should().Be(12);
        }

        [Test]
        public void The_resulting_Denominator_should_be_minus_4() {
            ResultingFraction.Denominator.Should().Be(-4);
        }

        [Test]
        public void The_resulting_State_should_be_Unknown() {
            ResultingFraction.State.Should().Be(FractionState.Unknown);
        }
    }
    
    [TestFixture]
    public class Using_int_minus_4_as_numerator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(-4);
        }

        [Test]
        public void The_resulting_Denominator_should_be_minus_4() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_long_minus_4_as_numerator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction((long)-4);
        }

        [Test]
        public void The_resulting_Denominator_should_be_minus_4() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
    
    [TestFixture]
    public class Using_double_minus_4_as_numerator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction((double)-4);
        }

        [Test]
        public void The_resulting_Denominator_should_be_minus_4() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    public class Using_decimal_minus_4_as_numerator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction((decimal)-4);
        }

        [Test]
        public void The_resulting_Denominator_should_be_minus_4() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }

    [TestFixture]
    public class Using_BigInteger_minus_4_as_numerator : Result {
        protected override Fraction CreateFraction() {
            return new Fraction(new BigInteger(-4));
        }

        [Test]
        public void The_resulting_Denominator_should_be_minus_4() {
            ResultingFraction.Denominator.IsOne.Should().BeTrue();
        }

        [Test]
        public void The_resulting_State_should_be_IsNormalized() {
            ResultingFraction.State.Should().Be(FractionState.IsNormalized);
        }
    }
}
