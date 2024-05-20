using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using Fractions.TypeConverters;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.TypeConverters.FractionTypeConverterSpecs.ConvertFrom;

[TestFixture]
public class When_converting_a_type_to_Fraction : Spec {
    private FractionTypeConverter _converter;

    public override void SetUp() {
        _converter = new FractionTypeConverter();
    }

    private static IEnumerable<TestCaseData> TypeTests {
        get {
            yield return new TestCaseData(typeof(Fraction)).Returns(true);
            yield return new TestCaseData(typeof(int)).Returns(true);
            yield return new TestCaseData(typeof(long)).Returns(true);
            yield return new TestCaseData(typeof(decimal)).Returns(true);
            yield return new TestCaseData(typeof(double)).Returns(true);
            yield return new TestCaseData(typeof(string)).Returns(true);
            yield return new TestCaseData(typeof(BigInteger)).Returns(true);

            yield return new TestCaseData(typeof(bool)).Returns(false);
            yield return new TestCaseData(typeof(object)).Returns(false);
        }
    }

    [Test]
    [TestCaseSource(nameof(TypeTests))]
    public bool CanConvertFrom_ShouldReturnCorrectResult(Type destinationType) {
        return _converter.CanConvertFrom(destinationType);
    }

    private static IEnumerable<TestCaseData> ConvertFromTests {
        get {
            yield return new TestCaseData(Fraction.One, CultureInfo.CurrentCulture)
                .Returns(Fraction.One);
            yield return new TestCaseData(new Fraction(1, 2), CultureInfo.CurrentCulture)
                .Returns(new Fraction(1, 2));

            yield return new TestCaseData(0, CultureInfo.CurrentCulture).SetName("0 (integer)")
                .Returns(Fraction.Zero);
            yield return new TestCaseData(1, CultureInfo.CurrentCulture).SetName("1 (integer)")
                .Returns(Fraction.One);
            yield return new TestCaseData(-1, CultureInfo.CurrentCulture).SetName("-1 (integer)")
                .Returns(new Fraction(-1));

            yield return new TestCaseData(0L, CultureInfo.CurrentCulture).SetName("0 (long)")
                .Returns(Fraction.Zero);
            yield return new TestCaseData(1L, CultureInfo.CurrentCulture).SetName("1 (long)")
                .Returns(Fraction.One);
            yield return new TestCaseData(-1L, CultureInfo.CurrentCulture).SetName("-1 (long)")
                .Returns(new Fraction(-1));

            yield return new TestCaseData(BigInteger.Zero, CultureInfo.CurrentCulture)
                .SetName("0 (big integer)")
                .Returns(Fraction.Zero);
            yield return new TestCaseData(BigInteger.One, CultureInfo.CurrentCulture)
                .SetName("1 (big integer)")
                .Returns(Fraction.One);
            yield return new TestCaseData(BigInteger.MinusOne, CultureInfo.CurrentCulture)
                .SetName("-1 (big integer)")
                .Returns(new Fraction(-1));

            yield return new TestCaseData(1m, CultureInfo.CurrentCulture)
                .Returns(Fraction.One);
            yield return new TestCaseData(0.5m, CultureInfo.CurrentCulture)
                .Returns(new Fraction(1, 2));

            yield return new TestCaseData(1d, CultureInfo.CurrentCulture)
                .Returns(Fraction.One);
            yield return new TestCaseData(0.5d, CultureInfo.CurrentCulture)
                .Returns(new Fraction(1, 2));

            yield return new TestCaseData("1", CultureInfo.CurrentCulture)
                .Returns(new Fraction(1));
            yield return new TestCaseData("123", CultureInfo.CurrentCulture)
                .Returns(new Fraction(123));
            yield return new TestCaseData("1/2", CultureInfo.CurrentCulture)
                .Returns(new Fraction(1, 2));
            yield return new TestCaseData("-1/2", CultureInfo.CurrentCulture)
                .Returns(new Fraction(-1, 2));
            yield return new TestCaseData("1/-2", CultureInfo.CurrentCulture)
                .Returns(new Fraction(-1, 2));
            yield return new TestCaseData("-1/-2", CultureInfo.CurrentCulture)
                .Returns(new Fraction(1, 2));

            yield return new TestCaseData("0,5", CultureInfo.GetCultureInfo("de-DE"))
                .Returns(new Fraction(1, 2));
            yield return new TestCaseData("-0,5", CultureInfo.GetCultureInfo("de-DE"))
                .Returns(new Fraction(-1, 2));
            yield return new TestCaseData("0.5", CultureInfo.GetCultureInfo("en-US"))
                .Returns(new Fraction(1, 2));
            yield return new TestCaseData("-0.5", CultureInfo.GetCultureInfo("en-US"))
                .Returns(new Fraction(-1, 2));
            yield return new TestCaseData("-0.125", CultureInfo.GetCultureInfo("en-US"))
                .Returns(new Fraction(-1, 8));

            yield return new TestCaseData(null, CultureInfo.CurrentCulture)
                .Returns(Fraction.Zero);
        }
    }

    [Test]
    [TestCaseSource(nameof(ConvertFromTests))]
    public Fraction ConvertFrom_ShouldReturnCorrectResult(object value, CultureInfo cultureInfo) {
        // ReSharper disable once PossibleNullReferenceException
        var result = (Fraction)_converter.ConvertFrom(null, cultureInfo, value);
        Console.WriteLine("Type: {0}, Result: {1}", value?.GetType(), result);

        return result;
    }
}
