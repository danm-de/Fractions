using Fractions;
using Fractions.Json;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using FluentAssertions;
using Fractions.Json.Tests;
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

        private readonly StringBuilder _sb = new StringBuilder();
        private JsonSerializer _serializer;
        private Test _test_objekt;

        [Culture("de-DE")]
        public override void Arrange() {
            var converter = new JsonFractionConverter();
            _serializer = new JsonSerializer();
            _serializer.Converters.Add(converter);

            _test_objekt = new Test {
                Name = "TestName",
                Value = new Fraction(1, 3)
            };
        }

        [Culture("de-DE")]
        public override void Act() {
            _serializer.Serialize(new JsonTextWriter(new StringWriter(_sb)), _test_objekt);
        }

        [Test]
        public void Shall_the_result_contain_1_third() {
            Debug.Print(_sb.ToString());
            _sb.ToString().Should().Contain("1/3");
        }

        [Test]
        public void Shall_the_deserialized_value_equal_to_the_origin_value() {
            _serializer.Deserialize<Test>(new JsonTextReader(new StringReader(_sb.ToString())))
                .ShouldBeEquivalentTo(_test_objekt);
        }
    }

    [TestFixture]
    [Culture("de-DE")]
    public class If_the_user_deserializes_a_json_text : Spec
    {
        private JsonSerializer _serializer;

        [Culture("de-DE")]
        public override void Arrange() {
            var converter = new JsonFractionConverter();
            _serializer = new JsonSerializer();
            _serializer.Converters.Add(converter);
        }

        [Test]
        [Culture("de-DE")]
        public void Shall_the_result_be_a_fraction_with_numerator_7_and_denominator_2(
            [Values("3,5", "7/2", "+3,5", "+7/2", "7/+2")] string fraction_text) {
            var json_text = "\"" + fraction_text + "\"";

            Debug.Print(json_text);
            _serializer.Deserialize<Fraction>(new JsonTextReader(new StringReader(json_text)))
                .Should().Be(new Fraction(7, 2));
        }
    }

    [TestFixture]
    public class Wenn_überprüft_wird_ob_der_Converter_mit_Typen_umgehen_kann : Spec
    {
        private JsonFractionConverter _converter;

        public override void Arrange() {
            _converter = new JsonFractionConverter();
        }

        [Test]
        public void Soll_das_bei_Fraction_True_liefern() {
            _converter
                .CanConvert(typeof(Fraction))
                .Should()
                .BeTrue();
        }

        [Test]
        public void Soll_das_bei_anderen_Typen_False_liefern([Values(typeof(int), typeof(string), typeof(object))] Type type) {
            _converter
                .CanConvert(type)
                .Should()
                .BeFalse();
        }
    }
}
