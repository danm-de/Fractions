﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.TryParse;

[TestFixture]
public class When_trying_to_parse_a_fraction : Spec {
    private static IEnumerable<TestCaseData> TestCases {
        get {
            yield return new TestCaseData("1/5").Returns(new Fraction(1, 5));
            yield return new TestCaseData("-1/-5").Returns(new Fraction(1, 5));
            yield return new TestCaseData("+1/5").Returns(new Fraction(1, 5));
            yield return new TestCaseData("+1/+5").Returns(new Fraction(1, 5));
            yield return new TestCaseData("1/+5").Returns(new Fraction(1, 5));

            yield return new TestCaseData("123456789987654321.123456789987654321")
                .Returns(
                    new Fraction(
                        numerator: BigInteger.Parse("123456789987654321123456789987654321"),
                        denominator: BigInteger.Pow(10, 18))
                );

            yield return new TestCaseData("-123456789987654321.123456789987654321")
                .Returns(
                    new Fraction(
                        numerator: BigInteger.Parse("-123456789987654321123456789987654321"),
                        denominator: BigInteger.Pow(10, 18))
                );

            yield return new TestCaseData("-1.23456789987654321E-24")
                .Returns(
                    new Fraction(
                        numerator: new BigInteger(-123456789987654321),
                        denominator: BigInteger.Pow(10, 17 + 24)));
        }
    }

    [Test, TestCaseSource(nameof(TestCases))]
    public Fraction? The_result_should_be_as_expected(string value) =>
        Fraction.TryParse(
            fractionString: value,
            numberStyles: NumberStyles.Number | NumberStyles.AllowExponent,
            formatProvider: CultureInfo.InvariantCulture,
            normalize: true,
            fraction: out var result)
            ? result
            : default(Fraction?);
}
