using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Numerics;

namespace Fractions
{
	/// <summary>
	/// Converts the <see cref="Fraction"/> from / to various data types.
	/// </summary>
	public sealed class FractionTypeConverter : TypeConverter {
		private static readonly HashSet<Type> _supported_types = new HashSet<Type> {
			typeof (string), 
			typeof (int), 
			typeof (long), 
			typeof (decimal), 
			typeof (double), 
			typeof (Fraction),
            typeof (BigInteger)
		};

		private static readonly Dictionary<Type, Func<object, CultureInfo, object>> _convert_to_dictionary = new Dictionary<Type, Func<object, CultureInfo, object>> {
			{typeof(string), (o, info) => ((Fraction)o).ToString()},
			{typeof(int), (o, info) => ((Fraction)o).ToInt32()},
			{typeof(long), (o, info) => ((Fraction)o).ToInt64()},
			{typeof(decimal), (o, info) => ((Fraction)o).ToDecimal()},
			{typeof(double), (o, info) => ((Fraction)o).ToDouble()},
			{typeof(Fraction), (o, info) => ((Fraction)o)},
            {typeof(BigInteger), (o, info) => ((Fraction)o).ToBigInteger()}
		};

		private static readonly Dictionary<Type, Func<object, CultureInfo, Fraction>> _convert_from_dictionary = new Dictionary<Type, Func<object, CultureInfo, Fraction>> {
			{typeof(string), (o, info) => Fraction.FromString((string)o, info)},
			{typeof(int), (o, info) => new Fraction((int)o)},
			{typeof(long), (o, info) => new Fraction((long)o)},
			{typeof(decimal), (o, info) => Fraction.FromDecimal((decimal)o)},
			{typeof(double), (o, info) => Fraction.FromDouble((double)o)},
			{typeof(Fraction), (o, info) => (Fraction)o},
            {typeof(BigInteger), (o, info) => new Fraction((BigInteger)o)}
		};

	    /// <summary>
        /// Returns whether the type converter can convert an object to the specified type. 
	    /// </summary>
        /// <param name="context">An object that provides a format context.</param>
        /// <param name="destination_type">The type you want to convert to.</param>
        /// <returns><c>true</c> if this converter can perform the conversion; otherwise, <c>false</c>.</returns>
	    public override bool CanConvertTo(ITypeDescriptorContext context, Type destination_type) {
			return _supported_types.Contains(destination_type);
		}

        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context. 
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext "/>that provides a format context. </param>
        /// <param name="source_type">A <see cref="Type"/> that represents the type you want to convert from. </param>
        /// <returns><c>true</c>if this converter can perform the conversion; otherwise, <c>false</c>.</returns>
	    public override bool CanConvertFrom(ITypeDescriptorContext context, Type source_type) {
			return _supported_types.Contains(source_type);
		}

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information. 
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="culture">A CultureInfo. If <c>null</c> is passed, the current culture is assumed.</param>
        /// <param name="value">The <see cref="Object"/> to convert.</param>
        /// <param name="destination_type">The <see cref="Type" />  to convert the value parameter to.</param>
        /// <returns>An <see cref="Object"/> that represents the converted value.</returns>
	   	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destination_type) {
			Func<object, CultureInfo, object> func;
			return (!ReferenceEquals(value, null) && _convert_to_dictionary.TryGetValue(destination_type, out func))
				? func(value, culture) 
				: base.ConvertTo(context, culture, value, destination_type);
		}

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to use as the current culture.</param>
        /// <param name="value">The <see cref="Object"/> to convert.</param>
        /// <returns>An <see cref="Object"/> that represents the converted value.</returns>
	    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
			if (ReferenceEquals(value, null)) {
				return Fraction.Zero;
			}

			Func<object, CultureInfo, Fraction> func;
			return _convert_from_dictionary.TryGetValue(value.GetType(), out func)
				? func(value, culture)
				: base.ConvertFrom(context, culture, value);
		}
	}
}