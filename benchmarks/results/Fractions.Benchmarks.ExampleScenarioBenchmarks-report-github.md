```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5131/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.100
  [Host]                       : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  MediumRun-.NET 9.0           : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  MediumRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9282.0), X64 RyuJIT VectorSize=256

IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method                     | Job                          | Runtime            | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|--------------------------- |----------------------------- |------------------- |----------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| PrepareSchedulesReduced    | MediumRun-.NET 9.0           | .NET 9.0           | 10.228 μs | 0.5222 μs | 0.7816 μs |  1.01 |    0.11 | 0.8698 | 0.0305 |  14.38 KB |        1.00 |
| PrepareSchedulesNonReduced | MediumRun-.NET 9.0           | .NET 9.0           |  9.135 μs | 0.0789 μs | 0.1181 μs |  0.90 |    0.07 | 0.9155 | 0.0305 |  15.06 KB |        1.05 |
|                            |                              |                    |           |           |           |       |         |        |        |           |             |
| PrepareSchedulesReduced    | MediumRun-.NET Framework 4.8 | .NET Framework 4.8 | 27.178 μs | 0.0977 μs | 0.1432 μs |  1.00 |    0.01 | 4.7913 | 0.1221 |  29.52 KB |        1.00 |
| PrepareSchedulesNonReduced | MediumRun-.NET Framework 4.8 | .NET Framework 4.8 | 20.746 μs | 0.0801 μs | 0.1069 μs |  0.76 |    0.01 | 4.9438 | 0.1221 |  30.56 KB |        1.04 |
