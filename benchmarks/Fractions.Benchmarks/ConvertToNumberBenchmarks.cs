using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace Fractions.Benchmarks;

[MemoryDiagnoser]
public class ConvertToNumberBenchmarks {

    public static IEnumerable<Fraction> FractionsToConvert => [
        Fraction.Zero, 
        Fraction.One, 
        10,
        new Fraction(1, 10),
        new Fraction(1, 3),
        new Fraction(int.MaxValue),
        new Fraction(decimal.MaxValue)
    ];
    
    [Benchmark(Baseline = true)]
    [ArgumentsSource(nameof(FractionsToConvert))]
    public double ConvertToDouble(Fraction fraction) {
        return fraction.ToDouble();
    }

    [Benchmark]
    [ArgumentsSource(nameof(FractionsToConvert))]
    public decimal ConvertToDecimal(Fraction fraction) {
        return fraction.ToDecimal();
    }

    [Benchmark]
    [ArgumentsSource(nameof(FractionsToConvert))]
    public BigInteger ConvertToBigInteger(Fraction fraction) {
        return fraction.ToBigInteger();
    }
}
