﻿#if NET
using System;
using System.Globalization;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Fractions.Properties;

namespace Fractions.JsonConverters;

/// <summary>
/// A <see cref="JsonConverter"/> for the <see cref="Fraction"/> data type.
/// </summary>
public class DefaultFractionJsonConverter : JsonConverter<Fraction> {
    private string _numeratorProperty;
    private string _denominatorProperty;
    private string _normalizationNotAppliedProperty;
    private JsonConverter<bool> _boolConverter;

    /// <inheritdoc />>
    public override Fraction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        Initialize(options);

        ThrowIfNot(reader, JsonTokenType.StartObject);

        var numerator = BigInteger.Zero;
        var denominator = BigInteger.Zero;
        var normalizationNotApplied = false;

        while (reader.Read()) {
            if (reader.TokenType == JsonTokenType.EndObject) {
                break;
            }

            ThrowIfNot(reader, JsonTokenType.PropertyName);

            var propertyName = reader.GetString();

            if (propertyName == _numeratorProperty) {
                reader.Read();
                var n = reader.GetString();
                if (!BigInteger.TryParse(n, CultureInfo.InvariantCulture, out numerator)) {
                    throw new JsonException(string.Format(Resources.InvalidNumeratorValue, n));
                }
            } else if (propertyName == _denominatorProperty) {
                reader.Read();
                var d = reader.GetString();
                if (!BigInteger.TryParse(d, CultureInfo.InvariantCulture, out denominator)) {
                    throw new JsonException(string.Format(Resources.InvalidDenominatorValue, d));
                }
            } else if (propertyName == _normalizationNotAppliedProperty) {
                reader.Read();
                normalizationNotApplied = _boolConverter.Read(ref reader, typeof(bool), options);
            }
        }

        return new Fraction(normalizationNotApplied, numerator, denominator);
    }

    /// <inheritdoc />>
    public override void Write(Utf8JsonWriter writer, Fraction value, JsonSerializerOptions options) {
        Initialize(options);

        writer.WriteStartObject();
        writer.WriteString(_numeratorProperty, value.Numerator.ToString("G", CultureInfo.InvariantCulture));
        writer.WriteString(_denominatorProperty, value.Denominator.ToString("G", CultureInfo.InvariantCulture));
        if (value.State == FractionState.Unknown) {
            writer.WriteBoolean(_normalizationNotAppliedProperty, true);
        }

        writer.WriteEndObject();
    }

    private static void ThrowIfNot(Utf8JsonReader reader, JsonTokenType tokenType) {
        if (reader.TokenType == tokenType) {
            return;
        }

        throw new JsonException(string.Format(Resources.InvalidTokenType, reader.TokenType, tokenType));
    }

    private void Initialize(JsonSerializerOptions options) {
        if (_numeratorProperty != null) {
            return;
        }

        // cache the property names (converter instance is reused)
        _numeratorProperty =
            options.PropertyNamingPolicy?.ConvertName(nameof(Fraction.Numerator))
            ?? nameof(Fraction.Numerator);

        _denominatorProperty =
            options.PropertyNamingPolicy?.ConvertName(nameof(Fraction.Denominator))
            ?? nameof(Fraction.Denominator);

        _normalizationNotAppliedProperty =
            options.PropertyNamingPolicy?.ConvertName("NormalizationNotApplied")
            ?? "NormalizationNotApplied";

        // cache converters
        _boolConverter = (JsonConverter<bool>)options.GetConverter(typeof(bool));
    }
}
#endif