using System.Globalization;
using BenchmarkDotNet.Attributes;

namespace Fractions.Benchmarks;

[MemoryDiagnoser]
[ShortRunJob]
public class FromStringBenchmarks {

    public static IEnumerable<string> ValidStrings => ["0", "1", "-1", "10242048", "1/5", "-1/5", "3.5", "-3.5", "1.2345678901234567890"];
    public static IEnumerable<char[]> ValidChars { get; } = ValidStrings.Select(x => x.ToCharArray()).ToArray();
    public static IEnumerable<string> InvalidStrings => ["", "invalid", "-10242048/", "1.2345678901234567890f"];
    public static IEnumerable<char[]> InvalidChars { get; } = InvalidStrings.Select(x => x.ToCharArray()).ToArray();

    [Benchmark]
    [ArgumentsSource(nameof(ValidStrings))]
    public bool TryParseValidString(string validString) {
        return Fraction.TryParse(validString, NumberStyles.Number, CultureInfo.InvariantCulture, false, out _);
    }

    [Benchmark]
    [ArgumentsSource(nameof(ValidChars))]
    public bool TryParseValidReadOnlySpan(char[] valid) {
        return Fraction.TryParse(valid.AsSpan(), NumberStyles.Number, CultureInfo.InvariantCulture, false, out _);
    }
    
    [Benchmark]
    [ArgumentsSource(nameof(InvalidStrings))]
    public bool TryParseInvalidString(string invalidString) {
        return Fraction.TryParse(invalidString, NumberStyles.Number, CultureInfo.InvariantCulture, false, out _);
    }

    [Benchmark]
    [ArgumentsSource(nameof(InvalidChars))]
    public bool TryParseInvalidReadOnlySpan(char[] invalid) {
        return Fraction.TryParse(invalid.AsSpan(), NumberStyles.Number, CultureInfo.InvariantCulture, false, out _);
    }
}
