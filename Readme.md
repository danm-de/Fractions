# Fractions

## Introduction

This package contains a data type to calculate with rational numbers. It supports basic mathematic operators such as:

- addition
- subtraction
- multiplication
- division
- remainder
- ..

- The fraction data type implements operator overloads and implicit type conversion for convenience.

## Creation

You can implicitly cast `int`, `uint`, `long`, `ulong`, `decimal` or `BigInteger` to `Fraction`:

```csharp
Fraction a = 3;    // int
Fraction b = 4L;   // long
Fraction c = 3.3m; // decimal
Fraction d = new BigInteger(3);
// ..
```

You can explicitly cast `double` to `Fraction`, however doing so directly has [some important caveats](#creation-from-double-without-rounding) that you should be aware of:

```csharp
var a = (Fraction)3.3;  // returns {3715469692580659/1125899906842624} which is 3.299999999999999822364316059975
```

You can explicitly cast from `Fraction` to any supported data type (`int`, `uint`, `long`, `ulong`, `BigInteger`, `decimal`, `double`). However, be aware that an `OverflowException` will be thrown, if the target data type's boundary values are exceeded.

### Constructors

There a three types of constructors available:

- `new Fraction (<value>)` for `int`, `uint`, `long`, `ulong`, `BigInteger`, `decimal` and _`double` [(without rounding)](#creation-from-double-without-rounding)_.
- `new Fraction (<numerator>, <denominator>)` using `BigInteger` for numerator and denominator.
- `new Fraction (<numerator>, <denominator>, <reduce>)` using `BigInteger` for numerator and denominator + `bool` to indicate if the resulting fraction shall be normalized (reduced).

> [!IMPORTANT]
> Please refer to the [Working with non-normalized fractions](#working-with-non-normalized-fractions) section for more information about the possible side effects when working with non-reduced fractions.

### Static creation methods

- `Fraction.FromDecimal(decimal)`
- `Fraction.FromDouble(double)`
- `Fraction.FromDoubleRounded(double)`
- `Fraction.FromDoubleRounded(double, int)` (using a maximum number of significant digits)
- `Fraction.FromString(string)` (using current culture)
- `Fraction.FromString(string, IFormatProvider)`
- `Fraction.FromString(string, NumberStyles, IFormatProvider)`
- `Fraction.TryParse(string, out Fraction)` (using current culture)
- `Fraction.TryParse(string, NumberStyles, IFormatProvider, out Fraction)`
- `Fraction.TryParse(ReadOnlySpan<char>, NumberStyles, IFormatProvider, bool, out Fraction)`

### Creation from `double` without rounding

The `double` data type in C# uses a binary floating-point representation, which complies with the [IEC 60559:1989 (IEEE 754)](https://en.wikipedia.org/wiki/IEEE_754) standard for [binary floating-point arithmetic](https://en.wikipedia.org/wiki/Floating-point_arithmetic). This representation can't accurately represent all decimal fractions. For example, the decimal fraction _0.1_ is represented as the repeating binary fraction _.0001100110011..._. As a result, a `double` value can only provide an approximate representation of the decimal number it's intended to represent.

#### Large values in the numerator / denominator

When you convert a `double` to a `Fraction` using the `Fraction.FromDouble` method, the resulting fraction is an exact representation of the `double` value, not the decimal number that the `double` is intended to approximate. This is why you can end up with large numerators and denominators. 

```csharp
var value = Fraction.FromDouble(0.1);
Console.WriteLine(value); // Ouputs "3602879701896397/36028797018963968" which is 0.10000000000000000555111512312578
```

The output fraction is an exact representation of the `double` value 0.1, which is actually slightly more than 0.1 due to the limitations of binary floating-point representation.

#### Comparing fractions created with double precision

Using a `Fraction` that was created using this method for strict Equality/Comparison should be avoided. For example:

```csharp
var fraction1 = Fraction.FromDouble(0.1);
var fraction2 = new Fraction(1, 10);
Console.WriteLine(fraction1 == fraction2); // Outputs "False"
```

If you need to compare a `Fraction` created from `double` with others fractions you should either do so by using a tolerance or consider constructing the `Fraction` by [specifying the maximum number of significant digits.](#creation-from-double-with-maximum-number-of-significant-digits)

#### Possible rounding errors near the limits of the double precision

When a `double` value is very close to the limits of its precision, `Fraction.FromDouble(value).ToDouble() == value` might not hold true. This is because the numerator and denominator of the `Fraction` are both very large numbers. When these numbers are converted to `double` for the division operation in the `Fraction.ToDouble` method, they can exceed the precision limit of the `double` type, resulting in a loss of precision.

```csharp
var value = Fraction.FromDouble(double.Epsilon);
Console.WriteLine(value.ToDouble() == double.Epsilon); // Outputs "False"
```

For more detailed information about the behavior of the `Fraction.FromDouble` method and the limitations of the `double` type, please refer to the XML documentation comments in the source code.

### Creation from `double` with maximum number of significant digits

The `Fraction.FromDoubleRounded(double, int)` method allows you to specify the maximum number of significant digits when converting a `double` to a `Fraction`. This can help to avoid large numerators and denominators, and can make the `Fraction` suitable for comparison operations. 

```csharp
var value = Fraction.FromDoubleRounded(0.1, 15); // Returns a fraction with a maximum of 15 significant digits
Console.WriteLine(value); // Outputs "1/10"
```

If you care only about minimizing the size of the numerator/denominator, and do not expect to use the fraction in any strict comparison operations, then [creating an approximated fraction](#creation-from-double-with-rounding-to-a-close-approximation) using the `Fraction.FromDoubleRounded(double)` overload should offer the best performance.

### Creation from `double` with rounding to a close approximation

You can use the `Fraction.FromDoubleRounded(double)` method to avoid big numbers in numerator and denominator. Example:

```csharp
var value = Fraction.FromDoubleRounded(0.1);
Console.WriteLine(value); // Outputs "1/10"
```

However, please note that while rounding to an approximate value would mostly produce the expected result, it shouldn't be relied on for any strict comparison operations. Consider this example:

```csharp
var doubleValue = 1055.05585262;
var roundedValue = Fraction.FromDoubleRounded(doubleValue);      // returns {4085925351/3872710} which is 1055.0558526199999483565771772222
var literalValue = Fraction.FromDoubleRounded(doubleValue, 15);  // returns {52752792631/50000000} which is 1055.05585262 exactly
Console.WriteLine(roundedValue.CompareTo(literalValue); // Outputs "-1" which stands for "smaller than"
Console.WriteLine(roundedValue.ToDouble() == doubleValue); // Outputs "true" as the actual difference is smaller than the precision of the doubles
```

## Creation from `string`

The following string patterns can be parsed:

- `[+/-]n` where _n_ is an integer. Examples: _+5_, _-6_, _1234_, _0_
- `[+/-]n.m` where _n_ and _m_ are integers. The decimal point symbol depends on the system's culture settings. Examples: _-4.3_, _0.45_
- `[+/-]n/[+/-]m` where _n_ and _m_ are integers. Examples: _1/2_, _-4/5_, _+4/-3_, _32/100_
Example:

```csharp
var value = Fraction.FromString("1,5", CultureInfo.GetCultureInfo("de-DE"))
// Returns 3/2 which is 1.5
Console.WriteLine(value);
```

You should consider the `TryParse` methods when reading numbers as text from user input. **Furthermore it is best practice to always supply a culture information (e.g. `CultureInfo.InvariantCulture`).** Otherwise you will sooner or later parse wrong numbers because of different decimal point symbols or included Thousands character.

## Conversion

You can convert a `Fraction` to any supported data type by calling:

- `.ToInt32()`
- `.ToUInt32()`
- `.ToInt64()`
- `.ToUInt64()`
- `.ToBigInteger()`
- `.ToDecimal()`
- `.ToDouble()`
- `.ToString()` (using current culture)
- `.ToString(string)` (using format string and the system's current culture)
- `.ToString(string,IFormatProvider)`

If the target's data type boundary values are exceeded the system will throw an `OverflowException`.

Example:

```csharp
var rationalNumber = new Fraction(1, 3);
var value = rationalNumber.ToDecimal();
// result is 0.33333
Console.WriteLine(Math.Round(value, 5));
```

## String format

| Specifier | Description |
| ----------| ----------- |
| G | General format: &lt;numerator&gt;/&lt;denominator&gt; e.g. _1/3_ |
| n | Numerator |
| d | Denominator |
| z | The fraction as integer |
| r | The positive remainder of all digits after the decimal point using the format: &lt;numerator&gt;/&lt;denominator&gt; or `string.Empty` if the fraction is a valid integer without digits after the decimal point. |
| m | The fraction as mixed number e.g. _2 1/3_ instead of _7/3_ |

**Note:** The special characters _#_, and _0_ like in _#.###_ are not supported. Consider converting the `Fraction` to `decimal`/`double` if you want to support the [custom formats](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings).

Example:

```csharp
var value = new Fraction(3, 2);
// returns 1 1/2
Console.WriteLine(value.ToString("m", CultureInfo.GetCultureInfo("de-DE")));
```

## Decimal Notation Formatter

The `DecimalNotationFormatter` class allows for formatting `Fraction` objects using the standard decimal notation, and the specified format and culture-specific format information. 
Unlike standard numeric types such as `double` and `decimal`, there is no limit to the represented range or precision when using `DecimalNotationFormatter`.

### Usage

Here is a general example of how to use the `DecimalNotationFormatter`:

```csharp
Fraction value = Fraction.FromString("123456789987654321.123456789987654321");
string formattedValue = DecimalNotationFormatter.Instance.Format("G36", value, CultureInfo.InvariantCulture);
Console.WriteLine(formattedValue); // Outputs "123456789987654321.123456789987654321"
```

In this example, the `Format` method is used to format the value of a `Fraction` object into a string using the 'G' (General) format with a precision specifier of 36, which formats the fraction with up to 36 significant digits.

### Supported Formats

The `Format` method supports the following format strings. For more information about these formats, see the [official .NET documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings).

| Specifier | Format Name | Fraction | Format | Output |
|-----------|-------------|----------|--------|--------|
| 'G' or 'g' | [General format](https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-general-g-format-specifier) | `400/3` | 'G2' | `1.3E+02` |
| 'F' or 'f' | [Fixed-point format](https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-fixed-point-f-format-specifier) | `12345/10` | 'F2' | `1234.50` |
| 'N' or 'n' | [Standard Numeric format](https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-number-n-format-specifier) | `1234567/1000` | 'N2' | `1,234.57` |
| 'E' or 'e' | [Scientific format](https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-exponential-e-format-specifier) | `1234567/1000` | 'E2' | `1.23E+003` |
| 'P' or 'p' | [Percent format](https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-percent-p-format-specifier) | `2/3` | 'P2' | `66.67 %` |
| 'C' or 'c' | [Currency format](https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-currency-c-format-specifier) | `1234567/1000` | 'C2' | `$1,234.57` |
| 'R' or 'r' | [Round-trip format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#RFormatString) | `1234567/1000` | 'R' | `1234.567` |
| 'S' or 's' | [Significant Digits After Radix format](#significant-digits-after-radix-format) | `400/3` | 'S2' | `133.33` |

Please note that the 'R' format and the [custom formats](https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings) are handled by casting the `Fraction` to `double`, which may result in a loss of precision.

### Significant Digits After Radix Format

The 'S' format is a non-standard format that formats the fraction with significant digits after the radix and dynamically switches between decimal and scientific notation depending on the value of the fraction. 

For fractions where the absolute value is greater than or equal to 0.001 and less than 10000, the 'S' format uses decimal notation. For all other values, it switches to scientific notation.

Here are a few examples:

```csharp
Fraction value = new Fraction(1, 3);
Console.WriteLine(value.ToString("S")); // Outputs "0.33"

value = newFraction(1, 1000);
Console.WriteLine(value.ToString("S")); // Outputs "0.001"

value = new Fraction(1, 100000);
Console.WriteLine(value.ToString("S")); // Outputs "1E-05"
```

## Mathematic operators

The following mathematic operations are supported:

- `.Reduce()` returns a normalized fraction (e.g. _2/4_ -> _1/2_)
- `.Add(Fraction)` returns the sum of `(a + b)`
- `.Subtract(Fraction)` returns the difference of `(a - b)`
- `.Multiply(Fraction)` returns the product of `(a * b)`
- `.Divide(Fraction)` returns the quotient of `(a / b)`
- `.Remainder(Fraction)` returns the remainder (or left over) of `(a % b)`
- `.Negate()` returns a negated fraction (same operation as `(a * -1)`)
- `.Abs()` returns the absolute value `|a|`
- `Fraction.Pow(Fraction, int)` returns a base raised to a power `(a ^ exponent)` (e.g. _1/10_^(-1) -> _10/1_)
- `Fraction.Round(Fraction, int, MidpointRounding)` returns the fraction, which is rounded to the specified precision
- `Fraction.RoundToBigInteger(Fraction, MidpointRounding)` returns the fraction as rounded BigInteger

As extension method:

- `FractionExt.Sqrt(this Fraction, int)` returns the square root, specifying the precision after the decimal point.

Example:

```csharp
 var a = new Fraction(1, 3);
 var b = new Fraction(2, 3);
 var result = a * b;
 // returns 2/9 which is 0,2222...
 Console.WriteLine(result);
```

### Working with non-normalized fractions

> [!IMPORTANT]
> For performance reasons, as of version 8.0.0, mathematical operations such as addition and multiplication no longer reduce the result to it's lowest terms, unless both operands are already simplified. 
> This change in behavior may introduce unexpected results when, for example, calling `ToString` on a `Fraction` that is the result of an expression, having one or more of the values de-serialized using the default `JsonFractionConverter` settings (i.e. without explicit reduction).


| Symbol | Description                                                                                          |
| ------ | ---------------------------------------------------------------------------------------------------- |
| $NF$   | Non-normalized (possibly reducible) fraction, created with `normalize: false`                         |
| $F$    | Fraction created with `normalize: true` (irreducible)                                                              |
| $⊙$   | Mathematical operation having two operands ($+$, $-$, $*$, $/$, $mod$).                              |

The following rules apply:

$F ⊙ F = F$  
$F ⊙ NF = NF$  
$NF ⊙ F = NF$  
$NF ⊙ NF = NF$  

That said, the following applies for normalized fractions:

```csharp
var a = new Fraction(4, 4, normalize: true); // a is 1/1
var b = new Fraction(2);    // b is 2/1 (automatically normalized)
var result = a / b;         // result is 1/2
```

$\frac{1}{1}/\frac{2}{1}=\frac{1}{2}$

However, for non-normalized fractions the following applies:

```csharp
var a = new Fraction(4, 4, normalize: false);
var b = new Fraction(2);    // b is 2/1 (automatically normalized)
var result = a / b;         // result is 4/8
```

$\frac{4}{4}/\frac{2}{1}=\frac{4}{8}$

## Equality operators

`Fraction` implements the following interfaces:

- `IEquatable<Fraction>`,
- `IComparable`,
- `IComparable<Fraction>`

> [!IMPORTANT]
> Please note that the default behavior of the `.Equals(Fraction)` method has changed with version 8.0.0. `Equals` now compares the calculated value from the $numerator/denominator$ ($Equals(\frac{1}{2}, \frac{2}{4}) = true$).

In case you want to compare the numerator and denominator exactly (i.e. $Equals(\frac{1}{2}, \frac{2}{4}) = false$) then you can use the new `FractionComparer.StrictEquality` comparer.

That said:

```csharp
var a = new Fraction(1, 2, normalize: true);
var b = new Fraction(1, 2, normalize: false);
var c = new Fraction(2, 4, normalize: false); // the fraction is not reduced

// result1 is true
var result1 = a == a;

// result2 is true
var result2 = a == b;

// result3 is true
var result3 = a == c;

// Special case:
// same behavior as with double, see https://learn.microsoft.com/en-us/dotnet/api/system.double.op_equality#remarks
// result4 is false 
var result4 = Fraction.NaN == Fraction.NaN;
```

## Under the hood

The data type stores the numerator and denominator as `BigInteger`. Per default it will reduce fractions to its normalized form during creation. The result of each mathematical operation will be reduced as well. There is a special constructor to create a non-normalized fraction. Be aware that `Equals` relies on normalized values when comparing two different instances.

## Performance considerations

We have a suite of benchmarks that test the performance of various operations in the Fractions library. These benchmarks provide valuable insights into the relative performance of different test cases.
For more detailed information about these benchmarks and how to interpret them, please refer to the [Fractions Benchmarks Readme](./benchmarks/Readme.md) in the benchmarks subfolder.

## Build from source

[![Build status](https://ci.appveyor.com/api/projects/status/22acgj4m7pt5wr8d?svg=true)](https://ci.appveyor.com/project/danm-de/fractions)

Just run `dotnet build -c release`.

### Required software frameworks

- .Net 8.0 SDK
