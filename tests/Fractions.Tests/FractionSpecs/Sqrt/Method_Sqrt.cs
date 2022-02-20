using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Sqrt {

    [TestFixture]
    public class If_the_Sqrt_function_is_called : Spec {
        [Test]
        public void Sqrt_Of_1_Shall_Be_1() {
            Fraction.One.Sqrt()
                .Should().Be(1);
        }

        [Test]
        public void Sqrt_Of_MinusOne_Shall_Be_Fail() {

            Action act = () => Fraction.MinusOne.Sqrt();

            act.Should().Throw<OverflowException>()
                        .WithMessage("Cannot calculate square root from a negative number");
        }

        private static IEnumerable<TestCaseData> TestCases {
            get {
                yield return new TestCaseData(0.001);
                yield return new TestCaseData(5);
                yield return new TestCaseData(4.54854751);
                yield return new TestCaseData(9999999855487);
                yield return new TestCaseData(99999998554865557);
                yield return new TestCaseData(Math.PI);
            }
        }

        [Test,TestCaseSource(nameof(TestCases))]
        public void Should_the_result_be_equal_to_Math_Sqrt(double value) {
            var expected = Math.Sqrt(value);
            var actual = Fraction.FromDouble(value).Sqrt();
            actual.ToDouble().Should().Be(expected);
        }
    }
}
