using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace Fractions.Benchmarks;

[MemoryDiagnoser]
[ShortRunJob]
public class ComparisonBenchmarks {
    public static IEnumerable<object[]> Operands() {
        yield return [new Fraction(0, 1), new Fraction(1, 1)];
        yield return [new Fraction(-1024, 1), new Fraction(-1, 1024)];
        yield return [new Fraction(-45, 1), new Fraction(1, 6)];
        yield return [new Fraction(BigInteger.Pow(-10, 37), 1), new Fraction(1, BigInteger.Pow(10 , 12))];
        yield return [new Fraction(0.135m), new Fraction(0.076m)];
        yield return [new Fraction(42, 66, false), new Fraction(36, 96, false)];  
        yield return [new Fraction(144, 384, false), new Fraction(36, 96, false)]; // those are equivalent
        yield return [Fraction.FromDouble(Math.PI), Fraction.FromDouble(Math.PI)];
        yield return [Fraction.FromDoubleRounded(Math.PI), Fraction.FromDoubleRounded(Math.PI)];
        yield return [Fraction.FromDouble(Math.PI), Fraction.FromDouble(Math.PI / 3)];
        yield return [Fraction.FromDoubleRounded(Math.PI), Fraction.FromDoubleRounded(Math.PI / 3)];
    }

    [Benchmark]
    [ArgumentsSource(nameof(Operands))]
    public bool Equals(Fraction a, Fraction b) {
        return a.Equals(b);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Operands))]
    public bool IsEquivalentTo(Fraction a, Fraction b) {
        return a.IsEquivalentTo(b);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Operands))]
    public int GetHashCode(Fraction a, Fraction b) {
        return HashCode.Combine(a, b);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Operands))]
    public int CompareTo(Fraction a, Fraction b) {
        return a.CompareTo(b);
    }
}
