#nullable enable

using Fractions.Properties;
using System.Globalization;
using System;

namespace Fractions;

public readonly partial struct Fraction {
     /// <inheritdoc cref="FromString(string, NumberStyles, IFormatProvider, bool)"/>
    public static Fraction FromString(string fractionString) {
        return FromString(fractionString, NumberStyles.Number, null, normalize: true);
    }

    /// <inheritdoc cref="FromString(string, NumberStyles, IFormatProvider, bool)"/>
    public static Fraction FromString(string fractionString, bool normalize) {
        return FromString(fractionString, NumberStyles.Number, null, normalize);
    }

    /// <inheritdoc cref="FromString(string, NumberStyles, IFormatProvider, bool)"/>
    public static Fraction FromString(string fractionString, IFormatProvider formatProvider) {
        return FromString(fractionString, NumberStyles.Number, formatProvider, normalize: true);
    }

    /// <inheritdoc cref="FromString(string, NumberStyles, IFormatProvider, bool)"/>
    public static Fraction FromString(string fractionString, NumberStyles numberStyles, IFormatProvider formatProvider) {
        return FromString(fractionString, numberStyles, formatProvider, normalize: true);
    }

    /// <inheritdoc cref="FromString(string, NumberStyles, IFormatProvider, bool)"/>
    public static Fraction FromString(string fractionString, IFormatProvider formatProvider, bool normalize) {
        return FromString(fractionString, NumberStyles.Number, formatProvider, normalize);
    }

    /// <summary>
    ///     Converts a string representation of a fraction or a decimal number to a Fraction object.
    /// </summary>
    /// <param name="fractionString">
    ///     A string that contains a fraction or a decimal number to convert. The fraction must be in the format
    ///     'numerator/denominator'. The decimal number must be in a format compatible with the specified format
    ///     provider (if specified).
    /// </param>
    /// <param name="numberStyles">
    ///     A bitwise combination of enumeration values that indicates the style elements that can be present in
    ///     fractionString. A typical value to specify is <see cref="NumberStyles.Number"/>.
    /// </param>
    /// <param name="formatProvider">
    ///     An object that supplies culture-specific formatting information about <paramref name="fractionString"/>. If <paramref name="formatProvider"/> is <c>null</c>,
    ///     the thread current culture is used.
    /// </param>
    /// <param name="normalize">
    ///     A boolean value that indicates whether the resulting Fraction object should be reduced to the lowest terms. If
    ///     normalize is true, the resulting Fraction object is reduced to the lowest terms; otherwise, it is not.
    /// </param>
    /// <returns>
    ///     A Fraction object that is equivalent to the fraction or decimal number contained in fractionString, as specified by
    ///     numberStyles and formatProvider.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when fractionString is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     Thrown when fractionString is not in the correct format.
    /// </exception>
    /// <remarks>
    ///     Here are some examples of how to use the
    ///     <see cref="FromString(string, NumberStyles, IFormatProvider, bool)" /> method:
    ///     <example>
    ///         <code>
    /// Fraction.FromString("3/4", NumberStyles.Number, null, true);
    /// </code>
    ///         This example parses the string "3/4" into a <see cref="Fraction" /> object with a numerator of 3 and a
    ///         denominator of 4.
    ///         <code>
    /// Fraction.FromString("1.25", NumberStyles.Number, null, true);
    /// </code>
    ///         This example parses the string "1.25" into a <see cref="Fraction" /> object with a numerator of 5 and a
    ///         denominator of 4.
    ///         <code>
    /// Fraction.FromString("1.23e-2", NumberStyles.Number, null, true);
    /// </code>
    ///         This example parses the string "1.23e-2" into a <see cref="Fraction" /> object with a numerator of 123 and
    ///         a denominator of 10000.
    ///     </example>
    /// </remarks>
    public static Fraction FromString(string fractionString, NumberStyles numberStyles, IFormatProvider? formatProvider, bool normalize) {
        if (fractionString == null) {
            throw new ArgumentNullException(nameof(fractionString));
        }

        if (!TryParse(fractionString, numberStyles, formatProvider, normalize, out var fraction)) {
            throw new FormatException(string.Format(Resources.CannotConvertToFraction, fractionString));
        }

        return fraction;
    }
}
