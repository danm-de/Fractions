using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Numerics;

namespace Fractions.TypeConverters;

/// <summary>
/// Converts the <see cref="Fraction"/> from / to various data types.
/// </summary>
public sealed class FractionTypeConverter : TypeConverter {
    private static readonly HashSet<Type> SupportedTypes = [
        typeof(string),
        typeof(int),
        typeof(long),
        typeof(decimal),
        typeof(double),
        typeof(Fraction),
        typeof(BigInteger)
    ];

    private static readonly Dictionary<Type, Func<object, CultureInfo, object>> ConvertToDictionary =
        new() {
            {typeof (string), (o, info) => ((Fraction) o).ToString(info)},
            {typeof (int), (o, _) => ((Fraction) o).ToInt32()},
            {typeof (long), (o, _) => ((Fraction) o).ToInt64()},
            {typeof (decimal), (o, _) => ((Fraction) o).ToDecimal()},
            {typeof (double), (o, _) => ((Fraction) o).ToDouble()},
            {typeof (Fraction), (o, _) => (Fraction) o},
            {typeof (BigInteger), (o, _) => ((Fraction) o).ToBigInteger()}
        };

    private static readonly Dictionary<Type, Func<object, CultureInfo, Fraction>> ConvertFromDictionary =
        new() {
            {typeof (string), (o, info) => Fraction.FromString((string) o, info)},
            {typeof (int), (o, _) => new Fraction((int) o)},
            {typeof (long), (o, _) => new Fraction((long) o)},
            {typeof (decimal), (o, _) => Fraction.FromDecimal((decimal) o)},
            {typeof (double), (o, _) => Fraction.FromDouble((double) o)},
            {typeof (Fraction), (o, _) => (Fraction) o},
            {typeof (BigInteger), (o, _) => new Fraction((BigInteger) o)}
        };

    /// <summary>
    /// Returns whether the type converter can convert an object to the specified type. 
    /// </summary>
    /// <param name="context">An object that provides a format context.</param>
    /// <param name="destinationType">The type you want to convert to.</param>
    /// <returns><c>true</c> if this converter can perform the conversion; otherwise, <c>false</c>.</returns>
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
            return SupportedTypes.Contains(destinationType);
        }

    /// <summary>
    /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context. 
    /// </summary>
    /// <param name="context">An <see cref="ITypeDescriptorContext "/>that provides a format context. </param>
    /// <param name="sourceType">A <see cref="Type"/> that represents the type you want to convert from. </param>
    /// <returns><c>true</c>if this converter can perform the conversion; otherwise, <c>false</c>.</returns>
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
            return SupportedTypes.Contains(sourceType);
        }

    /// <summary>
    /// Converts the given value object to the specified type, using the specified context and culture information. 
    /// </summary>
    /// <param name="context">An <see cref="ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="culture">A CultureInfo. If <c>null</c> is passed, the current culture is assumed.</param>
    /// <param name="value">The <see cref="object"/> to convert.</param>
    /// <param name="destinationType">The <see cref="Type" />  to convert the value parameter to.</param>
    /// <returns>An <see cref="object"/> that represents the converted value.</returns>
    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
        Type destinationType) {
            return !ReferenceEquals(value, null) && ConvertToDictionary.TryGetValue(destinationType, out var func)
                ? func(value, culture)
                : base.ConvertTo(context, culture, value, destinationType);
        }

    /// <summary>
    /// Converts the given object to the type of this converter, using the specified context and culture information.
    /// </summary>
    /// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context.</param>
    /// <param name="culture">The <see cref="CultureInfo"/> to use as the current culture.</param>
    /// <param name="value">The <see cref="object"/> to convert.</param>
    /// <returns>An <see cref="object"/> that represents the converted value.</returns>
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object? value) {
            if (ReferenceEquals(value, null)) {
                return Fraction.Zero;
            }

            return ConvertFromDictionary.TryGetValue(value.GetType(), out var func)
                ? func(value, culture)
                : base.ConvertFrom(context, culture, value);
        }
}
