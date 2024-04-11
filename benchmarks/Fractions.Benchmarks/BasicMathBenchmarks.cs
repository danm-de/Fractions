using BenchmarkDotNet.Attributes;

namespace Fractions.Benchmarks;

[MemoryDiagnoser]
[ShortRunJob]
public class BasicMathBenchmarks {
    public static IEnumerable<object[]> Operands() {
        yield return [new Fraction(0, 1), new Fraction(1, 1)];
        yield return [new Fraction(-1024, 1), new Fraction(-1, 1024)];
        yield return [new Fraction(-10 ^ 37, 1), new Fraction(1, 10 ^ 12)];
        yield return [Fraction.FromDouble(Math.PI), Fraction.FromDouble(Math.PI / 2)];
        yield return [Fraction.FromDoubleRounded(Math.PI), Fraction.FromDoubleRounded(Math.PI / 2)];
        yield return [Fraction.FromDouble(Math.PI), Fraction.FromDouble(Math.PI / 3)];
        yield return [Fraction.FromDoubleRounded(Math.PI), Fraction.FromDoubleRounded(Math.PI / 3)];
    }

    [Benchmark]
    [ArgumentsSource(nameof(Operands))]
    public Fraction Add(Fraction a, Fraction b) {
        return a + b;
    }

    [Benchmark]
    [ArgumentsSource(nameof(Operands))]
    public Fraction Subtract(Fraction a, Fraction b) {
        return a - b;
    }

    [Benchmark]
    [ArgumentsSource(nameof(Operands))]
    public Fraction Multiply(Fraction a, Fraction b) {
        return a * b;
    }

    [Benchmark]
    [ArgumentsSource(nameof(Operands))]
    public Fraction Divide(Fraction a, Fraction b) {
        return a / b;
    }
}
