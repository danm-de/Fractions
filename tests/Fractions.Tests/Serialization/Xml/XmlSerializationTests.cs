using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using FluentAssertions;
using NUnit.Framework;

namespace Fractions.Tests.Serialization.Xml;

[TestFixture]
public class If_the_user_serializes_a_fraction_using_the_XML_serializer {
    private readonly XmlSerializer _serializer = new(typeof(Fraction));

    private static IEnumerable<TestCaseData> SerializeTestCases {
        get {
            yield return new TestCaseData(Fraction.Zero)
                .Returns("""
                         <?xml version="1.0" encoding="utf-16"?><Fraction><Numerator>0</Numerator><Denominator>1</Denominator></Fraction>
                         """);
            yield return new TestCaseData(Fraction.One)
                .Returns("""
                         <?xml version="1.0" encoding="utf-16"?><Fraction><Numerator>1</Numerator><Denominator>1</Denominator></Fraction>
                         """);
            yield return new TestCaseData(new Fraction(2, 4, normalize: false))
                .Returns("""
                         <?xml version="1.0" encoding="utf-16"?><Fraction><Numerator>2</Numerator><Denominator>4</Denominator><NormalizationNotApplied>True</NormalizationNotApplied></Fraction>
                         """);
            yield return new TestCaseData(Fraction.PositiveInfinity)
                .Returns("""
                         <?xml version="1.0" encoding="utf-16"?><Fraction><Numerator>1</Numerator><Denominator>0</Denominator></Fraction>
                         """);
            yield return new TestCaseData(Fraction.NegativeInfinity)
                .Returns("""
                         <?xml version="1.0" encoding="utf-16"?><Fraction><Numerator>-1</Numerator><Denominator>0</Denominator></Fraction>
                         """);
            yield return new TestCaseData(Fraction.NaN)
                .Returns("""
                         <?xml version="1.0" encoding="utf-16"?><Fraction><Numerator>0</Numerator><Denominator>0</Denominator></Fraction>
                         """);
        }
    }

    [Test, TestCaseSource(nameof(SerializeTestCases))]
    public string Should_it_return_the_expected_result(Fraction value) {
        var xml = _serializer.Serialize(value);
        Console.WriteLine(xml);
        return xml;
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
        var xml = _serializer.Serialize(value);
        var deserializedValue = _serializer.Deserialize<Fraction>(xml);
        deserializedValue.Should().Be(value);
    }
}

public class If_the_user_serializes_a_TestDto_using_the_XML_serializer {
    private readonly XmlSerializer _serializer = new(typeof(TestDto));

    private static IEnumerable<TestCaseData> DeserializeTestCases {
        get {
            yield return new TestCaseData(new TestDto(Fraction.Zero, "cm"));
            yield return new TestCaseData(new TestDto(Fraction.One, "cm"));
            yield return new TestCaseData(new TestDto(Fraction.NaN, "cm"));
            yield return new TestCaseData(new TestDto(Fraction.PositiveInfinity, "cm"));
            yield return new TestCaseData(new TestDto(Fraction.NegativeInfinity, "cm"));
            yield return new TestCaseData(new TestDto(new Fraction(2, 4, normalize: false), "cm"));
            yield return new TestCaseData(new TestDto(new Fraction(decimal.MaxValue), "cm"));
            yield return new TestCaseData(new TestDto(new Fraction(decimal.MinValue), "cm"));
            yield return new TestCaseData(new TestDto(new Fraction(double.MaxValue), "cm"));
            yield return new TestCaseData(new TestDto(new Fraction(double.MinValue), "cm"));
            yield return new TestCaseData(new TestDto(new Fraction(Math.PI), "cm"));
        }
    }

    [Test, TestCaseSource(nameof(DeserializeTestCases))]
    public void Should_it_deserialize_to_the_same_model(TestDto value) {
        var xml = _serializer.Serialize(value);
        Console.WriteLine(xml);
        var deserializedValue = _serializer.Deserialize<TestDto>(xml);
        deserializedValue.Should().BeEquivalentTo(value);
    }

}
