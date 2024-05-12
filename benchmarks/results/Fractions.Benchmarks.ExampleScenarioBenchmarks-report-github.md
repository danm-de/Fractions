```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]                       : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  MediumRun-.NET 8.0           : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  MediumRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9232.0), X64 RyuJIT VectorSize=256

IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method                    | Job                          | Runtime            | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|-------------------------- |----------------------------- |------------------- |----------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| PrepareScheduleReduced    | MediumRun-.NET 8.0           | .NET 8.0           |  7.441 μs | 0.0394 μs | 0.0565 μs |  1.00 |    0.00 | 0.4272 | 0.0076 |   6.98 KB |        1.00 |
| PrepareScheduleNonReduced | MediumRun-.NET 8.0           | .NET 8.0           |  6.123 μs | 0.0584 μs | 0.0837 μs |  0.82 |    0.02 | 0.4272 | 0.0076 |   6.98 KB |        1.00 |
|                           |                              |                    |           |           |           |       |         |        |        |           |             |
| PrepareScheduleReduced    | MediumRun-.NET Framework 4.8 | .NET Framework 4.8 | 24.110 μs | 0.1658 μs | 0.2324 μs |  1.00 |    0.00 | 2.5330 | 0.0305 |  15.64 KB |        1.00 |
| PrepareScheduleNonReduced | MediumRun-.NET Framework 4.8 | .NET Framework 4.8 | 19.502 μs | 0.1580 μs | 0.2265 μs |  0.81 |    0.01 | 2.5330 | 0.0305 |  15.64 KB |        1.00 |
