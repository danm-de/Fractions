```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method           | fraction             | Mean       | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------- |--------------------- |-----------:|----------:|----------:|------:|--------:|----------:|------------:|
| **ConvertToDouble**  | **0**                    |  **0.8075 ns** | **0.0107 ns** | **0.0095 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 0                    |  4.0134 ns | 0.0144 ns | 0.0128 ns |  4.97 |    0.06 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **1/10**                 |  **3.1258 ns** | **0.0115 ns** | **0.0096 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 1/10                 | 26.4338 ns | 0.1027 ns | 0.0960 ns |  8.45 |    0.04 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **1/3**                  |  **3.1396 ns** | **0.0260 ns** | **0.0243 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 1/3                  | 37.2930 ns | 0.1303 ns | 0.1088 ns | 11.87 |    0.09 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **1**                    |  **3.1179 ns** | **0.0203 ns** | **0.0180 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 1                    | 12.8143 ns | 0.0159 ns | 0.0141 ns |  4.11 |    0.03 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **10**                   |  **3.1207 ns** | **0.0235 ns** | **0.0220 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 10                   | 13.4079 ns | 0.0522 ns | 0.0436 ns |  4.29 |    0.03 |         - |          NA |
|                  |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**  | **79228(...)50335 [29]** |  **6.1994 ns** | **0.0187 ns** | **0.0166 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal | 79228(...)50335 [29] | 25.4987 ns | 0.2524 ns | 0.2237 ns |  4.11 |    0.03 |         - |          NA |
