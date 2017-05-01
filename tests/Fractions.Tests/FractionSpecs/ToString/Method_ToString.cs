using System;
using System.Collections.Generic;
using System.Globalization;
using Fractions.Formatter;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.ToString
{
    [TestFixture]
    public class If_the_user_calls_ToString : Spec {
        private static IEnumerable<TestCaseData> TestCases {
            get {
                yield return new TestCaseData(new Fraction(0, 3))
                    .Returns("0/0");
                yield return new TestCaseData(new Fraction(1, 3))
                    .Returns("1/3");
                yield return new TestCaseData(new Fraction(-1, 3))
                    .Returns("-1/3");
                yield return new TestCaseData(new Fraction(1, -3, false))
                    .Returns("1/-3");
                yield return new TestCaseData(new Fraction(-1, -3, false))
                    .Returns("-1/-3");
            }
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public string Shall_the_text_output_be_the_expected_one(Fraction fraction) {
            return fraction.ToString();
        }

    }

    [TestFixture]
    public class If_the_user_calls_ToString_using_a_format_string : Spec {
        private static IEnumerable<TestCaseData> TestCases {
            get {
                var de = new CultureInfo("de-DE");
                var en = new CultureInfo("en-US");

                yield return new TestCaseData(new Fraction(1, 3), string.Empty, en)
                    .Returns("1/3");
                yield return new TestCaseData(new Fraction(1, 3), null, en)
                    .Returns("1/3");

                yield return new TestCaseData(new Fraction(0, 3), "G", de)
                    .Returns("0/0");
                yield return new TestCaseData(new Fraction(1, 3), "G", de)
                    .Returns("1/3");
                yield return new TestCaseData(new Fraction(3, 1), "G", de)
                    .Returns("3");
                yield return new TestCaseData(new Fraction(1, 3), "G", new DefaultFractionFormatProvider())
                    .Returns("1/3");
                yield return new TestCaseData(new Fraction(1, 3), "G", en)
                    .Returns("1/3");
                yield return new TestCaseData(new Fraction(-1, 3), "G", en)
                    .Returns("-1/3");
                yield return new TestCaseData(new Fraction(1, -3, false), "G", en)
                    .Returns("1/-3");
                yield return new TestCaseData(new Fraction(-1, -3, false), "G", en)
                    .Returns("-1/-3");

                yield return new TestCaseData(new Fraction(-1, -3, false), "n", en)
                    .Returns("-1");
                yield return new TestCaseData(new Fraction(3, 1), "n", de)
                    .Returns("3");

                yield return new TestCaseData(new Fraction(-1, -3, false), "d", en)
                    .Returns("-3");
                yield return new TestCaseData(new Fraction(-1, -3, false), "d d", en)
                    .Returns("-3 -3");
                yield return new TestCaseData(new Fraction(3, 1), "d", de)
                    .Returns("1");

                yield return new TestCaseData(new Fraction(1, 3), "n/d", en)
                    .Returns("1/3");
                
                yield return new TestCaseData(new Fraction(3, 1), "z", de)
                    .Returns("3");
                yield return new TestCaseData(new Fraction(1, 3), "z", de)
                    .Returns("0");
                yield return new TestCaseData(new Fraction(1, 2), "z", de)
                    .Returns("0");
                yield return new TestCaseData(new Fraction(1, 2), "r", de)
                    .Returns("1/2");
                yield return new TestCaseData(new Fraction(1, -2), "r", de)
                    .Returns("-1/2");

                yield return new TestCaseData(new Fraction(3, 2), "m", de)
                    .Returns("1 1/2");
                yield return new TestCaseData(new Fraction(-3, 2), "m", de)
                    .Returns("-1 1/2");
                yield return new TestCaseData(new Fraction(-1, 2), "m", de)
                    .Returns("-1/2");
                yield return new TestCaseData(new Fraction(1, 2), "m", de)
                    .Returns("1/2");
                yield return new TestCaseData(new Fraction(2, 1), "m", de)
                    .Returns("2");
                yield return new TestCaseData(new Fraction(-2, 1), "m", de)
                    .Returns("-2");
            }
        }

        [Test,TestCaseSource(nameof(TestCases))]
        public string Shall_the_text_output_be_the_expected_one(Fraction fraction, string format, IFormatProvider cultureInfo) {
            return fraction.ToString(format, cultureInfo);
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public string Shall_the_text_output_be_the_expected_one_when_using_the_simple_ToString_method(Fraction fraction, string format, IFormatProvider cultureInfo) {
            return fraction.ToString(format);
        }
    }
}