```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.300
  [Host]                      : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method      | Job                         | Runtime            | a                    | b                    | Mean       | Error      | StdDev    | Median     | Gen0   | Allocated |
|------------ |---------------------------- |------------------- |--------------------- |--------------------- |-----------:|-----------:|----------:|-----------:|-------:|----------:|
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/-96**               | **36/-96**               |   **4.531 ns** |  **0.2142 ns** | **0.0117 ns** |   **4.535 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  49.028 ns |  2.0206 ns | 0.1108 ns |  48.977 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |   4.910 ns |  0.3713 ns | 0.0203 ns |   4.913 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  20.679 ns |  0.1191 ns | 0.0065 ns |  20.681 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 213.533 ns |  2.3682 ns | 0.1298 ns | 213.476 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  29.926 ns |  1.0217 ns | 0.0560 ns |  29.939 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)000/1 [41]** | **1/1000000000000**      |  **25.124 ns** |  **1.2148 ns** | **0.0666 ns** |  **25.102 ns** | **0.0029** |      **48 B** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)000/1 [41] | 1/1000000000000      |  34.103 ns |  1.1074 ns | 0.0607 ns |  34.077 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)000/1 [41] | 1/1000000000000      |  25.031 ns |  7.3307 ns | 0.4018 ns |  24.866 ns | 0.0029 |      48 B |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      |  70.290 ns |  6.5724 ns | 0.3603 ns |  70.278 ns | 0.0076 |      48 B |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      |  77.280 ns |  4.1797 ns | 0.2291 ns |  77.162 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      |  79.723 ns |  4.2206 ns | 0.2313 ns |  79.755 ns | 0.0076 |      48 B |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1024/1**              | **-1/1024**              |   **9.622 ns** |  **0.7744 ns** | **0.0424 ns** |   **9.628 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  25.162 ns |  0.2693 ns | 0.0148 ns |  25.167 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |   9.528 ns |  1.2665 ns | 0.0694 ns |   9.510 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  36.176 ns |  2.1338 ns | 0.1170 ns |  36.142 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  76.462 ns |  1.5314 ns | 0.0839 ns |  76.479 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  44.022 ns |  6.8040 ns | 0.3729 ns |  43.846 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-45/1**                | **1/6**                  |  **10.033 ns** |  **1.8346 ns** | **0.1006 ns** |   **9.997 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  23.978 ns |  1.3986 ns | 0.0767 ns |  23.936 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |   9.236 ns |  0.7905 ns | 0.0433 ns |   9.223 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  35.351 ns |  0.6343 ns | 0.0348 ns |  35.357 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  70.805 ns |  7.5015 ns | 0.4112 ns |  70.756 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  43.478 ns |  0.8332 ns | 0.0457 ns |  43.453 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **0/1**                  | **1/1**                  |   **4.406 ns** |  **0.1591 ns** | **0.0087 ns** |   **4.408 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 0/1                  | 1/1                  |  19.173 ns |  1.0925 ns | 0.0599 ns |  19.151 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 0/1                  | 1/1                  |   4.798 ns |  0.1580 ns | 0.0087 ns |   4.802 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  20.680 ns |  0.3032 ns | 0.0166 ns |  20.674 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  61.518 ns |  6.5401 ns | 0.3585 ns |  61.322 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  24.352 ns |  0.8618 ns | 0.0472 ns |  24.356 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **77/3600**              | **37/3600**              |   **4.720 ns** |  **0.0117 ns** | **0.0006 ns** |   **4.720 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  32.880 ns |  1.6857 ns | 0.0924 ns |  32.904 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |   4.919 ns |  0.1662 ns | 0.0091 ns |   4.915 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  20.492 ns |  0.2054 ns | 0.0113 ns |  20.486 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 155.598 ns | 64.2601 ns | 3.5223 ns | 157.629 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  29.858 ns |  0.8319 ns | 0.0456 ns |  29.870 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **135/1000**             | **76/1000**              |   **4.386 ns** |  **0.2493 ns** | **0.0137 ns** |   **4.384 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  50.231 ns |  0.8581 ns | 0.0470 ns |  50.232 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |   4.913 ns |  0.3947 ns | 0.0216 ns |   4.919 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  20.668 ns |  2.3379 ns | 0.1281 ns |  20.601 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              | 220.514 ns | 36.8357 ns | 2.0191 ns | 220.450 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  29.798 ns |  1.6929 ns | 0.0928 ns |  29.799 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **27/200**               | **19/250**               |  **16.210 ns** |  **3.7747 ns** | **0.2069 ns** |  **16.120 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  31.093 ns | 11.5649 ns | 0.6339 ns |  30.889 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  15.100 ns |  3.3493 ns | 0.1836 ns |  15.064 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  55.285 ns |  0.8042 ns | 0.0441 ns |  55.266 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 150.644 ns | 13.5802 ns | 0.7444 ns | 150.933 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  60.466 ns |  4.9183 ns | 0.2696 ns |  60.314 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/66**                | **36/96**                |  **16.351 ns** |  **2.8856 ns** | **0.1582 ns** |  **16.428 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  53.403 ns |  9.3933 ns | 0.5149 ns |  53.487 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  15.005 ns |  0.0705 ns | 0.0039 ns |  15.006 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                |  55.965 ns |  4.6435 ns | 0.2545 ns |  56.004 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 212.663 ns | 13.8767 ns | 0.7606 ns | 213.094 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                |  60.632 ns |  8.3203 ns | 0.4561 ns |  60.459 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **70742(...)85248 [33]** | **70742(...)70496 [33]** |  **41.948 ns** |  **2.9570 ns** | **0.1621 ns** |  **41.892 ns** | **0.0048** |      **80 B** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] | 216.571 ns |  6.6989 ns | 0.3672 ns | 216.576 ns | 0.0076 |     128 B |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] |  40.849 ns |  4.8493 ns | 0.2658 ns |  40.965 ns | 0.0048 |      80 B |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 114.215 ns |  2.1830 ns | 0.1197 ns | 114.164 ns | 0.0126 |      80 B |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 311.625 ns |  8.1727 ns | 0.4480 ns | 311.619 ns | 0.0305 |     193 B |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 126.897 ns |  7.0170 ns | 0.3846 ns | 127.085 ns | 0.0126 |      80 B |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **NaN**                  |   **3.744 ns** |  **0.1073 ns** | **0.0059 ns** |   **3.747 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |  35.171 ns |  0.7876 ns | 0.0432 ns |  35.194 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   2.267 ns |  0.0662 ns | 0.0036 ns |   2.266 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  19.480 ns |  0.3110 ns | 0.0170 ns |  19.473 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  | 113.250 ns | 35.6056 ns | 1.9517 ns | 112.139 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  21.791 ns |  1.0232 ns | 0.0561 ns |  21.763 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **-∞**                   |   **3.758 ns** |  **0.0694 ns** | **0.0038 ns** |   **3.757 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |  34.970 ns |  5.2858 ns | 0.2897 ns |  34.870 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   5.202 ns |  2.0040 ns | 0.1098 ns |   5.245 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |   4.929 ns | 42.0201 ns | 2.3033 ns |   3.697 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   | 117.691 ns | 15.4769 ns | 0.8483 ns | 117.360 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  28.947 ns |  2.5040 ns | 0.1373 ns |  28.982 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **0**                    |   **3.763 ns** |  **0.2616 ns** | **0.0143 ns** |   **3.755 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  34.226 ns |  1.3631 ns | 0.0747 ns |  34.261 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   4.732 ns |  0.2098 ns | 0.0115 ns |   4.729 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  19.784 ns |  0.6998 ns | 0.0384 ns |  19.789 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    | 111.322 ns |  6.3846 ns | 0.3500 ns | 111.269 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  29.935 ns |  0.2120 ns | 0.0116 ns |  29.932 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **97/1**                 | **89/1**                 |   **4.720 ns** |  **0.2070 ns** | **0.0113 ns** |   **4.725 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  23.945 ns |  0.2926 ns | 0.0160 ns |  23.954 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |   4.917 ns |  0.1458 ns | 0.0080 ns |   4.922 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  20.528 ns |  0.4315 ns | 0.0237 ns |  20.518 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  72.657 ns |  6.3854 ns | 0.3500 ns |  72.639 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  30.003 ns |  4.0912 ns | 0.2243 ns |  29.883 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1000/1**               | **100/1**                |   **3.781 ns** |  **0.1308 ns** | **0.0072 ns** |   **3.782 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  24.028 ns |  2.5236 ns | 0.1383 ns |  23.949 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |   5.030 ns |  0.1594 ns | 0.0087 ns |   5.031 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  20.537 ns |  0.9259 ns | 0.0508 ns |  20.552 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  70.439 ns |  5.2024 ns | 0.2852 ns |  70.294 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  29.886 ns |  0.5233 ns | 0.0287 ns |  29.890 ns |      - |         - |
