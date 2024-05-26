```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.300
  [Host]                      : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method      | Job                         | Runtime            | a                    | b                    | Mean       | Error       | StdDev    | Gen0   | Allocated |
|------------ |---------------------------- |------------------- |--------------------- |--------------------- |-----------:|------------:|----------:|-------:|----------:|
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)000/1 [41]** | **1/1000000000000**      |  **25.191 ns** |   **0.4908 ns** | **0.0269 ns** | **0.0029** |      **48 B** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)000/1 [41] | 1/1000000000000      |  33.880 ns |   2.7924 ns | 0.1531 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)000/1 [41] | 1/1000000000000      |  27.178 ns |   2.5203 ns | 0.1381 ns | 0.0029 |      48 B |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      |  75.562 ns |   5.3203 ns | 0.2916 ns | 0.0076 |      48 B |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      |  77.487 ns |   1.6428 ns | 0.0900 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      |  76.814 ns |  12.3789 ns | 0.6785 ns | 0.0076 |      48 B |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1024/1**              | **-1/1024**              |  **10.245 ns** |   **0.2966 ns** | **0.0163 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  25.005 ns |   0.1660 ns | 0.0091 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  11.342 ns |   0.3166 ns | 0.0174 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  45.939 ns |   3.9878 ns | 0.2186 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  75.691 ns |   2.7205 ns | 0.1491 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  40.705 ns |   2.5724 ns | 0.1410 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-45/1**                | **1/6**                  |   **9.453 ns** |   **0.1376 ns** | **0.0075 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  23.996 ns |   2.6495 ns | 0.1452 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  11.067 ns |   1.2258 ns | 0.0672 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  42.559 ns |   2.2044 ns | 0.1208 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  86.635 ns |   6.7422 ns | 0.3696 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  40.267 ns |   7.9585 ns | 0.4362 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/-96**               | **36/-96**               |   **8.551 ns** |   **0.4951 ns** | **0.0271 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  49.581 ns |   0.9535 ns | 0.0523 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |   9.721 ns |   1.4531 ns | 0.0797 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  20.851 ns |   1.0540 ns | 0.0578 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 212.615 ns |   2.9906 ns | 0.1639 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  18.505 ns |   0.6120 ns | 0.0335 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **0/1**                  | **1/1**                  |   **8.063 ns** |   **0.3752 ns** | **0.0206 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 0/1                  | 1/1                  |  19.717 ns |   1.4119 ns | 0.0774 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 0/1                  | 1/1                  |  12.074 ns |   0.3015 ns | 0.0165 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  20.902 ns |   0.3838 ns | 0.0210 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  62.771 ns |  15.0593 ns | 0.8255 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  18.983 ns |   0.6862 ns | 0.0376 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **77/3600**              | **37/3600**              |   **8.246 ns** |   **2.5989 ns** | **0.1425 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  32.648 ns |   2.2979 ns | 0.1260 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  12.019 ns |   0.2533 ns | 0.0139 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  20.630 ns |   1.0169 ns | 0.0557 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 153.460 ns |  31.4009 ns | 1.7212 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  18.647 ns |   0.3353 ns | 0.0184 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **135/1000**             | **76/1000**              |   **8.438 ns** |   **0.8012 ns** | **0.0439 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  50.488 ns |   1.2601 ns | 0.0691 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  12.356 ns |   1.3681 ns | 0.0750 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  20.641 ns |   0.5961 ns | 0.0327 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              | 219.731 ns |  11.7438 ns | 0.6437 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  18.745 ns |   1.2384 ns | 0.0679 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **27/200**               | **19/250**               |  **16.844 ns** |   **0.4270 ns** | **0.0234 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  30.741 ns |   1.4927 ns | 0.0818 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  17.336 ns |   0.4595 ns | 0.0252 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  59.974 ns |   2.7408 ns | 0.1502 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 140.120 ns |   5.1339 ns | 0.2814 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  55.868 ns |   4.7321 ns | 0.2594 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/66**                | **36/96**                |  **16.090 ns** |   **1.5363 ns** | **0.0842 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  50.614 ns |   9.1213 ns | 0.5000 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  17.831 ns |   1.0544 ns | 0.0578 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                |  62.388 ns |   3.0223 ns | 0.1657 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 213.112 ns |   6.3972 ns | 0.3507 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                |  55.804 ns |   2.7767 ns | 0.1522 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **70742(...)85248 [33]** | **70742(...)70496 [33]** |  **43.403 ns** |   **5.4860 ns** | **0.3007 ns** | **0.0048** |      **80 B** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] | 222.331 ns | 104.5301 ns | 5.7296 ns | 0.0076 |     128 B |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] |  46.273 ns |   4.2904 ns | 0.2352 ns | 0.0048 |      80 B |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 129.983 ns |  79.6828 ns | 4.3677 ns | 0.0126 |      80 B |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 313.413 ns |  44.7530 ns | 2.4531 ns | 0.0305 |     193 B |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 120.376 ns |   8.3459 ns | 0.4575 ns | 0.0126 |      80 B |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **NaN**                  |   **7.579 ns** |   **0.2095 ns** | **0.0115 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |  35.467 ns |   0.9376 ns | 0.0514 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   9.300 ns |   1.9475 ns | 0.1067 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  20.154 ns |  12.2857 ns | 0.6734 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  | 113.144 ns |  61.5663 ns | 3.3747 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  16.609 ns |   1.7859 ns | 0.0979 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **-∞**                   |   **7.424 ns** |   **0.8610 ns** | **0.0472 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |  35.387 ns |   6.9313 ns | 0.3799 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |  11.674 ns |   1.8262 ns | 0.1001 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  20.025 ns |   6.0034 ns | 0.3291 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   | 112.339 ns |  10.0400 ns | 0.5503 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  18.327 ns |   4.7829 ns | 0.2622 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **0**                    |   **7.817 ns** |   **2.8960 ns** | **0.1587 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  35.353 ns |   3.6170 ns | 0.1983 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  12.126 ns |   1.2395 ns | 0.0679 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  19.822 ns |   0.2765 ns | 0.0152 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    | 113.698 ns |  17.2699 ns | 0.9466 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  24.462 ns |   2.8591 ns | 0.1567 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **97/1**                 | **89/1**                 |   **8.241 ns** |   **0.8776 ns** | **0.0481 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  24.267 ns |   1.5769 ns | 0.0864 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  12.277 ns |   4.9064 ns | 0.2689 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  21.096 ns |   6.4232 ns | 0.3521 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  72.873 ns |  30.3014 ns | 1.6609 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  18.777 ns |   0.9448 ns | 0.0518 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1000/1**               | **100/1**                |   **8.805 ns** |   **4.1742 ns** | **0.2288 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  24.385 ns |   0.9475 ns | 0.0519 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  12.131 ns |   0.4425 ns | 0.0243 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  20.711 ns |   0.6997 ns | 0.0384 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  72.295 ns |   8.2043 ns | 0.4497 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  18.869 ns |   0.5865 ns | 0.0321 ns |      - |         - |
