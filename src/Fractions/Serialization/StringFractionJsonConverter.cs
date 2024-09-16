#if NET
using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fractions.Serialization;

/// <summary>
/// A <see cref="JsonConverter"/> for the <see cref="Fraction"/> data type that (de-)serializes the value as a simple string. The normalization options are lost during the serialization process and cannot be restored.
/// </summary>
public class StringFractionJsonConverter : JsonConverter<Fraction> {
    private readonly CultureInfo _cultureInfo;

    /// <summary>
    /// Creates a new instance using invariant culture and <see cref="NumberStyles.Number"/> style
    /// </summary>
    public StringFractionJsonConverter() : this(CultureInfo.InvariantCulture) { }

    /// <summary>
    /// Creates a new instance
    /// </summary>
    /// <param name="cultureInfo">Culture used to serialize and deserialize the fraction</param>
    public StringFractionJsonConverter(CultureInfo cultureInfo) => _cultureInfo = cultureInfo;

    /// <inheritdoc />>
    public override Fraction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        Fraction.TryParse(
            value: reader.GetString(),
            numberStyles: NumberStyles.Number,
            formatProvider: _cultureInfo,
            fraction: out var value)
            ? value
            : throw new JsonException();

    /// <inheritdoc />>
    public override void Write(Utf8JsonWriter writer, Fraction value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString(_cultureInfo));
}
#endif
