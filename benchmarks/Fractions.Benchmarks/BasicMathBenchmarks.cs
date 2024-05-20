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
        // zero
        yield return [Fraction.Zero, Fraction.One];
        // basic integers (powers of 10)
        yield return [
            new Fraction(1000),
            new Fraction(100)];
        // prime integers 
        yield return [
            new Fraction(97),
            new Fraction(89)];
        // something per hour (non-reducible)
        yield return [
            new Fraction(77, 3600),
            new Fraction(37, 3600)];
        // {-1024} and {-1/1024}
        yield return [
            new Fraction(-1024, 1),
            new Fraction(-1, 1024)];
        // {-45} and {1/6}
        yield return [
            new Fraction(-45, 1),
            new Fraction(1, 6)];
        // {-10^37} and {1/10^12}
        yield return [
            new Fraction(BigInteger.Pow(-10, 37), 1),
            new Fraction(1, BigInteger.Pow(10 , 12))];
        // different denominators after reduction: {27/200} and {19/250}
        yield return [
            new Fraction(0.135m),
            new Fraction(0.076m)];
        yield return [
            Fraction.FromDouble(Math.PI),
            Fraction.FromDouble(Math.PI / 2)];
        // {245850922/78256779} and {0}
        yield return [
            Fraction.FromDoubleRounded(Math.PI),
            Fraction.Zero];
        // {245850922/78256779} and {NaN}
        yield return [
            Fraction.FromDoubleRounded(Math.PI),
            Fraction.NaN];
        // {245850922/78256779} and {Infinity}
        yield return [
            Fraction.FromDoubleRounded(Math.PI),
            Fraction.NegativeInfinity];
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
