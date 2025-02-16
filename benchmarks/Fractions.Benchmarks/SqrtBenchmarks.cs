using BenchmarkDotNet.Attributes;

namespace Fractions.Benchmarks;

[MemoryDiagnoser]
public class SqrtBenchmarks {
    public static IEnumerable<Fraction> FractionsToTest => [
        2, 3, new(2, 3), 12.345m, 9187.45m, 1024, 123456789L * 123456789L, 123456789L * 123456789L + 1
    ];

    [Params(15, 30, 45, 90)]
    public int Accuracy { get; set; }

    [ParamsSource(nameof(FractionsToTest))]
    public Fraction Fraction { get; set; }


    [Benchmark(Baseline = true)]
    public Fraction Sqrt() {
        return Fraction.Sqrt(Accuracy);
    }
}
