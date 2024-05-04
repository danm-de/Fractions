using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace Fractions.Tests.Serialization.DataContracts;

[TestFixture]
public class If_the_user_serializes_a_fraction_using_the_DataContractJson_serializer {
    private readonly DataContractJsonSerializer  _serializer = new(typeof(Fraction));

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

    public string Serialize(object obj)
    {
        using var stream = new MemoryStream();
        using var writer = JsonReaderWriterFactory.CreateJsonWriter(stream, Encoding.UTF8);
        _serializer.WriteObject(stream, obj);
        stream.Seek(0, SeekOrigin.Begin);
        return Encoding.UTF8.GetString(stream.ToArray());
    }

    public Fraction Deserialize(string json)
    {
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
        return (Fraction)_serializer.ReadObject(stream)!;
    }
}
