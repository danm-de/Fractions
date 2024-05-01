using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
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
                         <?xml version="1.0" encoding="utf-16"?>
                         <Fraction Numerator="0" Denominator="1" />
                         """);
            yield return new TestCaseData(Fraction.One)
                .Returns("""
                         <?xml version="1.0" encoding="utf-16"?>
                         <Fraction Numerator="1" Denominator="1" />
                         """);
            yield return new TestCaseData(Fraction.NaN)
                .Returns("""
                         <?xml version="1.0" encoding="utf-16"?>
                         <Fraction Numerator="0" Denominator="0" />
                         """);
            yield return new TestCaseData(Fraction.PositiveInfinity)
                .Returns("""
                         <?xml version="1.0" encoding="utf-16"?>
                         <Fraction Numerator="1" Denominator="0" />
                         """);
            yield return new TestCaseData(Fraction.NegativeInfinity)
                .Returns("""
                         <?xml version="1.0" encoding="utf-16"?>
                         <Fraction Numerator="-1" Denominator="0" />
                         """);
            yield return new TestCaseData(new Fraction(2, 4, normalize: false))
                .Returns("""
                         <?xml version="1.0" encoding="utf-16"?>
                         <Fraction Numerator="2" Denominator="4" NormalizationNotApplied="True" />
                         """);
        }
    }

    [Test, TestCaseSource(nameof(SerializeTestCases))]
    public string Should_it_return_the_expected_result(Fraction value) {
        var xml = Serialize(value);
        Debug.WriteLine(xml);
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
        var xml = Serialize(value);
        var deserializedValue = Deserialize(xml);
        deserializedValue.Should().Be(value);
    }

    private string Serialize(Fraction value) {
        var sb = new StringBuilder();
        using var writer = new StringWriter(sb);
        _serializer.Serialize(writer, value);
        writer.Flush();
        return sb.ToString();
    }

    private Fraction Deserialize(string xml) {
        using var reader = new StringReader(xml);
        return (Fraction)_serializer.Deserialize(reader)!;
    }
}
