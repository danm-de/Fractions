```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.205
  [Host]                       : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  MediumRun-.NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  MediumRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256

IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method                     | Job                          | Runtime            | Mean      | Error     | StdDev    | Ratio | Gen0   | Gen1   | Allocated | Alloc Ratio |
|--------------------------- |----------------------------- |------------------- |----------:|----------:|----------:|------:|-------:|-------:|----------:|------------:|
| PrepareSchedulesReduced    | MediumRun-.NET 8.0           | .NET 8.0           |  9.592 μs | 0.0469 μs | 0.0687 μs |  1.00 | 0.8698 | 0.0305 |  14.38 KB |        1.00 |
| PrepareSchedulesNonReduced | MediumRun-.NET 8.0           | .NET 8.0           |  8.598 μs | 0.0599 μs | 0.0878 μs |  0.90 | 0.9003 | 0.0305 |  14.81 KB |        1.03 |
|                            |                              |                    |           |           |           |       |        |        |           |             |
| PrepareSchedulesReduced    | MediumRun-.NET Framework 4.8 | .NET Framework 4.8 | 25.779 μs | 0.0840 μs | 0.1231 μs |  1.00 | 4.7913 | 0.1221 |  29.52 KB |        1.00 |
| PrepareSchedulesNonReduced | MediumRun-.NET Framework 4.8 | .NET Framework 4.8 | 24.344 μs | 0.0987 μs | 0.1478 μs |  0.94 | 4.8523 | 0.1221 |  29.96 KB |        1.01 |
