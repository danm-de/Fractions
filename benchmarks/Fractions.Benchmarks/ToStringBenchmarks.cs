using BenchmarkDotNet.Attributes;

namespace Fractions.Benchmarks;

[MemoryDiagnoser]
[ShortRunJob]
public class ToStringBenchmarks {

    [Params(null, "G", "n", "d", "z", "r", "m")]
    public string? StringFormat { get; set; }
    
    public static IEnumerable<Fraction> TestValues => [
        42,
        new Fraction(-2.5m),
        new Fraction(1.345m),        
        new Fraction(8, 3),
        new Fraction(Math.PI)
    ];
    
    [Benchmark]
    [ArgumentsSource(nameof(TestValues))]
    public string ToString_Fraction(Fraction fraction) {
        return fraction.ToString(StringFormat);
    }
}
