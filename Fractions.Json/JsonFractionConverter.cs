using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Fractions.Json
{
    /// <summary>
    /// Converts a <see cref="Fraction"/> data type to JSON.
    /// </summary>
    public class JsonFractionConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param><param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            var fraction = (Fraction)value;
            writer.WriteValue(fraction.ToString());
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param>
        /// <param name="object_type">Type of the object.</param><param name="existing_value">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type object_type, object existing_value, JsonSerializer serializer) {
            var value = reader.Value.ToString();
            Fraction fraction;
            if (!Fraction.TryParse(value, out fraction)) {
                throw new SerializationException(string.Format(Exceptions.CouldNotDeserialize, value));
            }
            return fraction;
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="object_type">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type object_type) {
            return object_type == typeof(Fraction);
        }
    }
}