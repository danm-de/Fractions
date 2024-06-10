```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.300
  [Host]                       : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  MediumRun-.NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  MediumRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256

IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method                     | Job                          | Runtime            | Mean      | Error     | StdDev    | Ratio | Gen0   | Gen1   | Allocated | Alloc Ratio |
|--------------------------- |----------------------------- |------------------- |----------:|----------:|----------:|------:|-------:|-------:|----------:|------------:|
| PrepareSchedulesReduced    | MediumRun-.NET 8.0           | .NET 8.0           | 10.378 μs | 0.0374 μs | 0.0548 μs |  1.00 | 0.8698 | 0.0305 |  14.38 KB |        1.00 |
| PrepareSchedulesNonReduced | MediumRun-.NET 8.0           | .NET 8.0           |  9.465 μs | 0.0588 μs | 0.0844 μs |  0.91 | 0.8698 | 0.0305 |  14.38 KB |        1.00 |
|                            |                              |                    |           |           |           |       |        |        |           |             |
| PrepareSchedulesReduced    | MediumRun-.NET Framework 4.8 | .NET Framework 4.8 | 25.980 μs | 0.1747 μs | 0.2615 μs |  1.00 | 4.7913 | 0.1221 |  29.52 KB |        1.00 |
| PrepareSchedulesNonReduced | MediumRun-.NET Framework 4.8 | .NET Framework 4.8 | 23.667 μs | 0.1044 μs | 0.1531 μs |  0.91 | 4.7913 | 0.1221 |  29.52 KB |        1.00 |
