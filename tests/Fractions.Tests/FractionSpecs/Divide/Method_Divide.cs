using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Divide;

[TestFixture]
// German: Wenn 0 mit 0 dividiert wird
public class When_dividing_0_by_0 : Spec {
    private Fraction _result;

    public override void Act() {
        _result = Fraction.Zero.Divide(Fraction.Zero);
    }

    [Test]
    public void The_result_should_be_NaN() {
        _result.Should().Be(Fraction.NaN);
    }
}

[TestFixture]
// German: Wenn 1 mit 0 dividiert wird
public class When_dividing_1_by_0 : Spec {
    private Fraction _result;

    public override void Act() {
        _result = Fraction.One.Divide(Fraction.Zero);
    }

    [Test]
    public void The_result_should_be_PositiveInfinity() {
        _result.Should().Be(Fraction.PositiveInfinity);
    }
}

[TestFixture]
// German: Wenn 10 mit 0 dividiert wird
public class When_dividing_10_by_0 : Spec {
    private Fraction _result;

    public override void Act() {
        _result = new Fraction(10).Divide(Fraction.Zero);
    }

    [Test]
    public void The_result_should_be_PositiveInfinity() {
        _result.Should().Be(Fraction.PositiveInfinity);
    }
}

[TestFixture]
// German: Wenn minus 1 mit 0 dividiert wird
public class When_dividing_minus_1_by_0 : Spec {
    private Fraction _result;

    public override void Act() {
        _result = Fraction.MinusOne.Divide(Fraction.Zero);
    }

    [Test]
    public void The_result_should_be_NegativeInfinity() {
        _result.Should().Be(Fraction.NegativeInfinity);
    }
}

[TestFixture]
// German: Wenn minus 10 mit 0 dividiert wird
public class When_dividing_minus_10_by_0 : Spec {
    private Fraction _result;

    public override void Act() {
        _result = new Fraction(-10).Divide(Fraction.Zero);
    }

    [Test]
    public void The_result_should_be_NegativeInfinity() {
        _result.Should().Be(Fraction.NegativeInfinity);
    }
}

[TestFixture]
// German: Wenn ein Fünftel mit ein Fünftel dividiert wird
public class When_dividing_one_fifth_by_one_fifth : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(1, 5);
        _b = new Fraction(1, 5);
    }

    public override void Act() {
        _result = _a.Divide(_b);
    }

    [Test]
    // German: Das Ergebnis sollte 1 sein
    public void The_result_should_be_1() {
        _result.Should().Be(new Fraction(1, 1));
    }
}

[TestFixture]
// German: Wenn 2 mit 2 Viertel dividiert wird
public class When_dividing_2_by_2_quarters : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(2, 1);
        _b = new Fraction(2, 4);
    }

    public override void Act() {
        _result = _a.Divide(_b);
    }

    [Test]
    // German: Das Ergebnis sollte 4 sein
    public void The_result_should_be_4() {
        _result.Should().Be(new Fraction(4, 1));
    }
}

public class When_dividing_2_by_2_quarters_without_normalization : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(2, 1, false);
        _b = new Fraction(2, 4, false);
    }

    public override void Act() {
        _result = _a.Divide(_b);
    }

    [Test]
    public void The_result_should_be_8_over_2() {
        _result.Should().Be(new Fraction(8, 2, false));
    }
}

[TestFixture]
// German: Wenn minus 2 mit 2 Viertel dividiert wird
public class When_dividing_minus_2_by_2_quarters : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(-2, 1, false);
        _b = new Fraction(2, 4, false);
    }

    public override void Act() {
        _result = _a.Divide(_b);
    }

    [Test]
    public void The_result_should_be_minus_8_over_2() {
        _result.Should().Be(new Fraction(-8, 2, false));
    }
}

[TestFixture]
// German: Wenn 0 Achtel durch 4 dividiert werden
public class When_dividing_0_eighths_by_4 : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(0, 8, false);
        _b = new Fraction(4, 1, true);
    }

    public override void Act() {
        _result = _a.Divide(_b);
    }

    [Test]
    public void The_result_should_be_a_Zero() {
        _result.IsZero.Should().BeTrue();
    }
    
    [Test]
    public void The_result_should_be_0_over_32_exactly() {
        _result.Should().Be(new Fraction(0, 32, false));
    }
}

