using System;
using System.Collections;
using System.Numerics;
using Fractions.TypeConverters;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.TypeConverters.FractionTypeConverterSpecs.ConvertTo {
    [TestFixture]
    public class If_the_user_wants_to_convert_a_Fraction_to_another_type : Spec {
        private FractionTypeConverter _converter;

        public override void SetUp() {
            _converter = new FractionTypeConverter();
        }

        private static IEnumerable TypeTests {
            get {
                yield return new TestCaseData(typeof (Fraction)).Returns(true);
                yield return new TestCaseData(typeof (int)).Returns(true);
                yield return new TestCaseData(typeof (long)).Returns(true);
                yield return new TestCaseData(typeof (decimal)).Returns(true);
                yield return new TestCaseData(typeof (double)).Returns(true);
                yield return new TestCaseData(typeof (string)).Returns(true);
                yield return new TestCaseData(typeof (BigInteger)).Returns(true);

                yield return new TestCaseData(typeof (bool)).Returns(false);
                yield return new TestCaseData(typeof (object)).Returns(false);
            }
        }

        [Test, TestCaseSource(nameof(TypeTests))]
        public bool Shall_the_result_of_CanConvertTo_be_correct(Type destinationType) {
            return _converter.CanConvertTo(destinationType);
        }

        private static IEnumerable ConvertToTests {
            get {
                yield return new TestCaseData(Fraction.One, typeof (Fraction)).Returns(Fraction.One);
                yield return new TestCaseData(new Fraction(1, 2), typeof (Fraction)).Returns(new Fraction(1, 2));

                yield return new TestCaseData(Fraction.Zero, typeof (int)).Returns(0);
                yield return new TestCaseData(Fraction.One, typeof (int)).Returns(1);
                yield return new TestCaseData(new Fraction(-1), typeof (int)).Returns(-1);
                yield return new TestCaseData(new Fraction(1, 2), typeof (int)).Returns(0);
                yield return new TestCaseData(new Fraction(-1, 2), typeof (int)).Returns(0);

                yield return new TestCaseData(Fraction.One, typeof (long)).Returns(1L);
                yield return new TestCaseData(new Fraction(1, 2), typeof (long)).Returns(0L);

                yield return new TestCaseData(Fraction.One, typeof (decimal)).Returns(1m);
                yield return new TestCaseData(new Fraction(1, 2), typeof (decimal)).Returns(0.5m);

                yield return new TestCaseData(Fraction.One, typeof (double)).Returns(1d);
                yield return new TestCaseData(new Fraction(1, 2), typeof (double)).Returns(0.5d);

                yield return new TestCaseData(Fraction.One, typeof (string)).Returns("1");
                yield return new TestCaseData(new Fraction(1, 2), typeof (string)).Returns("1/2");

                yield return new TestCaseData(Fraction.One, typeof (BigInteger)).Returns(BigInteger.One);
                yield return new TestCaseData(new Fraction(1, 2), typeof (BigInteger)).Returns(BigInteger.Zero);
                yield return new TestCaseData(new Fraction(-2, 1), typeof (BigInteger)).Returns(new BigInteger(-2));
            }
        }

        [Test, TestCaseSource(nameof(ConvertToTests))]
        public object Shall_the_result_of_ConvertTo_be_correct(Fraction value, Type destinationType) {
            var result = _converter.ConvertTo(value, destinationType);
            // ReSharper disable once PossibleNullReferenceException
            Console.WriteLine("Type: {0}, Value: {1}", result.GetType(), result);

            return result;
        }
    }
}