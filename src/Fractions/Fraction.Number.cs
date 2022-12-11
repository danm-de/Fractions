#if NET7_0
using System;
using System.Globalization;
using System.Numerics;

namespace Fractions {
    public partial struct Fraction : INumber<Fraction> {
        /// <inheritdoc />
        public static Fraction Parse(string s, IFormatProvider provider) =>
            FromString(s, provider);

        /// <inheritdoc />
        public static Fraction Parse(string s, NumberStyles style, IFormatProvider provider) =>
            FromString(s, style, provider);

        /// <inheritdoc />
        public static Fraction Parse(ReadOnlySpan<char> s, IFormatProvider provider) {
            // TODO optimize FromString to use ReadOnlySpan (Split required https://github.com/dotnet/runtime/issues/76186)
            return FromString(s.ToString(), provider);
        }

        /// <inheritdoc />
        public static Fraction Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider) {
            // TODO optimize FromString to use ReadOnlySpan (Split required https://github.com/dotnet/runtime/issues/76186)
            return FromString(s.ToString(), style, provider);
        }

        /// <inheritdoc />
        public static bool TryParse(string s, IFormatProvider provider, out Fraction result) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format,
            IFormatProvider provider) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider provider, out Fraction result) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider,
            out Fraction result) {
            throw new NotImplementedException();
        }


        /// <inheritdoc />
        public static Fraction AdditiveIdentity => throw new NotImplementedException();

        /// <inheritdoc />
        public static Fraction operator --(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static Fraction operator ++(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static Fraction MultiplicativeIdentity => throw new NotImplementedException();

        /// <inheritdoc />
        public static Fraction operator -(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static Fraction operator +(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool IsCanonical(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool IsComplexNumber(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool IsEvenInteger(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool IsFinite(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool IsImaginaryNumber(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool IsInfinity(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool IsInteger(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool IsNaN(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        static bool INumberBase<Fraction>.IsNegative(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool IsNegativeInfinity(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool IsNormal(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool IsOddInteger(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        static bool INumberBase<Fraction>.IsPositive(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool IsPositiveInfinity(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool IsRealNumber(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool IsSubnormal(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        static bool INumberBase<Fraction>.IsZero(Fraction value) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static Fraction MaxMagnitude(Fraction x, Fraction y) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static Fraction MaxMagnitudeNumber(Fraction x, Fraction y) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static Fraction MinMagnitude(Fraction x, Fraction y) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static Fraction MinMagnitudeNumber(Fraction x, Fraction y) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool TryConvertFromChecked<TOther>(TOther value, out Fraction result)
            where TOther : INumberBase<TOther> {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool TryConvertFromSaturating<TOther>(TOther value, out Fraction result)
            where TOther : INumberBase<TOther> {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool TryConvertFromTruncating<TOther>(TOther value, out Fraction result)
            where TOther : INumberBase<TOther> {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool TryConvertToChecked<TOther>(Fraction value, out TOther result)
            where TOther : INumberBase<TOther> {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool TryConvertToSaturating<TOther>(Fraction value, out TOther result)
            where TOther : INumberBase<TOther> {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public static bool TryConvertToTruncating<TOther>(Fraction value, out TOther result)
            where TOther : INumberBase<TOther> {
            throw new NotImplementedException();
        }



        /// <inheritdoc />
        public static int Radix => throw new NotImplementedException();
    }
}
#endif
