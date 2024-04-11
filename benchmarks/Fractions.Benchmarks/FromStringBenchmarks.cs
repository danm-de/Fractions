using System.Globalization;
using BenchmarkDotNet.Attributes;

namespace Fractions.Benchmarks;

[MemoryDiagnoser]
[ShortRunJob]
public class FromStringBenchmarks {

    public static IEnumerable<string> ValidStrings => ["0", "1", "-1", "10242048", "1/5", "-1/5", "3.5", "-3.5", "1.2345678901234567890"];
    public static IEnumerable<string> InvalidStrings => ["", "invalid", "-10242048/", "1.2345678901234567890f"];
    
    [Benchmark]
    [ArgumentsSource(nameof(ValidStrings))]
    public bool TryParseValidString(string validString) {
        return Fraction.TryParse(validString, NumberStyles.Number, CultureInfo.InvariantCulture, false, out _);
    }
    
    [Benchmark]
    [ArgumentsSource(nameof(InvalidStrings))]
    public bool TryParseInvalidString(string invalidString) {
        return Fraction.TryParse(invalidString, NumberStyles.Number, CultureInfo.InvariantCulture, false, out _);
    }
}
