# Changelog

## 8.0.2

- Bugfix in `Fraction.CompareTo` https://github.com/danm-de/Fractions/issues/78 by https://github.com/lipchev
- Performance optimization in `Fraction.FromDoubleRounded` https://github.com/danm-de/Fractions/pull/80 by https://github.com/lipchev
  Changed behavior: `ArgumentOutOfRangeException` is thrown when argument `significantDigits` is &lt; 1 or &gt; 17.

## 8.0.1

- Fixed nullable issue in Fraction.TryParse(..) reported in https://github.com/danm-de/Fractions/issues/76
  Error (active) CS8604 Possible null reference argument for parameter 'value' in 'bool Fraction.TryParse(..)

## 8.0.0

- Added support for NaN and Infinity by https://github.com/lipchev
- New properties IsNaN, IsInfinity, IsPositiveInfinity, IsNegativeInfinity by https://github.com/lipchev
- Adding a debugger display proxy by https://github.com/lipchev
- Various methods were optimized by https://github.com/lipchev
- Use the potential of Span&lt;T&gt; where sensible and possible (TryParse, FromDecimal) by https://github.com/lipchev
- No longer reduce non-normalized fractions when used in mathematical operations - by https://github.com/lipchev

### Breaking changes

- Mathematical operations no longer automatically generate normalized fractions if one of the operands is an non-normalized fraction. This has an impact on your calculations, especially if you have used the `JsonFractionConverter` with default settings. In such cases, deserialized fractions create non-normalized fractions, which can lead to changed behavior when calling `ToString`. Please refer the README section [Working with non-normalized fractions](Readme.md#working-with-non-normalized-fractions)
- The default behavior of the `.Equals(Fraction)` method has changed: `Equals` now compares the calculated value from the numerator/denominator (1/2 = 2/4).
- The standard function `ToString()` now depends on the active culture (`CultureInfo.CurrentCulture`). The reason is that NaN and Infinity should be displayed in the system language or the corresponding symbol should be used.
- Argument name for `Fraction.TryParse(..)` changed from `fractionString` to `value`.
- A fraction of 0/0 no longer has the value 0, but means NaN (not a number). Any fraction in the form x/0 is no longer a valid number. A denominator with the value 0 corresponds to, depending on the numerator, NaN, PositiveInfinity or NegativeInfinity.

## 7.7.1

- Added hotfix FromString supporting all NumberStyles https://github.com/lipchev

## 7.7.0

- Added DecimalNotationFormatter + documentation by https://github.com/lipchev
- Added Benchmark results summary (with Readme) by https://github.com/lipchev
- Introduced the negation (-) operator by https://github.com/lipchev
- Added extended xml comments to the FromDouble* methods by https://github.com/lipchev
- Replace .Invert() with .Negate() method

## 7.6.1

- Incorrect result when rounding 1/3 with MidpointRounding.ToEven (fixes #39) by https://github.com/lipchev

## 7.6.0

- Added method overload for FromDouble with significant digits by https://github.com/lipchev
- Performance optimization of the FromDouble method by https://github.com/lipchev

## 7.5.0

- Added benchmarks for the most common operations by https://github.com/lipchev
- Added Fraction.Round/RoundToBigInteger functions by https://github.com/lipchev
- Make the operator from decimal implicit by https://github.com/lipchev
- Support for parsing long/very precise numbers by https://github.com/lipchev
- Added support for `ReadOnlySpan<char>` when using TryParse(..)
- Added target framework .NET8.0
- Updated documentation
- Many thanks to @lipchev for the contributions

## 7.4.1

- Code cleanup (use new language features)
- fix https://github.com/danm-de/Fractions/issues/27 reported by https://github.com/lipchev

## 7.4.0

- The CLSCompliant(true) attribute was added by https://github.com/lipchev
- fix invalid characters in test names by https://github.com/lipchev
- Updated nuget packages

## 7.3.0

- New Reciprocal() method contributed by https://github.com/teemka
- Updated nuget packages

## 7.2.1

- Updated Newtonsoft.Json to version 13.0.2 (Dependabot)

## 7.2.0

- Removed System.Runtime.Numerics dependency. Thanks to @stan-sz https://github.com/danm-de/Fractions/pull/18

## 7.1.0

- New Sqrt() extension method contributed by https://github.com/MadsKirkFoged

## 7.0.0

- Removed unsupported framework DLL netstandard1.1 (Issue [#9](https://github.com/danm-de/Fractions/issues/9))
- Removed deplicated and unecessary framework DLLs net45, net48, net5.0 and netcoreapp3.1 (Issue [#9](https://github.com/danm-de/Fractions/issues/9))

## 6.0.0

- Breaking change: `new Fraction(0, 0).ToString()` or `new Fraction(0, 3).ToString()` returns "0" instead of "0/0"
- Bugfix: `Fraction.Zero.ToString("m")` does not longer throw a divide by zero exception (Issue [#6](https://github.com/danm-de/Fractions/issues/6))
- Added new framework DLLs for net48, netstandard2.1, netcoreapp3.1 and net5.0