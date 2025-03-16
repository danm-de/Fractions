# Fractions Benchmarks

This directory contains benchmark results for the Fractions library. Each benchmark tests a specific aspect of performance. 

Please note that these benchmark results were obtained under varying conditions and at different times, so they should be interpreted with a grain of salt. The primary purpose of these benchmarks is to provide a relative performance comparison between different test cases within a benchmark, rather than absolute performance metrics.

These benchmarks are particularly useful when introducing new features that may impact performance, as they provide a baseline for comparison.

For the most accurate results, we encourage you to run the benchmarks on your own machine. You can do this by running the following command in your terminal:

```bash
dotnet run -c Release -p Fractions.Benchmarks
```

This will run the `Fractions.Benchmarks` project and give you a more accurate understanding of the performance on your specific system.

## Constructor Benchmarks
These benchmarks evaluate the performance of various constructor operations within the `Fraction` class. The operations being benchmarked are:
- `Construct_With_Int32(int value)`: Constructs a `Fraction` from an integer value.
- `Construct_With_Decimal(decimal value)`: Constructs a `Fraction` from a decimal value.
- `Construct_With_Double(double value)`: Constructs a `Fraction` from a double value.
- `Construct_With_BigIntegers(BigInteger numerator, BigInteger denominator)`: Constructs a normalized `Fraction` from two `BigInteger` values representing the numerator and denominator.

For a detailed report on the performance of these operations, [view the results here](./results/Fractions.Benchmarks.ConstructorBenchmarks-report-github.md).

## From Double Benchmarks
These benchmarks evaluate the performance of constructing `Fraction` objects from double values. The operations being benchmarked are:
- `Construct_FromDouble(double value)`: Constructs a `Fraction` object from a double value. This operation is used when a fraction needs to be created from a floating-point number.
- `Construct_FromDoubleRounded(double value)`: Constructs a `Fraction` object from a double value, rounding the result. This operation is used when a fraction needs to be created from a floating-point number with rounding.
- `Construct_FromDoubleRoundedToFifteenDigits(double value)`: Constructs a `Fraction` object from a double value, rounding the result to fifteen digits. This operation is used when a fraction needs to be created from a floating-point number with rounding to a specific precision.
- `Construct_FromDoubleRoundedToEighteenDigits(double value)`: Constructs a `Fraction` object from a double value, rounding the result to eighteen digits. This operation is used when a fraction needs to be created from a floating-point number with rounding to a specific precision.

For a detailed report on the performance of these operations, [view the results here](./results/Fractions.Benchmarks.FromDoubleBenchmarks-report-github.md).

## Numeric Operations
This section can include benchmarks related to various numeric operations. It can be further divided into sub-sections:

### Comparison Operations
The operations being benchmarked are:
- `Equals(Fraction a, Fraction b)`: This method checks if two fractions are equivalent, meaning they represent the same value, even if their numerators and denominators are different.
- `StrictEqualityEquals(Fraction a, Fraction b)`: This method checks if two fractions are exactly equal, meaning both their numerators and denominators are the same.
- `GetHashCode(Fraction a, Fraction b)`: This method generates a hash code for a pair of fractions, either normalized or non-normalized. It's used in data structures like hash tables.
- `StrictEqualityGetHashCode(Fraction a, Fraction b)`: This method generates a hash code for a pair of fractions which are assumed to be normalized. It's used in data structures like hash tables.
- `CompareTo(Fraction a, Fraction b)`: This method compares two fractions and determines which one is greater, or if they are equal.

When using comparing using the `==` operator and especially when when using the `Fraction` as part of a key for data structures like hash tables (e.g. `Dictionary`) 
there is performance benefit to using to `normalized` fractions when compared to their `non-normalized` counterparts _(which are faster in all other scenarios)_. 

#### Normalized fractions
For a detailed report on the performance of these operations using only `normalized` fractions, [view the results here](./results/Fractions.Benchmarks.ComparisonBenchmarks-report-github.md).

#### Non-normalized fractions
For a detailed report on the performance of these operations using only `non-normalized` fractions, [view the results here](./results/Fractions.Benchmarks.NonNormalizedComparisonBenchmarks-report-github.md).

### Math Operations
These benchmarks evaluate the performance of fundamental mathematical operations within the `Fraction` class. The operations being benchmarked are:
- `Add(Fraction a, Fraction b)`: Adds two fractions.
- `Subtract(Fraction a, Fraction b)`: Subtracts one fraction from another.
- `Multiply(Fraction a, Fraction b)`: Multiplies two fractions.
- `Divide(Fraction a, Fraction b)`: Divides one fraction by another.
- `Remainder(Fraction a, Fraction b)`: Computes the remainder of a division operation between two fractions.

