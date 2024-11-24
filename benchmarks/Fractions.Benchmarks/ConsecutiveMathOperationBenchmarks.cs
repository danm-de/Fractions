using System.Numerics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace Fractions.Benchmarks;

[MemoryDiagnoser]
[ShortRunJob(RuntimeMoniker.Net48)]
[ShortRunJob(RuntimeMoniker.Net90)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
public class ConsecutiveMathOperationBenchmarks {
    [Params(100, 10_000, 1_000_000)]
    public int Denominator { get; set; }

    [Params(5, 10, 20, 50)]
    public int NbOperations { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Fraction[] NonReducedFractions { get; set; }
    public Fraction[] ReducedFractions { get; set; }
    public Func<Fraction, Fraction, Fraction>[] Operations { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [GlobalSetup]
    public void Setup() {
        var random = new Random(42);
        NonReducedFractions = Enumerable.Range(0, NbOperations).Select(_ => new Fraction(
            (random.Next(2) == 1 ? 1 : -1) * random.Next(1, 2 * Denominator + 1),
            new BigInteger(Denominator), false)).ToArray();
        ReducedFractions = NonReducedFractions.Select(x => x.Reduce()).ToArray();
        var addition = (Fraction fraction1, Fraction fraction2) => fraction1.Add(fraction2);
        var subtraction = (Fraction fraction1, Fraction fraction2) => fraction1.Subtract(fraction2);
        var multiplication  = (Fraction fraction1, Fraction fraction2) => fraction1.Multiply(fraction2);
        var division  = (Fraction fraction1, Fraction fraction2) => fraction1.Divide(fraction2);
        Operations = new Func<Fraction, Fraction, Fraction>[NbOperations];
        Operations[0] = random.Next(1) == 1 ? addition : subtraction;
        for (var i = 1; i < NbOperations; i++) {
            Operations[i] = random.Next(4) switch {
                0 => addition,
                1 => subtraction,
                2 => multiplication,
                _ => division
            };
        }
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
    
    [Benchmark(Baseline = true)]
    [BenchmarkCategory(nameof(Fraction))]
    public Fraction ReducedOperations() {
        var result = Fraction.Zero;
        for (var i = 0; i < NbOperations; i++) {
            result = Operations[i].Invoke(result, ReducedFractions[i]);
        }
        // Console.Out.WriteLine("ReducedOperations: nbOperations = {0}, denominator = {1}, result = {2}", NbOperations, Denominator, result);
        return result;
    }
    
    [Benchmark(Baseline = false)]
    [BenchmarkCategory(nameof(Fraction))]
    public Fraction NonReducedOperations() {
        var result = Fraction.Zero;
        for (var i = 0; i < NbOperations; i++) {
            result = Operations[i].Invoke(result, NonReducedFractions[i]);
        }
        // Console.Out.WriteLine("NonReducedOperations: nbOperations = {0}, denominator = {1}, result = {2}", NbOperations, Denominator, result);
        return result;
    }
}
