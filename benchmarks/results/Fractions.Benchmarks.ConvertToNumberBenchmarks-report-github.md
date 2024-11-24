```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5131/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method              | fraction             | Mean       | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------- |--------------------- |-----------:|----------:|----------:|------:|--------:|----------:|------------:|
| **ConvertToDouble**     | **0**                    |  **1.0024 ns** | **0.0111 ns** | **0.0093 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| ConvertToDecimal    | 0                    |  2.7662 ns | 0.0681 ns | 0.0784 ns |  2.76 |    0.08 |         - |          NA |
| ConvertToBigInteger | 0                    |  1.4730 ns | 0.0087 ns | 0.0081 ns |  1.47 |    0.02 |         - |          NA |
|                     |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**     | **1/10**                 |  **1.3461 ns** | **0.0073 ns** | **0.0068 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| ConvertToDecimal    | 1/10                 | 23.5164 ns | 0.1565 ns | 0.1464 ns | 17.47 |    0.14 |         - |          NA |
| ConvertToBigInteger | 1/10                 |  7.1879 ns | 0.0192 ns | 0.0161 ns |  5.34 |    0.03 |         - |          NA |
|                     |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**     | **1/3**                  |  **1.3154 ns** | **0.0140 ns** | **0.0124 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| ConvertToDecimal    | 1/3                  | 37.5789 ns | 0.2815 ns | 0.2633 ns | 28.57 |    0.32 |         - |          NA |
| ConvertToBigInteger | 1/3                  |  6.9982 ns | 0.0264 ns | 0.0247 ns |  5.32 |    0.05 |         - |          NA |
|                     |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**     | **1**                    |  **1.0807 ns** | **0.0105 ns** | **0.0088 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| ConvertToDecimal    | 1                    |  2.6711 ns | 0.0724 ns | 0.0862 ns |  2.47 |    0.08 |         - |          NA |
| ConvertToBigInteger | 1                    |  1.6279 ns | 0.0102 ns | 0.0096 ns |  1.51 |    0.01 |         - |          NA |
|                     |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**     | **10**                   |  **0.9976 ns** | **0.0163 ns** | **0.0145 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| ConvertToDecimal    | 10                   |  4.2289 ns | 0.0005 ns | 0.0004 ns |  4.24 |    0.06 |         - |          NA |
| ConvertToBigInteger | 10                   |  1.4976 ns | 0.0066 ns | 0.0062 ns |  1.50 |    0.02 |         - |          NA |
|                     |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**     | **2147483647**           |  **1.0218 ns** | **0.0117 ns** | **0.0109 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| ConvertToDecimal    | 2147483647           |  2.9349 ns | 0.0779 ns | 0.0833 ns |  2.87 |    0.08 |         - |          NA |
| ConvertToBigInteger | 2147483647           |  1.3910 ns | 0.0091 ns | 0.0081 ns |  1.36 |    0.02 |         - |          NA |
|                     |                      |            |           |           |       |         |           |             |
| **ConvertToDouble**     | **79228(...)50335 [29]** |  **2.9559 ns** | **0.0070 ns** | **0.0062 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ConvertToDecimal    | 79228(...)50335 [29] |  3.8930 ns | 0.0124 ns | 0.0116 ns |  1.32 |    0.00 |         - |          NA |
| ConvertToBigInteger | 79228(...)50335 [29] |  1.3933 ns | 0.0128 ns | 0.0120 ns |  0.47 |    0.00 |         - |          NA |
