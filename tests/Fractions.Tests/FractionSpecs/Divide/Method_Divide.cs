using System.Collections.Generic;
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
        _result.IsNaN.Should().BeTrue();
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
        Assert.That(_result, Is.EqualTo(new Fraction(8, 2, false)).Using(StrictTestComparer.Instance));
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
            yield return new TestCaseData(Fraction.NaN, Fraction.NaN, Fraction.NaN);
            // NaN with any number
            yield return new TestCaseData(Fraction.NaN, Fraction.PositiveInfinity, Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(5, 4), Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(-5, -5, false), Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.One, Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(4, 5), Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.Zero, Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.MinusOne, Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(-5, 4), Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(-4, 5), Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(5, -5, false), Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.NegativeInfinity, Fraction.NaN);
            // Any number with NaN
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NaN, Fraction.NaN);
            yield return new TestCaseData(new Fraction(5, 4), Fraction.NaN, Fraction.NaN);
            yield return new TestCaseData(Fraction.One, Fraction.NaN, Fraction.NaN);
            yield return new TestCaseData(new Fraction(4, 5), Fraction.NaN, Fraction.NaN);
            yield return new TestCaseData(Fraction.Zero, Fraction.NaN, Fraction.NaN);
            yield return new TestCaseData(Fraction.MinusOne, Fraction.NaN, Fraction.NaN);
            yield return new TestCaseData(new Fraction(-5, 4), Fraction.NaN, Fraction.NaN);
            yield return new TestCaseData(new Fraction(-4, 5), Fraction.NaN, Fraction.NaN);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NaN, Fraction.NaN);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void The_result_is_always_NaN(Fraction a, Fraction b, Fraction expected) {
        var result = a.Divide(b);
        Assert.That(result, Is.EqualTo(expected).Using(StrictTestComparer.Instance));
    }
}

[TestFixture]
public class When_dividing_infinity {
    private static IEnumerable<TestCaseData> TestCases {
        get {
            // positive infinity with positive infinity
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.PositiveInfinity, Fraction.NaN);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(5, 0, false), Fraction.NaN);

            // positive infinity with any other number
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(5, 4), Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.One, Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(4, 5), Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.Zero, Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.MinusOne, Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(-5, 4), Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(-4, 5), Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NegativeInfinity, Fraction.NaN);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(-5, 0, false), Fraction.NaN);

            // negative infinity with negative infinity
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NegativeInfinity, Fraction.NaN);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-5, 0, false), Fraction.NaN);

            // negative infinity with any other number
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(5, 4), Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.One, Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(4, 5), Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.Zero, Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.MinusOne, Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-5, 4), Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-4, 5), Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.PositiveInfinity, Fraction.NaN);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-5, 0, false), Fraction.NaN);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void The_result_is_always_NaN_or_Infinity(Fraction a, Fraction b, Fraction expected) {
        var result = a.Divide(b);
        Assert.That(result, Is.EqualTo(expected).Using(StrictTestComparer.Instance));
    }
}

[TestFixture]
public class When_dividing_with_infinity {
    private static IEnumerable<TestCaseData> TestCases {
        get {
            // positive infinity divided by positive infinity
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.PositiveInfinity, Fraction.NaN);
            yield return new TestCaseData(new Fraction(5, 0, false), Fraction.PositiveInfinity, Fraction.NaN);

            // any other number divided by positive infinity
            yield return new TestCaseData(new Fraction(5, 4), Fraction.PositiveInfinity, Fraction.Zero);
            yield return new TestCaseData(Fraction.One, Fraction.PositiveInfinity, Fraction.Zero);
            yield return new TestCaseData(new Fraction(4, 5), Fraction.PositiveInfinity, Fraction.Zero);
            yield return new TestCaseData(Fraction.Zero, Fraction.PositiveInfinity, Fraction.Zero);
            yield return new TestCaseData(Fraction.MinusOne, Fraction.PositiveInfinity, Fraction.Zero);
            yield return new TestCaseData(new Fraction(-5, 4), Fraction.PositiveInfinity, Fraction.Zero);
            yield return new TestCaseData(new Fraction(-4, 5), Fraction.PositiveInfinity, Fraction.Zero);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.PositiveInfinity, Fraction.NaN);
            yield return new TestCaseData(new Fraction(-5, 0, false), Fraction.PositiveInfinity, Fraction.NaN);

