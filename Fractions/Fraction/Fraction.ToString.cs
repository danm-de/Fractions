using System.Diagnostics.Contracts;
using System.Globalization;
using System.Numerics;

namespace Fractions {
    public partial struct Fraction
    {
        /// <summary>
        /// Returns the fraction as "numerator/denominator" or just "numerator" if the denominator has a value of 1.
        /// The returning value is culture invariant (<see cref="CultureInfo" />).
        /// </summary>
        /// <returns>"numerator/denominator" or just "numerator"</returns>
        [Pure]
        public override string ToString() {
            // ReSharper disable ImpureMethodCallOnReadonlyValueField
            if (_denominator == BigInteger.One) {
                return _numerator.ToString(CultureInfo.InvariantCulture);

            }
            return string.Concat(
                _numerator.ToString(CultureInfo.InvariantCulture),
                "/",
                _denominator.ToString(CultureInfo.InvariantCulture));
            // ReSharper restore ImpureMethodCallOnReadonlyValueField
        }
    }
}