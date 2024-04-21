```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method           | fraction             | Mean       | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------- |--------------------- |-----------:|----------:|----------:|------:|--------:|----------:|------------:|
| **ConvertToDouble**  | **0**                    |  **0.6018 ns** | **0.0027 ns** | **0.0025 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 0                    |  2.8818 ns | 0.0155 ns | 0.0145 ns |  4.79 |    0.03 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **1/10**                 | **10.3345 ns** | **0.0334 ns** | **0.0313 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 1/10                 | 25.0942 ns | 0.0577 ns | 0.0539 ns |  2.43 |    0.01 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **1/3**                  | **10.3167 ns** | **0.0323 ns** | **0.0303 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 1/3                  | 38.3337 ns | 0.1716 ns | 0.1605 ns |  3.72 |    0.02 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **1**                    | **10.2802 ns** | **0.0201 ns** | **0.0178 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 1                    | 13.4681 ns | 0.0213 ns | 0.0199 ns |  1.31 |    0.00 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **10**                   | **10.3151 ns** | **0.0434 ns** | **0.0406 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 10                   | 13.6004 ns | 0.0215 ns | 0.0179 ns |  1.32 |    0.00 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **79228(...)50335 [29]** | **13.3997 ns** | **0.0223 ns** | **0.0209 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 79228(...)50335 [29] | 29.0847 ns | 0.0429 ns | 0.0381 ns |  2.17 |    0.00 |         - |          NA |
