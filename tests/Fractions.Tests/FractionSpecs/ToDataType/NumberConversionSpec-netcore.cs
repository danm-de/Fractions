﻿#if NET
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.ToDataType;

public abstract class NumberConversionSpec : Spec {
    public static TNumber CreateChecked<TNumber, TOther>(TOther value)
        where TNumber : INumberBase<TNumber>
        where TOther : INumberBase<TOther> {
        return TNumber.CreateChecked(value);
    }

    public static TNumber CreateSaturating<TNumber, TOther>(TOther value)
        where TNumber : INumberBase<TNumber>
        where TOther : INumberBase<TOther> {
        return TNumber.CreateSaturating(value);
    }

    public static TNumber CreateTruncating<TNumber, TOther>(TOther value)
        where TNumber : INumberBase<TNumber>
        where TOther : INumberBase<TOther> {
        return TNumber.CreateTruncating(value);
    }

    /// <summary>
    ///     Represents a fake number implementation for testing purposes.
    /// </summary>
    /// <remarks>
    ///     This class is used internally within the test suite to simulate a number type that implements the
    ///     <see cref="System.Numerics.INumberBase{T}" /> interface.
    ///     It provides functionality to test conversions and operations involving custom number types.
    /// </remarks>
#pragma warning disable CA1067, CS0660, CS8632
    protected class FakeNumber : INumberBase<FakeNumber> {
        public static FakeNumber Zero { get; } = new();

        static bool INumberBase<FakeNumber>.TryConvertFromChecked<TOther>(TOther value, [MaybeNullWhen(false)] out FakeNumber result) {
            result = null;
            return false;
        }

        static bool INumberBase<FakeNumber>.TryConvertFromSaturating<TOther>(TOther value, [MaybeNullWhen(false)] out FakeNumber result) {
            result = null;
            return false;
        }

        static bool INumberBase<FakeNumber>.TryConvertFromTruncating<TOther>(TOther value, [MaybeNullWhen(false)] out FakeNumber result) {
            result = null;
            return false;
        }

        static bool INumberBase<FakeNumber>.TryConvertToChecked<TOther>(FakeNumber value, [MaybeNullWhen(false)] out TOther result) {
            result = default;
            return false;
        }

        static bool INumberBase<FakeNumber>.TryConvertToSaturating<TOther>(FakeNumber value, [MaybeNullWhen(false)] out TOther result) {
            result = default;
            return false;
        }

        static bool INumberBase<FakeNumber>.TryConvertToTruncating<TOther>(FakeNumber value, [MaybeNullWhen(false)] out TOther result) {
            result = default;
            return false;
        }

        public static bool TryConvertToFakeNumberChecked<TOther>(TOther value, out FakeNumber? result) where TOther : INumberBase<TOther> {
            // normally this would be called from a public CreateChecked method, where the type would first try a TryConvertFromChecked before calling TOther
            // when the result is false, a NotSupportedException is typically thrown (see decimal.CreateChecked(..))
            return TOther.TryConvertToChecked(value, out result);
        }

        public static bool TryConvertToFakeNumberSaturating<TOther>(TOther value, out FakeNumber? result) where TOther : INumberBase<TOther> {
            // normally this would be called from a public CreateSaturating method, where the type would first try a TryConvertFromSaturating before calling TOther
            // when the result is false, a NotSupportedException is typically thrown (see decimal.CreateSaturating(..))
            return TOther.TryConvertToSaturating(value, out result);
        }

        public static bool TryConvertToFakeNumberTruncating<TOther>(TOther value, out FakeNumber? result) where TOther : INumberBase<TOther> {
            // normally this would be called from a public CreateTruncating method, where the type would first try a TryConvertFromTruncating before calling TOther
            // when the result is false, a NotSupportedException is typically thrown (see decimal.CreateTruncating(..))
            return TOther.TryConvertToTruncating(value, out result);
        }

        #region Other interface members (not implemented)

        bool IEquatable<FakeNumber>.Equals(FakeNumber? other) {
            throw new NotImplementedException();
        }

        string IFormattable.ToString(string? format, IFormatProvider? formatProvider) {
            throw new NotImplementedException();
        }

        bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) {
            throw new NotImplementedException();
        }

        static FakeNumber IParsable<FakeNumber>.Parse(string s, IFormatProvider? provider) {
            throw new NotImplementedException();
        }

