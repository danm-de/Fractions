using System.Numerics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Fractions.Benchmarks;

[MemoryDiagnoser]
[ShortRunJob(RuntimeMoniker.Net48)]
[ShortRunJob(RuntimeMoniker.Net80)]
public class ConvertToFractionBenchmarks {
    public static IEnumerable<Fraction> FractionsToConvert => [
        Fraction.Zero,
        Fraction.One,
        10,
        new Fraction(1, 10),
        new Fraction(0.135m),
        new Fraction(-0.135m),
        new Fraction(decimal.MaxValue),
        new Fraction(decimal.MinValue),
        new Fraction(BigInteger.Pow(-10, 37)),
        new Fraction(1, BigInteger.Pow(10, 12)),
        new Fraction(42, 66, false),
        new Fraction(36, 96, false),
        new Fraction(42, -96, false),
        new Fraction(-42, -96, false),
        Fraction.FromDouble(Math.PI),
        Fraction.FromDouble(-Math.PI),
        Fraction.NaN,
        Fraction.PositiveInfinity,
        Fraction.NegativeInfinity
    ];

    [Benchmark]
    [ArgumentsSource(nameof(FractionsToConvert))]
    public Fraction Abs(Fraction fraction) {
        return fraction.Abs();
    }

    [Benchmark]
    [ArgumentsSource(nameof(FractionsToConvert))]
    public Fraction Negate(Fraction fraction) {
        return fraction.Negate();
    }

    [Benchmark]
    [ArgumentsSource(nameof(FractionsToConvert))]
    public Fraction Reciprocal(Fraction fraction) {
        return fraction.Reciprocal();
    }
}
