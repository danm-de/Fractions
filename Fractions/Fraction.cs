using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Fractions {
    /// <summary>
    /// A mathematical fraction. A rational number written as a/b (a is the numerator and b the denominator). 
    /// The data type is not capable to store NaN (not a number) or infinite.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof (FractionTypeConverter))]
    [StructLayout(LayoutKind.Sequential)]
    public struct Fraction : IEquatable<Fraction>, IComparable, IComparable<Fraction> {
        /// <summary>
        /// The fraction's state.
        /// </summary>
        public enum FractionState {
            /// <summary>
            /// Unknown state.
            /// </summary>
            Unknown,

            /// <summary>
            /// A reduced/simplified fraction.
            /// </summary>
            IsNormalized
        }

        [NonSerialized] private static readonly BigInteger MIN_DECIMAL = new BigInteger(decimal.MinValue);
        [NonSerialized] private static readonly BigInteger MAX_DECIMAL = new BigInteger(decimal.MaxValue);

        [NonSerialized] private static readonly Fraction _zero = new Fraction(BigInteger.Zero, BigInteger.Zero,
            FractionState.IsNormalized);

        [NonSerialized] private static readonly Fraction _one = new Fraction(BigInteger.One, BigInteger.One,
            FractionState.IsNormalized);

        [NonSerialized] private static readonly Fraction _minus_one = new Fraction(BigInteger.MinusOne, BigInteger.One,
            FractionState.IsNormalized);

        private readonly BigInteger _denominator;
        private readonly BigInteger _numerator;
        private readonly FractionState _state;

        #region constructors

        /// <summary>
        /// Create a fraction with <paramref name="numerator"/>, <paramref name="denominator"/> and the fraction' <paramref name="state"/>. 
        /// Warning: if you use unreduced values combined with a state of <see cref="FractionState.IsNormalized"/> 
        /// you will get wrong results when working with the fraction value.
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        /// <param name="state"></param>
        private Fraction(BigInteger numerator, BigInteger denominator, FractionState state) {
            _numerator = numerator;
            _denominator = denominator;
            _state = state;
        }

        /// <summary>
        /// Creates a normalized (reduced/simplified) fraction using <paramref name="numerator"/> and <paramref name="denominator"/>.
        /// </summary>
        /// <param name="numerator">Numerator</param>
        /// <param name="denominator">Denominator</param>
        public Fraction(BigInteger numerator, BigInteger denominator)
            : this(numerator, denominator, true) {}

        /// <summary>
        /// Creates a normalized (reduced/simplified) or unnormalized fraction using <paramref name="numerator"/> and <paramref name="denominator"/>.
        /// </summary>
        /// <param name="numerator">Numerator</param>
        /// <param name="denominator">Denominator</param>
        /// <param name="normalize">If <c>true</c> the fraction will be created as reduced/simplified fraction. 
        /// This is recommended, especially if your applications requires that the results of the equality methods <see cref="object.Equals(object)"/> 
        /// and <see cref="IComparable.CompareTo"/> are always the same. (1/2 != 2/4)</param>
        public Fraction(BigInteger numerator, BigInteger denominator, bool normalize) {
            if (normalize) {
                this = GetReducedFraction(numerator, denominator);
                return;
            }

            _state = (numerator.IsZero && denominator.IsZero)
                ? FractionState.IsNormalized
                : FractionState.Unknown;

            _numerator = numerator;
            _denominator = denominator;
        }

        /// <summary>
        /// Creates a normalized fraction using a signed 32bit integer.
        /// </summary>
        /// <param name="numerator">integer value that will be used for the numerator. The denominator will be 1.</param>
        public Fraction(int numerator) {
            _numerator = new BigInteger(numerator);
            _denominator = (numerator != 0) ? BigInteger.One : BigInteger.Zero;
            _state = FractionState.IsNormalized;
        }

        /// <summary>
        /// Creates a normalized fraction using a signed 64bit integer.
        /// </summary>
        /// <param name="numerator">integer value that will be used for the numerator. The denominator will be 1.</param>
        public Fraction(long numerator) {
            _numerator = new BigInteger(numerator);
            _denominator = numerator != 0 ? BigInteger.One : BigInteger.Zero;
            _state = FractionState.IsNormalized;
        }

        /// <summary>
        /// Creates a normalized fraction using a unsigned 32bit integer.
        /// </summary>
        /// <param name="numerator">integer value that will be used for the numerator. The denominator will be 1.</param>
        public Fraction(uint numerator) {
            _numerator = new BigInteger(numerator);
            _denominator = numerator != 0 ? BigInteger.One : BigInteger.Zero;
            _state = FractionState.IsNormalized;
        }


        /// <summary>
        /// Creates a normalized fraction using a unsigned 64bit integer.
        /// </summary>
        /// <param name="numerator">integer value that will be used for the numerator. The denominator will be 1.</param>
        public Fraction(ulong numerator) {
            _numerator = new BigInteger(numerator);
            _denominator = numerator != 0 ? BigInteger.One : BigInteger.Zero;
            _state = FractionState.IsNormalized;
        }

        /// <summary>
        /// Creates a normalized fraction using a big integer.
        /// </summary>
        /// <param name="numerator">big integer value that will be used for the numerator. The denominator will be 1.</param>
        public Fraction(BigInteger numerator) {
            _numerator = numerator;
            _denominator = numerator.IsZero ? BigInteger.Zero : BigInteger.One;
            _state = FractionState.IsNormalized;
        }


        /// <summary>
        /// Creates a normalized fraction using a 64bit floating point value (double).
        /// The value will not be rounded therefore you will probably get huge numbers as numerator und denominator. 
        /// <see cref="double"/> values are not able to store simple rational numbers like 0.2 or 0.3 - so please 
        /// don't be worried if the fraction looks weird. For more information visit 
        /// http://en.wikipedia.org/wiki/Floating_point
        /// </summary>
        /// <param name="value">Floating point value.</param>
        public Fraction(double value) {
            this = FromDouble(value);
        }

        /// <summary>
        /// Creates a normalized fraction using a 128bit decimal value (decimal).
        /// </summary>
        /// <param name="value">Floating point value.</param>
        public Fraction(decimal value) {
            this = FromDecimal(value);
        }

        #endregion

        /// <summary>
        /// The numerator.
        /// </summary>
        [Pure]
        public BigInteger Numerator => _numerator;

        /// <summary>
        /// The denominator
        /// </summary>
        [Pure]
        public BigInteger Denominator => _denominator;

        /// <summary>
        /// <c>true</c> if the value is positive (greater than or equal to 0).
        /// </summary>
        [Pure]
        public bool IsPositive => (_numerator.Sign == 1 && _denominator.Sign == 1) ||
                                  (_numerator.Sign == -1 && _denominator.Sign == -1);

        /// <summary>
        /// <c>true</c> if the value is negative (lesser than 0).
        /// </summary>
        [Pure]
        public bool IsNegative => (_numerator.Sign == -1 && _denominator.Sign == 1) ||
                                  (_numerator.Sign == 1 && _denominator.Sign == -1);

        /// <summary>
        /// <c>true</c> if the fraction has a real (calculated) value of 0.
        /// </summary>
        [Pure]
        public bool IsZero => _numerator.IsZero || _denominator.IsZero;

        /// <summary>
        /// The fraction's state.
        /// </summary>
        [Pure]
        public FractionState State => _state;

        /// <summary>
        /// A fraction with the reduced/simplified value of 0.
        /// </summary>
        [Pure]
        public static Fraction Zero => _zero;

        /// <summary>
        /// A fraction with the reduced/simplified value of 1.
        /// </summary>
        [Pure]
        public static Fraction One => _one;

        /// <summary>
        /// A fraction with the reduced/simplified value of -1.
        /// </summary>
        [Pure]
        public static Fraction MinusOne => _minus_one;

        /// <summary>
        /// Calculates the remainder of the division with the fraction's value and the supplied <paramref name="divisor"/> (% operator).
        /// </summary>
        /// <param name="divisor">Divisor</param>
        /// <returns>The remainder (left over)</returns>
        public Fraction Remainder(Fraction divisor) {
            if (divisor.IsZero) {
                throw new DivideByZeroException();
            }
            if (IsZero) {
                return _zero;
            }

            var gcd = BigInteger.GreatestCommonDivisor(_denominator, divisor.Denominator);

            var this_multiplier = BigInteger.Divide(_denominator, gcd);
            var other_multiplier = BigInteger.Divide(divisor.Denominator, gcd);

            var least_common_multiple = BigInteger.Multiply(this_multiplier, divisor.Denominator);

            var a = BigInteger.Multiply(_numerator, other_multiplier);
            var b = BigInteger.Multiply(divisor.Numerator, this_multiplier);

            var remainder = BigInteger.Remainder(a, b);

            return new Fraction(remainder, least_common_multiple);
        }


        /// <summary>
        /// Adds the fraction's value with <paramref name="summand"/>.
        /// </summary>
        /// <param name="summand">Summand</param>
        /// <returns>The result as summation.</returns>
        [Pure]
        public Fraction Add(Fraction summand) {
            if (_denominator == summand.Denominator) {
                return new Fraction(BigInteger.Add(_numerator, summand.Numerator), _denominator, true);
            }

            if (IsZero) {
                // 0 + b = b
                return summand;
            }

            if (summand.IsZero) {
                // a + 0 = a
                return this;
            }

            var gcd = BigInteger.GreatestCommonDivisor(_denominator, summand.Denominator);

            var this_multiplier = BigInteger.Divide(_denominator, gcd);
            var other_multiplier = BigInteger.Divide(summand.Denominator, gcd);

            var least_common_multiple = BigInteger.Multiply(this_multiplier, summand.Denominator);

            var calculated_numerator = BigInteger.Add(
                BigInteger.Multiply(_numerator, other_multiplier),
                BigInteger.Multiply(summand.Numerator, this_multiplier)
                );

            return new Fraction(calculated_numerator, least_common_multiple, true);
        }

        /// <summary>
        /// Subtracts the fraction's value (minuend) with <paramref name="subtrahend"/>.
        /// </summary>
        /// <param name="subtrahend">Subtrahend.</param>
        /// <returns>The result as difference.</returns>
        [Pure]
        public Fraction Subtract(Fraction subtrahend) {
            return Add(subtrahend.Invert());
        }

        /// <summary>
        /// Inverts the fraction. Has the same result as multiplying it by -1.
        /// </summary>
        /// <returns>The inverted fraction.</returns>
        [Pure]
        public Fraction Invert() {
            if (IsZero) {
                return _zero;
            }
            return new Fraction(BigInteger.Negate(_numerator), _denominator, _state);
        }

        /// <summary>
        /// Multiply the fraction's value by <paramref name="factor"/>.
        /// </summary>
        /// <param name="factor">Factor</param>
        /// <returns>The result as product.</returns>
        [Pure]
        public Fraction Multiply(Fraction factor) {
            return new Fraction(
                (_numerator * factor._numerator),
                (_denominator * factor._denominator),
                true);
        }

        /// <summary>
        /// Divides the fraction's value by <paramref name="divisor"/>.
        /// </summary>
        /// <param name="divisor">Divisor</param>
        /// <returns>The result as quotient.</returns>
        [Pure]
        public Fraction Divide(Fraction divisor) {
            if (divisor.IsZero) {
                throw new DivideByZeroException(string.Format(Exceptions.DivideByZero, this));
            }

            return new Fraction(
                (_numerator * divisor._denominator),
                (_denominator * divisor._numerator),
                true);
        }

        /// <summary>
        /// Compares the calculated value with the supplied <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">Fraction that shall be compared with.</param>
        /// <returns>
        /// Less than 0 if <paramref name="obj"/> is greater.
        /// Zero (0) if both calculated values are equal.
        /// Greater then zero (0) if <paramref name="obj"/> less.</returns>
        /// <exception cref="ArgumentException">If <paramref name="obj"/> is not of type <see cref="Fraction"/>.</exception>
        [Pure]
        public int CompareTo(object obj) {
            if (obj == null) {
                return 1;
            }

            if (obj.GetType() != typeof (Fraction)) {
                throw new ArgumentException(
                    string.Format(Exceptions.CompareToArgumentException, GetType(), obj.GetType()), "obj");
            }

            return CompareTo((Fraction) obj);
        }

        /// <summary>
        /// Compares the calculated value with the supplied <paramref name="other"/>.
        /// </summary>
        /// <param name="other">Fraction that shall be compared with.</param>
        /// <returns>
        /// Less than 0 if <paramref name="other"/> is greater.
        /// Zero (0) if both calculated values are equal.
        /// Greater then zero (0) if <paramref name="other"/> less.</returns>
        [Pure]
        public int CompareTo(Fraction other) {
            if (_denominator == other._denominator) {
                return _numerator.CompareTo(other._numerator);
            }

            if (IsZero != other.IsZero) {
                if (IsZero) {
                    return other.IsPositive ? -1 : 1;
                }
                return IsPositive ? 1 : -1;
            }

            var gcd = BigInteger.GreatestCommonDivisor(_denominator, other._denominator);

            var this_multiplier = BigInteger.Divide(_denominator, gcd);
            var other_multiplier = BigInteger.Divide(other._denominator, gcd);

            var a = BigInteger.Multiply(_numerator, other_multiplier);
            var b = BigInteger.Multiply(other._numerator, this_multiplier);

            return a.CompareTo(b);
        }

        /// <summary>
        /// Returns the fraction as "numerator/denominator" or just "numerator" if the denominator has a value of 1.
        /// The returning value is culture invariant (<see cref="CultureInfo" />).
        /// </summary>
        /// <returns>"numerator/denominator" or just "numerator"</returns>
        [PureAttribute]
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

        /// <summary>
        /// Tests if the calculated value of this fraction equals to the calculated value of <paramref name="other"/>.
        /// It does not matter if either of them is not normalized. Both values will be reduced (normalized) before performing 
        /// the <see cref="object.Equals(object)"/> test.
        /// </summary>
        /// <param name="other">The fraction to compare with.</param>
        /// <returns><c>true</c> if both values are equivalent. (e.g. 2/4 is equivalent to 1/2. But 2/4 is not equivalent to -1/2)</returns>
        [Pure]
        public bool IsEquivalentTo(Fraction other) {
            var a = Reduce();
            var b = other.Reduce();

            return a.Equals(b);
        }

        /// <summary>
        /// <para>Performs an exact comparison with <paramref name="other"/> using numerator and denominator.</para>
        /// <para>Warning: 1/2 is NOT equal to 2/4! -1/2 is NOT equal to 1/-2!</para>
        /// <para>If you want to test the calculated values for equality use <see cref="CompareTo(Fraction)"/> or
        /// <see cref="IsEquivalentTo"/> </para>
        /// </summary>
        /// <param name="other">The fraction to compare with.</param>
        /// <returns><c>true</c> if numerator and denominator of both fractions are equal.</returns>
        [Pure]
        public bool Equals(Fraction other) {
            return other._denominator.Equals(_denominator) && other._numerator.Equals(_numerator);
        }

        /// <summary>
        /// <para>Performs an exact comparison with <paramref name="other"/> using numerator and denominator.</para>
        /// <para>Warning: 1/2 is NOT equal to 2/4! -1/2 is NOT equal to 1/-2!</para>
        /// <para>If you want to test the calculated values for equality use <see cref="CompareTo(Fraction)"/> or
        /// <see cref="IsEquivalentTo"/> </para>
        /// </summary>
        /// <param name="other">The fraction to compare with.</param>
        /// <returns><c>true</c> if <paramref name="other"/> is type of <see cref="Fraction"/> and numerator and denominator of both are equal.</returns>
        [Pure]
        public override bool Equals(object other) {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            return other is Fraction && Equals((Fraction) other);
        }

        /// <summary>
        /// Returns the hash code.
        /// </summary>
        /// <returns>
        /// A 32bit integer with sign. It has been constructed using the <see cref="Numerator"/> and the <see cref="Denominator"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        [Pure]
        public override int GetHashCode() {
            unchecked {
                return (_denominator.GetHashCode() * 397) ^ _numerator.GetHashCode();
            }
        }

        /// <summary>
        /// Returns this as reduced/simplified fraction. The fraction's sign will be normalized.
        /// </summary>
        /// <returns>A reduced and normalized fraction.</returns>
        [Pure]
        public Fraction Reduce() {
            return (_state == FractionState.IsNormalized)
                ? this
                : GetReducedFraction(_numerator, _denominator);
        }

        #region ToDataTypeMethods

        /// <summary>
        /// Returns the fraction as signed 32bit integer.
        /// </summary>
        /// <returns>32bit signed integer</returns>
        [Pure]
        public int ToInt32() {
            if (IsZero) {
                return 0;
            }
            return (int) (Numerator / Denominator);
        }

        /// <summary>
        /// Returns the fraction as signed 64bit integer.
        /// </summary>
        /// <returns>64bit signed integer</returns>
        [Pure]
        public long ToInt64() {
            if (IsZero) {
                return 0;
            }
            return (long) (Numerator / Denominator);
        }

        /// <summary>
        /// Returns the fraction as unsigned 32bit integer.
        /// </summary>
        /// <returns>32bit unsigned integer</returns>
        [Pure]
        public uint ToUInt32() {
            if (IsZero) {
                return 0;
            }
            return (uint) (Numerator / Denominator);
        }

        /// <summary>
        /// Returns the fraction as unsigned 64bit integer.
        /// </summary>
        /// <returns>64-Bit unsigned integer</returns>
        [Pure]
        public ulong ToUInt64() {
            if (IsZero) {
                return 0;
            }
            return (ulong) (Numerator / Denominator);
        }

        /// <summary>
        /// Returns the fraction as BigInteger.
        /// </summary>
        /// <returns>BigInteger</returns>
        [Pure]
        public BigInteger ToBigInteger() {
            if (IsZero) {
                return BigInteger.Zero;
            }
            return Numerator / Denominator;
        }

        /// <summary>
        /// Returns the fraction as (rounded!) decimal value.
        /// </summary>
        /// <returns>Decimal value</returns>
        [Pure]
        public decimal ToDecimal() {
            if (IsZero) {
                return decimal.Zero;
            }

            if ((_numerator >= MIN_DECIMAL && _numerator <= MAX_DECIMAL)
                && (_denominator >= MIN_DECIMAL && _denominator <= MAX_DECIMAL)) {
                return ((decimal) _numerator) / ((decimal) _denominator);
            }

            // numerator or denominator is too big. Lets try to split the calculation..
            // Possible OverFlowException!
            var without_decimal_places = (decimal) (_numerator / _denominator);

            var remainder = _numerator % _denominator;
            var lowpart = (remainder * BigInteger.Pow(10, 28)) / _denominator;
            var decimal_places = (((decimal) lowpart) / (decimal) Math.Pow(10, 28));

            return without_decimal_places + decimal_places;
        }

        /// <summary>
        /// Returns the fraction as (rounded!) floating point value.
        /// </summary>
        /// <returns>A floating point value</returns>
        [Pure]
        public double ToDouble() {
            if (IsZero) {
                return 0;
            }
            return ((double) Numerator) / ((double) Denominator);
        }

        #endregion ToDataTypeMethods

        #region FromDataTypeMethods

        /// <summary>
        /// Converts a string to a fraction. Example: "3/4" or "4.5" (the decimal separator character is depending on the system culture).
        /// If the number contains a decimal separator it will be parsed as <see cref="decimal"/>.
        /// </summary>
        /// <param name="fraction_string">A fraction or a (decimal) number. The numerator and denominator must be separated with a '/' (slash) character.</param>
        /// <returns>A fraction</returns>
        [Pure]
        public static Fraction FromString(string fraction_string) {
            return FromString(fraction_string, NumberStyles.Number, null);
        }

        /// <summary>
        /// Converts a string to a fraction. Example: "3/4" or "4.5" (the decimal separator character depends on <paramref name="format_provider"/>).
        /// If the number contains a decimal separator it will be parsed as <see cref="decimal"/>.
        /// </summary>
        /// <param name="fraction_string">A fraction or a (decimal) number. The numerator and denominator must be separated with a '/' (slash) character.</param>
        /// <param name="format_provider">Provides culture specific information that will be used to parse the <paramref name="fraction_string"/>.</param>
        /// <returns>Ein Bruch</returns>
        [Pure]
        public static Fraction FromString(string fraction_string, IFormatProvider format_provider) {
            return FromString(fraction_string, NumberStyles.Number, format_provider);
        }

        /// <summary>
        /// Converts a string to a fraction. Example: "3/4" or "4.5" (the decimal separator character depends on <paramref name="format_provider"/>).
        /// If the number contains a decimal separator it will be parsed as <see cref="decimal"/>.
        /// </summary>
        /// <param name="fraction_string">A fraction or a (decimal) number. The numerator and denominator must be separated with a '/' (slash) character.</param>
        /// <param name="number_styles">A bitwise combination of number styles that are allowed in <paramref name="fraction_string"/>.</param>
        /// <param name="format_provider">Provides culture specific information that will be used to parse the <paramref name="fraction_string"/>.</param>
        /// <returns>Ein Bruch</returns>
        [Pure]
        public static Fraction FromString(string fraction_string, NumberStyles number_styles,
            IFormatProvider format_provider) {
            if (fraction_string == null) {
                throw new ArgumentNullException(nameof(fraction_string));
            }

            Fraction fraction;
            if (!TryParse(fraction_string, number_styles, format_provider, out fraction)) {
                throw new FormatException(string.Format(Exceptions.CannotConvertToFraction, fraction_string));
            }

            return fraction;
        }

        /// <summary>
        /// Try to convert a string to a fraction. Example: "3/4" or "4.5" (the decimal separator character depends on the system's culture).
        /// If the number contains a decimal separator it will be parsed as <see cref="decimal"/>.
        /// </summary>
        /// <param name="fraction_string">A fraction or a (decimal) number. The numerator and denominator must be separated with a '/' (slash) character.</param>
        /// <param name="fraction">A <see cref="Fraction"/> if the method returns with <c>true</c>. Otherwise the value is invalid.</param>
        /// <returns>
        /// <para><c>true</c> if <paramref name="fraction_string"/> was well formed. The parsing result will be written to <paramref name="fraction"/>. </para>
        /// <para><c>false</c> if <paramref name="fraction_string"/> was invalid.</para></returns>
        [Pure]
        public static bool TryParse(string fraction_string, out Fraction fraction) {
            return TryParse(fraction_string, NumberStyles.Number, null, out fraction);
        }


        /// <summary>
        /// Try to convert a string to a fraction. Example: "3/4" or "4.5" (the decimal separator character depends on <paramref name="format_provider"/>).
        /// If the number contains a decimal separator it will be parsed as <see cref="decimal"/>.
        /// </summary>
        /// <param name="fraction_string">A fraction or a (decimal) number. The numerator and denominator must be separated with a '/' (slash) character.</param>
        /// <param name="number_styles">A bitwise combination of number styles that are allowed in <paramref name="fraction_string"/>.</param>
        /// <param name="format_provider">Provides culture specific information that will be used to parse the <paramref name="fraction_string"/>.</param>
        /// <param name="fraction">A <see cref="Fraction"/> if the method returns with <c>true</c>. Otherwise the value is invalid.</param>
        /// <returns>
        /// <para><c>true</c> if <paramref name="fraction_string"/> was well formed. The parsing result will be written to <paramref name="fraction"/>. </para>
        /// <para><c>false</c> if <paramref name="fraction_string"/> was invalid.</para>
        /// </returns>
        [Pure]
        public static bool TryParse(string fraction_string, NumberStyles number_styles, IFormatProvider format_provider,
            out Fraction fraction) {
            if (fraction_string == null) {
                return CannotParse(out fraction);
            }

            var components = fraction_string.Split('/');
            if (components.Length == 1) {
                return TryParseSingleNumber(components[0], number_styles, format_provider, out fraction);
            }

            if (components.Length >= 2) {
                var numerator_string = components[0];
                var denominator_string = components[1];

                BigInteger numerator, denominator;
                var without_decimalpoint = number_styles & (~NumberStyles.AllowDecimalPoint);
                if (BigInteger.TryParse(numerator_string, without_decimalpoint, format_provider, out numerator) &&
                    BigInteger.TryParse(denominator_string, without_decimalpoint, format_provider, out denominator)) {

                    fraction = new Fraction(numerator, denominator);
                    return true;
                }
            }

            // Technically it should not be possible to reach this line of code..
            return CannotParse(out fraction);
        }

        /// <summary>
        /// Try to convert a single number to a fraction. Example 34 or 4.5 (depending on the supplied culture used in <paramref name="format_provider"/>)
        /// If the number contains a decimal separator it will be parsed as <see cref="decimal"/>.
        /// </summary>
        /// <param name="number">A (decimal) number</param>
        /// <param name="number_styles">A bitwise combination of number styles that are allowed in <paramref name="number"/>.</param>
        /// <param name="format_provider">Provides culture specific information that will be used to parse the <paramref name="number"/>.</param>
        /// <param name="fraction">A <see cref="Fraction"/> if the method returns with <c>true</c>. Otherwise the value is invalid.</param>
        /// <returns>
        /// <para><c>true</c> if <paramref name="number"/> was well formed. The parsing result will be written to <paramref name="fraction"/>. </para>
        /// <para><c>false</c> if <paramref name="number"/> was invalid.</para>
        /// </returns>
        private static bool TryParseSingleNumber(string number, NumberStyles number_styles,
            IFormatProvider format_provider, out Fraction fraction) {
            var number_format_info = NumberFormatInfo.GetInstance(format_provider);

            if (number.Contains(number_format_info.NumberDecimalSeparator)) {
                decimal decimal_number;
                if (decimal.TryParse(number, number_styles, format_provider, out decimal_number)) {
                    fraction = FromDecimal(decimal_number);
                    return true;
                }
            } else {
                BigInteger numerator;
                var without_decimalpoint = number_styles & (~NumberStyles.AllowDecimalPoint);
                if (BigInteger.TryParse(number, without_decimalpoint, format_provider, out numerator)) {
                    fraction = new Fraction(numerator);
                    return true;
                }
            }
            return CannotParse(out fraction);
        }

        /// <summary>
        /// Returns false. <paramref name="fraction"/> contains an invalid value.
        /// </summary>
        /// <param name="fraction">Returns <c>default()</c> of <see cref="Fraction"/></param>
        /// <returns><c>false</c></returns>
        [Pure]
        private static bool CannotParse(out Fraction fraction) {
            fraction = default(Fraction);
            return false;
        }

        /// <summary>
        /// Converts a floating point value to a fraction. The value will not be rounded therefore you will probably 
        /// get huge numbers as numerator und denominator. <see cref="double"/> values are not able to store simple rational
        /// numbers like 0.2 or 0.3 - so please don't be worried if the fraction looks weird. For more information visit 
        /// http://en.wikipedia.org/wiki/Floating_point
        /// </summary>
        /// <param name="value">A floating point value.</param>
        /// <returns>A fraction</returns>
        /// <exception cref="InvalidNumberException">If <paramref name="value"/> is NaN (not a number) or infinite.</exception>
        [Pure]
        public static Fraction FromDouble(double value) {
            if (double.IsNaN(value) || double.IsInfinity(value)) {
                throw new InvalidNumberException();
            }

            // No rounding here! It will convert the actual number that is stored as double! 
            // See http://www.mpdvc.de/artikel/FloatingPoint.htm

            const ulong SIGN_BIT = 0x8000000000000000;
            const ulong EXPONENT_BITS = 0x7FF0000000000000;
            const ulong MANTISSA = 0x000FFFFFFFFFFFFF;
            const ulong MANTISSA_DIVISOR = 0x0010000000000000;
            const ulong K = 1023;
            var one = BigInteger.One;

            // value = (-1 * sign)   *   (1 + 2^(-1) + 2^(-2) .. + 2^(-52))   *   2^(exponent-K)
            var value_bits = unchecked((ulong) BitConverter.DoubleToInt64Bits(value));

            if (value_bits == 0) {
                // See IEEE 754
                return Zero;
            }

            var is_negative = (value_bits & SIGN_BIT) == SIGN_BIT;
            var mantissa_bits = (value_bits & MANTISSA);

            // (exponent-K)
            var exponent = (int) (((value_bits & EXPONENT_BITS) >> 52) - K);

            // (1 + 2^(-1) + 2^(-2) .. + 2^(-52))
            var mantissa = new Fraction(mantissa_bits + MANTISSA_DIVISOR, MANTISSA_DIVISOR);

            // 2^exponent
            var factor = (exponent < 0)
                ? new Fraction(one, one << Math.Abs(exponent))
                : new Fraction(one << exponent);

            var result = mantissa * factor;

            return (is_negative)
                ? result.Invert()
                : result;
        }

        /// <summary>
        /// Converts a decimal value in a fraction. The value will not be rounded.
        /// </summary>
        /// <param name="value">A decimal value.</param>
        /// <returns>A fraction.</returns>
        [Pure]
        public static Fraction FromDecimal(decimal value) {
            if (value == decimal.Zero) {
                return _zero;
            }

            if (value == decimal.One) {
                return _one;
            }

            if (value == decimal.MinusOne) {
                return _minus_one;
            }

            var bits = decimal.GetBits(value);
            var low = BitConverter.GetBytes(bits[0]);
            var middle = BitConverter.GetBytes(bits[1]);
            var high = BitConverter.GetBytes(bits[2]);
            var scale = BitConverter.GetBytes(bits[3]);


            var exp = scale[2];
            bool positive_sign = (scale[3] & 0x80) == 0;

            // value = 0x00,high,middle,low / 10^exp
            var numerator = new BigInteger(new byte[] {
                low[0], low[1], low[2], low[3],
                middle[0], middle[1], middle[2], middle[3],
                high[0], high[1], high[2], high[3],
                0x00
            });
            var denominator = BigInteger.Pow(10, exp);

            return positive_sign
                ? new Fraction(numerator, denominator, true)
                : new Fraction(BigInteger.Negate(numerator), denominator, true);
        }

        #endregion FromDataTypeMethods

        /// <summary>
        /// Returns a reduced and normalized fraction.
        /// </summary>
        /// <param name="numerator">Numerator</param>
        /// <param name="denominator">Denominator</param>
        /// <returns>A reduced and normalized fraction</returns>
        [Pure]
        public static Fraction GetReducedFraction(BigInteger numerator, BigInteger denominator) {
            if (numerator.IsZero || denominator.IsZero) {
                return Zero;
            }

            if (denominator.Sign == -1) {
                // Denominator must not be negative after normalization
                numerator = BigInteger.Negate(numerator);
                denominator = BigInteger.Negate(denominator);
            }

            var gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);
            if (!gcd.IsOne && !gcd.IsZero) {
                return new Fraction(BigInteger.Divide(numerator, gcd), BigInteger.Divide(denominator, gcd),
                    FractionState.IsNormalized);
            }

            return new Fraction(numerator, denominator, FractionState.IsNormalized);
        }

        /// <summary>
        /// Returns a fraction raised to the specified power.
        /// </summary>
        /// <param name="base">base to be raised to a power</param>
        /// <param name="exponent">A number that specifies a power (exponent)</param>
        /// <returns>The fraction <paramref name="base"/> raised to the power <paramref name="exponent"/>.</returns>
        [PureAttribute]
        public static Fraction Pow(Fraction @base, int exponent) {
            return (exponent < 0)
                ? Pow(new Fraction(@base._denominator, @base._numerator), -exponent)
                : new Fraction(BigInteger.Pow(@base._numerator, exponent), BigInteger.Pow(@base._denominator, exponent));
        }

        #region Operators

#pragma warning disable 1591
        public static bool operator ==(Fraction left, Fraction right) {
            return left.Equals(right);
        }

        public static bool operator !=(Fraction left, Fraction right) {
            return !left.Equals(right);
        }

        public static Fraction operator +(Fraction a, Fraction b) {
            return a.Add(b);
        }

        public static Fraction operator -(Fraction a, Fraction b) {
            return a.Subtract(b);
        }

        public static Fraction operator *(Fraction a, Fraction b) {
            return a.Multiply(b);
        }

        public static Fraction operator /(Fraction a, Fraction b) {
            return a.Divide(b);
        }

        public static Fraction operator %(Fraction a, Fraction b) {
            return a.Remainder(b);
        }

        public static bool operator <(Fraction a, Fraction b) {
            return a.CompareTo(b) < 0;
        }

        public static bool operator >(Fraction a, Fraction b) {
            return a.CompareTo(b) > 0;
        }

        public static bool operator <=(Fraction a, Fraction b) {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator >=(Fraction a, Fraction b) {
            return a.CompareTo(b) >= 0;
        }

        public static implicit operator Fraction(int value) {
            return new Fraction(value);
        }

        public static implicit operator Fraction(long value) {
            return new Fraction(value);
        }

        public static implicit operator Fraction(uint value) {
            return new Fraction(value);
        }

        public static implicit operator Fraction(ulong value) {
            return new Fraction(value);
        }

        public static implicit operator Fraction(BigInteger value) {
            return new Fraction(value);
        }

        public static explicit operator Fraction(double value) {
            return new Fraction(value);
        }

        public static explicit operator Fraction(decimal value) {
            return new Fraction(value);
        }

        public static explicit operator Fraction(string value) {
            return FromString(value);
        }

        public static explicit operator int(Fraction fraction) {
            return fraction.ToInt32();
        }

        public static explicit operator long(Fraction fraction) {
            return fraction.ToInt64();
        }

        public static explicit operator uint(Fraction fraction) {
            return fraction.ToUInt32();
        }

        public static explicit operator ulong(Fraction fraction) {
            return fraction.ToUInt64();
        }

        public static explicit operator decimal(Fraction fraction) {
            return fraction.ToDecimal();
        }

        public static explicit operator double(Fraction fraction) {
            return fraction.ToDouble();
        }
#pragma warning restore 1591

        #endregion Operators
    }
}