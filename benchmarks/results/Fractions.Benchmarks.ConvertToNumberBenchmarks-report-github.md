```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method           | fraction             | Mean       | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------- |--------------------- |-----------:|----------:|----------:|------:|--------:|----------:|------------:|
| **ConvertToDouble**  | **0**                    |  **0.9628 ns** | **0.0094 ns** | **0.0083 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 0                    |  4.0236 ns | 0.0264 ns | 0.0234 ns |  4.18 |    0.04 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **1/10**                 |  **3.1228 ns** | **0.0367 ns** | **0.0344 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 1/10                 | 25.1917 ns | 0.1800 ns | 0.1684 ns |  8.07 |    0.10 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **1/3**                  |  **3.0972 ns** | **0.0218 ns** | **0.0194 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 1/3                  | 37.2712 ns | 0.2605 ns | 0.2310 ns | 12.03 |    0.13 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **1**                    |  **3.0966 ns** | **0.0244 ns** | **0.0228 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 1                    | 14.1269 ns | 0.0843 ns | 0.0747 ns |  4.56 |    0.05 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **10**                   |  **3.1139 ns** | **0.0278 ns** | **0.0246 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 10                   | 13.0731 ns | 0.1034 ns | 0.0864 ns |  4.20 |    0.04 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **79228(...)50335 [29]** |  **5.8255 ns** | **0.0390 ns** | **0.0346 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 79228(...)50335 [29] | 27.4897 ns | 0.1962 ns | 0.1740 ns |  4.72 |    0.04 |         - |          NA |