[TestFixture]
// German: Wenn 0 durch 4 dividiert werden
public class When_dividing_0_by_4 : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = Fraction.Zero;
        _b = new Fraction(4, 1, true);
    }

    public override void Act() {
        _result = _a.Divide(_b);
    }

    [Test]
    // German: Das Ergebnis sollte 0 sein
    public void The_result_should_be_0() {
        _result.Should().Be(Fraction.Zero);
    }
}

[TestFixture]
// German: Wenn 0 durch -4 dividiert werden
public class When_dividing_0_by_minus_4 : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = Fraction.Zero;
        _b = new Fraction(-4, 1, true);
    }

    public override void Act() {
        _result = _a.Divide(_b);
    }

    [Test]
    // German: Das Ergebnis sollte 0 sein
    public void The_result_should_be_0() {
        _result.Should().Be(Fraction.Zero);
    }
}

[TestFixture]
public class When_dividing_with_NaN {
    private static IEnumerable<TestCaseData> TestCases {
        get {
            // NaN with NaN
            yield return new TestCaseData(Fraction.NaN, Fraction.NaN).Returns(Fraction.NaN);
            // NaN with any number
            yield return new TestCaseData(Fraction.NaN, Fraction.PositiveInfinity).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(5, 4)).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(-5, -5, false)).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.One).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(4, 5)).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.Zero).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.MinusOne).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(-5, 4)).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(-4, 5)).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(5, -5, false)).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.NegativeInfinity).Returns(Fraction.NaN);
            // Any number with NaN
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(new Fraction(5, 4), Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.One, Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(new Fraction(4, 5), Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.Zero, Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.MinusOne, Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(new Fraction(-5, 4), Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(new Fraction(-4, 5), Fraction.NaN).Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NaN).Returns(Fraction.NaN);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public Fraction The_result_is_always_NaN(Fraction a, Fraction b) {
        return a.Divide(b);
    }
}

[TestFixture]
public class When_dividing_with_infinity {
    private static IEnumerable<TestCaseData> TestCases {
        get {
            // positive infinity with positive infinity
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.PositiveInfinity)
                .Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(5, 0, false))
                .Returns(Fraction.NaN);

            // positive infinity with any other number
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(5, 4))
                .Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.One)
                .Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(4, 5))
                .Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.Zero)
                .Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.MinusOne)
                .Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(-5, 4))
                .Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(-4, 5))
                .Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NegativeInfinity)
                .Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(-5, 0, false))
                .Returns(Fraction.NaN);

            // negative infinity with negative infinity
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NegativeInfinity)
                .Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-5, 0, false))
                .Returns(Fraction.NaN);

            // negative infinity with any other number
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(5, 4))
                .Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.One)
                .Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(4, 5))
                .Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.Zero)
                .Returns(Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.MinusOne)
                .Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-5, 4))
                .Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-4, 5))
                .Returns(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.PositiveInfinity)
                .Returns(Fraction.NaN);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-5, 0, false))
                .Returns(Fraction.NaN);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public Fraction The_result_is_always_NaN_or_Infinity(Fraction a, Fraction b) {
        return a.Divide(b);
    }
}

[TestFixture]
public class When_dividing_1_by_NaN : Spec {
    private Fraction _result;

    public override void Act() {
        _result = Fraction.One.Divide(Fraction.NaN);
    }

    [Test]
    public void The_result_should_be_NaN() {
        _result.Should().Be(Fraction.NaN);
    }
}

[TestFixture]
public class When_dividing_minus_1_by_NaN : Spec {
    private Fraction _result;

    public override void Act() {
        _result = Fraction.MinusOne.Divide(Fraction.NaN);
    }

    [Test]
    public void The_result_should_be_NaN() {
        _result.Should().Be(Fraction.NaN);
    }
}

