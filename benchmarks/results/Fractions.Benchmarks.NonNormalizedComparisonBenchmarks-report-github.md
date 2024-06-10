```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.300
  [Host]                      : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method      | Job                         | Runtime            | a                    | b                    | Mean       | Error      | StdDev    | Gen0   | Allocated |
|------------ |---------------------------- |------------------- |--------------------- |--------------------- |-----------:|-----------:|----------:|-------:|----------:|
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)000/1 [41]** | **1/1000000000000**      |  **10.169 ns** |  **2.1974 ns** | **0.1204 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)000/1 [41] | 1/1000000000000      |  34.959 ns |  5.3572 ns | 0.2936 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)000/1 [41] | 1/1000000000000      |   7.898 ns |  0.6159 ns | 0.0338 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      |  21.382 ns |  3.4024 ns | 0.1865 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      |  92.334 ns | 14.8665 ns | 0.8149 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      |  15.990 ns |  1.2744 ns | 0.0699 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1024/1**              | **-1/1024**              |  **17.416 ns** |  **4.2197 ns** | **0.2313 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  25.324 ns |  1.8208 ns | 0.0998 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  12.186 ns |  1.0754 ns | 0.0589 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  25.012 ns |  1.6214 ns | 0.0889 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  77.167 ns | 14.7017 ns | 0.8058 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  30.560 ns |  3.0574 ns | 0.1676 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-45/1**                | **1/6**                  |  **10.125 ns** |  **1.6511 ns** | **0.0905 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  24.398 ns |  2.6110 ns | 0.1431 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |   7.639 ns |  0.7118 ns | 0.0390 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  21.824 ns |  1.5237 ns | 0.0835 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  73.061 ns |  3.7304 ns | 0.2045 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  17.334 ns |  1.7697 ns | 0.0970 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/-96**               | **36/-96**               |  **10.970 ns** |  **1.6296 ns** | **0.0893 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  50.294 ns |  3.9009 ns | 0.2138 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |   4.489 ns |  0.6065 ns | 0.0332 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  22.403 ns |  0.7751 ns | 0.0425 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 218.158 ns | 10.7473 ns | 0.5891 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  17.995 ns |  1.1367 ns | 0.0623 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **0/1**                  | **1/1**                  |  **10.037 ns** |  **0.5248 ns** | **0.0288 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 0/1                  | 1/1                  |  20.888 ns | 17.9734 ns | 0.9852 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 0/1                  | 1/1                  |   8.158 ns |  0.1684 ns | 0.0092 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  22.507 ns |  1.1569 ns | 0.0634 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  62.444 ns |  5.7062 ns | 0.3128 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  16.436 ns |  1.3503 ns | 0.0740 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **77/3600**              | **37/3600**              |  **10.125 ns** |  **0.8324 ns** | **0.0456 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  34.997 ns |  1.5864 ns | 0.0870 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |   8.204 ns |  0.2248 ns | 0.0123 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  19.796 ns |  1.5447 ns | 0.0847 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 156.650 ns | 18.4823 ns | 1.0131 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  17.991 ns |  0.2980 ns | 0.0163 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **135/1000**             | **76/1000**              |  **10.109 ns** |  **0.8367 ns** | **0.0459 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  47.122 ns |  0.5744 ns | 0.0315 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |   8.253 ns |  0.5386 ns | 0.0295 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  22.338 ns |  0.1922 ns | 0.0105 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              | 224.256 ns | 23.6965 ns | 1.2989 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  17.975 ns |  1.2191 ns | 0.0668 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **27/200**               | **19/250**               |  **17.213 ns** |  **0.7556 ns** | **0.0414 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  31.298 ns |  0.3139 ns | 0.0172 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  11.616 ns |  0.4288 ns | 0.0235 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  23.901 ns |  1.5878 ns | 0.0870 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 141.952 ns | 28.1680 ns | 1.5440 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  29.083 ns |  0.5795 ns | 0.0318 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/66**                | **36/96**                |  **17.149 ns** |  **1.4635 ns** | **0.0802 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  51.297 ns |  2.7029 ns | 0.1482 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  11.689 ns |  3.4611 ns | 0.1897 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                |  24.735 ns |  1.5548 ns | 0.0852 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 215.849 ns | 15.0124 ns | 0.8229 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                |  28.976 ns |  1.0837 ns | 0.0594 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **70742(...)85248 [33]** | **70742(...)70496 [33]** |  **22.902 ns** |  **0.1506 ns** | **0.0083 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] | 231.468 ns | 22.3489 ns | 1.2250 ns | 0.0076 |     128 B |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] |  15.637 ns |  2.5112 ns | 0.1376 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] |  31.704 ns |  1.8954 ns | 0.1039 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 351.757 ns | 15.7862 ns | 0.8653 ns | 0.0305 |     193 B |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] |  35.516 ns |  0.7808 ns | 0.0428 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **NaN**                  |   **9.482 ns** |  **2.2874 ns** | **0.1254 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |  35.735 ns |  2.0529 ns | 0.1125 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   8.228 ns |  0.4316 ns | 0.0237 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  21.259 ns |  0.1411 ns | 0.0077 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  | 112.799 ns | 14.0422 ns | 0.7697 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  10.000 ns |  2.2610 ns | 0.1239 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **-∞**                   |   **9.440 ns** |  **0.8286 ns** | **0.0454 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |  36.114 ns |  3.1421 ns | 0.1722 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   8.192 ns |  0.5083 ns | 0.0279 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  21.161 ns |  1.3687 ns | 0.0750 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   | 113.731 ns |  9.2762 ns | 0.5085 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |   9.788 ns |  3.2391 ns | 0.1775 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **0**                    |   **9.431 ns** |  **0.6978 ns** | **0.0382 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  34.897 ns |  3.9927 ns | 0.2189 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   8.122 ns |  0.5425 ns | 0.0297 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  21.463 ns |  1.2987 ns | 0.0712 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    | 118.811 ns |  9.8212 ns | 0.5383 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  15.493 ns |  1.2580 ns | 0.0690 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **12345(...)00000 [36]** | **61728(...)00000 [34]** |  **59.451 ns** |  **3.1684 ns** | **0.1737 ns** | **0.0019** |      **32 B** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 12345(...)00000 [36] | 61728(...)00000 [34] |  34.514 ns |  4.0659 ns | 0.2229 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 12345(...)00000 [36] | 61728(...)00000 [34] |  53.054 ns |  1.3692 ns | 0.0750 ns | 0.0019 |      32 B |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 12345(...)00000 [36] | 61728(...)00000 [34] | 122.620 ns |  4.5927 ns | 0.2517 ns | 0.0100 |      64 B |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 12345(...)00000 [36] | 61728(...)00000 [34] |  42.151 ns |  2.0990 ns | 0.1151 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 12345(...)00000 [36] | 61728(...)00000 [34] | 117.796 ns | 20.4771 ns | 1.1224 ns | 0.0114 |      72 B |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **97/1**                 | **89/1**                 |  **10.067 ns** |  **0.6203 ns** | **0.0340 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  24.030 ns |  2.0228 ns | 0.1109 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |   8.164 ns |  0.5195 ns | 0.0285 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  21.476 ns |  2.8838 ns | 0.1581 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  74.178 ns | 11.2458 ns | 0.6164 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  16.288 ns |  1.8476 ns | 0.1013 ns |      - |         - |
| **Equals**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1000/1**               | **100/1**                |  **10.094 ns** |  **1.0917 ns** | **0.0598 ns** |      **-** |         **-** |
| GetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  24.437 ns |  1.2892 ns | 0.0707 ns |      - |         - |
| CompareTo   | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |   8.215 ns |  0.3537 ns | 0.0194 ns |      - |         - |
| Equals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  21.416 ns |  0.5761 ns | 0.0316 ns |      - |         - |
| GetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  73.275 ns |  1.8742 ns | 0.1027 ns |      - |         - |
| CompareTo   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  17.928 ns |  1.5321 ns | 0.0840 ns |      - |         - |