            // negative infinity divided by negative infinity
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NegativeInfinity, Fraction.NaN);
            yield return new TestCaseData(new Fraction(-5, 0, false), Fraction.NegativeInfinity, Fraction.NaN);

            // any other number divided by negative infinity 
            yield return new TestCaseData(new Fraction(5, 4), Fraction.NegativeInfinity, Fraction.Zero);
            yield return new TestCaseData(Fraction.One, Fraction.NegativeInfinity, Fraction.Zero);
            yield return new TestCaseData(new Fraction(4, 5), Fraction.NegativeInfinity, Fraction.Zero);
            yield return new TestCaseData(Fraction.Zero, Fraction.NegativeInfinity, Fraction.Zero);
            yield return new TestCaseData(Fraction.MinusOne, Fraction.NegativeInfinity, Fraction.Zero);
            yield return new TestCaseData(new Fraction(-5, 4), Fraction.NegativeInfinity, Fraction.Zero);
            yield return new TestCaseData(new Fraction(-4, 5), Fraction.NegativeInfinity, Fraction.Zero);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NegativeInfinity, Fraction.NaN);
            yield return new TestCaseData(new Fraction(-5, 0, false), Fraction.NegativeInfinity, Fraction.NaN);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void The_result_is_always_Zero_or_NaN(Fraction a, Fraction b, Fraction expected) {
        var result = a.Divide(b);
        Assert.That(result, Is.EqualTo(expected).Using(StrictTestComparer.Instance));
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
        _result.IsNaN.Should().BeTrue();
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
        _result.IsNaN.Should().BeTrue();
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
        _result.IsNaN.Should().BeTrue();
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
        _result.IsNaN.Should().BeTrue();
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
        _result.IsNaN.Should().BeTrue();
    }
}

