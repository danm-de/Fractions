using Fractions;
using Fractions.Json;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Tests.Fractions.Json.JsonFractionConverterSpecs {
    [TestFixture]
    [Culture("de-DE")]
    public class Wenn_ein_Objekt_welches_ein_Bruch_als_Eigenschaft_enthält_serialisiert_wird : Spec {
        [DataContract]
        private class Test {
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
        public void Soll_das_Ergebnis_den_Text_1_pro_3_enthalten() {
            Debug.Print(_sb.ToString());
            _sb.ToString().Should().Contain("1/3");
        }

        [Test]
        public void Soll_der_Ergebnis_auch_wieder_deserialisiert_werden_können() {
            _serializer.Deserialize<Test>(new JsonTextReader(new StringReader(_sb.ToString())))
                .ShouldBeEquivalentTo(_test_objekt);
        }
    }

    [TestFixture]
    [Culture("de-DE")]
    public class Wenn_ein_JSON_Text_mit_dem_Wert_3_durch_5_eingelesen_wird : Spec {
        private JsonSerializer _serializer;

        [Culture("de-DE")]
        public override void Arrange() {
            var converter = new JsonFractionConverter();
            _serializer = new JsonSerializer();
            _serializer.Converters.Add(converter);
        }

        [Test]
        [Culture("de-DE")]
        public void Soll_der_deserialisierte_Bruch_den_Wert_3_durch_5_haben(
            [Values("3,5", "7/2", "+3,5", "+7/2", "7/+2")] string fraction_text) {
            var json_text = "\"" + fraction_text + "\"";

            Debug.Print(json_text);
            _serializer.Deserialize<Fraction>(new JsonTextReader(new StringReader(json_text)))
                .Should().Be(new Fraction(7, 2));
        }
    }

    [TestFixture]
    public class Wenn_überprüft_wird_ob_der_Converter_mit_Typen_umgehen_kann : Spec {
        private JsonFractionConverter _converter;

        public override void Arrange() {
            _converter = new JsonFractionConverter();
        }

        [Test]
        public void Soll_das_bei_Fraction_True_liefern() {
            _converter
                .CanConvert(typeof (Fraction))
                .Should()
                .BeTrue();
        }

        [Test]
        public void Soll_das_bei_anderen_Typen_False_liefern([Values(typeof (int), typeof (string), typeof (object))] Type type) {
            _converter
                .CanConvert(type)
                .Should()
                .BeFalse();
        }
    }
}
