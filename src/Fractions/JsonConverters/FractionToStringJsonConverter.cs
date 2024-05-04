#if NET
using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fractions.JsonConverters;

/// <summary>
/// Converts a <see cref="Fraction"/> using the <see cref="Fraction.ToString()"/> method.
/// </summary>
public class FractionToStringJsonConverter : JsonConverter<Fraction> {
    /// <inheritdoc />>
    public override Fraction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        Fraction.TryParse(
            fractionString: reader.GetString(),
            numberStyles: NumberStyles.Number,
            formatProvider: CultureInfo.InvariantCulture,
            fraction: out var value)
            ? value
            : throw new JsonException();

    /// <inheritdoc />>
    public override void Write(Utf8JsonWriter writer, Fraction value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
}
#endif
