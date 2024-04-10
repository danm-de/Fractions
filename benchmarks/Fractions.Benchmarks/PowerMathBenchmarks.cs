using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace Fractions.Benchmarks;

[MemoryDiagnoser]
[ShortRunJob]
// [DryJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
public class PowerMathBenchmarks {
    public static IEnumerable<int> Powers => [0, 1, 2, -2, 50, 100];

    public static IEnumerable<Fraction> FractionsToRaise => [2, 3, new Fraction(2, 3), 1024];

    [ParamsSource(nameof(FractionsToRaise))]
    public Fraction FractionToRaise { get; set; }


    [Benchmark]
    [BenchmarkCategory("Pow")]
    [ArgumentsSource(nameof(Powers))]
    public Fraction Power(int exponent) {
        return Fraction.Pow(FractionToRaise, exponent);
    }

    [Benchmark]
    [BenchmarkCategory("Sqrt")]
    public Fraction Sqrt() {
        return FractionToRaise.Sqrt();
    }
}
