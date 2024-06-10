```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.300
  [Host]                      : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method     | Job                         | Runtime            | fraction             | Mean      | Error     | StdDev    | Allocated |
|----------- |---------------------------- |------------------- |--------------------- |----------:|----------:|----------:|----------:|
| **Abs**        | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **NaN**                  |  **5.585 ns** | **0.0740 ns** | **0.0041 ns** |         **-** |
| Negate     | ShortRun-.NET 8.0           | .NET 8.0           | NaN                  |  2.133 ns | 0.0193 ns | 0.0011 ns |         - |
| Reciprocal | ShortRun-.NET 8.0           | .NET 8.0           | NaN                  |  4.039 ns | 0.4382 ns | 0.0240 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | NaN                  | 18.257 ns | 0.8363 ns | 0.0458 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | NaN                  | 14.055 ns | 0.3971 ns | 0.0218 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | NaN                  | 21.890 ns | 0.1206 ns | 0.0066 ns |         - |
| **Negate**     | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-42/-96**              |  **2.151 ns** | **0.1403 ns** | **0.0077 ns** |         **-** |
| Reciprocal | ShortRun-.NET 8.0           | .NET 8.0           | -42/-96              |  4.219 ns | 0.3053 ns | 0.0167 ns |         - |
| **Negate**     | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-7922(...)50335 [30]** |  **1.992 ns** | **0.1564 ns** | **0.0086 ns** |         **-** |
| **Negate**     | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1/1000000000000**      |  **2.174 ns** | **0.2107 ns** | **0.0115 ns** |         **-** |
| **Abs**        | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **-∞**                   | **18.075 ns** | **0.1488 ns** | **0.0082 ns** |         **-** |
| **Reciprocal** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1/1000000000000**      |  **3.905 ns** | **2.0174 ns** | **0.1106 ns** |         **-** |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1/1000000000000      | 21.835 ns | 0.5703 ns | 0.0313 ns |         - |
| **Reciprocal** | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **1/10**                 | **21.678 ns** | **0.2634 ns** | **0.0144 ns** |         **-** |
| **Reciprocal** | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **27/200**               | **21.814 ns** | **0.5693 ns** | **0.0312 ns** |         **-** |
| **Negate**     | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **36/96**                |  **2.132 ns** | **0.0401 ns** | **0.0022 ns** |         **-** |
| **Negate**     | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-∞**                   |  **2.138 ns** | **0.0247 ns** | **0.0014 ns** |         **-** |
| Reciprocal | ShortRun-.NET 8.0           | .NET 8.0           | -∞                   |  4.071 ns | 0.1924 ns | 0.0105 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -∞                   | 14.087 ns | 0.6161 ns | 0.0338 ns |         - |
| **Reciprocal** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **36/96**                |  **4.051 ns** | **0.1524 ns** | **0.0084 ns** |         **-** |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 36/96                | 21.644 ns | 1.9918 ns | 0.1092 ns |         - |
| **Negate**     | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/66**                |  **2.152 ns** | **0.2615 ns** | **0.0143 ns** |         **-** |
| Reciprocal | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                |  4.025 ns | 0.1873 ns | 0.0103 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 21.613 ns | 1.4924 ns | 0.0818 ns |         - |
| **Negate**     | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1**                    |  **2.130 ns** | **0.0174 ns** | **0.0010 ns** |         **-** |
| Reciprocal | ShortRun-.NET 8.0           | .NET 8.0           | 1                    |  3.862 ns | 0.0726 ns | 0.0040 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1                    | 21.690 ns | 0.8574 ns | 0.0470 ns |         - |
| **Negate**     | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **88427(...)10656 [31]** |  **1.979 ns** | **0.0726 ns** | **0.0040 ns** |         **-** |
| **Abs**        | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-∞**                   |  **5.017 ns** | **0.1123 ns** | **0.0062 ns** |         **-** |
| **Reciprocal** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **88427(...)10656 [31]** |  **3.976 ns** | **1.8644 ns** | **0.1022 ns** |         **-** |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 21.838 ns | 0.4132 ns | 0.0226 ns |         - |
| **Negate**     | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **10**                   |  **2.142 ns** | **0.4111 ns** | **0.0225 ns** |         **-** |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 10                   | 21.833 ns | 0.3502 ns | 0.0192 ns |         - |
| **Reciprocal** | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **79228(...)50335 [29]** | **21.832 ns** | **0.5037 ns** | **0.0276 ns** |         **-** |
| **Reciprocal** | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **-∞**                   | **18.381 ns** | **0.1493 ns** | **0.0082 ns** |         **-** |
| **Reciprocal** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-7922(...)50335 [30]** |  **3.695 ns** | **0.2301 ns** | **0.0126 ns** |         **-** |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -7922(...)50335 [30] | 21.825 ns | 0.4533 ns | 0.0248 ns |         - |
| **Negate**     | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-8842(...)10656 [32]** |  **2.161 ns** | **0.1199 ns** | **0.0066 ns** |         **-** |
| Reciprocal | ShortRun-.NET 8.0           | .NET 8.0           | -8842(...)10656 [32] |  3.587 ns | 2.2722 ns | 0.1245 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -8842(...)10656 [32] | 21.796 ns | 0.0876 ns | 0.0048 ns |         - |
| **Negate**     | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-27/200**              |  **2.141 ns** | **0.0333 ns** | **0.0018 ns** |         **-** |
| Reciprocal | ShortRun-.NET 8.0           | .NET 8.0           | -27/200              |  3.495 ns | 0.0392 ns | 0.0022 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -27/200              | 21.828 ns | 0.2649 ns | 0.0145 ns |         - |
| **Abs**        | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **0**                    |  **5.556 ns** | **0.0945 ns** | **0.0052 ns** |         **-** |
| Negate     | ShortRun-.NET 8.0           | .NET 8.0           | 0                    |  2.146 ns | 0.0255 ns | 0.0014 ns |         - |
| Reciprocal | ShortRun-.NET 8.0           | .NET 8.0           | 0                    |  3.990 ns | 1.9750 ns | 0.1083 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 18.423 ns | 0.5857 ns | 0.0321 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 15.260 ns | 0.4052 ns | 0.0222 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 21.720 ns | 0.6913 ns | 0.0379 ns |         - |
| **Abs**        | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **∞**                    |  **5.720 ns** | **0.1686 ns** | **0.0092 ns** |         **-** |
| Negate     | ShortRun-.NET 8.0           | .NET 8.0           | ∞                    |  2.134 ns | 0.0701 ns | 0.0038 ns |         - |
| **Negate**     | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1/10**                 |  **2.144 ns** | **0.3123 ns** | **0.0171 ns** |         **-** |
| Reciprocal | ShortRun-.NET 8.0           | .NET 8.0           | 1/10                 |  3.863 ns | 0.2430 ns | 0.0133 ns |         - |
| **Negate**     | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **27/200**               |  **2.180 ns** | **0.2508 ns** | **0.0137 ns** |         **-** |
| Reciprocal | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               |  3.882 ns | 0.2455 ns | 0.0135 ns |         - |
| **Negate**     | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **∞**                    | **15.588 ns** | **0.5888 ns** | **0.0323 ns** |         **-** |
| **Reciprocal** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **10**                   |  **3.942 ns** | **2.3056 ns** | **0.1264 ns** |         **-** |
| **Negate**     | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **79228(...)50335 [29]** |  **2.171 ns** | **0.2430 ns** | **0.0133 ns** |         **-** |
| Reciprocal | ShortRun-.NET 8.0           | .NET 8.0           | 79228(...)50335 [29] |  3.916 ns | 2.0792 ns | 0.1140 ns |         - |
| **Reciprocal** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **∞**                    |  **4.048 ns** | **0.5163 ns** | **0.0283 ns** |         **-** |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | ∞                    | 18.155 ns | 0.5228 ns | 0.0287 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | ∞                    | 18.597 ns | 1.8384 ns | 0.1008 ns |         - |
| **Abs**        | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-42/-96**              |  **7.242 ns** | **0.4162 ns** | **0.0228 ns** |         **-** |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -42/-96              | 21.547 ns | 0.6578 ns | 0.0361 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -42/-96              | 14.076 ns | 0.4106 ns | 0.0225 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -42/-96              | 21.836 ns | 1.2586 ns | 0.0690 ns |         - |
| **Abs**        | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/-96**               |  **6.882 ns** | **0.1980 ns** | **0.0109 ns** |         **-** |
| Negate     | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               |  2.141 ns | 0.2188 ns | 0.0120 ns |         - |
| Reciprocal | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               |  4.103 ns | 2.0765 ns | 0.1138 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 21.785 ns | 2.5017 ns | 0.1371 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 15.566 ns | 0.4321 ns | 0.0237 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 21.667 ns | 0.2090 ns | 0.0115 ns |         - |
| **Abs**        | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)00000 [39]** |  **5.110 ns** | **1.9321 ns** | **0.1059 ns** |         **-** |
| Negate     | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] |  1.999 ns | 0.2957 ns | 0.0162 ns |         - |
| Reciprocal | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] |  3.513 ns | 0.5822 ns | 0.0319 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 18.132 ns | 0.2142 ns | 0.0117 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 14.108 ns | 2.9029 ns | 0.1591 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 21.848 ns | 0.9965 ns | 0.0546 ns |         - |
| **Abs**        | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-7922(...)50335 [30]** |  **5.058 ns** | **1.8417 ns** | **0.1010 ns** |         **-** |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -7922(...)50335 [30] | 18.032 ns | 2.2454 ns | 0.1231 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -7922(...)50335 [30] | 14.148 ns | 0.1321 ns | 0.0072 ns |         - |
| **Abs**        | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-8842(...)10656 [32]** |  **4.997 ns** | **0.1585 ns** | **0.0087 ns** |         **-** |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -8842(...)10656 [32] | 17.975 ns | 0.6678 ns | 0.0366 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -8842(...)10656 [32] | 15.412 ns | 1.7255 ns | 0.0946 ns |         - |
| **Abs**        | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-27/200**              |  **5.019 ns** | **0.0931 ns** | **0.0051 ns** |         **-** |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -27/200              | 18.153 ns | 0.8845 ns | 0.0485 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -27/200              | 15.462 ns | 0.9835 ns | 0.0539 ns |         - |
| **Abs**        | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1/1000000000000**      |  **5.567 ns** | **0.1389 ns** | **0.0076 ns** |         **-** |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1/1000000000000      | 18.301 ns | 0.0589 ns | 0.0032 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1/1000000000000      | 15.312 ns | 0.0890 ns | 0.0049 ns |         - |
| **Abs**        | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1/10**                 |  **5.740 ns** | **0.0658 ns** | **0.0036 ns** |         **-** |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1/10                 | 27.018 ns | 0.3519 ns | 0.0193 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1/10                 | 15.498 ns | 0.5063 ns | 0.0277 ns |         - |
| **Abs**        | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **27/200**               |  **5.754 ns** | **0.1781 ns** | **0.0098 ns** |         **-** |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 18.265 ns | 0.3509 ns | 0.0192 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 14.090 ns | 1.0773 ns | 0.0591 ns |         - |
| **Abs**        | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **36/96**                |  **8.255 ns** | **2.0523 ns** | **0.1125 ns** |         **-** |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 36/96                | 21.926 ns | 0.4237 ns | 0.0232 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 36/96                | 13.996 ns | 0.2496 ns | 0.0137 ns |         - |
| **Abs**        | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/66**                |  **8.158 ns** | **0.0740 ns** | **0.0041 ns** |         **-** |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 22.202 ns | 1.1888 ns | 0.0652 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 14.032 ns | 1.0864 ns | 0.0595 ns |         - |
| **Abs**        | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1**                    |  **5.583 ns** | **0.1190 ns** | **0.0065 ns** |         **-** |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1                    | 18.444 ns | 1.9682 ns | 0.1079 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1                    | 15.547 ns | 0.1580 ns | 0.0087 ns |         - |
| **Abs**        | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **88427(...)10656 [31]** |  **5.651 ns** | **1.9241 ns** | **0.1055 ns** |         **-** |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 17.935 ns | 0.5799 ns | 0.0318 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 14.095 ns | 0.3023 ns | 0.0166 ns |         - |
| **Abs**        | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **10**                   |  **5.575 ns** | **0.2566 ns** | **0.0141 ns** |         **-** |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 10                   | 18.286 ns | 0.7299 ns | 0.0400 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 10                   | 14.052 ns | 0.2249 ns | 0.0123 ns |         - |
| **Abs**        | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **79228(...)50335 [29]** |  **5.669 ns** | **1.9391 ns** | **0.1063 ns** |         **-** |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 79228(...)50335 [29] | 17.959 ns | 0.4077 ns | 0.0223 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 79228(...)50335 [29] | 15.447 ns | 0.2408 ns | 0.0132 ns |         - |
