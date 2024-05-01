using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using FluentAssertions;
using NUnit.Framework;

namespace Fractions.Tests.Serialization.DataContracts;

[TestFixture]
public class If_the_user_serializes_a_fraction_using_the_DataContract_serializer {
    private readonly DataContractSerializer  _serializer = new(typeof(Fraction));

    private static IEnumerable<TestCaseData> SerializeTestCases {
        get {
            yield return new TestCaseData(Fraction.Zero)
                .Returns("""
                         <Fraction Numerator="0" Denominator="1" xmlns="http://schemas.datacontract.org/2004/07/Fractions"/>
                         """);
            yield return new TestCaseData(Fraction.One)
                .Returns("""
                         <Fraction Numerator="1" Denominator="1" xmlns="http://schemas.datacontract.org/2004/07/Fractions"/>
                         """);
            yield return new TestCaseData(Fraction.NaN)
                .Returns("""
                         <Fraction Numerator="0" Denominator="0" xmlns="http://schemas.datacontract.org/2004/07/Fractions"/>
                         """);
            yield return new TestCaseData(Fraction.PositiveInfinity)
                .Returns("""
                         <Fraction Numerator="1" Denominator="0" xmlns="http://schemas.datacontract.org/2004/07/Fractions"/>
                         """);
            yield return new TestCaseData(Fraction.NegativeInfinity)
                .Returns("""
                         <Fraction Numerator="-1" Denominator="0" xmlns="http://schemas.datacontract.org/2004/07/Fractions"/>
                         """);
            yield return new TestCaseData(new Fraction(2, 4, normalize: false))
                .Returns("""
                         <Fraction Numerator="2" Denominator="4" NormalizationNotApplied="True" xmlns="http://schemas.datacontract.org/2004/07/Fractions"/>
                         """);
        }
    }

    [Test, TestCaseSource(nameof(SerializeTestCases))]
    public string Should_it_return_the_expected_result(Fraction value) {
        var xml = Serialize(value);
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
        var xml = Serialize(value);
        var deserializedValue = Deserialize(xml);
        deserializedValue.Should().Be(value);
    }

    public string Serialize(object obj)
    {
        using var stream = new MemoryStream();
        using var writer = new StreamWriter(stream, Encoding.UTF8);
        _serializer.WriteObject(stream, obj);
        stream.Seek(0, SeekOrigin.Begin);
        return Encoding.UTF8.GetString(stream.ToArray());
    }

    public Fraction Deserialize(string xml)
    {
        using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
        using var reader = XmlDictionaryReader.CreateTextReader(memoryStream, Encoding.UTF8, new XmlDictionaryReaderQuotas(), null);
        return (Fraction)_serializer.ReadObject(reader)!;
    }
}
