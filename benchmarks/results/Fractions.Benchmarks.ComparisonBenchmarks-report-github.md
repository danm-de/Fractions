```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5131/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.100
  [Host]                      : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET 9.0           : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9282.0), X64 RyuJIT VectorSize=256

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method                    | Job                         | Runtime            | a                    | b                    | Mean       | Error      | StdDev    | Gen0   | Allocated |
|-------------------------- |---------------------------- |------------------- |--------------------- |--------------------- |-----------:|-----------:|----------:|-------:|----------:|
| **Equals**                    | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **-1000(...)00000 [39]** | **1/1000000000000**      |   **5.890 ns** |  **0.1789 ns** | **0.0098 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 9.0           | .NET 9.0           | -1000(...)00000 [39] | 1/1000000000000      |   2.236 ns |  0.0414 ns | 0.0023 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 9.0           | .NET 9.0           | -1000(...)00000 [39] | 1/1000000000000      |  21.192 ns |  1.3052 ns | 0.0715 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | -1000(...)00000 [39] | 1/1000000000000      |  21.825 ns |  1.0250 ns | 0.0562 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 9.0           | .NET 9.0           | -1000(...)00000 [39] | 1/1000000000000      |   3.493 ns |  0.3616 ns | 0.0198 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  21.684 ns |  1.0173 ns | 0.0558 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |   8.648 ns |  0.2150 ns | 0.0118 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  38.562 ns |  3.1802 ns | 0.1743 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  14.020 ns |  0.1486 ns | 0.0081 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  17.283 ns |  1.5202 ns | 0.0833 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **-1024**                | **-1/1024**              |  **15.881 ns** |  **0.9908 ns** | **0.0543 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 9.0           | .NET 9.0           | -1024                | -1/1024              |   1.812 ns |  3.7988 ns | 0.2082 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 9.0           | .NET 9.0           | -1024                | -1/1024              |   8.300 ns |  0.0593 ns | 0.0032 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | -1024                | -1/1024              |   6.475 ns |  3.3668 ns | 0.1845 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 9.0           | .NET 9.0           | -1024                | -1/1024              |  11.449 ns |  2.4109 ns | 0.1322 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  23.862 ns |  0.1937 ns | 0.0106 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |   8.440 ns |  0.4395 ns | 0.0241 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  34.947 ns |  0.0880 ns | 0.0048 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  18.033 ns |  0.3323 ns | 0.0182 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  29.583 ns |  1.1220 ns | 0.0615 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **-45**                  | **1/6**                  |   **5.332 ns** |  **0.9484 ns** | **0.0520 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 9.0           | .NET 9.0           | -45                  | 1/6                  |   1.818 ns |  3.7899 ns | 0.2077 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 9.0           | .NET 9.0           | -45                  | 1/6                  |   8.310 ns |  5.7092 ns | 0.3129 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | -45                  | 1/6                  |   5.513 ns | 21.2440 ns | 1.1645 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 9.0           | .NET 9.0           | -45                  | 1/6                  |   3.684 ns |  1.9580 ns | 0.1073 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  20.530 ns |  0.6901 ns | 0.0378 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |   9.900 ns |  0.3147 ns | 0.0172 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  34.972 ns |  0.7667 ns | 0.0420 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  18.254 ns |  0.6570 ns | 0.0360 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  16.948 ns |  1.1024 ns | 0.0604 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **0**                    | **1**                    |   **5.738 ns** |  **0.3896 ns** | **0.0214 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 9.0           | .NET 9.0           | 0                    | 1                    |   1.811 ns |  3.8388 ns | 0.2104 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 9.0           | .NET 9.0           | 0                    | 1                    |   8.324 ns |  0.4984 ns | 0.0273 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 0                    | 1                    |   6.177 ns |  0.5200 ns | 0.0285 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 9.0           | .NET 9.0           | 0                    | 1                    |   3.831 ns |  0.1699 ns | 0.0093 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  15.958 ns |  1.6811 ns | 0.0921 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |   8.589 ns |  0.9961 ns | 0.0546 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  35.132 ns |  0.1310 ns | 0.0072 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  18.274 ns |  0.9724 ns | 0.0533 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  16.160 ns |  0.2961 ns | 0.0162 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **77/3600**              | **37/3600**              |   **5.762 ns** |  **0.4242 ns** | **0.0233 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 9.0           | .NET 9.0           | 77/3600              | 37/3600              |   2.168 ns |  0.1991 ns | 0.0109 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 9.0           | .NET 9.0           | 77/3600              | 37/3600              |   8.555 ns |  2.7760 ns | 0.1522 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 77/3600              | 37/3600              |   6.284 ns |  1.8258 ns | 0.1001 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 9.0           | .NET 9.0           | 77/3600              | 37/3600              |   3.916 ns |  0.3202 ns | 0.0176 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  21.215 ns |  0.4700 ns | 0.0258 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  11.341 ns |  0.8436 ns | 0.0462 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  35.106 ns |  0.0974 ns | 0.0053 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  18.200 ns |  0.2478 ns | 0.0136 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  17.663 ns |  0.1186 ns | 0.0065 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **27/200**               | **19/250**               |  **15.616 ns** |  **1.0610 ns** | **0.0582 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 9.0           | .NET 9.0           | 27/200               | 19/250               |   1.685 ns |  0.0580 ns | 0.0032 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 9.0           | .NET 9.0           | 27/200               | 19/250               |   8.398 ns |  0.0492 ns | 0.0027 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 27/200               | 19/250               |   6.734 ns |  9.7559 ns | 0.5348 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 9.0           | .NET 9.0           | 27/200               | 19/250               |   9.892 ns |  0.3008 ns | 0.0165 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  23.682 ns |  0.7169 ns | 0.0393 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  10.077 ns |  0.2454 ns | 0.0135 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  34.954 ns |  1.8297 ns | 0.1003 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  18.181 ns |  0.5751 ns | 0.0315 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  23.421 ns |  0.5306 ns | 0.0291 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **88427(...)10656 [31]** | **88427(...)21312 [31]** |  **20.754 ns** |  **0.6727 ns** | **0.0369 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 9.0           | .NET 9.0           | 88427(...)10656 [31] | 88427(...)21312 [31] |   4.001 ns |  0.3780 ns | 0.0207 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 9.0           | .NET 9.0           | 88427(...)10656 [31] | 88427(...)21312 [31] |  33.798 ns |  0.1870 ns | 0.0103 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 88427(...)10656 [31] | 88427(...)21312 [31] |  31.282 ns |  2.8678 ns | 0.1572 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 9.0           | .NET 9.0           | 88427(...)10656 [31] | 88427(...)21312 [31] |  12.922 ns |  1.8756 ns | 0.1028 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] |  33.962 ns |  2.6542 ns | 0.1455 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] |  22.103 ns |  7.3848 ns | 0.4048 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] |  51.365 ns |  0.5017 ns | 0.0275 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] |  24.514 ns |  1.6139 ns | 0.0885 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] |  35.185 ns |  1.0912 ns | 0.0598 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **245850922/78256779**   | **NaN**                  |   **5.300 ns** |  **0.1189 ns** | **0.0065 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | NaN                  |   2.167 ns |  0.0614 ns | 0.0034 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | NaN                  |   8.361 ns |  0.4112 ns | 0.0225 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | NaN                  |   6.743 ns |  9.2445 ns | 0.5067 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | NaN                  |   3.075 ns |  0.9662 ns | 0.0530 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  20.297 ns |  0.6017 ns | 0.0330 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |   8.382 ns |  0.3014 ns | 0.0165 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  35.051 ns |  2.1277 ns | 0.1166 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  12.938 ns |  0.3944 ns | 0.0216 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  15.182 ns |  0.1456 ns | 0.0080 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **245850922/78256779**   | **-∞**                   |   **5.437 ns** |  **0.4273 ns** | **0.0234 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | -∞                   |   2.341 ns |  0.2447 ns | 0.0134 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | -∞                   |   8.355 ns |  0.0720 ns | 0.0039 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | -∞                   |   6.693 ns |  9.9614 ns | 0.5460 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | -∞                   |   3.343 ns |  0.1665 ns | 0.0091 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  21.039 ns |  0.8773 ns | 0.0481 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |   8.656 ns |  0.2702 ns | 0.0148 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  34.979 ns |  3.3245 ns | 0.1822 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  18.133 ns |  0.3910 ns | 0.0214 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  15.187 ns |  1.8504 ns | 0.1014 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **245850922/78256779**   | **0**                    |   **5.447 ns** |  **0.1579 ns** | **0.0087 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | 0                    |   2.323 ns |  0.1774 ns | 0.0097 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | 0                    |   8.139 ns |  0.5037 ns | 0.0276 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | 0                    |   6.366 ns |  0.4091 ns | 0.0224 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | 0                    |   4.273 ns |  0.6102 ns | 0.0334 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  21.053 ns |  0.3490 ns | 0.0191 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |   8.414 ns |  0.1685 ns | 0.0092 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  35.196 ns |  6.5917 ns | 0.3613 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  17.969 ns |  0.3467 ns | 0.0190 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  16.189 ns | 18.0967 ns | 0.9919 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **12345(...)00000 [36]** | **61728(...)00000 [34]** |  **50.205 ns** | **17.0013 ns** | **0.9319 ns** | **0.0019** |      **32 B** |
| StrictEqualityEquals      | ShortRun-.NET 9.0           | .NET 9.0           | 12345(...)00000 [36] | 61728(...)00000 [34] |   2.527 ns |  0.4278 ns | 0.0234 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 9.0           | .NET 9.0           | 12345(...)00000 [36] | 61728(...)00000 [34] |  34.496 ns |  1.4897 ns | 0.0817 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 12345(...)00000 [36] | 61728(...)00000 [34] |  31.671 ns |  1.8243 ns | 0.1000 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 9.0           | .NET 9.0           | 12345(...)00000 [36] | 61728(...)00000 [34] |  47.952 ns |  1.1949 ns | 0.0655 ns | 0.0019 |      32 B |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 12345(...)00000 [36] | 61728(...)00000 [34] | 125.017 ns | 15.0242 ns | 0.8235 ns | 0.0100 |      64 B |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 12345(...)00000 [36] | 61728(...)00000 [34] |  12.571 ns |  0.6330 ns | 0.0347 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 12345(...)00000 [36] | 61728(...)00000 [34] |  50.814 ns |  2.2838 ns | 0.1252 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 12345(...)00000 [36] | 61728(...)00000 [34] |  24.917 ns |  1.9685 ns | 0.1079 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 12345(...)00000 [36] | 61728(...)00000 [34] | 114.538 ns | 28.0072 ns | 1.5352 ns | 0.0114 |      72 B |
| **Equals**                    | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **97**                   | **89**                   |   **5.862 ns** |  **0.6301 ns** | **0.0345 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 9.0           | .NET 9.0           | 97                   | 89                   |   2.270 ns |  0.0021 ns | 0.0001 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 9.0           | .NET 9.0           | 97                   | 89                   |   8.422 ns |  6.1229 ns | 0.3356 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 97                   | 89                   |   6.175 ns |  0.0243 ns | 0.0013 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 9.0           | .NET 9.0           | 97                   | 89                   |   4.004 ns |  0.3458 ns | 0.0190 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  22.239 ns |  3.6252 ns | 0.1987 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |   8.817 ns |  0.4426 ns | 0.0243 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  43.345 ns |  1.3770 ns | 0.0755 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  18.052 ns |  1.6454 ns | 0.0902 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  11.091 ns |  0.0688 ns | 0.0038 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **1000**                 | **100**                  |   **5.992 ns** |  **3.0327 ns** | **0.1662 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 9.0           | .NET 9.0           | 1000                 | 100                  |   1.833 ns |  4.1526 ns | 0.2276 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 9.0           | .NET 9.0           | 1000                 | 100                  |   8.294 ns |  0.6780 ns | 0.0372 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 9.0           | .NET 9.0           | 1000                 | 100                  |   6.552 ns |  2.8335 ns | 0.1553 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 9.0           | .NET 9.0           | 1000                 | 100                  |   4.295 ns |  0.8683 ns | 0.0476 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  24.614 ns | 62.6469 ns | 3.4339 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  10.056 ns |  1.4074 ns | 0.0771 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  35.286 ns |  2.1271 ns | 0.1166 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  18.182 ns |  1.1126 ns | 0.0610 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  10.661 ns |  0.6337 ns | 0.0347 ns |      - |         - |