[TestFixture]
public class When_dividing_NaN_by_1 : Spec {
    private Fraction _result;

    public override void Act() {
        _result = Fraction.NaN.Divide(Fraction.One);
    }

    [Test]
    public void The_result_should_be_NaN() {
        _result.Should().Be(Fraction.NaN);
    }
}

[TestFixture]
public class When_dividing_NaN_by_minus_1 : Spec {
    private Fraction _result;

    public override void Act() {
        _result = Fraction.NaN.Divide(Fraction.MinusOne);
    }

    [Test]
    public void The_result_should_be_NaN() {
        _result.Should().Be(Fraction.NaN);
    }
}

[TestFixture]
public class When_dividing_NaN_by_NaN : Spec {
    private Fraction _result;

    public override void Act() {
        _result = Fraction.NaN.Divide(Fraction.NaN);
    }

    [Test]
    public void The_result_should_be_NaN() {
        _result.Should().Be(Fraction.NaN);
    }
}

[TestFixture]
public class When_dividing_without_normalization {
    private static IEnumerable<TestCaseData> TestCases {
        get {
            #region zero cases

            // {0/1} / {1/10} = {0/1}
            yield return new TestCaseData(
                    Fraction.Zero,
                    new Fraction(1, 10, false))
                .Returns(new Fraction(0, 1, false));

            // {0/-1} / {1/10} = {0/-1}
            yield return new TestCaseData(
                    new Fraction(0, -1, false),
                    new Fraction(1, 10, false))
                .Returns(new Fraction(0, -1, false));

            // {0/10} / {1/10} = {0/10}
            yield return new TestCaseData(
                    new Fraction(0, 10, false),
                    new Fraction(1, 10, false))
                .Returns(new Fraction(0, 10, false));

            // {0/-10} / {1/10} = {0/-10}
            yield return new TestCaseData(
                    new Fraction(0, -10, false),
                    new Fraction(1, 10, false))
                .Returns(new Fraction(0, -10, false));
            
            #endregion

            #region 0.1m / 0.1XX

            // {1/10} / {1/10} == {10/10} 
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(1, 10, false))
                .Returns(new Fraction(10, 10, false));

            // {1/10} / {10/100} == {100/100}       // the denominator be increased (1.00m)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(10, 100, false))
                .Returns(new Fraction(100, 100, false));

            // {1/10} / {100/1000} == {1000/1000}   // the denominator should be increased (0.1m / 0.100m = 1.000m)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(100, 1000, false))
                .Returns(new Fraction(1000, 1000, false));

            #endregion

            #region 0.1m / 0.5XX

            // {1/10} / {5/10} == {10/50}        // the denominator should be increased incrementally (x / 0.5 / 0.2 should be the same as x / 0.1)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(5, 10, false))
                .Returns(new Fraction(10, 50, false));

            // {1/10} / {50/100} == {100/500}     // the denominator should be increased incrementally (x / 0.50 / 0.20 should be the same as x / 0.10)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(50, 100, false))
                .Returns(new Fraction(100, 500, false));

            // {1/10} / {500/1000} == {1000/5000}   // the denominator should be increased incrementally (x / 0.500 / 0.200 should be the same as x / 0.100)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(500, 1000, false))
                .Returns(new Fraction(1000, 5000, false));

            #endregion

            #region 0.1m / 1.XX

            // {1/10} / {1/1} == {1/10}
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(1, 1, false))
                .Returns(new Fraction(1, 10, false));

            // {1/10} / {10/10} == {10/100}       // the denominator should be increased (0.10m)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(10, 10, false))
                .Returns(new Fraction(10, 100, false));

            // {1/10} / {100/100} == {100/1000}   // the denominator should be increased (0.1m / 1.0m = 0.100m)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(100, 100, false))
                .Returns(new Fraction(100, 1000, false));

            #endregion

            #region 0.1m / 5.XX

            // {1/10} / {5/1} == {1/50}         // the denominator should be increased incrementally (x / 5 / 2 should be the same as x / 10)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(5, 1, false))
                .Returns(new Fraction(1, 50, false));

