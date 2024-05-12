using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace Fractions.Benchmarks;

[MemoryDiagnoser]
public class ConstructorBenchmarks {
    public static IEnumerable<int> IntegerValues => [0, 42, int.MinValue, int.MaxValue];
    public static IEnumerable<decimal> DecimalValues => [0m, 42m, 123.45m, int.MinValue, decimal.MinValue, (decimal)Math.PI];
    public static IEnumerable<double> DoubleValues => [0.0, 42, 123.45, (double)decimal.MinValue, double.MaxValue, Math.PI];

    public IEnumerable<object[]> BigIntegerValues() 
    {
        yield return [new BigInteger(0), new BigInteger(1)];                           // zero
        yield return [new BigInteger(42), new BigInteger(1)];                          // small integer
        yield return [new BigInteger(int.MinValue), new BigInteger(1)];                // large integer
        yield return [new BigInteger(int.MaxValue), new BigInteger(int.MaxValue)];     // large integers reduced to 1
        yield return [new BigInteger(decimal.MinValue), new BigInteger(int.MaxValue)]; // not reducible
        yield return [new BigInteger(int.MaxValue), new BigInteger(double.MaxValue)];  // not reducible (huge denominator)
        yield return [new BigInteger(245850922), new BigInteger(78256779)];            // ~ PI
    }

    [Benchmark]
    [ArgumentsSource(nameof(IntegerValues))]
    public Fraction Construct_With_Int32(int value) {
        return new Fraction(value);
    }

    [Benchmark]
    [ArgumentsSource(nameof(DecimalValues))]
    public Fraction Construct_With_Decimal(decimal value) {
        return new Fraction(value);
    }

    [Benchmark]
    [ArgumentsSource(nameof(DoubleValues))]
    public Fraction Construct_With_Double(double value) {
        return new Fraction(value);
    }

    [Benchmark]
    [ArgumentsSource(nameof(BigIntegerValues))]
    public Fraction Construct_With_BigIntegers(BigInteger numerator, BigInteger denominator) {
        return new Fraction(numerator, denominator);
    }
}
