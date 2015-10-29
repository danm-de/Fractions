using System;

namespace Fractions.Formatter {
    /// <summary>
    /// Default <see cref="Fraction.ToString()"/> formatter.
    /// </summary>
    public class DefaultFractionFormatProvider : IFormatProvider {
        /// <summary>
        /// Singleton instance
        /// </summary>
        public static readonly IFormatProvider Instance = new DefaultFractionFormatProvider();

        object IFormatProvider.GetFormat(Type format_type) {
            return format_type == typeof (Fraction) 
                ? DefaultFractionFormatter.Instance
                : null;
        }
    }
}