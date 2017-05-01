using System;
using System.Globalization;
using System.Runtime.Serialization;
using Fractions.Json.Properties;
using Newtonsoft.Json;

namespace Fractions.Json
{
    /// <summary>
    /// Converts a <see cref="Fraction"/> data type to JSON.
    /// </summary>
    public class JsonFractionConverter : JsonConverter {
        private static readonly Lazy<JsonFractionConverter> _instance = new Lazy<JsonFractionConverter>(() => new JsonFractionConverter());
        private readonly IFormatProvider _formatProvider;
        private readonly bool _normalizeOnDeserialization;
        private readonly bool _normalizeOnSerialization;

        /// <summary>
        /// The default instance using the system's default formatter and does not apply normalization.
        /// </summary>
        public static JsonFractionConverter Instance => _instance.Value;

        /// <summary>
        /// Creates an instance using the system's default formatter and does not apply normalization.
        /// </summary>
        public JsonFractionConverter() {
            _normalizeOnSerialization = false;
            _normalizeOnDeserialization = false;
            _formatProvider = default(IFormatProvider);
        }

        /// <summary>
        /// Creates an instance.
        /// </summary>
        /// <param name="formatProvider">The provider to use to format the value. -or- A null reference (Nothing in Visual Basic) to obtain the numeric format information from the current locale setting of the operating system.</param>
        /// <param name="normalizeOnSerialization">The fraction will be normalized during serialization.</param>
        /// <param name="normalizeOnDeserialization">The fraction will be normalized during deserialization.</param>
        public JsonFractionConverter(IFormatProvider formatProvider, bool normalizeOnSerialization, bool normalizeOnDeserialization) {
            _formatProvider = formatProvider;
            _normalizeOnSerialization = normalizeOnSerialization;
            _normalizeOnDeserialization = normalizeOnDeserialization;
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param><param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            var fraction = (Fraction)value;

            if (_normalizeOnSerialization && fraction.State != FractionState.IsNormalized) {
                writer.WriteValue(fraction.Reduce().ToString("G", _formatProvider));
                return;
            }
            writer.WriteValue(fraction.ToString("G", _formatProvider));
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param><param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var value = reader.Value.ToString();
            if (Fraction.TryParse(value, NumberStyles.Number, _formatProvider, _normalizeOnDeserialization, out Fraction fraction)) {
                return fraction;
            }
            throw new SerializationException(string.Format(Resources.CouldNotDeserialize, value));
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(Fraction);
        }
    }
}