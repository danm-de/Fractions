using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using Fractions.Formatter;

namespace Fractions;

public readonly partial struct Fraction {
    internal readonly struct FractionDebugView(Fraction fraction) {
        public BigInteger A => fraction.Numerator;
        public BigInteger B => fraction.Denominator;
        public FractionState State => fraction.State;
        public StringFormatsView StringFormats => new(fraction);
        public NumericFormatsView ValueFormats => new(fraction);

        [DebuggerDisplay("{ShortFormat}")]
        internal readonly struct StringFormatsView(Fraction fraction) {
            public string GeneralFormat => DecimalNotationFormatter.Instance.Format("g", fraction, CultureInfo.CurrentCulture);
            public string ShortFormat => DecimalNotationFormatter.Instance.Format("s", fraction, CultureInfo.CurrentCulture);
            public string SimplifiedFraction => fraction.ToString("m");
        }

        [DebuggerDisplay("{Double}")]
        internal readonly struct NumericFormatsView(Fraction fraction) {
            public int Integer => fraction.ToInt32();
            public long Long => fraction.ToInt64();
            public decimal Decimal => fraction.ToDecimalWithTrailingZeros();
            public double Double => fraction.ToDouble();
        }
    }
}