[TestFixture]
public class When_dividing_zero {
    private static IEnumerable<TestCaseData> TestCases {
        get {
            
            // {0/1} / {1/10} = Zero
            yield return new TestCaseData(
                Fraction.Zero,
                new Fraction(1, 10, false));

            // {0/-1} / {1/10} = Zero
            yield return new TestCaseData(
                new Fraction(0, -1, false),
                new Fraction(1, 10, false));

            // {0/10} / {1/10} = Zero
            yield return new TestCaseData(
                new Fraction(0, 10, false),
                new Fraction(1, 10, false));

            // {0/-10} / {1/10} = Zero
            yield return new TestCaseData(
                new Fraction(0, -10, false),
                new Fraction(1, 10, false));

            // {0/-10} / {-1/10} = Zero
            yield return new TestCaseData(
                new Fraction(0, -10, false),
                new Fraction(-1, 10, false));
            
            // {0/-10} / {-1/-10} = Zero
            yield return new TestCaseData(
                new Fraction(0, -10, false),
                new Fraction(-1, -10, false));
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void The_result_is_Zero_or_NaN(Fraction a, Fraction b) {
        var result = a.Divide(b);
        Assert.That(result, Is.EqualTo(Fraction.Zero).Using(StrictTestComparer.Instance));
    }
}

[TestFixture]
public class When_dividing_without_normalization {
    private static IEnumerable<TestCaseData> PositiveResultCases {
        get {
            #region 0.1m / 0.1XX

            // {1/10} / {1/10} == {1/1} 
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(1, 10, false),
                new Fraction(1, 1, false));

            // {1/10} / {10/100} == {10/10}
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(10, 100, false),
                new Fraction(10, 10, false));

            // {1/10} / {100/1000} == {100/100}
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(100, 1000, false),
                new Fraction(100, 100, false));

            #endregion

            #region 0.1m / 0.5XX
            
            // {1/10} / {5/10} == {1/5}
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(5, 10, false),
                new Fraction(1, 5, false));
            // {1/10} / {50/100} == {10/50}
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(50, 100, false),
                new Fraction(10, 50, false));
            // {1/10} / {500/1000} == {100/500}
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(500, 1000, false),
                new Fraction(100, 500, false));
            
            #endregion
            
            #region 0.1m / 1.XX
            
            // {1/10} / {1/1} == {1/10}
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(1, 1, false),
                new Fraction(1, 10, false));
            // {1/10} / {10/10} == {1/10}      
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(10, 10, false),
                new Fraction(1, 10, false));
            // {1/10} / {100/100} == {10/100}   
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(100, 100, false),
                new Fraction(10, 100, false));
            
            #endregion
            
            #region 0.1m / 5.XX
            
            // {1/10} / {5/1} == {1/50}
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(5, 1, false),
                new Fraction(1, 50, false));
            // {1/10} * {50/10} == {1/50}       
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(50, 10, false),
                new Fraction(1, 50, false));
            // {1/10} * {500/100} == {10/500}
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(500, 100, false),
                new Fraction(10, 500, false));
            
            #endregion
            
            #region 0.1m / 10.XX
            
            // {1/10} / {10/1} == {1/100}        
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(10, 1, false),
                new Fraction(1, 100, false));
            // {1/10} / {100/10} == {1/100}     
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(100, 10, false),
                new Fraction(1, 100, false));
            // {1/10} / {1000/100} == {10/1000}
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(1000, 100, false),
                new Fraction(10, 1000, false));
            
            #endregion
            
            #region 0.1m / 50.XX
            
            // {1/10} / {50/1} == {1/500}
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(50, 1, false),
                new Fraction(1, 500, false));
            // {1/10} / {500/10} == {1/500}
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(500, 10, false),
                new Fraction(1, 500, false));
            // {1/10} / {5000/100} == {10/5000}
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(5000, 100, false),
                new Fraction(10, 5000, false));
            
            #endregion
            
            #region 0.10m / 0.1XX
            
            // {10/100} / {1/10} == {10/10}
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(1, 10, false),
                new Fraction(10, 10, false));
            // {10/100} / {10/100} == {10/10}
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(10, 100, false),
                new Fraction(10, 10, false));
            // {10/100} / {100/1000} == {100/100}
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(100, 1000, false),
                new Fraction(100, 100, false));
            // {10/100} / {1000/10000} == {1000/1000}
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(1000, 10000, false),
                new Fraction(1000, 1000, false));
            
            #endregion
            
            #region 0.10m / 0.5XX
            
            // {10/100} / {5/10} == {10/50}
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(5, 10, false),
                new Fraction(10, 50, false));
            // {10/100} / {50/100} == {10/50}  
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(50, 100, false),
                new Fraction(10, 50, false));
            // {10/100} / {500/1000} == {100/500}  
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(500, 1000, false),
                new Fraction(100, 500, false));
            // {10/100} / {5000/10000} == {1000/5000} 
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(5000, 10000, false),
                new Fraction(1000, 5000, false));
            
            #endregion
            
            #region 0.10m / 1.XX
            
            // {10/100} / {1/1} == {10/100}
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(1, 1, false),
                new Fraction(10, 100, false));
            // {10/100} / {10/10} == {10/100}       
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(10, 10, false),
                new Fraction(10, 100, false));
            // {10/100} / {100/100} == {10/100}  
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(100, 100, false),
                new Fraction(10, 100, false));
            // {10/100} / {1000/1000} == {100/1000}  
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(1000, 1000, false),
                new Fraction(100, 1000, false));
            
            #endregion
            
            #region 0.10m / 5.XX
            
            // {10/100} / {5/1} == {10/500}         
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(5, 1, false),
                new Fraction(10, 500, false));
            // {10/100} / {50/10} == {10/500}       
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(50, 10, false),
                new Fraction(10, 500, false));
            // {10/100} / {500/100} == {10/500}    
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(500, 100, false),
                new Fraction(10, 500, false));
            // {10/100} / {5000/1000} == {100/5000}  
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(5000, 1000, false),
                new Fraction(100, 5000, false));
            
            #endregion
            
            #region 0.10m / 10.XX
            
            // {10/100} / {10/1} == {10/1000}      
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(10, 1, false),
                new Fraction(10, 1000, false));
            // {10/100} / {100/10} == {10/1000}    
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(100, 10, false),
                new Fraction(10, 1000, false));
            // {10/100} / {1000/100} == {10/1000}   
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(1000, 100, false),
                new Fraction(10, 1000, false));
            // {10/100} / {10000/1000} == {100/10000}
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(10000, 1000, false),
                new Fraction(100, 10000, false));
            
            #endregion
            
            #region 0.10m / 50.XX
            
            // {10/100} / {50/1} == {10/5000}      
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(50, 1, false),
                new Fraction(10, 5000, false));
            // {10/100} / {500/10} == {10/5000}     
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(500, 10, false),
                new Fraction(10, 5000, false));
            // {10/100} / {5000/100} == {10/5000}   
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(5000, 100, false),
                new Fraction(10, 5000, false));
            // {10/100} / {50000/1000} == {100/50000} 
            yield return new TestCaseData(
                new Fraction(10, 100, false),
                new Fraction(50000, 1000, false),
                new Fraction(100, 50000, false));
            
            #endregion
            
            #region other values
            
            // {1/10} / {3/10} == {1/3} 
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(3, 10, false),
                new Fraction(1, 3, false));
            
            // 1/3 / 10/1 == {1/30}
            yield return new TestCaseData(
                new Fraction(1, 3, false),
                new Fraction(10, 1, false),
                new Fraction(1, 30, false));
            
            // {20/10} / {25/10} = {(0 + 20/25) / (1 + 0/10)} = {(20/25)/(1)} = {20/25}
            yield return new TestCaseData(
                new Fraction(20, 10, false),
                new Fraction(25, 10, false),
                new Fraction(20, 25, false));
            
            // {9/7} / {4/3} = {(2 + 1/4) / (2 + 1/3)} = {(9/4)/(7/3)} = {27/28}
            yield return new TestCaseData(
                new Fraction(9, 7, false),
                new Fraction(4, 3, false),
                new Fraction(27, 28, false));
            
            #endregion
        }
    }

    [Test]
    [TestCaseSource(nameof(PositiveResultCases))]
    public void The_terms_expansion_is_constrained(Fraction a, Fraction b, Fraction expectedValue) {
        // positive results
        a.Divide(b).Should().Be(expectedValue, "Both a / b and the expectedValue should reduce to the same fraction");
        Assert.That(a.Divide(b), Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance)); // a / b = c
        Assert.That(a.Negate().Divide(b.Negate()), Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance)); // -a / -b = c
        Assert.That(a.Reciprocal().Divide(b.Reciprocal()), Is.EqualTo(expectedValue.Reciprocal())); // 1/a / 1/b = 1/c (equivalent)
        Assert.That(a.Reciprocal().Negate().Divide(b.Reciprocal().Negate()), Is.EqualTo(expectedValue.Reciprocal())); // -1/a / -1/b = 1/c (equivalent)
        Assert.That(a.Reciprocal().Negate().Divide(b.Negate().Reciprocal()), Is.EqualTo(expectedValue.Reciprocal())); // -1/a / 1/-b = 1/c (equivalent)
        Assert.That(a.Negate().Reciprocal().Divide(b.Reciprocal().Negate()), Is.EqualTo(expectedValue.Reciprocal())); // 1/-a / -1/b = 1/c (equivalent)
        Assert.That(a.Negate().Reciprocal().Divide(b.Negate().Reciprocal()), Is.EqualTo(expectedValue.Reciprocal())); // 1/-a / 1/-b = 1/c (equivalent)
        Assert.That(a.Negate().Reciprocal().Negate().Divide(b.Negate().Reciprocal().Negate()), Is.EqualTo(expectedValue.Reciprocal())); // -1/-a / -1/-b = 1/c (equivalent)

        // negative results
        Assert.That(a.Negate().Divide(b), Is.EqualTo(expectedValue.Negate()).Using(StrictTestComparer.Instance)); // -a / b = -c
        Assert.That(a.Divide(b.Negate()), Is.EqualTo(expectedValue.Negate()).Using(StrictTestComparer.Instance)); // a / -b = -c
        Assert.That(a.Reciprocal().Negate().Divide(b.Reciprocal()), Is.EqualTo(expectedValue.Reciprocal().Negate())); // -1/a / 1/b = -1/c (equivalent)
        Assert.That(a.Reciprocal().Divide(b.Reciprocal().Negate()), Is.EqualTo(expectedValue.Reciprocal().Negate())); // 1/a / -1/b = -1/c (equivalent)
        Assert.That(a.Reciprocal().Divide(b.Negate().Reciprocal()), Is.EqualTo(expectedValue.Reciprocal().Negate())); // 1/a / 1/-b = -1/c (equivalent)
        Assert.That(a.Negate().Reciprocal().Divide(b.Reciprocal()), Is.EqualTo(expectedValue.Reciprocal().Negate())); // 1/-a / 1/b = -1/c (equivalent)
        Assert.That(a.Negate().Reciprocal().Negate().Divide(b.Negate().Reciprocal()), Is.EqualTo(expectedValue.Reciprocal().Negate())); // -1/-a / 1/-b = -1/c (equivalent)
        Assert.That(a.Negate().Reciprocal().Divide(b.Negate().Reciprocal().Negate()), Is.EqualTo(expectedValue.Reciprocal().Negate())); // 1/-a / -1/-b = -1/c (equivalent)
    }
    
    [Test]
    public void The_resulting_denominator_is_increased_incrementally_when_dividing_by_small_integers() {
        // Arrange
        var initialValue = new Fraction(10, 100, false);
        var expectedValue = new Fraction(10, 1_000, false);
        // Act
        var dividedByTen = initialValue / 10;
        var dividedByTwoAndFive = initialValue / 2 / 5;
        var dividedByFiveAndTwo = initialValue / 5 / 2;
        // Assert
        Assert.That(dividedByTen, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(dividedByTwoAndFive, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(dividedByFiveAndTwo, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
    }

    [Test]
    public void The_resulting_denominator_is_increased_incrementally_when_dividing_by_integers_large_and_small() {
        // Arrange
        var initialValue = new Fraction(10, 100, false);
        var expectedValue = new Fraction(10, 1_000_000, false);
        // Act
        var dividedByTen = initialValue / 10_000;
        var dividedByTwoAndFive = initialValue / 2_000 / 5;
        var dividedByFiveAndTwo = initialValue / 5_000 / 2;
        // Assert
        Assert.That(dividedByTen, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(dividedByTwoAndFive, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(dividedByFiveAndTwo, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
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
        Assert.That(dividedByTen, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(dividedByTwoAndFive, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(dividedByFiveAndTwo, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
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
        Assert.That(dividedByTen, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(dividedByTwoAndFive, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(dividedByFiveAndTwo, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
    }

    [Test]
    public void The_resulting_numerator_is_increased_incrementally_when_dividing_by_one_over_small_integer() {
        // Arrange: {10/100} / {1/10} = {100/100}
        var initialValue = new Fraction(10, 100, false);
        var expectedValue = new Fraction(10, 10, false);
        // Act
        var dividedByTen = initialValue / 0.1m;
        var dividedByTwoAndFive = initialValue / 0.2m / 0.5m;
        var dividedByFiveAndTwo = initialValue / 0.5m / 0.2m;
        // Assert
        Assert.That(dividedByTen, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(dividedByTwoAndFive, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(dividedByFiveAndTwo, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
    }

    [Test]
    public void The_resulting_numerator_is_increased_incrementally_when_dividing_by_one_over_large_integer() {
        // Arrange: {10/100} / {1/10_000} = {1/100_000}
        var initialValue = new Fraction(10, 100, false);
        var expectedValue = new Fraction(1_000, 1, false);
        // Act
        var dividedByTen = initialValue / 0.0001m;
        var dividedByTwoAndFive = initialValue / 0.0002m / 0.5m;
        var dividedByFiveAndTwo = initialValue / 0.0005m / 0.2m;
        // Assert
        Assert.That(dividedByTen, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(dividedByTwoAndFive, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(dividedByFiveAndTwo, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
    }
}
