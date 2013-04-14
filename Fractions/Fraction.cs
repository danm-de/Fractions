using System;
using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Fractions
{
    /// <summary>
    /// A mathematical fraction. A rational number written as a/b (a is the numerator and b the denominator). 
    /// The data type is not capable to store NaN (not a number) or infinite.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Fraction : IEquatable<Fraction>, IComparable, IComparable<Fraction>
    {
        /// <summary>
        /// The fraction's state.
        /// </summary>
        public enum FractionState
        {
            /// <summary>
            /// Unknown state.
            /// </summary>
            Unknown,
            /// <summary>
            /// A reduced/simplified fraction.
            /// </summary>
            IsNormalized
        }

        private static readonly Fraction _zero = new Fraction(BigInteger.Zero, BigInteger.Zero, FractionState.IsNormalized);
        private static readonly Fraction _one = new Fraction(BigInteger.One, BigInteger.One, FractionState.IsNormalized);
        private static readonly Fraction _minus_one = new Fraction(BigInteger.MinusOne, BigInteger.One, FractionState.IsNormalized);

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
            : this(numerator, denominator, true) { }

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
        public Fraction(Int32 numerator) {
            _numerator = new BigInteger(numerator);
            _denominator = (numerator != 0) ? BigInteger.One : BigInteger.Zero;
            _state = FractionState.IsNormalized;
        }

        /// <summary>
        /// Creates a normalized fraction using a signed 64bit integer.
        /// </summary>
        /// <param name="numerator">integer value that will be used for the numerator. The denominator will be 1.</param>
        public Fraction(Int64 numerator) {
            _numerator = new BigInteger(numerator);
            _denominator = numerator != 0 ? BigInteger.One : BigInteger.Zero;
            _state = FractionState.IsNormalized;
        }

        /// <summary>
        /// Creates a normalized fraction using a unsigned 32bit integer.
        /// </summary>
        /// <param name="numerator">integer value that will be used for the numerator. The denominator will be 1.</param>
        public Fraction(UInt32 numerator) {
            _numerator = new BigInteger(numerator);
            _denominator = numerator != 0 ? BigInteger.One : BigInteger.Zero;
            _state = FractionState.IsNormalized;
        }


        /// <summary>
        /// Creates a normalized fraction using a unsigned 64bit integer.
        /// </summary>
        /// <param name="numerator">integer value that will be used for the numerator. The denominator will be 1.</param>
        public Fraction(UInt64 numerator) {
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
        public BigInteger Numerator {
            get { return _numerator; }
        }

        /// <summary>
        /// The denominator
        /// </summary>
        [Pure]
        public BigInteger Denominator {
            get { return _denominator; }
        }

        /// <summary>
        /// <c>true</c> if the value is positive (greater than or equal to 0).
        /// </summary>
        [Pure]
        public bool IsPositive {
            get {
                return (_numerator.Sign == 1 && _denominator.Sign == 1) || (_numerator.Sign == -1 && _denominator.Sign == -1);
            }
        }

        /// <summary>
        /// <c>true</c> if the value is negative (lesser than 0).
        /// </summary>
        [Pure]
        public bool IsNegative {
            get {
                return (_numerator.Sign == -1 && _denominator.Sign == 1) || (_numerator.Sign == 1 && _denominator.Sign == -1);
            }
        }

        /// <summary>
        /// <c>true</c> if the fraction has a real (calculated) value of 0.
        /// </summary>
        [Pure]
        public bool IsZero {
            get { return _numerator.IsZero || _denominator.IsZero; }
        }

        /// <summary>
        /// The fraction's state.
        /// </summary>
        [Pure]
        public FractionState State {
            get { return _state; }
        }

        /// <summary>
        /// A fraction with the reduced/simplified value of 0.
        /// </summary>
        [Pure]
        public static Fraction Zero {
            get { return _zero; }
        }

        /// <summary>
        /// A fraction with the reduced/simplified value of 1.
        /// </summary>
        [Pure]
        public static Fraction One {
            get { return _one; }
        }

        /// <summary>
        /// A fraction with the reduced/simplified value of -1.
        /// </summary>
        [Pure]
        public static Fraction MinusOne {
            get { return _minus_one; }
        }

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

            BigInteger gcd = BigInteger.GreatestCommonDivisor(Denominator, divisor.Denominator);

            BigInteger this_multiplier = BigInteger.Divide(Denominator, gcd);
            BigInteger other_multiplier = BigInteger.Divide(divisor.Denominator, gcd);

            BigInteger least_common_multiple = BigInteger.Multiply(this_multiplier, divisor.Denominator);

            var a = BigInteger.Multiply(Numerator, other_multiplier);
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
            if (Denominator == summand.Denominator) {
                // Beide Brüche haben bereits den selben Nenner
                return new Fraction(BigInteger.Add(Numerator, summand.Numerator), Denominator, true);
            }

            if (IsZero) {
                // 0 + b = b
                return summand;
            }

            if (summand.IsZero) {
                // a + 0 = a
                return this;
            }

            BigInteger gcd = BigInteger.GreatestCommonDivisor(Denominator, summand.Denominator);

            BigInteger this_multiplier = BigInteger.Divide(Denominator, gcd);
            BigInteger other_multiplier = BigInteger.Divide(summand.Denominator, gcd);

            BigInteger least_common_multiple = BigInteger.Multiply(this_multiplier, summand.Denominator);

            BigInteger calculated_numerator = BigInteger.Add(
                BigInteger.Multiply(Numerator, other_multiplier),
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

            if (obj.GetType() != typeof(Fraction)) {
                throw new ArgumentException(string.Format(Exceptions.CompareToArgumentException, GetType(), obj.GetType()), "obj");
            }

            return CompareTo((Fraction)obj);
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
                // Beide Brüche haben bereits den selben Nenner
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
        /// A string: numerator / denominator.
        /// </summary>
        /// <returns>numerator / denominator</returns>
        [Pure]
        public override string ToString() {
            return String.Format("{0} / {1}", _numerator, _denominator);
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
        /// <para>Performs an exact comparison with <paramref name="obj"/> using numerator and denominator.</para>
        /// <para>Warning: 1/2 is NOT equal to 2/4! -1/2 is NOT equal to 1/-2!</para>
        /// <para>If you want to test the calculated values for equality use <see cref="CompareTo(Fraction)"/> or
        /// <see cref="IsEquivalentTo"/> </para>
        /// </summary>
        /// <param name="obj">The fraction to compare with.</param>
        /// <returns><c>true</c> if <paramref name="obj"/> is type of <see cref="Fraction"/> and numerator and denominator of both are equal.</returns>
        [Pure]
        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (obj.GetType() != typeof(Fraction)) {
                return false;
            }
            return Equals((Fraction)obj);
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
            return (int)(Numerator / Denominator);
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
            return (long)(Numerator / Denominator);
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
            return (uint)(Numerator / Denominator);
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
            return (ulong)(Numerator / Denominator);
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
            return ((decimal)Numerator) / ((decimal)Denominator);
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
            return ((double)Numerator) / ((double)Denominator);
        }
        #endregion ToDataTypeMethods

        #region FromDataTypeMethods

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

            // Hier wird nicht gerundet! Stattdessen wird die tatsächlich, enthaltene Zahl als
            // Bruch erzeugt. Das ist mitunter
            // See http://www.mpdvc.de/artikel/FloatingPoint.htm

            const ulong SIGN_BIT = 0x8000000000000000;
            const ulong EXPONENT_BITS = 0x7FF0000000000000;
            const ulong MANTISSA = 0x000FFFFFFFFFFFFF;
            const ulong MANTISSA_DIVISOR = 0x0010000000000000;
            const ulong K = 1023;
            var one = BigInteger.One;

            // value = (-1 * sign)   *   (1 + 2^(-1) + 2^(-2) .. + 2^(-52))   *   2^(exponent-K)
            var value_bits = unchecked((ulong)BitConverter.DoubleToInt64Bits(value));

            if (value_bits == 0) {
                // See IEEE 754
                return Zero;
            }

            var is_negative = (value_bits & SIGN_BIT) == SIGN_BIT;
            var mantissa_bits = (value_bits & MANTISSA);

            // (exponent-K)
            var exponent = (int)(((value_bits & EXPONENT_BITS) >> 52) - K);

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

            var numerator = new BigInteger(new byte[] { 
                low[0],    low[1],    low[2],    low[3], 
                middle[0], middle[1], middle[2], middle[3],
                high[0],   high[1],   high[2],   high[3], 
                0x00 });
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
                // Der Nenner darf bei einem normalisierten Bruch nicht negativ sein.
                numerator = BigInteger.Negate(numerator);
                denominator = BigInteger.Negate(denominator);
            }

            var gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);
            if (!gcd.IsOne && !gcd.IsZero) {
                // Es wurde ein gößter, gemeinsamer Teiler gefunden -> Bruch vereinfachen
                return new Fraction(BigInteger.Divide(numerator, gcd), BigInteger.Divide(denominator, gcd), FractionState.IsNormalized);
            }

            return new Fraction(numerator, denominator, FractionState.IsNormalized);
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