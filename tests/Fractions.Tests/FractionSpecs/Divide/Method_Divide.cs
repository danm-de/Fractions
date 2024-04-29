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
        _a = new Fraction(2, 1, false);
        _b = new Fraction(2, 4, false);
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
    // German: Das Ergebnis sollte minus 4 sein
    public void The_result_should_be_minus_4() {
        _result.Should().Be(new Fraction(-4, 1));
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
    // German: Das Ergebnis sollte 0 sein
    public void The_result_should_be_0() {
        _result.Should().Be(Fraction.Zero);
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
