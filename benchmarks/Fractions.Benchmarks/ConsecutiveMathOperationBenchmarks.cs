using System.Numerics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace Fractions.Benchmarks;

[MemoryDiagnoser]
[ShortRunJob(RuntimeMoniker.Net48)]
[ShortRunJob(RuntimeMoniker.Net80)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
public class ConsecutiveMathOperationBenchmarks {
    [Params(1, 10, 100, 1_000, 10_000)]
    public int Denominator { get; set; }

    [Params(10, 20, 100)]
    public int NbOperations { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Fraction[] NonReducedFractions { get; set; }
    public Fraction[] ReducedFractions { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [GlobalSetup]
    public void Setup() {
        var random = new Random(42);
        NonReducedFractions = Enumerable.Range(0, NbOperations).Select(_ => new Fraction(
            (random.Next(2) == 1 ? 1 : -1) * random.Next(1, 2 * Denominator + 1),
            new BigInteger(Denominator), false)).ToArray();
        ReducedFractions = NonReducedFractions.Select(x => x.Reduce()).ToArray();
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(nameof(Fraction.Add))]
    public Fraction ReducedAdditions() {
        var result = ReducedFractions.Aggregate(Fraction.Zero, (current, reducedFraction) => current.Add(reducedFraction));
        // Console.Out.WriteLine("ReducedAdditions: nbOperations = {0}, denominator = {1}, result = {2}", NbOperations, Denominator, result);
        return result;
    }
    
    [Benchmark(Baseline = false)]
    [BenchmarkCategory(nameof(Fraction.Add))]
    public Fraction NonReducedAdditions() {
        var result = NonReducedFractions.Aggregate(Fraction.Zero, (current, reducedFraction) => current.Add(reducedFraction));
        // Console.Out.WriteLine("ReducedAdditions: nbOperations = {0}, denominator = {1}, result = {2}", NbOperations, Denominator, result);
        return result;
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(nameof(Fraction.Multiply))]
    public Fraction ReducedMultiplications() {
        var result = ReducedFractions.Aggregate(Fraction.One, (current, reducedFraction) => current.Multiply(reducedFraction));
        // Console.Out.WriteLine("ReducedMultiplications: nbOperations = {0}, denominator = {1}, result = {2}", NbOperations, Denominator, result);
        return result;
    }

    [Benchmark(Baseline = false)]
    [BenchmarkCategory(nameof(Fraction.Multiply))]
    public Fraction NonReducedMultiplications() {
        var result = NonReducedFractions.Aggregate(Fraction.One, (current, reducedFraction) => current.Multiply(reducedFraction));
        // Console.Out.WriteLine("ReducedMultiplications: nbOperations = {0}, denominator = {1}, result = {2}", NbOperations, Denominator, result);
        return result;
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(nameof(Fraction.Divide))]
    public Fraction ReducedDivisions() {
        var result = ReducedFractions.Aggregate(Fraction.One, (current, reducedFraction) => current.Divide(reducedFraction));
        // Console.Out.WriteLine("ReducedDivisions: nbOperations = {0}, denominator = {1}, result = {2}", NbOperations, Denominator, result);
        return result;
    }
    
    [Benchmark(Baseline = false)]
    [BenchmarkCategory(nameof(Fraction.Divide))]
    public Fraction NonReducedDivisions() {
        var result = NonReducedFractions.Aggregate(Fraction.One, (current, reducedFraction) => current.Divide(reducedFraction));
        // Console.Out.WriteLine("NonReducedDivisions: nbOperations = {0}, denominator = {1}, result = {2}", NbOperations, Denominator, result);
        return result;
    }
}
