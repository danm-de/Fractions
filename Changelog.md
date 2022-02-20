7.1.0

- New Sqrt() extension method contributed by https://github.com/MadsKirkFoged

7.0.0

- Removed unsupported framework DLL netstandard1.1 (Issue [#9](https://github.com/danm-de/Fractions/issues/9))
- Removed deplicated and unecessary framework DLLs net45, net48, net5.0 and netcoreapp3.1 (Issue [#9](https://github.com/danm-de/Fractions/issues/9))

6.0.0

- Breaking change: `new Fraction(0, 0).ToString()` or `new Fraction(0, 3).ToString()` returns "0" instead of "0/0"
- Bugfix: `Fraction.Zero.ToString("m")` does not longer throw a divide by zero exception (Issue [#6](https://github.com/danm-de/Fractions/issues/6))
- Added new framework DLLs for net48, netstandard2.1, netcoreapp3.1 and net5.0