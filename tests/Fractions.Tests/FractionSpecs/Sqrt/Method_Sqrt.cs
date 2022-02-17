using System;
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

        
        private bool SqrtCompareToDouble(double testValue) {

            var fractionSqrt = Fraction.FromDouble(testValue).Sqrt();
            var doubleSqrt = Math.Sqrt(testValue);

            return fractionSqrt.ToDouble() == doubleSqrt;            
        }

        [Test]
        public void Sqrt_Of_values() {

            SqrtCompareToDouble(0.001).Should().BeTrue();
            SqrtCompareToDouble(5).Should().BeTrue();  
            SqrtCompareToDouble(4.54854751).Should().BeTrue();
            SqrtCompareToDouble(9999999855487).Should().BeTrue();
            SqrtCompareToDouble(99999998554865557).Should().BeTrue();
            SqrtCompareToDouble(Math.PI).Should().BeTrue();

        }





    }
}
