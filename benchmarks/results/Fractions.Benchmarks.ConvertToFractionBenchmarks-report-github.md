```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5131/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.100
  [Host]                      : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET 9.0           : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9282.0), X64 RyuJIT VectorSize=256

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method     | Job                         | Runtime            | fraction             | Mean      | Error      | StdDev    | Allocated |
|----------- |---------------------------- |------------------- |--------------------- |----------:|-----------:|----------:|----------:|
| **Abs**        | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **NaN**                  |  **5.172 ns** |  **0.2645 ns** | **0.0145 ns** |         **-** |
| Negate     | ShortRun-.NET 9.0           | .NET 9.0           | NaN                  |  2.169 ns |  0.2929 ns | 0.0161 ns |         - |
| Reciprocal | ShortRun-.NET 9.0           | .NET 9.0           | NaN                  |  3.526 ns |  2.2495 ns | 0.1233 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | NaN                  | 18.206 ns |  0.2382 ns | 0.0131 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | NaN                  | 15.641 ns |  4.1935 ns | 0.2299 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | NaN                  | 21.803 ns |  0.0869 ns | 0.0048 ns |         - |
| **Abs**        | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **-∞**                   |  **5.176 ns** |  **0.6708 ns** | **0.0368 ns** |         **-** |
| Negate     | ShortRun-.NET 9.0           | .NET 9.0           | -∞                   |  2.033 ns |  0.9109 ns | 0.0499 ns |         - |
| Reciprocal | ShortRun-.NET 9.0           | .NET 9.0           | -∞                   |  3.328 ns |  0.7240 ns | 0.0397 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -∞                   | 18.419 ns |  7.2631 ns | 0.3981 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -∞                   | 14.157 ns |  1.7280 ns | 0.0947 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -∞                   | 18.630 ns |  1.3612 ns | 0.0746 ns |         - |
| **Abs**        | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **-1000(...)00000 [39]** |  **5.522 ns** |  **0.0523 ns** | **0.0029 ns** |         **-** |
| Negate     | ShortRun-.NET 9.0           | .NET 9.0           | -1000(...)00000 [39] |  2.158 ns |  0.0388 ns | 0.0021 ns |         - |
| Reciprocal | ShortRun-.NET 9.0           | .NET 9.0           | -1000(...)00000 [39] |  3.226 ns |  2.0288 ns | 0.1112 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 18.022 ns |  0.0949 ns | 0.0052 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 15.456 ns |  0.1249 ns | 0.0068 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 21.651 ns |  0.5331 ns | 0.0292 ns |         - |
| **Abs**        | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **-7922(...)50335 [30]** |  **5.160 ns** |  **0.3691 ns** | **0.0202 ns** |         **-** |
| Negate     | ShortRun-.NET 9.0           | .NET 9.0           | -7922(...)50335 [30] |  2.144 ns |  2.6160 ns | 0.1434 ns |         - |
| Reciprocal | ShortRun-.NET 9.0           | .NET 9.0           | -7922(...)50335 [30] |  3.650 ns | 15.0375 ns | 0.8243 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -7922(...)50335 [30] | 17.938 ns |  6.5371 ns | 0.3583 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -7922(...)50335 [30] | 15.664 ns |  0.7695 ns | 0.0422 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -7922(...)50335 [30] | 22.347 ns |  6.0576 ns | 0.3320 ns |         - |
| **Abs**        | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **-8842(...)10656 [32]** |  **5.301 ns** |  **1.2043 ns** | **0.0660 ns** |         **-** |
| Negate     | ShortRun-.NET 9.0           | .NET 9.0           | -8842(...)10656 [32] |  2.288 ns |  2.2385 ns | 0.1227 ns |         - |
| Reciprocal | ShortRun-.NET 9.0           | .NET 9.0           | -8842(...)10656 [32] |  3.130 ns |  0.4907 ns | 0.0269 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -8842(...)10656 [32] | 18.114 ns |  2.8828 ns | 0.1580 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -8842(...)10656 [32] | 14.199 ns |  1.4133 ns | 0.0775 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -8842(...)10656 [32] | 22.044 ns |  5.5127 ns | 0.3022 ns |         - |
| **Abs**        | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **42/-96**               |  **6.540 ns** |  **0.8250 ns** | **0.0452 ns** |         **-** |
| Negate     | ShortRun-.NET 9.0           | .NET 9.0           | 42/-96               |  2.214 ns |  0.0380 ns | 0.0021 ns |         - |
| Reciprocal | ShortRun-.NET 9.0           | .NET 9.0           | 42/-96               |  3.507 ns |  1.8099 ns | 0.0992 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 21.810 ns |  0.0923 ns | 0.0051 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 14.087 ns |  0.1885 ns | 0.0103 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 21.536 ns |  0.2796 ns | 0.0153 ns |         - |
| **Abs**        | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **-27/200**              |  **5.233 ns** |  **0.0773 ns** | **0.0042 ns** |         **-** |
| Negate     | ShortRun-.NET 9.0           | .NET 9.0           | -27/200              |  2.028 ns |  0.0486 ns | 0.0027 ns |         - |
| Reciprocal | ShortRun-.NET 9.0           | .NET 9.0           | -27/200              |  3.107 ns |  0.2305 ns | 0.0126 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -27/200              | 17.857 ns |  0.5136 ns | 0.0282 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -27/200              | 14.072 ns |  0.1559 ns | 0.0085 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -27/200              | 21.661 ns |  1.2014 ns | 0.0659 ns |         - |
| **Abs**        | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **0**                    |  **5.479 ns** |  **1.3628 ns** | **0.0747 ns** |         **-** |
| Negate     | ShortRun-.NET 9.0           | .NET 9.0           | 0                    |  2.024 ns |  0.0387 ns | 0.0021 ns |         - |
| Reciprocal | ShortRun-.NET 9.0           | .NET 9.0           | 0                    |  3.674 ns |  0.0802 ns | 0.0044 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 18.155 ns |  1.6911 ns | 0.0927 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 14.062 ns |  0.3364 ns | 0.0184 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 21.757 ns |  0.3423 ns | 0.0188 ns |         - |
| **Abs**        | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **1/1000000000000**      |  **5.535 ns** |  **1.7762 ns** | **0.0974 ns** |         **-** |
| Negate     | ShortRun-.NET 9.0           | .NET 9.0           | 1/1000000000000      |  2.206 ns |  0.0115 ns | 0.0006 ns |         - |
| Reciprocal | ShortRun-.NET 9.0           | .NET 9.0           | 1/1000000000000      |  3.660 ns |  0.1775 ns | 0.0097 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1/1000000000000      | 18.145 ns |  0.3765 ns | 0.0206 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1/1000000000000      | 13.957 ns |  0.2950 ns | 0.0162 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1/1000000000000      | 21.701 ns |  0.6551 ns | 0.0359 ns |         - |
| **Abs**        | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **1/10**                 |  **5.618 ns** |  **0.0705 ns** | **0.0039 ns** |         **-** |
| Negate     | ShortRun-.NET 9.0           | .NET 9.0           | 1/10                 |  2.207 ns |  0.0170 ns | 0.0009 ns |         - |
| Reciprocal | ShortRun-.NET 9.0           | .NET 9.0           | 1/10                 |  3.308 ns |  0.4298 ns | 0.0236 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1/10                 | 18.192 ns |  0.3363 ns | 0.0184 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1/10                 | 13.937 ns |  1.0608 ns | 0.0581 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1/10                 | 21.807 ns |  0.0853 ns | 0.0047 ns |         - |
| **Abs**        | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **27/200**               |  **5.233 ns** |  **0.0899 ns** | **0.0049 ns** |         **-** |
| Negate     | ShortRun-.NET 9.0           | .NET 9.0           | 27/200               |  2.209 ns |  0.2076 ns | 0.0114 ns |         - |
| Reciprocal | ShortRun-.NET 9.0           | .NET 9.0           | 27/200               |  3.372 ns |  2.3775 ns | 0.1303 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 18.215 ns |  2.8318 ns | 0.1552 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 14.168 ns |  2.0038 ns | 0.1098 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 21.829 ns |  0.1670 ns | 0.0092 ns |         - |
| **Abs**        | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **36/96**                |  **7.260 ns** |  **1.1126 ns** | **0.0610 ns** |         **-** |
| Negate     | ShortRun-.NET 9.0           | .NET 9.0           | 36/96                |  2.206 ns |  0.0093 ns | 0.0005 ns |         - |
| Reciprocal | ShortRun-.NET 9.0           | .NET 9.0           | 36/96                |  3.659 ns |  0.5530 ns | 0.0303 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 36/96                | 22.021 ns |  0.3116 ns | 0.0171 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 36/96                | 13.999 ns |  0.4382 ns | 0.0240 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 36/96                | 21.520 ns |  0.3535 ns | 0.0194 ns |         - |
| **Abs**        | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **-42/-96**              |  **6.553 ns** |  **1.8332 ns** | **0.1005 ns** |         **-** |
| Negate     | ShortRun-.NET 9.0           | .NET 9.0           | -42/-96              |  2.205 ns |  0.0073 ns | 0.0004 ns |         - |
| Reciprocal | ShortRun-.NET 9.0           | .NET 9.0           | -42/-96              |  3.676 ns |  0.5015 ns | 0.0275 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -42/-96              | 22.712 ns |  0.1967 ns | 0.0108 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -42/-96              | 15.052 ns |  0.5099 ns | 0.0279 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -42/-96              | 21.598 ns |  1.1727 ns | 0.0643 ns |         - |
| **Abs**        | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **42/66**                |  **7.257 ns** |  **0.0725 ns** | **0.0040 ns** |         **-** |
| Negate     | ShortRun-.NET 9.0           | .NET 9.0           | 42/66                |  2.206 ns |  0.0158 ns | 0.0009 ns |         - |
| Reciprocal | ShortRun-.NET 9.0           | .NET 9.0           | 42/66                |  3.777 ns |  1.5598 ns | 0.0855 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 22.007 ns |  1.0396 ns | 0.0570 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 13.991 ns |  0.6824 ns | 0.0374 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 21.418 ns |  0.2739 ns | 0.0150 ns |         - |
| **Abs**        | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **1**                    |  **5.239 ns** |  **0.0109 ns** | **0.0006 ns** |         **-** |
| Negate     | ShortRun-.NET 9.0           | .NET 9.0           | 1                    |  2.203 ns |  0.0036 ns | 0.0002 ns |         - |
| Reciprocal | ShortRun-.NET 9.0           | .NET 9.0           | 1                    |  3.361 ns |  1.9256 ns | 0.1055 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1                    | 18.105 ns |  0.8582 ns | 0.0470 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1                    | 15.264 ns |  0.3725 ns | 0.0204 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1                    | 21.599 ns |  0.1476 ns | 0.0081 ns |         - |
| **Abs**        | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **88427(...)10656 [31]** |  **5.790 ns** |  **0.0176 ns** | **0.0010 ns** |         **-** |
| Negate     | ShortRun-.NET 9.0           | .NET 9.0           | 88427(...)10656 [31] |  2.206 ns |  0.0024 ns | 0.0001 ns |         - |
| Reciprocal | ShortRun-.NET 9.0           | .NET 9.0           | 88427(...)10656 [31] |  3.477 ns |  0.7590 ns | 0.0416 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 18.016 ns |  0.2350 ns | 0.0129 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 14.152 ns |  1.2904 ns | 0.0707 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 22.272 ns |  8.5967 ns | 0.4712 ns |         - |
| **Abs**        | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **10**                   |  **5.283 ns** |  **0.4547 ns** | **0.0249 ns** |         **-** |
| Negate     | ShortRun-.NET 9.0           | .NET 9.0           | 10                   |  2.220 ns |  0.0865 ns | 0.0047 ns |         - |
| Reciprocal | ShortRun-.NET 9.0           | .NET 9.0           | 10                   |  3.299 ns |  0.5745 ns | 0.0315 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 10                   | 18.576 ns |  6.9611 ns | 0.3816 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 10                   | 15.688 ns |  1.1801 ns | 0.0647 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 10                   | 22.360 ns | 10.2497 ns | 0.5618 ns |         - |
| **Abs**        | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **79228(...)50335 [29]** |  **5.424 ns** |  **0.3287 ns** | **0.0180 ns** |         **-** |
| Negate     | ShortRun-.NET 9.0           | .NET 9.0           | 79228(...)50335 [29] |  2.223 ns |  0.5565 ns | 0.0305 ns |         - |
| Reciprocal | ShortRun-.NET 9.0           | .NET 9.0           | 79228(...)50335 [29] |  3.393 ns |  0.5626 ns | 0.0308 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 79228(...)50335 [29] | 18.217 ns |  2.6635 ns | 0.1460 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 79228(...)50335 [29] | 14.278 ns |  0.9107 ns | 0.0499 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 79228(...)50335 [29] | 21.727 ns |  0.8101 ns | 0.0444 ns |         - |
| **Abs**        | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **∞**                    |  **5.437 ns** |  **0.6188 ns** | **0.0339 ns** |         **-** |
| Negate     | ShortRun-.NET 9.0           | .NET 9.0           | ∞                    |  2.204 ns |  0.3674 ns | 0.0201 ns |         - |
| Reciprocal | ShortRun-.NET 9.0           | .NET 9.0           | ∞                    |  3.343 ns |  0.2780 ns | 0.0152 ns |         - |
| Abs        | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | ∞                    | 18.329 ns |  2.3454 ns | 0.1286 ns |         - |
| Negate     | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | ∞                    | 14.244 ns |  2.4170 ns | 0.1325 ns |         - |
| Reciprocal | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | ∞                    | 18.594 ns |  7.5153 ns | 0.4119 ns |         - |
