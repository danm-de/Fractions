using System.Globalization;
using BenchmarkDotNet.Attributes;
using Fractions.Formatter;

namespace Fractions.Benchmarks;

[MemoryDiagnoser]
[ShortRunJob]
public class DecimalNotationFormatterBenchmarks {

    [Params(null, "G2", "F2", "N2", "E2", "P2", "C2", "S2")]
    public string? StringFormat { get; set; }
    
    public static IEnumerable<Fraction> TestValues => [
        // normal integer
        42, -42,
        // extreme integers
        123456789, -123456789,             
        // normal decimals
        new Fraction(-2.5m), new Fraction(1.345m),
        new Fraction(1234567, 1000),
        new Fraction(-1234567, 1000),
        // extreme decimals
        new Fraction(1, 123456789),
        new Fraction(-1, 123456789),
        // high precision fractions
        new Fraction(Math.PI),
        new Fraction(-Math.PI),
        // non-terminating fractions
        new Fraction(8, 3),
        new Fraction(-8, 3),
        new Fraction(400, 3),
        new Fraction(-400, 3),
        new Fraction(2, 3),
        new Fraction(-2, 3),
    ];
    
    [Benchmark(Baseline = true)]
    [ArgumentsSource(nameof(TestValues))]
    public string ToDouble_ToString(Fraction fraction) {
        return fraction.ToDouble().ToString(StringFormat, CultureInfo.InvariantCulture);
    }
    
    [Benchmark]
    [ArgumentsSource(nameof(TestValues))]
    public string DecimalNotationFormatter_Format(Fraction fraction) {
        return DecimalNotationFormatter.Instance.Format(StringFormat, fraction, CultureInfo.InvariantCulture);
    }
}
