using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.DataContractSpecs.Xml;

public class DataContractSerializerSpecs : Spec {
    protected static string SerializeObject(object obj) {
        var serializer = new DataContractSerializer(obj.GetType());
        using var stream = new MemoryStream();
        serializer.WriteObject(stream, obj);
        stream.Position = 0;
        using var streamReader = new StreamReader(stream);
        var result = streamReader.ReadToEnd();
        return result;
    }

    protected T DeserializeObject<T>(string xml) {
        var serializer = new DataContractSerializer(typeof(T));
        using var stream = new MemoryStream();
        using var writer = new StreamWriter(stream);
        writer.Write(xml);
        writer.Flush();
        stream.Position = 0;
        return (T)(serializer.ReadObject(stream) ?? throw new InvalidOperationException("Read 'null' from stream."));
    }
}

[TestFixture]
public class When_serializing_a_fraction_to_xml : DataContractSerializerSpecs {
    private const string XmlSchema = "xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"";
    private const string FractionsNamespace = "xmlns=\"http://schemas.datacontract.org/2004/07/Fractions\"";
    private const string NumericsNamespace = "xmlns:a=\"http://schemas.datacontract.org/2004/07/System.Numerics\"";
    private const string ArraysNamespace = "xmlns:b=\"http://schemas.microsoft.com/2003/10/Serialization/Arrays\"";

    private static IEnumerable<TestCaseData> TestCases {
        get {
            // zero value should emit no properties (same using default(Fraction))
            yield return new TestCaseData(Fraction.Zero)
                .Returns($"<Fraction {FractionsNamespace} {XmlSchema}/>");
            // "small" integer fraction;
            yield return new TestCaseData(new Fraction(-1234567899))
                .Returns($"<Fraction {FractionsNamespace} {XmlSchema}>"
                    .Concat($"<Numerator {NumericsNamespace}>")
                    .Concat($"<a:_bits i:nil=\"true\" {ArraysNamespace}/>")
                    .Concat("<a:_sign>-1234567899</a:_sign>")
                    .Concat("</Numerator>")
                    .Concat("</Fraction>")
                );
            // large integer fraction
            yield return new TestCaseData(new Fraction(BigInteger.Pow(10, 10)))
                .Returns($"<Fraction {FractionsNamespace} {XmlSchema}>"
                    .Concat($"<Numerator {NumericsNamespace}>")
                    .Concat($"<a:_bits {ArraysNamespace}>")
                    .Concat("<b:unsignedInt>1410065408</b:unsignedInt>")
                    .Concat("<b:unsignedInt>2</b:unsignedInt>")
                    .Concat("</a:_bits>")
                    .Concat("<a:_sign>1</a:_sign>")
                    .Concat("</Numerator>")
                    .Concat("</Fraction>")
                );
            // small decimal fraction
            yield return new TestCaseData(new Fraction(-7, 2))
                .Returns($"<Fraction {FractionsNamespace} {XmlSchema}>"
                    .Concat($"<Numerator {NumericsNamespace}>")
                    .Concat($"<a:_bits i:nil=\"true\" {ArraysNamespace}/>")
                    .Concat("<a:_sign>-7</a:_sign>")
                    .Concat("</Numerator>")
                    .Concat($"<Denominator {NumericsNamespace}>")
                    .Concat($"<a:_bits i:nil=\"true\" {ArraysNamespace}/>")
                    .Concat("<a:_sign>2</a:_sign>")
                    .Concat("</Denominator>")
                    .Concat("</Fraction>")
                );
            // improper decimal fraction
            yield return new TestCaseData(new Fraction(7, -2, false))
                .Returns($"<Fraction {FractionsNamespace} {XmlSchema}>"
                    .Concat($"<Numerator {NumericsNamespace}>")
                    .Concat($"<a:_bits i:nil=\"true\" {ArraysNamespace}/>")
                    .Concat("<a:_sign>7</a:_sign>")
                    .Concat("</Numerator>")
                    .Concat($"<Denominator {NumericsNamespace}>")
                    .Concat($"<a:_bits i:nil=\"true\" {ArraysNamespace}/>")
                    .Concat("<a:_sign>-2</a:_sign>")
                    .Concat("</Denominator>")
                    .Concat("<NormalizationNotApplied>true</NormalizationNotApplied>")
                    .Concat("</Fraction>")
                );
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public string The_result_should_match_the_expected_xml_format(Fraction fraction) {
        var result = SerializeObject(fraction);
        fraction.Should().Be(DeserializeObject<Fraction>(result), "the format should work both ways");
        return result;
    }
}

[TestFixture]
public class When_deserializing_a_fraction_from_xml : DataContractSerializerSpecs {
    private static IEnumerable<TestCaseData> TestCases {
        get {
            yield return new TestCaseData(Fraction.Zero);
            yield return new TestCaseData(Fraction.One);
            yield return new TestCaseData(Fraction.MinusOne);
            yield return new TestCaseData(new Fraction(1234567899));
            yield return new TestCaseData(new Fraction(-1234567899));
            yield return new TestCaseData(new Fraction(BigInteger.Pow(10, 37)));
            yield return new TestCaseData(new Fraction(-BigInteger.Pow(10, 37)));
            yield return new TestCaseData(new Fraction(-1, 3));
            yield return new TestCaseData(new Fraction(1, -3, false));
            yield return new TestCaseData(new Fraction(-1, -3, false));
            yield return new TestCaseData(Fraction.FromDouble(Math.PI));
            yield return new TestCaseData(Fraction.FromDouble(-Math.PI));
            yield return new TestCaseData(Fraction.NaN);
            yield return new TestCaseData(Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity);
            yield return new TestCaseData(new Fraction(3, 0, false));
            yield return new TestCaseData(new Fraction(-3, 0, false));
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void The_result_should_be_the_original_value(Fraction fraction) {
        // Arrange
        var xml = SerializeObject(fraction);
        // Act
        var deserializedFraction = DeserializeObject<Fraction>(xml);
        // Assert
        fraction.Should().Be(deserializedFraction);
    }
}
