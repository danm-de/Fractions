using System.Numerics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Fractions.Benchmarks;

[MemoryDiagnoser]
// [ShortRunJob]
[ShortRunJob(RuntimeMoniker.Net48)]
[ShortRunJob(RuntimeMoniker.Net80)]
public class BasicMathBenchmarks {
    public static IEnumerable<object[]> Operands() {
        yield return [Fraction.Zero, Fraction.One];
        yield return [new Fraction(1000), new Fraction(100)]; // basic integers (powers of 10)
        yield return [new Fraction(97), new Fraction(89)];  // prime integers 
        yield return [new Fraction(77, 3600), new Fraction(37, 3600)]; // something per hour (non-reducible)
        yield return [new Fraction(-1024, 1), new Fraction(-1, 1024)];
        yield return [new Fraction(-45, 1), new Fraction(1, 6)];
        yield return [new Fraction(BigInteger.Pow(-10, 37), 1), new Fraction(1, BigInteger.Pow(10 , 12))];
        yield return [new Fraction(0.135m), new Fraction(0.076m)]; // different denominators after reduction: {27/200} and {19/250}
        yield return [new Fraction(135, 1000, false), new Fraction(76, 1000, false)]; 
        yield return [new Fraction(42, 66, false), new Fraction(36, 96, false)];
        yield return [new Fraction(42, -96, false), new Fraction(36, -96, false)];
        yield return [Fraction.FromDouble(Math.PI), Fraction.FromDouble(Math.PI / 2)];
        yield return [Fraction.FromDoubleRounded(Math.PI), Fraction.FromDoubleRounded(Math.PI / 2)];
        yield return [Fraction.FromDouble(Math.PI), Fraction.FromDouble(Math.PI / 3)];
        yield return [Fraction.FromDoubleRounded(Math.PI), Fraction.FromDoubleRounded(Math.PI / 3)];
        yield return [Fraction.FromDoubleRounded(Math.PI), Fraction.Zero];
        yield return [Fraction.FromDoubleRounded(Math.PI), Fraction.NaN];
        yield return [Fraction.FromDoubleRounded(Math.PI), Fraction.NegativeInfinity];
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
    
    [Benchmark]
    [ArgumentsSource(nameof(Operands))]
    public Fraction Mod(Fraction a, Fraction b) {
        return a % b;
    }
}