            // {1/10} * {50/10} == {10/500}       // the denominator should be increased incrementally (x / 50.0 / 2.0 should be the same as x / 100.0)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(50, 10, false))
                .Returns(new Fraction(10, 500, false));

            // {1/10} * {500/100} == {100/5000}   // the denominator should be increased incrementally (x / 50.00 / 2.0 should be the same as x / 100.00)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(500, 100, false))
                .Returns(new Fraction(100, 5000, false));

            #endregion

            #region 0.1m / 10.XX

            // {1/10} / {10/1} == {1/100}        
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(10, 1, false))
                .Returns(new Fraction(1, 100, false));

            // {1/10} / {100/10} == {10/1000}     
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(100, 10, false))
                .Returns(new Fraction(10, 1000, false));

            // {1/10} / {1000/100} == {100/10000}     // the denominator should be increased (0.1m / 10.00m = 0.010m)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(1000, 100, false))
                .Returns(new Fraction(100, 10000, false));

            #endregion

            #region 0.1m / 50.XX

            // {1/10} / {50/1} == {1/500}       // the denominator should be increased incrementally (x / 50 / 2 should be the same as x / 100)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(50, 1, false))
                .Returns(new Fraction(1, 500, false));

            // {1/10} / {500/10} == {10/5000}     // the denominator should be increased incrementally (x / 50.0 / 2.0 should be the same as x / 100.0)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(500, 10, false))
                .Returns(new Fraction(10, 5000, false));

            // {1/10} / {5000/100} == {100/50000}  // the denominator should be increased incrementally (x / 50.00 / 2.00 should be the same as x / 100.00)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(5000, 100, false))
                .Returns(new Fraction(100, 50000, false));

            #endregion

            #region 0.10m / 0.1XX

            // {10/100} / {1/10} == {100/100}     // the denominator should not change (0.10m / 0.1m = 1.00m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(1, 10, false))
                .Returns(new Fraction(100, 100, false));

            // {10/100} / {10/100} == {1000/1000}    // the denominator should be increased (0.10m / 0.10m = 1.000m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(10, 100, false))
                .Returns(new Fraction(1000, 1000, false));

            // {10/100} / {100/1000} == {10000/10000}   // the denominator should not change (0.10m / 0.100m = 1.0000m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(100, 1000, false))
                .Returns(new Fraction(10000, 10000, false));

            // {10/100} / {1000/10000} == {100000/100000} // the denominator should be increased (0.10m / 0.100m = 1.000000m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(1000, 10000, false))
                .Returns(new Fraction(100000, 100000, false));

            #endregion

            #region 0.10m / 0.5XX

            // {10/100} / {5/10} == {100/500}       // the denominator should be increased incrementally (x / 0.5 / 0.2 should be the same as x / 0.1)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(5, 10, false))
                .Returns(new Fraction(100, 500, false));

            // {10/100} / {50/100} == {1000/5000}   // the denominator should be increased incrementally (x / 0.50 / 0.20 should be the same as x / 0.10)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(50, 100, false))
                .Returns(new Fraction(1000, 5000, false));

            // {10/100} / {500/1000} == {10000/50000}   // the denominator should be increased incrementally (x / 0.500 / 0.200 should be the same as x / 0.100)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(500, 1000, false))
                .Returns(new Fraction(10000, 50000, false));

            // {10/100} / {5000/10000} == {100000/500000} // the denominator should be increased incrementally (x / 0.5000 / 0.2000 should be the same as x / 0.1000)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(5000, 10000, false))
                .Returns(new Fraction(100000, 500000, false));

            #endregion

            #region 0.10m / 1.XX

            // {10/100} / {1/1} == {10/100}
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(1, 1, false))
                .Returns(new Fraction(10, 100, false));

            // {10/100} / {10/10} == {100/1000}       // the denominator be increased (0.10m / 1.0m = 0.100m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(10, 10, false))
                .Returns(new Fraction(100, 1000, false));

            // {10/100} / {100/100} == {1000/10000}     // the denominator should not change (0.10m / 1.00m = 0.1000m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(100, 100, false))
                .Returns(new Fraction(1000, 10000, false));

            // {10/100} / {1000/1000} == {10000/100000}   // the denominator should be increased (0.10m / 1.000m = 0.10000m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(1000, 1000, false))
                .Returns(new Fraction(10000, 100000, false));

            #endregion

            #region 0.10m / 5.XX

            // {10/100} / {5/1} == {10/500}          // the denominator should be increased incrementally (x / 5 / 2 should be the same as x / 10)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(5, 1, false))
                .Returns(new Fraction(10, 500, false));

            // {10/100} / {50/10} == {100/5000}       // the denominator should be increased incrementally (x / 5.0 / 2.0 should be the same as x / 10.0)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(50, 10, false))
                .Returns(new Fraction(100, 5000, false));

            // {10/100} / {500/100} == {1000/50000}     // the denominator should be increased incrementally (x / 5.00 / 2.00 should be the same as x / 10.00)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(500, 100, false))
                .Returns(new Fraction(1000, 50000, false));

            // {10/100} / {5000/1000} == {10000/500000}   // the denominator should be increased incrementally (x / 5.000 / 2.000 should be the same as x / 10.000)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(5000, 1000, false))
                .Returns(new Fraction(10000, 500000, false));

            #endregion

            #region 0.10m / 10.XX

            // {10/100} / {10/1} == {10/1000}       // the denominator should be increased (0.10m / 10m = 0.010m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(10, 1, false))
                .Returns(new Fraction(10, 1000, false));

            // {10/100} / {100/10} == {100/10000}     // the denominator should be increased (0.10m / 10.0m = 0.0100m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(100, 10, false))
                .Returns(new Fraction(100, 10000, false));

            // {10/100} / {1000/100} == {1000/100000}   // the denominator should be increased (0.10m / 10.00m = 0.01000m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(1000, 100, false))
                .Returns(new Fraction(1000, 100000, false));

            // {10/100} / {10000/1000} == {10000/1000000} // the denominator should be increased (0.10m / 10.000m = 0.010000m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(10000, 1000, false))
                .Returns(new Fraction(10000, 1000000, false));

            #endregion

            #region 0.10m / 50.XX

            // {10/100} / {50/1} == {10/5000}       // the denominator should be increased incrementally (x / 50 / 2 should be the same as x / 100)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(50, 1, false))
                .Returns(new Fraction(10, 5000, false));

            // {10/100} / {500/10} == {100/50000}     // the denominator should be increased incrementally (x / 50.0 / 2.0 should be the same as x / 100.0)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(500, 10, false))
                .Returns(new Fraction(100, 50000, false));

            // {10/100} / {5000/100} == {1000/500000}   // the denominator should be increased incrementally (x / 50.00 / 2.00 should be the same as x / 100.00)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(5000, 100, false))
                .Returns(new Fraction(1000, 500000, false));

            // {10/100} / {50000/1000} == {10000/5000000} // the denominator should be increased incrementally (x / 50.000 / 2.000 should be the same as x / 100.000)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(50000, 1000, false))
                .Returns(new Fraction(10000, 5000000, false));

            #endregion
        }
    }
    
    [Test]
    [TestCaseSource(nameof(TestCases))]
    public Fraction The_result_should_preserve_the_number_precision(Fraction a, Fraction b) {
        var result = a.Divide(b);
        result.Multiply(b).Should().Be(a); // a / b = c => c * b = a
        return result;
    }
    public static IEnumerable<TestCaseData> OperationTestCases => TestCases.Select(x =>
        new TestCaseData((x.Arguments[0]), x.Arguments[1]));

    [Test]
    [TestCaseSource(nameof(OperationTestCases))]
    public void The_result_should_be_round_tripping(Fraction a, Fraction b) {
        var result = a.Divide(b);
        result.Multiply(b).Should().Be(a); // a / b = c => c * b = a
    }

    [Test]
    public void The_resulting_denominator_is_increased_incrementally_when_dividing_by_small_integers() {
        // Arrange
        var initialValue = new Fraction(10, 100, false);
        var expectedValue = new Fraction(10, 1000, false);
        // Act
        var dividedByTen = initialValue / 10;
        var dividedByTwoAndFive = initialValue / 2 / 5;
        var dividedByFiveAndTwo = initialValue / 5 / 2;
        // Assert
        dividedByTen.Should().Be(expectedValue);
        dividedByTwoAndFive.Should().Be(expectedValue);
        dividedByFiveAndTwo.Should().Be(expectedValue);
    }

    [Test]
    public void The_resulting_denominator_is_increased_incrementally_when_dividing_by_integers_large_and_small() {
        // Arrange
        var initialValue = new Fraction(10, 100, false);
        var expectedValue = new Fraction(10, 1_000_000, false);
        // Act
        var multipliedByTen = initialValue / 10_000;
        var multipliedByTwoAndFive = initialValue / 2_000 / 5;
        var multipliedByFiveAndTwo = initialValue / 5_000 / 2;
        // Assert
        multipliedByTen.Should().Be(expectedValue);
        multipliedByTwoAndFive.Should().Be(expectedValue);
        multipliedByFiveAndTwo.Should().Be(expectedValue);
    }

    [Test]
    public void The_resulting_denominator_is_increased_incrementally_when_dividing_by_integers_small_and_large() {
        // Arrange
        var initialValue = new Fraction(10, 100, false);
        var expectedValue = new Fraction(10, 1_000_000, false);
        // Act
        var dividedByTen = initialValue / 10_000;
        var dividedByTwoAndFive = initialValue / 5 / 2_000;
        var dividedByFiveAndTwo = initialValue / 2 / 5_000;
        // Assert
        dividedByTen.Should().Be(expectedValue);
        dividedByTwoAndFive.Should().Be(expectedValue);
        dividedByFiveAndTwo.Should().Be(expectedValue);
    }

    [Test]
    public void The_resulting_denominator_is_increased_incrementally_when_dividing_by_integers_large_and_large() {
        // Arrange
        var initialValue = new Fraction(10, 100, false);
        var expectedValue = new Fraction(10, 1_000_000_000, false);
        // Act
        var dividedByTen = initialValue / 10_000_000;
        var dividedByTwoAndFive = initialValue / 5_000 / 2_000;
        var dividedByFiveAndTwo = initialValue / 2_000 / 5_000;
        // Assert
        dividedByTen.Should().Be(expectedValue);
        dividedByTwoAndFive.Should().Be(expectedValue);
        dividedByFiveAndTwo.Should().Be(expectedValue);
    }

    [Test]
    public void The_resulting_numerator_is_increased_incrementally_when_dividing_by_one_over_small_integer() {
        // Arrange: {10/100} / {1/10} = {100/100}
        var initialValue = new Fraction(10, 100, false);
        var expectedValue = new Fraction(100, 100, false);
        // Act
        var dividedByTen = initialValue / 0.1m;
        var dividedByTwoAndFive = initialValue / 0.2m / 0.5m;
        var dividedByFiveAndTwo = initialValue / 0.5m / 0.2m;
        // Assert
        dividedByTen.Should().Be(expectedValue);
        dividedByTwoAndFive.Should().Be(expectedValue);
        dividedByFiveAndTwo.Should().Be(expectedValue);
    }

    [Test]
    public void The_resulting_numerator_is_increased_incrementally_when_dividing_by_one_over_large_integer() {
        // Arrange: {10/100} / {1/10_000} = {1/100_000}
        var initialValue = new Fraction(10, 100, false);
        var expectedValue = new Fraction(100_000, 100, false);
        // Act
        var dividedByTen = initialValue / 0.0001m;
        var dividedByTwoAndFive = initialValue / 0.0002m / 0.5m;
        var dividedByFiveAndTwo = initialValue / 0.0005m / 0.2m;
        // Assert
        dividedByTen.Should().Be(expectedValue);
        dividedByTwoAndFive.Should().Be(expectedValue);
        dividedByFiveAndTwo.Should().Be(expectedValue);
    }
}
