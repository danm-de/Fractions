# Changelog

## 8.0.0

- Great thanks to https://github.com/lipchev for added NaN and Infinity support!
- New properties IsNaN, IsInfinity, IsPositiveInfinity, IsNegativeInfinity
- ... TODO

### Breaking changes

- Added support for NaN and Infinity by https://github.com/lipchev
- A fraction of 0/0 no longer has the value 0, but instead means NaN (not a number). Any fraction in the form x/0 is no longer a valid number. A denominator with the value 0 corresponds - depending on the numerator - to NaN, PositiveInfinity or NegativeInfinity. 
- The standard function `ToString()` now depends on the active culture (`CultureInfo.CurrentCulture`). The reason is that NaN and Infinity should be displayed in the system language or the corresponding symbol should be used.
- ... TODO

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