        static bool IParsable<FakeNumber>.TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out FakeNumber result) {
            throw new NotImplementedException();
        }

        static FakeNumber ISpanParsable<FakeNumber>.Parse(ReadOnlySpan<char> s, IFormatProvider? provider) {
            throw new NotImplementedException();
        }

        static bool ISpanParsable<FakeNumber>.TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out FakeNumber result) {
            throw new NotImplementedException();
        }


        static FakeNumber IAdditionOperators<FakeNumber, FakeNumber, FakeNumber>.operator +(FakeNumber left, FakeNumber right) {
            throw new NotImplementedException();
        }

        static FakeNumber IAdditiveIdentity<FakeNumber, FakeNumber>.AdditiveIdentity { get; } = new();

        static FakeNumber IDecrementOperators<FakeNumber>.operator --(FakeNumber value) {
            throw new NotImplementedException();
        }

        static FakeNumber IDivisionOperators<FakeNumber, FakeNumber, FakeNumber>.operator /(FakeNumber left, FakeNumber right) {
            throw new NotImplementedException();
        }

        static bool IEqualityOperators<FakeNumber, FakeNumber, bool>.operator ==(FakeNumber? left, FakeNumber? right) {
            throw new NotImplementedException();
        }

        static bool IEqualityOperators<FakeNumber, FakeNumber, bool>.operator !=(FakeNumber? left, FakeNumber? right) {
            throw new NotImplementedException();
        }

        static FakeNumber IIncrementOperators<FakeNumber>.operator ++(FakeNumber value) {
            throw new NotImplementedException();
        }

        static FakeNumber IMultiplicativeIdentity<FakeNumber, FakeNumber>.MultiplicativeIdentity { get; } = new();

        static FakeNumber IMultiplyOperators<FakeNumber, FakeNumber, FakeNumber>.operator *(FakeNumber left, FakeNumber right) {
            throw new NotImplementedException();
        }

        static FakeNumber ISubtractionOperators<FakeNumber, FakeNumber, FakeNumber>.operator -(FakeNumber left, FakeNumber right) {
            throw new NotImplementedException();
        }

        static FakeNumber IUnaryNegationOperators<FakeNumber, FakeNumber>.operator -(FakeNumber value) {
            throw new NotImplementedException();
        }

        static FakeNumber IUnaryPlusOperators<FakeNumber, FakeNumber>.operator +(FakeNumber value) {
            throw new NotImplementedException();
        }

        static FakeNumber INumberBase<FakeNumber>.Abs(FakeNumber value) {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsCanonical(FakeNumber value) {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsComplexNumber(FakeNumber value) {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsEvenInteger(FakeNumber value) {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsFinite(FakeNumber value) {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsImaginaryNumber(FakeNumber value) {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsInfinity(FakeNumber value) {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsInteger(FakeNumber value) {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsNaN(FakeNumber value) {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsNegative(FakeNumber value) {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsNegativeInfinity(FakeNumber value) {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsNormal(FakeNumber value) {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsOddInteger(FakeNumber value) {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsPositive(FakeNumber value) {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsPositiveInfinity(FakeNumber value) {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsRealNumber(FakeNumber value) {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsSubnormal(FakeNumber value) {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.IsZero(FakeNumber value) {
            throw new NotImplementedException();
        }

        static FakeNumber INumberBase<FakeNumber>.MaxMagnitude(FakeNumber x, FakeNumber y) {
            throw new NotImplementedException();
        }

        static FakeNumber INumberBase<FakeNumber>.MaxMagnitudeNumber(FakeNumber x, FakeNumber y) {
            throw new NotImplementedException();
        }

        static FakeNumber INumberBase<FakeNumber>.MinMagnitude(FakeNumber x, FakeNumber y) {
            throw new NotImplementedException();
        }

        static FakeNumber INumberBase<FakeNumber>.MinMagnitudeNumber(FakeNumber x, FakeNumber y) {
            throw new NotImplementedException();
        }

        static FakeNumber INumberBase<FakeNumber>.Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) {
            throw new NotImplementedException();
        }

        static FakeNumber INumberBase<FakeNumber>.Parse(string s, NumberStyles style, IFormatProvider? provider) {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out FakeNumber result) {
            throw new NotImplementedException();
        }

        static bool INumberBase<FakeNumber>.TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out FakeNumber result) {
            throw new NotImplementedException();
        }

        static FakeNumber INumberBase<FakeNumber>.One { get; } = new();
        static int INumberBase<FakeNumber>.Radix { get; } = 10;

        #endregion
    }
}
#endif
