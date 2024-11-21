```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5131/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.100
  [Host]                      : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET 9.0           : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9282.0), X64 RyuJIT VectorSize=256

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method      | Job                         | Runtime            | a                    | b                    | Mean       | Error      | StdDev    | Gen0   | Allocated |
|------------ |---------------------------- |------------------- |--------------------- |--------------------- |-----------:|-----------:|----------:|-------:|----------:|
| **Equals**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **-1000(...)000/1 [41]** | **1/1000000000000**      |   **5.984 ns** |  **0.1234 ns** | **0.0068 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | -1000(...)000/1 [41] | 1/1000000000000      |  31.687 ns |  0.6315 ns | 0.0346 ns |      - |         - |
| CompareTo   | ShortRun-.NET 9.0           | .NET 9.0           | -1000(...)000/1 [41] | 1/1000000000000      |   3.563 ns |  0.2992 ns | 0.0164 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      |  24.152 ns |  0.9370 ns | 0.0514 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      |  88.180 ns |  4.5763 ns | 0.2508 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      |  15.895 ns |  0.2002 ns | 0.0110 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **-1024/1**              | **-1/1024**              |  **15.959 ns** |  **0.5015 ns** | **0.0275 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | -1024/1              | -1/1024              |  21.355 ns |  1.8445 ns | 0.1011 ns |      - |         - |
| CompareTo   | ShortRun-.NET 9.0           | .NET 9.0           | -1024/1              | -1/1024              |  12.239 ns |  1.5378 ns | 0.0843 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  23.986 ns |  2.0514 ns | 0.1124 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  76.866 ns |  5.1897 ns | 0.2845 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  28.202 ns |  0.7140 ns | 0.0391 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **-45/1**                | **1/6**                  |   **5.385 ns** |  **0.2009 ns** | **0.0110 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | -45/1                | 1/6                  |  20.603 ns |  0.4186 ns | 0.0229 ns |      - |         - |
| CompareTo   | ShortRun-.NET 9.0           | .NET 9.0           | -45/1                | 1/6                  |   3.647 ns |  0.6650 ns | 0.0365 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  21.551 ns |  0.8569 ns | 0.0470 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  70.921 ns |  4.3363 ns | 0.2377 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  15.769 ns |  0.1683 ns | 0.0092 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **42/-96**               | **36/-96**               |   **7.916 ns** |  **0.5818 ns** | **0.0319 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 42/-96               | 36/-96               |  67.907 ns |  4.4585 ns | 0.2444 ns |      - |         - |
| CompareTo   | ShortRun-.NET 9.0           | .NET 9.0           | 42/-96               | 36/-96               |   4.926 ns |  0.1343 ns | 0.0074 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  21.367 ns |  1.0805 ns | 0.0592 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 234.683 ns |  4.5667 ns | 0.2503 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  16.234 ns |  1.2169 ns | 0.0667 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **0/1**                  | **1/1**                  |   **5.852 ns** |  **0.0761 ns** | **0.0042 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 0/1                  | 1/1                  |  22.120 ns |  2.9639 ns | 0.1625 ns |      - |         - |
| CompareTo   | ShortRun-.NET 9.0           | .NET 9.0           | 0/1                  | 1/1                  |   3.917 ns |  0.1309 ns | 0.0072 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  22.050 ns |  0.8917 ns | 0.0489 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  60.772 ns |  0.5368 ns | 0.0294 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  16.321 ns |  0.3526 ns | 0.0193 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **77/3600**              | **37/3600**              |   **5.742 ns** |  **0.0556 ns** | **0.0030 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 77/3600              | 37/3600              |  22.804 ns |  0.2352 ns | 0.0129 ns |      - |         - |
| CompareTo   | ShortRun-.NET 9.0           | .NET 9.0           | 77/3600              | 37/3600              |   4.249 ns |  0.3586 ns | 0.0197 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  21.923 ns |  0.8752 ns | 0.0480 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 156.152 ns | 13.1189 ns | 0.7191 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  17.782 ns |  0.7414 ns | 0.0406 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **135/1000**             | **76/1000**              |   **5.821 ns** |  **0.1641 ns** | **0.0090 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 135/1000             | 76/1000              |  70.881 ns |  1.6440 ns | 0.0901 ns |      - |         - |
| CompareTo   | ShortRun-.NET 9.0           | .NET 9.0           | 135/1000             | 76/1000              |   4.263 ns |  0.6567 ns | 0.0360 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  21.359 ns |  0.8436 ns | 0.0462 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              | 242.762 ns | 17.9700 ns | 0.9850 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  17.759 ns |  0.6887 ns | 0.0378 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **27/200**               | **19/250**               |  **15.813 ns** |  **1.0737 ns** | **0.0589 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 27/200               | 19/250               |  21.923 ns |  1.0050 ns | 0.0551 ns |      - |         - |
| CompareTo   | ShortRun-.NET 9.0           | .NET 9.0           | 27/200               | 19/250               |   9.949 ns |  0.5356 ns | 0.0294 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  23.782 ns |  1.6207 ns | 0.0888 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 139.120 ns |  8.3536 ns | 0.4579 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  29.046 ns |  2.7510 ns | 0.1508 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **42/66**                | **36/96**                |  **15.655 ns** |  **0.5867 ns** | **0.0322 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 42/66                | 36/96                |  72.343 ns | 23.7330 ns | 1.3009 ns |      - |         - |
| CompareTo   | ShortRun-.NET 9.0           | .NET 9.0           | 42/66                | 36/96                |   9.990 ns |  0.3720 ns | 0.0204 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                |  24.783 ns |  0.8040 ns | 0.0441 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 216.451 ns | 10.9439 ns | 0.5999 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                |  29.125 ns |  3.8164 ns | 0.2092 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **14148(...)70496 [34]** | **70742(...)70496 [33]** |   **7.357 ns** |  **0.0359 ns** | **0.0020 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 14148(...)70496 [34] | 70742(...)70496 [33] | 244.874 ns | 21.0722 ns | 1.1550 ns | 0.0076 |     128 B |
| CompareTo   | ShortRun-.NET 9.0           | .NET 9.0           | 14148(...)70496 [34] | 70742(...)70496 [33] |   6.309 ns |  2.3657 ns | 0.1297 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 14148(...)70496 [34] | 70742(...)70496 [33] |  26.733 ns |  3.5930 ns | 0.1969 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 14148(...)70496 [34] | 70742(...)70496 [33] | 314.974 ns | 24.3971 ns | 1.3373 ns | 0.0305 |     193 B |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 14148(...)70496 [34] | 70742(...)70496 [33] |  21.577 ns |  0.5217 ns | 0.0286 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **245850922/78256779**   | **NaN**                  |   **5.372 ns** |  **0.1269 ns** | **0.0070 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | NaN                  |  32.453 ns |  2.3542 ns | 0.1290 ns |      - |         - |
| CompareTo   | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | NaN                  |   3.162 ns |  2.1874 ns | 0.1199 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  20.743 ns |  1.1686 ns | 0.0641 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  | 116.909 ns | 43.9346 ns | 2.4082 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |   9.763 ns |  0.4860 ns | 0.0266 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **245850922/78256779**   | **-∞**                   |   **5.494 ns** |  **0.0892 ns** | **0.0049 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | -∞                   |  33.678 ns |  4.5713 ns | 0.2506 ns |      - |         - |
| CompareTo   | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | -∞                   |   3.105 ns |  0.4294 ns | 0.0235 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  20.399 ns |  0.8659 ns | 0.0475 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   | 112.409 ns |  0.7860 ns | 0.0431 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  16.651 ns |  0.8770 ns | 0.0481 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **245850922/78256779**   | **0**                    |   **5.506 ns** |  **0.0361 ns** | **0.0020 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | 0                    |  33.251 ns |  8.7072 ns | 0.4773 ns |      - |         - |
| CompareTo   | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | 0                    |   4.031 ns |  3.7409 ns | 0.2051 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  20.678 ns |  0.7663 ns | 0.0420 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    | 119.204 ns |  3.6927 ns | 0.2024 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  17.206 ns |  0.5292 ns | 0.0290 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **12345(...)00000 [36]** | **61728(...)00000 [34]** |  **50.279 ns** |  **2.5113 ns** | **0.1377 ns** | **0.0019** |      **32 B** |
| GetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 12345(...)00000 [36] | 61728(...)00000 [34] |  34.226 ns |  0.1902 ns | 0.0104 ns |      - |         - |
| CompareTo   | ShortRun-.NET 9.0           | .NET 9.0           | 12345(...)00000 [36] | 61728(...)00000 [34] |  49.101 ns |  2.2313 ns | 0.1223 ns | 0.0019 |      32 B |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 12345(...)00000 [36] | 61728(...)00000 [34] | 125.855 ns | 14.6082 ns | 0.8007 ns | 0.0100 |      64 B |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 12345(...)00000 [36] | 61728(...)00000 [34] |  41.989 ns | 11.4239 ns | 0.6262 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 12345(...)00000 [36] | 61728(...)00000 [34] | 115.256 ns | 32.4402 ns | 1.7782 ns | 0.0114 |      72 B |
| **Equals**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **97/1**                 | **89/1**                 |   **5.757 ns** |  **0.5358 ns** | **0.0294 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 97/1                 | 89/1                 |  20.692 ns |  8.3825 ns | 0.4595 ns |      - |         - |
| CompareTo   | ShortRun-.NET 9.0           | .NET 9.0           | 97/1                 | 89/1                 |   4.318 ns |  0.7475 ns | 0.0410 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  22.120 ns |  1.0840 ns | 0.0594 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  75.064 ns | 38.6323 ns | 2.1176 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  17.883 ns |  0.9843 ns | 0.0540 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **1000/1**               | **100/1**                |   **5.874 ns** |  **1.8941 ns** | **0.1038 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 1000/1               | 100/1                |  20.444 ns |  2.7744 ns | 0.1521 ns |      - |         - |
| CompareTo   | ShortRun-.NET 9.0           | .NET 9.0           | 1000/1               | 100/1                |   4.268 ns |  0.2119 ns | 0.0116 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  21.467 ns |  5.2438 ns | 0.2874 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  68.424 ns |  8.5259 ns | 0.4673 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  16.159 ns |  0.2648 ns | 0.0145 ns |      - |         - |
