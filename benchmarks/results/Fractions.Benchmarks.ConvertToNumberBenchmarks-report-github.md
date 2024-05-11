```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method              | fraction             | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------- |--------------------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|
| **ConvertToDouble**     | **0**                    |  **1.019 ns** | **0.0084 ns** | **0.0078 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal    | 0                    |  3.057 ns | 0.0085 ns | 0.0076 ns |  3.00 |    0.02 |         - |          NA |
| ConvertToBigInteger | 0                    |  1.384 ns | 0.0038 ns | 0.0035 ns |  1.36 |    0.01 |         - |          NA |
|                     |                      |           |           |           |       |         |           |             |
| **ConvertToDouble**     | **1/10**                 |  **1.387 ns** | **0.0198 ns** | **0.0185 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal    | 1/10                 | 23.439 ns | 0.1490 ns | 0.1393 ns | 16.90 |    0.26 |         - |          NA |
| ConvertToBigInteger | 1/10                 |  7.147 ns | 0.0309 ns | 0.0289 ns |  5.15 |    0.08 |         - |          NA |
|                     |                      |           |           |           |       |         |           |             |
| **ConvertToDouble**     | **1/3**                  |  **1.383 ns** | **0.0124 ns** | **0.0116 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal    | 1/3                  | 36.369 ns | 0.1354 ns | 0.1201 ns | 26.31 |    0.25 |         - |          NA |
| ConvertToBigInteger | 1/3                  |  7.147 ns | 0.0366 ns | 0.0343 ns |  5.17 |    0.05 |         - |          NA |
|                     |                      |           |           |           |       |         |           |             |
| **ConvertToDouble**     | **1**                    |  **1.064 ns** | **0.0048 ns** | **0.0043 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal    | 1                    |  3.072 ns | 0.0193 ns | 0.0181 ns |  2.89 |    0.02 |         - |          NA |
| ConvertToBigInteger | 1                    |  1.384 ns | 0.0068 ns | 0.0064 ns |  1.30 |    0.01 |         - |          NA |
|                     |                      |           |           |           |       |         |           |             |
| **ConvertToDouble**     | **10**                   |  **1.051 ns** | **0.0081 ns** | **0.0076 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal    | 10                   |  3.066 ns | 0.0097 ns | 0.0081 ns |  2.92 |    0.02 |         - |          NA |
| ConvertToBigInteger | 10                   |  1.380 ns | 0.0059 ns | 0.0052 ns |  1.31 |    0.01 |         - |          NA |
|                     |                      |           |           |           |       |         |           |             |
| **ConvertToDouble**     | **2147483647**           |  **1.052 ns** | **0.0185 ns** | **0.0173 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal    | 2147483647           |  3.054 ns | 0.0075 ns | 0.0070 ns |  2.90 |    0.05 |         - |          NA |
| ConvertToBigInteger | 2147483647           |  1.377 ns | 0.0070 ns | 0.0065 ns |  1.31 |    0.03 |         - |          NA |
|                     |                      |           |           |           |       |         |           |             |
| **ConvertToDouble**     | **79228(...)50335 [29]** |  **3.286 ns** | **0.0195 ns** | **0.0183 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal    | 79228(...)50335 [29] |  3.095 ns | 0.0071 ns | 0.0063 ns |  0.94 |    0.01 |         - |          NA |
| ConvertToBigInteger | 79228(...)50335 [29] |  1.497 ns | 0.0068 ns | 0.0063 ns |  0.46 |    0.00 |         - |          NA |
