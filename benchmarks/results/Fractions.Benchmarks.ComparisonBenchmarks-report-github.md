```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.300
  [Host]                      : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method                    | Job                         | Runtime            | a                    | b                    | Mean       | Error      | StdDev    | Gen0   | Allocated |
|-------------------------- |---------------------------- |------------------- |--------------------- |--------------------- |-----------:|-----------:|----------:|-------:|----------:|
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)00000 [39]** | **1/1000000000000**      |  **25.694 ns** |  **3.1141 ns** | **0.1707 ns** | **0.0029** |      **48 B** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |   3.929 ns |  0.4083 ns | 0.0224 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  22.699 ns |  0.5989 ns | 0.0328 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  21.893 ns |  1.9434 ns | 0.1065 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  24.168 ns |  3.2012 ns | 0.1755 ns | 0.0029 |      48 B |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  71.137 ns |  3.9653 ns | 0.2174 ns | 0.0076 |      48 B |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  10.086 ns |  1.0774 ns | 0.0591 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  38.444 ns |  6.1483 ns | 0.3370 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  19.505 ns |  0.2179 ns | 0.0119 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  79.842 ns |  5.0205 ns | 0.2752 ns | 0.0076 |      48 B |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1024**                | **-1/1024**              |   **9.759 ns** |  **1.4416 ns** | **0.0790 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |   4.090 ns |  0.1207 ns | 0.0066 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  10.762 ns |  2.4600 ns | 0.1348 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |   7.918 ns |  0.1811 ns | 0.0099 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |   9.552 ns |  0.1815 ns | 0.0099 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  35.710 ns |  3.1209 ns | 0.1711 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |   9.806 ns |  0.2432 ns | 0.0133 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  37.871 ns |  4.1972 ns | 0.2301 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  18.168 ns |  1.1915 ns | 0.0653 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  43.511 ns |  2.1550 ns | 0.1181 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-45**                  | **1/6**                  |  **10.555 ns** |  **2.0678 ns** | **0.1133 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |   4.137 ns |  0.0641 ns | 0.0035 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  10.712 ns |  6.7499 ns | 0.3700 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |   7.534 ns |  0.8596 ns | 0.0471 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |   9.011 ns |  0.7160 ns | 0.0392 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  35.576 ns |  2.1697 ns | 0.1189 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |   8.647 ns |  2.0367 ns | 0.1116 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  29.906 ns |  0.8514 ns | 0.0467 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  18.092 ns |  0.6874 ns | 0.0377 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  43.745 ns |  0.2108 ns | 0.0116 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **0**                    | **1**                    |   **4.505 ns** |  **0.0578 ns** | **0.0032 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   4.089 ns |  0.5526 ns | 0.0303 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |  10.724 ns |  0.2874 ns | 0.0158 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   7.715 ns |  0.1287 ns | 0.0071 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   4.794 ns |  0.7229 ns | 0.0396 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  15.918 ns |  1.6840 ns | 0.0923 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  10.078 ns |  0.1845 ns | 0.0101 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  34.931 ns |  3.1652 ns | 0.1735 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  18.272 ns |  1.2848 ns | 0.0704 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  30.011 ns |  0.3189 ns | 0.0175 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **77/3600**              | **37/3600**              |   **4.698 ns** |  **0.2239 ns** | **0.0123 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |   4.074 ns |  0.1591 ns | 0.0087 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  11.286 ns |  1.2151 ns | 0.0666 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |   7.951 ns |  0.0308 ns | 0.0017 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |   4.982 ns |  0.5159 ns | 0.0283 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  20.458 ns |  0.6828 ns | 0.0374 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |   8.574 ns |  1.4775 ns | 0.0810 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  35.035 ns |  0.6656 ns | 0.0365 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  18.260 ns |  0.3631 ns | 0.0199 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  30.006 ns |  0.1576 ns | 0.0086 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **27/200**               | **19/250**               |  **15.838 ns** |  **2.1451 ns** | **0.1176 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |   3.912 ns |  0.1841 ns | 0.0101 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  10.546 ns |  0.3580 ns | 0.0196 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |   7.739 ns |  0.3747 ns | 0.0205 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  15.052 ns |  0.1334 ns | 0.0073 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  55.315 ns |  2.2459 ns | 0.1231 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  10.481 ns |  0.3474 ns | 0.0190 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  35.198 ns |  0.4679 ns | 0.0256 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  18.140 ns |  0.4887 ns | 0.0268 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  61.040 ns |  6.9295 ns | 0.3798 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **88427(...)10656 [31]** | **88427(...)21312 [31]** |  **48.256 ns** | **24.2880 ns** | **1.3313 ns** | **0.0048** |      **80 B** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] |   5.903 ns |  0.2100 ns | 0.0115 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] |  34.035 ns |  1.5763 ns | 0.0864 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] |  32.185 ns |  0.2096 ns | 0.0115 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] |  41.946 ns |  0.1573 ns | 0.0086 ns | 0.0048 |      80 B |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 112.958 ns |  6.7483 ns | 0.3699 ns | 0.0126 |      80 B |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] |  21.821 ns |  1.4357 ns | 0.0787 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] |  35.715 ns |  1.2400 ns | 0.0680 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] |  23.877 ns |  0.2954 ns | 0.0162 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 130.780 ns |  2.3437 ns | 0.1285 ns | 0.0126 |      80 B |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **NaN**                  |   **3.955 ns** |  **0.1801 ns** | **0.0099 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   3.950 ns |  0.0645 ns | 0.0035 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |  10.861 ns |  1.0164 ns | 0.0557 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   7.734 ns |  0.0836 ns | 0.0046 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   2.447 ns |  0.1288 ns | 0.0071 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  19.590 ns |  1.1834 ns | 0.0649 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  10.026 ns |  0.3050 ns | 0.0167 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  34.834 ns |  0.0635 ns | 0.0035 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  17.971 ns |  0.4923 ns | 0.0270 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  21.949 ns |  0.4685 ns | 0.0257 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **-∞**                   |   **3.965 ns** |  **0.1989 ns** | **0.0109 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   4.097 ns |  0.1796 ns | 0.0098 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |  10.674 ns |  0.1941 ns | 0.0106 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   7.967 ns |  0.1346 ns | 0.0074 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   4.830 ns |  0.0396 ns | 0.0022 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  19.748 ns |  0.5883 ns | 0.0322 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |   8.607 ns |  0.7613 ns | 0.0417 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  35.056 ns |  1.1581 ns | 0.0635 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  18.157 ns |  1.1907 ns | 0.0653 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  29.172 ns |  0.5701 ns | 0.0312 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **0**                    |   **3.769 ns** |  **0.2107 ns** | **0.0115 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   3.927 ns |  0.0997 ns | 0.0055 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  10.706 ns |  0.4235 ns | 0.0232 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   7.594 ns |  0.2313 ns | 0.0127 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   4.874 ns |  0.3784 ns | 0.0207 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  19.994 ns |  1.7029 ns | 0.0933 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |   4.621 ns |  0.9459 ns | 0.0518 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  35.095 ns |  0.9536 ns | 0.0523 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  18.048 ns |  0.0395 ns | 0.0022 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  35.466 ns |  0.3885 ns | 0.0213 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **97**                   | **89**                   |   **4.581 ns** |  **4.0918 ns** | **0.2243 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |   3.918 ns |  0.5192 ns | 0.0285 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |  11.270 ns |  1.3143 ns | 0.0720 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |   7.895 ns |  0.7547 ns | 0.0414 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |   4.877 ns |  0.4726 ns | 0.0259 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  15.735 ns |  0.5150 ns | 0.0282 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |   8.454 ns |  1.6834 ns | 0.0923 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  34.801 ns |  3.5997 ns | 0.1973 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  17.918 ns |  1.2509 ns | 0.0686 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  29.874 ns |  3.0591 ns | 0.1677 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1000**                 | **100**                  |   **4.408 ns** |  **0.1518 ns** | **0.0083 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |   4.104 ns |  0.3148 ns | 0.0173 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |  10.530 ns |  0.4111 ns | 0.0225 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |   7.554 ns |  0.1007 ns | 0.0055 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |   5.029 ns |  0.2079 ns | 0.0114 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  20.509 ns |  0.5477 ns | 0.0300 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |   4.447 ns |  0.2894 ns | 0.0159 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  34.918 ns |  1.0153 ns | 0.0557 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  12.493 ns |  0.6296 ns | 0.0345 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  29.721 ns |  0.2429 ns | 0.0133 ns |      - |         - |
