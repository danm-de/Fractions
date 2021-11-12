using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Fractions.Json.Tests.JsonFractionConverterSpecs
{
    [TestFixture]
    [Culture("de-DE")]
    public class If_an_object_containing_a_fraction_property_is_being_serialized : Spec
    {
        [DataContract]
        private class Test
        {
            [DataMember]
            public string Name { get; set; }

            [DataMember]
            public Fraction Value { get; set; }
        }

        private readonly StringBuilder _sb = new();
        private JsonSerializer _serializer;
        private Test _testObject;

        [Culture("de-DE")]
        public override void Arrange() {
            var converter = new JsonFractionConverter(null, true, true);
            _serializer = new JsonSerializer();
            _serializer.Converters.Add(converter);

            _testObject = new Test {
                Name = "TestName",
                Value = new Fraction(1, 3)
            };
        }

        [Culture("de-DE")]
        public override void Act() {
            _serializer.Serialize(new JsonTextWriter(new StringWriter(_sb)), _testObject);
        }

        [Test]
        public void Shall_the_result_contain_1_third() {
            Console.WriteLine(_sb.ToString());
            _sb.ToString().Should().Contain("1/3");
        }

        [Test]
        public void Shall_the_deserialized_value_equal_to_the_origin_value() {
            _serializer.Deserialize<Test>(new JsonTextReader(new StringReader(_sb.ToString())))
                .Should().BeEquivalentTo(_testObject);
        }
    }

    [TestFixture]
    [Culture("de-DE")]
    public class If_the_user_serializes_a_Fraction_without_normalization : Spec
    {
        private JsonSerializer _serializer;

        [Culture("de-DE")]
        public override void Arrange() {
            var converter = new JsonFractionConverter(null, false, true);
            _serializer = new JsonSerializer();
            _serializer.Converters.Add(converter);
        }

        private static IEnumerable<TestCaseData> TestCases {
            get {
                yield return new TestCaseData(new Fraction(7, 2, true)).Returns("\"7/2\"");
                yield return new TestCaseData(new Fraction(-7, 2, true)).Returns("\"-7/2\"");
                yield return new TestCaseData(new Fraction(7, -2, false)).Returns("\"7/-2\"");
                yield return new TestCaseData(new Fraction(-7, -2, false)).Returns("\"-7/-2\"");
            }
        }

        [Test, TestCaseSource(nameof(TestCases))]
        [Culture("de-DE")]
        public string Shall_the_result_be_the_expected_json_text(Fraction value) {
            Console.WriteLine(value);
            var sb = new StringBuilder();
            _serializer.Serialize(new JsonTextWriter(new StringWriter(sb)), value);
            return sb.ToString();
        }
    }

    [TestFixture]
    [Culture("de-DE")]
    public class If_the_user_serializes_a_Fraction_with_normalization : Spec
    {
        private JsonSerializer _serializer;

        [Culture("de-DE")]
        public override void Arrange() {
            var converter = new JsonFractionConverter(null, true, false);
            _serializer = new JsonSerializer();
            _serializer.Converters.Add(converter);
        }

        private static IEnumerable<TestCaseData> TestCases {
            get {
                yield return new TestCaseData(new Fraction(7, 2, true)).Returns("\"7/2\"");
                yield return new TestCaseData(new Fraction(-7, 2, true)).Returns("\"-7/2\"");
                yield return new TestCaseData(new Fraction(7, -2, false)).Returns("\"-7/2\"");
                yield return new TestCaseData(new Fraction(-7, -2, false)).Returns("\"7/2\"");
            }
        }

        [Test, TestCaseSource(nameof(TestCases))]
        [Culture("de-DE")]
        public string Shall_the_result_be_the_expected_json_text(Fraction value) {
            Console.WriteLine(value);
            var sb = new StringBuilder();
            _serializer.Serialize(new JsonTextWriter(new StringWriter(sb)), value);
            return sb.ToString();
        }
    }

    [TestFixture]
    [Culture("de-DE")]
    public class If_the_user_deserializes_a_json_text_without_normalization : Spec
    {
        private JsonSerializer _serializer;

        [Culture("de-DE")]
        public override void Arrange() {
            var converter = new JsonFractionConverter(null, true, false);
            _serializer = new JsonSerializer();
            _serializer.Converters.Add(converter);
        }

        private static IEnumerable<TestCaseData> TestCases {
            get {
                yield return new TestCaseData("3,5").Returns(new Fraction(7, 2, true));
                yield return new TestCaseData("-3,5").Returns(new Fraction(-7, 2, true));
                yield return new TestCaseData("7/2").Returns(new Fraction(7, 2, true));
                yield return new TestCaseData("+3,5").Returns(new Fraction(7, 2, true));
                yield return new TestCaseData("+7/2").Returns(new Fraction(7, 2, true));
                yield return new TestCaseData("7/+2").Returns(new Fraction(7, 2, true));
                yield return new TestCaseData("7/-2").Returns(new Fraction(7, -2, false));
                yield return new TestCaseData("-7/2").Returns(new Fraction(-7, 2, true));
                yield return new TestCaseData("-7/-2").Returns(new Fraction(-7, -2, false));
            }
        }

        [Test,TestCaseSource(nameof(TestCases))]
        [Culture("de-DE")]
        public Fraction Shall_the_result_be_the_expected_fraction(string text) {
            var json_text = "\"" + text + "\"";

            Console.WriteLine(json_text);
            return _serializer.Deserialize<Fraction>(new JsonTextReader(new StringReader(json_text)));
        }
    }

    [TestFixture]
    [Culture("de-DE")]
    public class If_the_user_deserializes_a_json_text_with_normalization : Spec
    {
        private JsonSerializer _serializer;

        [Culture("de-DE")]
        public override void Arrange() {
            var converter = new JsonFractionConverter(null, true, true);
            _serializer = new JsonSerializer();
            _serializer.Converters.Add(converter);
        }

        private static IEnumerable<TestCaseData> TestCases {
            get {
                yield return new TestCaseData("3,5").Returns(new Fraction(7, 2, true));
                yield return new TestCaseData("-3,5").Returns(new Fraction(-7, 2, true));
                yield return new TestCaseData("7/2").Returns(new Fraction(7, 2, true));
                yield return new TestCaseData("+3,5").Returns(new Fraction(7, 2, true));
                yield return new TestCaseData("+7/2").Returns(new Fraction(7, 2, true));
                yield return new TestCaseData("7/+2").Returns(new Fraction(7, 2, true));
                yield return new TestCaseData("7/-2").Returns(new Fraction(-7, 2, false));
                yield return new TestCaseData("-7/2").Returns(new Fraction(-7, 2, true));
                yield return new TestCaseData("-7/-2").Returns(new Fraction(7, 2, false));
            }
        }

        [Test, TestCaseSource(nameof(TestCases))]
        [Culture("de-DE")]
        public Fraction Shall_the_result_be_the_expected_fraction(string text) {
            var json_text = "\"" + text + "\"";

            Console.WriteLine(json_text);
            return _serializer.Deserialize<Fraction>(new JsonTextReader(new StringReader(json_text)));
        }
    }

    [TestFixture]
    public class If_the_user_checks_the_supported_types : Spec
    {
        private JsonFractionConverter _converter;

        public override void Arrange() {
            _converter = new JsonFractionConverter();
        }

        [Test]
        public void Shall_it_be_TRUE_for_Fraction() {
            _converter
                .CanConvert(typeof(Fraction))
                .Should()
                .BeTrue();
        }

        [Test]
        public void Shall_it_be_FALSE_for_other_types([Values(typeof(int), typeof(string), typeof(object))] Type type) {
            _converter
                .CanConvert(type)
                .Should()
                .BeFalse();
        }
    }
}
