```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4170/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method           | fraction             | Mean       | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------- |--------------------- |-----------:|----------:|----------:|------:|--------:|----------:|------------:|
| **ConvertToDouble**  | **0**                    |  **0.1876 ns** | **0.0153 ns** | **0.0143 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 0                    |  2.9211 ns | 0.0295 ns | 0.0276 ns | 15.66 |    1.28 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **1/10**                 | **10.1118 ns** | **0.0961 ns** | **0.0899 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 1/10                 | 26.1153 ns | 0.2389 ns | 0.2235 ns |  2.58 |    0.02 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **1/3**                  | **10.1212 ns** | **0.0764 ns** | **0.0715 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 1/3                  | 38.8582 ns | 0.3116 ns | 0.2915 ns |  3.84 |    0.04 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **1**                    |  **9.9788 ns** | **0.0939 ns** | **0.0879 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 1                    | 14.0782 ns | 0.1247 ns | 0.1167 ns |  1.41 |    0.02 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **10**                   |  **9.9971 ns** | **0.0660 ns** | **0.0617 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 10                   | 13.6648 ns | 0.1334 ns | 0.1248 ns |  1.37 |    0.01 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **79228(...)50335 [29]** | **13.4279 ns** | **0.1006 ns** | **0.0941 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 79228(...)50335 [29] | 30.2528 ns | 0.2741 ns | 0.2564 ns |  2.25 |    0.03 |         - |          NA |