Math operations with normalized fractions are typically much slower than the alternative.

#### Normalized fractions
For a detailed report on the performance of these operations using only `normalized` fraction, [view the results here](./results/Fractions.Benchmarks.BasicMathBenchmarks-report-github.md).

#### Non-normalized fractions
For a detailed report on the performance of these operations using only `non-normalized` fraction, [view the results here](./results/Fractions.Benchmarks.NonNormalizedMathBenchmarks-report-github.md).

#### Consecutive Math Operations
For a detailed report on the performance of a sequence of these operations, using the `normalized` vs the `non-normalized` operations,
[view the results here](./results/Fractions.Benchmarks.ConsecutiveMathOperationBenchmarks-report-github.md) 

### Power Math Operations
These benchmarks evaluate the performance of power operations within the `Fraction` class. The operations being benchmarked are:
- `Pow(Fraction a, int b)`: Raises a `Fraction` object to an integer power. This operation is used in various mathematical computations involving fractions.
- `Root(Fraction a, int b)`: Computes the b-th root of a `Fraction` object. This operation is used in various mathematical computations involving fractions.

For a detailed report on the performance of these operations, [view the results here](./results/Fractions.Benchmarks.PowerMathBenchmarks-report-github.md) and [here](./results/Fractions.Benchmarks.SqrtBenchmarks-report-github.md).

### Rounding
These benchmarks evaluate the performance of rounding a `Fraction` to a given number of decimal places. The operations being benchmarked are:
- `Round(Fraction fraction, int decimals, MidpointRounding mode)`: Rounds a `Fraction` to the given number of decimal places, returning a normalized Fraction.
- `Round(Fraction fraction, int decimals, MidpointRounding mode, bool normalize)`: Rounding a `Fraction` to the given number of decimal places, without reducing its terms.

For a detailed report on the performance of these operations, [view the results here](./results/Fractions.Benchmarks.RoundingBenchmarks-report-github.md) and [here](./results/Fractions.Benchmarks.RoundingWithoutReductionBenchmarks-report-github.md).

### Conversions
These benchmarks evaluate the performance of converting `Fraction` objects to number types. The operations being benchmarked are:
- `ConvertToDouble(Fraction fraction)`: Converts a `Fraction` object to a double value.
- `ConvertToDecimal(Fraction fraction)`: Converts a `Fraction` object to a decimal value.

For a detailed report on the performance of these operations, [view the results here](./results/Fractions.Benchmarks.ConvertToNumberBenchmarks-report-github.md).

## String Operations
This section can include benchmarks related to string manipulation of fractions. It can be further divided into sub-sections:

### To String
These benchmarks evaluate the performance of converting `Fraction` objects to string representations. The operations being benchmarked are:
- `ToString_Fraction(Fraction fraction)`: Converts a `Fraction` object to its string representation. This operation is used when displaying fractions to the user or when storing fractions in a text-based format.

For a detailed report on the performance of these operations, [view the results here](./results/Fractions.Benchmarks.ToStringBenchmarks-report-github.md).

### From String
These benchmarks evaluate the performance of constructing `Fraction` objects from string representations. The operations being benchmarked are:
- `TryParseValidString(string validString)`: Tries to parse a valid string representation of a fraction and construct a `Fraction` object. This operation is used when a fraction needs to be created from a string.
- `TryParseValidReadOnlySpan(char[] valid)`: Tries to parse a valid ReadOnlySpan representation of a fraction and construct a `Fraction` object. This operation is used when a fraction needs to be created from a ReadOnlySpan.
- `TryParseInvalidString(string invalidString)`: Tries to parse an invalid string representation of a fraction. This operation measures the performance when handling invalid inputs.
- `TryParseInvalidReadOnlySpan(char[] invalid)`: Tries to parse an invalid ReadOnlySpan representation of a fraction. This operation measures the performance when handling invalid inputs.

For a detailed report on the performance of these operations, [view the results here](./results/Fractions.Benchmarks.FromStringBenchmarks-report-github.md).

### Decimal Notation Formatter
These benchmarks evaluate the performance of formatting fractions in decimal notation. The operations being benchmarked are:
- `ToDouble_ToString(Fraction fraction)`: Converts a `Fraction` object to a double value and then to its string representation. This operation serves as a reference implementation for comparison.
- `DecimalNotationFormatter_Format(Fraction fraction)`: Formats a `Fraction` object in decimal notation using the `DecimalNotationFormatter` class. This operation is our custom implementation that aims to provide a more precise string representation of a fraction.

For a detailed report on the performance of these operations, [view the results here](./results/Fractions.Benchmarks.DecimalNotationFormatterBenchmarks-report-github.md).
