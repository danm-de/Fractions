#if NET
using System;
using System.Collections.Generic;
using System.Text.Json;
using FluentAssertions;
using Fractions.JsonConverters;
using NUnit.Framework;

namespace Fractions.Tests.Serialization.SystemTextJson;

[TestFixture]
public class If_the_user_serializes_a_fraction_using_the_SystemTextJson_serializer {
    private static IEnumerable<TestCaseData> SerializeTestCases {
        get {
            yield return new TestCaseData(Fraction.Zero)
                .Returns("""
                         {"Numerator":"0","Denominator":"1"}
                         """);
            yield return new TestCaseData(Fraction.One)
                .Returns("""
                         {"Numerator":"1","Denominator":"1"}
                         """);
            yield return new TestCaseData(new Fraction(double.MaxValue))
                .Returns("""
                         {"Numerator":"179769313486231570814527423731704356798070567525844996598917476803157260780028538760589558632766878171540458953514382464234321326889464182768467546703537516986049910576551282076245490090389328944075868508455133942304583236903222948165808559332123348274797826204144723168738177180919299881250404026184124858368","Denominator":"1"}
                         """);
            yield return new TestCaseData(new Fraction(2, 4, normalize: false))
                .Returns("""
                         {"Numerator":"2","Denominator":"4","NormalizationNotApplied":true}
                         """);
            yield return new TestCaseData(Fraction.PositiveInfinity)
                .Returns("""
                         {"Numerator":"1","Denominator":"0"}
                         """);
            yield return new TestCaseData(Fraction.NegativeInfinity)
                .Returns("""
                         {"Numerator":"-1","Denominator":"0"}
                         """);
            yield return new TestCaseData(Fraction.NaN)
                .Returns("""
                         {"Numerator":"0","Denominator":"0"}
                         """);
        }
    }

    [Test, TestCaseSource(nameof(SerializeTestCases))]
    public string Should_it_return_the_expected_result(Fraction value) {
        var json = Serialize(value);
        Console.WriteLine(json);
        return json;
    }

    private static IEnumerable<TestCaseData> DeserializeTestCases {
        get {
            yield return new TestCaseData(Fraction.Zero);
            yield return new TestCaseData(Fraction.One);
            yield return new TestCaseData(Fraction.NaN);
            yield return new TestCaseData(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity);
            yield return new TestCaseData(new Fraction(2, 4, normalize: false));
            yield return new TestCaseData(new Fraction(decimal.MaxValue));
            yield return new TestCaseData(new Fraction(decimal.MinValue));
            yield return new TestCaseData(new Fraction(double.MaxValue));
            yield return new TestCaseData(new Fraction(double.MinValue));
            yield return new TestCaseData(new Fraction(Math.PI));
        }
    }

    [Test, TestCaseSource(nameof(DeserializeTestCases))]
    public void Should_it_deserialize_to_the_same_value(Fraction value) {
        var json = Serialize(value);
        var deserializedValue = Deserialize(json);
        deserializedValue.Should().Be(value);
    }

    private static string Serialize(object obj) => JsonSerializer.Serialize(obj);

    public Fraction Deserialize(string json) => JsonSerializer.Deserialize<Fraction>(json);
}

[TestFixture]
public class If_the_user_serializes_a_fraction_using_the_SystemTextJson_serializer_with_FractionToStringJsonConverter {
    private static readonly JsonSerializerOptions SerializerOptions =
        new() {
            // use FractionToStringJsonConverter
            Converters = { new FractionToStringJsonConverter() } 
        };

    private static IEnumerable<TestCaseData> SerializeTestCases {
        get {
            yield return new TestCaseData(Fraction.Zero)
                .Returns("""
                         "0"
                         """);
            yield return new TestCaseData(Fraction.One)
                .Returns("""
                         "1"
                         """);
            yield return new TestCaseData(new Fraction(double.MaxValue))
                .Returns("""
                         "179769313486231570814527423731704356798070567525844996598917476803157260780028538760589558632766878171540458953514382464234321326889464182768467546703537516986049910576551282076245490090389328944075868508455133942304583236903222948165808559332123348274797826204144723168738177180919299881250404026184124858368"
                         """);
            yield return new TestCaseData(new Fraction(1, 2))
                .Returns("""
                         "1/2"
                         """);
            yield return new TestCaseData(Fraction.PositiveInfinity)
                .Returns("""
                         "Infinity"
                         """);
            yield return new TestCaseData(Fraction.NegativeInfinity)
                .Returns("""
                         "-Infinity"
                         """);
            yield return new TestCaseData(Fraction.NaN)
                .Returns("""
                         "NaN"
                         """);
        }
    }

    [Test, TestCaseSource(nameof(SerializeTestCases))]
    public string Should_it_return_the_expected_result(Fraction value) {
        var json = Serialize(value);
        Console.WriteLine(json);
        return json;
    }

    private static IEnumerable<TestCaseData> DeserializeTestCases {
        get {
            yield return new TestCaseData(Fraction.Zero);
            yield return new TestCaseData(Fraction.One);
            yield return new TestCaseData(Fraction.NaN);
            yield return new TestCaseData(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity);
            yield return new TestCaseData(new Fraction(1, 2));
            yield return new TestCaseData(new Fraction(decimal.MaxValue));
            yield return new TestCaseData(new Fraction(decimal.MinValue));
            yield return new TestCaseData(new Fraction(double.MaxValue));
            yield return new TestCaseData(new Fraction(double.MinValue));
            yield return new TestCaseData(new Fraction(Math.PI));
        }
    }

    [Test, TestCaseSource(nameof(DeserializeTestCases))]
    public void Should_it_deserialize_to_the_same_value(Fraction value) {
        var json = Serialize(value);
        var deserializedValue = Deserialize(json);
        deserializedValue.Should().Be(value);
    }

    private static string Serialize(object obj) =>
        JsonSerializer.Serialize(obj, options: SerializerOptions);

    public Fraction Deserialize(string json) =>
        JsonSerializer.Deserialize<Fraction>(json, options: SerializerOptions);
}
#endif
