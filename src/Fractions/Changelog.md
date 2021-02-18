6.0.0   

- Breaking change: `new Fraction(0, 0).ToString()` or `new Fraction(0, 3).ToString()` returns "0" instead of "0/0"
- Bugfix: `Fraction.Zero.ToString("m")` does not longer throw a divide by zero exception (Issue [#6](https://github.com/danm-de/Fractions/issues/6))
- Added new framework DLLs for net48, netstandard2.1, netcoreapp3.1 and net5.0