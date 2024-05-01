using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.Serialization.Json;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.DataContractSpecs.Json;

public class DataContractJsonSerializerSpecs : Spec {
    protected static string SerializeObject(object obj) {
        var serializer = new DataContractJsonSerializer(obj.GetType());
        using var stream = new MemoryStream();
        serializer.WriteObject(stream, obj);
        stream.Position = 0;
        using var streamReader = new StreamReader(stream);
        var result = streamReader.ReadToEnd();
        return result;
    }

    protected T DeserializeObject<T>(string json) {
        var serializer = new DataContractJsonSerializer(typeof(T));
        using var stream = new MemoryStream();
        using var writer = new StreamWriter(stream);
        writer.Write(json);
        writer.Flush();
        stream.Position = 0;
        return (T)(serializer.ReadObject(stream) ?? throw new InvalidOperationException("Read 'null' from stream."));
    }
}

[TestFixture]
public class When_serializing_a_fraction_to_json : DataContractJsonSerializerSpecs {
    private static IEnumerable<TestCaseData> TestCases {
        get {
            // zero value should emit no properties (same using default(Fraction))
            yield return new TestCaseData(Fraction.Zero)
                .Returns("{}");
            // "small" integer fraction;
            yield return new TestCaseData(new Fraction(-1234567899))
                .Returns("""{"Numerator":{"_bits":null,"_sign":-1234567899}}""");
            // large integer fraction
            yield return new TestCaseData(new Fraction(BigInteger.Pow(10, 10)))
                .Returns("""{"Numerator":{"_bits":[1410065408,2],"_sign":1}}""");
            // small decimal fraction
            yield return new TestCaseData(new Fraction(-7, 2))
                .Returns("""{"Numerator":{"_bits":null,"_sign":-7},"Denominator":{"_bits":null,"_sign":2}}""");
            // improper decimal fraction
            yield return new TestCaseData(new Fraction(7, -2, false))
                .Returns("""{"Numerator":{"_bits":null,"_sign":7},"Denominator":{"_bits":null,"_sign":-2},"NormalizationNotApplied":true}""");
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public string The_result_should_match_the_expected_json_format(Fraction fraction) {
        var result = SerializeObject(fraction);
        return result;
    }
}

[TestFixture]
public class When_deserializing_a_fraction_from_json : DataContractJsonSerializerSpecs {
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
        var json = SerializeObject(fraction);
        // Act
        var deserializedFraction = DeserializeObject<Fraction>(json);
        // Assert
        fraction.Should().Be(deserializedFraction);
    }
}
